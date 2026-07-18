using System.Diagnostics.Contracts;
using System.Drawing;
using WeightedAndDirectedGraph;

namespace WDGTest
{
	public class WDGTests
	{
		[Fact]
		public void AddVertexAndSearchTest()
		{
			Graph<int> graph = new Graph<int>();

			graph.AddVertex(new Vertex<int>(1));
			graph.AddVertex(new Vertex<int>(2));
			graph.AddVertex(new Vertex<int>(3));

			Assert.NotNull(graph.Search(1));
			Assert.NotNull(graph.Search(2));
			Assert.NotNull(graph.Search(3));
		}

		[Fact]
		public void RemoveVertexTest()
		{
			Graph<int> graph = new Graph<int>();

			Vertex<int> v1 = new Vertex<int>(1);
			Vertex<int> v2 = new Vertex<int>(2);
			Vertex<int> v3 = new Vertex<int>(3);

			graph.AddVertex(v1);
			graph.AddVertex(v2);
			graph.AddVertex(v3);

			graph.RemoveVertex(v1);
			graph.RemoveVertex(v2);
			graph.RemoveVertex(v3);

			Assert.Null(graph.Search(1));
			Assert.Null(graph.Search(2));
			Assert.Null(graph.Search(3));
		}

		[Fact]

		public void DFSTest()
		{
			Graph<int> graph = new Graph<int>();

			Vertex<int>[] Vs = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }.Select(v => new Vertex<int>(v)).ToArray();

			int[] order = [0, 5, 9, 8, 6, 2, 1, 4, 7, 3];

			foreach (var vertex in Vs)
			{
				graph.AddVertex(vertex);
			}

			graph.AddEdge(Vs[0], Vs[1], 1);
			graph.AddEdge(Vs[0], Vs[2], 1);
			graph.AddEdge(Vs[0], Vs[5], 1);
			graph.AddEdge(Vs[1], Vs[3], 1);
			graph.AddEdge(Vs[1], Vs[4], 1);
			graph.AddEdge(Vs[2], Vs[5], 1);
			graph.AddEdge(Vs[3], Vs[2], 1);
			graph.AddEdge(Vs[3], Vs[6], 1);
			graph.AddEdge(Vs[4], Vs[7], 1);
			graph.AddEdge(Vs[4], Vs[2], 1);
			graph.AddEdge(Vs[5], Vs[8], 1);
			graph.AddEdge(Vs[5], Vs[6], 1);
			graph.AddEdge(Vs[5], Vs[9], 1);

			int[] result = graph.DFSPathfinding(Vs[0], Vs[9]).Select(v => v.Value).ToArray();
			Assert.Equal(order, result);
		}

		[Fact]

