using System;

namespace LongestSubstringWithoutRepeatingCharacters
{
    /*
        Given a string s, find the length of the longest substring without repeating characters.
        Example 1:

        Input: s = "abcabcbb"
        Output: 3
        Explanation: The answer is "abc", with the length of 3.
        Example 2:

        Input: s = "bbbbb"
        Output: 1
        Explanation: The answer is "b", with the length of 1.
        Example 3:

        Input: s = "pwwkew"
        Output: 3
        Explanation: The answer is "wke", with the length of 3.
        Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 

        Constraints:

        0 <= s.length <= 5 * 104
        s consists of English letters, digits, symbols and spaces.    
    */
    class Program
    {
        static void Main(string[] args)
        {
            var userInput = "abcabcbb";
            var result = userInput.LengthOfLongestSubstring();

            Console.WriteLine($"Length of longest substring: {result}");
        }
    }

    public static class ExtentionString
    {
        public static int LengthOfLongestSubstring(this string s)
        {
            if (s.Length < 2)
                return s.Length;

            // Window Algo indexes
            int i = 0;
            int j = 1;
            string curr = s[0].ToString();
            int result = 1;
            while (i < s.Length - 1)
            {
                // Increase our window
                while (j < s.Length && !curr.Contains(s[j]))
                {
                    curr += s[j];
                    j++;
                }
       
                // Take very huge window in window algo
                result = Math.Max(result, curr.Length);
                curr = curr.Substring(1);
                i++;
            }

            // Space complicty O(n) Time complicity O(n + n)
            return result;
        }
    }
}
