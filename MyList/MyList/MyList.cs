using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    internal class MyList<T> where T : IComparable<T>
    {
        public T[] data;
        int dataIndex = 0;
        public int Capacity = 0;

        public MyList(int dataLength)
        {
            Capacity = dataLength;
            data = new T[Capacity];
        }

        public void Add(T newData)
        {
            data[dataIndex] = newData;
            dataIndex++;
            if (dataIndex == Capacity)
            {
                T[] newArray = new T[2 * Capacity];

                for (int i = 0; i < Capacity; i++)
                {
                    newArray[i] = data[i];
                }
                Capacity *= 2;
                data = newArray;
            }
        }

        public bool IndexRemove(int index)
        {
            if (index < Capacity && index > 0)
            {
                for (int i = index; i < data.Length - 1; i++)
                {
                    data[i] = data[i + 1];
                }
                dataIndex--;
                return true;
            }
            return false;
        }

        public MyList<int> GetIndex(T value)
        {
            MyList<int> indices = new MyList<int>(data.Length);
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Equals(value))
                {
                    indices.Add(i);
                }
            }
            return indices;
        }

        public bool Remove(T removeData)
        {
            bool removed = false;
            MyList<int> removeIndices = GetIndex(removeData);
            for (int i = 0; i < removeIndices.Capacity; i++)
            {
                removed = IndexRemove(removeIndices.data[i]);
            }
            return removed;
        }
    }
}
