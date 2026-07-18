using AVLTree;
using System.ComponentModel.Design;
using Xunit.Sdk;

namespace AVLTreeTest
{
    public class AVLTest
    {
        [Fact]
        public void EmptyTest()
        {
            AVLTree<int> tree = new AVLTree<int>();
            Assert.Equal(0, tree.Count);
            Assert.False(tree.Delete(5));
        }

        [Fact]
        public void InsertTest()
        {
            AVLTree<int> tree = new AVLTree<int>();
            int[] ints = { 5, 8, 1234, 10 };
            tree.Insert(5);
            tree.Insert(8);
            tree.Insert(1234);
            tree.Insert(10);

            Assert.Equal(4, tree.Count);

            foreach (int i in ints)
            {
                Assert.True(tree.Contains(i));
            }
        }

        [Fact]
        public void DeleteTest()
        {
            AVLTree<int> tree = new AVLTree<int>();
            int[] ints = { 5, 8, 1234, 10 };
            tree.Insert(10);
            tree.Insert(15);
            tree.Insert(2);
            tree.Insert(62);
            Assert.True(tree.Delete(10));
            Assert.False(tree.Contains(10));
            Assert.Equal(15, tree.root.value);
        }

        [Theory]
        [InlineData(0, 213, 514235, 12341, 365246245, 541234)]
        [InlineData(-12341234, 23451234, 51422345, -2345234, 1872348, 187234)]
        [InlineData(2352340, 21456743, 514235, 123456741, 36235245, 23452434)]
        public void ContainsTest(params int[] seeds)
        {
            AVLTree<int> tree = new AVLTree<int>();

            for (int i = 0; i < seeds.Length; i++)
            {
                Random randy = new Random(seeds[i]);
                int[] ints = new int[100];
                for (int x = 0; x < 100; x++)
                {
                    int randomValue = randy.Next();
                    tree.Insert(randomValue);
                    ints[x] = randomValue;
                }
                foreach (int y in ints)
                {
                    Assert.True(tree.Contains(y));
                }
            }
        }
    }
}