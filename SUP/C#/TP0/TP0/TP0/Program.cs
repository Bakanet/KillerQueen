using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

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
        
    }
}