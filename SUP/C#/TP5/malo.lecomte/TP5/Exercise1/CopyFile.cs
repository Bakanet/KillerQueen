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
			/* if (!File.Exists(source))
				throw new ArgumentException("could not open file: " + source);
			string[] file = File.ReadAllLines(source);
			string[] half = new string[file.Length];
			Array.Copy(file, half, file.Length / 2);
			File.WriteAllLines(destination, half); */
		}
	}
}