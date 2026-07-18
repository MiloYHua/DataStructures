namespace MergeSort
{
    static public class Sorts<T> where T : IComparable<T>
    {
        static public List<T> MergeSort(List<T> items)
        {
            int half = items.Count / 2;
            List<T> halfOne = new List<T>();
            List<T> halfTwo = new List<T>();

            if (half * 2 == items.Count)
            {
                halfOne.AddRange(items.GetRange(0, half));
                halfTwo.AddRange(items.GetRange(half, half));
            }
            else
            {
                halfOne.AddRange(items.GetRange(0, half + 1));
                halfTwo.AddRange(items.GetRange(half + 1, half));
            }

            List<T> mergeResultOne = halfOne;
            List<T> mergeResultTwo = halfTwo;

            if (halfOne.Count > 1)
            {
                mergeResultOne = MergeSort(halfOne);
            }
            if (halfTwo.Count > 1)
            {
                mergeResultTwo = MergeSort(halfTwo);
            }

            return Merge(mergeResultOne, mergeResultTwo);
        }

        static List<T> Merge(List<T> listOne, List<T> listTwo)
        {
            List<T> result = new List<T>();
            int iOne = 0;
            int iTwo = 0;

            while (iOne < listOne.Count || iTwo < listTwo.Count)
            {
                if (iOne >= listOne.Count)
                {
                    result.Add(listTwo[iTwo]);
                    iTwo++;
                    continue;
                }
                if (iTwo >= listTwo.Count)
                {
                    result.Add(listOne[iOne]);
                    iOne++;
                    continue;
                }

                if (listOne[iOne].CompareTo(listTwo[iTwo]) <= 0)
                {
                    result.Add(listOne[iOne]);
                    iOne++;
                }
                else if (listOne[iOne].CompareTo(listTwo[iTwo]) > 0)
                {
                    result.Add(listTwo[iTwo]);
                    iTwo++;
                }
            }
            return result;
        }
    }
}
