using System;

namespace Application
{
    public class Calculator : ICalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Divide(double a, double b)
        {
            if (a == 0 || b == 0)
            {
                throw new ArgumentException();
            }
            else
            {
                return a/b;
            }
        }

        public double Multiply(double a, double b)
        {
            return a*b;
        }
        public double Power(double x, double exp)
        {
            return Math.Pow(x, exp);
        }
    }
}
