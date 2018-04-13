using EvalExpr;
using System;
using System.Collections.Generic;
using List;

namespace TPCS12
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List.List<int> list = new List.List<int>(2);
            list.insert(0, 2);
            list.insert(0, 1);
            list.insert(1, 6);

            Node<int> n = list.head_;
            for (int i = 0; n != null; ++i)
            {
                Console.Write(n.Data);
                Console.Write(" ");
                n = n.Next;
            }

            Console.ReadLine();
        }
    }
}