using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubiouslyKirkularlyLinkityLisity
{
    internal class Node<T>
    {
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }

        public Node(T value, Node<T> Next, Node<T> Previous)
        {
            Value = value;
            this.Next = Next;
            this.Previous = Previous;
        }
    }
}
