using System;
using Calculater;

namespace CalculatorTest
{
    public class CalculatorTest
    {
        ICalculator _calculator;

        public CalculatorTest(ICalculator calculator)
        {
            _calculator = calculator;

            RunTests();
        }

        public void RunTests()
        {
            Console.WriteLine("Addition......... is" + (AddTest() ? "" : " not") + " working!");
            Console.WriteLine("Subtraction...... is" + (SubtractTest() ? "" : " not") + " working!");
            Console.WriteLine("Multiplication... is" + (MultiplyTest() ? "" : " not") + " working!");
            Console.WriteLine("Power............ is" + (PowerTest() ? "" : " not") + " working!");
            Console.WriteLine("Division......... is" + (DivideTest() ? "" : " not") + " working!");
        }

        public bool AddTest()
        {
            if (_calculator.Add(1, 1) != (1 + 1))
                return false;
            if (_calculator.Add(0, 0) != (0 + 0))
                return false;
            if (_calculator.Add(-5, 5) != ((-5) + 5))
                return false;
            return true;
        }

        public bool SubtractTest()
        {
            if (_calculator.Subtract(1, 1) != (1 - 1))
                return false;
            if (_calculator.Subtract(0, 0) != (0 - 0))
                return false;
            if (_calculator.Subtract(-5, 5) != ((-5) - 5))
                return false;
            return true;
        }

        public bool MultiplyTest()
        {
            if (_calculator.Multiply(1, 1) != (1 * 1))
                return false;
            if (_calculator.Multiply(0, 3) != (0 * 3))
                return false;
            if (_calculator.Multiply(-5, 5) != ((-5) * 5))
                return false;
            return true;
        }

        public bool PowerTest()
        {
            if (_calculator.Power(1, 1) != (Math.Pow(1, 1)))
                return false;
            if (_calculator.Power(0, 0) != (Math.Pow(0, 0)))
                return false;
            if (_calculator.Power(-5, 5) != (Math.Pow(-5, 5)))
                return false;
            return true;
        }

        public bool DivideTest()
        {
            try
            {
                if (_calculator.Divide(2, 2) != (2 / 2))
                    return false;
                if (_calculator.Divide(4, 2) != (4 / 2))
                    return false;
                if (_calculator.Divide(-5, 5) != ((-5) / 5))
                    return false;
                if (_calculator.Divide(5, 0) != 0)
                    return false;
                else
                    return true;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Caught {0}, u done goofed!",e);
                return false;
            }
        }
    }
}
