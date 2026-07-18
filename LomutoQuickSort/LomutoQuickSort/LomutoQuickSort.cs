using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace LomutoQuickSort
{
    public class LomutoQuickSort<T> where T : IComparable
    {
        private static void ArraySwap(T[] swapMe, int indexOne, int indexTwo)
        {
            T iOneValue = swapMe[indexOne];
            swapMe[indexOne] = swapMe[indexTwo];
            swapMe[indexTwo] = iOneValue;
        }

        private static void QuickSort(T[] sortMe, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex) return;

            int currIndex = startIndex;
            int wallIndex = startIndex;
            int pivotIndex = endIndex;

            while (currIndex <= endIndex)
            {
                if (sortMe[pivotIndex].CompareTo(sortMe[currIndex]) > 0)
                {
                    ArraySwap(sortMe, wallIndex, currIndex);
                    wallIndex++;
                }
                currIndex++;
            }

            ArraySwap(sortMe, wallIndex, pivotIndex);

            QuickSort(sortMe, startIndex, wallIndex - 1);
            QuickSort(sortMe, wallIndex + 1, endIndex);
        }

        public static void QuickSort(T[] sortMe) { QuickSort(sortMe, 0, sortMe.Length - 1); }
    }
}
