using BloomFilter;

namespace BloomFilterTest
{
    public class Tests
    {
        [Fact]
        public void AddMayContainsTestTest()
        {
            int max = 10;
            Random random = new(10);

            string[] toCompare = new string[max];
            BloomFilter<string> bloomFilter = new();

            for (int i = 0; i < max; i++)
            {
                string next = random.Next().ToString();
                bloomFilter.Add(next);
                toCompare[i] = next;
            }

            foreach (string s in toCompare)
            {
                Assert.True(bloomFilter.ProbablyContains(s));
            }
        }

        [Fact]
        public void LoadHashFuncTest()
        {
            int max = 10;
            Random random = new(10);

            string[] toCompare = new string[max];
            BloomFilter<string> bloomFilter = new();
            for (int i = 0; i < max-1; i++)
            {
                bloomFilter.LoadHash(new Func<string, int>(val => (val.GetHashCode() * i^2)));
            }
            for (int i = 0; i < max; i++)
            {
                string next = random.Next().ToString();
           bloomFilter.Add(next);
                toCompare[i] = next;
            }

            foreach (string s in toCompare)
            {
                Assert.True(bloomFilter.ProbablyContains(s));
            }
        }
    }
}
