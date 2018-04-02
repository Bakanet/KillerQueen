using System;

namespace TinyBistro
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("What type of operation do you want to use ?");
            Console.WriteLine("  1. +");
            Console.WriteLine("  2. -");
            Console.WriteLine("  3. *");
            Console.WriteLine("  4. /");
            Console.WriteLine("  5. %");
            Console.WriteLine();
            string res_n = "";
            int op = -1;
            do
            {
                Console.WriteLine("Please provide an integer between 1 and 5 ");
                res_n = Console.ReadLine();
                if (!Int32.TryParse(res_n, out op))
                {
                    Console.WriteLine("This was not an integer");
                    op = -1;
                }
            } while (op <= 0 || op > 5);
            string num1, num2;
            Console.WriteLine("Please type the first number");
            num1 = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Please type the second number");
            num2 = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Result: ");
            switch (op)
            {
                    case 1:
                        BigNum res1 = new BigNum(num1) + new BigNum(num2);
                        res1.Print();
                        break;
                    case 2:
                        BigNum res2 = new BigNum(num1) - new BigNum(num2);
                        res2.Print();
                        break;
                    case 3:
                        BigNum res3 = new BigNum(num1) * new BigNum(num2);
                        res3.Print();
                        break;
                    case 4:
                        BigNum res4 = new BigNum(num1) / new BigNum(num2);
                        res4.Print();
                        break;
                    case 5:
                        BigNum res5 = new BigNum(num1) % new BigNum(num2);
                        res5.Print();
                        break;
                    default:
                        throw new ArgumentException("Maybe you break the code of Main but this is not supposed to happen");
            }
            Console.WriteLine();
            Console.WriteLine("Press enter key to quit...");
            Console.ReadLine();

            BigNumExtended test = new BigNumExtended("254");
        }
    }
}
