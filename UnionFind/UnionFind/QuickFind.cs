namespace UnionFind
{
	interface IUnionFind<T>
	{
		// Returns the set that p belongs to
		int Find(T p);

		// Connects p and q — returns true if successful, false otherwise
		bool Union(T p, T q);

		// Returns true if p and q are connected, false otherwise
		bool AreConnected(T p, T q);
	}

	public class QuickFind<T>
	{
		LinkedList<T>[] Sets = new LinkedList<T>[4];

		public int Count { get; private set; } = 0;
		public int Length { get; private set; } = 4;

		public QuickFind()
		{
			for(int i = 0; i < Sets.Length; i++)
			{
				Sets[i] = [];
			}
		}

		public int GetID(T a)
		{
			if (Sets.Length < 0) throw new ArgumentException("Bucket was empty");
			int hashCode = a.GetHashCode();
			return Math.Abs(hashCode % Sets.Length);
		}
		public int GetNewID(T a)
		{
			int hashCode = a.GetHashCode();
			return Math.Abs(hashCode % (Sets.Length * 2));
		}
		public void Resize()
		{
			LinkedList<T>[] newSets = new LinkedList<T>[Length * 2];

			foreach(Linked)
		}

		public bool Add(T a)
		{
			if (a is null) return false;
			if (Count == Length) Length *= 2;


			Sets[Count].AddFirst(a);
			Count++;

			return true;
		}
	}
}
