namespace Bubble_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] sortMe = { 5, 2, 1, 6, 3, 4 };
            bool wasSwapped = false;

            while (true)
            {
                wasSwapped = false;
                for (int i = 0; i < sortMe.Length - 1; i++)
                {
                    if (sortMe[i] > sortMe[i + 1])
                    {
                        byte tempNum = sortMe[i];
                        sortMe[i] = sortMe[i + 1];
                        sortMe[i + 1] = tempNum;
                        wasSwapped = true;
                    }
                }
                if (!wasSwapped)
                {
                    break;
                }
            }

            for (int i = 0; i < sortMe.Length; i++)
            {
                Console.WriteLine(sortMe[i]);
            }
        }
    }
}
