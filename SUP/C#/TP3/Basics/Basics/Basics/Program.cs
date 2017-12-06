using System;
using System.Collections.Generic;

namespace Basics
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int a = 4, b = 7;
            Reference.Swap(ref a, ref b);
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}