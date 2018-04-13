using EvalExpr;
using System;
using System.Collections.Generic;

namespace TPCS12
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Parser.Parse("24 + 3 -4 * 8").Eval());
            Console.ReadLine();
        }
    }
}