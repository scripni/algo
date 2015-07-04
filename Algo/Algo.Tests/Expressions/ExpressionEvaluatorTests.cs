using Algo.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests.Expressions
{
    [TestClass]
    public class ExpressionEvaluatorTests
    {
        [TestMethod]
        public void Prefix_ValidExpression_CorrectResult()
        {
            // arrange
            string input = "-+*23*549";
            ExpressionParser parser = new ExpressionParser();

            // act
            int result = parser.Prefix(input);

            // assert
            Assert.AreEqual(17, result);
        }

        [TestMethod]
        public void Postfix_ValidExpression_CorrectResult()
        {
            // arrange
            string input = "23*54*+9-";
            ExpressionParser parser = new ExpressionParser();

            // act
            int result = parser.Postfix(input);

            // assert
            Assert.AreEqual(17, result);
        }
    }
}
