﻿using Algo.MathOps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Tests.MathOps
{
    [TestClass]
    public class MathOperationTests
    {
        [TestMethod]
        public void DivideNoOperator_ValidValues_ReturnsValue()
        {
            // arrange
            int a = 10;
            int b = 2;
            DivisionResult expected = new DivisionResult();
            expected.Divisor = a / b;
            expected.Remainder = a % b;
            MathOperations m = new MathOperations();

            // act
            DivisionResult actual = m.DivideNoOperand(a, b);

            // assert
            Assert.AreEqual(expected.Divisor, actual.Divisor);
            Assert.AreEqual(expected.Remainder, actual.Remainder);
        }


        [TestMethod]
        public void DivideNoOperator_RandomSamples_ReturnsValue()
        {
            Random r = new Random(1234);
            for (int i = 0; i < 100000; i++)
            {
                // arrange
                int a = r.Next(10000);
                int b = r.Next(1, 100);
                DivisionResult expected = new DivisionResult();
                expected.Divisor = a / b;
                expected.Remainder = a % b;
                MathOperations m = new MathOperations();

                // act
                DivisionResult actual = m.DivideNoOperand(a, b);

                // assert
                Assert.AreEqual(expected.Remainder, actual.Remainder);
                Assert.AreEqual(expected.Divisor, actual.Divisor);
            }
        }
    }
}
