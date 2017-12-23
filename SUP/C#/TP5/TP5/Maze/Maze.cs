using System;
using System.IO;
using System.Linq;
using System.Reflection.Emit;

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
			return Path.ChangeExtension(fileIn, ".maze");
		}

		private static char[][] ParseFile(string file)
		{
			string[] parse = File.ReadAllLines(file);
			char[][] total = new char[parse.Length][];
			int i = 0;
			foreach (var line in parse)
			{
				int j = 0;
				char[] line1 = new char[line.Length];
				foreach (var charact in line)
				{
					line1[j] = charact;
					++j;
				}
				total[i] = line1;
				++i;
			}
			return total;
		}
	}

	/// <summary>
	///   Class that allows to store 2D coordinates.
	/// </summary>
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