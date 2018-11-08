using System.Text;
using System.Collections.Generic;
using System;

namespace leetcode
{
    public class EncodeAndDecodeStrings
    {
        public static string Serialize(List<string> words)
        {
            // Every char is the string representation of its ASCII value
            // Every char is delimited by a white space
            // Words are delimited by a *
            //
            StringBuilder sb = new StringBuilder();
            foreach(string word in words)
            {
                foreach(char c in word)
                {
                    sb.Append((int)(c));
                    sb.Append(' ');
                }

                sb.Append('*');
            }

            return sb.ToString();
        }

        public static List<string> Deserialize(string s)
        {
            List<string> res = new List<string>();
            StringBuilder sb = new StringBuilder();
            int start = 0; int end = 0;
            while(start < s.Length)
            {
                if(s[end] == '*')
                {
                    res.Add(sb.ToString());
                    sb.Clear();
                    end++;
                    start = end;
                }
                else 
                {
                    if(s[end] == ' ')
                    {
                        string temp = s.Substring(start, end-start);
                        sb.Append((char)(Int32.Parse(temp)));
                        start = end+1;
                    }

                    end++;
                }
            }

            return res;
        }
    }
}