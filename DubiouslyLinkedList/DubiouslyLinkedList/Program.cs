using DubiousNode;

namespace DubiouslyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DubiouslyLinkedList<int> bob = new DubiouslyLinkedList<int>();
            bob.AddFirst(1);
            bob.AddFirst(2);
            bob.AddBefore(bob.Head, 5);
            bob.AddLast(4);
            bob.AddAfter(bob.Head, 27);
            bob.Remove(bob.Head);

            DubiousNode<int> john = bob.Search(2);

            bob.Clear();

            bob.AddFirst(1);
            bool yes = bob.Contains(1);
            bob.AddLast(3);
            bob.AddBefore(bob.Search(1), 0);
            bob.AddAfter(bob.Search(3), 4);
            bool no = bob.Contains(2);

            bob.Remove(bob.Search(0));
            bob.Remove(bob.Search(4));
            bob.Remove(bob.Search(3));
            bob.Remove(bob.Search(1));

            bob.AddFirst(1);
            bob.RemoveFirst();

            bob.AddLast(1);
            bob.RemoveLast();
        }
    }
}
