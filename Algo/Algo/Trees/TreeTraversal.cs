using System.Collections.Generic;

namespace Algo.Trees
{
    public class TreeTraversal
    {
        public IEnumerable<BinaryTreeNode> LevelFirstTraversal(BinaryTreeNode root)
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
    }
}
