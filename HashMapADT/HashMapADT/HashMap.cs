using System.Collections;
using System.Diagnostics.CodeAnalysis;
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

        public Pair(KeyValuePair<TKey, TValue> KVPair)
        {
            Key = KVPair.Key;
            Value = KVPair.Value;
        }
    }
    public class HashMap<TKey, TValue> : IDictionary<TKey, TValue>
    {
        LinkedList<Pair<TKey, TValue>>[] Buckets;
        private readonly IEqualityComparer<TKey> keyComparer;

        public int Count { get; private set; }

        public ICollection<TKey> Keys { get; }

        public ICollection<TValue> Values { get; }

        public bool IsReadOnly => false;

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

        private void Add(Pair<TKey, TValue> pair)
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

        private bool Remove(TKey key)
        {
            if (key is null) throw new ArgumentNullException($"Key: '{key}' is null.");

            int index = ComputeIndex(key);
            LinkedList<Pair<TKey, TValue>> bucket = Buckets[index];

            foreach (Pair<TKey, TValue> pair in bucket)
            {
                if (!keyComparer.Equals(pair.Key, key)) continue;

                bucket.Remove(pair);
                return true;
            }
            return false;
        }

        public void Add(TKey key, TValue value)
        {
            Add(new Pair<TKey, TValue>(key, value));
        }

        public bool ContainsKey(TKey key)
        {
            int index = ComputeIndex(key);
            if (Buckets[index] is not null) return true;
            return false;
        }

        bool IDictionary<TKey, TValue>.Remove(TKey key)
        {
            return Remove(key);
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            foreach (TKey findKey in Keys)
            {
                if (!keyComparer.Equals(findKey, key)) continue;
                value = GetPair(key).Value;
                return true;
            }
            value = default(TValue);
            return false;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(new Pair<TKey, TValue>(item));
        }

        public void Clear()
        {
            Buckets = [];
            Keys.Clear();
            Values.Clear();
            Count = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            if (!ContainsKey(item.Key)) return false;

            int index = ComputeIndex(item.Key);
            if (Buckets[index].Contains(new Pair<TKey, TValue>(item))) return true;
            return false;
        }

        private KeyValuePair<TKey, TValue>[] ToKVArray(LinkedList<Pair<TKey, TValue>> bucket)
        {
            KeyValuePair<TKey, TValue>[] kvps = new KeyValuePair<TKey, TValue>[bucket.Count];
            int index = 0;
            foreach (Pair<TKey, TValue> pair in bucket)
            {
                kvps[index] = new(pair.Key, pair.Value);
            }
            return kvps;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            int num = 0;
            for (int i = arrayIndex; i < Buckets.Length - arrayIndex; i++)
            {
                foreach (Pair<TKey, TValue> pair in Buckets[i])
                {
                    if (num >= array.Length) throw new ArgumentException("Array is too small.");
                    array[num] = new KeyValuePair<TKey, TValue>(pair.Key, pair.Value);
                    num++;
                }
            }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            LinkedList<Pair<TKey, TValue>> curr = Buckets[0];
            int num = 0;
            while (curr != null)
            {
                foreach(Pair<TKey, TValue> pair in curr)
                {
                    yield return new KeyValuePair<TKey, TValue>(pair.Key, pair.Value);
                }
                num++;
                curr = Buckets[num];  // move onto the next
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

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
