namespace HashMapADT
{
    public struct Bucket<TKey, TValue>
    {
        public TKey Key { get; }
        public TValue Value { get; }

        public Bucket(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
    public class HashMap<TKey, TValue>
    {
        LinkedList<Bucket<TKey, TValue>> buckets;

        TValue GetValue(TKey key)
        {
            int hashCode = key.GetHashCode();
            int index =
        }
    }
}
