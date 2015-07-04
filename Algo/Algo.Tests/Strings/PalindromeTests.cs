using Algo.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests.Strings
{
    [TestClass]
    public class PalindromeTests
    {
        [TestMethod]
        public void IsPalindrome_OnlyLowercaseChars_ReturnsTrue()
        {
            // arrange
            string palindrome1 = "abccba";
            string palindrome2 = "abcba";
            Palindrome p = new Palindrome();

            // act
            // assert
            Assert.IsTrue(p.IsPalindromeLoose(palindrome1));
            Assert.IsTrue(p.IsPalindromeLoose(palindrome2));
        }


        [TestMethod]
        public void IsPalindrome_LowerUpperChars_ReturnsTrue()
        {
            // arrange
            string palindrome1 = "abCcba";
            string palindrome2 = "aBcbA";
            Palindrome p = new Palindrome();

            // act
            // assert
            Assert.IsTrue(p.IsPalindromeLoose(palindrome1));
            Assert.IsTrue(p.IsPalindromeLoose(palindrome2));
        }


        [TestMethod]
        public void IsPalindrome_LowerUpperPunctuation_ReturnsTrue()
        {
            // arrange
            string palindrome1 = "ab,C.c  ba";
            string palindrome2 = "a\\B,cb|A";
            Palindrome p = new Palindrome();

            // act
            // assert
            Assert.IsTrue(p.IsPalindromeLoose(palindrome1));
            Assert.IsTrue(p.IsPalindromeLoose(palindrome2));
        }
    }
}
