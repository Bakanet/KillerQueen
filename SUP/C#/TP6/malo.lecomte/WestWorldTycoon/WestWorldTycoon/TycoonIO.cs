using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace WestWorldTycoon
{
    public static class TycoonIO
    {
        private const string PATH_OUT = "Content/bot.out";

        public static Tile[,] ParseMap(string name)
        {
            string path = "Content/maps/" + name;
            Tile[,] map = null;
            using (StreamReader sr = new StreamReader(path))
            {
                string[] dim = sr.ReadLine().Split();
                int lines = Int16.Parse(dim[0]);
                int cols = Int16.Parse(dim[1]);
                map = new Tile[lines,cols];
                for (int i = 0; i < lines; i++)
                {
                    string line = sr.ReadLine();
                    for (int j = 0; j < cols; j++)
                    {
                        switch (line[j])
                        {
                            case '#':
                                map[i,j] = new Tile(Tile.Biome.PLAIN);
                                break;
                            case '^':
                                map[i,j] = new Tile(Tile.Biome.MOUNTAIN);
                                break;
                            case '_':
                                map[i,j] = new Tile(Tile.Biome.SEA);
                                break;
                        }
                    }
                }
            }
            return map;
        }


        public static void GameInit(string name, int nbRound, long initialMoney)
        {
            Tile[,] map = ParseMap(name);
            using (StreamWriter sw = new StreamWriter(PATH_OUT))
            {
                sw.WriteLine("{0} {1} {2} {3}", nbRound, initialMoney, map.GetLength(0), map.GetLength(1));
                for (int i = 0; i < map.GetLength(0); i++, sw.Write("\n"))
                    for (int j = 0; j < map.GetLength(1); j++)
                        sw.Write((int) map[i,j].GetBiome);
            }

        }


        public static void GameBuild(int i, int j, Building.BuildingType type)
        {
            using (StreamWriter sw = new StreamWriter(PATH_OUT, true))
                sw.Write("B {0} {1} {2}|", (int) type, i, j);
        }


        public static void GameDestroy(int i, int j)
        {
            using (StreamWriter sw = new StreamWriter(PATH_OUT, true))
            {
                sw.Write("D {0} {1}|", i, j);
            }
        }


        public static void GameUpgrade(int i, int j)
        {
            using (StreamWriter sw = new StreamWriter(PATH_OUT, true))
            {
                sw.Write("U {0} {1}|", i, j);
            }
        }


        public static void GameUpdate()
        {
            using (StreamWriter sw = new StreamWriter(PATH_OUT, true))
            {
                sw.Write("\n");
            }
        }


        public static void Viewer()
        {
            File.Copy(PATH_OUT, "../../../bot.out", true);
            ProcessStartInfo viewer = new ProcessStartInfo();
            viewer.FileName = "Content/viewer/viewer.py";
            viewer.Arguments = PATH_OUT;
            viewer.UseShellExecute = false;
            viewer.RedirectStandardError = true;
            viewer.RedirectStandardOutput = true;
            using (Process process = Process.Start(viewer))
            {
                using (StreamReader sr = process.StandardOutput)
                    Console.Write(sr.ReadToEnd());
                using (StreamReader sr = process.StandardError)
                    Console.Write(sr.ReadToEnd());
            }
        }
    }
}
