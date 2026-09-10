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
                for (int j = i; j >= 0; j--)
                {
                    if(j == 0)
                    {
                        ;
                    }
                    int gap = collection.Length / (int)Math.Pow(2, i);

                    if (comparer.Compare(collection[j], collection[j + (1 * gap)]) > 0)
                    {
                        Swap(ref collection[j], ref collection[j + (1 * gap)]);
                    }
                }
            }
        }
    }
}
