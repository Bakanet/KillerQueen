using System;
using System.Collections.Generic;
using System.Threading;

namespace TP1
{
    static class Program
    {
        public static void Main(string[] args)
        {
            Morse();
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

        static string Lute(string s)
        {
            if (s.Length == 1)
                return s;
            else
                return (Lute(s.Substring(1))) + s[0];
        }

        public static void Reverse()
        {
            string s = Console.ReadLine();
            Console.WriteLine(Lute(s));
        }

        public static void LoveAcdc()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
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

        public static void BestYears()
        {
            int n = 1989;
            while (n < 2022)
            {
                if (n == 2020)
                    Console.WriteLine("Best Year");
                else if (n % 2 == 0)
                    Console.WriteLine("Good Year");
                else
                    Console.WriteLine("Bad Year");
                n++;
            }
            Console.WriteLine("Bad Year");
        }

        public static void Morse(string s, int i = 0)
        {
            while (i < s.Length)
            {
                char c = s[i];

                if (c == '.')
                    Console.Beep(900, 150);
                else if (c == '_')
                    Console.Beep(900, 450);
                else
                    Thread.Sleep(450);
                i++;
            }
        }

        public static void LightHouse(int n)
        {
            string b1f = " ===== \n_||_||_\n-------";
            string roof = "  /^\\  \n  |#|  ";
            string floor = " |===| \n  |0| \n  | |  ";
            
            int i = 0;
            Console.WriteLine(roof);
            while (i < n)
            {
                Console.WriteLine(floor);
                i++;
            }
            Console.WriteLine(b1f);
        }

        static void Music()
        {
            Console.WriteLine("nothing");
        }
    }
}