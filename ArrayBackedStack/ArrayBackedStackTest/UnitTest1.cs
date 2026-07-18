using ArrayBackedStack;
using System.IO;

namespace ArrayBackedStackTest
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyTest()
        {
            ThEpicMiloStack<int> stack = new ThEpicMiloStack<int>();

            Assert.Equal(0, stack.Count);
            Assert.Throws<NullReferenceException>(() => stack.Peek());
            Assert.Throws<MiloException>(() => stack.Pop());
        }

        [Fact]
        public void PushOneTest()
        {
            ThEpicMiloStack<int> stack = new ThEpicMiloStack<int>();

            stack.Push(1);

            Assert.Equal(1, stack.Count);
            Assert.Equal(1, stack.Peek());
        }

        [Fact]
        public void PopOneTest()
        {
            ThEpicMiloStack<int> stack = new ThEpicMiloStack<int>();

            stack.Push(1);

            Assert.Equal(1, stack.Pop());
        }

        [Theory]
        [InlineData(new int[] { 1, 2 })]
        [InlineData(new int[] { 3, 4, 1, 5, 6 })]
        public void PushMultiTest(int[] nums)
        {
            ThEpicMiloStack<int> stack = new ThEpicMiloStack<int>();

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                stack.Push(nums[i]);
            }

            Assert.Equal(stack.Count, nums.Length);
            int bob = stack.Peek();
            Assert.Equal(stack.Peek(), nums[0]);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 9 })]
        public void PopMultiTest(int[] nums)
        {
            ThEpicMiloStack<int> stack = new ThEpicMiloStack<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                stack.Push(nums[i]);
            }

            for (int i = nums.Length - 1; i > 0; i--)
            {
                Assert.Equal(nums[i], stack.Pop());
            }
        }

        [Fact]
        public void PeekOneTest()
        {
            ThEpicMiloStack<int> stack = new ThEpicMiloStack<int>();

            stack.Push(1);

            Assert.Equal(1, stack.Peek());
        }

        [Fact]
        public void ClearOneTest()
        {
            ThEpicMiloStack<int> stack = new ThEpicMiloStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Clear();

            Assert.True(stack.IsEmpty());
        }
    }
}