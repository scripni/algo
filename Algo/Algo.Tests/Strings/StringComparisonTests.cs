
using Algo.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests.Strings
{
    [TestClass]
    public class StringComparisonTests
    {
        [TestMethod]
        public void SimilarWords_SimilarWords_ReturnsTrue()
        {
            // arrange
            StringComparison s = new StringComparison();

            // act
            // assert
            Assert.IsTrue(s.SimilarWords("car", "cas"));
            Assert.IsTrue(s.SimilarWords("car", "card"));

            Assert.IsFalse(s.SimilarWords("car", "caert"));
            Assert.IsFalse(s.SimilarWords("car", "bat"));
        }
    }
}
