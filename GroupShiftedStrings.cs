using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode
{
    public static class GroupShiftedStrings
    {
        public static List<List<string>> Group(List<string> words)
        {
            List<List<string>> res = new List<List<string>>();
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            foreach(string word in words)
            {
                string diff = GetDiff(word);
                if(dict.ContainsKey(diff)) dict[diff].Add(word);
                else dict.Add(diff, new List<string>(){word});
            }

            foreach(KeyValuePair<string, List<string>> kvp in dict)
            {
                res.Add(kvp.Value);
            }

            return res;
        }

        private static string GetDiff(string word)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 1; i < word.Length; i++)
            {
                int diff = word[i]-word[i-1];
                if(diff < 0) diff += 26;
                sb.Append((char)('a' + diff));
            }

            return sb.ToString();
        }
    }
}