using System;
using System.Collections.Generic;

namespace leetcode
{
    public class PaintFence
    {
        public static int NumWays(int n, int k)
        {
            if(n == 0) return 0;
            int same = 0; int diff = k; int total = same + diff;
            for(int i = 1; i < n; i++)
            {
                same = diff;
                diff = (k-1)*total;
                total = same + diff;
            }

            return total;
        }
    }
}