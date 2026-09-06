using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace HashMapADT
{
    public class HashMap<TKey, TValue> : IDictionary<TKey, TValue>
    {
        LinkedList<KeyValuePair<TKey, TValue>>[] Buckets;
        private readonly IEqualityComparer<TKey> keyComparer;

        public int Count { get; private set; }

        public ICollection<TKey> Keys { get; } = [];

        public ICollection<TValue> Values { get; } = [];

        public bool IsReadOnly => false;

        public HashMap(IEqualityComparer<TKey> comparer, LinkedList<KeyValuePair<TKey, TValue>>[] buckets)
        {
            keyComparer = comparer;
            Buckets = buckets;
            Count = buckets.Length;
        }

        public HashMap(LinkedList<KeyValuePair<TKey, TValue>>[] buckets)
            : this(EqualityComparer<TKey>.Default, buckets)
        {
            Buckets = buckets;
            Count = buckets.Length;
        }

        public HashMap()
            : this(EqualityComparer<TKey>.Default, [])
        {
            Buckets = new LinkedList<KeyValuePair<TKey, TValue>>[8];
            Count = 0;
        }

        public int ComputeIndex(TKey key)
        {
            if (Buckets.Length < 0) throw new ArgumentException("Bucket was empty");
            int hashCode = key.GetHashCode();
            return Math.Abs(hashCode % Buckets.Length);
        }

        public int ComputeNewIndex(TKey key)
        {
            int hashCode = key.GetHashCode();
            return Math.Abs(hashCode % (Buckets.Length * 2));
        }

        public KeyValuePair<TKey, TValue> GetPair(TKey key)
        {
            int index = ComputeIndex(key);

            LinkedList<KeyValuePair<TKey, TValue>> bucket = Buckets[index];

            for (int i = 0; i < bucket.Count; i++)
            {
                KeyValuePair<TKey, TValue> KeyValuePair = bucket.ToArray()[i];

                if (keyComparer.Equals(KeyValuePair.Key, key))
                    return KeyValuePair;
            }
            throw new ArgumentException($"Given key: '{key}' is not found.");
        }

        public TValue GetValue(TKey key)
        {
            return GetPair(key).Value;
        }

        public void Add(TKey key, TValue value)
        {
            Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool ContainsKey(TKey key)
        {
            if (Buckets.Length == 0) return false;
            int index = ComputeIndex(key);
            LinkedList<KeyValuePair<TKey, TValue>> bucket = Buckets[index];

            foreach (KeyValuePair<TKey, TValue> kvp in bucket)
            {
                if (keyComparer.Equals(kvp.Key, key)) return true;
            }

            return false;
        }

        public bool Remove(TKey key)
        {
            if (key is null) throw new ArgumentNullException($"Key: '{key}' is null.");

            int index = ComputeIndex(key);
            LinkedList<KeyValuePair<TKey, TValue>> bucket = Buckets[index];

            foreach (KeyValuePair<TKey, TValue> KeyValuePair in bucket)
            {
                if (!keyComparer.Equals(KeyValuePair.Key, key)) continue;

                bucket.Remove(KeyValuePair);
                Values.Remove(KeyValuePair.Value);
                Keys.Remove(KeyValuePair.Key);
                return true;
            }
            return false;
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            foreach (TKey findKey in Keys)
            {
                if (!keyComparer.Equals(findKey, key)) continue;
                value = GetPair(findKey).Value;
                return true;
            }
            value = default(TValue);
            return false;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            int index = ComputeIndex(item.Key);

            if (index >= Buckets.Length)
            {
                Rehash(item.Key);
            }

            Count++;

            if (Buckets[index] is null)
            {
                LinkedList<KeyValuePair<TKey, TValue>> toAdd = [];
                toAdd.AddFirst(item);

                Buckets[index] = toAdd;
                Keys.Add(item.Key);
                Values.Add(item.Value);
                return;
            }
            if (Contains(item))
            {
                throw new ArgumentException($"Given value: '{item.Value}' already exists.");
            }
            Buckets[index].AddFirst(item);
            Keys.Add(item.Key);
            Values.Add(item.Value);
            return;

            void Rehash(TKey key)
            {
                LinkedList<KeyValuePair<TKey, TValue>>[] newBuckets = [];

                foreach (LinkedList<KeyValuePair<TKey, TValue>> bucket in Buckets)
                {
                    if (bucket is null) continue;

                    newBuckets[ComputeNewIndex(key)] = bucket;
                }
                Buckets = newBuckets;
            }
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
            if (Buckets[index].Contains(item)) return true;
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            foreach (var pair in this)
            {
                array[arrayIndex++] = pair;
            }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (LinkedList<KeyValuePair<TKey, TValue>> bucket in Buckets)
            {
                if (bucket is null) continue;
                foreach (KeyValuePair<TKey, TValue> KeyValuePair in bucket)
                {
                    yield return new KeyValuePair<TKey, TValue>(KeyValuePair.Key, KeyValuePair.Value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public TValue this[TKey key]
        {
            get => GetValue(key);
            set
            {
                int index = ComputeIndex(key);

                LinkedList<KeyValuePair<TKey, TValue>> bucket = Buckets[index];

                for (int i = 0; i < Buckets.Length; i++)
                {
                    KeyValuePair<TKey, TValue> KeyValuePair = bucket.ToArray()[i];

                    if (keyComparer.Equals(KeyValuePair.Key, key))
                    {
                        KeyValuePair = new KeyValuePair<TKey, TValue>(key, value);
                        return;
                    }
                }
                bucket.AddFirst(new KeyValuePair<TKey, TValue>(key, value));
            }
        }
    }
}
