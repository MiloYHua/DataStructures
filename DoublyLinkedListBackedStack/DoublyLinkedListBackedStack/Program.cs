namespace DoublyLinkedListBackedStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MiloStack<int> stack = new MiloStack<int>();
            stack.Push(1);
            int bob = stack.Peek();
            stack.Push(2);
			int timmy = stack.Peek();

            int tom = stack.Pop();
        }
    }
}
