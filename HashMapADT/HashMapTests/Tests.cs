using HashMapADT;
using System.Text;

namespace HashMapTests
{
	public class Tests
	{
		[Fact]
		public void IndexComputingTest()
		{
			string[] names = [	"billy", "bobby", "marker", "jill", "jack", "jose", "hernandez", "john", "bob", "six seven man", "the ceo",
								"theman", "british guy", "mao zedong", "xi jinping", "putin", "stalin", "kim jong un", "huang", "jenson", "lisa su",
								"nikita", "trump", "biden", "mamdani", "texas texico bonhambuger", "stan", "benjamin", "michael jackson", "michael jordan"];

			HashMap<string, int> mapNameIndex = new();
			Random random = new Random();

			string name = names[random.Next(names.Length)];
			int index = random.Next(100);
            mapNameIndex[name] = index;
			mapNameIndex.ContainsKey(name);
			mapNameIndex.ComputeIndex(name);
		}
	}
}