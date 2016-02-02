namespace Calculater_namespace
{
    public interface ICalculator
    {
        double Add(double a, double b);
        double Multiply(double a, double b);
        double Power(double x, double exp);
        double Subtract(double a, double b);
    }
}