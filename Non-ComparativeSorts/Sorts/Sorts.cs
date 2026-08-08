using System.ComponentModel.Design;

namespace Sorts
{
    public class SortCollection
    {
        public static void CountingSort(uint[] nums)
        {
            uint[] buckets = new uint[nums.Length + 1];

            foreach (uint num in nums) buckets[num]++;

            int index = 0;

            for (uint i = 0; i < buckets.Length; i++)
            {
                while (buckets[i] > 0)
                {
                    nums[index++] = i;
                    buckets[i]--;
                }
            }
        }
        public interface IKeyable
        {
            public int Key { get; }
        }
    }
}
