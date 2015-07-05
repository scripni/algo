using Algo.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Tests.Trees
{
    [TestClass]
    public class InOrderEnumeratorTests
    {
        [TestMethod]
        public void Next_ValidValues_ReturnsCorrectSequence()
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
            InOrderEnumerator enumerator = new InOrderEnumerator(root);

            // act
            // assert
            Assert.AreEqual(enumerator.Next().Value, "2-left-left");
            Assert.AreEqual(enumerator.Next().Value, "1-left");
            Assert.AreEqual(enumerator.Next().Value, "2-left-right");
            Assert.AreEqual(enumerator.Next().Value, "0-root");
            Assert.AreEqual(enumerator.Next().Value, "2-right-left");
            Assert.AreEqual(enumerator.Next().Value, "1-right");
            Assert.AreEqual(enumerator.Next().Value, "3-right-right-left");
            Assert.AreEqual(enumerator.Next().Value, "4-right-right-left-right");
            Assert.AreEqual(enumerator.Next().Value, "2-right-right");
        }
    }
}
