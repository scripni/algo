using System.Collections.Generic;

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

        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }
    }
}
