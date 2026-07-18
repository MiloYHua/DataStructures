using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayBackedStack
{
    public class ThEpicMiloStack<T>
    {
        T[] data;
        public int Count { get; private set; }
        
        public ThEpicMiloStack()
        {
            data = new T[5];
            Count = 0;
        }

        public void ExpandArray()
        {
            T[] temp = new T[data.Length + 1];
            
            for(int i = 0; i < data.Length; i++)
            {
                temp[i] = data[i];
            }

            data = temp;
            Count++;
        }

        public void Push(T value)
        {
            if (Count == data.Length) ExpandArray();

            data[Count] = value;

            Count++;
        }

        public T Pop()
        {
            if (Count < 0) throw new MiloException();

            Count--;

            return data[Count];
        }

        public T Peek()
        {
            if (Count - 1 == -1) throw new NullReferenceException();

            return data[Count - 1];
        }

        public void Clear()
        {
            data = Array.Empty<T>();
            Count = 0;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }
    }
}
