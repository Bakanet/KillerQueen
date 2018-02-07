using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TinyPhotoshop
{
    public static class Steganography
    {
        public static Image EncryptImage(Bitmap img, Bitmap enc)
        {
            int w = enc.Width, h = enc.Height;
            if (w > img.Width || h > img.Height)
                throw new ArgumentOutOfRangeException("the image to encrypt is too big");

            for (int i = 0; i < img.Width; ++i)
            {
                for (int j = 0; j < img.Height; ++j)
                {
                    int imgRed = 240 & img.GetPixel(i, j).R; // 240(10) = 1111 0000(2)
                    int imgGreen = 240 & img.GetPixel(i, j).G;
                    int imgBlue = 240 & img.GetPixel(i, j).B;

                    imgRed += i < w && j < h ? (240 & enc.GetPixel(i, j).R) >> 4 : 0; //decalage de 4 bits
                    imgGreen += i < w && j < h ? (240 & enc.GetPixel(i, j).G) >> 4 : 0;
                    imgBlue += i < w && j < h ? (240 & enc.GetPixel(i, j).B) >> 4 : 0;

                    img.SetPixel(i, j, Color.FromArgb(imgRed, imgGreen, imgBlue));
                }
            }

            return img;
        }

        public static Image DecryptImage(Bitmap img)
        {
            for (int i = 0; i < img.Width; ++i)
            {
                for (int j = 0; j < img.Height; ++j)
                {
                    int decRed = (15 & img.GetPixel(i, j).R) << 4; // 15(10) = 0000 1111(2)
                    int decGreen = (15 & img.GetPixel(i, j).G) << 4;
                    int decBlue = (15 & img.GetPixel(i, j).B) << 4;

                    img.SetPixel(i, j, Color.FromArgb(decRed, decGreen, decBlue));
                }
            }

            return img;
        }

        public static Image EncryptText(Bitmap img, string text)
        {
            if (text.Length > img.Height * img.Width)
                throw new ArgumentOutOfRangeException("text too big for the image");

            // buffer part

            int[] buffer = new int[text.Length * 2 + 2]; // longueur du texte * 2 parce qu'on divise par 2 les caractères + 2 pour les deux 0
            int i = 0;

            foreach (char character in text)
            {
                buffer[i] = character & 15;
                buffer[i + 1] = (character & 240) >> 4;
                i += 2;
            }

            buffer[i] = 0;
            buffer[i + 1] = 0;

            // encryptage

            i = 0;
            int length = buffer.Length;
            for (int k = 0; k < img.Width && i < length; ++k)
            {
                for (int l = 0; l < img.Height && i < length; ++l)
                {
                    int encRed = img.GetPixel(k, l).R & 240;
                    int encGreen = img.GetPixel(k, l).G & 240;
                    int encBlue = img.GetPixel(k, l).B & 240;

                    if (i == length - 2)
                    {
                        encRed += buffer[i];
                        encBlue += buffer[i + 1];
                        i += 2;
                    }

                    else if (i == length - 1)
                    {
                        encRed += buffer[i];
                        ++i;
                    }

                    else
                    {
                        encRed += buffer[i];
                        encGreen += buffer[i + 1];
                        encBlue += buffer[i + 2];
                        i += 3;
                    }

                    img.SetPixel(k, l, Color.FromArgb(encRed, encGreen, encBlue));
                }
            }

            return img;
        }

        public static string DecryptText(Bitmap img)
        {
            // buffer
            List<int> buffer = new List<int>();

            for (int i = 0; i < img.Width; ++i)
            {
                for (int j = 0; j < img.Height; ++j)
                {
                    int testRed = img.GetPixel(i, j).R;
                    int testGreen = img.GetPixel(i, j).G;
                    int testBlue = img.GetPixel(i, j).B;

                    buffer.Add(testRed & 15);
                    if (buffer.Count > 1 && buffer[buffer.Count - 1] == 0 && buffer[buffer.Count - 2] == 0)
                        goto c_moche;

                    buffer.Add(testGreen & 15);
                    if (buffer[buffer.Count - 1] == 0 && buffer[buffer.Count - 2] == 0)
                        goto c_moche;

                    buffer.Add(testBlue & 15);
                    if (buffer[buffer.Count - 1] == 0 && buffer[buffer.Count - 2] == 0)
                        goto c_moche;
                }
            }

            c_moche:
            // string
            string decrypted = "";

            for (int i = 0; i < buffer.Count - 2; i += 2)
            {
                decrypted += (char) ((buffer[i] << 4) + buffer[i + 1]);
                Console.WriteLine(decrypted);
            }

            return decrypted;
        }
    }
}