using System.Security.Cryptography;

namespace Basics
{
    public class Reference
    {
        public static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }

        public static int Trunc(ref float f)
        {
            int e = (int) f;
            f = f - (float) e;

            return e;
        }

        public static void RotChar(ref char c, int n)
        {
            int c2 = (int) c;
            if (48 <= c2 || c2 <= 57)
            {
                c2 = c2 + n % 10;
                if (c2 > (int) '9')
                    c = (char) (((int) '0' - 1) + (c2 - (int) '9'));
                else if (c2 < (int) '0')
                    c = (char) (((int) '9' + 1) - ((int) '0' - c2));
                else
                    c = (char) c2;
            }
        }
    }
}