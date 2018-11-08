using System.Collections.Generic;

namespace leetcode
{
    public class FlipGame
    {
        // We need to return all possible states that require only 1 move
        //
        public static List<string> AllPossibleStates(string s)
        {
            List<string> res = new List<string>();
            char[] arr = s.ToCharArray();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == '+' && arr[i + 1] == '+')
                {
                    arr[i] = arr[i + 1] = '-';
                    res.Add(new string(arr));
                    arr[i] = arr[i + 1] = '+';
                }
            }

            return res;
        }

        public static bool CanPlayerWin(string s)
        {
            // Very elegant solution:
            // If player can make the string (by altering any ++) non winnable in the next iteration 
            // then the player wins.
            int idx = -1;
            while (true)
            {
                idx = s.IndexOf("++", idx + 1);
                if (idx == -1) return false;
                if (!CanPlayerWin(s.Substring(0, idx) + "--" + s.Substring(idx + 2)))
                {
                    return true;
                }
            }
        }
    }
}