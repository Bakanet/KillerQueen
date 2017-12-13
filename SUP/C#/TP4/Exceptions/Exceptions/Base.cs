using System;

namespace Exceptions
{
    public static class Base
    {
        public static int Fibonacci(int n)
        {
            if (n < 0)
                throw new ArgumentException("n must be positive");
            
            else
            {
                int a = 1, b = 1;
                while (n > 1)
                {
                    a += b;
                    b += a;
                    n -= 2;
                }

                if (n % 2 == 0)
                    return a;
                else
                    return b;
            }
        }

        public static float DegToRad(float angle)
        {
            // TODO
            throw new NotImplementedException("Fix this quickly");
        }
        
        public static float RadToDeg(float angle)
        {
            // TODO
            throw new NotImplementedException("Fix this quickly");
        }
        
        public static float Pow(float n, int p)
        {
            // TODO
            throw new NotImplementedException("Fix this quickly");
        }
    }
}