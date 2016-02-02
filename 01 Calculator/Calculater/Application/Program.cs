using static Application.Calculator;

namespace Application
{
    class Program
    {
        private static void Main(string[] args)
        {
            CalculatorTest myCalculatorTest = new CalculatorTest(new Calculator());
        }
    }
}
