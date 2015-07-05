namespace Algo.Strings
{
    public class DecodeWays
    {
        public int FindDecodeWays(string encodedText)
        {
            // check base case for the recursion
            if (encodedText.Length == 0)
            {
                return 1;
            }

            // sum all tails
            int sum = 0;
            for (int headSize = 1; headSize <= 2 && headSize <= encodedText.Length; headSize++)
            {
                string head = encodedText.Substring(0, headSize);
                string tail = encodedText.Substring(headSize);
                if (int.Parse(head) > 26)
                {
                    break;
                }

                sum += FindDecodeWays(tail);
            }

            return sum;
        }
    }
}
