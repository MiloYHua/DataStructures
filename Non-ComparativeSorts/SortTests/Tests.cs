using Non_ComparativeSorts;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Xunit.Sdk;

namespace SortTests
{
    public class Tests
    {
        [Fact]
        public void RadixTest()
        {
			Random randy = new Random();

			List<Pigeon> pigeons = [];
			HashSet<int> seen = [];

			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < 10; i++)
			{
				pigeons.Add(new(GenerateUnique(randy, seen, 10)-1, $"Billy Johnson {sb}"));

				sb.Append("I");
			}

			List<int> sortedKeys = Sorts<Pigeon>.RadixSort(pigeons);

			for (int i = 0; i < pigeons.Count; i++)
			{
				Assert.Equal(i, sortedKeys[i]);
			}
		}

        [Fact]
        public void BucketSortTest()
        {
            Random randy = new Random();

            List<Pigeon> pigeons = [];
            HashSet<int> seen = [];

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                pigeons.Add(new(GenerateUnique(randy, seen, 10), $"Billy Johnson {sb}"));

                sb.Append("I");
            }

            List<int> keysForDebugView = [];
            foreach (Pigeon pigeon in pigeons)
            {
                keysForDebugView.Add(pigeon.Key);
            }

            Sorts<Pigeon>.BucketSort(pigeons);

            for (int i = 0; i < pigeons.Count; i++)
            {
                Assert.Equal(i + 1, pigeons[i].Key);
            }
        }
        public int GenerateUnique(Random randy, HashSet<int> seen, int limit)
        {
            while (true)
            {
                int next = randy.Next(limit) + 1;
                if (seen.Contains(next)) continue;
                seen.Add(next);
                return next;
            }
        }

        [Theory]
        [InlineData(123, 42345, 73451, 34656, 235435, 56834545, 762435, 762345, 643265)]
        [InlineData(654, 24567, 48754, 53246, 46823, 52345, 6798, 2345234, 6867, 2345)]
        public void PigeonholeTest(params int[] ints)
        {
            foreach (int seed in ints)
            {
                string[] names = ["billy", "johnny", "claude", "code", "bobby", "alex", "brandon", "the guy", "john", "guy", "dude", "lolz"];
                List<Pigeon> pigeons = new List<Pigeon>(names.Length);
                Random randy = new Random(seed);
                HashSet<int> seen = new HashSet<int>();

                for (int i = 0; i < names.Length; i++)
                {
                    int num = GenerateUnique(randy, seen, names.Length);

                    string name = names[num - 1];
                    pigeons.Add(new Pigeon(num, name));
                }

                Sorts<Pigeon>.PigeonholeSort(pigeons);

                for (int i = 0; i < pigeons.Count; i++)
                {
                    Assert.Equal(i + 1, pigeons[i].Key);
                }
            }
        }
    }

    public class Pigeon : IKeyable
    {
        public int Key { get; }

        public string Name { get; }

        public Pigeon(int key, string name)
        {
            Key = key;
            Name = name;
        }
    }
}
