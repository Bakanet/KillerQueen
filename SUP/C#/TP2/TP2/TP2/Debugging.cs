using System.Net;

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
            double d = x, sum = x;
            for (int i = 1; i < n; i++)
            {
                d *= x * x * (-1);
                sum += d;
            }
            return sum;
            
            // Les problemes ici sont que sum, initialise a 0, est toujours egal a 0 a chaque tour de boucle (car
            // il y a la ligne sum = sum et que d, initialise a 0, va toujours renvoyer 0 car 0 * quelque chose est 
            // toujours egal a 0. c est inutile pour la fonction actuelle alors on le supprime. Il suffit ensuite de
            // modifier d de telle sorte que l'on va renvoyer une puissance impaire de x (on part de x puis on multiplie
            // par x^2 donc on obtient x^3 puis x^5, etc...) et on multiplie par -1 pour inverser les signes a chaque
            // tour. On doit s'arreter avant n et partir a partir de x (x^3 est notre premier terme calcule).
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
                for (int j = arr.Length - 2; j >= 0; j--)
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
            
            // Le premier probleme est qu'on veut chercher l'indice d'un element qui n'existe pas dans notre tableau car
            // ce dernier commence a -1. Du coup on initialise j à la taille du tableau -2 au lieu de -1. On fait
            // descendre j jusqu'a -1 pour bien parcourir tout notre tableau.
        }
    }
}