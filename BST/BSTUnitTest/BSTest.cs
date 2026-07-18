using BST;
using System.ComponentModel.DataAnnotations;
namespace BSTUnitTest
{
    public class BSTest
    {
        [Fact]
        public void EmptyTest()
        {
            BST<int> tree = new BST<int>();

            Assert.True(tree.IsEmpty());
            Assert.Equal(0, tree.Count);
        }

        [Fact]
        public void InsertSingleTest()
        {
            BST<int> tree = new BST<int>();

            tree.Insert(10);

            Assert.Equal(1, tree.Count);
            Assert.Equal(10, tree.Root.Value);
        }

        [Fact]
        public void SearchTest()
        {
            BST<int> tree = new BST<int>();

            tree.Insert(10);
            tree.Insert(135123451);
            tree.Insert(254123415);
            tree.Insert(2123451453);
            tree.Insert(314561454);
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(365);
            tree.Insert(4);
            tree.Insert(5);
            tree.Insert(6);
            tree.Insert(7);
            tree.Insert(623455);
            tree.Insert(67245723);


            BSTNode<int> node = tree.Search(67245723);

            Assert.Equal(67245723, node.Value);
        }

        [Theory]
        [InlineData(10, 9, 8, 7, 6, 5, 4, 3, 2, 1)]
        public void MultiInsertLeftTest(params int[] nums)
        {
            BST<int> tree = new BST<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                tree.Insert(nums[i]);
            }

            BSTNode<int> treeNode = tree.Root;

