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
}