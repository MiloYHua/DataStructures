using System.Security.AccessControl;

namespace LRUCache
{
    public interface ICache<TKey, TValue>
    {
        bool TryGetValue(TKey key, out TValue value);
        void Put(TKey key, TValue value);
    }

    public class LRUCache<TKey, TValue> : ICache<TKey, TValue>
    {
        public LinkedList<KeyValuePair<TKey, TValue>> lruList;
        public Dictionary<TKey, TValue> cache;

       public LRUCache()
        {
            lruList = [];
            cache = [];
        }

        public void Put(TKey key, TValue value)
        {
            if (key is null) throw new ArgumentNullException($"{nameof(key)} is null");
            if (value is null) throw new ArgumentNullException($"{nameof(value)} is null");
            if (cache.ContainsKey(key))
            {
                cache[key] = value;
            }
            else
            {
                cache.Add(key, value);
                lruList.AddFirst(new KeyValuePair<TKey, TValue>(key, value));
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (cache.ContainsKey(key))
            {
                value = cache[key];
                lruList.Remove(new KeyValuePair<TKey, TValue>(key, value));
                lruList.AddLast(new KeyValuePair<TKey, TValue>(key, value));
                return true;
            }
            value = default;
            return false;
        }


    }
}
