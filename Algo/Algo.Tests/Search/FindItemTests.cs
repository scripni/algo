using Algo.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Tests.Search
{
    [TestClass]
    public class FindItemTests
    {
        [TestMethod]
        public void FindInRotatedSortedArray_RotatedArray_ReturnsValue()
        {
            // arrange
            int[] a = { 4, 5, 6, 7, 8, 9, 1, 2, 3 };
            FindItem f = new FindItem();

            // act
            // assert
            Assert.AreEqual(0, f.SearchRotated(a, 4));
            Assert.AreEqual(1, f.SearchRotated(a, 5));
            Assert.AreEqual(2, f.SearchRotated(a, 6));
            Assert.AreEqual(3, f.SearchRotated(a, 7));
            Assert.AreEqual(4, f.SearchRotated(a, 8));
            Assert.AreEqual(5, f.SearchRotated(a, 9));
            Assert.AreEqual(6, f.SearchRotated(a, 1));
            Assert.AreEqual(7, f.SearchRotated(a, 2));
            Assert.AreEqual(8, f.SearchRotated(a, 3));
            Assert.AreEqual(-1, f.SearchRotated(a, 10));
        }
    }
}