            for (int i = 0; i < nums.Length; i++)
            {
                Assert.Equal(nums[i], treeNode.Value);
                treeNode = treeNode.Left;
            }
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)]
        public void MultiInsertRightTest(params int[] nums)
        {
            BST<int> tree = new BST<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                tree.Insert(nums[i]);
            }

            BSTNode<int> treeNode = tree.Root;

            for (int i = 0; i < nums.Length; i++)
            {
                Assert.Equal(nums[i], treeNode.Value);
                treeNode = treeNode.Right;
            }
        }

        [Fact]
        public void ContainsTest()
        {
            BST<int> tree = new BST<int>();

            tree.Insert(12345);
            tree.Insert(1212341345);
            tree.Insert(112341234);
            tree.Insert(21341);
            tree.Insert(12341234);
            tree.Insert(2341234);
            tree.Insert(1232341234);

            Assert.True(tree.Contains(1232341234));
        }

        [Fact]
        public void MinimumTest()
        {
            BST<int> tree = new BST<int>();

            tree.Insert(2345);
            tree.Insert(2345423);
            tree.Insert(35463);
            tree.Insert(6345);
            tree.Insert(1346);
            tree.Insert(8756);
            tree.Insert(9746);

            Assert.Equal(1346, tree.Minimum(tree.Root));
        }

        [Fact]
        public void MaximumTest()
        {
            BST<int> tree = new BST<int>();

            tree.Insert(2345);
            tree.Insert(2345423);
            tree.Insert(123456);
            tree.Insert(6345);
            tree.Insert(1346);
            tree.Insert(8756);
            tree.Insert(9746);

            Assert.Equal(2345423, tree.Maximum(tree.Root));
        }

        [Fact]
        public void Remove0ChildrenTest()
        {
            BST<int> tree = new BST<int>();

            tree.Insert(23);
            tree.Insert(345);
            tree.Insert(500);

            Assert.True(tree.Remove(500));
            Assert.False(tree.Contains(500));
        }

        [Fact]
        public void Remove1ChildTest()
        {
            BST<int> tree = new BST<int>();

            tree.Insert(5);
            tree.Insert(6);

            Assert.True(tree.Remove(5));
            Assert.False(tree.Contains(5));
        }

        [Fact]
        public void Remove2ChildrenTest()
        {
            BST<int> tree = new BST<int>();

            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(8);
            tree.Insert(10);
            tree.Insert(7);

            Assert.True(tree.Remove(5));
            Assert.False(tree.Contains(5));
        }

        [Fact]
        public void LevelOrderTraversalTest()
        {
            BST<int> tree = new BST<int>();

            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);

            List<BSTNode<int>> vals = new List<BSTNode<int>>();
            vals.Add(new BSTNode<int>(1));
            vals.Add(new BSTNode<int>(2));
            vals.Add(new BSTNode<int>(3));

            List<BSTNode<int>> actualVals = BST<int>.LevelOrderTraversal(tree.Root);

            for (int i = 0; i < vals.Count; i++)
            {
                Assert.Equal(vals[i].Value, actualVals[i].Value);
            }
        }

        [Fact]
        public void PreOrderTraversalTest()
        {
            BST<int> tree = new BST<int>();

            tree.Insert(4);
            tree.Insert(3);
            tree.Insert(6);
            tree.Insert(1);

            List<BSTNode<int>> vals = new List<BSTNode<int>>();
            vals.Add(new BSTNode<int>(4));
            vals.Add(new BSTNode<int>(3));
            vals.Add(new BSTNode<int>(1));
            vals.Add(new BSTNode<int>(6));

            List<BSTNode<int>> actualVals = BST<int>.PreOrderTraversal(tree.Root);

            for (int i = 0; i < vals.Count; i++)
            {
                Assert.Equal(vals[i].Value, actualVals[i].Value);
            }
        }


        [Fact]
        public void RecursivePreOrderTest()
        {
            BST<int> tree = new BST<int>();

            tree.Insert(4);
            tree.Insert(3);
            tree.Insert(6);
            tree.Insert(1);

            List<int> vals = [4, 3, 1, 6];

            List<int> actualVals = BST<int>.RecursivePreOrder(tree.Root);

            for (int i = 0; i < vals.Count; i++)
            {
                Assert.Equal(vals[i], actualVals[i]);
            }
        }

        [Fact]
        public void PostOrderTraversalTest()
        {
            BST<int> tree = new BST<int>();

            tree.Insert(4);
            tree.Insert(3);
            tree.Insert(6);
            tree.Insert(1);

            List<BSTNode<int>> vals = new List<BSTNode<int>>();
            vals.Add(new BSTNode<int>(4));
            vals.Add(new BSTNode<int>(6));
            vals.Add(new BSTNode<int>(3));
            vals.Add(new BSTNode<int>(1));

            List<BSTNode<int>> actualVals = BST<int>.PostOrderTraversal(tree.Root);

            for (int i = 0; i < vals.Count; i++)
            {
                Assert.Equal(vals[i].Value, actualVals[i].Value);
            }
        }

        [Fact]
        public void RecursivePostOrderTest()
        {
            BST<int> tree = new BST<int>();

            tree.Insert(4);
            tree.Insert(3);
            tree.Insert(6);
            tree.Insert(1);

            List<int> vals = [1, 3, 6, 4];

            List<int> actualVals = BST<int>.RecursivePostOrder(tree.Root);

            for (int i = 0; i < vals.Count; i++)
            {
                Assert.Equal(vals[i], actualVals[i]);
            }
        }

        [Theory]
        [InlineData(
            new int[] { 9, 4, 2, 7, 6, 17, 15, 16, 19 },
            new int[] { 2, 4, 6, 7, 9, 15, 16, 17, 19 })
        ]
        public void RecursiveInOrderTest(int[] nums, int[] expectedNums)
        {
            BST<int> tree = new BST<int>();

            for (int i = 0; i < 9; i++)
            {
                tree.Insert(nums[i]);
            }

            List<int> vals = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                vals.Add(expectedNums[i]);
            }

            List<int> result = BST<int>.RecursiveInOrder(tree.Root);

            Assert.Equal(result.Count, vals.Count);

            for (int i = 0; i < vals.Count; i++)
            {
                Assert.Equal(vals[i], result[i]);
            }
        }

        [Theory]
        [InlineData(
            new int[] { 9, 4, 2, 7, 6, 17, 15, 16, 19 },
            new int[] { 2, 4, 6, 7, 9, 15, 16, 17, 19 })
        ]
        public void InOrderTraversalTest(int[] nums, int[] expectedNums)
        {
            BST<int> tree = new BST<int>();

            for (int i = 0; i < 9; i++)
            {
                tree.Insert(nums[i]);
            }
            
            List<BSTNode<int>> vals = new List<BSTNode<int>>();
            for (int i = 0; i < 9; i++)
            {
                vals.Add(new BSTNode<int>(expectedNums[i]));
            }

            List<BSTNode<int>> result = BST<int>.InOrderTraversal(tree.Root);

            Assert.Equal(result.Count, vals.Count);

            for (int i = 0; i < vals.Count; i++)
            {
                Assert.Equal(vals[i].Value, result[i].Value);
            }
        }
    }
}