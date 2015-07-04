using Algo.Sets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Tests.Sets
{
    [TestClass]
    public class PermutationTests
    {
        [TestMethod]
        public void GeneratePermutations_SizeThree_ReturnsValidValue()
        {
            // arrange
            char[] s = new char[] { 'a', 'b', 'c' };
            List<char[]> expected = new List<char[]>()
            {
                new char[] {'a', 'b', 'c'},
                new char[] {'a', 'c', 'b'},
                new char[] {'b', 'a', 'c'},
                new char[] {'b', 'c', 'a'},
                new char[] {'c', 'a', 'b'},
                new char[] {'c', 'b', 'a'},
            };
            Permutations p = new Permutations();

            // act
            List<char[]> actual = p.GeneratePermutations(s);

            // assert
            Assert.AreEqual(expected.Count, actual.Count);
            foreach (char[] e in expected)
            {
                bool found = false;
                foreach (char[] a in actual)
                {
                    int i = 0;
                    for (; i < a.Length; i++)
                    {
                        if (e[i] != a[i])
                        {
                            break;
                        }
                    }

                    if (i == a.Length)
                    {
                        found = true;
                        break;
                    }
                }

                Assert.IsTrue(found);
            }
        }
    }
}
