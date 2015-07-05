using Algo.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Tests.Strings
{
    [TestClass]
    public class DecodeWaysTests
    {
        [TestMethod]
        public void DecodeWays_ValidInput_FindsResult()
        {
            // arrange
            string input = "4757562545844617494555774581341211511296816786586787755257741178599337186486723247528324612117156948";
            int expected = 589824;
            DecodeWays d = new DecodeWays();

            // act
            int actual = d.FindDecodeWays(input);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
