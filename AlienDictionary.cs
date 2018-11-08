using System.Collections.Generic;
using System;

namespace leetcode
{
    public class AlienDictionary
    {
        public static List<char> GetCharSequence(List<string> words)
        {
            Dictionary<char, List<char>> dict = new Dictionary<char, List<char>>();
            
            // Need to get the char sequences from word order:
            // abcd, abcb; then d -> b. 
            for(int i = 0; i < words.Count-1; i++)
            {
                int len = Math.Min(words[i].Length, words[i+1].Length);
                for(int j = 0; j < len; j++)
                {
                    if(words[i][j] != words[i+1][j])
                    {
                        if(dict.ContainsKey(words[i][j])) dict[words[i][j]].Add(words[i+1][j]);
                        else 
                            dict.Add(words[i][j], new List<char>(){words[i+1][j]});
                        break;
                    }
                }
            }

            return TopoSort(dict);
        }

        private static List<char> TopoSort(Dictionary<char, List<char>> dict)
        {
            HashSet<char> visited = new HashSet<char>();
            Stack<char> stack = new Stack<char>();

            foreach(char c in dict.Keys)
            {
                if(!visited.Contains(c))
                    DFS(c, dict, visited, stack);
            }

            return new List<char>(stack);
        }

        private static void DFS(char root, Dictionary<char, List<char>> dict, HashSet<char> visited, Stack<char> stack)
        {
            if(visited.Contains(root)) return;
            visited.Add(root);

            if(!dict.ContainsKey(root)) 
            {
                stack.Push(root);
                return;
            }

            foreach(char c in dict[root])
            {
                DFS(c, dict, visited, stack);
            }

            stack.Push(root);
        }
    }
}