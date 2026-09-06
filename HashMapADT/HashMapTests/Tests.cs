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
                mapNameIndex.Add(new(names[i], i));
            }

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
                mapNameIndex.Add(new(names[i], i));
            }

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
        public void AddResizeContainsKeyTest()
        {
            HashMap<string, int> map = new();
            Random random = new Random(42424242); //seed for repeatability
            List<KeyValuePair<string, int>> keyValuePairs = [];

            int size = map.Count;

            for (int i = 0; i < 100; i++)
            {
                int value = random.Next(100);
                keyValuePairs.Add(new($"key{i}", value));
                map.Add(new($"key{i}", value));
            }

            Assert.True(size < map.Count);

            for (int i = 0; i < map.Count - 1; i++)
            {
                Assert.True(map.ContainsKey(keyValuePairs[i].Key));
                Assert.True(map.Values.Contains(keyValuePairs[i].Value));
            }
        }

        [Fact]
        public void RemoveTest()
        {
            HashMap<string, int> map = new();
            Random random = new Random(42424242); //seed for repeatability
            List<KeyValuePair<string, int>> keyValuePairs = [];
            for (int i = 0; i < 100; i++)
            {
                int value = random.Next(100);
                keyValuePairs.Add(new($"key{i}", value));
                map.Add(new($"key{i}", value));
            }
            for (int i = 0; i < map.Count - 1; i++)
            {
                Assert.True(map.Remove(keyValuePairs[i]));
                Assert.False(map.ContainsKey(keyValuePairs[i].Key));
            }
        }

        [Fact]
        public void TryGetValueTest()
        {
            HashMap<string, int> map = new();
            Random random = new Random(42424242); //seed for repeatability
            List<KeyValuePair<string, int>> keyValuePairs = [];

            for (int i = 0; i < 100; i++)
            {
                int value = random.Next(100);
                keyValuePairs.Add(new($"key{i}", value));
                map.Add(new($"key{i}", value));
            }

            for (int i = 0; i < map.Count - 1; i++)
            {
                Assert.True(map.TryGetValue(keyValuePairs[i].Key, out int value));
                Assert.Equal(keyValuePairs[i].Value, value);
                Assert.False(map.TryGetValue($"nonexistent{i}", out int nonnullvalue));
                Assert.Equal(default, nonnullvalue);
            }
        }

        [Fact]
        public void ClearTest()
        {
            HashMap<string, int> map = new();
            Random random = new Random(42424242); //seed for repeatability
            List<KeyValuePair<string, int>> keyValuePairs = [];

            for (int i = 0; i < 100; i++)
            {
                int value = random.Next(100);
                keyValuePairs.Add(new($"key{i}", value));
                map.Add(new($"key{i}", value));
            }
            Assert.True(map.Count > 0);
            Assert.NotEmpty(map.Keys);
            Assert.NotEmpty(map.Values);
            Assert.True(map.ContainsKey(keyValuePairs[0].Key));
            map.Clear();
            Assert.Empty(map);
            Assert.False(map.ContainsKey(keyValuePairs[0].Key));
            Assert.Empty(map.Keys);
            Assert.Empty(map.Values);
        }

        [Fact]
        public void ContainsTest()
        {
            HashMap<string, int> map = new();
            Random random = new Random(42424242); //seed for repeatability
            List<KeyValuePair<string, int>> keyValuePairs = [];

            for (int i = 0; i < 100; i++)
            {
                int value = random.Next(100);
                keyValuePairs.Add(new($"key{i}", value));
                map.Add(new($"key{i}", value));
            }

            for (int i = 0; i < map.Count - 1; i++)
            {
                Assert.True(map.Contains(keyValuePairs[i]));
                Assert.False(map.Contains(new KeyValuePair<string, int>($"nonexistent{i}", 999)));
            }
        }

        [Fact]
        public void CopyToGetEnumeratorTest()
        {
            HashMap<string, int> map = new();
            Random random = new Random(42424242); //seed for repeatability
            List<KeyValuePair<string, int>> keyValuePairs = [];
            for (int i = 0; i < 100; i++)
            {
                int value = random.Next(100);
                keyValuePairs.Add(new($"key{i}", value));
                map.Add(new($"key{i}", value));
            }
            KeyValuePair<string, int>[] array = new KeyValuePair<string, int>[map.Count];
            map.CopyTo(array, 0);
            for (int i = 0; i < map.Count; i++)
            {
                Assert.True(keyValuePairs.Contains(array[i]));
            }
        }

        [Fact]
        public void IndexingTest()
        {
            HashMap<string, int> map = new();
            Random random = new Random(42424242); //seed for repeatability
            List<KeyValuePair<string, int>> keyValuePairs = [];

            for (int i = 0; i < 100; i++)
            {
                int value = random.Next(100);
                keyValuePairs.Add(new($"key{i}", value));
                map.Add(new($"key{i}", value));
            }

            for (int i = 0; i < map.Count; i++)
            {
                Assert.Equal(map[keyValuePairs[i].Key], keyValuePairs[i].Value);
            }
        }
    }
}