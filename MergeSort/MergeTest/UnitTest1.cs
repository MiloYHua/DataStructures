using MergeSort;

namespace MergeTest
{
	public class UnitTest1
	{
		[Theory]
		[InlineData(52)]
        [InlineData(150)]
        [InlineData(123412345)]
        public void Test1(int seed)
		{
			Random randy = new Random(seed);

            List<int> randomList = new List<int>(10);

            for (int i = 0; i < randomList.Count; i++)
			{
                randomList[i] = randy.Next();
			}

			List<int> sortedList = Sorts<int>.MergeSort(randomList);

			Assert.Equal(sortedList, randomList);
		}

		[Theory]
		[InlineData(1000)]
        public void TexTest(int size)
		{
			Random randy = new Random();

			for (int i = 0; i < size; i++)
			{
				List<int> nums = new List<int>(size);
				for (int j = 0; j < size; j++)
				{
					nums.Add(randy.Next(size));
				}

				var output = Sorts<int>.MergeSort(nums);
				for (int j = 0; j < size - 1; j++)
				{
					Assert.True(output[j] <= output[j + 1]);
				}
			}

		}
	}
}