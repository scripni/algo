using System.Collections.Generic;

namespace Algo.Arrays
{
    public class ArrayOperations
    {
        public int[] FindZeroSum(int[] input)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for (int i = 0; i < input.Length; i++)
            {
                numbers[input[i]] = i;
            }

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (numbers.ContainsKey(-input[i] - input[j]))
                    {
                        int index = numbers[-input[i] - input[j]];
                        if (i == index || j == index) continue;
                        return new[] { i, j, index };
                    }
                }
            }

            return null;
        }
    }
}
