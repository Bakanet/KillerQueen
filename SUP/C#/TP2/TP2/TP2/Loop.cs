using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Security.Cryptography.X509Certificates;

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
            for (int i = 1; i <= n; i++)
            {
                int sum = 0;
                int x = i;
                while (x != 0)
                {
                    sum += (int) Factorial(x % 10);
                    x /= 10;
                }
                
            if (sum == i)
                Console.Write(sum + " ");                
            }
        }

        public static float Abs(float n)
        {
            return n > 0 ? n : -n;
        }

        public static float Sqrt(float n)
        {
            float x0 = n;
            float x1 = 0;

            while (Abs(x0 - x1) > 0.00001)
            {
                x1 = 0.5f * (x0 + n / x0);
                x0 = 0.5f * (x1 + n / x1);
            }
            return x0;
        }

        public static long Power(long a, long b)
        {
            long result = a;

            if (b == 0)
                return 1;
            
            if (b < 0)
                return 0;
            
            else
            {
                for (long i = b > 0 ? b : -b; i > 1; i--)
                {
                    result *= a;
                }
                return result;
            }
        }

        public static void Print_Tree(int n)
        {
            string trunk = n < 3 ? "   *   " : "   *   \n   *   ";

            string xmas = "   *   ";

            while (n > 0)
            {
                xmas += "**";
                Console.WriteLine(xmas);
                --n;
            }
            Console.WriteLine(trunk);
        }
    }
}