namespace HoareQuick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] intsegers = { 2, 5, 4, 3, 2, 1 };
            Sort<int>.QuickSort(intsegers);

            for(int i = 0; i < intsegers.Length; i++)
            {
                Console.WriteLine(intsegers[i]);
            }
        }
    }
}
