using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RandomCodesnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            //var x = 2;

            //while (x == 2)
            //{
            //    Console.Write("herro");
            //}
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            
            if (a == 10)
            {
            }

            Foo(a, b);
        }

        static void Foo(int x, int y)
        {
            switch (x)
            {
                case 1:
                    Console.WriteLine(y);
                    break;
                default:
                    Console.WriteLine(y);
                    break;
            }
        }
    }
}
