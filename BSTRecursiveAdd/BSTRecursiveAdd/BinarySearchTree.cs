using System.Xml.Linq;

namespace BSTRecursiveAdd
{
	public class BinarySearchTree<T> where T : IComparable<T>
	{
		private Node<T> root;
		public int Count { get; private set; }
		public T RootValue => root.Value;

		public BinarySearchTree()
		{
			root = null;
			Count = 0;
		}

		public void Insert(T value)
		{
			root = InsertRecursive(root, value);
			Count++;
		}

		public Node<T> InsertRecursive(Node<T> node, T value)
		{
			if (node is null)
			{
				return new Node<T>(value);
			}

			if (value.CompareTo(node.Value) > 0)
			{
				var temp = InsertRecursive(node.Right, value);
				node.Right = temp;
			}
			else
			{
				var temp = InsertRecursive(node.Left, value);
				node.Left = temp;
			}

			return node;
		}

		public Node<T> Search(T value)
		{
			Node<T> node = SearchRecursive(root, value);

			if (node is null) throw new ArgumentNullException("value");

			return node;
		}

		public Node<T> SearchRecursive(Node<T> node, T value)
		{
			if (node is null) return node;

			if (value.CompareTo(node.Value) > 0)
			{
				return SearchRecursive(node.Right, value);
			}
			else if (value.CompareTo(node.Value) < 0)
			{
				return SearchRecursive(node.Left, value);
			}

			if (node.Value.CompareTo(value) == 0) return node;

			return null;
		}

		public bool Remove(T value)
		{

		}

		public Node<T> RemoveHelper(Node<T> value)
		{

		}

		public Node<T> RemoveRecursive(Node<T> node, T value)
		{
			if (node is null) throw new NullReferenceException("node");

			if (node.Value.CompareTo(value) > 0)
			{
				node.Right.Value = value;
			}
			else if (node.Value.CompareTo(value) < 0)
			{
				node.Left.Value = value;
			}
		}
	}
}
