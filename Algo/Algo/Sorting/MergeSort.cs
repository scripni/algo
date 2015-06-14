using System;

namespace Algo.Sorting
{
	/// <summary>
	/// Merge sort.
	/// </summary>
	public class MergeSort<T> : Sorter<T> where T : IComparable<T>
	{
		/// <summary>
		/// Sorts an input array using merge sort.
		/// </summary>
		/// <param name="input">The input array.</param>
		/// <returns>A sorted array containing the input elements.</returns>
		public override T[] Sort(T[] input)
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
		public int CountInversions(T[] input)
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
		/// <param name="inversionCount">On return, incremented by the number of inversions in the array.</param>
		/// <returns>A sorted array containing all input elements.</returns>
		private T[] SortAndCountInternal(T[] input, ref int inversionCount)
		{
			if (input.Length == 1)
			{
				return input;
			}

			// divide
			int middle = input.Length / 2;
			T[] left = new T[middle];
			Array.Copy(input, left, middle);
			T[] right = new T[input.Length - middle];
			Array.Copy(input, middle, right, 0, input.Length - middle);

			// conquer
			left = SortAndCountInternal(left, ref inversionCount);
			right = SortAndCountInternal(right, ref inversionCount);

			// combine
			return Merge(left, right, ref inversionCount);
		}


		/// <summary>
		/// Merges two arrays into a sorted array.
		/// </summary>
		/// <param name="left">First array.</param>
		/// <param name="right">Second array.</param>
		/// <param name="inversionCount">On return, incremented by the number of inversions counted while merging.</param>
		/// <returns>The sorted array.</returns>
		private T[] Merge(T[] left, T[] right, ref int inversionCount)
		{
			T[] merged = new T[left.Length + right.Length];

			int i = 0, j = 0, k = 0;

			while (k < merged.Length)
			{
				if (j >= right.Length || (i < left.Length && left[i].CompareTo(right[j]) <= 0))
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
