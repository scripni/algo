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
    }

    public struct DivisionResult
    {
        public int Divisor;
        public int Remainder;
    }

}
