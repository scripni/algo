using System.Collections.Generic;

namespace Algo.TopCoder.Medium
{
    public class BrokenElevator
    {
        public int wayTime(string[] plan)
        {
            int[] start = new int[2];
            int[] end = new int[2];

            for (int floor = 0; floor < plan.Length; floor += 2)
            {
                for (int square = 0; square < plan[floor].Length; square++)
                {
                    if (plan[floor][square] == 'S')
                    {
                        start[Floor] = floor;
                        start[Square] = square;
                    }

                    if (plan[floor][square] == 'F')
                    {
                        end[Floor] = floor;
                        end[Square] = square;
                    }
                }
            }

            int[,] distances = new int[plan.Length, plan[0].Length];

            int minDistance = int.MaxValue;
            HeapNode root = new HeapNode(start[Floor], start[Square]);
            MinHeap heap = new MinHeap(root, distances);
            while (heap.HasItems)
            {
                HeapNode node = heap.Top();

                foreach (HeapNode move in getValidMoves(plan, node, distances))
                {
                    if (plan[move.Floor][move.Square] == '#')
                    {
                        heap.Add(move);
                    }
                    else if (plan[move.Floor][move.Square] == 'F' && minDistance > distances[move.Floor, move.Square])
                    {
                        minDistance = distances[move.Floor, move.Square];
                    }
                }
            }

            return minDistance;
        }

        private IEnumerable<HeapNode> getValidMoves(string[] plan, HeapNode node, int[,] distances)
        {
            int left = node.Square - 1;
            int right = node.Square + 1;
            int up = node.Floor - 2;
            int down = node.Floor + 2;

            // left
            if (left >= 0 && (plan[node.Floor][left] == '#' || plan[node.Floor][left] == 'F') && distances[node.Floor, node.Square] + 2 < distances[node.Floor, left])
            {
                distances[node.Floor, left] = distances[node.Floor, node.Square] + 2;
                yield return new HeapNode(node.Floor, left);
            }

            // right
            if (right < plan[node.Floor].Length && (plan[node.Floor][right] == '#' || plan[node.Floor][right] == 'F') && distances[node.Floor, node.Square] + 2 < distances[node.Floor, right])
            {
                distances[node.Floor, right] = distances[node.Floor, node.Square] + 2;
                yield return new HeapNode(node.Floor, right);
            }

            // up
            if (up < plan.Length && (plan[up][node.Square] == '#' || plan[up][node.Square] == 'F') && plan[up - 1][node.Square] == '|' && distances[up, node.Square] + 3 < distances[up, node.Square])
            {
                distances[up, node.Square] = distances[node.Floor, node.Square] + 3;
                yield return new HeapNode(up, node.Square);
            }

            // down
            if (down > 0 && (plan[down][node.Square] == '#' || plan[down][node.Square] == 'F') && plan[down - 1][node.Square] == '|' && distances[down, node.Square] + 1 < distances[down, node.Square])
            {
                distances[down, node.Square] = distances[node.Floor, node.Square] + 1;
                yield return new HeapNode(down, node.Square);
            }
        }

        private const int Floor = 0;
        private const int Square = 0;
    }

    public class MinHeap
    {
        private HeapNode[] m_data;

        private int m_tail = -1;

        private readonly int[,] m_distances;

        public MinHeap(HeapNode root, int[,] distances)
        {
            m_data = new HeapNode[1000000];
            m_data[0] = root;
            m_tail = 0;
            m_distances = distances;
        }

        public bool HasItems
        {
            get
            {
                return m_tail >= 0;
            }
        }

        public void Add(HeapNode n)
        {
            m_tail++;
            m_data[m_tail] = n;
            Bubble(m_tail);
        }

        private void Bubble(int n)
        {
            if (n == 0) return;

            HeapNode node = m_data[n];
            HeapNode parent = m_data[(n - 1) / 2];

            if (m_distances[parent.Floor, parent.Square] > m_distances[node.Floor, node.Square])
            {
                m_data[n] = parent;
                m_data[(n - 1) / 2] = node;
                Bubble((n - 1) / 2);
            }
        }

        public HeapNode Top()
        {
            HeapNode top = m_data[0];
            m_data[0] = m_data[m_tail];
            m_data[m_tail--] = null;
            MinHeapify(0);

            return top;
        }

        private void MinHeapify(int n)
        {
            if (n >= m_tail)
            {
                return;
            }

            HeapNode node = m_data[n];
            HeapNode left = m_data[n * 2 + 1];
            HeapNode right = m_data[n * 2 + 2];

            if (left != null && m_distances[node.Floor, node.Square] > m_distances[left.Floor, left.Square])
            {
                m_data[n] = left;
                m_data[n * 2 + 1] = node;
                MinHeapify(n * 2 + 1);
            }
            else if (right != null && m_distances[node.Floor, node.Square] > m_distances[right.Floor, right.Square])
            {
                m_data[n] = right;
                m_data[n * 2 + 2] = node;
                MinHeapify(n * 2 + 2);
            }
        }
    }

    public class HeapNode
    {
        public HeapNode(int floor, int square)
        {
            Floor = floor;
            Square = square;
        }

        public readonly int Floor;

        public readonly int Square;
    }
}
