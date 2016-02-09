namespace PartiallyFilledArray
{
    public interface IPartiallyFilledArray
    {
        // Returns the size of the array 
        uint Size { get; }

        // Returns the number of used elements in the array
        uint Used { get; }

        // Sets position 'pos' to 'data'
        void Set(uint pos, int data);

        // Gets data from position 'pos'
        int Get(uint pos);

        // Puts 'data' into the array and returns the index at which 
        // 'data' was put
        uint Put(int data);

        // Returns the index of the first occurrence of 'data'
        uint Find(int data);

        // Removes element at position 'pos'
        void RemoveAt(uint pos);
    }

    public class PartiallyFilledArray : IPartiallyFilledArray
    {
        private uint _size;
        private uint _used;

        public PartiallyFilledArray(uint size)
        {
            _size = size;
            _used = 0;
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
            throw new System.NotImplementedException();
        }

        public int Get(uint pos)
        {
            throw new System.NotImplementedException();
        }

        public uint Put(int data)
        {
            throw new System.NotImplementedException();
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