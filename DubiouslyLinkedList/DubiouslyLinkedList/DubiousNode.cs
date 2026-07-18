using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  DubiousNode
{
    class  DubiousNode<T>
    {
        public  DubiousNode<T> Next { get; set; }
        public  DubiousNode<T> Previous { get; set; } // the only change

        public T Value { get; set; }

        public  DubiousNode(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
        public DubiousNode(T value, DubiousNode<T> next, DubiousNode<T> previous)
        {
            Value = value;
            Next = next;
            Previous = previous;
        }
    }
}
