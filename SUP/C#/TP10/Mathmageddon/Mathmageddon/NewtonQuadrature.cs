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

        // Initialize it, you will need to call this function the first time you use the dictionary
        public static void InitDictionary()
        {
            //FIXME
            throw new NotImplementedException();
        }

        public static double IntegralNewtonQuadratureAt6(double a, double b, Func<double, double> f)
        {
            //FIXME
            throw new NotImplementedException();
        }

        public static double IntegralNewtonQuadrature(double a, double b, int n, Func<double, double> f)
        {
            //FIXME
            throw new NotImplementedException();
        }

        public static double CompositeIntegralNewtonQuadrature(double a, double b, double n, int d, Func<double, double> f)
        {
            //FIXME
            throw new NotImplementedException();
        }

        public static double CINQErrorMargin(double a, double b, double n, int d, Func<double, double> f, Func<double, double> F)
        {
            //FIXME
            throw new NotImplementedException();
        }
    }
}
