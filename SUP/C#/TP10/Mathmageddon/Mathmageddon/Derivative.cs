using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derivative
{
    class Derivative
    {
        public static double RateOfChange(double a, double h, Func<double, double> f)
        {
            if (h == 0)
                throw new DivideByZeroException();
            return Math.Round((f(a + h) - f(a)) / h, 6);
        }

        public static List<double> GeneratePointsForPlot(double a, double b, double t, Func<double, double> f)
        {
            List<double> list = new List<double>();
            for (double i = a; i < b; i += t)
            {
                list.Add(RateOfChange(i, b - i, f));
            }
            return list;
        }
    }
}
