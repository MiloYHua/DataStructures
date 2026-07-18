namespace BinaryHeapTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryHeapTree<int> tree = new BinaryHeapTree<int>();
            tree.Insert(5);
            tree.Insert(8);
            tree.Insert(1);
            tree.Insert(374);
            tree.Insert(3);
            tree.Insert(-10);
            tree.HeapSort();
        }
    }
}
