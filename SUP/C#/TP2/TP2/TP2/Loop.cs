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
            
        }

        public static long Fibonacci(long n)
        {
            if (n <= 0)
            {
                Console.WriteLine("Fibonacci: invalid argument");
                return 0;
            }
             
            else
            {
                long a = 0;
                long b = 1;

                while (n > 1)
                {
                    a += b;
                    b += a;
                    n -= 2;
                }

                return n % 2 == 0 ? a : b;
            }
        }

        public static long Factorial(long n)
        {
            if (n < 0)
            {
                Console.WriteLine("Factorial: invalid argument");
                return 0;
            }

            else
            {
                long fact = 1;
                for (int i = 1; i <= n; i++)
                {
                    fact *= i;
                }
                return fact;
            }
        }

        public static void Print_Strong(int n)
        {
            // TODO
        }

        public static float Abs(float n)
        {
            return n > 0 ? n : -n;
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