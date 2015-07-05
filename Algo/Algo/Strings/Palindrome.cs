namespace Algo.Strings
{
    public class Palindrome
    {
        public bool IsPalindromeLoose(string s)
        {
            for (int i = 0, j = s.Length - 1; i >= j; i++, j--)
            {
                while (i < 'A' || i > 'z')
                {
                    i++;
                }

                char a = char.ToLowerInvariant(s[i]);

                while (j < 'A' || j > 'z')
                {
                    j--;
                }

                char b = char.ToLowerInvariant(s[j]);

                if (a != b) return false;
            }

            return true;
        }
    }
}
