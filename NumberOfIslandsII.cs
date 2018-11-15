using System;
using System.Collections.Generic;

namespace leetcode
{
    public class NumberOfIslandsII
    {
        public static List<int> NumOfIslands(int m, int n, List<Tuple<int, int>> positions)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int[,] dir = new int[,] {
                {-1, 0},
                {1, 0},
                {0, -1},
                {0, 1}
            };

            int currCountIslands = 0;
            List<int> ret = new List<int>();

            foreach (Tuple<int, int> t in positions)
            {
                int id = t.Item1 * n + t.Item2;
                if (dict.ContainsKey(id))
                {
                    continue;
                }

                dict.Add(id, id);
                currCountIslands++;
                for (int i = 0; i < dir.GetLength(0); i++)
                {
                    int r = t.Item1 + dir[i, 0]; int c = t.Item2 + dir[i, 1];
                    if (r < 0 || r >= m || c < 0 || c >= n) continue;
                    int nid = r * n + c;
                    if (!dict.ContainsKey(nid)) continue;
                    int p = GetRoot(id, dict); int q = GetRoot(nid, dict);
                    if (p != q)
                    {
                        currCountIslands--;
                        dict[q] = p;
                    }
                }

                ret.Add(currCountIslands);
            }

            return ret;
        }

        private static int GetRoot(int id, Dictionary<int, int> dict)
        {
            if (id == dict[id]) return id;
            return GetRoot(dict[id], dict);
        }
    }
}