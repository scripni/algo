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
            T sorter = new T();

            // act
            int[] actual = sorter.Sort(input);

            // assert
            Assert.IsTrue(actual.SequenceEqual(ExternalSort(input)), "Sequence [{0}] should be sorted.", string.Join(", ", actual));
        }


        [TestMethod]
        public void Sort_SortedInput_ReturnsExpected()
        {
            // arrange
            int[] input = { 1, 2, 3, 4, 5, 6, 7 };
            T sorter = new T();

            // act
            int[] actual = sorter.Sort(input);

            // assert
            Assert.IsTrue(actual.SequenceEqual(ExternalSort(input)), "Sequence [{0}] should be sorted.", string.Join(", ", actual));
        }


        [TestMethod]
        public void Sort_InputReverseSorted_ReturnsExpected()
        {
            // arrange
            int[] input = { 7, 6, 4, 2, 1 };
            T sorter = new T();

            // act
            int[] actual = sorter.Sort(input);

            // assert
            Assert.IsTrue(actual.SequenceEqual(ExternalSort(input)), "Sequence [{0}] should be sorted.", string.Join(", ", actual));
        }


        [TestMethod]
        public void Sort_InputLengthEven_ReturnsExpected()
        {
            // arrange
            int[] input = { 1, 2 };
            T sorter = new T();

            // act
            int[] actual = sorter.Sort(input);

            // assert
            Assert.IsTrue(actual.SequenceEqual(ExternalSort(input)), "Sequence [{0}] should be sorted.", string.Join(", ", actual));
        }


        [TestMethod]
        public void Sort_InputLengthOdd_ReturnsExpected()
        {
            // arrange
            int[] input = { 1, 2, 3 };
            T sorter = new T();

            // act
            int[] actual = sorter.Sort(input);

            // assert
            Assert.IsTrue(actual.SequenceEqual(ExternalSort(input)), "Sequence [{0}] should be sorted.", string.Join(", ", actual));
        }


        [TestMethod]
        public void Sort_InputRepeating_ReturnsExpected()
        {
            // arrange
            int[] input = { 1, 1, 1, 1, 1 };
            T sorter = new T();

            // act
            int[] actual = sorter.Sort(input);

            // assert
            Assert.IsTrue(actual.SequenceEqual(ExternalSort(input)), "Sequence [{0}] should be sorted.", string.Join(", ", actual));
        }


        [TestMethod]
        public void Sort_RandomInput_ReturnsExpected()
        {
            // arrange
            Random r = new Random(20150610);
            int[] evenInput = new int[100];
            int[] oddInput = new int[101];

            for (int i = 0; i < evenInput.Length; i++)
            {
                evenInput[i] = r.Next() % 1000;
            }

            for (int i = 0; i < oddInput.Length; i++)
            {
                oddInput[i] = r.Next() % 1000;
            }

            Sorter<int> sorter = new QuickSort();

            // act
            int[] evenOutput = sorter.Sort(evenInput);
            int[] oddOutput = sorter.Sort(oddInput);

            // assert
            Assert.IsTrue(evenOutput.SequenceEqual(ExternalSort(evenInput)), "Sequence [{0}] should be sorted.", string.Join(", ", evenOutput));
            Assert.IsTrue(oddOutput.SequenceEqual(ExternalSort(oddInput)), "Sequence [{0}] should be sorted.", string.Join(", ", oddOutput));
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
