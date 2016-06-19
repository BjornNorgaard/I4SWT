using System;
using System.Security.Cryptography.X509Certificates;

namespace Calculator.Library
{
    public class Calculator : ICalculator
    {
        private ISmartCalculater _smartCalculater;

        public Calculator(ISmartCalculater smartCalculater)
        {
            _smartCalculater = smartCalculater;
        }

        public void Derp(int a, int b)
        {
            _smartCalculater.Add(a, b);
        }

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
            if (b == 0)
            {
                throw new DivideByZeroException();
            }
            return a / b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }
        public double Power(double x, double exp)
        {
            return Math.Pow(x, exp);
        }
    }

    public interface ISmartCalculater
    {
        void Add(int a, int b);
    }
}
