using System.Runtime.CompilerServices;

namespace HashMapADT
{
	public struct Pair<TKey, TValue>
	{
		public TKey Key { get; }
		public TValue Value { get; }

		public Pair(TKey key, TValue value)
		{
			Key = key;
			Value = value;
		}
	}
	public class HashMap<TKey, TValue>
	{
		LinkedList<Pair<TKey, TValue>>[] Buckets;
		private readonly IEqualityComparer<TKey> keyComparer;

		public int Count { get; private set; }

		public HashMap(IEqualityComparer<TKey> comparer, LinkedList<Pair<TKey, TValue>>[] buckets)
		{
			keyComparer = comparer;
			Buckets = buckets;
		}

		public HashMap(LinkedList<Pair<TKey, TValue>>[] buckets)
			: this(EqualityComparer<TKey>.Default, buckets)
		{
			Buckets = buckets;
		}

		public HashMap()
			: this(EqualityComparer<TKey>.Default, [])
		{

		}

		public int ComputeIndex(TKey key)
		{
			int hashCode = key.GetHashCode();
			return Math.Abs(hashCode % Buckets.Length);
		}

		public int ComputeNewIndex(TKey key)
		{
			int hashCode = key.GetHashCode();
			return Math.Abs(hashCode % (Buckets.Length * 2));
		}

		public Pair<TKey, TValue> GetPair(TKey key)
		{
			int index = ComputeIndex(key);

			LinkedList<Pair<TKey, TValue>> bucket = Buckets[index];

			for (int i = 0; i < Buckets.Length; i++)
			{
				Pair<TKey, TValue> pair = bucket.ToArray()[i];

				if (keyComparer.Equals(pair.Key, key)) return pair;
			}
			throw new ArgumentException($"Given key: '{key}' is not found.");
		}

		public TValue GetValue(TKey key)
		{
			return GetPair(key).Value;
		}

		public void Add(Pair<TKey, TValue> pair)
		{
			int index = ComputeIndex(pair.Key);

			if (index >= Buckets.Length)
			{
				Rehash(pair.Key);
			}

			Count++;

			if (Buckets[index] is null || Buckets.Length == 0)
			{
				LinkedList<Pair<TKey, TValue>> toAdd = [];
				toAdd.AddFirst(pair);

				Buckets[index] = toAdd;
				return;
			}
			throw new ArgumentException($"Given key: '{pair.Key}' already exists.");

			void Rehash(TKey key)
			{
				LinkedList<Pair<TKey, TValue>>[] newBuckets = [];

				foreach (LinkedList<Pair<TKey, TValue>> bucket in Buckets)
				{
					if (bucket is null) continue;

					newBuckets[ComputeNewIndex(key)] = bucket;
				}
				Buckets = newBuckets;
			}
		}

		public void Remove(TKey key)
		{
			if (key is null) throw new ArgumentNullException($"Key: '{key}' is null.");

			int index = ComputeIndex(key);
			LinkedList<Pair<TKey, TValue>> bucket = Buckets[index];

			foreach (Pair<TKey, TValue> pair in bucket)
			{
				if (!keyComparer.Equals(pair.Key, key)) continue;

				bucket.Remove(pair);
				return;
			}
			throw new KeyNotFoundException($"Key: '{key}' was not found.");
		}

		public TValue this[TKey key]
		{
			get => GetValue(key);
			set
			{
				int index = ComputeIndex(key);

				LinkedList<Pair<TKey, TValue>> bucket = Buckets[index];

				for (int i = 0; i < Buckets.Length; i++)
				{
					Pair<TKey, TValue> pair = bucket.ToArray()[i];

					if (keyComparer.Equals(pair.Key, key)) pair = new Pair<TKey, TValue>(key, value);
					return;
				}
				bucket.AddFirst(new Pair<TKey, TValue>(key, value));
			}
		}
	}
}
