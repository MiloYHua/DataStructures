using System.Drawing;

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

    public class QuickFind<T> : IUnionFind<T>
    {
        public LinkedList<T>[] Sets = new LinkedList<T>[4];

        public Dictionary<T, int> Pairs = [];

        public int Length { get; private set; } = 4;
        public int Count { get; private set; } = 0;

        public QuickFind()
        {
            for (int i = 0; i < Sets.Length; i++)
            {
                Sets[i] = [];
            }
        }

        public void Resize()
        {
            LinkedList<T>[] newSets = new LinkedList<T>[Length * 2];
            Length *= 2;

            for (int i = 0; i < Sets.Length; i++)
            {
                newSets[i] = Sets[i];
            }
            for (int i = Sets.Length; i < Length; i++)
            {
                newSets[i] = [];
            }
            Sets = newSets;
        }

        public bool Add(T a)
        {
            if (a is null || Pairs.Keys.Contains(a)) return false;
            if (Count == Length) Resize();

            Sets[Count].AddFirst(a);
            Pairs.Add(a, Count);
            Count++;

            return true;
        }

        public int Find(T p) => Pairs[p];

        public bool Union(T p, T q)
        {
            if (p is null || q is null) return false;

            LinkedList<T> setP = Sets[Pairs[p]];
            foreach (T item in setP)
            {
                Pairs[item] = Pairs[p];
            }

            return true;
        }

        public bool AreConnected(T p, T q)
        {+
            if (p is null || q is null) return false;

            if (Pairs[q] == Pairs[p]) return true;
            return false;
        }
    }
}
