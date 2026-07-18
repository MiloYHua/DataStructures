using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Xml.Linq;

namespace SkipList
{
    public class SkipNode<T> where T : IComparable<T>
    {
        public T Value; // Value of the node
        public SkipNode<T> Next; // Rightward connection
        public SkipNode<T> Down; // Downward connection
        public int Height { get; } // Vertical height of the node

        public SkipNode(int height)
        {
            Height = height;
            Value=default(T);
        }
        public SkipNode(int height, T value)
        {
            Height = height;
            Value = value;
        }
        public SkipNode(int height, SkipNode<T> down, SkipNode<T> next)
        {
            Height = height;
            Down = down;
            Next = next;
        }
        public SkipNode(int height, T value, SkipNode<T> down, SkipNode<T> next)
        {
            Height = height;
            Value = value;
            Down = down;
            Next = next;
        }

        public SkipNode(SkipNode<T> node)
        {
            Value = node.Value;
            Height = node.Height;
            Down = node.Down;
            Next = node.Next;
        }
    }

    public class SkipList<T> where T : IComparable<T>
    {
        public SkipNode<T> Sentinel;

        public SkipList()
        {
            Sentinel = new SkipNode<T>(1);
        }

        private int ChooseRandomHeight()
        {
            Random random = new Random();

            int height = 1;

            while (random.NextDouble() < 0.5 && height < Sentinel.Height + 1)
            {
                height++;
            }

            if (height > Sentinel.Height) Sentinel = new SkipNode<T>(height, Sentinel.Value, Sentinel, null);

            return height;
        }

        public void Insert(T value)
        {
            //add check for duplicates
            int height = ChooseRandomHeight();
            InsertRecursive(Sentinel, value, height);
        }

        private static SkipNode<T> InsertRecursive(SkipNode<T> node, T value, int height)
        {
            if (node is null) return node;

            if (node.Next is null || value.CompareTo(node.Next.Value) < 0)
            {
                SkipNode<T> temp = InsertRecursive(node.Down, value, height);
               
                if (node.Height <= height)
                {                   
                    node.Next = new SkipNode<T>(node.Height,value, temp, node.Next);
                }
                return node.Next;
            }
            else
            {
                SkipNode<T> temp = InsertRecursive(node.Next, value, height);
                return temp;
            }
        }

        public void OldInsert(T value)
        {
            int height = ChooseRandomHeight();
            SkipNode<T> currentNode = Sentinel;
            SkipNode<T> parentNode = new SkipNode<T>(Sentinel);

            for (int i = Sentinel.Height; i > 0; i--)
            {
                if (currentNode.Next is null || value.CompareTo(currentNode.Next.Value) < 0)
                {
                    if (height <= i)
                    {
                        currentNode.Next = new SkipNode<T>(i, value, null, currentNode.Next);
                        if (i != Sentinel.Height) parentNode.Next.Down = currentNode.Next;
                        parentNode = currentNode;
                    }
                    currentNode = currentNode.Down;
                }
                else if (value.CompareTo(currentNode.Next.Value) > 0)
                {
                    currentNode = currentNode.Next;
                }
                else throw new Exception("No Duplicates");
            }
        }

        public SkipNode<T> Search(T value)
        {
            return SearchRecursive(Sentinel, value);
        }

        private SkipNode<T> SearchRecursive(SkipNode<T> node, T value)
        {
            if (value is null) throw new ArgumentNullException("value");

            if (node is null) return node;

            if (node.Next is null || value.CompareTo(node.Next.Value) < 0)
            {
                node = SearchRecursive(node.Down, value);
                return node;
            }
            else if (value.CompareTo(node.Next.Value) > 0)
            {
                node = SearchRecursive(node.Next, value);
                return node;
            }
            else return node;
        }

        public SkipNode<T> OldSearch(T value) //change this, you dont always go down. refer to insert logic
        {
            if (value is null) throw new ArgumentNullException("value");

            SkipNode<T> currentNode = Sentinel;

            for (int i = Sentinel.Height; i > 0; i--)
            {
                if (currentNode.Next is null || value.CompareTo(currentNode.Next.Value) < 0)
                {
                    currentNode = currentNode.Down;
                }
                else if (value.CompareTo(currentNode.Next.Value) > 0)
                {
                    currentNode = currentNode.Next;
                }
                else return currentNode;
            }
            return null;
        }

        public bool Remove(SkipNode<T> node)
        {
            SkipNode<T> currentNode = Sentinel;

            while (currentNode is not null)
            {
                if (currentNode.Next is null || node.Value.CompareTo(currentNode.Next.Value) < 0)
                {
                    currentNode = currentNode.Down;
                }
                else if (node.Value.CompareTo(currentNode.Next.Value) > 0)
                {
                    currentNode = currentNode.Down;
                    currentNode = currentNode.Next;
                }
                else if (currentNode.Down is null)
                {
                    currentNode.Next = node.Next;
                }
                else
                {
                    currentNode.Next = node.Next;
                    currentNode = currentNode.Down;
                }

                if (currentNode.Height < 2) return true;
            }
            return false;
        }
        public bool Remove(T node) => Remove(new SkipNode<T>(Sentinel.Height, node));

    }
}

