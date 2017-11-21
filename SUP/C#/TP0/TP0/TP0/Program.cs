using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

namespace TP0
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
        }

        static void HelloWorld()
        {
            Console.WriteLine("Hello World!");
        }

        static void SayHello()
        {
            Console.WriteLine("What's your name ?");
            string name = Console.ReadLine();
            Console.WriteLine("Well Hello " + name + " !");
        }

        static void CalcAge()
        {
            Console.WriteLine("What's your year of birth ?");
            int age = DateTime.Today.Year - int.Parse(Console.ReadLine());
            Console.WriteLine("Looks like you're around " + age + " !");
        }

        static int Absolute(int x)
        {
            if (x < 0)
                return -x;
            return x;
        }

        static double MyPow(double x, int n)
        {
            if (n == 0)
                return 1;
            else if (n == 1)
                return x;
            else if (n < 0)
                return (1 / x) * MyPow(x, n + 1);
            else
                return x * MyPow(x, n - 1);
        }

        static uint MyFibo(uint n)
        {
            if (n == 0 || n == 1)
                return n;
            else
                return MyFibo(n - 1) + MyFibo(n - 2);
        }

        static string ChangeChar(string s, char c, uint n)
        {
            if (n > s.Length - 1)
                return s;
            else
            {
                return s.Substring(0, (int) n) + c + s.Substring((int) n + 1);
            }

        }

        static int MyGcd(uint a, uint b)
        {
            int a2 = a < b ? (int) b : (int) a;
            int b2 = a < b ? (int) a : (int) b;
            int r = a2 % b2;

            if (r == 0)
                return b2;
            else
                return MyGcd((uint) b2, (uint) r);
        }

        static double MySqrt(double n, uint i)
        {
            if (i == 0)
                return 0.5;
            else
                return (MySqrt(n, i - 1) + n / MySqrt(n, i - 1)) / 2;
        }

        static string MyReverseString(string s)
        {
            if (s.Length == 1)
                return s;
            else
            {
                return (MyReverseString(s.Substring(1))) + s[0];
            }
        }

        static bool MyIsPalindrome(string a)
        {
            int length = a.Length / 2;
            return a.Substring(0, a.Length / 2 + 1) == MyReverseString(a.Substring(length));
        }

        static void CalcRealAge()
        {
            Console.WriteLine("What's your year of birth ?");
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("What's your month of birth ?");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("What's your day of birth");
            int d = int.Parse(Console.ReadLine());
            
            if (m < DateTime.Today.Month || d < DateTime.Today.Day && m == DateTime.Today.Month)
                Console.WriteLine("Looks like you're exactly " + (DateTime.Today.Year - y));
            else
                Console.WriteLine("Looks like you're exactly " + (DateTime.Today.Year - y - 1));
        }

    }
}