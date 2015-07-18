using Algo.Arrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Algo.Tests.Arrays
{
    [TestClass]
    public class ArrayOperationTests
    {
        [TestMethod]
        public void FindZeroSum_ThreeNumbersAddingToZero_ReturnsValue()
        {
            // arrange
            int[] a = { 1, 2, -3 };
            int[] expected = { 0, 1, 2 };
            ArrayOperations ops = new ArrayOperations();

            // act
            int[] actual = ops.FindZeroSum(a);
            Array.Sort(actual);

            // assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }


        [TestMethod]
        public void FindZeroSum_ThreeNumbersNotAddingToZero_ReturnsValue()
        {
            // arrange
            int[] a = { 1, 2, 3 };
            ArrayOperations ops = new ArrayOperations();

            // act
            int[] actual = ops.FindZeroSum(a);

            // assert
            Assert.IsNull(actual);
        }


        [TestMethod]
        public void FindZeroSum_LargeArrayThreeAddingToZero_ReturnsValue()
        {
            // arrange
            int[] a = { 4, 3, 6, 9, 1, 5, -3, 123, 2, 439 };
            int[] expected = { 4, 6, 8 };
            ArrayOperations ops = new ArrayOperations();

            // act
            int[] actual = ops.FindZeroSum(a);
            Array.Sort(actual);

            // assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }


        [TestMethod]
        public void SortByCategory_ValidArray_ReturnsValue()
        {
            // arrange
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ArrayOperations ops = new ArrayOperations();

            // act
            ops.SortByCategory(a);

            // assert
            int c = 0;
            for (int i = 0; i < a.Length; i++)
            {
                int x = a[i];
                if (a[i] % 3 != c)
                {
                    c++;
                }
            }

            Assert.AreEqual(2, c);
        }


        [TestMethod]
        public void KadaneLargestSubarray_ValidValue_ReturnsExpected()
        {
            // arrange
            int[] value = { -1, -2, 3, 4, -5, 6 };
            ArrayOperations ops = new ArrayOperations();

            // act
            SubarraySum actual = ops.KadaneLargestSubarray(value);

            // assert
            Assert.AreEqual(2, actual.From);
            Assert.AreEqual(5, actual.To);
            Assert.AreEqual(8, actual.Sum);
        }
    }
}
