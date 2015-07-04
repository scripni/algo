using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.MathOps
{
    public class MathOperations
    {
        public int DivideNoOperand(int a, int b)
        {
            // a / b
            int r = 0;
            while (a >= b)
            {
                r++;
                a -= b;
            }

            return r;
        }
    }
}
