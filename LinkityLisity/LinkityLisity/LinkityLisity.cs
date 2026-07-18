using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkityLisity
{
    internal class LinkityLisity<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        public int Count { get; private set; }

        public LinkityLisity()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Creates a new Head node for LinkityList.
        /// </summary>
        /// <param name="value"></param>
        public void AddFirst(T value) 
        {
            Count++;
            if (Head == null)
            {
                Head = new Node<T>(value);
                Tail = Head;
                return;
            }

            Node<T> newNode = new Node<T>(value);
            newNode.next = Head;
            Head = newNode;
        }
        /// <summary>
        /// Creates a new Tail node for LinkityList.
        /// </summary>
        /// <param name="value"></param>
        public void AddLast(T value)
        {
            Count++;
            if (Tail == null)
            {
                Tail = new Node<T>(value);
                Head = Tail;
                return;
            }

            Node<T> newNode = new Node<T>(value);
            Tail.next = newNode;
            Tail = newNode;
        }
        /// <summary>
        /// Adds a new node before the node specified from a value.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        public void AddBefore(Node<T> node, T value) //add a new node before any specified (and extant) node
        {
            Count++;
            Node<T> previousNode = Head;
            while(previousNode.next != node)
            {
                previousNode = previousNode.next;
            }
            previousNode.next = new Node<T>(value);
            previousNode.next.next = node;
        }
        /// <summary>
        /// Adds a new node after the node specified from a value.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        public void AddAfter(Node<T> node, T value)   //add a new node after any specified (and extant) node
        {
            Count++;
            node.next = new Node<T>(value, node.next);
        }
        /// <summary>
        /// Removes the first node.
        /// </summary>
        /// <returns></returns>
        public bool RemoveFirst()                   //remove the first node
        {
            if(Head == null) return false;

            Count--;
            Head = Head.next;
            return true;
        }
        /// <summary>
        /// Removes the last node.
        /// </summary>
        /// <returns></returns>
        public bool RemoveLast()                    //remove the last node 
        {
            if(Tail == null) return false;

            Node<T> newNode = Head;

            while(newNode.next != Tail)
            {
                newNode = newNode.next;
            }
            Count--;
            Tail = newNode;
            newNode.next = null;
            return true;
        }
        /// <summary>
        /// Finds and removes a node containing the value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Remove(T value)              //find and remove a node containing the given value
        {
            if (value == null) return false;

            Node<T> policeNode = Head;

            while (!policeNode.next.value.Equals(value))
            {
                policeNode = policeNode.next;
                if (policeNode.next == null) return false;
            }
            policeNode.next = policeNode.next.next;
            Count--;
            return true;
        }
        /// <summary>
        /// Deletes every node in the linked list.
        /// </summary>
        public void Clear()                      //delete every node in the linked list
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        /// <summary>
        /// Searches for a given value and return a node that contains it
        /// </summary>
        /// <param name="value"></param>
        /// <returns>node that contains value, null if none is found</returns>
        public Node<T> Search(T value)
        {
            if (value == null || Head == null) return null;

            Node<T> currentNode = Head;

            while (!currentNode.value.Equals(value))
            {
                currentNode = currentNode.next;

                if (currentNode == null) return null;
            }
            return currentNode;
        }
        public bool Contains(T value)            //search for a given value and return if you found it.
        {
            if (value == null || Head == null) return false;

            Node<T> searchAndRescueNode = Head;

            while (!searchAndRescueNode.value.Equals(value))
            {
                searchAndRescueNode = searchAndRescueNode.next;
                if(searchAndRescueNode == null)
                {
                    return false;
                }
            }
            return true;
        }
        public bool Contains(Node<T> node)       //search for a given node and return if you found it.
        {
            return Contains(node.value);
        }
    }
}