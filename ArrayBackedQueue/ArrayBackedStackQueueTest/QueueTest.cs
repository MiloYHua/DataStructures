using ArrayBackedQueue;
namespace ArrayBackedStackQueueTest
{
    public class QueueTest
    {
        [Fact]
        public void EmptyTest()
        {
            MiloQueue<int> queue = new MiloQueue<int>();

            Assert.Equal(0, queue.Count);
            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void SingleEnqueueAndDequeueTest()
        {
            MiloQueue<int> queue = new MiloQueue<int>();

            queue.Enqueue(5);

            Assert.Equal(1, queue.Count);
            Assert.Equal(5, queue.Dequeue());
        }

        //true = Enqueue
        //false = Dequeue
        [Theory]
        [InlineData(5, 2, 1, 4, 3 )]        
        public void MultiEnqueueAndDequeueTest(params int[] nums)
        {
            MiloQueue<int> queue = new MiloQueue<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                queue.Enqueue(nums[i]);
            }

            Assert.Equal(nums.Length, queue.Count);

            for (int i = 0; i < nums.Length; i++)
            {
                Assert.Equal(nums[i], queue.Dequeue());
            }

            Assert.Equal(0, queue.Count);
        }

        [Theory]
        [InlineData(new int[] { 5, 2, 1, 4, 3 }, new bool[] { true, true, false, true, false }, new int[] { 5, 2 })]
        public void MultiEnqueueAndDeuqueueMiddleTest(int[] nums, bool[] operation, int[] expectedout)
        {
            MiloQueue<int> queue = new MiloQueue<int>();
            List<int> output = new List<int>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (operation[i])
                {
                    queue.Enqueue(nums[i]);
                    output.Add(nums[i]);
                }
                else
                {
                    queue.Dequeue();
                    output.Remove(nums[i]);
                }
            }

            for (int i = 0; i < expectedout.Length; i++)
            {
                Assert.True(output[i] == expectedout[i]);
            }
        }

        [Fact]
        public void PeekTest()
        {
            MiloQueue<int> queue = new MiloQueue<int>();

            queue.Enqueue(5);

            Assert.Equal(5, queue.Peek());
        }

        [Fact]
        public void ClearTest()
        {
            MiloQueue<int> queue = new MiloQueue<int>();

            queue.Enqueue(5);
            queue.Enqueue(1);
            queue.Enqueue(4);
            queue.Enqueue(3);

            queue.Clear();

            Assert.Equal(0, queue.Count);
        }

        [Fact]
        public void SpecialTest()
        {
            MiloQueue<char> queue = new MiloQueue<char>();

            queue.Enqueue('a');
            queue.Enqueue('b');
            queue.Dequeue();
            queue.Enqueue('c');
            queue.Enqueue('d');
            queue.Enqueue('f');
            queue.Enqueue('a');
        }
    }
}