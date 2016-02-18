using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;
using NUnit.Framework;

namespace Andengradsligning.Test.Unit
{
    [TestFixture]
    public class AndengradsligningTestUnit
    {
        private Andengradsligning _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new Andengradsligning();
        }

        [TestCase(5, 0, -5, 1)]
        [TestCase(-5, 2, 1, -0.28989794855663559d)]
        public void FindRoots_FindCorrectRoots_SetsMemberR1(int a, int b, int c, double d)
        {
            _uut.FindRoots(a, b, c);
            Assert.That(_uut.R1, Is.EqualTo(d));
        }

        [Test]
        public void FindRoots_FindFaultyRoots_ThrowsExcep()
        {
            Assert.Throws<NoRootsException>(() => _uut.FindRoots(5, 2, 1));
        }
    }
}
