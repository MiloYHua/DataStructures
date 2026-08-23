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
        readonly LinkedList<Pair<TKey, TValue>>[] buckets;
        private readonly IEqualityComparer<TKey> keyComparer;

        public HashMap(IEqualityComparer<TKey> comparer)
        {
            keyComparer = comparer;

            /* rest of the constructor goes here */
        }

        public HashMap()
            : this(EqualityComparer<TKey>.Default)
        {
            /* rest of the constructor goes here */
        }

        public int ComputeIndex(TKey key)
        {
            int hashCode = key.GetHashCode();
            return Math.Abs(hashCode % buckets.Length);
        }

        public int ComputeNewIndex(TKey key)
        {
            int hashCode = key.GetHashCode();
            return Math.Abs(hashCode % buckets.Length * 2);
        }

        public TValue GetValue(TKey key)
        {
            int index = ComputeIndex(key);

            LinkedList<Pair<TKey, TValue>> bucket = buckets[index];

            foreach (Pair<TKey, TValue> pair in bucket)
            {
                if (keyComparer.Equals(pair.Key, key)) return pair.Value;
            }
            throw new ArgumentException($"Given key: '{key}' is not found.");
        }

        public void Add(Pair<TKey, TValue> pair)
        {
            int index = ComputeIndex(pair.Key);


            if (buckets[index] is null || buckets.Length == 0)
            {
                LinkedList<Pair<TKey, TValue>> toAdd = [];
                toAdd.AddFirst(pair);

                buckets[index] = toAdd;
            }
            throw new ArgumentException($"Given key: '{pair.Key}' already exists.");

            void Rehash()
            {
                LinkedList<Pair<TKey, TValue>>[] newList = [];

                foreach(LinkedList<Pair<TKey, TValue>> bucket in buckets)
                {
                    if (bucket is null) continue;
                    newList[ComputeNewIndex(bucket.)]
                }
            }
        }
    }
}
