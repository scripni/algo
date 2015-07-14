using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Search
{
    public class FindItem
    {
        public int SearchRotated(int[] a, int x)
        {
            int i = 0, j = a.Length - 1;
            while (i <= j)
            {
                int m = i + (j - i) / 2;
                if (a[m] == x) return m;

                if (a[i] < a[m])
                {
                    if (a[i] <= x && x < a[m]) j = m - 1;
                    else i = m + 1;
                }
                else
                {
                    if (a[m] < x && x <= a[j]) i = m + 1;
                    else j = m - 1;
                }
            }

            return -1;
        }
    }
}
