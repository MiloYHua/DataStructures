using Sorts;

namespace SortTests
{
    public class Tests
    {
        [Fact]
        public void CountingSortTest()
        {
            uint[] nums = { 5, 3, 1, 4, 2 };
            SortCollection.CountingSort(nums);

            Assert.Equal(nums, [ 1, 2, 3, 4, 5]);
        }
    }
}
