using System;
using System.Threading.Tasks;

namespace PartiallyFilledArray
{
    public class PFAIndexOutOfBoundsException : Exception
    {
        public uint Pos { get; set; }
        public uint Count { get; set; }

        public PFAIndexOutOfBoundsException(uint pos, uint count)
        {
            Pos = pos;
            Count = count;
        }
    }

    public class PFAArrayFullException : Exception { }

    public class PFANoDataAtIndexException : Exception
    {
        public uint Pos { get; set; }

        public PFANoDataAtIndexException(uint pos)
        {
            Pos = pos;
        }
    }

    public class PFAElementNotInArray : Exception { }
}