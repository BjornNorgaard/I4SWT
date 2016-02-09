using System.Collections.Generic;

namespace PartiallyFilledArray
{
    public class PartiallyFilledArray : IPartiallyFilledArray
    {
        private uint _size;
        private uint _used;

        List<int> list = new List<int>(); 

        public PartiallyFilledArray(uint size)
        {
            _size = size;
            _used = 0;

            list.Capacity = (int)_size;
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

            if (pos > _size)
            {
                throw new PFAIndexOutOfBoundsException(pos, _size);
            }

            list[(int)pos] = data;
            _used++;
        }

        public int Get(uint pos)
        {
            if (pos > _size)
            {
                throw new PFAIndexOutOfBoundsException(pos, _size);
            }

            return list[(int) pos];
        }

        public uint Put(int data)
        {
            // if full array throw exception

            // find empty index
            uint index = 0;
            // if no empty throw exception

            // insert element

            // return index of element
            return index;
        }

        public uint Find(int data)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(uint pos)
        {
            throw new System.NotImplementedException();
        }
    }
}