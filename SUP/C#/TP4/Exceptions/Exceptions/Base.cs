using System;

namespace Exceptions
{
    public static class Base
    {
        public static int Fibonacci(int n)
        {
            if (n < 0)
                throw new ArgumentException("n must be positive");

            int a = 1, b = 1;
            while (n > 1)
            {
                a += b;
                b += a;
                n -= 2;
            }


            if (n % 2 == 0)
                return a;
            return b;
        }

        public static float DegToRad(float angle)
        {
            if (angle < -180 || angle > 180)
                throw new ArgumentException("angle must be between -180 and 180");

            angle = (angle * (float) Math.PI) / 180;
            return angle;
        }
        
        public static float RadToDeg(float angle)
        {
            if (angle < (float) -Math.PI || angle > (float) Math.PI)
                throw new ArgumentException("angle must be between -pi and pi");

            angle = (angle * 180) / (float) Math.PI;
            return angle;
        }
        
        public static float Pow(float n, int p)
        {
            int sign = 1;
            float temp = n;
            if (p < 0)
            {
                sign = -1;
                p = -p;
            }

            while (p > 1)
            {
                temp *= n;
                --p;
                
                if (temp > int.MaxValue)
                    throw new OverflowException("result is over max value");
            }
            return temp;
        }
    }
}