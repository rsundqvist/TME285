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
        {
        }

        /// <summary>
        /// Normalization by formulae (9) and (10) in Simple Face-detection Algorithm Based on
        /// Minimum Facial Features, Yao-Jiunn Chen, Yen-Chun Lin, 2007
        /// 
        /// Will sett all hair-paixels to white and all others to black.
        /// </summary>
        public void FindHairPixelsChenLin()
        {
            unsafe
            {
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bitmap.PixelFormat) / 8;
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
                        int I = (int)Math.Round((blue + green + red) / 3.0);
                        int H = GetHueFromRGB(red, green, blue);

                        if (I < 80 && (blue - green < 15 || blue - red < 15)
                            || H > 20 && H <= 40)
                        {
                            currentLine[x] = 1;
                            currentLine[x + 1] = 1;
                            currentLine[x + 2] = 1;
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

        public int GetHueFromRGB(double r, double g, double b)
        {
            r = r / 255.0;
            g = g / 255.0;
            b = b / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double hue;

            if (r == max)
                hue = (g - b) / (max - min);
            else if (g == max)
                hue = 2.0 + (b - r) / (max - min);
            else if (b == max)
                hue = 4.0 + (r - g) / (max - min);
            else
                throw new Exception("Uh oh.");

            hue = hue * 60;
            hue = hue < 0 ? hue + 360.0 : hue;

            return (int)(hue + 0.5);

            /* 
            http://stackoverflow.com/questions/23090019/fastest-formula-to-get-hue-from-rgb
            http://www.niwa.nu/2013/05/math-behind-colorspace-conversions-rgb-hsl/

            R = r / 255 = 0.09
            G = g / 255 = 0.38
            B = b / 255 = 0.46
            If Red is max, then Hue = (G - B) / (max - min)
            If Green is max, then Hue = 2.0 + (B - R) / (max - min)
            If Blue is max, then Hue = 4.0 + (R - G) / (max - min)
            */
        }

        /// <summary>
        /// Normalization by formulae (1) and (2) in Simple Face-detection Algorithm Based on
        /// Minimum Facial Features, Yao-Jiunn Chen, Yen-Chun Lin, 2007
        /// </summary>
        public void normalize()
        {
            unsafe
            {
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, bitmapData.Height, y =>
                {
                    byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int oldBlue = currentLine[x];
                        int oldGreen = currentLine[x + 1];
                        int oldRed = currentLine[x + 2];

                        double sum = oldBlue + oldGreen + oldRed;
                        byte newGreen = (byte)Math.Round(oldGreen / sum);
                        byte newRed = (byte)Math.Round(oldRed / sum);

                //Blue isn't changed.
                currentLine[x + 1] = newGreen;
                        currentLine[x + 2] = newRed;
                    }
                });
            }
        }
    }
}
