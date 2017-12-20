using System;
using System.IO;

namespace Exercise1
{
	internal static class PrintFile
	{
		public static void PrintAllFile(string path)
		{
			if (!File.Exists(path))
				throw new ArgumentException("could not open file: " + path);
			Console.WriteLine(File.ReadAllText(path));
		}

		public static void PrintHalfFile(string path)
		{
			if (!File.Exists(path))
				throw new ArgumentException("could not open file: " + path);
			string[] file = File.ReadAllLines(path);

			for (int i = 0; i < file.Length; i += 2)
			{
				 Console.WriteLine(file[i]);
			}
		}
	}
}