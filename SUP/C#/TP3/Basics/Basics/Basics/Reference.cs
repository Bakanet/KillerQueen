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
            //FIXME
        }
    }
}