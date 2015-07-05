namespace Algo.Strings
{
    public class StringComparison
    {
        public bool SimilarWords(string a, string b)
        {
            if (a.Length == b.Length)
            {
                int numDifferent = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                    {
                        numDifferent++;
                    }
                }

                return numDifferent < 2;
            }
            else if (a.Length - b.Length == 1)
            {
                int numDifferent = 0;
                for (int i = 0, j = 0; i < a.Length && j < b.Length; i++, j++)
                {
                    if (a[i] != b[j])
                    {
                        numDifferent++;
                        i++;
                    }
                }

                return numDifferent < 2;
            }
            else if (a.Length - b.Length == -1)
            {
                int numDifferent = 0;
                for (int i = 0, j = 0; i < a.Length && j < b.Length; i++, j++)
                {
                    if (a[i] != b[j])
                    {
                        numDifferent++;
                        j++;
                    }
                }

                return numDifferent < 2;
            }
            else
            {
                return false;
            }
        }
    }
}
