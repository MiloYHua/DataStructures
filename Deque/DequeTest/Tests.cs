using DequeAndInterfaces;

namespace DequeTest
{
    public class Tests
    {
        [Fact]
        public void StackPushPopTest()
        {
            Random randy = new Random();
            IStack<int> dequeStack = new Deque<int>();
            
            int length = 10;
            int[] expected = new int[length];

            for (int i = 0; i < length; i++)
            {
                int next = randy.Next(100);
                dequeStack.Push(next);
                expected[length - 1 - i] = next;
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(expected[i], dequeStack.Pop());
            }
        }

        [Fact]
        public void QueueEnqueueDequeTest()
        {
            Random randy = new Random();
            IQueue<int> dequeStack = new Deque<int>();

            int length = 10;
            int[] expected = new int[length];

            for (int i = 0; i < length; i++)
            {
                int next = randy.Next(100);
                dequeStack.Enqueue(next);
                expected[i] = next;
            }
            KeyValuePair
            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(expected[i], dequeStack.Dequeue());
            }
        }

        [Fact]
        public void CreationTest()
        {
            Deque<int> deque = new();

            Assert.Equal(0, deque.Length);
        }

        [Fact]
        public void PushFrontPopBackTest()
        {
            Random randy = new Random();
            Deque<int> deque = new();
            
            int length = 10;
            int[] expected = new int[length];

            for (int i = 0; i < length; i++)
            {
                int next = randy.Next(100);
                deque.PushFront(next);
                expected[i] = next;
            }

            for (int i = 0;i < 10;i++)
            {
                Assert.Equal(expected[i], deque.PopBack());
            }
        }

        [Fact]
        public void PopFrontPushFrontTest()
        {
            Random randy = new Random();
            Deque<int> deque = new();

            int length = 10;
            int[] expected = new int[length];
            int[] actual = new int[length];

            for (int i = 0; i < length; i++)
            {
                int next = randy.Next(100);
                expected[i] = next;
                deque.PushFront(next);
                actual[i] = deque.PopFront();
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }
        }

        [Fact]
        public void PeekFrontPushBackPopFrontTest()
        {
            Random randy = new Random();
            Deque<int> deque = new();

            int length = 10;
            int[] expected = new int[length];

            for (int i = 0; i < length; i++)
            {
                int next = randy.Next(100);
                expected[i] = next;
                deque.PushBack(next);
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(expected[i], deque.PeekFront());
                deque.PopFront();
            }
        }

        [Fact]
        public void PeekBackPushFrontPopBackTest()
        {
            Random randy = new Random();
            Deque<int> deque = new();

            int length = 10;
            int[] expected = new int[length];

            for (int i = 0; i < length; i++)
            {
                int next = randy.Next(100);
                expected[i] = next;
                deque.PushFront(next);
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(expected[i], deque.PeekBack());
                deque.PopBack();
            }
        }
    }
}
