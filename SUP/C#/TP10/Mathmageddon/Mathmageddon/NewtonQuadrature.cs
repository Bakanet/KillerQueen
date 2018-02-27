using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton
{
    class NewtonQuadrature
    {
        // Define dictionary here
        private static Dictionary<int, List<double>> dictionary;

        // Initialize it, you will need to call this function the first time you use the dictionary
        public static void InitDictionary()
        {
            dictionary = new Dictionary<int, List<double>>{};
            dictionary.Add(0, new List<double> { 1, 1 });
            dictionary.Add(1, new List<double> { 1.0 / 2.0, 1, 1 });
            dictionary.Add(2, new List<double> { 1.0 / 6.0, 1, 4, 1 });
            dictionary.Add(3, new List<double> { 1.0 / 8.0, 1, 3, 3, 1 });
            dictionary.Add(4, new List<double> { 1.0 / 90.0, 7, 32, 12, 32, 7 });
            dictionary.Add(5, new List<double> { 1.0 / 288.0, 19, 75, 50, 50, 75, 19 });
            dictionary.Add(6, new List<double> { 1.0 / 840.0, 41, 216, 27, 272, 27, 216, 41 });
            dictionary.Add(7, new List<double> { 1.0 / 17280.0, 751, 3577, 1323, 2989, 2989, 1323, 3577, 751 });
            dictionary.Add(8, new List<double> { 1.0 / 28350.0, 989, 5888, -928, 10496, -4540, 10496, -928, 5888, 989 });
            dictionary.Add(9, new List<double> { 1.0 / 89600.0, 2857, 15741, 1080, 19344, 5778, 5778, 19344, 1080, 15741, 2857 });
            dictionary.Add(10, new List<double> { 1.0 / 59875.0, 16067, 106300, -48525, 272400, -260550, 427368, -260550, 272400, -48525, 106300, 16067 });
        }

        public static double IntegralNewtonQuadratureAt6(double a, double b, Func<double, double> f)
        {
            double h = (b - a) / 5;
            return (b - a) / 288 * (19 * f(a) + 75 * f(a + h) + 50 * f(a + 2 * h) + 50 * f(a + 3 * h) + 75 * f(a + 4 * h) + 19 * f(a + 5 * h));
        }

        public static double IntegralNewtonQuadrature(double a, double b, int n, Func<double, double> f)
        {
            InitDictionary();
            double h = (b - a) / n;
            List<double> deg = dictionary[n];
            double result = 0;
            for (int i = 1; i < deg.Count; ++i)
            {
                result += f(a + (i - 1) * h) * deg[i];
            }

            return result * (b - a) * deg[0];
        }

        public static double CompositeIntegralNewtonQuadrature(double a, double b, double n, int d, Func<double, double> f)
        {
            double integral = 0;
            for (double i = a; i < b; i += n)
            {
                integral += IntegralNewtonQuadrature(i, i + n, d, f);
            }
            return integral;
        }

        public static double CINQErrorMargin(double a, double b, double n, int d, Func<double, double> f, Func<double, double> F)
        {
            return F(b) - F(a) - CompositeIntegralNewtonQuadrature(a, b, n, d, f);  
        }
    }
}
