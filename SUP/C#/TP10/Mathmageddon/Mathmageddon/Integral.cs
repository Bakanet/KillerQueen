using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace integral
{
    class Integral
    {
        public static double IntegralRectangleRule(double a, double b, Func<double, double> f)
        {
            return f(a) * (b - a);
        }

        public static double CompositeIntegralRectangleRule(double a, double b, double n, Func<double, double> f)
        {
            double integral = 0;
            for (double i = a; i < b; i += n)
            {
                integral += IntegralRectangleRule(i, i + n, f);
            }

            return integral;
        }

        public static double CIRRErrorMargin(double a, double b, double n, Func<double, double> f, Func<double, double> F)
        {
            return F(b) - F(a) - CompositeIntegralRectangleRule(a, b, n, f);
        }

        public static double IntegralTrapezoidalRule(double a, double b, Func<double, double> f)
        {
            return (b - a) * (f(a) + f(b)) / 2;
        }

        public static double CompositeIntegralTrapezoidalRule(double a, double b, double n, Func<double, double> f)
        {
            double integral = 0;
            for (double i = a; i < b; i += n)
            {
                integral += IntegralTrapezoidalRule(i, i + n, f);
            }
            return integral;
        }

        public static double CITRErrorMargin(double a, double b, double n, Func<double, double> f, Func<double, double> F)
        {
            return F(b) - F(a) - CompositeIntegralTrapezoidalRule(a, b, n, f);
        }

        public static double IntegralSimpsonRule(double a, double b, Func<double, double> f)
        {
            //FIXME
            throw new NotImplementedException();
        }

        public static double CompositeIntegralSimpsonRule(double a, double b, double n, Func<double, double> f)
        {
            //FIXME
            throw new NotImplementedException();
        }

        public static double CISRErrorMargin(double a, double b, double n, Func<double, double> f, Func<double, double> F)
        {
            //FIXME
            throw new NotImplementedException();
        }
    }
}
