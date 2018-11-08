using System.Collections.Generic;

namespace leetcode
{
    public class PalindromePermutation
    {
        public static bool IsPermutationPalindrome(string s)
        {
            int[] counts = new int[26];
            for(int i = 0; i < s.Length; i++)
            {
                counts[s[i]-'a']++;
            }

            /* Code optimization. Count number of chars with odd value. If count > 1 return false, else true
            Because to make a string of even length there have to be atleast 2 odd count chars anyway */

            int oddCount = 0;
            for(int i = 0; i < counts.Length; i++)
            {
                if(counts[i]%2 != 0) oddCount++;
            }

            return oddCount <= 1;
            
            /* bool extra = s.Length%2 != 0;
            for(int i = 0; i < 26; i++)
            {
                if(counts[i]%2 != 0)
                {
                    if(extra) extra = false;
                    else return false;
                }
            }

            return true;
            */
        }
    }
}