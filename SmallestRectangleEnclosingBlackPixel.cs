using System;
using System.Collections.Generic;

namespace leetcode
{

    // The below solution take O(m*n) time in the worst case
    // Another optimized solution is O(n*logm + m*logn)
    // Explanation of the optimized solution:
    //      Binary search the top part of the given grid. 
    //      If any of the rows in the top part has a 1 then we continue binary
    //      search till we find the boundary of the top part.
    //
    //      Repeat the same for the bottom, left and right parts.
    //      Once boundary is found we can calculate the area
    //      Ex:
    //      
    // private int binarySearch(char[][] image, int lo, int hi, int min, int max, boolean searchHorizontal, boolean searchLo) {
    //     while(lo < hi) {
    //         int mid = lo + (hi - lo) / 2;
    //         boolean hasBlackPixel = false;
    //         for(int i = min; i < max; i++) {
    //             if((searchHorizontal ? image[i][mid] : image[mid][i]) == '1') {
    //                 hasBlackPixel = true;
    //                 break;
    //             }
    //         }
    //         if(hasBlackPixel == searchLo) {
    //             hi = mid;
    //         } else {
    //             lo = mid + 1;
    //         }
    //     }
    //     return lo;
    // }
    public class SmallestRectangleEnclosingBlackPixel
    {
        private class Point
        {
            public int r;
            public int c;

            public Point(int r, int c)
            {
                this.r = r;
                this.c = c;
            }
        }

        public static int AreaOfSmallestRect(int[,] grid, int x, int y)
        {
            // Do a BFS to get the left and right-most coordinates 
            // As well as get the top and bottom-most coordinates
            // Ans will be (right-left)*(bottom-top)
            //
            Queue<Point> q = new Queue<Point>();
            q.Enqueue(new Point(x, y));
            HashSet<int> visited = new HashSet<int>();

            int cleft = grid.GetLength(1); int cright = 0; int rtop = grid.GetLength(0); int rbottom = 0;
            while (q.Count > 0)
            {
                Point p = q.Dequeue();
                if (p.r < 0 || p.r >= grid.GetLength(0) || p.c < 0 || p.c >= grid.GetLength(1) || grid[p.r, p.c] != 1)
                    continue;
                if (visited.Contains(p.r * grid.GetLength(1) + p.c)) continue;
                visited.Add(p.r * grid.GetLength(1) + p.c);

                cleft = Math.Min(cleft, p.c); cright = Math.Max(cright, p.c);
                rtop = Math.Min(rtop, p.r); rbottom = Math.Max(rbottom, p.r);

                q.Enqueue(new Point(p.r - 1, p.c));
                q.Enqueue(new Point(p.r + 1, p.c));
                q.Enqueue(new Point(p.r, p.c - 1));
                q.Enqueue(new Point(p.r, p.c + 1));
            }

            return (cright - cleft + 1) * (rbottom - rtop + 1);
        }
    }
}