using System.Collections.Generic;
using System;

namespace leetcode
{
    public class WiggleSort
    {
        // Explanation:
        // If arr[i] > arr[i+1] and it needs to be greater
        // then we are done.
        // Else we swap arr[i] & arr[i+1] 
        // i++.
        // Now, arr[i+1] needs to be less that arr[i+2]
        // if this is already the case then we are done and we i++.
        // else if arr[i+1] > arr[i+2], 
        // swap arr[i+2] with arr[i+1]. Since arr[i+1] was already 
        // less than arr[i] and arr[i+1] > arr[i+2] then arr[i+2] is 
        // guaranteed to be less than arr[i]!! 
        // So after swapping we are done and now i++
        public static int[] Sort(int[] arr)
        {
            bool greater = false;
            for(int i = 0; i < arr.Length-1; i++)
            {
                greater = !greater;
                if(greater && arr[i] > arr[i+1])
                {
                    continue;
                }
                else if(!greater && arr[i] < arr[i+1])
                {
                    continue;
                }

                int temp = arr[i];
                arr[i] = arr[i+1];
                arr[i+1] = temp;
            }

            return arr;
        }
    }
}