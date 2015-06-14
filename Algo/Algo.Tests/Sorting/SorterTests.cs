using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algo.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests.Sorting
{
	[TestClass]
	public abstract class SorterTests<T> where T : Sorter<int>, new()
	{
		[TestMethod]
		public void Sort_ValidInput_ReturnsExpected()
		{
			// arrange
			int[] input = { 1, 2, 3, 2, 1 };
			int[] expected = ExternalSort(input);
			T sorter = new T();

			// act
			int[] actual = sorter.Sort(input);

			// assert
			Assert.IsTrue(actual.SequenceEqual(expected));
		}


		[TestMethod]
		public void MergeSort_SortedInput_ReturnsExpected()
		{
			// arrange
			int[] input = { 1, 2, 3, 4, 5, 6, 7 };
			int[] expected = ExternalSort(input);
			T sorter = new T();

			// act
			int[] actual = sorter.Sort(input);

			// assert
			Assert.IsTrue(actual.SequenceEqual(expected));
		}


		[TestMethod]
		public void MergeSort_InputReverseSorted_ReturnsExpected()
		{
			// arrange
			int[] input = { 7, 6, 4, 2, 1 };
			int[] expected = ExternalSort(input);
			T sorter = new T();

			// act
			int[] actual = sorter.Sort(input);

			// assert
			Assert.IsTrue(actual.SequenceEqual(expected));
		}


		[TestMethod]
		public void MergeSort_InputLengthEven_ReturnsExpected()
		{
			// arrange
			int[] input = { 1, 2 };
			int[] expected = ExternalSort(input);
			T sorter = new T();

			// act
			int[] actual = sorter.Sort(input);

			// assert
			Assert.IsTrue(actual.SequenceEqual(expected));
		}


		[TestMethod]
		public void MergeSort_InputLengthOdd_ReturnsExpected()
		{
			// arrange
			int[] input = { 1, 2, 3 };
			int[] expected = ExternalSort(input);
			T sorter = new T();

			// act
			int[] actual = sorter.Sort(input);

			// assert
			Assert.IsTrue(actual.SequenceEqual(expected));
		}


		[TestMethod]
		public void MergeSort_InputRepeating_ReturnsExpected()
		{
			// arrange
			int[] input = { 1, 1, 1, 1, 1 };
			int[] expected = ExternalSort(input);
			T sorter = new T();

			// act
			int[] actual = sorter.Sort(input);

			// assert
			Assert.IsTrue(actual.SequenceEqual(expected));
		}


		/// <summary>
		/// Sorts an array using a standard library sorter.
		/// </summary>
		/// <param name="input">Input array.</param>
		/// <returns>Sorted array containing input elements.</returns>
		protected int[] ExternalSort(int[] input)
		{
			int[] expected = input.ToArray();
			Array.Sort(expected);
			return expected;
		}
	}
}
