namespace SelectionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] sortUs = { 6, 4, 2, 3, 1, 5 };
            byte smallestIndex = 0;

            for(byte i = 0; i < sortUs.Length; i++)
            {
                byte num = sortUs[i];
                for (byte x = i; x < sortUs.Length; x++)
                {
                    if(num > sortUs[x])
                    {
                        num = sortUs[x];
                        smallestIndex = x;
                    }
                }
                byte tempNum = sortUs[i];
                sortUs[i] = sortUs[smallestIndex];
                sortUs[smallestIndex] = tempNum;
            }
            
            for(byte i = 0; i < sortUs.Length; i++)
            {
                Console.Write(sortUs[i]);
            }
        }
    }
}
