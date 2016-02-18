using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;

namespace Andengradsligning
{
    public class Andengradsligning
    {
        public double R1 { get; private set; } = 0;
        public double R2 { get; private set; } = 0;
        public double D { get; set; }

        public void FindRoots(int a, int b, int c)
        {
             D = b * b - 4 * a * c;

            if (D == 0)
            {
                R1 = (-b + Math.Sqrt(D))/(a*2);
            }
            else if (D > 0)
            {
                R1 = (-b + Math.Sqrt(D)) / (a * 2);
                R2 = (-b - Math.Sqrt(D)) / (a * 2);
            }
            else if (D < 0)
            {
                throw new NoRootsException();
            }
        }
    }
}
