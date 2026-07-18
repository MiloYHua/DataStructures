using SkipList;

namespace SkipListTest
{
    public class Tests
    {

        [Theory]
        [InlineData(23453457)]
        [InlineData(3456)]
        public void InsertTest(int seed)
        {
            SkipList<int> skipList = new SkipList<int>();
            int[] ints = new int[100];
            Random random = new Random(seed);
            for (int y = 0; y < 100; y++)
            {
                ints[y] = random.Next(int.MaxValue);
                skipList.Insert(ints[y]);
                Assert.True(skipList.Search(ints[y]) is not null);
            }
        }

        [Theory]
        [InlineData(12341234)]
        [InlineData(28394789)]
        public void SearchTest(int seed)
        {
            SkipList<int> skipList = new SkipList<int>();
            int[] ints = new int[100];
            Random random = new Random(seed);
            for (int y = 0; y < 100; y++)
            {
                ints[y] = random.Next(int.MaxValue);
                skipList.Insert(ints[y]);
                Assert.True(skipList.Search(ints[y]) is not null);
            }
        }

        [Theory]
        [InlineData(274576)]
        [InlineData(42856245)]
        public void RemoveTest(int seed)
        {
            SkipList<int> skipList = new SkipList<int>();
            int[] ints = new int[100];
            Random random = new Random(seed);
            for(int i = 0; i < 100; i++)
            {
                ints[i] = random.Next(int.MaxValue);
                skipList.Insert(ints[i]);
                Assert.True(skipList.Remove(ints[i]));
            }    
        }
    }
}
