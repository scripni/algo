using Algo.Heaps;

namespace Algo.Sorting
{
    public class HeapSort : Sorter<int>
    {
        public override int[] Sort(int[] input)
        {
            MaxHeap heap = new MaxHeap(input);
            while (heap.Size > 0)
            {
                heap.RemoveAt(0);
            }

            return heap.Data;
        }
    }
}
