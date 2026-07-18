using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DubiouslyKirkularlyLinkityLisity
{
    internal class DubiouslyKirkularlyLinkityLisity<T>
    {
        public int Count { get; private set; }

        public Node<T> Head { get; private set; }

        public Node<T> Tail
        {
            get
            {
                if(Head == null) return null;
				return Head.Previous;
            }
            private set => Head.Previous = value;
        }

        /// <summary>
        /// Adds a new Head node of the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddFirst(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            Count++;

            if (Head == null)
            {
                Head = new Node<T>(value);
                Tail = Head;
                Head.Previous = Head;
                Head.Next = Head;
                return;
            }

            Head.Previous = new Node<T>(value, Head, Tail);
            Head = Head.Previous;
            Tail.Next = Head;
        }

        /// <summary>
        /// Adds a new Tail node of the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddLast(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            Count++;

            Tail.Next = new Node<T>(value, Head, Tail);
            Tail = Tail.Next;
		}

		/// <summary>
		/// Adds a new node with the specified value after the given and extant node.
		/// </summary>
		/// <param name="node"></param>
		/// <param name="value"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public void AddAfter(Node<T> node, T value)
        {
			if (node == null) throw new ArgumentNullException(nameof(node));

			if (value == null) throw new ArgumentNullException(nameof(value));

			if (node == Tail)
			{
				AddLast(value);
				return;
			}

            Count++;

            node.Next.Previous = new Node<T>(value, node.Next, node);
            node.Next = node.Next.Previous;
		}

        /// <summary>
        /// Adds a new node with the specified value before the given and extant node.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddBefore(Node<T> node, T value) //do circularly stuff for this
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            if (value == null) throw new ArgumentNullException(nameof(value));

            if (node == Head)
            {
                AddFirst(value);
                return;
            }
            
            Count++;

            node.Previous = new Node<T>(value, node, node.Previous);
        }

        public bool Remove(Node<T> removeNode)
        {
            if (removeNode == null) return false;

            Count--;

            if (removeNode == Head) Head = removeNode.Next;

            if (removeNode == Tail) Tail = removeNode.Previous;

            removeNode.Previous.Next = removeNode.Next;
            removeNode.Next.Previous = removeNode.Previous;
            return true;
        }

        public bool RemoveFirst() => Remove(Head);

		public bool RemoveLast() => Remove(Tail);

        public void Clear()
        {
            Count = 0;
            Head = null;
        }

        public Node<T> Search(Node<T> searchNode)
        {
            Node<T> finderNode = Head;

            while(!finderNode.Value.Equals(searchNode.Value))
            {
                finderNode = finderNode.Next;

                if(finderNode == Head)
                {
                    return null;
                }
            }
            return finderNode;
        }

        public Node<T> Search(T searchValue) => Search(new Node<T>(searchValue));


		public bool Contains(T value)
        {
			Node<T> finderNode = Head;

			while (!finderNode.Value.Equals(value))
			{
				finderNode = finderNode.Next;

				if (finderNode == Head)
				{
					return false;
				}
			}
			return true;
		}

        public bool Contains(Node<T> searchNode) => Contains(searchNode.Value);
    }
}