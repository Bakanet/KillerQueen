using System;
using System.Collections.Generic;

namespace Basics
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }

        public static int BinarySearch(int[] arr, int x)
        {
            int left = arr[0], right = arr[arr.Length - 1], mid = 0;
            while (left <= right)
            {
                mid = (left + right) / 2;
                
                if (x == mid)
                    return mid;
                else if (x < mid)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return -1; // si l'elem n'est pas dans le tableau
        }
    }
}