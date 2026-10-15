using System;
using System.Collections.Generic;
using System.Text;
using UnionFind;

namespace UnionFindTest
{
    public class QuickUnionTest
    {
        [Fact]
        public void FindAddTest()
        {
            Random random = new Random(2);
            QuickUnion<string> quickStringFind = new();

            for (int i = 0; i < 100;)
            {
                string randomString = random.Next(1, 10000).ToString();
                if (quickStringFind.Add(randomString))
                {
                    Assert.Equal(i, quickStringFind.Find(quickStringFind.indexToParent[i]));
                    i++;
                }
            }
        }

        int[] MakeArray(int max)
        {
            int[] pool = new int[max];
            for (int i = 1; i < max + 1; i++)
            {
                pool[i-1] = i;
            }
            return pool;
        }

        int FindUniqueRandom(ref int[] pool)
        {
            Random randy = new Random();

            List<int> listPool = pool.ToList();
            int num = randy.Next(pool.Length);
            int removed = listPool[num];
            listPool.RemoveAt(num);
            pool = listPool.ToArray();
            return removed;
        }

        [Fact]
        public void UnionAreConnectedTest()
        {
            Random random = new Random(2);
            QuickUnion<string> quickStringFind = new();
            int[] pool = MakeArray(10);

            for (int i = 0; i < 10; i++)
            {
                string randomString = FindUniqueRandom(ref pool).ToString();
                quickStringFind.Add(randomString);
            }

            for (int i = 0; i < 4; i += 2)
            {
                quickStringFind.Union(quickStringFind.indexToParent[i], quickStringFind.indexToParent[i + 1]);
            }
            for (int i = 0; i < 4; i += 2)
            {
                Assert.True(quickStringFind.AreConnected(quickStringFind.indexToParent[i], quickStringFind.indexToParent[i + 1]));
            }
        }
    }
}
