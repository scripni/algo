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
    public class PoorMansRegexTests
    {
        [TestMethod]
        public void Match_StartOfString_FindsMatch()
        {
            // arrange
            string input = "andrei scripniciuc";
            string pattern = "andrei";
            PoorMansRegex r = new PoorMansRegex();

            // act
            string actual = r.Match(input, pattern);

            // assert
            Assert.AreEqual(pattern, actual);
        }

        [TestMethod]
        public void Match_EndOfString_FindsMatch()
        {
            // arrange
            string input = "andrei scripniciuc";
            string pattern = "scripniciuc";
            PoorMansRegex r = new PoorMansRegex();

            // act
            string actual = r.Match(input, pattern);

            // assert
            Assert.AreEqual(pattern, actual);
        }

        [TestMethod]
        public void Match_MiddleOfString_FindsMatch()
        {
            // arrange
            string input = "dubl, andrei scripniciuc, dublin, ireland";
            string pattern = "dublin";
            PoorMansRegex r = new PoorMansRegex();

            // act
            string actual = r.Match(input, pattern);

            // assert
            Assert.AreEqual(pattern, actual);
        }

        [TestMethod]
        public void Match_IncludesZeroOrMoreMatch_FindsMatch()
        {
            // arrange
            string input = "foo bar";
            string pattern = "fo*";
            PoorMansRegex r = new PoorMansRegex();

            // act
            string actual = r.Match(input, pattern);

            // assert
            Assert.AreEqual("foo", actual);
        }

        [TestMethod]
        public void Match_IncludesZeroOrMoreMatchWithZeroMatch_FindsMatch()
        {
            // arrange
            string input = "foo bar";
            string pattern = "fooa*";
            PoorMansRegex r = new PoorMansRegex();

            // act
            string actual = r.Match(input, pattern);

            // assert
            Assert.AreEqual("foo", actual);
        }

        [TestMethod]
        public void Match_IncludesDotMatch_FindsMatch()
        {
            // arrange
            string input = "foo bar";
            string pattern = "foo.bar";
            PoorMansRegex r = new PoorMansRegex();

            // act
            string actual = r.Match(input, pattern);

            // assert
            Assert.AreEqual("foo bar", actual);
        }
    }
}
