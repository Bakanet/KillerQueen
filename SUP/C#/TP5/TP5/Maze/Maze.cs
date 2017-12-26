using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Maze
{
	internal static class Maze
	{
		public static void Main(string[] args)
		{
			ResolveMaze();
		}	

		private static string AskMazeFile()
		{
			Console.WriteLine("Which file should be loaded ?");
			string file;
			while ((file = Console.ReadLine()) == ""){};
			while (!File.Exists(file) || Path.GetExtension(file) != ".maze")
			{
				Console.WriteLine("Which file should be loaded ?");
				while ((file = Console.ReadLine()) == ""){};
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
					{
						return new Point(j, i);
					}
					++j;
				}
				++i;
			}
			return null;
		}

		private static bool SolveMazeBackTracking(char[][] grid, int[][] processed, Point p)
		{
			if (p.X < 0 || p.X > grid[0].Length - 1 || p.Y < 0 || p.Y > grid.Length - 1 || processed[p.Y][p.X] != 0)
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

		private static void PrintMaze(char[][] grid)
		{
			foreach (char[] line in grid)
			{
				foreach (char charact in line)
				{
					switch (charact)
					{
						case 'B':
							Console.BackgroundColor = ConsoleColor.Blue;
							Console.Write("  ");
							break;
						case 'O':
							Console.BackgroundColor = ConsoleColor.Gray;
							Console.Write("  ");
							break;
						case 'P':
							Console.BackgroundColor = ConsoleColor.DarkRed;
							Console.Write("  ");
							break;
						case 'S':
							Console.BackgroundColor = ConsoleColor.Red;
							Console.Write("  ");
							break;
						case 'F':
							Console.BackgroundColor = ConsoleColor.Yellow;
							Console.Write("  ");
							break;
					}
				}
				Console.ResetColor();
				Console.WriteLine(""); // pour le "" : des fois y avait des bugs. maintenant y a moins de bugs. dunno.
			}
		}

		private static void ResolveMaze()
		{
			string file = AskMazeFile();
			char[][] grid = ParseFile(file);
			int[][] processed = new int[grid.Length][];
			
			int i = 0;
			foreach (char[] line in grid)
			{
				processed[i] = new int[line.Length];
				++i;
			}
			
			PrintMaze(ParseFile(file));
			SolveMazeBackTracking(grid, processed, FindStart(grid));
			SaveSolution(grid, GetOutPutFile(file));
			Console.WriteLine("Maze solved :");
			PrintMaze(ParseFile(GetOutPutFile(file)));
		}

		public static void GetNeighboursValue(char[][] grid, Node n, List<Node> doneNodes, List<Node> toExplore)
		{
			Node downNode = new Node(n.X, n.Y + 1, n.Value + 10, Direction.Down);
			Node upNode = new Node(n.X, n.Y - 1, n.Value + 10, Direction.Up);
			Node leftNode = new Node(n.X - 1, n.Y, n.Value + 10, Direction.Left);
			Node rightNode = new Node(n.X + 1, n.Y, n.Value + 10, Direction.Right);
			
			downNode:
			if (downNode.X < 0 || downNode.X > grid[0].Length - 1 || downNode.Y < 0 || downNode.Y > grid.Length - 1 || doneNodes.Contains(downNode))
				goto upNode;
			downNode.Value += (downNode.X - // need finish point
			toExplore.Add(downNode);
			
			upNode:
			
			leftNode:
			
			rightNode:
				
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

	internal enum Direction
	{Right, Left, Up, Down}

	internal class Node
	{
		public int X { get; set; }
		public int Y { get; set; }
		public long Value { get; set; }
		public Direction Direction { get; set; }

		public Node(int x, int y, long value, Direction direction) // le long, si vous etes chiants et que vous faites overflow la value d'une case
		{
			X = x;
			Y = y;
			Value = value;
			Direction = direction;
		}
	}
}