using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLQueue
{
    public class MiloQueue<T>
    {
        public LinkedList<T> data;

        public int Count { get; private set; }

        public MiloQueue()
        {
            data = new LinkedList<T>();
            Count = 0;
        }

        public void Enqueue(T value)
        {
            if(value == null) throw new ArgumentNullException("value");

            data.AddLast(value);
            Count++;
        }

        public T Dequeue()
        {
            T temp = data.First.Value;
            data.RemoveFirst();
            Count--;
            return temp;
        }

        public T Peek()
        {
            return data.First.Value;
        }


        // Optional Functions
        public bool IsEmpty() => Count == 0;

        public void Clear()
        {
            data.Clear();
            Count = 0;
        }

    }
}
