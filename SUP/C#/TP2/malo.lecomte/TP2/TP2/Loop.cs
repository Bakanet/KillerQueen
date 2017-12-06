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
            for (int i = 2; i < n; i++)
            {
                int c = 2;
                
                while (c * c < i || i % c != 0)
                    ++c;
                
                if (i == c)
                    Console.Write(i + " ");
            }
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
            if (n >= 0)
                return n;
            else
                return -n;
        }

        public static float Sqrt(float n)
        {
            float x0 = n;
            float x1 = 0;

            while (Abs(x0 - x1) > 0.0001)
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

        static string Space(int n, string space = "")
        {
            for (int i = 1; i < n; i++)
            {
                space += " ";
            }
            return space;
        }

        public static void Print_Tree(int n)
        {

            int c = n;

            for (int i = 1; i <= n; i++) //leaves
            {
                string space = Space(c);
                string star = "";
                
                for (int x = c; x < n; x++)
                {
                    star += "*";
                }
                
                Console.WriteLine(space + star + "*" + star + space);
                --c;
            }

            if (n < 3) //trunk    
            {
                Console.WriteLine(Space(n) + "*" + Space(n));
            }

            else
            {
                Console.WriteLine(Space(n) + "*" + Space(n));
                Console.WriteLine(Space(n) + "*" + Space(n));
            }
        }
    }
}