using System;
using System.Collections.Generic;

namespace leetcode
{
    public class GraphValidTree
    {
        public static bool IsValidTree(int n, int[][] edges)
        {
            // Undirected graph is a valid tree if it is
            // connected and no cycles and has only one parent.
            //
            HashSet<int> visited = new HashSet<int>();
            
            if(DFSCycle(0, edges, visited, -1)) return false;

            return visited.Count == n;
        }

        private static bool DFSCycle(int root, int[][] edges, HashSet<int> visited, int parent)
        {
            if(visited.Contains(root) && root != parent) return true;

            visited.Add(root);
            for(int i=0; i < edges[root].Length; i++)
            {
                if(DFSCycle(edges[root][i], edges, visited, root)) return true;
            }

            return false;
        }
    }
}