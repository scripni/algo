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

        [TestMethod]
        public void SquareRoot_ValidValues_ReturnsExpected()
        {
            // arrange
            double a = 100;
            MathOperations m = new MathOperations();
            double expected = 10;
            double error = 0.1;

            // act
            double actual = m.SquareRoot(a, error);

            // assert
            Assert.IsTrue(Math.Abs(actual * actual - expected * expected) < error);
        }

        [TestMethod]
        public void SquareRoot_RandomSamples_ReturnsValue()
        {
            Random r = new Random(1234);
            for (int i = 0; i < 100000; i++)
            {
                // arrange
                double a = r.NextDouble() * (i % 10);
                MathOperations m = new MathOperations();
                double expected = Math.Sqrt(a);
                double error = 0.001;

                // act
                double actual = m.SquareRoot(a, error);

                // assert
                Assert.IsTrue(Math.Abs(actual * actual - expected * expected) < error);
            }
        }


        [TestMethod]
        public void AddBigNumbers_TwoNumbersNoCarry_ReturnsValue()
        {
            // arrange
            int[] a = { 1, 2, 3 };
            int[] b = { 2, 3, 4 };
            int[] expected = { 0, 3, 5, 7 };
            MathOperations m = new MathOperations();

            // act
            int[] actual = m.AddBigNumbers(a, b);

            // assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }


        [TestMethod]
        public void AddBigNumbers_TwoNumbersWithCarry_ReturnsValue()
        {
            // arrange
            int[] a = { 1, 2, 3 };
            int[] b = { 9, 3, 4 };
            int[] expected = { 1, 0, 5, 7 };
            MathOperations m = new MathOperations();

            // act
            int[] actual = m.AddBigNumbers(a, b);

            // assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }


        [TestMethod]
        public void AddBigNumbers_TwoNumbersDifferentSize_ReturnsValue()
        {
            // arrange
            int[] a = { 1, 2, 3 };
            int[] b = { 5, 9, 3, 4 };
            int[] expected = { 0, 6, 0, 5, 7 };
            MathOperations m = new MathOperations();

            // act
            int[] actual = m.AddBigNumbers(a, b);

            // assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}
