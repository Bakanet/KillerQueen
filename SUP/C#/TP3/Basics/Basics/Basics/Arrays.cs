using System.Xml.Schema;

namespace Basics
{
    public class Arrays
    {
        public static int Search(int[] arr, int e)
        {
            int n = arr.Length, i = 0;
            while (i < n && e != arr[i])
                ++i;

            if (i < n)
                return i;
            else
                return -1;
        }

        public static int KingOfTheHill(int[] arr)
        {
            return -1;
        }

        public static int[] CloneArray(int[] arr)
        {
            int length = arr.Length;
            int[] newArr = new int[length];
            
            for (int i = 0; i < length; i++)
            {
                newArr[i] = arr[i];
            }

            return newArr;
        }

        public static void BubbleSort(int[] arr)
        {
            int length = arr.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int a = arr[j], b = arr[j + 1];
                        Reference.Swap(ref a, ref b);
                        arr[j] = a;
                        arr[j + 1] = b;
                    }
                }
            }
        }
    }
}