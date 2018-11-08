using System.Collections.Generic;
using System;

namespace leetcode
{
    public class LongestConsecutivePathInBinaryTree
    {
        private static int maxLen = 0;

        public static int LengthOfLongestPath(TreeNode root)
        {
            maxLen = 0;
            if (root == null) return maxLen;
            Helper(root, 1);
            return maxLen;
        }

        private static void Helper(TreeNode root, int currLen)
        {
            if (root == null) return;
            maxLen = Math.Max(currLen, maxLen);
            if (root.left != null && root.left.val == root.val + 1) Helper(root.left, currLen + 1);
            else Helper(root.left, 1);
            if (root.right != null && root.right.val == root.val + 1) Helper(root.right, currLen + 1);
            else Helper(root.right, 1);
        }
    }
}