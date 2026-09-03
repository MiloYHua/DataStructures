using HashMapADT;
using System.Globalization;
using System.Text;

namespace HashMapTests
{
    public class Tests
    {
        [Fact]
       
        public void IndexComputingTest()
        {
            string[] names = [  "billy", "bobby", "marker", "jill", "jack", "jose", "jane doe", "john doe", "who?", "hernandez", "john", "bob", "the ceo of life",
                                "theman", "huang", "jenson", "lisa su",
                                "benjamin", "michael jackson", "michael jordan"];

            HashMap<string, int> mapNameIndex = new();

            for (int i = 0; i < names.Length; i++)
            {
                int index = mapNameIndex.ComputeIndex(names[i]);
                int index2 = mapNameIndex.ComputeIndex(names[i]);

                Assert.True(index >= 0 && index < mapNameIndex.Count);
                Assert.Equal(index, index2);
            }
        }

        [Fact]
        public void NewIndexComputingTest()
        {
            string[] names = [  "billy", "bobby", "marker", "jill", "jack", "jose", "jane doe", "john doe", "who?", "hernandez", "john", "bob", "the ceo of life",
                                "theman", "huang", "jenson", "lisa su",
                                "benjamin", "michael jackson", "michael jordan"];

            HashMap<string, int> mapNameIndex = new();

            for (int i = 0; i < names.Length; i++)
            {
                int index = mapNameIndex.ComputeNewIndex(names[i]);
                int index2 = mapNameIndex.ComputeNewIndex(names[i]);

                Assert.True(index >= 0 && index < mapNameIndex.Count * 2);
                Assert.Equal(index, index2);
            }
        }

        [Fact]
        public void GetPairTest()
        {
            HashMap<string, int> map = new();
            KeyValuePair<string, int>[] keyValuePairs = [new KeyValuePair<string, int>("key1", 1), new KeyValuePair<string, int>("key2", 2), new KeyValuePair<string, int>("key3", 3)];

            int num = 0;
            foreach (KeyValuePair<string, int> kvp in keyValuePairs)
            {
                KeyValuePair<string, int> pair = keyValuePairs[num++];
                map.Add(kvp);
                Assert.Equal(pair, kvp);
            }
        }

        [Fact]
        public void GetValueTest()
        {
            HashMap<string, int> map = new();
            KeyValuePair<string, int>[] keyValuePairs = [new KeyValuePair<string, int>("key1", 1), new KeyValuePair<string, int>("key2", 2), new KeyValuePair<string, int>("key3", 3)];

            int num = 0;
            foreach (KeyValuePair<string, int> kvp in keyValuePairs)
            {
                KeyValuePair<string, int> pair = keyValuePairs[num++];
                map.Add(kvp);
                Assert.Equal(pair.Value, kvp.Value);
            }
        }

        [Fact]
        private void AddResizeTest()
        {
            HashMap<string, int> map = new();
            Random random = new Random(42424242); //seed for repeatability
            List<KeyValuePair<string, int>> keyValuePairs = [];

            for (int i = 0; i < 100; i++)
            {
                int value = random.Next(100);
                keyValuePairs.Add(new($"key{i}", value));
            }
        }
    }
}