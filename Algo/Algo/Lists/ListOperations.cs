using Algo.Trees;
using System.Collections.Generic;

namespace Algo.Lists
{
    public class ListOperations
    {
        public LinkedList<T> ReverseLinkedList<T>(LinkedList<T> list)
        {
            Stack<LinkedListNode<T>> s = new Stack<LinkedListNode<T>>();
            LinkedListNode<T> n = list.First;
            while (n != null)
            {
                s.Push(n);
                n = n.Next;
            }

            LinkedList<T> result = new LinkedList<T>();
            while (s.Count > 0)
            {
                result.AddLast(s.Pop());
            }

            return result;
        }


        public LinkedListNode ConvertTree(BinaryTreeNode n)
        {
            // level order
            Queue<BinaryTreeNode> nodes = new Queue<BinaryTreeNode>();
            nodes.Enqueue(n);

            LinkedListNode previous = null;
            LinkedListNode first = null;
            LinkedListNode current = null;

            while (nodes.Count > 0)
            {
                BinaryTreeNode currentTreeNode = nodes.Dequeue();

                current = new LinkedListNode();
                current.Value = currentTreeNode.Value;
                if (previous != null)
                {
                    current.Previous = previous;
                    previous.Next = current;
                }

                if (first == null)
                {
                    first = current;
                }

                previous = current;

                if (currentTreeNode.Left != null)
                {
                    nodes.Enqueue(currentTreeNode.Left);
                }

                if (currentTreeNode.Right != null)
                {
                    nodes.Enqueue(currentTreeNode.Right);
                }
            }

            first.Previous = current;
            current.Next = first;

            return first;
        }

        public class LinkedListNode
        {
            public string Value;

            public LinkedListNode Previous;
            public LinkedListNode Next;
        }
    }
}
