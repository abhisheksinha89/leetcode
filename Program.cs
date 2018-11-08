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
            TreeNode root = new TreeNode(6);
            root.right = new TreeNode(9);
            root.right.left = new TreeNode(7);
            root.right.right = new TreeNode(10);
            root.right.right.right = new TreeNode(11);
            var res = LongestConsecutivePathInBinaryTree.LengthOfLongestPath(root);
        }
    }
}
