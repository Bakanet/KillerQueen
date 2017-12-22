using System;
using System.IO;
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