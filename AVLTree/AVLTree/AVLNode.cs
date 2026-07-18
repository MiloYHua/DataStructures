using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    public class AVLNode<T> where T : IComparable<T>
    {
        public AVLNode<T> left;
        public AVLNode<T> right;
        public int height;
        public T value;
        public int Balance
        {
            get
            {
                int leftHeight = left is null ? 0 : left.height;
                int rightHeight = right is null ? 0 : right.height;
                return rightHeight - leftHeight;
            }
        }

        public AVLNode(T value)
        {
            height = 1;
            this.value = value;
        }
        public AVLNode(AVLNode<T> left, AVLNode<T> right)
        {
            height = 1;
            this.left = left;
            this.right = right;
        }
        public AVLNode(AVLNode<T> left, AVLNode<T> right, T value)
        {
            height = 1;
            this.left = left;
            this.right = right;
            this.value = value;
        }
    }
}
