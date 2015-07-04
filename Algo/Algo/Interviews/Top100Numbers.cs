using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Interviews
{
    public class FindBigNumbers
    {
        public int[] top100(int[] n)
        {
            Stack<int> top100 = new Stack<int>();
            Stack<int> temp = new Stack<int>();

            for (int i = 0; i < n.Length; i++)
            {
                if (top100.Count == 100 && top100.Peek() >= n[i]) continue;

                while (top100.Count == 0 || n[top100.Peek()] < n[i])
                {
                    temp.Push(top100.Pop());
                }

                top100.Push(i);

                while (temp.Count > 1)
                {
                    top100.Push(temp.Pop());
                }

                temp.Pop();
            }


            return top100.ToArray();
        }
    }
}
