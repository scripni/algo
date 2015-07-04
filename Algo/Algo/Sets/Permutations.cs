using System;
using System.Collections.Generic;

namespace Algo.Sets
{
    public class Permutations
    {
        public List<char[]> GeneratePermutations(char[] s)
        {
            List<char[]> results = new List<char[]>();

            GeneratePermutations(s, 0, results);

            return results;
        }

        private void GeneratePermutations(char[] a, int i, List<char[]> results)
        {
            if (i == a.Length - 1)
            {
                char[] r = new char[a.Length];
                Array.Copy(a, r, a.Length);
                results.Add(r);
                return;
            }

            for (int j = i; j < a.Length; j++)
            {
                char t = a[i];
                a[i] = a[j];
                a[j] = t;

                GeneratePermutations(a, i + 1, results);

                t = a[i];
                a[i] = a[j];
                a[j] = t;
            }
        }
    }
}
