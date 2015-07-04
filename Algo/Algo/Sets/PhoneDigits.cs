using System;
using System.Collections.Generic;

namespace Algo.Sets
{
    public class PhoneDigits
    {
        private static readonly Dictionary<int, char[]> s_letters =
            new Dictionary<int, char[]>()
            {
                {0, new char[] {'a', 'b', 'c'} },
                {1, new char[] {'d', 'e', 'f'} },
                {2, new char[] {'g', 'h', 'i'} },
                {3, new char[] {'j', 'k', 'l', 'm'} },
            };

        public List<char[]> PossibleWords(int[] digits)
        {
            // [0, 1, 2]

            int[] option = new int[digits.Length];

            List<char[]> results = new List<char[]>();

            PossibleWords(digits, option, 0, results);

            return results;
        }

        private void PossibleWords(int[] digits, int[] option, int i, List<char[]> results)
        {
            if (i >= digits.Length)
            {
                return;
            }

            while (option[i] < s_letters[digits[i]].Length)
            {
                char[] r = new char[digits.Length];

                for (int c = 0; c < digits.Length; c++)
                {
                    r[c] = s_letters[digits[c]][option[c]];
                }

                if (i == digits.Length - 1)
                {
                    char[] n = new char[r.Length];
                    Array.Copy(r, n, r.Length);
                    results.Add(n);
                }
                else
                {
                    PossibleWords(digits, option, i + 1, results);
                }

                option[i]++;
            }

            option[i] = 0;
        }
    }
}
