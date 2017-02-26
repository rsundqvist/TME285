using AudioLibrary;
using SpeechRecognitionLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IsolatedWordRecognitionApplication
{
    class EAForISR
    {
        #region const
        private const int MAX_ITERATIONS = 1000;
        private const int SAMPLE_SIZE = 5;
        private const double MAX_GENERATIONS_WITHOUT_IMPROVEMENT = 20;

        private const int NUMBER_OF_INDIVIDUALS = 100;
        private const double CREEP_RANGE = 0.1;
        private const double SQUASH_PARAMETER = 0.3;
        private const double INITIAL_WEIGHT_RANGE = 1;
        private const double DUEL_SELECTION_PARAMETER = 0.7;
        private const double CROSS_PARAMETER = 0.7;

        private const int KNOWN_SOUNDS_PER_TEST = 10;
        private const int UNKNOWN_SOUNDS_PER_TEST = 6;
        #endregion

        #region field
        private readonly Random random = new Random();
        private readonly IsolatedWordRecognizer recognizer;
        private List<string> recognizerSounds; //= recognizer.GetAvailableSounds();
        private readonly List<List<WAVSound>> testSound = new List<List<WAVSound>>();
        private readonly List<WAVSound> unknownSoundList = new List<WAVSound>();

        private List<List<double>> population;
        private List<List<double>> tmpPopulation;
        private List<double> bestIndividual;
        private List<double> popFitness;
        private double bestFitness;
        #endregion

        public EAForISR(IsolatedWordRecognizer recognizer)
        {
            this.recognizer = recognizer;
            recognizer.RecognitionThreshold = 0.005;
        }

        #region private
        private void initialize()
        {
            int numWeights = recognizer.WeightList.Count;

            population = new List<List<double>>(NUMBER_OF_INDIVIDUALS);
            tmpPopulation = new List<List<double>>(NUMBER_OF_INDIVIDUALS);
            popFitness = new List<double>(NUMBER_OF_INDIVIDUALS);

            List<double> weightList;
            double initialWeight;
            for (int i = 0; i < NUMBER_OF_INDIVIDUALS; i++)
            {
                popFitness.Add(double.MinValue);

                //Create random initial weights
                weightList = new List<double>(numWeights);
                for (int j = 0; j < numWeights; j++)
                {
                    initialWeight = -INITIAL_WEIGHT_RANGE + 2 * random.NextDouble();
                    weightList.Add(initialWeight);
                }

                population.Add(weightList);
                tmpPopulation.Add(weightList);
            }

            bestIndividual = new List<double>(recognizer.WeightList);
            bestFitness = evaluate(bestIndividual);
            insertElites(1);
        }

        private void mutate(List<double> individual)
        {
            int length = individual.Count;

            double creep;
            for (int i = 0; i < length; i++)
            {
                if (SQUASH_PARAMETER < random.NextDouble())
                {
                    individual[i] = 0;
                }
                else
                {
                    double weight = individual[i];

                    creep = -CREEP_RANGE + 2 * CREEP_RANGE * random.NextDouble();
                    weight = weight + creep;

                    individual[i] = weight;
                }
            }
        }

        private Tuple<List<double>, List<double>> cross(List<double> p1, List<double> p2, double crossProbability)
        {
            List<double> child1;
            List<double> child2;
            if (random.NextDouble() < crossProbability)
            {
                int length = p1.Count;

                child1 = new List<double>();
                child2 = new List<double>();

                int cutoff = random.Next(0, length - 1); //Single-point cutoff

                for (int i = 0; i < cutoff; i++)
                {
                    child1.Add(p1[i]);
                    child2.Add(p1[i]);
                }

                for (int i = cutoff; i < length; i++)
                {
                    child1.Add(p2[i]);
                    child2.Add(p2[i]);
                }
            }
            else
            {
                child1 = p1;
                child2 = p2;
            }

            return new Tuple<List<double>, List<double>>(child1, child2);
        }

        private int duelSelect(int i1, int i2, double selectionParameter)
        {
            int winner = popFitness[i2] > popFitness[i1] ? i2 : i1;

            if (selectionParameter < random.NextDouble())
                winner = winner == i1 ? i2 : i1;

            return winner;
        }

        private double evaluate(List<double> individual)
        {
            recognizer.WeightList = individual;
            double fitness = 0;
            List<WAVSound> testKnown = new List<WAVSound>(KNOWN_SOUNDS_PER_TEST);
            List<WAVSound> testUnknown = new List<WAVSound>(UNKNOWN_SOUNDS_PER_TEST);

            for (int i = 0; i < SAMPLE_SIZE; i++)
            {
                testKnown.Clear();
                testUnknown.Clear();
                populateRandomKnown(testKnown);
                populateRandomUnknown(testUnknown);

                foreach (WAVSound sound in testKnown)
                    fitness += evaluateKnown(sound);

                foreach (WAVSound sound in testUnknown)
                    fitness += evaluateUnknown(sound);
            }

            return fitness / SAMPLE_SIZE;
        }

        private double evaluateKnown(WAVSound knownSound)
        {
            double fitness;

            Tuple<string, double, bool> result = recognize(knownSound);
            if (result.Item3 && knownSound.Name.Contains(result.Item1))
                fitness = 1 / result.Item2;
            else
                fitness = -result.Item2 * result.Item2; //Didnt recognize at all or recognized wrong sound

            //Console.WriteLine("    " + knownSound.Name + ": RESULT = " + result.Item1 + ", d = "
            //    + result.Item2 + ", R = " + (result.Item3 && knownSound.Name.Equals(result.Item1)));
            return fitness;
        }

        private double evaluateUnknown(WAVSound unknownSound)
        {
            double fitness;

            Tuple<string, double, bool> result = recognize(unknownSound);
            if (!result.Item3)
                fitness = result.Item2 * result.Item2; //Doesnt recgonize unknown sound - good!
            else
                fitness = -1 / result.Item2; //Recgonized unknown sound as known.

            double f = Math.Pow(Math.E, 2);
            //Console.WriteLine("    " + unknownSound.Name + ": RESULT = " + result.Item1 + ", d = "
            //    + result.Item2 + ", R = " + (result.Item3 && unknownSound.Name.Equals(result.Item1)));
            return fitness;
        }



        private void populateRandomUnknown(List<WAVSound> list)
        {
            for (int i = 0; i < UNKNOWN_SOUNDS_PER_TEST; i++)
            {
                int rand = random.Next(unknownSoundList.Count);
                list.Add(unknownSoundList[rand]);
            }
        }

        private void populateRandomKnown(List<WAVSound> list)
        {
            for (int i = 0; i < KNOWN_SOUNDS_PER_TEST; i++)
            {
                int randWord = random.Next(testSound.Count);
                int randSample = random.Next(testSound[randWord].Count);
                WAVSound sound = testSound[randWord][randSample];
                list.Add(sound);
            }
        }

        private void insertElites(int numElites)
        {
            for (int i = NUMBER_OF_INDIVIDUALS - numElites; i < NUMBER_OF_INDIVIDUALS; i++)
            {
                population[i] = bestIndividual;
                popFitness[i] = bestFitness;
            }
        }

        #endregion

        #region
        public void evolve()
        {
            Thread thread = new Thread(evolveInternal);
            thread.Start();
            //Task.Factory.StartNew(() => evolveInternal());
        }
        private void evolveInternal()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("START EVOLVE");
            Console.WriteLine("RecognitionThreshold: " + recognizer.RecognitionThreshold);
            initialize();

            int iteration = 0;
            int generationsWithoutImprovement = 0;
            int isNaNCount = 0;
            while (iteration < MAX_ITERATIONS && generationsWithoutImprovement < MAX_GENERATIONS_WITHOUT_IMPROVEMENT)
            {
                iteration++;
                generationsWithoutImprovement++;

                // ===========================================================
                // Evaluate population
                // =========================================================== 
                for (int i = 0; i < NUMBER_OF_INDIVIDUALS; i++)
                {
                    popFitness[i] = evaluate(population[i]);

                    while (double.IsNaN(popFitness[i])) //Result from IPA somtimes NaN.
                    {
                        isNaNCount++;
                        int numWeights = recognizer.WeightList.Count;

                        //Create random initial weights
                        List<Double> weightList = new List<double>(numWeights);
                        for (int j = 0; j < numWeights; j++)
                        {
                            double initialWeight = -INITIAL_WEIGHT_RANGE + 2 * random.NextDouble();
                            weightList.Add(initialWeight);
                        }
                        population[i] = weightList;
                        tmpPopulation[i] = weightList;
                        popFitness[i] = evaluate(weightList);
                    }

                    if (popFitness[i] > bestFitness)
                    {
                        bestFitness = popFitness[i];
                        bestIndividual = new List<double>(population[i]); //Should not be mutated.
                        generationsWithoutImprovement = 0;
                    }
                }

                // ===========================================================
                // Select
                // =========================================================== 
                for (int i = 0; i < NUMBER_OF_INDIVIDUALS; i++)
                {
                    int i1 = random.Next(0, NUMBER_OF_INDIVIDUALS);
                    int i2 = random.Next(0, NUMBER_OF_INDIVIDUALS);
                    int winner = duelSelect(i1, i2, DUEL_SELECTION_PARAMETER);
                    tmpPopulation[i] = population[winner];
                }

                // ===========================================================
                // Cross
                // =========================================================== 
                for (int i = 0; i < NUMBER_OF_INDIVIDUALS - 1; i = i + 2)
                {
                    Tuple<List<double>, List<double>> children
                        = cross(tmpPopulation[i], tmpPopulation[i + 1], CROSS_PARAMETER);
                    tmpPopulation[i] = children.Item1;
                    tmpPopulation[i + 1] = children.Item2;
                }

                // ===========================================================
                // Mutate temp population
                // =========================================================== 
                for (int i = 0; i < NUMBER_OF_INDIVIDUALS; i++)
                    mutate(tmpPopulation[i]);

                // ===========================================================
                // Swap generations and insert elite
                // =========================================================== 
                for (int i = 0; i < NUMBER_OF_INDIVIDUALS; i++)
                    population[i] = tmpPopulation[i];

                insertElites(1);

                int avg = (int)(popFitness.Sum() / popFitness.Count + 0.5);
                int max = (int)(bestFitness + 0.5);
                Console.WriteLine("(i, max, avg) = ({0},\t{1},\t{2}), GWO:\t{3}/{4},\t NaN remakes: {5}",
                    iteration, max, avg, generationsWithoutImprovement, MAX_GENERATIONS_WITHOUT_IMPROVEMENT, isNaNCount);
                /*
                Console.WriteLine("i =  " + iteration + ", max = " + max +
                    ", avg = " + avg + ", gwo = " + generationsWithoutImprovement + "/" + MAX_GENERATIONS_WITHOUT_IMPROVEMENT + ", NaN = " + isNaNCount);
                    */
            }

            //Done
            recognizer.WeightList = bestIndividual;
            Console.WriteLine("BEST: " + bestFitness);
        }

        /// <summary>
        /// Import all sounds from the subfolders of a folder (given as parameter). Assumes that test sounds are placed 
        /// in folders with the same name as those found in IsolatedWordRecognizer.GetAvailableSounds().
        /// </summary>
        /// <param name="folder">The root folder for the test sounds.</param>
        public void importTestSounds(string folder)
        {
            recognizerSounds = recognizer.GetAvailableSounds();

            for (int i = 0; i < recognizerSounds.Count; i++)
            {
                string[] filePaths = Directory.GetFiles(folder + "\\" + recognizerSounds[i]);
                List<WAVSound> soundList = new List<WAVSound>(filePaths.Length);

                foreach (string path in filePaths)
                {
                    WAVSound sound = new WAVSound();
                    sound.LoadFromFile(path);
                    sound.Name = recognizerSounds[i];
                    soundList.Add(sound);
                }
                Console.WriteLine("samples = " + soundList.Count);
                testSound.Add(soundList);
            }

            Console.WriteLine("numWords = " + testSound.Count);
        }

        /// <summary>
        /// Imports all sounds in a folder and treats them as unkown.
        /// </summary>
        /// <param name="folder">The folder path.</param>
        public void importUnknownSounds(string folder)
        {
            string[] filePaths = Directory.GetFiles(folder);
            unknownSoundList.Capacity = (filePaths.Length);

            foreach (string path in filePaths)
            {
                WAVSound sound = new WAVSound();
                sound.LoadFromFile(path);
                sound.Name = "UNKNOWN";
                unknownSoundList.Add(sound);
            }
            Console.WriteLine("unknownSoundList = " + unknownSoundList.Count);
        }

        /// <summary>
        /// Returns the winner
        /// Item1: Sound name
        /// Item2: Deviation
        /// Item3: Recognized
        /// </summary>
        /// <param name="sound"></param>
        /// <returns></returns>
        private Tuple<string, double, bool> recognize(WAVSound sound)
        {
            RecognitionResult recognitionResult = recognizer.RecognizeSingle(sound);

            Tuple<string, double> best = recognitionResult.DeviationList[0];
            bool recognized = best.Item2 < recognizer.RecognitionThreshold;

            //Console.WriteLine("min = " + recognitionResult.DeviationList[0].Item2 +
            //    ", max = " + recognitionResult.DeviationList[recognitionResult.DeviationList.Count-1].Item2);

            return Tuple.Create(best.Item1, best.Item2, recognized);
        }

        /// <summary>
        /// testSound.Clear(); unknownSoundList.Clear();
        /// </summary>
        public void clearTestSounds()
        {
            testSound.Clear();
            unknownSoundList.Clear();
        }
        #endregion
    }
}
