using System.Security.Cryptography;

namespace BloomFilter
{
    public class BloomFilter<T>
    {
        public bool[] hashCodeExists = new bool[1000]; // Size of the bit array
        private List<Func<T, int>> hashToIndexFuncs = [];

        int DefaultHash(T item) => item.GetHashCode();

        public BloomFilter()
        {
            hashToIndexFuncs.Add(DefaultHash);
        }

        public void LoadHash(Func<T, int> hashToIndexFunc)
        {
            hashToIndexFuncs.Add(hashToIndexFunc);
        }

        public void Add(T item)
        {
            foreach(Func<T, int> hashToIndexFunc in hashToIndexFuncs)
            {
                hashCodeExists[Math.Abs(hashToIndexFunc(item)) % hashCodeExists.Length] = true;
            }
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              

        public bool ProbablyContains(T item)
        {
            foreach (Func<T, int> hashToIndexFunc in hashToIndexFuncs)
            {
                if (!hashCodeExists[Math.Abs(hashToIndexFunc(item)) % hashCodeExists.Length]) return false;
            }
            return true;
        }
    }
}