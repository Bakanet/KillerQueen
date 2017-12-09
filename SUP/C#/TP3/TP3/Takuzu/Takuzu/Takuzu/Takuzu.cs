using System;
using System.Data.Common;

namespace Takuzu 
{
    public static class Takuzu
    {
        public static void PrintGrid(int[,] grid)
        {
            int row = grid.GetLength(1);
            int column = grid.GetLength(0);
            
            Console.Write("   ");                // mettre au bon endroit la premiere ligne
            for (int x = 0; x < row; x++)        // print de la premiere ligne
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
            
            for (int i = 0; i < column; i++)       // decomposition par lignes
            {
                Console.Write(i + " ");
                
                for (int j = 0; j < row; j++)  // parcours des colonnes
                {
                    if (grid[i,j] == 1 || grid[i,j] == 0)
                        Console.Write("|" + grid[i,j]);
                    else
                        Console.Write("| ");

                }
                Console.WriteLine("|");
            }
        }

        public static bool IsRowValid(int[,] grid, int row)
        {
            int nb0 = 0, nb1 = 0;

            for (int i = 0; i < grid.GetLength(1); i++)
            {
                if (grid[row, i] == 0)
                    nb0 += 1;
                else if (grid[row, i] == 1)
                    nb1 += 1;
            }

            return 2 * (nb0 > nb1 ? nb0 : nb1) >= grid.GetLength(1); // max(nb0,nb1) > length - max(nb0,nb1)
        }
        
        public static bool IsColumnValid(int[,] grid, int col)
        {
            int nb0 = 0, nb1 = 1;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                if (grid[i, col] == 0)
                    nb0 += 1;
                else if (grid[i, col] == 1)
                    nb1 += 1;
            }
            return 2 * (nb0 > nb1 ? nb0 : nb1) >= grid.GetLength(0);
        }

        public static bool IsGridValid(int[,] grid)
        {
            int row_length = grid.GetLength(1), i = 0;
            while (i < row_length && IsRowValid(grid, i))
            {
                ++i;
            }

            bool row = i < row_length;
            return false;
        }

        public static bool PutCell(int[,] grid, int x, int y, int val)
        {
            //FIXME
            return false;
        }
        
        public static void Game(int[,] start)
        {
            //FIXME
        }

        public static int[,] AI(int[,] grid)
        {
            //FIXME
            return null;
        }
    }
}