import subprocess
import heapq


class MedianFinder:
    def __init__(self):
        self.h1 = []
        self.h2 = []

    def addNum(self, num):
        h1, h2 = self.h1, self.h2
        heapq.heappush(h1, -num)
        if(len(h1) > len(h2)+1):
            heapq.heappush(h2, -heapq.heappop(h1))

    def findMedian(self):
        h1, h2 = self.h1, self.h2
        if(len(h1) == len(h2)):
            return (-h1[0] + h2[0])/2
        else:
            return -h1[0]


if __name__ == '__main__':
    s = ['1', '2', '3']
    print("#".join(s))
    mf = MedianFinder()
    mf.addNum(0)
    mf.addNum(6)
    mf.addNum(3)
    mf.addNum(4)
    print(mf.findMedian())
