using System;
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

		/// <summary>
		///   EXERCISE 1.4:
		///   <para />
		///   Read the source file and put half of its content into destination file
		/// </summary>
		/// <param name="source">the path to the source file</param>
		/// <param name="destination">the path to the destination file</param>
		public static void CopyHalfFile(string source, string destination)
		{
			if (!File.Exists(source))
				throw new ArgumentException("could not open file: " + source);
			// TODO
		}
	}
}