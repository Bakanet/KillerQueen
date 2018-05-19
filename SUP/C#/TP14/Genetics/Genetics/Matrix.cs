using System;
using System.Collections.Generic;
using System.Runtime.Remoting;

namespace Genetics
{
    public class Matrix
    {
        #region Attributes

        private int Height;
        private int Width;
        public float[,] Tab;
        public float[] Bias;
        private static readonly Random Rdn = new Random();

        #endregion

        #region Constructors

        public Matrix(int height, int width, bool init = false)
        {
            Tab = new float[height, width];
            Height = height;
            Width = width;
           if (init)
                for (int i = 0; i < height; ++i)
                {
                    for (int j = 0; j < width; ++j)
                    {
                        Tab[i, j] = (float) Rdn.NextDouble();
                    }
                }

            Bias = new float[width];
            for (int i = 0; i < width; ++i)
                Bias[i] = (float) Rdn.NextDouble() * -0.5f - 0.5f;
        }

        public Matrix(List<float> tab)
        {
            Height = 1;
            Width = tab.Count;
            Tab = new float[Height, Width];
            for (int j = 0; j < Width; j++)
                Tab[0, j] = tab[j];
        }

        #endregion

        public void MakeCopyFrom(Matrix copy)
        {
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                    Tab[i, j] = copy.Tab[i, j];
            }
        }

        public void ApplyMutation()
        {
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    Tab[i, j] += (float) Rdn.NextDouble() / 5 - 0.1f;

                    if (Tab[i, j] > 1)
                        Tab[i, j] = 1;
                    else if (Tab[i, j] < 0)
                        Tab[i, j] = 0;
                }
            }

            for (int k = 0; k < Width; ++k)
            {
                Bias[k] += Rdn.Next(-10, 10) / 10;
                if (Bias[k] < -1)
                    Bias[k] = -1;
                else if (Bias[k] > -0.5)
                    Bias[k] = -0.5f;
            }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Height != b.Height)
                throw new Exception("Matrix have different sizes");
            Matrix c = new Matrix(a.Height, a.Width);
            
            for (int i = 0; i < c.Height; ++i)
            {
                for (int j = 0; j < c.Width; ++j)
                {
                    c.Tab[i, j] = a.Tab[i, j] + b.Tab[i, j];
                }
            }

            return c;
        }

        public  static float Sigmoid(float x)
        {
            return 1 / (1 + (float) Math.Exp(-x));
        }

        /// <summary>
        /// This is not only a multiplication ! We also normalize !
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Normalized multiplication</returns>
        /// <exception cref="ArgumentException"></exception>
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Width != b.Height)
                throw new Exception("Can't multiply these matrices (problem of size)");
            Matrix c = new Matrix(a.Height, b.Width);
            for (int i = 0; i < a.Height; ++i)
            {
                for (int j = 0; j < b.Width; ++j)
                {
                    float S = 0;
                    for (int k = 0; k < a.Width; ++k)
                    {
                        S += a.Tab[i, k] * b.Tab[k, j];
                    }
                    c.Tab[i, j] = Sigmoid(S / (b.Width + b.Bias[j]));
                }
            }

            return c;
        }


        public void Print()
        { 
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    Console.Write(Tab[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}