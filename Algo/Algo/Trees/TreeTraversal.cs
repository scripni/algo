using System.Collections.Generic;
using System.Linq;

namespace Algo.Trees
{
    public class TreeTraversal
    {
        public IEnumerable<BinaryTreeNode> LevelOrder(BinaryTreeNode root)
        {
            Queue<BinaryTreeNode> nodes = new Queue<BinaryTreeNode>();
            nodes.Enqueue(root);

            while (nodes.Count > 0)
            {
                BinaryTreeNode node = nodes.Dequeue();

                if (node.Left != null)
                {
                    nodes.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    nodes.Enqueue(node.Right);
                }

                yield return node;
            }
        }


        public IEnumerable<BinaryTreeNode> InOrder(BinaryTreeNode node)
        {
            if (node == null) { return Enumerable.Empty<BinaryTreeNode>(); }
            return InOrder(node.Left)
                .Union(new[] { node })
                .Union(InOrder(node.Right));

            // non-recursive
            //Stack<BinaryTreeNode> nodes = new Stack<BinaryTreeNode>();
            //BinaryTreeNode current = node;

            //while (nodes.Count > 0 || current != null)
            //{
            //    while (current != null)
            //    {
            //        nodes.Push(current);
            //        current = current.Left;
            //    }

            //    yield return nodes.Peek();

            //    current = nodes.Pop().Right;
            //}
        }


        public IEnumerable<BinaryTreeNode> PreOrder(BinaryTreeNode node)
        {
            if (node == null) { return Enumerable.Empty<BinaryTreeNode>(); }

            return new[] { node }
                .Union(PreOrder(node.Left))
                .Union(PreOrder(node.Right));

            // non-recursive
            //Stack<BinaryTreeNode> nodes = new Stack<BinaryTreeNode>();
            //nodes.Push(node);
            //while (nodes.Count > 0)
            //{
            //    BinaryTreeNode current = nodes.Pop();
            //    yield return current;
            //    if (current.Right != null)
            //    {
            //        nodes.Push(current.Right);
            //    }

            //    if (current.Left != null)
            //    {
            //        nodes.Push(current.Left);
            //    }
            //}
        }


        public IEnumerable<BinaryTreeNode> PostOrder(BinaryTreeNode node)
        {
            if (node == null) { return Enumerable.Empty<BinaryTreeNode>(); }

            return PostOrder(node.Left).Union(PostOrder(node.Right)).Union(new[] { node });

            // non-recursive
            //Stack<BinaryTreeNode> nodes = new Stack<BinaryTreeNode>();
            //nodes.Push(node);
            //BinaryTreeNode previous = null;
            //while (nodes.Count > 0)
            //{
            //    BinaryTreeNode current = nodes.Peek();

            //    // travel down
            //    if (previous == null || previous.Left == current || previous.Right == current)
            //    {
            //        if (current.Left != null)
            //        {
            //            nodes.Push(current.Left);
            //        }
            //        else if (current.Right != null)
            //        {
            //            nodes.Push(current.Right);
            //        }
            //        else
            //        {
            //            yield return nodes.Pop();
            //        }
            //    }
            //    // travel up from the left
            //    else if (current.Left == previous)
            //    {
            //        if (current.Right != null)
            //        {
            //            nodes.Push(current.Right);
            //        }
            //        else
            //        {
            //            yield return nodes.Pop();
            //        }
            //    }
            //    // travel up from the right
            //    else if (current.Right == previous)
            //    {
            //        yield return nodes.Pop();
            //    }

            //    previous = current;
            //}
        }
    }
}
