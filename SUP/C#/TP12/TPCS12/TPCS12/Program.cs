using EvalExpr;
using System;
using System.Collections.Generic;
using List;

namespace TPCS12
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            INode test = Parser.Parse("4 - 1 + 2 * 3");
            test.PrintRevertPolish();
            Console.ReadLine();
        }
    }
}