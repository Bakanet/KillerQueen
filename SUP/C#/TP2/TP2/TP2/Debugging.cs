namespace Debugger
{
    public class Debugging
    {
        public static int ex1()
        {
            //FIXME   
            bool stop = false;
            int div = 42;
            while (!stop)
            {
                bool isDivisor = Misc.isDivisor(666, div);
                stop = isDivisor;
                ++div;
            }
            return --div;
            
            // La boucle while ne fonctionnait pas car on isDivisor renvoyait toujours false (on re-calcule toujours la
            // meme operation) et donc stop ne pouvait jamais changer de valeur. Il faut donc retirer le & de la ligne
            // stop &= (sinon comme stop est initialise a false, cette ligne renvoit toujours false) et il faut que
            // isDivisor puisse renvoyer true egalement, donc remplacer 42 par div, la valeur qui s'incremente dans
            // cette boucle. Ainsi, quand 666 sera divisible par div, isDivisor vaudra true, donc stop vaudra true, donc
            // la boucle s'arretera.
        }

        public static double ex2(int x, int n)
        {
            // FIXME expected output: the sum of [x - x^3 + x^5 - ...]
            // with n number of terms
            double c = 0, d = 0, sum = 0;
            for (int i = 1; i < n - 1; i++)
            {
                c = (2) * (2 * i);
                d = d * x / c;
                sum = sum;
            }
            return sum;
            
            // Les problemes ici sont que sum, initialise a 0, est toujours egal a 0 a chaque tour de boucle et que
            // d, initialise a 0, va toujours renvoyer 0 car 0 * quelque chose est toujours egal a 0.
        }

        public static bool ex3(int n)
        {
            // FIXME expexted output: returns true if the number can be express as the sum of two primes 
            int i, f1 = 1, f2 = 1, f3 = 0, j;
            for (i = 0; i < n / 2 + 2; i++)
            {
                f1 = 0;
                f2 = 0;
                for (j = 4; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        f1 = 0;
                        j = i;
                    }
                }
                for (j = 0; j < n - i; j++)
                {
                    if ((n - 1) % j == 0)
                    {
                        f2 = 0;
                        j = n - i;
                    }
                }
                if (f1 == 0 && f2 == 1)
                {
                    return true;
                }
            }
            if (f3 == 1)
            {
                return false;
            }
            return true;
        }

        public static int[] ex4(int[] arr)
        {
            // FIXME - expected output: a sorted array
            // see Misc for a function that print an array
            for (int i = 0; i < arr.Length + 1; i++)
            {
                int temp = 0;
                for (int j = arr.Length; j >= 1; j--)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            return arr;
        }
    }
}