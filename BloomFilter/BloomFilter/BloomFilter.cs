using System.Security.Cryptography;

namespace BloomFilter
{
    public class BloomFilter<T>
    {
        public bool[] hashCodeExists = new bool[1000]; // Size of the bit array
        private Func<T, int>[] hashToIndexFuncs = new Func<T, int>[3];

        private int HashToIndexA(T item) => Math.Abs(item.GetHashCode()) % hashCodeExists.Length;
        private int HashToIndexB(T item) => Math.Abs(item.GetHashCode() * 50) % hashCodeExists.Length;
        private int HashToIndexC(T item) => Math.Abs(item.GetHashCode() * 239048843) % hashCodeExists.Length;

        public BloomFilter()
        {
            hashToIndexFuncs[0] = HashToIndexA;
            hashToIndexFuncs[1] = HashToIndexB;
            hashToIndexFuncs[2] = HashToIndexC;
        }

        public void Add(T item)
        {
            foreach(Func<T, int> hashToIndexFunc in hashToIndexFuncs)
            {
                hashCodeExists[hashToIndexFunc(item)] = true;
            }
        }

        public bool ProbablyContains(T item)
        {
            foreach (Func<T, int> hashToIndexFunc in hashToIndexFuncs)
            {
                if (!hashCodeExists[hashToIndexFunc(item)]) return false;
            }
            return true;
        }
    }
}
