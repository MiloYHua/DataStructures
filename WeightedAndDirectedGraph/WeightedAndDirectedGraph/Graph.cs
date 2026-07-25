using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeightedAndDirectedGraph
{
	public enum VertexState
	{
		Start,
		End,
		Frontier,
		Visited,
		Path,
		Undiscovered
	}

	public record class Edge<T>(Vertex<T> StartVertex, Vertex<T> EndVertex, float Cost);

	public class Vertex<T>(T value)
	{
		public T Value { get; set; } = value;
		public List<Edge<T>> Edges { get; set; } = new List<Edge<T>>();
	}
	class VertexInfo<T>
	{
		public Vertex<T> Vertex { get; set; }

		public bool IsVisited { get; set; }
		public float TotalCost { get; set; }
		public Edge<T> FoundingEdge { get; set; }

		public VertexInfo(Vertex<T> vertex, float totalCost, Edge<T> foundingEdge)
		{
			Vertex = vertex;
			TotalCost = totalCost;
			FoundingEdge = foundingEdge;
		}
	}

	public class Graph<T>
	{
		private HashSet<Vertex<T>> vertices;
		private HashSet<Edge<T>> edges;

		public IReadOnlyCollection<Vertex<T>> Vertices { get { return vertices; } }
		public IReadOnlyCollection<Edge<T>> Edges { get { return edges; } }

		public Graph() : this([], []) { }

		public Graph(HashSet<Vertex<T>> vertices, HashSet<Edge<T>> edges)
		{
			this.vertices = vertices;
			this.edges = edges;
		}

		public bool AddVertex(Vertex<T> vertex)
		{
			if (vertex is null || vertices.Contains(vertex)) return false;

			vertices.Add(vertex);
			return true;
		}

		public bool RemoveVertex(Vertex<T> vertex)
		{
			if (vertex is null || !vertices.Contains(vertex)) return false;

			vertices.Remove(vertex);
			return true;
		}

		public bool AddEdge(Vertex<T> a, Vertex<T> b, float distance)
		{
			if (a is null || b is null || edges.Contains(new(a, b, distance))) return false;

			Edge<T> edge = new(a, b, distance);

			a.Edges.Add(edge);

			edges.Add(edge);
			return true;
		}

		public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
		{
			if (a is null || b is null) return false;

			foreach (Edge<T> edge in a.Edges)
			{
				if (edge.EndVertex == b)
				{
					a.Edges.Remove(edge);
					edges.Remove(edge);
					return true;
				}
			}
			return false;
		}

		public bool DualRemoveEdge(Edge<T> edge)
		{
            if (edge is null) return false;

			Edge<T> reverseEdge = new Edge<T>(edge.EndVertex, edge.StartVertex, edge.Cost);

            bool happened = edge.StartVertex.Edges.Remove(reverseEdge);
            bool happened1 = edge.EndVertex.Edges.Remove(reverseEdge);
            bool thing = edge.StartVertex.Edges.Remove(edge);
			bool thing1 = edge.EndVertex.Edges.Remove(edge);
			edges.Remove(edge);

			return true;
        }

        public Vertex<T> Search(T value)
		{
			foreach (Vertex<T> vertex in vertices)
			{
				if (EqualityComparer<T>.Default.Equals(vertex.Value, value))
				{
					return vertex;
				}
			}
			return null;
		}

		public Edge<T> GetEdge(Vertex<T> a, Vertex<T> b)
		{
			foreach (Edge<T> edge in edges)
			{
				if (edge.StartVertex == a && edge.EndVertex == b)
				{
					return edge;
				}
			}
			return null;
		}

		public (List<Dictionary<Vertex<T>, VertexState>>, List<T>) DFS(Vertex<T> a, Vertex<T> b)
		{
			List<Dictionary<Vertex<T>, VertexState>> graphChanges = new();
			List<T> order = new();
			HashSet<Vertex<T>> visited = new();
            Stack<Vertex<T>> backtrackBreadcrumbs = new();

			backtrackBreadcrumbs.Push(a);

			while (backtrackBreadcrumbs.Count > 0)
			{
				Vertex<T> current = backtrackBreadcrumbs.Pop();
                graphChanges.Add(new Dictionary<Vertex<T>, VertexState>());
                graphChanges.Last().Add(current, VertexState.Visited);

                if (current.Edges.Count == 0 || current.Edges.All(x => visited.Contains(x.EndVertex)))
				{
					order.Add(current.Value);
					visited.Add(current);
                    continue;
				}

				foreach (Edge<T> edge in current.Edges)
				{
					if (order.Contains(edge.EndVertex.Value)) break;

					backtrackBreadcrumbs.Push(edge.EndVertex);
                    graphChanges.Last().Add(edge.EndVertex, VertexState.Frontier);
                }

				order.Add(current.Value);
                visited.Add(current);
            }
			return (graphChanges, order);
		}

		public (List<Dictionary<Vertex<T>, VertexState>> steps, List<T> path) BFS(Vertex<T> a, Vertex<T> b)
		{
			List<T> order = new();
			HashSet<Vertex<T>> visited = new();
			Queue<Vertex<T>> needToVisit = new();
            List<Dictionary<Vertex<T>, VertexState>> graphChanges = new();

			needToVisit.Enqueue(a);

			while (needToVisit.Count > 0)
			{
				Vertex<T> current = needToVisit.Dequeue();
				order.Add(current.Value);
                graphChanges.Add(new Dictionary<Vertex<T>, VertexState>());
                graphChanges.Last().Add(current, VertexState.Visited);

                foreach (Edge<T> edge in current.Edges)
				{
					if (visited.Contains(edge.EndVertex)) continue;
					needToVisit.Enqueue(edge.EndVertex);
                    graphChanges.Last().Add(edge.EndVertex, VertexState.Frontier);
                    visited.Add(edge.EndVertex);
				}
			}

			return (graphChanges, order);
		}


		public (List<Dictionary<Vertex<T>, VertexState>> steps, List<T> path) Dijkstras(Vertex<T> a, Vertex<T> b)
		{
			Dictionary<Vertex<T>, VertexInfo<T>> vertexInfoMaps = new()
			{
				[a] = new VertexInfo<T>(a, 0, null)
			};

            List<Dictionary<Vertex<T>, VertexState>> graphChanges = new();
            PriorityQueue<Vertex<T>, float> weightPriority = new();
			HashSet<Vertex<T>> visited = new();

			weightPriority.Enqueue(a, 0);

			Vertex<T> current = a;

			while (true)
			{
				current = weightPriority.Dequeue();
				if (visited.Contains(current)) continue;

                graphChanges.Add(new Dictionary<Vertex<T>, VertexState>());
                graphChanges.Last().Add(current, VertexState.Visited);

                visited.Add(current);

				foreach (Edge<T> edge in current.Edges)
				{
					vertexInfoMaps.TryAdd(edge.EndVertex, new VertexInfo<T>(edge.EndVertex, float.PositiveInfinity, edge));
                    graphChanges.Last().Add(edge.EndVertex, VertexState.Frontier);

                    float totalCost = vertexInfoMaps[edge.EndVertex].TotalCost;
					float tentativeCost = vertexInfoMaps[current].TotalCost + edge.Cost;

					if (tentativeCost < totalCost)
					{
						weightPriority.Enqueue(edge.EndVertex, tentativeCost);
						vertexInfoMaps[edge.EndVertex].TotalCost = tentativeCost;
						vertexInfoMaps[edge.EndVertex].FoundingEdge = edge;
					}
				}

				if (current == b) break;
			}

			List<T> path = new();

			while (vertexInfoMaps[current].FoundingEdge is not null)
			{
				VertexInfo<T> pathfinder = vertexInfoMaps[current];

				path.Add(pathfinder.Vertex.Value);
				current = vertexInfoMaps[current].FoundingEdge.StartVertex;
			}
			path.Add(a.Value);
			path.Reverse();

			return (graphChanges, path);
		}

		public (List<Dictionary<Vertex<T>, VertexState>> steps, List<T> path) AStar(Vertex<T> a, Vertex<T> b, Func<Vertex<T>, Vertex<T>, float> heuristic)
		{
			Dictionary<Vertex<T>, VertexInfo<T>> vertexInfoMaps = new()
			{
				[a] = new VertexInfo<T>(a, 0, null)
			}; 

			List<Dictionary<Vertex<T>, VertexState>> graphChanges = new(); 
			PriorityQueue<Vertex<T>, float> weightPriority = new();
			HashSet<Vertex<T>> visited = new();

			weightPriority.Enqueue(a, 0);

			Vertex<T> current = a;

			while (true)
			{
				current = weightPriority.Dequeue();
				graphChanges.Add(new Dictionary<Vertex<T>, VertexState>());
				graphChanges.Last().Add(current, VertexState.Visited);

				if (visited.Contains(current)) continue;

				visited.Add(current);

				foreach (Edge<T> edge in current.Edges)
				{
					vertexInfoMaps.TryAdd(edge.EndVertex, new VertexInfo<T>(edge.EndVertex, float.PositiveInfinity, edge));
					graphChanges.Last().Add(edge.EndVertex, VertexState.Frontier);

					float totalCost = vertexInfoMaps[edge.EndVertex].TotalCost;
					float tentativeCost = vertexInfoMaps[current].TotalCost + edge.Cost;

					if (tentativeCost < totalCost)
					{
						vertexInfoMaps[edge.EndVertex].TotalCost = tentativeCost;
						vertexInfoMaps[edge.EndVertex].FoundingEdge = edge;
						weightPriority.Enqueue(edge.EndVertex, tentativeCost + heuristic(edge.EndVertex, b));
					}
				}

				if (current == b) break;
			}

			List<T> path = new();

			while (vertexInfoMaps[current].FoundingEdge is not null)
			{
				VertexInfo<T> pathfinder = vertexInfoMaps[current];

				path.Add(pathfinder.Vertex.Value);
				current = vertexInfoMaps[current].FoundingEdge.StartVertex;
			}
			path.Add(a.Value);
			path.Reverse();

			return (graphChanges, path);
		}
	}
}