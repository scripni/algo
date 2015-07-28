using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Algo.Graphs
{
    public class DijkstraShortestPath
    {
        /// <summary>
        /// Graph vertices.
        /// </summary>
        private readonly HashSet<int> m_v;


        /// <summary>
        /// Graph edges.
        /// </summary>
        private readonly Dictionary<int, Dictionary<int, double>> m_e;


        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="v">Graph vertices.</param>
        /// <param name="e">Graph edges.</param>
        public DijkstraShortestPath(HashSet<int> v, Dictionary<int, Dictionary<int, double>> e)
        {
            m_v = v;
            m_e = e;
        }


        /// <summary>
        /// Computes the shortest path between two nodes.
        /// </summary>
        /// <param name="from">Source node.</param>
        /// <param name="to">Destination node.</param>
        /// <returns>Path letngth.</returns>
        public double ShortestPath(int from, int to)
        {
            if (!m_v.Contains(from))
            {
                throw new ArgumentOutOfRangeException("from",
                    string.Format(CultureInfo.InvariantCulture, "Node '{0}' does not exist.", from));
            }

            if (!m_v.Contains(to))
            {
                throw new ArgumentOutOfRangeException("to",
                    string.Format(CultureInfo.InvariantCulture, "Node '{0}' does not exist.", to));
            }

            MinHeap<Destination> heap = new MinHeap<Destination>(m_v.Count);

            Dictionary<int, double> minDistances = m_v.ToDictionary(v => v, _ => double.MaxValue);

            heap.Add(new Destination(from, 0));

            while (heap.HasItems)
            {
                Destination min = heap.RemoveMin();
                minDistances[min.To] = Math.Min(min.TravelTime, minDistances[min.To]);

                foreach (KeyValuePair<int, double> path in m_e[min.To])
                {
                    Destination d = new Destination(path.Key, path.Value + minDistances[min.To]);
                    if (d.TravelTime < minDistances[d.To])
                    {
                        heap.Add(d);
                    }
                }
            }

            return minDistances[to];
        }
    }

    public class Destination : IComparable<Destination>, IEquatable<Destination>
    {
        public readonly double TravelTime;
        public readonly int To;

        public Destination(int to, double travelTime)
        {
            TravelTime = travelTime;
            To = to;
        }

        public int CompareTo(Destination r)
        {
            return TravelTime.CompareTo(r.TravelTime);
        }

        public bool Equals(Destination d)
        {
            return d.To == To;
        }

        public override bool Equals(object o)
        {
            return Equals(o as Destination);
        }

        public override int GetHashCode()
        {
            return To.GetHashCode();
        }
    }

    public class MinHeap<T>
        where T : IComparable<T>
    {
        private readonly T[] m_nodes;
        private readonly Dictionary<T, int> m_nodeIndices;

        private int m_tail;

        public MinHeap(int capacity)
        {
            m_nodes = new T[capacity];
            m_tail = -1;
            m_nodeIndices = new Dictionary<T, int>();
        }

        public bool HasItems
        {
            get
            {
                return m_tail >= 0;
            }
        }

        public void Add(T value)
        {
            if (!m_nodeIndices.ContainsKey(value))
            {
                m_nodes[++m_tail] = value;
                m_nodeIndices[value] = m_tail;
                Bubble(m_tail);
            }
            else
            {
                DecreaseKey(value);
            }
        }

        public T RemoveMin()
        {
            if (!HasItems)
            {
                throw new InvalidOperationException("No items to remove.");
            }

            T min = m_nodes[0];
            Swap(0, m_tail--);
            MinHeapify(0);
            m_nodeIndices.Remove(min);

            return min;
        }

        private void DecreaseKey(T value)
        {
            if (value.CompareTo(m_nodes[m_nodeIndices[value]]) == 0)
            {
                return;
            }

            m_nodes[m_nodeIndices[value]] = value;
            Bubble(m_nodeIndices[value]);
        }

        private void Bubble(int i)
        {
            if (i <= 0) return;

            int parent = (i - 1) / 2;
            if (m_nodes[i].CompareTo(m_nodes[parent]) < 0)
            {
                Swap(i, parent);
                Bubble(parent);
            }
        }

        private void MinHeapify(int index)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;

            if (left > m_tail) return;

            if (m_nodes[index].CompareTo(m_nodes[left]) > 0)
            {
                if (right > m_tail || m_nodes[right].CompareTo(m_nodes[left]) > 0)
                {
                    Swap(index, left);
                    MinHeapify(left);
                }
                else
                {
                    Swap(index, right);
                    MinHeapify(right);
                }
            }
            else
            {
                Swap(index, left);
                MinHeapify(left);
            }
        }

        private void Swap(int i, int j)
        {
            T temp = m_nodes[i];
            m_nodes[i] = m_nodes[j];
            m_nodes[j] = temp;

            m_nodeIndices[m_nodes[i]] = i;
            m_nodeIndices[m_nodes[j]] = j;
        }
    }
}
