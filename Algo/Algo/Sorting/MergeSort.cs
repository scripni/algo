using System;

namespace Algo.Sorting
{
	/// <summary>
	/// Merge sort.
	/// </summary>
	public class MergeSort : Sorter
	{
		/// <summary>
		/// Sorts an input array using merge sort.
		/// </summary>
		/// <param name="input">The input array.</param>
		/// <returns>A sorted array containing the input elements.</returns>
		public override int[] Sort(int[] input)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}

			int _ = 0;
			return SortAndCountInternal(input, ref _);
		}


		/// <summary>
		/// Counts the number of inversions in an array.
		/// </summary>
		/// <param name="input">The input array.</param>
		/// <returns>Returns the number of inversions in the array.</returns>
		public int CountInversions(int[] input)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}

			int inversions = 0;
			SortAndCountInternal(input, ref inversions);

			return inversions;
		}


		/// <summary>
		/// Sorts an input array using merge sort and counts the number of inversions in the array.
		/// </summary>
		/// <param name="input">The input array.</param>
		/// <param name="mutationCount">On return, incremented by the number of inversions in the array.</param>
		/// <returns>A sorted array containing all input elements.</returns>
		private int[] SortAndCountInternal(int[] input, ref int mutationCount)
		{
			if (input.Length == 1)
			{
				return input;
			}

			int middle = input.Length / 2;
			int[] left = new int[middle];
			Array.Copy(input, left, middle);
			int[] right = new int[input.Length - middle];
			Array.Copy(input, middle, right, 0, input.Length - middle);

			// divide
			left = SortAndCountInternal(left, ref mutationCount);
			right = SortAndCountInternal(right, ref mutationCount);

			// conquer
			return Merge(left, right, ref mutationCount);
		}


		/// <summary>
		/// Merges two arrays into a sorted array.
		/// </summary>
		/// <param name="left">First array.</param>
		/// <param name="right">Second array.</param>
		/// <param name="inversionCount">On return, incremented by the number of inversions counted while merging.</param>
		/// <returns>The sorted array.</returns>
		private int[] Merge(int[] left, int[] right, ref int inversionCount)
		{
			int[] merged = new int[left.Length + right.Length];

			int i = 0, j = 0, k = 0;

			while (k < merged.Length)
			{
				if (j >= right.Length || (i < left.Length && left[i] <= right[j]))
				{
					merged[k++] = left[i++];
				}
				else
				{
					merged[k++] = right[j++];

					// all left-array elements not merged yet count as an inversion
					inversionCount += left.Length - i;
				}
			}

			return merged;
		}
	}
}
