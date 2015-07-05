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

            if (a.Length < b.Length)
            {
                int[] t = new int[b.Length];
                Array.Copy(a, 0, t, t.Length - a.Length, a.Length);
                a = t;
            }

            int[] result = new int[a.Length + 1];

            for (int i = a.Length - 1; i >= 0; i--)
            {
                result[i + 1] = a[i] + b[i];
            }

            for (int i = result.Length - 1; i > 0; i--)
            {
                if (result[i] > 9)
                {
                    result[i - 1] += result[i] / 10;
                    result[i] %= 10;
                }
            }

            return result;
        }

        public int[] Multiply(int[] a, int[] b)
        {
            if (a.Length > b.Length)
            {
                int[] t = new int[a.Length];
                Array.Copy(b, 0, t, a.Length - b.Length, b.Length);
                b = t;
            }

            if (b.Length > a.Length)
            {
                int[] t = new int[b.Length];
                Array.Copy(a, 0, t, b.Length - a.Length, a.Length);
                a = t;
            }

            int[] result = new int[a.Length * 2];
            int resultIndex = 0;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                for (int j = b.Length - 1; j >= 0; j--)
                {
                    int aOffset = a.Length - 1 - i;
                    int bOffset = b.Length - 1 - j;
                    resultIndex = a.Length * 2 - 1 - aOffset - bOffset;

                    int x = a[i] * b[j];
                    result[resultIndex] += x;
                }
            }

            for (int i = result.Length - 1; i > 0; i--)
            {
                if (result[i] > 9)
                {
                    result[i - 1] += result[i] / 10;
                    result[i] %= 10;
                }
            }

            return result;
        }
    }

    public struct DivisionResult
    {
        public int Divisor;
        public int Remainder;
    }

}
