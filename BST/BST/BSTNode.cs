using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    public class BSTNode<T> where T : IComparable<T>
    {
        public BSTNode<T> Left { get; set; } //Instead of Next
        public BSTNode<T> Right { get; set; } //Instead of Previous

        public T Value { get; set; }

        public BSTNode()
        {

        }

        public BSTNode(T value)
        {
            Value = value;
        }

        public BSTNode(BSTNode<T> left, BSTNode<T> right, T value) 
        {
            Left = left;
            Right = right;
            Value = value;
        }
    }
}
