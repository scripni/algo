using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Trees
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode(string value)
        {
            Value = value;
        }

        public BinaryTreeNode Left { get; set; }

        public BinaryTreeNode Right { get; set; }

        public string Value { get; private set; }
    }
}
