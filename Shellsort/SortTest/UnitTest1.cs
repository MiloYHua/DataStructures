using Shellsort;

namespace SortTest
{
    public class UnitTest1
    {
        [Fact]
        public void ShellSort_SortsIntegersAscending()
        {
            int[] input = [ 5, 3, 8, 1 ];
            int[] expected = new int[input.Length];

            Array.Copy(input, expected, input.Length);
            Array.Sort(expected);

            Sort<int>.ShellSort(input, Comparer<int>.Default);

            Assert.Equal(expected, input);
        }
    }
}
