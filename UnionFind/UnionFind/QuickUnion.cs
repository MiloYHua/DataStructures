using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml.Linq;

namespace UnionFind
{
	public class Node<T>
	{
		public T Value { get; set; }
		public int ParentID { get; set; }
		public int Height { get; set; }

		public Node() { }
		public Node(int height, T value)
		{
			Height = height;
			Value = value;
		}

		public Node(int parentID, int height, T value)
		{
			Value = value;
			ParentID = parentID;
			Height = height;
		}

		public Node(Node<T> toCopy)
		{
			Value = toCopy.Value;
			ParentID = toCopy.ParentID;
			Height = toCopy.Height;
		}
	}

	public class QuickUnion<T>
	{
		public Node<T>[] indexToParent = new Node<T>[4];
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

		private int IncrementHeights(Node<T> node)
		{
			Node<T> traveller = new(node);
			int currentID = -1;
			while (currentID != node.ParentID)
			{
				currentID = node.ParentID;
				indexToParent[traveller.ParentID].Height++;
				traveller = indexToParent[traveller.ParentID];
			}
			return currentID;
		}
		private int FindRootID(Node<T> node)
		{
			int currentID = -1;
			Node<T> traveller = new(node);
			while (currentID != traveller.ParentID)
			{
				currentID = traveller.ParentID;
				traveller = indexToParent[traveller.ParentID];
			}
			return currentID;
		}
		private int ConnectSetID(Node<T> node, int setID)
		{
			int currentID = -1;
			Node<T> traveller = new(node);
			while (currentID != traveller.ParentID)
			{
				currentID = traveller.ParentID;
				nodeToSet[traveller] = setID;
				traveller = indexToParent[traveller.ParentID];
			}
			return currentID;
		}

		public bool Add(T item)
		{
			if (item is null || !nodeToSet.TryAdd(new(0, item), Count)) return false;
			if (Length == Count) Resize();

			Node<T> node = new(Count, 0, item);
			indexToParent[Count] = node;
			nodeToSet.Add(node, Count);
			IncrementHeights(node);
			Count++;
			return true;
		}

		public bool Union(Node<T> parent, Node<T> child)
		{
			if (parent is null || child is null) return false;
			if (!nodeToSet.ContainsKey(parent) || !nodeToSet.ContainsKey(child)) return false;

			Node<T> parentRoot = indexToParent[FindRootID(parent)];
			Node<T> childRoot = indexToParent[FindRootID(child)];

			if(parentRoot.Height > childRoot.Height)
			{
				ConnectSetID(child, nodeToSet[parentRoot]);
				childRoot.ParentID = parentRoot.ParentID;
			}
			else if(childRoot.Height > parentRoot.Height)
			{ 
				ConnectSetID(parentRoot, nodeToSet[child]);
				parentRoot.ParentID = childRoot.ParentID;
			}
			else
			{
				ConnectSetID(child, nodeToSet[parentRoot]);
				childRoot.ParentID = parentRoot.ParentID;
				parentRoot.Height++;
			}
			
			return true;
			#region old union
			//if (parent is null || child is null) return false;
			//if (!nodeToSet.ContainsKey(parent) || !nodeToSet.ContainsKey(child)) return false;
			//int parentID = nodeToSet[parent];
			//int childID = nodeToSet[child];

			//if (parent.Height < child.Height)
			//{
			//	parentID = nodeToSet[child];
			//	childID = nodeToSet[parent];
			//	parent.Height++;
			//	parent.ParentID = childID;
			//}
			//else
			//{
			//	child.Height++;
			//	child.ParentID = parentID;
			//}

			//indexToParent[parentID] = indexToParent[childID];
			//nodeToSet[child] = nodeToSet[parent];
			//return true;
			#endregion
		}

		public int Find(Node<T> node)
		{
			Node<T> traveller = node;
			for (int i = 0; i < node.Height; i++)
			{
				traveller = indexToParent[node.ParentID];
			}
			int parentID = nodeToSet[traveller];

			for (int i = 0; i < node.Height; i++)
			{
				indexToParent[node.ParentID + i].ParentID = parentID;
			}
			return parentID;
		}

        public bool AreConnected(Node<T> p, Node<T> q)
        {
            if (p is null || q is null) return false;

            if (nodeToSet[q] == nodeToSet[p]) return true;
            return false;
        }
    }
}
