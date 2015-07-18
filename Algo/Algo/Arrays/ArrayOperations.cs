using System.Collections.Generic;

namespace Algo.Arrays
{
    public class ArrayOperations
    {
        public SubarraySum KadaneLargestSubarray(int[] a)
        {
            SubarraySum max = new SubarraySum(int.MinValue, int.MinValue, int.MinValue);
            SubarraySum currentMax = new SubarraySum(int.MinValue, int.MinValue, int.MinValue);

            for (int i = 0; i < a.Length; i++)
            {
                if (currentMax.Sum < 0)
                {
                    currentMax = new SubarraySum(i, i, a[i]);
                }
                else
                {
                    currentMax.To = i;
                    currentMax.Sum += a[i];
                }

                if (max.Sum < currentMax.Sum)
                {
                    max = currentMax;
                }
            }

            return max;
        }


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

        public void SortByCategory(int[] a)
        {
            int head = 0, tail = a.Length - 1, current = 0;
            while (current < tail)
            {
                int t = a[current];
                switch (Category(a[current]))
                {
                    case 0:
                        a[current] = a[head];
                        a[head++] = t;
                        break;
                    case 1:
                        current++;
                        break;
                    case 2:
                        a[current] = a[tail];
                        a[tail--] = t;
                        break;
                }
            }
        }

        private int Category(int x)
        {
            return x % 3;
        }
    }

    public struct SubarraySum
    {
        public int From;
        public int To;
        public int Sum;

        public SubarraySum(int from, int to, int sum)
        {
            From = from;
            To = to;
            Sum = sum;
        }
    }
}
