using System;

namespace Algo.Heaps
{
    public class MaxHeap
    {
        private int[] m_data;
        private int m_tail = -1;

        public MaxHeap(int maxElements)
        {
            m_data = new int[maxElements];
        }

        public MaxHeap(int[] initial)
        {
            m_data = initial;
            m_tail = initial.Length - 1;
            for (int i = m_data.Length / 2 + 1; i >= 0; i--)
            {
                MaxHeapify(i);
            }
        }


        public int[] Data
        {
            get { return m_data; }
        }

        public void Add(int value)
        {
            if (m_tail + 1 >= m_data.Length)
            {
                throw new InvalidOperationException("Heap is at capacity. Cannot insert more elements.");
            }

            m_tail++;
            m_data[m_tail] = value;
            Bubble(m_tail);
        }

        public int Size
        {
            get
            {
                return m_tail + 1;
            }
        }


        public void RemoveAt(int index)
        {
            if (index > m_tail)
            {
                throw new IndexOutOfRangeException(
                    string.Format("Cannot remove element at index '{0}', heap has '{1}' total elements.", index, m_tail));
            }

            if (index != m_tail)
            {
                m_data[m_tail] ^= m_data[index];
                m_data[index] ^= m_data[m_tail];
                m_data[m_tail] ^= m_data[index];

            }

            m_tail--;
            MaxHeapify(index);
        }


        private void MaxHeapify(int i)
        {
            int left = i * 2 + 1;
            int right = i * 2 + 2;

            if (left > m_tail)
            {
                return;
            }

            if (m_data[i] < m_data[left])
            {
                if (right > m_tail)
                {
                    m_data[left] ^= m_data[i];
                    m_data[i] ^= m_data[left];
                    m_data[left] ^= m_data[i];
                    return;
                }

                if (m_data[left] > m_data[right])
                {
                    m_data[left] ^= m_data[i];
                    m_data[i] ^= m_data[left];
                    m_data[left] ^= m_data[i];
                    MaxHeapify(left);
                }
                else
                {
                    m_data[right] ^= m_data[i];
                    m_data[i] ^= m_data[right];
                    m_data[right] ^= m_data[i];
                    MaxHeapify(right);
                }
            }
            else if (right < m_tail && m_data[i] < m_data[right])
            {
                m_data[right] ^= m_data[i];
                m_data[i] ^= m_data[right];
                m_data[right] ^= m_data[i];
                MaxHeapify(right);
            }
        }

        private void Bubble(int i)
        {
            if (i == 0) return;
            int parent = (i - 1) / 2;
            if (m_data[i] > m_data[parent])
            {
                m_data[i] ^= m_data[parent];
                m_data[parent] ^= m_data[i];
                m_data[i] ^= m_data[parent];
                Bubble(parent);
            }
        }
    }
}
