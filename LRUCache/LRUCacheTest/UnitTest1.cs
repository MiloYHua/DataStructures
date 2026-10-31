using LRUCache;

namespace LRUCacheTest
{
    public class UnitTest1
    {
        [Fact]
        public void PutTryGetTest()
        {
            int length = 10;
            Random randy = new Random(12);
            LRUCache<int, string> cache = new();
            string[] info = new string[length];

            for (int i = 0; i < length; i++)
            {
                int index = randy.Next(length - 1);
                string val = randy.Next(100).ToString();
                cache.Put(index, val);
                info[index] = val;
            }

            for (int i = 0; i < info.Length; i++)
            {
                string val;
                cache.TryGetValue(i, out val);
                Assert.Equal(info[i], val);
            }
        }
    }
}
