using System.IO;

namespace Exercise1
{
	internal static class Architecture
	{
		/// <summary>
		///   EXERCISE 1.5:
		///   <para />
		///   This function creates a folder architecture as described in the subject.
		///   When testing, take care not to put an important folder in path.
		/// </summary>
		/// <param name="path">the path to the first folder you will create</param>
		public static void Architect(string path)
		{
			// if path is a file, remove it.
			// if path is a directory remove it and everything it contains
			// - create a directory at path 
			// - add a file AUTHORS in the created directory
			// - fill AUTHORS with "* firstname.lastname\n" ('\n' is a newline character)
			// - add file README in the created directory
			// - fill README with "Everything in programming is magic... except for the programmer\n"
			// - add a new directory inside the first directory named TP5
			// - add a file useless.txt in TP5 directory and leave it empty

			if (File.Exists(path))
				File.Delete(path);
			else if (Directory.Exists(path))
				Directory.Delete(path, true);
			
			Directory.CreateDirectory(path);
			File.AppendAllText(path + "/AUTHORS", "* malo.lecomte\n");
			File.AppendAllText(path + "/README", "Everything in programming is magic... except for the programmer\n");
			Directory.CreateDirectory(path + "/TP5");
			File.Create(path + "/TP5" + "/TP5.txt");

		}
	}
}