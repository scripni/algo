using System.Collections.Generic;

namespace Algo.MathOps
{
    public class Fibbonacci
    {
        public List<int> CreateFibbonacci(int n)
        {
            List<int> result = new List<int>();
            result.Add(0);
            result.Add(1);

            for (int i = 2; i < n; i++)
            {
                result.Add(result[i - 1] + result[i - 2]);
            }

            return result;
        }
    }
}
