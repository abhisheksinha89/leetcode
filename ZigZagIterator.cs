using System;
using System.Collections.Generic;

namespace leetcode
{
    public class ZigZagIterator
    {
        private class ListMeta
        {
            public int IdxOfList;
            public int IdxOfElemWithinList;

            public ListMeta(int idxOfList, int idxOfElemWithinList)
            {
                this.IdxOfList = idxOfList;
                this.IdxOfElemWithinList = idxOfElemWithinList;
            }
        }

        private List<List<int>> lists;
        private Queue<ListMeta> q;

        public ZigZagIterator(List<List<int>> lists)
        {
            this.lists = lists;
            q = new Queue<ListMeta>();
            for(int i = 0; i < lists.Count; i++)
            {
                if(lists[i].Count > 0)
                    q.Enqueue(new ListMeta(i, 0));
            }
        }


        public int Next()
        {
            ListMeta lm = q.Dequeue();
            int ret = this.lists[lm.IdxOfList][lm.IdxOfElemWithinList];
            lm.IdxOfElemWithinList++;
            if(lm.IdxOfElemWithinList < this.lists[lm.IdxOfList].Count) q.Enqueue(lm);
            return ret;
        }

        public bool HasNext()
        {
            return q.Count > 0;
        }
    }
}