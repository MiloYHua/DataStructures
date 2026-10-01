using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
	public class Node<T>
	{
		public T Value { get; set; }
		public int ParentID { get; set; }
		public int Depth { get; set; }

		public Node() { }
		public Node(int depth, T value)
		{
			Depth = depth;
			Value = value;
		}
		public Node(int parentID, int depth)
		{
			ParentID = parentID;
			Depth = depth;
		}
	}

	public class QuickUnion<T>
	{
		Node<T>[] indexToParent = new Node<T>[4];
		public Dictionary<Node<T>, int> nodeToSet = [];

		public int Length { get; private set; } = 4;
		public int Count { get; private set; } = 0;

		public QuickUnion() { }

		public void Resize()
		{
			Node<T>[] newSets = new Node<T>[Length * 2];
			Length *= 2;

			for (int i = 0; i < indexToParent.Length; i++)
			{
				newSets[i] = indexToParent[i];
			}
			for (int i = indexToParent.Length; i < Length; i++)
			{
				newSets[i] = default;	
			}
			indexToParent = newSets;
		}

		public bool Add(T item)
		{
			if (item is null || !nodeToSet.TryAdd(new(0, item), Count)) return false;
			if (Length == Count) Resize();

			indexToParent[Count] = new(0, item);
			Count++;
			return true;
		}

		public bool Union(Node<T> parent, Node<T> child)
		{
			if (parent is null || child is null) return false;
			if (!nodeToSet.ContainsKey(parent) || !nodeToSet.ContainsKey(child)) return false;
			int parentID = nodeToSet[parent];
			int childID = nodeToSet[child];

			if (parent.Depth < child.Depth)
			{
				parentID = nodeToSet[child];
				childID = nodeToSet[parent];
				parent.Depth++;
				parent.ParentID = childID;
			}
			else
			{
				child.Depth++;
				child.ParentID = parentID;
			}

			indexToParent[parentID] = indexToParent[childID];
			nodeToSet[child] = nodeToSet[parent];
			return true;
		}

		public int Find(Node<T> node)
		{
			Node<T> traveller = node;
			for (int i = 0; i < node.Depth; i++)
			{
				traveller = indexToParent[node.ParentID];
			}
			int parentID = nodeToSet[traveller];

			for (int i = 0; i < node.Depth; i++)
			{
				indexToParent[node.ParentID + i].ParentID = parentID;
			}
			return parentID;
		}
	}
}
