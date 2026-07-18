using DubiousNode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DubiouslyLinkedList
{
    internal class DubiouslyLinkedList<T>
    {
        public int Count { get; private set; }

        public DubiousNode<T> Head { get; private set; }

        public void AddFirst(T value)
        {
            Count++;
            if (Head == null)
            {
                Head = new DubiousNode<T>(value);
                return;
            }

            DubiousNode<T> newNode = new DubiousNode<T>(value);
            newNode.Next = Head;
            Head = newNode;
            Head.Next.Previous = Head;
        }

        public void AddLast(T Value)
        {
            Count++;
            DubiousNode<T> searchNode = Head;

            if (searchNode == null)
            {
                searchNode = new DubiousNode<T>(Value, null, null);
                Head = searchNode;
                return;
            }

            while (searchNode.Next != null)
            {
                searchNode = searchNode.Next;
            }

            searchNode.Next = new DubiousNode<T>(Value, null, searchNode);
        }

        public void AddAfter(DubiousNode<T> node, T value)
        {
            if (node.Next == null)
            {
                Count++;
                node.Next = new DubiousNode<T>(value, null, node);
                return;
            }

            Count++;
            DubiousNode<T> searchNode = Head;

            while (!searchNode.Value.Equals(node.Value)) searchNode = searchNode.Next;

            searchNode.Next = new DubiousNode<T>(value, searchNode.Next, searchNode);
            searchNode.Next.Next.Previous = searchNode.Next;
        }

        public void AddBefore(DubiousNode<T> node, T value)
        {
            DubiousNode<T> newNode = new DubiousNode<T>(value);

            if (node == Head)
            {
                AddFirst(value);
                return;
            }

            Count++;

            newNode.Next = node;
            newNode.Previous = node.Previous;
            node.Previous = newNode;
            newNode.Previous.Next = newNode;
        }

        public bool RemoveFirst()
        {
            if (Head == null) return false;

            Count--;

            if (Head.Next == null)
            {
                Head = null;
                return true;
            }

            Head = Head.Next;
            Head.Previous = null;

            return true;
        }

        public bool RemoveLast()
        {
            if (Head == null) return false;

            Count--;

            if(Head.Next == null)
            {
                Head = null;
                return true;
            }
            
            DubiousNode<T> searchNode = Head;

            while (searchNode.Next != null) searchNode = searchNode.Next;

            searchNode.Previous.Next = null;

            return true;
        }

        public bool Remove(DubiousNode<T> fugitiveNode)
        {
            if (fugitiveNode == null) return false;

            if (fugitiveNode == Head) return RemoveFirst();

            Count--;

            if (fugitiveNode.Next == null)
            {
                fugitiveNode.Previous.Next = null;
                return true;
            }

            fugitiveNode.Previous.Next = fugitiveNode.Next;
            fugitiveNode.Next.Previous = fugitiveNode.Previous;

            return true;
        }

        public DubiousNode<T> Search(DubiousNode<T> lostNode)
        {
            DubiousNode<T> searchAndRescueNode = Head;

            while (!searchAndRescueNode.Value.Equals(lostNode.Value))
            {
                searchAndRescueNode = searchAndRescueNode.Next;
                if(searchAndRescueNode == null)
                {
                    return null;
                }    
            }
            return searchAndRescueNode;
        }

        public DubiousNode<T> Search(T Value)
        {
            return Search(new DubiousNode<T>(Value));
        }

        public bool Contains(DubiousNode<T> crinimalNode)
        {
            DubiousNode<T> polishIceNode = Head;

            while (!polishIceNode.Value.Equals(crinimalNode.Value))
            {
                polishIceNode = polishIceNode.Next;
                if (polishIceNode == null)
                {
                    return false;
                }
            }
            return true;
        }

        public bool Contains(T Value)
        {
            return Contains(new DubiousNode<T>(Value));
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }
    }
}