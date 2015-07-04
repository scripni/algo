using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Selection
{
    public class RandomizedSelection
    {
        Random r = new Random();


        public int RandomSelect(int[] input)
        {
            int statisticOrder = r.Next(0, input.Length - 1);

            return RandomSelect(input, 0, input.Length - 1, statisticOrder);
        }

        private int RandomSelect(int[] input, int start, int end, int statisticOrder)
        {
            if (start == end)
            {
                return input[start];
            }

            return 0;

        }
    }
}
