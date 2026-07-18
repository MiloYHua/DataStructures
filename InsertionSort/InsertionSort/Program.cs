using System;
using System.ComponentModel.Design;

namespace InsertionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] sortTheseSomethingies = { 2, 5, 3, 6, 4, 1 };

            for (int i = 0; i < sortTheseSomethingies.Length - 1; i++)
            {
                for (int x = i; x >= 0; x--)
                {
                    if (sortTheseSomethingies[x] > sortTheseSomethingies[x + 1])
                    {
                        byte tempNum = sortTheseSomethingies[x];
                        sortTheseSomethingies[x] = sortTheseSomethingies[x + 1];
                        sortTheseSomethingies[x + 1] = tempNum;
                        
                    }
                }
            }
            for (int i = 0; i < sortTheseSomethingies.Length; i++)
            {
                Console.WriteLine(sortTheseSomethingies[i]);
            }
        }
    }
}
