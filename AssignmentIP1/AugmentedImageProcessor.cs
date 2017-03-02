using ImageProcessingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FaceRecognitionApplication
{
    class AugmentedImageProcessor : ImageProcessor
    {
        public AugmentedImageProcessor(Bitmap bitmap)
            : base(bitmap)
        { }

        public void Average(bool[,] matrix, int size, int fraction)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);

            int adjWidth = width / size;
            int adjHeight = height / size;

            int numTrueThreshold = (int)((double)size * size / fraction + 0.5);
            Parallel.For(0, adjWidth, x =>
            {
                Parallel.For(0, adjHeight, y =>
                {
                    int numTrue = 0;
                    for (int i = x * size; i < size * (x + 1); i++)
                        for (int j = y * size; j < size * (y + 1); j++)
                            if (matrix[i, j])
                                numTrue++;

                    bool thresholdReached = numTrue >= numTrueThreshold;
                    for (int i = x * size; i < size * (x + 1); i++)
                        for (int j = y * size; j < size * (y + 1); j++)
                            matrix[i, j] = thresholdReached;
                });
            });
        }

        public bool[,] BinaryImage()
        {
            bool[,] binary = new bool[bitmapData.Width, bitmapData.Height];

            unsafe
            {
                int bytesPerPixel = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                int widthInBytes = bitmapData.Width * bytesPerPixel;

                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;
                Parallel.For(0, bitmapData.Height, y =>
                {
                    byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int blue = currentLine[x];
                        int green = currentLine[x + 1];
                        int red = currentLine[x + 2];
                        binary[x / bytesPerPixel, y / bytesPerPixel] = blue != 0 && green != 0 && red != 0;
                    }
                });
            }

            return binary;
        }

        public void FindHairPixelsChenLin()
        {
            unsafe
            {
                int bytesPerPixel = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                int widthInBytes = bitmapData.Width * bytesPerPixel;

                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;
                Parallel.For(0, bitmapData.Height, y =>
                {
                    byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int blue = currentLine[x];
                        int green = currentLine[x + 1];
                        int red = currentLine[x + 2];

                        //HSI stuff
                        double I = GetIntensity(blue, green, red); //Ref (7)
                        double H = GetHue(blue, green, red);

                        //Detect skin
                        bool isHair = I < 80 && (blue - green < 15 || blue - red < 15)
                        || (H < 20 && H <= 40);
                        if (isHair)
                        {
                            currentLine[x] = 255;
                            currentLine[x + 1] = 255;
                            currentLine[x + 2] = 255;
                        }
                        else
                        {
                            currentLine[x] = 0;
                            currentLine[x + 1] = 0;
                            currentLine[x + 2] = 0;
                        }
                    }
                });
            }
        }

        public static Tuple<int, int, int, int> GetBoundries(bool[,] binaryImage)
        {
            int width = binaryImage.GetLength(0);
            int height = binaryImage.GetLength(1);

            int minX = width;
            int maxX = 0;
            int minY = height;
            int maxY = 0;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (binaryImage[x, y])
                    {
                        if (x < minX)
                            minX = x;
                        else if (x > maxX)
                            maxX = x;

                        if (y < minY)
                            minY = y;
                        else if (y > maxY)
                            maxY = y;
                    }
                }
            }

            return Tuple.Create(minX, minY, maxX, maxY);
        }

        public void DrawRect(Tuple<int, int, int, int> bounds, int lineWidth)
        {
            int x1 = bounds.Item1;
            int y1 = bounds.Item2;
            int x2 = bounds.Item3;
            int y2 = bounds.Item4;
            Console.WriteLine(bounds.ToString());
            unsafe
            {
                int bytesPerPixel = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                int widthInBytes = bitmapData.Width * bytesPerPixel;

                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                //Vertical lines
                Parallel.For(y1, y2, y =>
                {
                    Console.WriteLine("y = " + y);
                    byte* currentLine = ptrFirstPixel + y * bitmapData.Stride;
                    //left
                    for (int x = x1; x < x1 + lineWidth; x++)
                    {
                        int xp = x * widthInBytes;
                        currentLine[xp] = 0;
                        currentLine[xp + 1] = 0;
                        currentLine[xp + 2] = 255;
                    }
                    //right
                    for (int x = x2 - lineWidth; x < x2; x++)
                    {
                        int xp = x * widthInBytes;
                        currentLine[xp] = 0;
                        currentLine[xp + 1] = 0;
                        currentLine[xp + 2] = 255;
                    }
                });
            }
        }

        public void BinaryImage(bool[,] binaryImage)
        {
            unsafe
            {
                int bytesPerPixel = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                int widthInBytes = bitmapData.Width * bytesPerPixel;

                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;
                Parallel.For(0, bitmapData.Height, y =>
                {
                    byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        if (binaryImage[x / bytesPerPixel, y / bytesPerPixel])
                        {
                            currentLine[x] = 255;
                            currentLine[x + 1] = 255;
                            currentLine[x + 2] = 255;
                        }
                        else
                        {
                            currentLine[x] = 0;
                            currentLine[x + 1] = 0;
                            currentLine[x + 2] = 0;
                        }
                    }
                });
            }
        }

        /// <summary>
        /// Skin pixel detection by formulae (8), Simple Face-detection Algorithm Based on
        /// Minimum Facial Features, Yao-Jiunn Chen, Yen-Chun Lin, 2007
        /// </summary>
        public Tuple<int, int, int, int> FindSkinPixelsChenLin()
        {
            unsafe
            {
                int bytesPerPixel = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                int widthInBytes = bitmapData.Width * bytesPerPixel;

                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;
                Parallel.For(0, bitmapData.Height, y =>
                {
                    byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int blue = currentLine[x];
                        int green = currentLine[x + 1];
                        int red = currentLine[x + 2];

                        //Normalized stuff
                        Tuple<double, double, double> normalized = NormalizePixel(
                            blue, green, red);
                        double b = normalized.Item1;
                        double g = normalized.Item2;
                        double r = normalized.Item3;
                        double f1 = -1.376 * r * r + 1.074 * r + 0.2; //Ref (3)
                        double f2 = -0.776 * r * r + 0.5601 * r + 0.18; //Ref (4)
                        double w = (r - 0.33) * (r - 0.33) + (g - 0.33) * (g - 0.33); //Ref (5)
                        //w = 1;

                        //HSI stuff
                        double H = GetHue(blue, green, red); //Ref (7)

                        //Detect skin
                        bool isSkin = g < f1 && g > f2 && w > 0.001 &&
                        (H > 240 || H <= 20);
                        if (isSkin)
                        {
                            currentLine[x] = 255;
                            currentLine[x + 1] = 255;
                            currentLine[x + 2] = 255;
                        }
                        else
                        {
                            currentLine[x] = 0;
                            currentLine[x + 1] = 0;
                            currentLine[x + 2] = 0;
                        }
                    }
                });
            }
            bool[,] binaryImage = BinaryImage();
            Average(binaryImage, 5, 2);
            BinaryImage(binaryImage);
            return GetBoundries(binaryImage);
        }

        /// <summary>
        /// Hues element, ref 7. Simple Face-detection Algorithm Based on
        /// Minimum Facial Features, Yao-Jiunn Chen, Yen-Chun Lin, 2007
        /// </summary>
        private static double GetHue(int B, int G, int R)
        {
            double numerator = 0.5 * ((R - G) + (R - B));
            double denominator = Math.Sqrt((R - G) * (R - G) + (R - B) * (G - B));

            double arg = numerator / denominator;
            double theta = RadianToDegree(Math.Acos(arg)); //Acos returns radians

            return B <= G ? theta : 360 - theta;
        }

        private static double GetIntensity(int B, int G, int R)
        {
            return (B + G + R) / 3.0;
        }

        private static double RadianToDegree(double angle)
        {
            return angle * 180.0 / Math.PI;
        }

        private Tuple<double, double, double> NormalizePixel(int B, int G, int R)
        {
            double sum = B + G + R;
            double newBlue = B / sum;
            double newGreen = G / sum;
            double newRed = R / sum;
            return Tuple.Create(newBlue, newGreen, newRed);
        }
    }
}
