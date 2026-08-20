namespace Deque
{
    public class Deque<T> : IDeque<T>, IStack<T>, IQueue<T>
    {
        LinkedList<T> List { get; set; } = [];

        #region Queue Elements
        void IQueue<T>.Enqueue(T value)
        {
            if (value is null) throw new ArgumentNullException("Given value is null.");

            List.AddLast(value);
        }

        T IQueue<T>.Dequeue()
        {
            if (List.First is null) throw new NullReferenceException("Empty deque.");

            T removed = List.First.Value;
            List.RemoveFirst();
            return removed;
        }
        #endregion

        #region Stack Elements
        void IStack<T>.Push(T value)
        {
            if(value is null) throw new ArgumentNullException("Given value is null.");
            List.AddFirst(value);
        }

        T IStack<T>.Pop()
        {
            if (List.First is null) throw new NullReferenceException("Empty deque.");

            T removed = List.First.Value;
            List.RemoveFirst();
            return removed;
        }
        #endregion

        #region Deque Elements
        public void PushFront(T value)
        {
            if(value is null) throw new ArgumentNullException("Given value is null.");

            List.AddFirst(value);
        }

        public T PopFront()
        {
            if (List.First is null) throw new NullReferenceException("Empty deque.");
            T removed = List.First.Value;
            List.RemoveFirst();

            return removed;
        }

        public T PeekFront()
        {
            return Peek();
        }

        public void PushBack(T value)
        {
            if (value is null) throw new ArgumentNullException("Given value is null.");

            List.AddLast(value);
        }

        public T PopBack()
        {
            if (List.Last is null) throw new NullReferenceException("Empty deque.");
            T removed = List.Last.Value;
            List.RemoveLast();

            return removed;
        }

        public T PeekBack()
        {
            if (List.Last is null) throw new NullReferenceException("Empty deque.");
            return List.Last.Value;
        }
        #endregion

        #region loner 🤣🤣🤣🤣🤣🤣🤣🤣🤣
        public T Peek()
        {
            if (List.First is null) throw new NullReferenceException("Empty deque.");
            return List.First.Value;
        }
        #endregion
    }

    interface IDeque<T>
    {
        public void PushFront(T value);
        public T PopFront();
        public T PeekFront();

        void PushBack(T value);
        public T PopBack();
        public T PeekBack();
    }

    interface IStack<T>
    {
        public void Push(T value);
        public T Pop();
        public T Peek();
    }

    interface IQueue<T>
    {
        public void Enqueue(T value);
        public T Dequeue();
        public T Peek();
    }
}