		public void BFSTest()
		{
			Graph<int> graph = new Graph<int>();
			Vertex<int>[] Vs = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }.Select(v => new Vertex<int>(v)).ToArray();
			int[] order = [0, 1, 2, 5, 3, 4, 6, 8, 9, 7];
			foreach (var vertex in Vs)
			{
				graph.AddVertex(vertex);
			}
			graph.AddEdge(Vs[0], Vs[1], 1);
			graph.AddEdge(Vs[0], Vs[2], 1);
			graph.AddEdge(Vs[0], Vs[5], 1);
			graph.AddEdge(Vs[1], Vs[3], 1);
			graph.AddEdge(Vs[1], Vs[4], 1);
			graph.AddEdge(Vs[2], Vs[5], 1);
			graph.AddEdge(Vs[3], Vs[2], 1);
			graph.AddEdge(Vs[3], Vs[6], 1);
			graph.AddEdge(Vs[4], Vs[2], 1);
			graph.AddEdge(Vs[4], Vs[7], 1);
			graph.AddEdge(Vs[5], Vs[8], 1);
			graph.AddEdge(Vs[5], Vs[6], 1);
			graph.AddEdge(Vs[5], Vs[9], 1);
			int[] result = graph.BFSPathfinding(Vs[0], Vs[9]).Select(v => v.Value).ToArray();
			Assert.Equal(order, result);
		}

		[Fact]

		public void DijkstrasTest()
		{
			Graph<int> graph = new Graph<int>();
			Vertex<int>[] Vs = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }.Select(v => new Vertex<int>(v)).ToArray();
			int[] path = [0, 5, 7, 11];

			foreach (var vertex in Vs)
			{
				graph.AddVertex(vertex);
			}

			graph.AddEdge(Vs[0], Vs[1], 0.59f);
			graph.AddEdge(Vs[1], Vs[2], 0.17f);
			graph.AddEdge(Vs[2], Vs[3], 0.89f);
			graph.AddEdge(Vs[3], Vs[4], 0.63f);
			graph.AddEdge(Vs[4], Vs[5], 0.71f);
			graph.AddEdge(Vs[5], Vs[6], 0.78f);
			graph.AddEdge(Vs[6], Vs[7], 0.58f);
			graph.AddEdge(Vs[7], Vs[8], 0.84f);
			graph.AddEdge(Vs[8], Vs[9], 0.89f);
			graph.AddEdge(Vs[9], Vs[10], 0.88f);
			graph.AddEdge(Vs[10], Vs[11], 0.78f);
			graph.AddEdge(Vs[0], Vs[3], 0.71f);
			graph.AddEdge(Vs[0], Vs[5], 0.71f);
			graph.AddEdge(Vs[1], Vs[4], 0.41f);
			graph.AddEdge(Vs[2], Vs[6], 0.4f);
			graph.AddEdge(Vs[2], Vs[8], 0.26f);
			graph.AddEdge(Vs[3], Vs[7], 0.48f);
			graph.AddEdge(Vs[4], Vs[8], 0.31f);
			graph.AddEdge(Vs[4], Vs[9], 0.32f);
			graph.AddEdge(Vs[5], Vs[7], 0.16f);
			graph.AddEdge(Vs[6], Vs[9], 0.41f);
			graph.AddEdge(Vs[6], Vs[10], 0.53f);
			graph.AddEdge(Vs[7], Vs[11], 0.35f);
			graph.AddEdge(Vs[8], Vs[10], 0.76f);
			graph.AddEdge(Vs[9], Vs[11], 0.64f);
			graph.AddEdge(Vs[10], Vs[11], 0.54f);
			graph.AddEdge(Vs[3], Vs[6], 0.19f);
			graph.AddEdge(Vs[5], Vs[9], 0.77f);

			int[] result = graph.DijkstrasPathfinding(Vs[0], Vs[11]).Select(v => v.Value).ToArray();

			Assert.Equal(path, result);
		}

		float Manhattan(Vertex<int> vertex, Vertex<int> goal)
		{
			return 0;
		}

		[Fact]

		public void AStarTest()
		{
			Graph<int> graph = new Graph<int>();
			Vertex<int>[] Vs = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }.Select(v => new Vertex<int>(v)).ToArray();
			int[] path = [0, 1, 4, 5, 8];

			foreach (var vertex in Vs)
			{
				graph.AddVertex(vertex);
			}

			graph.AddEdge(Vs[0], Vs[1], 1);
			graph.AddEdge(Vs[0], Vs[3], 1);
			graph.AddEdge(Vs[1], Vs[2], 1);
			graph.AddEdge(Vs[1], Vs[4], 1);
			graph.AddEdge(Vs[2], Vs[5], 1);
			graph.AddEdge(Vs[3], Vs[4], 1);
			graph.AddEdge(Vs[3], Vs[6], 1);
			graph.AddEdge(Vs[4], Vs[5], 1);
			graph.AddEdge(Vs[4], Vs[7], 1);
			graph.AddEdge(Vs[5], Vs[8], 1);
			graph.AddEdge(Vs[6], Vs[7], 1);
			graph.AddEdge(Vs[7], Vs[8], 1);

			(List<Dictionary<Vertex<int>, VertexState>> cool, List<int> bob) = graph.AStar(Vs[0], Vs[8], Manhattan);

			Assert.Equal(path, bob);
		}
	}
}
/*
graph.AddEdge(Vs[0], Vs[1], 0.37f);
graph.AddEdge(Vs[1], Vs[0], 0.82f);
graph.AddEdge(Vs[1], Vs[2], 0.54f);
graph.AddEdge(Vs[2], Vs[1], 0.29f);
graph.AddEdge(Vs[2], Vs[3], 0.61f);
graph.AddEdge(Vs[2], Vs[6], 0.45f);
graph.AddEdge(Vs[3], Vs[0], 0.73f);
graph.AddEdge(Vs[1], Vs[4], 0.18f);
graph.AddEdge(Vs[1], Vs[5], 0.92f);
graph.AddEdge(Vs[4], Vs[5], 0.35f);
graph.AddEdge(Vs[5], Vs[4], 0.67f);
graph.AddEdge(Vs[5], Vs[6], 0.48f);
graph.AddEdge(Vs[6], Vs[5], 0.83f);
graph.AddEdge(Vs[4], Vs[7], 0.22f);
graph.AddEdge(Vs[5], Vs[8], 0.59f);
graph.AddEdge(Vs[6], Vs[9], 0.14f);
graph.AddEdge(Vs[6], Vs[10], 0.76f);
graph.AddEdge(Vs[7], Vs[0], 0.31f);
graph.AddEdge(Vs[7], Vs[8], 0.88f);
graph.AddEdge(Vs[7], Vs[14], 0.43f);
graph.AddEdge(Vs[14], Vs[7], 0.57f);
graph.AddEdge(Vs[8], Vs[12], 0.69f);
graph.AddEdge(Vs[9], Vs[12], 0.25f);
graph.AddEdge(Vs[10], Vs[13], 0.91f);
graph.AddEdge(Vs[11], Vs[7], 0.38f);
graph.AddEdge(Vs[12], Vs[11], 0.52f);
graph.AddEdge(Vs[12], Vs[13], 0.17f);
graph.AddEdge(Vs[13], Vs[12], 0.64f);
graph.AddEdge(Vs[12], Vs[15], 0.79f);
graph.AddEdge(Vs[12], Vs[16], 0.33f);
graph.AddEdge(Vs[14], Vs[15], 0.46f);
graph.AddEdge(Vs[15], Vs[16], 0.85f);
graph.AddEdge(Vs[16], Vs[15], 0.21f);
graph.AddEdge(Vs[16], Vs[17], 0.94f);
graph.AddEdge(Vs[17], Vs[14], 0.58f);
*/