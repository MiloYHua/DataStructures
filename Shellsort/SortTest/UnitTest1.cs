using Shellsort;

namespace SortTest
{
    public class UnitTest1
    {
        [Fact]
        public void ShellSort()
        {
            Random random = new Random();
            List<int> actual = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                actual.Add(random.Next(1, 100));
            }

            int[] expected = actual.ToArray();
            Array.Sort(expected);

            Sort<int>.ShellSort(actual.ToArray(), Comparer<int>.Default);

            Assert.Equal(expected, actual);
        }
    }
}
