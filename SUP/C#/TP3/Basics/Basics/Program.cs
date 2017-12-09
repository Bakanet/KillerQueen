using System;
using System.Collections.Generic;

namespace Basics
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            char c = '1';
            Console.WriteLine(c);
            Reference.RotChar(ref c, -13);
            Console.WriteLine(c);
        }
    }
}