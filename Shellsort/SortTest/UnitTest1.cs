using Shellsort;

namespace SortTest
{
    public class UnitTest1
    {
        [Fact]
        public void ShellSort()
        {
            Random random = new Random();
            int[] actual = new int[15];

            for (int i = 0; i < actual.Length; i++)
            {
                actual[i] = random.Next(1, 100);
            }

            int[] expected = new int[actual.Length];
            Array.Copy(actual, expected, actual.Length);
            Array.Sort(expected);

            Sort<int>.ShellSort(actual, Comparer<int>.Default);

            Assert.Equal(expected, actual);
        }
    }
}
