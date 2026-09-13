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
            //looping from 0 to second to last index to be able to compare a value in front of the current index
            for (int i = 0; i < collection.Length - 1; i++)
            {
                int gap = collection.Length / (int)Math.Pow(2, i + 1);
                if (gap == 0) gap = 1;

                for (int j = i + gap; j >= gap; j -= gap)
                {
                    //if the next value(index j) is smaller than the j - 1
                    //SWAP
                    //else stop checking and go to the next value of i
                    if (comparer.Compare(collection[j], collection[j - gap]) < 0)
                    {
                        Swap(ref collection[j], ref collection[j - gap]);
                    }
                    else
                    {
                        
                    }
                }
            }
        }

    }
}
