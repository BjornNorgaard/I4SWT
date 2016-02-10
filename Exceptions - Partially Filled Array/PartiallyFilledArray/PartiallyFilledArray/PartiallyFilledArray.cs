using System.Collections.Generic;

namespace PartiallyFilledArray
{
    public class PartiallyFilledArray : IPartiallyFilledArray
    {
        private uint _size;
        private uint _used;

        int[] _array;

        public PartiallyFilledArray(uint size)
        {
            _size = size;
            _used = 0;

            _array = new int[10];

            for (int i = 0; i < _size; i++)
            {
                _array[i] = -1;
            }
        }

        public uint Size
        {
            get { return _size; }
        }

        public uint Used
        {
            get { return _used; }
        }

        public void Set(uint pos, int data)
        {
            if (_used >= _size)
            {
                throw new PFAArrayFullException();
            }

            if (pos >= _size)
            {
                throw new PFAIndexOutOfBoundsException(pos, _size);
            }

            _array[pos] = data;
            _used++;
        }

        public int Get(uint pos)
        {
            if (pos >= _size)
            {
                throw new PFAIndexOutOfBoundsException(pos, _size);
            }

            return _array[pos];
        }

        public uint Put(int data)
        {
            // if full array throw exception
            if (_used >= _size)
            {
                throw new PFAArrayFullException();
            }

            // find empty index
            int index = 0;

            for (int i = 0; i < _size; i++)
            {
                if (_array[i] == -1)
                {
                    index = i;
                    break;
                }
            }

            // insert element
            Set((uint)index, data);

            // return index of element
            return (uint)index;
        }

        public uint Find(int data)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_array[i] == data)
                {
                    return (uint)i;
                }
            }

            throw new PFAElementNotInArray();
        }

        public void RemoveAt(uint pos)
        {
            if (pos >= _size)
            {
                throw new PFAIndexOutOfBoundsException(pos, _size);
            }

            if (_array[pos] != -1)
            {
                _array[pos] = -1;
                _used--;
            }
        }
    }
}