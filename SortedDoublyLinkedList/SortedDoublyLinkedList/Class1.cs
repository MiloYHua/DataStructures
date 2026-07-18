using System.Globalization;

namespace SortedDoublyLinkedList
{
    public class DLNode<T> where T : IComparable<T>
    {
        public T value;
        public DLNode<T> prev;
        public DLNode<T> next;

        public DLNode()
        {

        }

        public DLNode(T value)
        {
            this.value = value;
        }

        public DLNode(DLNode<T> prev, DLNode<T> next)
        {
            this.prev = prev;
            this.next = next;
        }
        public DLNode(T value, DLNode<T> prev, DLNode<T> next)
        {
            this.value = value;
            this.prev = prev;
            this.next = next;
        }
    }

    public class SortedDLList<T> where T : IComparable<T>
    {
        DLNode<T> head = new DLNode<T>();
        DLNode<T> tail;

        public void Add()
        {
            
        }
    }
}
