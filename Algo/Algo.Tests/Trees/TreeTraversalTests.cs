using Algo.Trees;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace Algo.Tests.Trees
{
    [TestClass]
    public class TreeTraversalTests
    {
        [TestMethod]
        public void LevelFirstTraversal_ValidTree_CorrectSequence()
        {
            // arrange
            BinaryTreeNode root = new BinaryTreeNode("0-root");
            root.Left = new BinaryTreeNode("1-left");
            root.Right = new BinaryTreeNode("1-right");
            root.Left.Left = new BinaryTreeNode("2-left-left");
            root.Left.Right = new BinaryTreeNode("2-left-right");
            root.Right.Left = new BinaryTreeNode("2-right-left");
            root.Right.Right = new BinaryTreeNode("2-right-right");
            root.Right.Right.Left = new BinaryTreeNode("3-right-right");
            root.Right.Right.Left.Right = new BinaryTreeNode("4-right-right");
            TreeTraversal traversal = new TreeTraversal();

            // act
            BinaryTreeNode[] levelFirst = traversal.LevelFirstTraversal(root).ToArray();

            // assert
            Assert.AreEqual(levelFirst[0].Value[0], '0');
            Assert.AreEqual(levelFirst[1].Value[0], '1');
            Assert.AreEqual(levelFirst[2].Value[0], '1');
            Assert.AreEqual(levelFirst[3].Value[0], '2');
            Assert.AreEqual(levelFirst[4].Value[0], '2');
            Assert.AreEqual(levelFirst[5].Value[0], '2');
            Assert.AreEqual(levelFirst[6].Value[0], '2');
            Assert.AreEqual(levelFirst[7].Value[0], '3');
            Assert.AreEqual(levelFirst[8].Value[0], '4');
        }
    }
}
