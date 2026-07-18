using LomutoQuickSort;
using System.Drawing;

namespace LomutoUnitTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1823049)]
        [InlineData(123123123)]
        [InlineData(123513462)]
        [InlineData(354673)]
        [InlineData(2)]
        [InlineData(1235247)]
        public void Test1(int seed)
        {
            Random randy = new Random(seed);

            int[] ints = new int[100];

            for (int j = 0; j < 100; j++)
            {
                ints[j] = randy.Next();
            }

            LomutoQuickSort<int>.QuickSort(ints);
            for (int j = 0; j < 100 - 1; j++)
            {
                Assert.True(ints[j] <= ints[j + 1]);
            }
        }
    }
}