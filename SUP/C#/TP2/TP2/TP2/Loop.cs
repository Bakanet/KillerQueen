using System;
using System.Net;

namespace Debugger
{
    public static class Loop
    {
        public static void Print_Naturals(int n)
        {
            if (n <= 0)
                Console.WriteLine("Print_Naturals: invalid argument");
            else
            {
                for (int i = 1; i < n; i++)
                    {
                        Console.Write(i + " ");
                    }
                Console.WriteLine(n);
            }
        }

        public static void Print_Primes(int n)
        {
            // TODO
        }

        public static long Fibonacci(long n)
        {
            // TODO
            return 0;
        }

        public static long Factorial(long n)
        {
            // TODO
            return 0;
        }

        public static void Print_Strong(int n)
        {
            // TODO
        }

        public static float Abs(float n)
        {
            // TODO
            return 0;
        }

        public static float Sqrt(float n)
        {
            // TODO
            return 0;
        }

        public static long Power(long a, long b)
        {
            // TODO
            return 0;
        }

        public static void Print_Tree(int n)
        {
            // TODO
        }
    }
}