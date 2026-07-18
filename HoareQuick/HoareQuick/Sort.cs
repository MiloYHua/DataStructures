using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoareQuick
{
    public static class Sort<T> where T : IComparable<T>
    {
        static int index = 0;
        private static void ArraySwap(T[] swapMe, int indexOne, int indexTwo)
            => (swapMe[indexTwo], swapMe[indexOne]) = (swapMe[indexOne], swapMe[indexTwo]);

		private static void HoarePartitonQuickSort(T[] toSort, int start, int end)
        {
            index++;
            if (end - start < 1) 
                return;

            int leftIndex = start - 1;
            int rightIndex = end + 1;
            T pivotValue = toSort[start];

            while (rightIndex >= leftIndex)
            {
                do
                {
                    leftIndex++;
                } while (toSort[leftIndex].CompareTo(pivotValue) < 0 && rightIndex >= leftIndex);

                do
                {
                    rightIndex--;
                } while (toSort[rightIndex].CompareTo(pivotValue) > 0 && rightIndex >= leftIndex);

                if (rightIndex <= leftIndex) break;

                ArraySwap(toSort, leftIndex, rightIndex);
            }

            HoarePartitonQuickSort(toSort, start, rightIndex);
            HoarePartitonQuickSort(toSort, rightIndex+1, end);
        }

        public static void QuickSort(T[] toSort)
        {
            HoarePartitonQuickSort(toSort, 0, toSort.Length - 1);
        }
    }
}
