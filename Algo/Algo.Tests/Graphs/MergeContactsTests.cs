using Algo.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Tests.Graphs
{
    [TestClass]
    public class MergeContactsTests
    {
        [TestMethod]
        public void Merge_DistinctContacts_ReturnsValue()
        {
            // arrange
            string[] contacts = { "andrei andrei@mail.com +12345", "paraschiva gicu@mail.com +23456", "aurel aurel@mail.con +23423" };
            MergeContacts m = new MergeContacts();

            // act
            List<List<int>> actual = m.Merge(contacts);

            // assert
            Assert.AreEqual(actual.Count, 3);
            Assert.IsNotNull(actual.Single(c => c.Count == 1 && c[0] == 0));
            Assert.IsNotNull(actual.Single(c => c.Count == 1 && c[0] == 1));
            Assert.IsNotNull(actual.Single(c => c.Count == 1 && c[0] == 2));
        }


        [TestMethod]
        public void Merge_NonUniqueContacts_ReturnsValue()
        {
            // arrange
            string[] contacts = { "andrei andrei@mail.com +12345", "paraschiva andrei@mail.com +23456", "aurel aurel@mail.con +12345" };
            MergeContacts m = new MergeContacts();

            // act
            List<List<int>> actual = m.Merge(contacts);

            // assert
            Assert.AreEqual(actual.Count, 1);
            Assert.IsNotNull(actual[0].Single(c => c == 0));
            Assert.IsNotNull(actual[0].Single(c => c == 1));
            Assert.IsNotNull(actual[0].Single(c => c == 2));
        }


        [TestMethod]
        public void Merge_NonUniqueAndUniqueContacts_ReturnsValue()
        {
            // arrange
            string[] contacts = { "andrei andrei@mail.com +12345", "paraschiva andrei@mail.com +23456", "aurel aurel@mail.con +12345",
                                   "mihai mihai@mail.com +53231", "petre petre@mail.com +32423"};
            MergeContacts m = new MergeContacts();

            // act
            List<List<int>> actual = m.Merge(contacts);

            // assert
            Assert.AreEqual(3, actual.Count);
            Assert.IsNotNull(actual.Single(a => a.Count == 3 &&
                a.Count(c => c == 0) == 1 && a.Count(c => c == 1) == 1 &&
                a.Count(c => c == 2) == 1));
            Assert.IsNotNull(actual.Single(c => c.Count == 1 && c[0] == 3));
            Assert.IsNotNull(actual.Single(c => c.Count == 1 && c[0] == 4));
        }
    }
}
