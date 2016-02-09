using System.Xml.Serialization;
using NUnit.Framework;
using PartiallyFilledArray;

namespace PartiallyFilledArray.Test.Unit
{
    [TestFixture]
    public class PFAUnitTest
    {
        private IPartiallyFilledArray _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new PartiallyFilledArray(10);
        }

        #region Testing Size

        [Test]
        public void Size_NoItemsAdded_Returns10()
        {
            Assert.That(_uut.Size, Is.EqualTo(10));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        public void Size_AddsNumberOfItems_ReturnsUnchangedSize(int numOfItems)
        {
            // adding items
            for (int i = 0; i < numOfItems; i++)
            {
                _uut.Put(i);
            }

            Assert.That(_uut.Size, Is.EqualTo(10));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        public void Size_RemovesNumberOfItems_ReturnsUnchangedSize(int numOfItems)
        {
            // adds items to be removed
            for (int i = 0; i < numOfItems; i++)
            {
                _uut.Put(i);
            }

            // removes items
            for (uint i = 0; i < numOfItems; i++)
            {
                _uut.RemoveAt(i);
            }

            Assert.That(_uut.Size, Is.EqualTo(10));
        }

        #endregion

        #region Testing Used

        [Test]
        public void Used_NoItemsAdded_Returns0()
        {
            Assert.That(_uut.Used, Is.EqualTo(0));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(9)]
        [TestCase(10)]
        public void Used_AddNumberOfItems_ReturnCorrectUsed(int numOfItems)
        {
            for (int i = 0; i < numOfItems; i++)
            {
                _uut.Put(i);
            }

            Assert.That(_uut.Used, Is.EqualTo(numOfItems));
        }

        #endregion

        #region Testing Set



        #endregion
    }
}
