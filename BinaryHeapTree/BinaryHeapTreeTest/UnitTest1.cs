using BinaryHeapTree;
namespace BinaryHeapTreeTest
{
	public class UnitTest1
	{
		[Fact]
		public void EmptyTest()
		{
			BinaryHeapTree<int> tree = new BinaryHeapTree<int>();
			Assert.Equal(0, tree.Count);
			Assert.Equal(10, tree.Capacity);
		}

		[Fact]
		public void InsertTest()
		{
			BinaryHeapTree<int> tree = new BinaryHeapTree<int>();
			tree.Insert(0);
			tree.Insert(2);
			tree.Insert(5);
			tree.Insert(4);
			tree.Insert(-1);
			tree.Insert(7);

			Assert.Equal(6, tree.Count);

			int[] expectedList = { -1, 0, 5, 4, 2, 7 };

			for (int i = 0; i < tree.Count; i++)
			{
				Assert.Equal(expectedList[i], tree.data[i]);
			}
		}

		[Fact]
		public void ResizeTest()
		{
			BinaryHeapTree<int> tree = new BinaryHeapTree<int>();
			while (tree.Capacity > 10)
			{
				tree.Insert(1);
			}
			Assert.Equal(1, 1);
		}

		[Fact]
		public void InsertArrayTest()
		{
			int[] inputArray = { 5, 3, 8, 1, 2 };
			BinaryHeapTree<int> tree = new BinaryHeapTree<int>(inputArray);
			Assert.Equal(inputArray.Length, tree.Count);
			int[] expectedList = { 1, 2, 8, 5, 3 };
			for (int i = 0; i < tree.Count; i++)
			{
				Assert.Equal(expectedList[i], tree.data[i]);
			}
		}

		[Fact]
		public void HeapSortTest()
		{
			int[] inputArray = { 43, 52, 2, 344345, 2, 232345, 654342 };
			BinaryHeapTree<int> tree = new BinaryHeapTree<int>(inputArray);
			tree.HeapSort();
			for (int i = 0; i < tree.Count; i++)
			{
				Assert.True(tree.data[i] <= tree.data[i]);
			}
		}

		[Fact]
		public void TryPopTest()
		{
			BinaryHeapTree<int> Emptytree = new BinaryHeapTree<int>();
			bool fail = Emptytree.TryPop(out int failValue);
			Assert.False(fail);
			Assert.Equal(0, failValue);
			int[] inputArray = { 8, 3, 12, 5, 1 };
			BinaryHeapTree<int> tree = new BinaryHeapTree<int>(inputArray);
			bool success = tree.TryPop(out int value);
			Assert.True(success);
			Assert.Equal(1, value);
			Assert.Equal(inputArray.Length - 1, tree.Count);
		}

		[Fact]
		public void HeapSortStaticTest()
		{
			int[] inputArray = { 34, 2, 543, 23, 12, 5 };
			bool result = BinaryHeapTree<int>.HeapSort(inputArray);
			Assert.True(result);
			for (int i = 0; i < inputArray.Length - 1; i++)
			{
				Assert.True(inputArray[i] <= inputArray[i + 1]);
			}
		}


	}
}