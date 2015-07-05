using System;
using System.Collections.Generic;

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

        public int[] AddBigNumbers(int[] a, int[] b)
        {
            if (a.Length > b.Length)
            {
                int[] t = new int[a.Length];
                Array.Copy(b, 0, t, t.Length - b.Length, b.Length);
                b = t;
            }
            else if (a.Length < b.Length)
            {
                int[] t = new int[b.Length];
                Array.Copy(a, 0, t, t.Length - a.Length, a.Length);
                a = t;
            }

            int carry = 0;
            int[] result = new int[a.Length + 1];

            for (int i = a.Length - 1; i >= 0; i--)
            {
                result[i + 1] = a[i] + b[i] + carry;
                carry = result[i + 1] / 10;
                result[i + 1] %= 10;
            }

            result[0] = carry;
            return result;
        }
    }

    public struct DivisionResult
    {
        public int Divisor;
        public int Remainder;
    }

}
