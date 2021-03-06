﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace CheckRendu
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(CheckRendu("../../../../malo.lecomte"));
        }

        public static bool CheckRendu(string path)
        {
            if (!File.Exists(path + "/AUTHORS"))
            {
                Console.WriteLine("fail AUTHORS : missing");
                return false;
            }

            if (File.ReadAllText(path + "/AUTHORS") != "* malo.lecomte\n")
            {
                Console.WriteLine("fail AUTHORS : newline");
                return false;
            }

            if (!File.Exists(path + "/README"))
            {
                Console.WriteLine("fail README : missing");
                return false;
            }

            if (File.ReadAllText(path + "/README") == "")
            {
                Console.WriteLine("fail README : empty");
                return false;
            }

            string[] directories = Directory.GetDirectories(path);

            foreach (string dir in directories)
            {
                string[] subdir = Directory.GetDirectories(dir);
                foreach (string gpodidé in subdir)
                {
                    if (gpodidé == Path.Combine(dir, ".idea"))
                    {
                        Console.WriteLine("fail dir : .idea");
                        return false;
                    }

                    if (!File.Exists(dir + "/WestWorldTycoon.sln"))
                    {
                        Console.WriteLine("fail sln : missing");
                        return false;
                    }    
                    
                    string[] deep = Directory.GetDirectories(gpodidé);
                    foreach (string deeper in deep)
                    {
                        if (deeper == Path.Combine(gpodidé, "bin") || deeper == Path.Combine(gpodidé, "obj"))
                        {
                            Console.WriteLine("fail dir : obj and bin");
                            return false;
                        }
                    }
                    
                }
            }
            return true;
        }
    }
}