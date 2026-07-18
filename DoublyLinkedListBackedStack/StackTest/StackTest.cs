using DoublyLinkedListBackedStack;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackTest
{
	public class StackTest
	{
		[Fact]
		public void EmptyTest()
		{ 
			MiloStack<int> stack = new MiloStack<int>();

			Assert.Equal(0, stack.Count);
			Assert.Throws<NullReferenceException>(() => stack.Peek());
			Assert.Throws<MiloException>(() => stack.Pop());			
		}

		[Fact]
		public void PushOneTest()
		{
			MiloStack<int> stack = new MiloStack<int>();

			stack.Push(1);

			Assert.Equal(1, stack.Count);
			Assert.Equal(1, stack.Peek());			
		}

		[Fact]
		public void PopOneTest()
		{
			MiloStack<int> stack = new MiloStack<int>();

			stack.Push(1);

			Assert.Equal(1, stack.Pop());			
		}

		[Theory]
		[InlineData(new int[] { 1, 2 })]
		[InlineData(new int[] { 3, 4, 1, 5, 6 })]
		public void PushMultiTest(int[] nums)
		{
			MiloStack<int> stack = new MiloStack<int>();

			for (int i = 0; i < nums.Length; i++)
			{
				stack.Push(nums[i]);
			}

			Assert.Equal(stack.Count, nums.Length);
			Assert.Equal(stack.Peek(), nums[nums.Length - 1]);
		}

		[Theory]
		[InlineData(new int[] { 1, 2, 9 })]
        public void PopMultiTest(int[] nums)
        {
            MiloStack<int> stack = new MiloStack<int>();

			for(int i = 0; i < nums.Length; i++)
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
			MiloStack<int> stack = new MiloStack<int>();

			stack.Push(1);

			Assert.Equal(1, stack.Peek());
		}

		[Fact]
		public void ClearOneTest()
		{
            MiloStack<int> stack = new MiloStack<int>();

			stack.Push(1);
            stack.Push(2);
            stack.Push(3);
			stack.Clear();

			Assert.True(stack.IsEmpty());
        }

    }
}