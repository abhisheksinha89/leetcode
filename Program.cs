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
            List<Tuple<int, int>> pos = new List<Tuple<int, int>>(){
                Tuple.Create(0,0),
                Tuple.Create(1,1),
                Tuple.Create(1, 0)
            };

            var ret = NumberOfIslandsII.NumOfIslands(3, 3, pos);
        }
    }
}
