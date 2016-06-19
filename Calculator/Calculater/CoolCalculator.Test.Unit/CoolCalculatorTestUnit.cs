using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace CoolCalculator.Test.Unit
{
    [TestFixture]
    public class CoolCalculatorTestUnit
    {
        Calculator _uut;
        private IAdditionCalculator _fakeAdditionCalculator;

        [SetUp]
        public void Setup()
        {
            _fakeAdditionCalculator = Substitute.For<IAdditionCalculator>();
            _uut = new Calculator(_fakeAdditionCalculator);
        }

        [Test]
        public void Add_Adding1And2_SubclassReceivedCall()
        {
            _uut.Add(1,2);
            _fakeAdditionCalculator.Received().Add(1, Arg.Any<int>());
        }

        [Test]
        public void Add_Adding1And2_Returns3()
        {
            _fakeAdditionCalculator.Add(1, 2).Returns(3);
            Assert.That(_uut.Add(1, 2), Is.EqualTo(3));
        }
    }
}
