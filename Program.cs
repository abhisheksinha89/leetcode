using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = new int[,]{
                {0,0,0,0},
                {1,1,0,0},
                {0,1,1,1}
            };

            var ret = SmallestRectangleEnclosingBlackPixel.AreaOfSmallestRect(grid, 1, 0);
        }
    }
}
