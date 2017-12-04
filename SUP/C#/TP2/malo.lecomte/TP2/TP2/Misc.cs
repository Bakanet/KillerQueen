using System;

namespace Debugger
{
    public static class Misc
    {
        public static bool isDivisor(int a, int b)
        {
            return a % b == 0;
        }

        public static void printArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}