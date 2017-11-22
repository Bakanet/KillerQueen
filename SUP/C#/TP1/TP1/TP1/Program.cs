using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;

namespace TP1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MCQ("Combien font 3+3", "6", "9", "12", "14", 1);
        }

        public static void HelloWorlds(int n)
        {
            int i = 0;
            while (i < n)
            {
                i++;
                Console.WriteLine("Hello (West)World!");
            }
        }

        public static void Echo()
        {
            string std = Console.ReadLine();
            Console.WriteLine(std);
        }

        public static void Reverse()
        {
            Console.WriteLine("des barres");
        }

        public static void LoveAcdc()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("  * * *   * * *  \n* *   * * *   * *\n*       *       *\n* *  <3 ACDC  * *\n");
            Console.Write("  * *       * *  \n    * *   * *    \n      * * *      \n        *        \n");
            Console.ResetColor();
            
        }

        public static void MCQ(string question, string aws1, string aws2, string aws3, string aws4, int aws)
        {
            Console.WriteLine(question);
            Console.WriteLine("1) " + aws1);
            Console.WriteLine("2) " + aws2);
            Console.WriteLine("3) " + aws3);
            Console.WriteLine("4) " + aws4);
            int entry = int.Parse(Console.ReadLine());

            if (entry == aws)
                Console.WriteLine("Good job bro!");
            else if (0 < entry && entry < 5)
                Console.WriteLine("You lose... The answer was " + aws);
            else
                Console.WriteLine("So counting is too hard, n00b...");
        }
    }
}