using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListBackedStack
{
	public class MiloStack<T>
	{
		public int Count => data.Count;
		private LinkedList<T> data;

		public MiloStack()
		{
			data = new LinkedList<T>();
		}

		public void Push(T value)
		{

			data.AddFirst(value);
		}

		public T Pop()
		{
			if (data.First == null) throw new MiloException("Bad code");

			LinkedListNode<T> node = data.First;

			data.RemoveFirst();

			return node.Value;
		}

		public T Peek()
		{
			return data.First.Value;
		}

		public void Clear()
		{
			data.Clear();
		}

		public bool IsEmpty()
		{
			return data.Count == 0;
		}
	}
}
