using System;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace Maze
{
	internal static class Maze
	{
		public static void Main(string[] args)
		{
			// get .maze filename
			// get .solved filename
			// parse .maze file
			// print the maze (BONUS)
			// solve the maze
			// print the maze (BONUS)
			// save solution in .solved file
			grid_to_str(ParseFile("../../../tests/map2.maze"));
			string file = AskMazeFile();
			char[][] grid = ParseFile(file);
			int[][] processed = new int[grid.Length][];
			SolveMazeBackTracking(grid, processed, FindStart(grid));
			SaveSolution(grid, GetOutPutFile(file));
			grid_to_str(ParseFile("../../../tests/map2.solved"));
		}
		
		private static void grid_to_str(char[][] grid)
		{
			for (int j = 0; j < grid.Length; j++)
			{
				for (int i = 0; i < grid[0].Length; i++)
				{
					Console.Write(grid[j][i] + " ");
				}
				Console.WriteLine();
			}
		}

		private static string AskMazeFile()
		{
			Console.WriteLine("Which file should be loaded ?");
			string file = Console.ReadLine();
			while (!File.Exists(file) || Path.GetExtension(file) != ".maze")
			{
				Console.WriteLine("Which file should be loaded ?");
				file = Console.ReadLine();
			}

			return file;
		}

		private static string GetOutPutFile(string fileIn)
		{
			return Path.ChangeExtension(fileIn, ".solved");
		}

		private static char[][] ParseFile(string file)
		{
			string[] parse = File.ReadAllLines(file);	
			char[][] total = new char[parse.Length][];
			int i = 0;
			foreach (string line in parse)
			{
				int j = 0;
				char[] line1 = new char[line.Length];
				foreach (char charact in line)
				{
					line1[j] = charact;
					++j;
				}
				total[i] = line1;
				++i;
			}
			return total;
		}

		private static Point FindStart(char[][] grid)
		{
			int i = 0;
			foreach (char[] line in grid)
			{
				int j = 0;
				foreach (char letter in line)
				{
					if (letter == 'S')
						return new Point(i, j);
					++j;
				}
				++i;
			}
			return null;
		}

		private static bool SolveMazeBackTracking(char[][] grid, int[][] processed, Point p)
		{
			if (p.X < 0 || p.X > grid[0].Length || p.Y < 0 || p.Y > grid.Length)
				return false;
			
			if (processed[p.Y][p.X] != 0)
				return false;
			
			processed[p.Y][p.X] = 1;

			switch (grid[p.Y][p.X])
			{
				case 'F':
					return true;
				case 'B':
					return false;
			}

			if (SolveMazeBackTracking(grid, processed, new Point(p.X, p.Y - 1)))
			{
				grid[p.Y][p.X] = 'P';
				return true;
			}
			
			if (SolveMazeBackTracking(grid, processed, new Point(p.X - 1, p.Y)))
			{
				grid[p.Y][p.X] = 'P';
				return true;
			}
			
			if (SolveMazeBackTracking(grid, processed, new Point(p.X + 1, p.Y)))
			{
				grid[p.Y][p.X] = 'P';
				return true;
			}
			
			if (SolveMazeBackTracking(grid, processed, new Point(p.X, p.Y + 1)))
			{
				grid[p.Y][p.X] = 'P';
				return true;
			}

			return false;
		}

		private static void SaveSolution(char[][] grid, string fileOut)
		{
			string[] strArr = new string[grid.Length];
			int i = 0;
			foreach (char[] line in grid)
			{
				string str = "";
				foreach (char charact in line)
				{
					str += charact;
				}
				strArr[i] = str;
				++i;
			}

			File.WriteAllLines(fileOut, strArr);
		}
	}
	
	internal class Point
	{
		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int Y { get; set; }
		public int X { get; set; }
	}
}