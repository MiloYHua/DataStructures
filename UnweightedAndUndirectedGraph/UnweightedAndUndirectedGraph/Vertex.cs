using System;
using System.Collections.Generic;
using System.Text;

namespace UnweightedAndUndirectedGraph
{
    public class Vertex<T>
    {
        public T Value { get; set; }

        public List<Vertex<T>> Neighbors { get; set; }

        public Vertex(T value)
        {
            Value = value;
            Neighbors = new List<Vertex<T>>();
        }
    }
}
