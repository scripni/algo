using System.Linq;

namespace Algo.Sorting
{
    /// <summary>
    /// QuickSort implementation.
    /// </summary>
    public class QuickSort : Sorter<int>
    {
        /// <summary>
        /// Sorts the elements of an array.
        /// </summary>
        /// <param name="input">The input array.</param>
        /// <returns>A sorted array containing the input elements.</returns>
        public override int[] Sort(int[] input)
        {
            // though QuickSort can do in-place sorting,
            // leave the original array untouched as per the base class contract
            int[] copy = input.ToArray();

            Sort(copy, 0, input.Length - 1);

            return copy;
        }


        /// <summary>
        /// In-place recursive QuickSort.
        /// </summary>
        /// <param name="input">Input array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="end">End index.</param>
        /// <returns></returns>
        private void Sort(int[] input, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = input[start];
            int temp;
            int i, j;
            for (i = start + 1, j = start + 1; j <= end; j++)
            {
                if (input[j] < pivot)
                {
                    temp = input[j];
                    input[j] = input[i];
                    input[i] = temp;

                    i++;
                }
            }

            temp = input[i - 1];
            input[i - 1] = input[start];
            input[start] = temp;

            Sort(input, start, i - 2);
            Sort(input, i, end);

            return;
        }
    }
}
