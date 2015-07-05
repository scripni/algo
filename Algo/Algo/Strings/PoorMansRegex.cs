using System.Collections.Generic;
using System.Text;

namespace Algo.Strings
{
    public class PoorMansRegex
    {
        public string Match(string input, string pattern)
        {
            // build search stack
            Stack<SearchItem> toSearch = new Stack<SearchItem>();
            for (int i = pattern.Length - 1; i >= 0; i--)
            {
                SearchItem searchItem = new SearchItem();
                if (pattern[i] == '*')
                {
                    i--;
                    searchItem.MatchZeroOrMore = true;
                }

                searchItem.Character = pattern[i];
                toSearch.Push(searchItem);
            }

            Stack<SearchItem> found = new Stack<SearchItem>();
            StringBuilder result = new StringBuilder();
            int inputIndex = 0;

            // search for pattern
            while (toSearch.Count > 0 && inputIndex < input.Length)
            {
                for (int i = inputIndex; i < input.Length && toSearch.Count > 0; i++)
                {
                    SearchItem current = toSearch.Peek();

                    if (current.MatchZeroOrMore)
                    {
                        while (current.Character == input[i])
                        {
                            result.Append(input[i++]);
                        }

                        found.Push(toSearch.Pop());
                    }
                    else if (current.Character == '.' || current.Character == input[i])
                    {
                        result.Append(input[i]);
                        found.Push(toSearch.Pop());
                    }
                    else
                    {
                        inputIndex++;
                        while (found.Count > 0) toSearch.Push(found.Pop());
                        result.Length = 0;
                        break;
                    }
                }
            }

            if (toSearch.Count == 0) return result.ToString();
            else return null;
        }
    }

    public struct SearchItem
    {
        public char Character;

        public bool MatchZeroOrMore;
    }
}
