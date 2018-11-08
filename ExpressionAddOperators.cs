using System;
using System.Collections.Generic;

namespace leetcode
{
    public class ExpressionAddOperators
    {
        public static List<string> AddOperators(string s, int target)
        {
            List<string> res = new List<string>();
            Helper(s, res, target, 0, "", 0, 0);
            return res;
        }

        // prev is the last value that needs to be multiplied if a * symbol is going to be used before the current 
        // val being used.
        //
        private static void Helper(string s, List<string> res, int target, int idx, string curr, int eval, int prev)
        {
            if(idx == s.Length)
            {
                if(eval == target) res.Add(curr);
                return;
            }

            for(int i = idx; i < s.Length; i++)
            {
                // A 2 digit number cannot start with 0
                if(i != idx && s[idx] == '0') break;

                int val = Int32.Parse(s.Substring(idx, i-idx+1));
                if(idx == 0)
                {
                    Helper(s, res, target, i+1, curr + val.ToString(), val, val);
                }
                else
                {
                    // Assume we are adding + before this val
                    Helper(s, res, target, i+1, curr + "+" + val.ToString(), eval + val, val);

                    // Assume we are adding - before this val
                    Helper(s, res, target, i+1, curr + "-" + val.ToString(), eval-val, -1*val);

                    // Assume we are adding a * before this val
                    Helper(s, res, target, i+1, curr + "*" + val.ToString(), eval-prev+prev*val, prev*val);
                }
            }
        }
    }
}