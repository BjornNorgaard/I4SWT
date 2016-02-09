using System;
using System.CodeDom;
using System.Threading;

namespace PartiallyFilledArray.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            IPartiallyFilledArray pfa = new PartiallyFilledArray(10);

            var cont = true;
            while (cont)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("(1) Size       See size of array");
                Console.WriteLine("(2) Used       See current array usage");
                Console.WriteLine("(3) Set()      set data at specified entry");
                Console.WriteLine("(4) Get()      get data from specified entry");
                Console.WriteLine("(5) Put()      put data");
                Console.WriteLine("(6) Find()     find data");
                Console.WriteLine("(7) RemoveAt() Remove data from specified entry");
                Console.WriteLine("(8) Quit");

                uint choice = 0;
                try
                {
                    choice = Convert.ToUInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    // Do nothing - choice = 0 is fine
                }


                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Size is {0}", pfa.Size);
                            break;

                        case 2:
                            Console.WriteLine("Used is {0}", pfa.Used);
                            break;

                        case 3:
                            Console.Write("Enter position to set: ");
                            var setPos = Convert.ToUInt32(Console.ReadLine());
                            Console.Write("Enter value to set: ");
                            var setVal = Convert.ToInt32(Console.ReadLine());
                            pfa.Set(setPos, setVal);
                            Console.WriteLine("Position {0} set to {1}", setPos, setVal);
                            break;

                        case 4:
                            Console.Write("Enter position to get from: ");
                            var getPos = Convert.ToUInt32(Console.ReadLine());
                            var getRes = pfa.Get(getPos);
                            Console.WriteLine("Got {0} from pos {1}", getRes, getPos);
                            break;

                        case 5:
                            Console.Write("Enter value to put: ");
                            var putVal = Convert.ToInt32(Console.ReadLine());
                            var putPos = pfa.Put(putVal);
                            Console.WriteLine("Put {0} on pos {1}", putVal, putPos);
                            break;

                        case 6:
                            Console.Write("Enter value to find: ");
                            var findVal = Convert.ToInt32(Console.ReadLine());
                            var findPos = pfa.Find(findVal);
                            if (findPos == pfa.Size) Console.WriteLine("Did not find {0}", findVal);
                            else Console.WriteLine("Found {0} on pos {1}", findVal, findPos);
                            break;

                        case 7:
                            Console.Write("Enter position to remove from: ");
                            var removePos = Convert.ToUInt32(Console.ReadLine());
                            pfa.RemoveAt(removePos);
                            Console.WriteLine("Removed element at position {0}", removePos);
                            break;

                        case 8:
                            cont = false;
                            break;

                        default:
                            Console.WriteLine("Input not recognized, please try again");
                            break;
                    }
                }
                catch (PFAIndexOutOfBoundsException ex)
                {
                    Console.WriteLine("Error: Index out of bounds: {0} >= {1}", ex.Pos, ex.Count);
                }
                catch (PFAArrayFullException ex)
                {
                    Console.WriteLine("Error: Array is full");
                }
                catch (PFANoDataAtIndexException ex)
                {
                    Console.WriteLine("Error: No data at index {0}", ex.Pos);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: General exception caught: {0}", ex.ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
