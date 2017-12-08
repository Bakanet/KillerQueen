using System;
using System.Collections.Concurrent;
using System.Data.Common;
using System.Linq.Expressions;

namespace Takuzu 
{
    public static class Takuzu
    {
        public static void PrintGrid(int[,] grid)
        {
            int line = grid.GetLength(0);
            int column = grid.GetLength(1);
            
            Console.Write("   ");                // mettre au bon endroit la premiere ligne
            for (int x = 0; x < column; x++)    // print de la premiere ligne
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
            
            for (int i = 0; i < line; i++)        // decomposition par lignes
            {
                Console.Write(i + " ");
                
                for (int j = 0; j < column; j++)  // parcours des colonnes
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
            //FIXME
            return false;
        }
        
        public static bool IsColumnValid(int[,] grid, int col)
        {
            //FIXME
            return false;
        }

        public static bool IsGridValid(int[,] grid)
        {
            //FIXME
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