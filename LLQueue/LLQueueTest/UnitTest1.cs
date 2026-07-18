using LLQueue;
using System.Numerics;

namespace LLQueueTest
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyTest()
        {
            MiloQueue<int> queue = new MiloQueue<int>();
             
            Assert.Equal(0, queue.Count);
            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void SingleEnqueueTest()
        {
            MiloQueue<int> queue = new MiloQueue<int>();

            queue.Enqueue(1);

            Assert.Equal(1, queue.Count);
            Assert.Equal(1, queue.Peek());
        }

        [Fact]
        public void SingleDequeueTest()
        {
            MiloQueue<int> queue = new MiloQueue<int>();

            queue.Enqueue(1);

            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(0, queue.Count);
            Assert.Throws<NullReferenceException>(() => queue.Peek());
        }

        [Theory]
        [InlineData(0, 1, 2, 3)]
        public void MultiEnqueueTest(params int[] nums)
        {
            MiloQueue<int> queue = new MiloQueue<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                queue.Enqueue(nums[i]);
            }

            LinkedListNode<int> hubertBlaineWolfeschlegelsteinhausenbergerdorffSr = queue.data.First;

            Assert.Equal(nums.Length, queue.Count);

            for (int i = 0; i < nums.Length; i++)
            {
                Assert.Equal(nums[i], hubertBlaineWolfeschlegelsteinhausenbergerdorffSr.Value);

                hubertBlaineWolfeschlegelsteinhausenbergerdorffSr = hubertBlaineWolfeschlegelsteinhausenbergerdorffSr.Next;
            }
        }

        [Theory]
        [InlineData(0, 1, 2, 3)]
        public void MultiDequeueTest(params int[] nums)
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

            Assert.Throws<NullReferenceException>(() => queue.Dequeue());
        }

        [Fact]
        public void ClearTest()
        {
            MiloQueue<int> queue = new MiloQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(5);

            queue.Clear();

            Assert.Equal(0, queue.Count);
        }
    }
}