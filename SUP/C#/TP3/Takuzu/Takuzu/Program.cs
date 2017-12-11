using System;
using System.Collections.Generic;

namespace Takuzu
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[,] grid =
            {
                {-1, -1,  0, -1, -1, -1, -1, -1},
                { 1, -1,  1, -1, -1, -1, -1, -1},
                {-1, -1, -1, -1,  0,  0, -1, -1},
                {-1, -1, -1,  1, -1, -1, -1, -1},
                {-1, -1,  0, -1, -1, -1, -1,  0},
                {-1, -1, -1, -1,  0, -1, -1,  0},
                { 0, -1, -1,  0,  0, -1, -1, -1},
                { 0, -1, -1, -1, -1,  0,  0, -1}
            };
         
            int[,] c = {{-1, 1, 0, 0}, {0, 0, -1, 1}, {-1, 0, 1, 0}};
            Console.WriteLine(Takuzu.IsGridValid(grid));
        }

        static bool Same(int[] b1, int[] b2)
        {
            int i = 0, length = b1.Length;
            while (i < length && b1[i] == b2[i])
            {
                ++i;
            }
            return i == length;
        }
    }
}
