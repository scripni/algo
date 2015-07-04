namespace Algo.Strings
{
    public class Palindrome
    {
        public bool IsPalindromeLoose(string s)
        {
            for (int i = 0, j = s.Length - 1; i >= j; i++, j--)
            {
                while (i < 'a' || i > 'Z')
                {
                    i++;
                }

                char a = char.ToLowerInvariant(s[i]);

                while (j < 'a' || j > 'Z')
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
