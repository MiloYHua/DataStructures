using System.Data;
using System.Runtime.Versioning;
using System.Security;

namespace Non_ComparativeSorts
{
	public class Sorts<T> where T : IKeyable
	{
		public static void PigeonholeSort(List<T> vals)
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

		private static T IdentifyBiggest(List<T> vals)
		{
			T biggest = vals[0];
			foreach (T val in vals)
			{
				if (biggest.Key < val.Key) biggest = val;
			}
			return biggest;
		}

		private static int FindBucket(int val, int range)
		{
			int indexer = 0;
			int bucket = 0;
			while (indexer < val)
			{
				indexer += range;
				bucket++;
			}
			return bucket;
		}

		private static List<T>[] SectionVals(List<T> vals, int maxVal)
		{
			List<T>[] toReturn = new List<T>[vals.Count];

			for (int i = 0; i < toReturn.Length; i++)
			{
				toReturn[i] = [];
			}

			int range = maxVal / vals.Count;

			foreach (T val in vals)
			{
				int bucketIndex = FindBucket(val.Key, range);

				toReturn[bucketIndex - 1].Add(val);
			}

			foreach (List<T> values in toReturn)
			{
				values.Sort();
			}
			return toReturn;
		}

		public static void BucketSort(List<T> vals)
		{
			int biggestKey = IdentifyBiggest(vals).Key;
			List<T>[] sortedSections = SectionVals(vals, biggestKey);
			List<T> combiner = [];

			foreach (List<T> section in sortedSections)
			{
				combiner.AddRange(section);
			}

			for (int i = 0; i < sortedSections.Length; i++)
			{
				vals[i] = combiner[i];
			}
		}

		public static List<int> RadixSort(List<T> vals)
		{
			Dictionary<int, T> keyToKeyable = [];

			List<int> result = [];
			int[] key = new int[10];

			int biggest = IdentifyBiggest(vals).Key;
			int digits = (int)Math.Ceiling(Math.Log10(biggest));

			foreach (T val in vals)
			{
				result.Add(val.Key);
			}

			for (int i = 0; i < digits; i++)
			{
				foreach (int val in result)
				{
					int digit1 = val % 10;

					key[digit1]++;
				}

				int prev = 0;

				for (int x = 0; x < key.Length; x++)
				{
					key[x] += prev;
					prev = key[x];
				}

				List<int> temp = [];
				foreach(int val in result)
				{
					temp.Add(val);
				}

				foreach (int val in result)
				{
					int index = key[val] - 1;
					temp[index] = val;
				}

				result = temp;
			}
			return result;
		}
	}

	public interface IKeyable
	{
		public int Key { get; }
	}
}