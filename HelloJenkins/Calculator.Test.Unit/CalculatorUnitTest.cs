using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.Test.Unit
{
    [TestFixture]
    public class CalculatorUnitTest
    {
        [Test]
        public void Add_AddTwoNumbers_SumReturned()
        {
            var uut = new Calc();
            Assert.That(uut.Add(2, 3), Is.EqualTo(5));
        }
    }
}
