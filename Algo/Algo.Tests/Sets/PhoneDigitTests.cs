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
    public class PhoneDigitTests
    {
        [TestMethod]
        public void PossibleWords_ThreeDigits_ReturnsExpected()
        {
            // arrange
            int[] number = { 0, 1, 0 };
            PhoneDigits p = new PhoneDigits();
            List<char[]> expected = new List<char[]>()
            {
                new[] {'a', 'd', 'a'}, new[] {'a', 'd', 'b'}, new[] {'a', 'd', 'c'},
                new[] {'a', 'e', 'a'}, new[] {'a', 'e', 'b'}, new[] {'a', 'e', 'c'},
                new[] {'a', 'f', 'a'}, new[] {'a', 'f', 'b'}, new[] {'a', 'f', 'c'},
                new[] {'b', 'd', 'a'}, new[] {'b', 'd', 'b'}, new[] {'b', 'd', 'c'},
                new[] {'b', 'e', 'a'}, new[] {'b', 'e', 'b'}, new[] {'b', 'e', 'c'},
                new[] {'b', 'f', 'a'}, new[] {'b', 'f', 'b'}, new[] {'b', 'f', 'c'},
                new[] {'c', 'd', 'a'}, new[] {'c', 'd', 'b'}, new[] {'c', 'd', 'c'},
                new[] {'c', 'e', 'a'}, new[] {'c', 'e', 'b'}, new[] {'c', 'e', 'c'},
                new[] {'c', 'f', 'a'}, new[] {'c', 'f', 'b'}, new[] {'c', 'f', 'c'},
            };

            // act
            List<char[]> actual = p.PossibleWords(number);

            // assert
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
