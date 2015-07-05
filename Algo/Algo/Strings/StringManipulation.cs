using System.Collections.Generic;
using System.Text;

namespace Algo.Strings
{
    public class StringManipulation
    {
        public string RotateWords(string a)
        {
            StringBuilder result = new StringBuilder();
            Stack<char> reverse = new Stack<char>();
            foreach (char c in a)
            {
                if (c < 'A' || c > 'z')
                {
                    while (reverse.Count > 0)
                    {
                        result.Append(reverse.Pop());
                    }

                    result.Append(c);
                }
                else
                {
                    reverse.Push(c);
                }
            }

            while (reverse.Count > 0)
            {
                result.Append(reverse.Pop());
            }

            return result.ToString();
        }
    }
}
