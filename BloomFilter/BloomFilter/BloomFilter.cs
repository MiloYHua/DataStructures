using System.Security.Cryptography;

namespace BloomFilter
{
    public class BloomFilter<T>
    {
        public bool[] hashCodeExists = new bool[1000]; // Size of the bit array
        private Func<T, int>[] hashToIndexFuncs = new Func<T, int>[4];

        int DefaultHash(T item) => item.GetHashCode() % hashCodeExists.Length;
        int currentHashFuncIndex = 0;

        public BloomFilter()
        {
            hashToIndexFuncs[0] = DefaultHash;
            currentHashFuncIndex++;
        }

        public void LoadHash(Func<T, int> hashToIndexFunc)
        {
            hashToIndexFuncs[currentHashFuncIndex] = hashToIndexFunc;
            currentHashFuncIndex++;
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
