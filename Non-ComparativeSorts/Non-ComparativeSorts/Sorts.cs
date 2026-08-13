using System.Data;

namespace Non_ComparativeSorts
{
	public class Sorts<T> where T : IKeyable
	{
		public void PigeonholeSort(List<T> vals)
		{
			Dictionary<int, T> dict = new();
			int[] buckets = new int[vals.Count + 1];

			foreach (T value in vals)
			{
				buckets[value.Key]++;
				dict.Add(value.Key, value);
			}

			int index = 0;

			for (int i = 0; i < buckets.Length; i++)
			{
				while (buckets[i]-- > 0)
				{
					vals[index++] = dict[i];
				}
			}
		}
	}

	public interface IKeyable
	{
		public int Key { get; }
	}
}

//uint maxValue = dataset.GetMaxValue();
//uint[] buckets = new uint[maxValue + 1];

//foreach (int value in dataset)
//{
//	buckets[value]++;
//}

//int dataIndex = 0;
//for (uint i = 0; i < buckets.Length; i++)
//{
//	while (buckets[i]-- > 0)
//	{
//		dataset[dataIndex++] = i;
//	}
//}