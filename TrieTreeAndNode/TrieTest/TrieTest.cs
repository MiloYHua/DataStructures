using System.Runtime.ExceptionServices;
using TrieTreeAndNode;

namespace TrieTest
{
    public class TrieTest
    {
        [Theory]
        [InlineData([1234234, 513834426, 134623547, 39456546, 4112346, 48356, 67246])]
        [InlineData([723457, 23462468, 2346134, 74236982, 3652436, 23824582, 2432357])]
        public void InsertContainsAndSearchTest(params int[] seeds)
        {
            TrieTree trie = new TrieTree();
            for (int i = 0; i < seeds.Length; i++)
            {
                Random random = new Random(seeds[i]);
                for (int y = 0; y < 10; y++)
                {
                    string word = random.NextInt64().ToString();
                    trie.Insert(word);
                    Assert.True(trie.Contains(word));
                }
            }
        }

        [Theory]
        [InlineData([12384, 541389, 1239841, 18592, 123948, 51782923, 152838])]
        [InlineData([2923434, 619374, 6245848, 31481346, 7318513, 5782345])]
        public void RemoveTest(params int[] seeds)
        {
            TrieTree trie = new TrieTree();
            for (int i = 0; i < seeds.Length; i++)
            {
                Random random = new Random(seeds[i]);
                for (int y = 0; y < 10; y++)
                {
                    string word = random.NextInt64().ToString();
                    trie.Insert(word);
                    Assert.True(trie.Remove(word));
                }
            }
        }

        [Theory]
        [InlineData([3457345, 1374513, 51361347, 42513456, 45682246, 5372527])]
        [InlineData([234812356, 24587214123, 2345724, 13246137645, 132571346, 2345724357])]
        public void SingleGetAllMatchingPrefixTest(params int[] seeds)
        {
            for (int i = 0; i < seeds.Length; i++)
            {
                Random random = new Random(seeds[i]);
                for (int y = 0; y < 10; y++)
                {
                    List<string> suffixes = new List<string>();
                    List<string> words = new List<string>();
                    string prefix = random.NextInt64().ToString();
                    for (int x = 0; x < 3; x++)
                    {
                        TrieTree trie = new TrieTree();
                        suffixes.Add(random.NextInt64().ToString());
                        words.Add(prefix + suffixes[x]);
                        trie.Insert(words[x]);
                        Assert.Equal(trie.GetAllMatchingPrefix(prefix)[0], words[x]);
                    }
                }
            }
        }
        [Theory]
        [InlineData([3457345, 1374513, 51361347, 42513456, 45682246, 5372527])]
        [InlineData([234812356, 24587214123, 2345724, 13246137645, 132571346, 2345724357])]
        public void GetAllMatchingPrefixTest(params int[] seeds)
        {
            for (int i = 0; i < seeds.Length; i++)
            {
                Random random = new Random(seeds[i]);
                for (int y = 0; y < 10; y++)
                {
                    TrieTree trie = new TrieTree();
                    List<string> words = new List<string>();
                    string prefix = random.NextInt64().ToString();

                    for (int x = 0; x < 3; x++)
                    {
                        words.Add(prefix + random.NextInt64().ToString());
                        trie.Insert(words[x]);
                    }

                    List<string> matches = trie.GetAllMatchingPrefix(prefix);

                    foreach (string word in words)
                    {
                        Assert.Contains(word, matches);
                    }
                }
            }
        }
        //alex a apple alexander alexa        

        //prefix: alexa
        //
    }
}
