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
    public class StringManipulationTests
    {
        [TestMethod]
        public void RotateWords_SingleWord_Reverses()
        {
            // arrange
            string input = "foo";
            string expected = "oof";
            StringManipulation s = new StringManipulation();

            // act
            string actual = s.RotateWords(input);

            // assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void RotateWords_SentenceWithPunctuation_Reverses()
        {
            // arrange
            string input = "Marry had... a little lamb.";
            string expected = "yrraM dah... a elttil bmal.";
            StringManipulation s = new StringManipulation();

            // act
            string actual = s.RotateWords(input);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
