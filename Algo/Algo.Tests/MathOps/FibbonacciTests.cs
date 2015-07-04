using Algo.MathOps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Tests.MathOps
{
    [TestClass]
    public class FibbonacciTests
    {
        [TestMethod]
        public void GenerateFibonacci_SmallNumber_ReturnsExpected()
        {
            // arrange
            List<int> expected = new List<int>() { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };
            Fibbonacci f = new Fibbonacci();

            // act
            List<int> actual = f.CreateFibbonacci(expected.Count);

            // assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}
