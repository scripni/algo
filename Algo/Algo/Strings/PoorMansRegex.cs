using System.Collections.Generic;
using System.Text;

namespace Algo.Strings
{
    public class PoorMansRegex
    {
        public string Match(string input, string pattern)
        {
            // fooobar
            // fo*.ar
            StringBuilder result = new StringBuilder();
            int i = 0, j = 0;
            while (i < input.Length && j < pattern.Length)
            {
                bool zeroOrMore = j < pattern.Length - 1 && pattern[j + 1] == '*';

                if (zeroOrMore)
                {
                    while (i < input.Length && input[i] == pattern[j])
                    {
                        result.Append(input[i++]);
                    }

                    j += 2;
                }
                else if (input[i] == pattern[j] || pattern[j] == '.')
                {
                    result.Append(input[i++]);
                    j++;
                }
                else
                {
                    i -= result.Length;
                    i++;
                    result.Length = 0;
                    j = 0;
                }
            }

            if (j == pattern.Length)
            {
                return result.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
