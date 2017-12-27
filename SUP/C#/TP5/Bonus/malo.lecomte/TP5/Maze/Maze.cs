using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Maze
{
	internal static class Maze
	{
		public static void Main(string[] args)
		{
			ResolveMaze();
			ResolveMaze2();
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
							Console.BackgroundColor = ConsoleColor.Red;
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
		
		// c'est la que commence mon A* enjoy :D

		public static Point FindFinish(char[][] grid)		// on c/c la fonction FindStart
		{
			int i = 0;
			foreach (char[] line in grid)
			{
				int j = 0;
				foreach (char letter in line)
				{
					if (letter == 'F')
					{
						return new Point(j, i);
					}
					++j;
				}
				++i;
			}
			
			throw new Exception("finish point not found");
		}

		public static bool Exists(List<Node> list, int x, int y) // le i permettra de recup l'index sans passer par une autre fonction
		{
			foreach (Node node in list)
			{
				if (node.X == x && node.Y == y)
					return true;
			}
			return false;
		}

		public static int Index(List<Node> list, int x, int y)
		{
			int i = 0;
			for ( ; i < list.Count && list[i].X != x || list[i].Y != y; ++i){}
			return i;
		}
		
		public static void GetNeighboursValue(char[][] grid, Node n, List<Node> doneNodes, List<Node> toExplore, Point finish)
		{
			Node downNode = new Node(n.X, n.Y + 1, n.Value + 10, Direction.Down);
			Node upNode = new Node(n.X, n.Y - 1, n.Value + 10, Direction.Up);
			Node leftNode = new Node(n.X - 1, n.Y, n.Value + 10, Direction.Left);
			Node rightNode = new Node(n.X + 1, n.Y, n.Value + 10, Direction.Right);
			List<Node> neighbours = new List<Node>{downNode, upNode, leftNode, rightNode};

			foreach (Node node in neighbours)
			{
				if (node.X < 0 || node.X > grid[0].Length - 1 || node.Y < 0 || node.Y > grid.Length - 1 ||
				    Exists(doneNodes, node.X, node.Y) || grid[node.Y][node.X] == 'B')	
					continue;
				long newValue = node.ComputeValue(finish);
				if (Exists(toExplore, node.X, node.Y) && toExplore[Index(toExplore, node.X, node.Y)].Value < node.Value + newValue)
				{
					toExplore[Index(toExplore, node.X, node.Y)].Value = node.Value + newValue;
					toExplore[Index(toExplore, node.X, node.Y)].Direction = node.Direction;
					continue;
				}
				node.Value += newValue;
				toExplore.Add(node);
			}
		}

		public static Node GottaGoFast(List<Node> toExplore, List<Node> doneNodes) // SAAAAAANIC
		{
			Node min = toExplore[0];
			foreach (Node node in toExplore)
			{
				if (node.Value < min.Value)
					min = node;
			}
			toExplore.RemoveAt(Index(toExplore, min.X, min.Y));
			doneNodes.Add(min);
			return min;
		}

		public static void PathFinding(char[][] grid)
		{
			Point startPoint = FindStart(grid);
			Point finishPoint = FindFinish(grid);
			Node start = new Node(startPoint.X, startPoint.Y, 0, Direction.None);  // BUG: value, direction
			Node finish = new Node(finishPoint.X, finishPoint.Y, 0, Direction.None);

			List<Node> toExplore = new List<Node> {start};
			List<Node> doneNodes = new List<Node>();

			while (toExplore.Count > 0 && !Exists(toExplore, finish.X, finish.Y))
			{
				Node min = GottaGoFast(toExplore, doneNodes);
				GetNeighboursValue(grid, min, doneNodes, toExplore, finishPoint);
			}
			
			if (toExplore.Count <= 0)
				throw new Exception("maze can't be solved");
			finish = toExplore[Index(toExplore, finish.X, finish.Y)];
			while (finish.X != doneNodes[0].X || finish.Y != doneNodes[0].Y)
			{
				switch (finish.Direction)
				{
					case Direction.Down:
						grid[finish.Y][finish.X] = 'P';
						finish = doneNodes[Index(doneNodes, finish.X, finish.Y - 1)];
						break;
					case Direction.Up:
						grid[finish.Y][finish.X] = 'P';
						finish = doneNodes[Index(doneNodes, finish.X, finish.Y + 1)];
						break;
					case Direction.Left:
						grid[finish.Y][finish.X] = 'P';
						finish = doneNodes[Index(doneNodes, finish.X + 1, finish.Y)];
						break;
					case Direction.Right:
						grid[finish.Y][finish.X] = 'P';
						finish = doneNodes[Index(doneNodes, finish.X - 1, finish.Y)];
						break;
				}
			}
		}

		private static void ResolveMaze2()
		{
			string file = AskMazeFile();
			char[][] grid = ParseFile(file);
			PrintMaze(ParseFile(file));
			PathFinding(grid);
			SaveSolution(grid, GetOutPutFile(file));
			Console.WriteLine("Maze solved :");
			PrintMaze(ParseFile(GetOutPutFile(file)));
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
	{None, Right, Left, Up, Down} // le None sert pour le start (qui n'a pas de predecesseur), et le finish (pas encore defini)

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

		public long ComputeValue(Point p)
		{
			return (X - p.X) * (X - p.X) + (Y - p.Y) * (Y - p.Y);
		}
	}
}