namespace CoolCalculator
{
    public class Calculator
    {
        IAdditionCalculator _additionCalculator;

        public Calculator(IAdditionCalculator additionCalculator)
        {
            _additionCalculator = additionCalculator;
        }

        public int Add(int a, int b)
        {
            return _additionCalculator.Add(a, b);
        }
    }
}
