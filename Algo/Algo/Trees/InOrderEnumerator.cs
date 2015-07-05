using System;
using System.Collections.Generic;

namespace Algo.Trees
{
    public class InOrderEnumerator
    {

        private readonly Stack<BinaryTreeNode> m_nodes;

        private BinaryTreeNode m_current;

        public InOrderEnumerator(BinaryTreeNode root)
        {
            m_current = root;
            m_nodes = new Stack<BinaryTreeNode>();
        }


        public BinaryTreeNode Next()
        {
            if (m_current == null && m_nodes.Count == 0)
                throw new InvalidOperationException();

            while (m_current != null)
            {
                m_nodes.Push(m_current);
                m_current = m_current.Left;
            }

            BinaryTreeNode returnValue = m_nodes.Pop();
            m_current = returnValue.Right;

            return returnValue;
        }


        public bool HasNext
        {
            get { return m_current != null || m_nodes.Count > 0; }
        }
    }
}
