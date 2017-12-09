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

            int[,] test = {{0, 0, 0, 1, 1, 1}, {-1, -1, -1, -1, -1, -1}};
            Takuzu.PrintGrid(test);
            Console.WriteLine(Takuzu.IsRowValid(test, 0));
        }
    }
}
