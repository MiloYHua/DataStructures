using System.ComponentModel;
using UnweightedAndUndirectedGraph;

namespace UWUDGraphTest
{
    public class UWUDTests
    {
        [Theory]
        [InlineData(123481923, 43182934, 5123534, 342543762)]
        [InlineData(7356823457, 73247254, 795325764, 2457256)]
        [InlineData(246982569, 35793245, 3856833, 359735427)]
        public void AddAndSearchTest(params int[] seeds)
        {
            for (int i = 0; i < seeds.Length; i++)
            {
                Random rand = new Random(seeds[i]);
                UWUDGraph<int> graph = new UWUDGraph<int>();
                for (int j = 0; j < 10; j++)
                {
                    int value = rand.Next();
                    Vertex<int> vertex = new Vertex<int>(value);
                    Assert.True(graph.AddVertex(vertex));
                    Assert.False(graph.AddVertex(vertex));
                    Assert.Equal(vertex, graph.Search(value));
                }
            }
        }

        [Theory]
        [InlineData(123481923, 43182934, 5123534, 342543762)]
        [InlineData(7356823457, 73247254, 795325764, 2457256)]
        [InlineData(246982569, 35793245, 3856833, 359735427)]
        public void RemoveTest(params int[] seeds)
        {
            for (int i = 0; i < seeds.Length; i++)
            {
                Random rand = new Random(seeds[i]);
                UWUDGraph<int> graph = new UWUDGraph<int>();
                for (int j = 0; j < 10; j++)
                {
                    Vertex<int> vertex = new Vertex<int>(rand.Next());
                    graph.AddVertex(vertex);
                    Assert.True(graph.RemoveVertex(vertex));
                }
            }
        }

        [Theory]
        [InlineData(123481923, 43182934, 5123534, 342543762)]
        [InlineData(7356823457, 73247254, 795325764, 2457256)]
        [InlineData(246982569, 35793245, 3856833, 359735427)]
        public void AddEdgeTest(params int[] seeds)
        {
            for (int i = 0; i < seeds.Length; i++)
            {
                Random rand = new Random(seeds[i]);
                UWUDGraph<int> graph = new UWUDGraph<int>();
                for (int j = 0; j < 10; j++)
                {
                    Vertex<int> vertex1 = new Vertex<int>(rand.Next());
                    Vertex<int> vertex2 = new Vertex<int>(rand.Next());

                    Assert.True(graph.AddEdge(vertex1, vertex2));
                    Assert.False(graph.AddEdge(vertex1, vertex2));

                    Assert.Contains(vertex2, vertex1.Neighbors);
                    Assert.Contains(vertex1, vertex2.Neighbors);
                }
            }
        }

        [Theory]
        [InlineData(123481923, 43182934, 5123534, 342543762)]
        [InlineData(7356823457, 73247254, 795325764, 2457256)]
        [InlineData(246982569, 35793245, 3856833, 359735427)]
        public void RemoveEdgeTest(params int[] seeds)
        {
            for (int i = 0; i < seeds.Length; i++)
            {
                Random rand = new Random(seeds[i]);
                UWUDGraph<int> graph = new UWUDGraph<int>();
                for (int j = 0; j < 10; j++)
                {
                    Vertex<int> vertex1 = new Vertex<int>(rand.Next());
                    Vertex<int> vertex2 = new Vertex<int>(rand.Next());

                    graph.AddVertex(vertex1);
                    graph.AddVertex(vertex2);

                    graph.AddEdge(vertex1, vertex2);

                    Assert.True(graph.RemoveEdge(vertex1, vertex2));
                    Assert.False(graph.RemoveEdge(vertex1, vertex2));

                    Assert.DoesNotContain(vertex2, vertex1.Neighbors);
                    Assert.DoesNotContain(vertex1, vertex2.Neighbors);
                }
            }
        }

        [Fact]
        public void DFTTest()
        {
            UWUDGraph<int> graph = new UWUDGraph<int>();

            Vertex<int> vertex1 = new Vertex<int>(5);
            Vertex<int> vertex2 = new Vertex<int>(2);
            Vertex<int> vertex3 = new Vertex<int>(7);
            Vertex<int> vertex4 = new Vertex<int>(8);
            Vertex<int> vertex5 = new Vertex<int>(3);
            Vertex<int> vertex6 = new Vertex<int>(6);

            List<int> ints = [5, 2, 3, 7, 6, 8];

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);
            graph.AddVertex(vertex4);
            graph.AddVertex(vertex5);
            graph.AddVertex(vertex6);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex1, vertex3);
            graph.AddEdge(vertex1, vertex4);
            graph.AddEdge(vertex2, vertex5);
            graph.AddEdge(vertex3, vertex6);

            Assert.Equal(ints, graph.DepthFirstTraversal());
        }
    }
}
