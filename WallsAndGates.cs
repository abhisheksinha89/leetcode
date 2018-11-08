using System;
using System.Collections.Generic;

namespace leetcode
{
    public class WallsAndGates
    {
        public static void FindPaths(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(matrix[i,j] == 0) 
                    {
                        BFS(matrix, i, j, m, n);
                    }
                }
            }
        }

        private static void BFS(int[,] matrix, int row, int col, int m, int n)
        {
            Queue<Tuple<int, int>> q = new Queue<Tuple<int,int>>();
            q.Enqueue(Tuple.Create(row, col));
            int dist = 0;

            while(q.Count != 0)
            {
                int count = q.Count;
                for(int i = 0; i < count; i++)
                {
                    var pos = q.Dequeue();
                    int r = pos.Item1; int c = pos.Item2;
                    if(r < 0 || c < 0 || r >= m || c >= n) continue;
                    if(matrix[r, c] == -1) continue;
                    if(dist > matrix[r, c]) continue;
                    matrix[r, c] = dist;
                    q.Enqueue(Tuple.Create(r-1, c));
                    q.Enqueue(Tuple.Create(r, c-1));
                    q.Enqueue(Tuple.Create(r, c+1));
                    q.Enqueue(Tuple.Create(r+1, c));
                }
                
                dist++;
            }
        }
    }
}