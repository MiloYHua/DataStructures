namespace Shellsort
{
    public static class Sort<T>
    {
        private static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public static void ShellSort(T[] collection, IComparer<T> comparer)
        {
            for (int i = 1; i < collection.Length; i++)
            {
                int gap = collection.Length / (int)Math.Pow(2, i);
                if (gap == 0) gap = 1;

                for (int j = gap; j < collection.Length; j += gap)
                {
                    if (comparer.Compare(collection[j], collection[j - gap]) > 0)
                    {
                        Swap(ref collection[j], ref collection[j - gap]);
                    }
                }
            }
        }
    }
}
