using System.Collections.Generic;
using System.Text;

namespace Algo.Expressions
{
    public class ExpressionParser
    {
        public int Prefix(string e)
        {
            Stack<int> s = new Stack<int>();

            for (int i = e.Length - 1; i >= 0; i--)
            {
                char c = e[i];
                if (IsOperator(c))
                {
                    int a = s.Pop();
                    int b = s.Pop();
                    switch (c)
                    {
                        case '+':
                            s.Push(a + b);
                            break;
                        case '-':
                            s.Push(a - b);
                            break;
                        case '*':
                            s.Push(a * b);
                            break;
                        case '/':
                            s.Push(a / b);
                            break;
                    }
                }
                else
                {
                    s.Push(c - '0');
                }
            }

            return s.Pop();
        }

        public int Postfix(string e)
        {
            Stack<int> s = new Stack<int>();
            foreach (char c in e)
            {
                if (IsOperator(c))
                {
                    int b = s.Pop();
                    int a = s.Pop();
                    switch (c)
                    {
                        case '+':
                            s.Push(a + b);
                            break;
                        case '-':
                            s.Push(a - b);
                            break;
                        case '*':
                            s.Push(a * b);
                            break;
                        case '/':
                            s.Push(a / b);
                            break;
                    }
                }
                else
                {
                    s.Push(c - '0');
                }
            }

            return s.Pop();
        }


        public string ToPostfix(string infix)
        {
            Stack<char> s = new Stack<char>();
            StringBuilder b = new StringBuilder();
            foreach (char c in infix)
            {
                if (IsOperator(c))
                {
                    while (s.Count > 0 && s_precedences[s.Peek()] >= s_precedences[c])
                    {
                        b.Append(s.Pop());
                    }

                    s.Push(c);
                }
                else
                {
                    b.Append(c);
                }
            }

            while (s.Count > 0)
            {
                b.Append(s.Pop());
            }

            return b.ToString();
        }

        private static readonly Dictionary<char, int> s_precedences =
            new Dictionary<char, int>()
            {
                {'+', 0 },
                {'-', 0 },
                {'*', 1 },
                {'/', 1 },
            };

        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }
    }
}
