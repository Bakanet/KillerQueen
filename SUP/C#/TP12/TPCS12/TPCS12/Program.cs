using EvalExpr;
using System;
using System.Collections.Generic;

namespace TPCS12
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Token> tokens = Lexer.Lex(" 3 + 4 -5* 6");
            foreach (Token token in tokens)
                Console.Write(token);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}