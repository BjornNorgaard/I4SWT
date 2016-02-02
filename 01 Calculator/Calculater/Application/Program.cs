using System;
using Calculater;

namespace Application
{
    class Program
    {
        static Calculator _calculator = new Calculator();

        static void Main(string[] args)
        {
            Console.WriteLine("Commence testing!");

            TestAdd();
            TestSubtract();
            TestMultiply();
            TestExponential();
        }

        private static void TestAdd()
        {
            Console.Write("Adding... \t");
            Console.WriteLine(_calculator.Add(1, 1) == 2 ? "Works!" : "Does NOT work!");
        }

        private static void TestSubtract()
        {
            Console.Write("Subtracting... \t");
            Console.WriteLine(_calculator.Subtract(10, 4) == 6 ? "Works!" : "Does NOT work!");
        }

        private static void TestMultiply()
        {
            Console.Write("Multiplying... \t");
            Console.WriteLine(_calculator.Multiply(2, 3) == 6 ? "Works!" : "Does NOT work!");
        }

        private static void TestExponential()
        {
            Console.Write("Power... \t");
            Console.WriteLine(_calculator.Power(3, 2) == 9 ? "Works!" : "Does NOT work!");
        }
    }
}
