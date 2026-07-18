using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayBackedQueue
{
    public class MiloQueue<T>
    {
        public int Count { get; private set; } // The amount of items in the Queue
        public T[] data; // Backing for the Queue
        private int head; // The point to remove at
        private int tail; // The point to add at

        public MiloQueue()
        {
            data = new T[4];
            head = 0;
            tail = 0;
        }

        public void ExpandArray()
        {
            T[] data = new T[this.data.Length * 2];

            int current = head;
            for (int i = 0; i < Count; i++)
            {
                if (current == this.data.Length) current = 0;

                data[i] = this.data[current];
                current++;
            }
            this.data = data;
        }

        public void Enqueue(T value)
        {
            if (value == null) throw new NullReferenceException();

            //if (Count == data.Length)
            //{ 

            //    if (head == 0)
            //    {
            //        ExpandArray();
            //    }

            //    else
            //    {
            //        tail = 0;
            //    }
            //}

            data[tail] = value;
            Count++;
            tail++;

            if (tail == data.Length)
            {
                tail = 0;
            }

            if (tail == head)
            {
                ExpandArray();
                head = 0;
                tail = Count;
            }
        }
        public T Dequeue()
        {
            Count--;
            head++;
            return data[head - 1];
        }
        public T Peek()
        {
            return data[head];
        }

        // Optional Functions
        public bool IsEmpty() => Count == 0;
        public void Clear()
        {
            Count = 0;
            data = new T[5];
            head = 0;
            tail = 0;
        }
    }
}
