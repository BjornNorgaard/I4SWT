using System;
using Calculator.Library;
using NSubstitute;
using NUnit.Framework;

namespace Calculator.Test.Unit
{
    [TestFixture]
    public class CalculatorUnitTest
    {
        private ICalculator _uut;
        private ISmartCalculater fakeSmartCalculater;

        [SetUp]
        public void Setup()
        {
            fakeSmartCalculater = Substitute.For<ISmartCalculater>();
            _uut = new Library.Calculator(fakeSmartCalculater);
        }

        [Test]
        public void DerpTest()
        {
            _uut.Derp(1, 89);
            fakeSmartCalculater.Received().Add(1, Arg.Any<int>());
        }

        [TestCase(1.5, 2, 3.5)]
        [TestCase(0, 2, 2)]
        [TestCase(-1, 2, 1)]
        [TestCase(0, 0, 0)]
        [TestCase(7, 3, 10)]
        public void Add_AddTwoNumbers_ReturnsCorrect(double a, double b, double result)
        {
            Assert.That(_uut.Add(a, b), Is.EqualTo(result));
        }

        [TestCase(1, 0.5, 0.5)]
        [TestCase(0, 2, -2)]
        [TestCase(10, 2, 8)]
        [TestCase(0, 0, 0)]
        public void Subtract_SubtractTwoNumbers_ReturnsCorrect(double a, double b, double result)
        {
            Assert.That(_uut.Subtract(a, b), Is.EqualTo(result));
        }

        [TestCase(10, 0.5, 5)]
        [TestCase(0, 2, 0)]
        [TestCase(10, 2.5, 25)]
        [TestCase(0, 0, 0)]
        public void Multiply_MultiplyTwoNumbers_ReturnsCorrect(double a, double b, double result)
        {
            Assert.That(_uut.Multiply(a, b), Is.EqualTo(result));
        }

        [TestCase(0, 0, 1)]
        [TestCase(3, 2, 9)]
        [TestCase(1, 3, 1)]
        [TestCase(5, 5, 3125)]
        public void Power_PowerTwoNumbers_ReturnsCorrect(double a, double b, double result)
        {
            Assert.That(_uut.Power(a, b), Is.EqualTo(result));
        }

        [TestCase(10, 2, 5)]
        [TestCase(-10, 2, -5)]
        [TestCase(3, 2, 1.5)]
        [TestCase(3, 3, 1)]
        public void Divide_DivideTwoNumbers_ReturnsCorrect(double a, double b, double result)
        {
            Assert.That(_uut.Divide(a, b), Is.EqualTo(result));
        }

        [Test]
        public void Divide_DivideWithZero_ThrowsArgumentException()
        {
            Assert.Throws<DivideByZeroException>(() => _uut.Divide(3,0));
        }
    }
}
