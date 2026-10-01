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

			for (int i = 0; i < 500;)
			{
				string randomString = random.Next(1, 10000).ToString();
				if (quickStringFind.Add(randomString))
				{
					i++;
				}
			}

			for (int i = 0; i < 4; i += 2)
			{
				quickStringFind.Union(quickStringFind.Sets[i].First.Value, quickStringFind.Sets[i + 1].First.Value);
			}
			for (int i = 0; i < 4; i += 2)
			{
				Assert.True(quickStringFind.AreConnected(quickStringFind.Sets[i + 1].First.Value, quickStringFind.Sets[i + 1].First.Value));
			}
		}
	}
}
