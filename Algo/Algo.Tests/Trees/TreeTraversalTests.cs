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
            BinaryTreeNode[] levelFirst = traversal.LevelOrder(root).ToArray();

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


        [TestMethod]
        public void InOrderTraversal_ValidTree_CorrectSequence()
        {
            // arrange
            BinaryTreeNode root = new BinaryTreeNode("0-root");
            root.Left = new BinaryTreeNode("1-left");
            root.Right = new BinaryTreeNode("1-right");
            root.Left.Left = new BinaryTreeNode("2-left-left");
            root.Left.Right = new BinaryTreeNode("2-left-right");
            root.Right.Left = new BinaryTreeNode("2-right-left");
            root.Right.Right = new BinaryTreeNode("2-right-right");
            root.Right.Right.Left = new BinaryTreeNode("3-right-right-left");
            root.Right.Right.Left.Right = new BinaryTreeNode("4-right-right-left-right");
            TreeTraversal traversal = new TreeTraversal();

            // act
            BinaryTreeNode[] levelFirst = traversal.InOrder(root).ToArray();

            // assert
            Assert.AreEqual(levelFirst[0].Value, "2-left-left");
            Assert.AreEqual(levelFirst[1].Value, "1-left");
            Assert.AreEqual(levelFirst[2].Value, "2-left-right");
            Assert.AreEqual(levelFirst[3].Value, "0-root");
            Assert.AreEqual(levelFirst[4].Value, "2-right-left");
            Assert.AreEqual(levelFirst[5].Value, "1-right");
            Assert.AreEqual(levelFirst[6].Value, "3-right-right-left");
            Assert.AreEqual(levelFirst[7].Value, "4-right-right-left-right");
            Assert.AreEqual(levelFirst[8].Value, "2-right-right");
        }


        [TestMethod]
        public void PreOrderTraversal_ValidTree_CorrectSequence()
        {
            // arrange
            BinaryTreeNode root = new BinaryTreeNode("0-root");
            root.Left = new BinaryTreeNode("1-left");
            root.Right = new BinaryTreeNode("1-right");
            root.Left.Left = new BinaryTreeNode("2-left-left");
            root.Left.Right = new BinaryTreeNode("2-left-right");
            root.Right.Left = new BinaryTreeNode("2-right-left");
            root.Right.Right = new BinaryTreeNode("2-right-right");
            root.Right.Right.Left = new BinaryTreeNode("3-right-right-left");
            root.Right.Right.Left.Right = new BinaryTreeNode("4-right-right-left-right");
            TreeTraversal traversal = new TreeTraversal();

            // act
            BinaryTreeNode[] levelFirst = traversal.PreOrder(root).ToArray();

            // assert
            Assert.AreEqual(levelFirst[0].Value, "0-root");
            Assert.AreEqual(levelFirst[1].Value, "1-left");
            Assert.AreEqual(levelFirst[2].Value, "2-left-left");
            Assert.AreEqual(levelFirst[3].Value, "2-left-right");
            Assert.AreEqual(levelFirst[4].Value, "1-right");
            Assert.AreEqual(levelFirst[5].Value, "2-right-left");
            Assert.AreEqual(levelFirst[6].Value, "2-right-right");
            Assert.AreEqual(levelFirst[7].Value, "3-right-right-left");
            Assert.AreEqual(levelFirst[8].Value, "4-right-right-left-right");
        }


        [TestMethod]
        public void PostOrderTraversal_ValidTree_CorrectSequence()
        {
            // arrange
            BinaryTreeNode root = new BinaryTreeNode("0-root");
            root.Left = new BinaryTreeNode("1-left");
            root.Right = new BinaryTreeNode("1-right");
            root.Left.Left = new BinaryTreeNode("2-left-left");
            root.Left.Right = new BinaryTreeNode("2-left-right");
            root.Right.Left = new BinaryTreeNode("2-right-left");
            root.Right.Right = new BinaryTreeNode("2-right-right");
            root.Right.Right.Left = new BinaryTreeNode("3-right-right-left");
            root.Right.Right.Left.Right = new BinaryTreeNode("4-right-right-left-right");
            TreeTraversal traversal = new TreeTraversal();

            // act
            BinaryTreeNode[] levelFirst = traversal.PostOrder(root).ToArray();

            // assert
            Assert.AreEqual(levelFirst[0].Value, "2-left-left");
            Assert.AreEqual(levelFirst[1].Value, "2-left-right");
            Assert.AreEqual(levelFirst[2].Value, "1-left");
            Assert.AreEqual(levelFirst[3].Value, "2-right-left");
            Assert.AreEqual(levelFirst[4].Value, "4-right-right-left-right");
            Assert.AreEqual(levelFirst[5].Value, "3-right-right-left");
            Assert.AreEqual(levelFirst[6].Value, "2-right-right");
            Assert.AreEqual(levelFirst[7].Value, "1-right");
            Assert.AreEqual(levelFirst[8].Value, "0-root");
        }


        [TestMethod]
        public void SameFringe_IdenticalTrees_ReturnsTrue()
        {
            // arrange
            BinaryTreeNode a = new BinaryTreeNode("0-root");
            a.Left = new BinaryTreeNode("1-left");
            a.Right = new BinaryTreeNode("1-right");

            BinaryTreeNode b = new BinaryTreeNode("0-root2");
            b.Left = new BinaryTreeNode("1-left");
            b.Right = new BinaryTreeNode("1-right");

            TreeTraversal traversal = new TreeTraversal();

            // act
            // assert
            Assert.IsTrue(traversal.SameFringe(a, b));
        }


        [TestMethod]
        public void SameFringe_IdenticalLeaves_ReturnsTrue()
        {
            // arrange
            BinaryTreeNode a = new BinaryTreeNode("0-root");
            a.Left = new BinaryTreeNode("1-left");
            a.Right = new BinaryTreeNode("1-right");

            BinaryTreeNode b = new BinaryTreeNode("0-root2");
            b.Left = new BinaryTreeNode("1-leftdd");
            b.Left.Left = new BinaryTreeNode("1-left");
            b.Right = new BinaryTreeNode("1-right");

            TreeTraversal traversal = new TreeTraversal();

            // act
            // assert
            Assert.IsTrue(traversal.SameFringe(a, b));
        }


        [TestMethod]
        public void SameFringe_DifferentLeaves_ReturnsFalse()
        {
            // arrange
            BinaryTreeNode a = new BinaryTreeNode("0-root");
            a.Left = new BinaryTreeNode("1-left");
            a.Right = new BinaryTreeNode("1-right");

            BinaryTreeNode b = new BinaryTreeNode("0-root2");
            b.Left = new BinaryTreeNode("1-leftdd");
            b.Right = new BinaryTreeNode("1-right");

            TreeTraversal traversal = new TreeTraversal();

            // act
            // assert
            Assert.IsFalse(traversal.SameFringe(a, b));
        }
    }
}
