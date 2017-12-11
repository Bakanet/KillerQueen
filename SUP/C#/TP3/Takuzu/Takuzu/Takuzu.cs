﻿using System;
using System.Data.Common;
using System.Reflection;

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
            bool valid = true;

            for (int x = 0; x < grid.GetLength(1) - 2 && valid; x++)
            {
                int x_pos = grid[row, x];
                if (x_pos == grid[row, x + 1] && x_pos == grid[row, x + 2] && x_pos != -1)
                    valid = false;
            }

            if (valid)
            {
                for (int i = 0; i < grid.GetLength(1); i++)
                {
                    if (grid[row, i] == 0)
                        nb0 += 1;
                    else if (grid[row, i] == 1)
                        nb1 += 1;
                }
                return 2 * (nb0 > nb1 ? nb0 : nb1) <= grid.GetLength(1); // max(nb0,nb1) > length - max(nb0,nb1)
            }

            else
                return false;
        }
            
        
        public static bool IsColumnValid(int[,] grid, int col)
        {
            int nb0 = 0, nb1 = 1;
            bool valid = true;

            for (int x = 0; x < grid.GetLength(0) - 2 && valid; x++)
            {
                int x_pos = grid[x, col];
                if (x_pos == grid[x + 1, col] && x_pos == grid[x + 2, col] && x_pos != -1)
                    valid = false;
            }

            if (valid)
            {
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    if (grid[i, col] == 0)
                        nb0 += 1;
                    else if (grid[i, col] == 1)
                        nb1 += 1;
                }
                return 2 * (nb0 > nb1 ? nb0 : nb1) <= grid.GetLength(0);
            }

            else
                return false;
        }

        public static bool IsGridValid(int[,] grid)
        {
            int row_length = grid.GetLength(1), col_length = grid.GetLength(0);
            bool row = true, column = true;
            for (int x = 0; x < col_length; x++) // pour les lignes
            {
                for (int j = x + 1; j < col_length && row; j++)
                {
                    int i = 0;
                    while (i < row_length && (grid[x, i] == grid[j, i]))
                    {
                        ++i;
                    }
                    row &= (i != row_length) && IsRowValid(grid, j);
                }
            }

            for (int x = 0; x < row_length; x++) // pour les colonnes
            {
                for (int j = x + 1; j < row_length && column; j++)
                {
                    int i = 0;
                    while (i < col_length && (grid[i, x] == grid[i, j]))
                    {
                        ++i;
                    }
                    column &= (i != col_length) && IsColumnValid(grid, j);
                }
            }
            return row && column;
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