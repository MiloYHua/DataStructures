using System.ComponentModel;

namespace RecursionPractice
{
    
    internal class Program
    {
        static int iterations = 0;
        static bool Contains(int[] items, int itemToFind)
        {
            return ContainsHelper(items, itemToFind, 100, 50, 0);
        }

        static bool ContainsHelper(int[] items, int itemToFind, int upperBound, int middleIndex, int lowerBound)
        {
            if (items[middleIndex].Equals(itemToFind)) return true;
            if (upperBound < lowerBound) return false;

            iterations++;

            if (itemToFind > items[middleIndex])
            {
                lowerBound = middleIndex;
                middleIndex = ((upperBound - lowerBound) / 2) + lowerBound;
            }
            else
            {
                upperBound = middleIndex;
                middleIndex = ((upperBound - lowerBound) / 2) + lowerBound;
            }
            return ContainsHelper(items, itemToFind, upperBound, middleIndex, lowerBound);
        }

        static void TriangleMaker(string startString)
        {
            if (startString.Length > 20) return;

            Console.WriteLine(startString);
            TriangleMaker(startString.Insert(startString.Length, " *"));
        }

        static void Main(string[] args)
        {
            int[] items = new int[100];

            for(int i = 0; i < items.Length; i++)
            {
                items[i] = i;
            }
            bool bob = true;
            for (int i = 0; i < items.Length; i++)
            {                
                bool john = Contains(items, i);
                if (!john) bob = false;
            }
        }
        
    }
    
}
