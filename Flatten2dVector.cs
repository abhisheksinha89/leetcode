using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode
{
    public class Flatten2dVector
    {
        List<List<int>> vector;

        int row = 0;
        int col = 0;

        public Flatten2dVector(List<List<int>> vector)
        {
            this.vector = vector;
        }

        public int Next()
        {
            // return the next int
            // int ret = vector[row][col];
            // if(col >= vector[row].Count-1) 
            // {
            //     col = 0;
            //     row++;
            // }
            // else
            // {
            //     col++;
            // }

            // return ret;

            int ret = vector[row][col];
            col++;
            return ret;
        }

        public bool HasNext()
        {
            // while(row < vector.Count && vector[row].Count == 0)
            // {
            //     row++;
            // }

            while(row < vector.Count && col >= vector[row].Count)
            {
                col = 0;
                row++;
            }

            if(row >= vector.Count) return false;
            return true;
        }
    }
}