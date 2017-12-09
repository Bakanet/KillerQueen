using System.Security.Cryptography;
using System.Security.Policy;

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
            if (48 <= c2 && c2 <= 57)
            {
                c2 = c2 + n % 10;
                if (c2 > (int) '9')
                    c = (char) (c2 - 10);
                else if (c2 < (int) '0')
                    c = (char) (58 - (48 - c2));
                else
                    c = (char) c2;
            }
            
            else if (97 <= c2 && c2 <= 122)
            {
                c2 = c2 + n % 26;
                if (c2 > (int) 'z')
                    c = (char) (c2 - 26);
                else if (c2 < (int) 'a')
                    c = (char) (123 - (97 - c2));
                else c = (char) c2;
            }
            
            else if (65 <= c2 && c2 <= 90)
            {
                c2 = c2 + n % 26;
                if (c2 > (int) 'Z')
                    c = (char) (c2 - 26);
                else if (c2 < (int) 'A')
                    c = (char) (91 - (65 - c2));
                else c = (char) c2;
            }
        }
    }
}