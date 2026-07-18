using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeapTree
{
    public class BinaryHeapTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// This or the array size doubles each time it gets too big.
        /// </summary>
        public int Capacity { get; private set; }
        /// <summary>
        /// Number of elements in the tree.
        /// </summary>
        public int Count { get; private set; }

        public T[] data = new T[10];

        public BinaryHeapTree() 
        {
            Capacity = data.Length;
            Count = 0;
        }
        public BinaryHeapTree(T[] data)
        {
            Capacity = data.Length;
            Count = 0;

            for(int i = 0; i < data.Length; i++)
            {
                Insert(data[i]);
            }
        }

        void ResizeByTwo()
        {
            T[] tempArray = new T[data.Length * 2];

            for (int i = 0; i < data.Length; i++) tempArray[i] = data[i];

            data = tempArray;
            Capacity = data.Length;
        }

        void ArraySwap(int indexOne, int indexTwo)
        {
            T tempValue = data[indexOne];
            data[indexOne] = data[indexTwo];
            data[indexTwo] = tempValue;
        }

        bool TryFindLeftIndex(int index, out int leftIndex)
        {
            leftIndex = default;
            int tempLeftIndex = (2 * index) + 1;
            if (tempLeftIndex > Count) return false;
            leftIndex = tempLeftIndex;
            return true;
        }

        bool TryFindRightIndex(int index, out int rightIndex)
        {
            rightIndex = default;
            int tempRightIndex = (2 * index) + 2;
            if (tempRightIndex > Count) return false;
            rightIndex = tempRightIndex;
            return true;
        }

        void HeapifyUp(int index)
        {
            if (index > Count) throw new IndexOutOfRangeException("index");

            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;

                if (data[index].CompareTo(data[parentIndex]) >= 0) break;

                ArraySwap(index, parentIndex);

                index = parentIndex;
            }
        }

        void HeapifyDown(int index)
        {
            if (index < 0) throw new IndexOutOfRangeException("index");

            int leftIndex;
            int rightIndex;

            while (TryFindLeftIndex(index, out leftIndex) && TryFindRightIndex(index, out rightIndex))
            {
                int smallerIndex = data[leftIndex].CompareTo(data[rightIndex]) < 0 ? leftIndex : rightIndex;

                if (data[index].CompareTo(data[smallerIndex]) <= 0) break;

                ArraySwap(index, smallerIndex);

                index = smallerIndex;
            }
        }
        /// <summary>
        /// Inserts a given value at the end of the tree.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Insert(T value)
        {
            if (value == null) throw new ArgumentNullException("value");

            data[Count] = value;
            HeapifyUp(Count);
            Count++;

            if (Count > Capacity) ResizeByTwo();
        }
        /// <summary>
        /// Attempts to pop and returns a boolean that indicated faliure or success and also gives out a variable.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryPop([NotNullWhen(true)] out T? value)
        {
            value = default;

            if (Count < 1) return false;

            value = data[0];
            data[0] = data[Count - 1];
            Count--;

            HeapifyDown(0);

            return true;
        }
        /// <summary>
        /// Sorts a given array using TryPop().
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool HeapSort(T[] array)
        {
            BinaryHeapTree<T> tree = new BinaryHeapTree<T>(array);

            for (int i = 0; i < tree.Count; i++)
            {
                tree.HeapifyUp(i);
			}

            if (array.Length < 1) return false;
            
            int tempCount = array.Length;

            for (int i = 0; i < tempCount; i++)
            {
                if (tree.TryPop(out T? value))
                {
					array[i] = value;
                }
            }

            tree.Count = tempCount;

			return true;
        }
        /// <summary>
        /// Sorts the data array built into the tree.
        /// </summary>
        /// <returns></returns>
        public bool HeapSort() => HeapSort(data);
    }
}
