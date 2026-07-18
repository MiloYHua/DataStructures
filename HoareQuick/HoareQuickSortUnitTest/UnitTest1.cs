using HoareQuick;

namespace HoareQuickSortUnitTest
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
        public void TexTest(int seed)
        {
            Random randy = new Random(seed);

            int[] ints = new int[100];

            for (int j = 0; j < 100; j++)
            {
                ints[j] = randy.Next();
            }

            Sort<int>.QuickSort(ints);
            for (int j = 0; j < 100 - 1; j++)
            {
                Assert.True(ints[j] <= ints[j + 1]);
            }
        }

        [Theory]
		[InlineData(1823049)]
        [InlineData(123123123)]
        [InlineData(123513462)]
		[InlineData(354673)]
		[InlineData(2)]
        [InlineData(1235247)]
		public void SmallerTexTest(int seed)
		{
			Random randy = new Random(seed);

			int[] ints = new int[5];

			for (int j = 0; j < ints.Length; j++)
			{
				ints[j] = randy.Next();
			}

			Sort<int>.QuickSort(ints);
			for (int j = 0; j < ints.Length - 1; j++)
			{
				Assert.True(ints[j] <= ints[j + 1]);
			}
		}
	}
}