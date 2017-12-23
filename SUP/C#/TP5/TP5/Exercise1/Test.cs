using System;
using System.IO;

namespace Exercise1
{
	internal static class Test
	{
		private static readonly string HomePath = 	   Environment.OSVersion.Platform == PlatformID.Unix 
													|| Environment.OSVersion.Platform == PlatformID.MacOSX
													?  Environment.GetEnvironmentVariable("HOME")
													:  Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

		public static void Main(string[] args)
		{
			// TODO: put all your tests here like these examples
			PrintFile.PrintAllFile ("../../../tests/exo1_test1.txt");
			PrintFile.PrintHalfFile("../../../tests/exo1_test2.txt");
			CopyFile.CopyAllFile   ("../../../tests/exo1_test1.txt", "../../../all_file.txt");
			CopyFile.CopyHalfFile  ("../../../tests/exo1_test2.txt", "../../../half_file.txt");
			Architecture.Architect (Path.Combine(HomePath, "archi"));
		}
	}
}