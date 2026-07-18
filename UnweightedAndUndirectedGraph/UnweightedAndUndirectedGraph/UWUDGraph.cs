namespace UnweightedAndUndirectedGraph
{
    class Edge<T>
    {
        public Vertex<T> Previous { get; set; }
        public Vertex<T> Next { get; set; }

        public Edge(Vertex<T> previous, Vertex<T> start)
        {
            Previous = previous;
            Next = start;
        }
    }

    public class UWUDGraph<T>
    {
        public List<Vertex<T>> Vertices { get; private set; }

        public UWUDGraph()
        {
            Vertices = new List<Vertex<T>>();
        }

        public bool AddVertex(Vertex<T> vertex)
        {
            if (vertex is null || Vertices.Contains(vertex)) return false;

            Vertices.Add(vertex);
            return true;
        }

        public bool RemoveVertex(Vertex<T> vertex)
        {
            if (vertex is null || !Vertices.Contains(vertex)) return false;

            foreach (Vertex<T> toCheck in vertex.Neighbors)
            {
                toCheck.Neighbors.Remove(vertex);
            }

            return true;
        }

        public bool AddEdge(Vertex<T> a, Vertex<T> b)
        {
            if (a.Neighbors.Contains(b)) return false;

            a.Neighbors.Add(b);
            b.Neighbors.Add(a);
            return true;
        }

        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            if (!a.Neighbors.Contains(b)) return false;

            a.Neighbors.Remove(b);
            b.Neighbors.Remove(a);
            return true;
        }

        public Vertex<T> Search(T value)
        {
            return Vertices.Find(v => v.Value.Equals(value));
        }

        public List<T> DepthFirstTraversal(Vertex<T> node) => RecursingDFT(new HashSet<Vertex<T>>(), node);

        private List<T> RecursingDFT(HashSet<Vertex<T>> visitedVertices, Vertex<T> vertex)
        {
            if (vertex is null) return new List<T>();
            List<T> result = [];
            visitedVertices.Add(vertex);

            foreach (Vertex<T> v in vertex.Neighbors)
            {
                if (!visitedVertices.Contains(v))
                {
                    result.AddRange(RecursingDFT(visitedVertices, v));
                }
            }

            result.Add(vertex.Value);

            return result;
        }

        public List<T> BreadthFirstTraversal(Vertex<T> vertex)
        {
            List<Vertex<T>> visitedVerticies = new List<Vertex<T>>();
            Queue<Vertex<T>> needToVisitVerticies = new Queue<Vertex<T>>();
            needToVisitVerticies.Enqueue(vertex);

            while (needToVisitVerticies.Count > 0)
            {
                Vertex<T> current = needToVisitVerticies.Dequeue();
                visitedVerticies.Add(current);

                foreach (Vertex<T> v in current.Neighbors)
                {
                    if (!needToVisitVerticies.Contains(v) && !visitedVerticies.Contains(v))
                    {
                        needToVisitVerticies.Enqueue(v);
                    }
                }
            }
            return visitedVerticies.Select(v => v.Value).ToList();
        }

        public List<Vertex<T>> ShortestPathOldOutdatedArchaicDepricated(Vertex<T> startingVertex, Vertex<T> endingVertex)
        {
            List<Vertex<T>> visitedVerticies = new List<Vertex<T>>();
            List<Vertex<T>> pathOfVerticies = new List<Vertex<T>>();
            Queue<Vertex<T>> needToVisitVerticies = new Queue<Vertex<T>>();
            Dictionary<Vertex<T>, Edge<T>> vertexEdgePair = new();
            Vertex<T> current = startingVertex;
            needToVisitVerticies.Enqueue(startingVertex);

            while (needToVisitVerticies.Count > 0)
            {
                vertexEdgePair.TryAdd(current, new Edge<T>(current, needToVisitVerticies.Peek()));
                current = needToVisitVerticies.Dequeue();

                if (current == endingVertex) break;
                visitedVerticies.Add(current);

                foreach (Vertex<T> v in current.Neighbors)
                {
                    needToVisitVerticies.Enqueue(v);
                }
            }

            Vertex<T> currentVertex = startingVertex;

            while (true)
            {
                if (vertexEdgePair.TryGetValue(currentVertex, out Edge<T> edge))
                {
                    pathOfVerticies.Add(currentVertex);
                    if (currentVertex == endingVertex) break;
                    currentVertex = edge.Next;
                }
            }

            return pathOfVerticies;
        }

        public List<Vertex<T>> ShortestPath(Vertex<T> startingVertex, Vertex<T> endingVertex)
        {
            List<Vertex<T>> visitedVerticies = new List<Vertex<T>>();
            Queue<Vertex<T>> needToVisitVerticies = new Queue<Vertex<T>>();
            Dictionary<Vertex<T>, Vertex<T>> reverseBreadcrumbs = new();
            //think of htis as breadcrumbs, make connections from the end back once you are there.
            needToVisitVerticies.Enqueue(startingVertex);

            while (needToVisitVerticies.Count > 0)
            {
                Vertex<T> current = needToVisitVerticies.Dequeue();

                visitedVerticies.Add(current);

                if (current == endingVertex) break;

                foreach (Vertex<T> v in current.Neighbors)
                {
                    needToVisitVerticies.Enqueue(v);
                    reverseBreadcrumbs.TryAdd(v, current);
                }
            }

            Vertex<T> pathFinder = endingVertex;
            List<Vertex<T>> pathOfVerticies = [endingVertex];

            while (pathFinder != startingVertex)
            {
                pathFinder = reverseBreadcrumbs[pathFinder];
                pathOfVerticies.Add(pathFinder);
            }

            pathOfVerticies.Reverse();
            return pathOfVerticies;
        }
    }
}