namespace LomutoQuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 2, 3, 5, 1, 6 };
            LomutoQuickSort<int>.QuickSort(ints);

            for(int i = 0; i < ints.Length; i++)
            {
                Console.WriteLine(ints[i]);
            }
        }
    }
}
