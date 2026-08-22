namespace DequeAndInterfaces
{
    public class Deque<T> : IDeque<T>, IStack<T>, IQueue<T>
    {
        LinkedList<T> list = [];

        public int Length { get; private set; } = 0;

        #region Queue Elements
        void IQueue<T>.Enqueue(T value)
        {
            if (value is null) throw new ArgumentNullException("Given value is null.");

            list.AddLast(value);
            Length++;
        }

        T IQueue<T>.Dequeue()
        {
            if (list.First is null) throw new NullReferenceException("Empty deque.");

            T removed = list.First.Value;
            list.RemoveFirst();
            Length--;
            return removed;
        }
        #endregion

        #region Stack Elements
        void IStack<T>.Push(T value)
        {
            if(value is null) throw new ArgumentNullException("Given value is null.");
            list.AddFirst(value);
            Length++;
        }

        T IStack<T>.Pop()
        {
            if (list.First is null) throw new NullReferenceException("Empty deque.");

            T removed = list.First.Value;
            list.RemoveFirst();
            Length--;
            return removed;
        }
        #endregion

        #region Deque Elements
        public void PushFront(T value)
        {
            if(value is null) throw new ArgumentNullException("Given value is null.");

            list.AddFirst(value);
            Length++;
        }

        public T PopFront()
        {
            if (list.First is null) throw new NullReferenceException("Empty deque.");
            T removed = list.First.Value;
            list.RemoveFirst();
            Length--;

            return removed;
        }

        public T PeekFront()
        {
            return Peek();
        }

        public void PushBack(T value)
        {
            if (value is null) throw new ArgumentNullException("Given value is null.");

            list.AddLast(value);
            Length++;
        }

        public T PopBack()
        {
            if (list.Last is null) throw new NullReferenceException("Empty deque.");
            T removed = list.Last.Value;
            list.RemoveLast();
            Length--;

            return removed;
        }

        public T PeekBack()
        {
            if (list.Last is null) throw new NullReferenceException("Empty deque.");
            return list.Last.Value;
        }
        #endregion

        #region loner 🤣🤣🤣🤣🤣🤣🤣🤣🤣
        public T Peek()
        {
            if (list.First is null) throw new NullReferenceException("Empty deque.");
            return list.First.Value;
        }
        #endregion
    }

    public interface IDeque<T>
    {
        public void PushFront(T value);
        public T PopFront();
        public T PeekFront();

        void PushBack(T value);
        public T PopBack();
        public T PeekBack();
    }

    public interface IStack<T>
    {
        public void Push(T value);
        public T Pop();
        public T Peek();
    }

    public interface IQueue<T>
    {
        public void Enqueue(T value);
        public T Dequeue();
        public T Peek();
    }
}
