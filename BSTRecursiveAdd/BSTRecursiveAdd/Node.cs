namespace BSTRecursiveAdd
{
	public class Node<T>(T value)
	{
		public T Value = value;
		public Node<T> Left;
		public Node<T> Right;
	}
}
