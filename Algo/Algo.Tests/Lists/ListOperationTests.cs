using Algo.Lists;
using Algo.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests.Lists
{
    [TestClass]
    public class ListOperationTests
    {
        [TestMethod]
        public void ConvertTree_ValidTree_ConvertsToCircularLinkedList()
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
            ListOperations ops = new ListOperations();

            // act
            ListOperations.LinkedListNode actual = ops.ConvertTree(root);

            // assert
            Assert.AreEqual(root.Value, actual.Value);
            Assert.AreEqual(root.Left.Value, actual.Next.Value);
            Assert.AreEqual(root.Right.Value, actual.Next.Next.Value);
            Assert.AreEqual(root.Left.Left.Value, actual.Next.Next.Next.Value);
            Assert.AreEqual(root.Left.Right.Value, actual.Next.Next.Next.Next.Value);
            Assert.AreEqual(root.Right.Left.Value, actual.Next.Next.Next.Next.Next.Value);
            Assert.AreEqual(root.Right.Right.Value, actual.Next.Next.Next.Next.Next.Next.Value);
            Assert.AreEqual(root.Right.Right.Left.Value, actual.Next.Next.Next.Next.Next.Next.Next.Value);
            Assert.AreEqual(root.Right.Right.Left.Right.Value, actual.Next.Next.Next.Next.Next.Next.Next.Next.Value);
            Assert.AreEqual(actual, actual.Next.Next.Next.Next.Next.Next.Next.Next.Next);
        }
    }
}
