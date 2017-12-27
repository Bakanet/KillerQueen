using System;
using System.Dynamic;
using System.IO;
using System.Resources;

namespace Exercise1
{
	internal static class CopyFile
	{
		public static void CopyAllFile(string source, string destination)
		{
			if (!File.Exists(source))
				throw new ArgumentException("could not open file: " + source);
			File.Copy(source, destination, true);
		}

		public static void CopyHalfFile(string source, string destination)
		{
			if (!File.Exists(source))
				throw new ArgumentException("could not open file: " + source);
			string[] file = File.ReadAllLines(source);
			
			for (int i = 0; i < file.Length / 2; ++i)
			{
				File.AppendAllText(file[i], destination);
			}
			
		}
	}
}