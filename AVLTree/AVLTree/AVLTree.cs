using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace AVLTree
{
    public class AVLTree<T> where T : IComparable<T>
    {
        public AVLNode<T> root;
        public int Count { get; private set; }
        public void Insert(T value)
        {
            root = InsertRecursive(root, value);
            Count++;
        }

        public AVLNode<T> InsertRecursive(AVLNode<T> node, T value)
        {
            if (node is null) return new AVLNode<T>(value);

            if (value.CompareTo(node.value) > 0) node.right = InsertRecursive(node.right, value);

            else node.left = InsertRecursive(node.left, value);

            node.height++;

            return Rotate(node);
        }

        private AVLNode<T> Rotate(AVLNode<T> node)
        {
            if (node.Balance > 1)
            {
                if (node.right.Balance < -1)
                {
                    node.right = RightRotation(node.right);
                }
                return LeftRotation(node);
            }
            else if (node.Balance < -1)
            {
                if (node.left.Balance > 1)
                {
                    node.left = LeftRotation(node.left);
                }
                return RightRotation(node);
            }
            return node;
        }

        private AVLNode<T> LeftRotation(AVLNode<T> node)
        {
            AVLNode<T> tempNode = node.right;
            node.right = tempNode.left;
            tempNode.left = node;
            SetHeight(node);
            SetHeight(tempNode);
            return tempNode;
        }

        private AVLNode<T> RightRotation(AVLNode<T> node)
        {
            AVLNode<T> tempNode = node.left;
            node.left = tempNode.right;
            tempNode.right = node;
            SetHeight(node);
            SetHeight(tempNode);
            return tempNode;
        }

        public bool Delete(T value)
        {
            if (root is null) return false;

            bool didRemove = true;
            root = DeleteRecursive(root, value);
            root = Rotate(root);

            return didRemove;

            AVLNode<T> DeleteRecursive(AVLNode<T> node, T value)
            {
                if (node is null)
                {
                    didRemove = false;
                    return null;
                }

                int result = value.CompareTo(node.value);

                if (result > 0)
                {
                    node.right = DeleteRecursive(node.right, value);
                }
                else if (result < 0)
                {
                    node.left = DeleteRecursive(node.left, value);
                }
                else
                {
                    node = DeleteHelper(node);
                }
                return node;
            }
        }



        private AVLNode<T> DeleteHelper(AVLNode<T> node)
        {
            if (node.left is null && node.right is null)
            {
                return null;
            }
            else if (node.left is not null && node.right is null)
            {
                return node.left;
            }
            else if (node.left is null && node.right is not null)
            {
                return node.right;
            }
            else
            {
                int i = 0;
                AVLNode<T> parent = node;
                AVLNode<T> curr = node.left;

                for ( i = 0; curr.height > 1; i++ )
                {
                    parent = curr;
                    curr = curr.right;
                }

                T tempValue = curr.value;
                if (i == 0) parent.left = DeleteHelper(curr);
                else parent.right = DeleteHelper(curr);

                return new AVLNode<T>(node.left, node.right, tempValue);
            }
        }

        private void SetHeight(AVLNode<T> node)
        {
            int leftHeight = node.left is null ? 0 : node.left.height;
            int rightHeight = node.right is null ? 0 : node.right.height;
            node.height = Math.Max(leftHeight, rightHeight) + 1;
        }

        public bool Contains(T value)
        {
            AVLNode<T> curr = root;

            while (curr is not null)
            {
                int result = value.CompareTo(curr.value);

                if (result > 0) curr = curr.right;
                else if (result < 0) curr = curr.left;
                if (result == 0) return true;
            }
            return false;
        }
    }
}
