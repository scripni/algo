using Algo.Heaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algo.Tests.Heap
{
    [TestClass]
    public class MaxHeapTests
    {
        [TestMethod]
        public void Add_SortedElements_ReturnsExpected()
        {
            // arrange
            MaxHeap heap = new MaxHeap(1000);

            // act
            heap.Add(3);
            heap.Add(2);
            heap.Add(1);

            // assert
            Assert.AreEqual(3, heap.Data.ElementAt(0));
            Assert.AreEqual(2, heap.Data.ElementAt(1));
            Assert.AreEqual(1, heap.Data.ElementAt(2));
        }


        [TestMethod]
        public void Add_ReverseSortedElements_ReturnsExpected()
        {
            // arrange
            MaxHeap heap = new MaxHeap(1000);

            // act
            heap.Add(1);
            heap.Add(2);
            heap.Add(3);

            // assert
            Assert.AreEqual(3, heap.Data.ElementAt(0));
            Assert.AreEqual(1, heap.Data.ElementAt(1));
            Assert.AreEqual(2, heap.Data.ElementAt(2));
        }


        [TestMethod]
        public void Add_RandomElements_LevelsSorted()
        {
            // arrange
            const int heapSize = 1000000;
            MaxHeap heap = new MaxHeap(heapSize);

            // act
            Random r = new Random(heapSize);
            for (int i = 0; i < heapSize; i++)
            {
                heap.Add(r.Next());
            }

            // assert
            ValidateSorting(heap);
        }

        [TestMethod]
        public void Remove_RemoveAllFromHead_EmptyHeap()
        {
            // arrange
            MaxHeap heap = new MaxHeap(1000);

            // act
            heap.Add(1);
            heap.Add(2);
            heap.Add(3);
            heap.RemoveAt(0);
            heap.RemoveAt(0);
            heap.RemoveAt(0);

            // assert
            Assert.AreEqual(0, heap.Size);
        }

        [TestMethod]
        public void Remove_RemoveAllFromTail_EmptyHeap()
        {
            // arrange
            MaxHeap heap = new MaxHeap(1000);

            // act
            heap.Add(3);
            heap.Add(2);
            heap.Add(1);
            heap.RemoveAt(2);
            heap.RemoveAt(1);
            heap.RemoveAt(0);

            // assert
            Assert.AreEqual(0, heap.Size);
        }

        [TestMethod]
        public void Remove_RandomElements_EmptyHeap()
        {
            // arrange
            const int heapSize = 1000000;
            MaxHeap heap = new MaxHeap(heapSize);

            // act
            Random r = new Random(heapSize);
            for (int i = 0; i < heapSize; i++)
            {
                heap.Add(r.Next());
            }

            int j = heapSize - 1;
            while (j >= 0)
            {
                heap.RemoveAt(0);
                j--;
            }

            // assert
            Assert.AreEqual(0, heap.Size);
        }

        [TestMethod]
        public void Remove_HalfRandomElements_HeapSorted()
        {
            // arrange
            const int heapSize = 10;
            MaxHeap heap = new MaxHeap(heapSize);

            // act
            Random r = new Random(heapSize);
            for (int i = 0; i < heapSize; i++)
            {
                heap.Add(r.Next() % 10);
            }

            int j = heapSize / 2;
            while (j >= 0)
            {
                heap.RemoveAt(0);
                j--;
            }

            // assert
            ValidateSorting(heap);
        }

        [TestMethod]
        public void LinearHeapFromArray_ValidArray_HeapSorted()
        {
            // arrange
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            // act
            MaxHeap heap = new MaxHeap(data);

            // assert
            ValidateSorting(heap);
        }

        [TestMethod]
        public void LinearHeapFromRandomArray_ValidArray_HeapSorted()
        {
            // arrange
            Random r = new Random(1000);
            int[] data = Enumerable.Range(0, 1000000).Select(_ => r.Next()).ToArray();

            // act
            MaxHeap heap = new MaxHeap(data);

            // assert
            ValidateSorting(heap);
        }

        /// <summary>
        /// Validates the sorting of a heap, ensuring each node's children are less than the parent.
        /// </summary>
        /// <param name="heap">The heap to validate.</param>
        private static void ValidateSorting(MaxHeap heap)
        {
            Queue<int> n = new Queue<int>();
            n.Enqueue(0);
            while (n.Count > 0)
            {
                int i = n.Dequeue();
                int left = i * 2 + 1;
                int right = i * 2 + 2;

                if (left < heap.Size)
                {
                    Assert.IsTrue(heap.Data[i] >= heap.Data[left]);
                    n.Enqueue(left);
                }

                if (right < heap.Size)
                {
                    Assert.IsTrue(heap.Data[i] >= heap.Data[right]);
                    n.Enqueue(right);
                }
            }
        }
    }
}
