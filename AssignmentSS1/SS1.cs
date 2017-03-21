using AudioLibrary;
using ObjectSerializerLibrary;
using SpeechSynthesisLibrary.FormantSynthesis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormatSpeechDemo
{
    public partial class Ss1 : Form
    {
        #region Fields

        private SpeechSynthesizer _synthesizer;
        private const string SynthPath = "\\..\\..\\ss.xml";
        #endregion

        public Ss1()
        {
            InitializeComponent();
            try
            {
                string applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                LoadSynthesizer(applicationDirectory + SynthPath);
            }
            catch (Exception)
            {
                speakSentenceButton.Enabled = false;
                speakWordButton.Enabled = false;
            }
        }

        private void RemoveSentenceWord(object sender, MouseEventArgs e)
        {
            int i = sentenceBox.SelectedIndex;
            sentenceBox.Items.RemoveAt(i);
        }

        private void AddSentenceWord(object sender, MouseEventArgs e)
        {
            var i = wordBox.SelectedItem;
            sentenceBox.Items.Add(i);
        }

        private void SpeakSentence(object sender, EventArgs e)
        {
            if (sentenceBox.Items.Count == 0) return;

            List<string> wordList = new List<string>(sentenceBox.Items.Count);
            List<double> silenceList = new List<double>(sentenceBox.Items.Count);

            foreach (var v in sentenceBox.Items)
            {
                string word = v as string;
                wordList.Add(word);
                silenceList.Add(0.5);
            }

            WAVSound sentence = _synthesizer.GenerateWordSequence(wordList, silenceList);

            SoundPlayer soundPlayer = new SoundPlayer();
            sentence.GenerateMemoryStream();
            sentence.WAVMemoryStream.Position = 0; // Manually rewind stream 
            soundPlayer.Stream = null; //TODO varför?
            soundPlayer.Stream = sentence.WAVMemoryStream;
            soundPlayer.PlaySync();
        }

        private void load_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "xml files (*.xml)|*.xml";
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                LoadSynthesizer(openFileDialog.FileName);
            }
        }

        private void LoadSynthesizer(string path)
        {
            try
            {
                _synthesizer = (SpeechSynthesizer)ObjectXmlSerializer.ObtainSerializedObject(path, typeof(SpeechSynthesizer));
                sentenceBox.Items.Clear();
                wordBox.Items.Clear();
                LoadSynthesizer(_synthesizer);
                speakSentenceButton.Enabled = true;
                speakWordButton.Enabled = true;
            }
            catch (Exception)
            {
                speakSentenceButton.Enabled = false;
                speakWordButton.Enabled = false;
            }
        }

        private void LoadSynthesizer(SpeechSynthesizer synthesizer)
        {
            synthesizer.SpecificationList.Sort((a, b) => String.Compare(a.Name, b.Name, StringComparison.Ordinal));

            //Load the sounds into list.
            sentenceBox.Items.Clear();
            wordBox.Items.Clear();

            foreach (var wtsm in synthesizer.WordToSoundMappingList)
                wordBox.Items.Add(wtsm.Word);

            speakWordButton.Enabled = true;
            speakSentenceButton.Enabled = true;
        }

        private void SingleWord(object sender, EventArgs e)
        {
            var word = wordBox.SelectedItem;
            if (word != null)
            {
                WAVSound sound = _synthesizer.GenerateWord((string)word);

                SoundPlayer soundPlayer = new SoundPlayer();
                sound.GenerateMemoryStream();
                sound.WAVMemoryStream.Position = 0; // Manually rewind stream 
                soundPlayer.Stream = null;
                soundPlayer.Stream = sound.WAVMemoryStream;
                soundPlayer.PlaySync();
            }
        }
    }
}
