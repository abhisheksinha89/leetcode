using System.Collections.Generic;
using System;

namespace leetcode
{
    public class ClosestBSTValue
    {
        public static int ClosestValue(TreeNode root, int target)
        {
            if(root == null) throw new ArgumentNullException("root");

            int diff = Int32.MaxValue;
            int closest = 0;

            while(root != null)
            {
                if(Math.Abs(target - root.val) < diff)
                {
                    diff = Math.Abs(target - root.val);
                    closest = root.val;
                }

                if(target == root.val) break;
                else if(target < root.val) root = root.left;
                else root = root.right;
            }

            /* Recursive */
            // FindClosest(root, ref diff, ref closest, target);

            return closest;
        }

        private static void FindClosest(TreeNode root, ref int diff, ref int closest, int target)
        {
            if(root == null) return;

            if(Math.Abs(target - root.val) < diff) 
            {
                closest = root.val;
                diff = Math.Abs(target-root.val);
            }

            if(root.val == target) return;
            if(root.val > target) FindClosest(root.left, ref diff, ref closest, target);
            else FindClosest(root.right, ref diff, ref closest, target);
        }
    }
}