using Non_ComparativeSorts;
using System.Text;

namespace SortTests
{
	public class Tests
	{
		[Theory]
		[InlineData(123,42345,73451,34656,235435,56834545,762435,762345,643265)]
		[InlineData(654,24567,48754,53246,46823,52345,6798,2345234,6867,2345)]
		public void PigeonholeTest(params int[] ints)
		{
			foreach(int seed in ints)
			{
				string[] names = ["billy", "johnny", "claude", "code", "bobby", "alex", "brandon", "the guy", "john", "guy", "dude", "lolz"];
				List<Pigeon> pigeons = new List<Pigeon>(names.Length);
				Random randy = new Random(seed);
				HashSet<int> seen = new HashSet<int>();

				while(true) //change
				{
					int num = randy.Next(names.Length - 1);
					if (seen.Contains(num)) continue;
						seen.Add(num);
					string name = names[num];
					pigeons[num] = new Pigeon(num, name);
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
