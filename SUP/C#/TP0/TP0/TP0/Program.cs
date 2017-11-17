using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Xsl.Runtime;

namespace TP0
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(MyGcd(74, 148));
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
            int l = s.Length;
            int nth = (int) n;
            if (n > l)
                return s;
            else
            {
                return s.Substring(0, nth) + c + s.Substring(nth + 1);
            }

        }

        static int MyGcd(uint a, uint b)
        {
            int a2 = (int) a;
            int b2 = (int) b;

            if (a2 > b2)
            {
                int r = a2 % b2;
                if (r == 0)
                    return b2;
                else
                {
                    uint b3 = (uint) b2;
                    uint r2 = (uint) r;
                    return MyGcd(b3, r2);
                }
            }

            else
            {
                int r = b2 % a2;
                if (r == 0)
                    return a2;
                else
                {
                    uint a3 = (uint) a2;
                    uint r2 = (uint) r;
                    return MyGcd(a3, r2);
                }
            }
        }
        
    }
}