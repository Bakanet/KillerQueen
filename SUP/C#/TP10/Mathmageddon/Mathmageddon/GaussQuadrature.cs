using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gauss
{
    class GaussQuadrature
    {
        public static double IntegralGaussQuadrature(double a, double b, uint n, Func<double, double> f)
        {
            double[,] coeffs = GaussCoefficients(n);
            Tuple<double[], double[]> p = GetGaussRootsAndweights(n, coeffs);
            return GaussIntegrate(f, n, a, b, p.Item1, p.Item2);
        }

        // calculate gauss coeffiecients
        static double[,] GaussCoefficients(uint n)
        {
            //FIXME
            throw new NotImplementedException();
        }

        // evaluates gauss at x
        static double GaussEvaluation(uint n, double x, double[,] coeffs)
        {
            //FIXME
            throw new NotImplementedException();
        }

        static double Difference(uint n, double x, double[,] coeffs)
        {
            return n * (x * GaussEvaluation(n, x, coeffs) - GaussEvaluation(n - 1, x, coeffs)) / (x * x - 1);
        }

        // calculate the roots and the weights, use the Difference here
        static Tuple<double[], double[]> GetGaussRootsAndweights(uint n, double[,] coeffs)
        {
            //FIXME
            throw new NotImplementedException();
        }

        static double GaussIntegrate(Func<double, double> f, uint n, double a, double b, double[] roots, double[] weights)
        {
            //FIXME
            throw new NotImplementedException();
        }
    }
}
