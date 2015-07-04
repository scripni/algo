using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Tests.TopCoder.Easy
{
    [TestClass]
    public class AaagmnrsTests
    {
        [TestMethod]
        public void Anagrams_TestCase1_Passes()
        {
            // arrange
            string[] phrases = new string[] { "Aaagmnrs", "TopCoder", "anagrams", "Drop Cote" };
            string[] expected = new string[] { "Aaagmnrs", "TopCoder" };
            Aaagmnrs solver = new Aaagmnrs();

            // act
            string[] actual = solver.anagrams(phrases);

            // assert
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }


        [TestMethod]
        public void Anagrams_TestCase2_Passes()
        {
            // arrange
            string[] phrases = new string[] { "SnapDragon vs tomek", "savants groped monk", "Adam vents prongs ok" };
            string[] expected = new string[] { "SnapDragon vs tomek" };
            Aaagmnrs solver = new Aaagmnrs();

            // act
            string[] actual = solver.anagrams(phrases);

            // assert
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }


        [TestMethod]
        public void Anagrams_TestCase3_Passes()
        {
            // arrange
            string[] phrases = new string[] { "Radar ghost jilts Kim", "patched hers first", "DEPTH FIRST SEARCH", "DIJKSTRAS ALGORITHM" };
            string[] expected = new string[] { "Radar ghost jilts Kim", "patched hers first" };
            Aaagmnrs solver = new Aaagmnrs();

            // act
            string[] actual = solver.anagrams(phrases);

            // assert
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
