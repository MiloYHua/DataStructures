using UnionFind;

namespace QuickFindTest
{
    public class QuickFindTests
    {
        [Fact]
        public void FindAddTest()
        {
            Random random = new Random(2);
            QuickFind<string> quickStringFind = new();

            for (int i = 0; i < 100;)
            {
                string randomString = random.Next(1, 10000).ToString();
                if (quickStringFind.Add(randomString))
                {
                    Assert.Equal(i, quickStringFind.Find(randomString));
                    i++;
                }
            }
        }

        [Fact]
        public void UnionAreConnectedTest()
        {
            Random random = new Random(2);
            QuickFind<string> quickStringFind = new();

            for (int i = 0; i < 16;)
            {
                string randomString = random.Next(1, 10000).ToString();
                if (quickStringFind.Add(randomString))
                {
                    i++;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                string a = quickStringFind.Sets[i].First.Value;
                for (int x = 0; x < 4; x++)
                {
                    quickStringFind.Union(a, quickStringFind.Sets[x].First.Value);
                }
            }

            for (int i = 0; i < 4; i++)
            {
                string a = quickStringFind.Sets[i].First.Value;
                for (int x = 0; x < 4; x++)
                {
                    Assert.True(quickStringFind.AreConnected(a, quickStringFind.Sets[x].First.Value));
                }
            }
        }
    }
}
