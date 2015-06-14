using Algo.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests.Sorting
{
	[TestClass]
	public class MergeSortTests : SorterTests<MergeSort<int>>
	{
		[TestMethod]
		public void CountInversions_OnlySplitInversions_ReturnsExpected()
		{
			// arrange
			int[] input = { 1, 3, 5, 2, 4, 6 };
			int expectedInversions = 3;
			MergeSort<int> sort = new MergeSort<int>();

			// act
			int actualInversions = sort.CountInversions(input);

			// assert
			Assert.AreEqual(expectedInversions, actualInversions, "Inversion count should match.");
		}


		[TestMethod]
		public void CountInversions_InvertedArray_ReturnsMax()
		{
			// arrange
			int[] input = { 7, 6, 5, 4, 3, 2, 1 };
			int expectedInversions = input.Length * (input.Length - 1) / 2;
			MergeSort<int> sort = new MergeSort<int>();

			// act
			int actualInversions = sort.CountInversions(input);

			// assert
			Assert.AreEqual(expectedInversions, actualInversions, "Inversion count should match.");
		}


		[TestMethod]
		public void CountInversions_SortedArray_ReturnsMin()
		{
			// arrange
			int[] input = { 1, 2, 3, 4, 5, 6, 7, 8 };
			MergeSort<int> sort = new MergeSort<int>();

			// act
			int actualInversions = sort.CountInversions(input);

			// assert
			Assert.AreEqual(0, actualInversions, "No inversions expected.");
		}


		[TestMethod]
		public void CountInversions_LeftAndRightInversions_ReturnsExpected()
		{
			// arrange
			int[] input = { 2, 1, 4, 3 };
			int expectedInversions = 2;
			MergeSort<int> sort = new MergeSort<int>();

			// act
			int actualInversions = sort.CountInversions(input);

			// assert
			Assert.AreEqual(expectedInversions, actualInversions, "Inversion count should match.");
		}
	}
}
