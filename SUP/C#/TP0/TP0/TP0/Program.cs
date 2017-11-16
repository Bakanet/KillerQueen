using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
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

        static uint MyFact(uint n)
        {
            if (n == 1)
                return n;
            return n * MyFact(n - 1);
        }
    }
}