using System;
using System.Xml.Serialization;
using NUnit.Framework;
using PartiallyFilledArray;

namespace PartiallyFilledArray.Test.Unit
{
    [TestFixture]
    public class PFAUnitTest
    {
        private IPartiallyFilledArray _uut;
        private uint _sizeOfArray = 10;

        [SetUp]
        public void Setup()
        {
            _uut = new PartiallyFilledArray(_sizeOfArray);
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

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(9)]
        [TestCase(10)]
        public void Used_AddNumberOfItemsWithSet_ReturnCorrectUsed(int numOfItems)
        {
            for (int i = 0; i < numOfItems; i++)
            {
                _uut.Set((uint)i, i);
            }

            Assert.That(_uut.Used, Is.EqualTo(numOfItems));
        }

        #endregion

        #region Testing Set

        [TestCase(1, 2)]
        [TestCase(1, 4)]
        [TestCase(5, 54)]
        [TestCase(8, 9)]
        [TestCase(9, 88)]
        public void Set_SetDataInPos_DataIsNowContainedInPos(int pos, int data)
        {
            _uut.Set((uint)pos, data);

            Assert.That(_uut.Get((uint)pos), Is.EqualTo(data));
        }

        [TestCase(-1, 5)]
        [TestCase(10, 5)]
        [TestCase(11, 5)]
        public void Set_SetDataInInvalidPos_ThrowsPFAIndexOutOfBoundsException(int pos, int data)
        {
            Assert.Throws<PFAIndexOutOfBoundsException>(() => _uut.Set((uint)pos, data));
        }

        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(10, 1)]
        [TestCase(11, 1)] // checks if array if full, before valid-index-check
        public void Set_InputDataInFullArray_ThrowsPFAArrayFullException(int pos, int data)
        {
            for (int i = 0; i < _sizeOfArray; i++)
            {
                _uut.Set((uint)i, i);
            }

            Assert.Throws<PFAArrayFullException>(() => _uut.Set((uint)pos, data));
        }

        #endregion

        #region Testing Get

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(8)]
        [TestCase(9)]
        public void Get_GetsDataFromValidPos_ReturnsCorrectData(int pos)
        {
            _uut.Set((uint)pos, pos);

            Assert.That(_uut.Get((uint)pos), Is.EqualTo(pos));
        }

        [TestCase(-2)]
        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(11)]
        public void Get_GetDataFromInvalidPos_ThrowsPFAIndexOutOfBoundsException(int pos)
        {
            Assert.Throws<PFAIndexOutOfBoundsException>(() => _uut.Get((uint)pos));
        }

        #endregion

        #region Testing Put

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(8)]
        [TestCase(9)]
        public void Put_PutsItemInFullArray_ThrowsPFAArrayFullException(int data)
        {
            for (int i = 0; i < _sizeOfArray; i++)
            {
                _uut.Set((uint)i, i);
            }

            Assert.Throws<PFAArrayFullException>(() => _uut.Put(data));
        }

        [Test]
        public void Put_AllEntriesExceptOneAreTaken_InsertItemAtLastEmptyIndex()
        {
            for (int i = 0; i < 5; i++)
            {
                _uut.Set((uint)i, i);
            }

            for (int i = 6; i < _sizeOfArray; i++)
            {
                _uut.Set((uint)i, i);
            }

            _uut.Put(99);

            Assert.That(_uut.Find(99), Is.EqualTo(5));
        }

        #endregion

        #region Testing Find

        [TestCase(-10)]
        [TestCase(-1)]
        [TestCase(11)]
        [TestCase(55)]
        [TestCase(500)]
        public void Find_SearchForItemNotInArray_ThrowsPFAElementNotInArray(int a)
        {
            for (int i = 0; i < _sizeOfArray; i++)
            {
                _uut.Set((uint)i, i * 10);
            }

            Assert.Throws<PFAElementNotInArray>(() => _uut.Find(a));
        }

        [TestCase(0, 5)]
        [TestCase(1, 4)]
        [TestCase(5, 7)]
        [TestCase(8, 55)]
        [TestCase(9, 99)]
        public void Find_SearchForItemInArray_ReturnsCorrectIndexOfItem(int pos, int data)
        {
            _uut.Set((uint)pos, data);
            
            Assert.That(_uut.Find(data), Is.EqualTo(pos));
        }

        #endregion

        #region Testing RemoveAt

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(8)]
        [TestCase(9)]
        public void RemoveAt_RemovesSingleItem_IndexShouldBeNulled(int pos)
        {
            for (int i = 0; i < _sizeOfArray; i++)
            {
                _uut.Put(i);
            }

            _uut.RemoveAt((uint) pos);

            Assert.That(_uut.Get((uint)pos), Is.EqualTo(-1));
        }

        [TestCase(-2)]
        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(100)]
        public void RemoveAt_RemoveItemOutOfBound_ThrowsPFAIndexOutOfBoundsException(int pos)
        {
            Assert.Throws<PFAIndexOutOfBoundsException>( () => _uut.RemoveAt((uint)pos));
        }

        #endregion
    }
}
