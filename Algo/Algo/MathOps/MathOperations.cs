using System;

namespace Algo.MathOps
{
    public class MathOperations
    {
        public DivisionResult DivideNoOperand(int a, int b)
        {
            // a / b
            int r = 0;
            while (a >= b)
            {
                r++;
                a -= b;
            }

            DivisionResult result = new DivisionResult();
            result.Divisor = r;
            result.Remainder = a;

            return result;
        }


        public double SquareRoot(double a, double e)
        {
            double x = a / 2;

            while (Math.Abs(x * x - a) >= e)
            {
                x = (x + a / x) / 2;
            }

            return x;
        }
    }

    public struct DivisionResult
    {
        public int Divisor;
        public int Remainder;
    }

}
