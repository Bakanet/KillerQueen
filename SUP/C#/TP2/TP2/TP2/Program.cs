using System;
using System.CodeDom;
using System.Collections.Generic;
using Debugger;

namespace TP2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] test = {4, 2, 3, 6, 8, 2};
            Misc.printArr(Debugging.ex4(test));
        }
    }
}