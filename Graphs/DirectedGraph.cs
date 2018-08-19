using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class DirectedGraph<T> where T : IComparable<T>
    {
        List<Vertex<T>> vertices;
        List<Edge<T>> edges;
        public List<Vertex<T>> dft;
        public List<Vertex<T>> bft;
        public List<Vertex<T>> dijkstra;
        public double Dft;
        public double Bft;
        public DirectedGraph()
        {
            vertices = new List<Vertex<T>>();
            edges = new List<Edge<T>>();
            dft = new List<Vertex<T>>();
            bft = new List<Vertex<T>>();
            dijkstra = new List<Vertex<T>>();
            Bft = 0;
        }

        public bool AddVertex(Vertex<T> vertex)
        {
            if (!vertices.Contains(vertex))
            {
                vertices.Add(vertex);
                return true;
            }

            return false;
        }

        public bool RemoveVertex(Vertex<T> vertex)
        {
            if (!vertices.Contains(vertex))
            {
                return false;
            }

            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].Start.Equals(vertex) || edges[i].End.Equals(vertex))
                {
                    edges[i].Start.EdgeList.Remove(edges[i]);
                    edges.Remove(edges[i]);
                    i--;
                }
            }

            vertices.Remove(vertex);
            return true;

        }

        public bool AddEdge(Vertex<T> start, Vertex<T> end, double weight)
        {
            Edge<T> edge = GetEdge(start, end);

            if (edge != null)
            {
                return false;
            }

            edge = new Edge<T>(start, end, weight);

            start.AddEdge(edge);
            edges.Add(edge);
            return true;
        }

        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            Edge<T> edgeToRemove = GetEdge(a, b);
            if (edgeToRemove == null)
            {
                return false;
            }

            edges.Remove(edgeToRemove);
            a.EdgeList.Remove(edgeToRemove);
            return true;
        }

        public void DepthFirstTraversal(Vertex<T> start)
        {
            start.Visited = true;
            dft.Add(start);
            for (int i = 0; i < start.EdgeList.Count; i++)
            {
                if (start.EdgeList[i].End.Visited == false)
                {
                    Dft += start.EdgeList[i].Weight;
                    start.EdgeList[i].End.Visited = true;
                    DepthFirstTraversal(start.EdgeList[i].End);
                }
            }

        }

        public void BreadthFirstTraversal(Vertex<T> start)
        {
            for (int i = 0; i < vertices.Count; i++) { vertices[i].Visited = false; };
            bft.Clear();
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            start.Visited = true;
            bft.Add(start);
            queue.Enqueue(start);

            while (queue.Count != 0)
            {
                var temp = queue.Peek().EdgeList;
                bft.Add(queue.Peek());
                Console.WriteLine($"{queue.Peek().Value}");
                queue.Dequeue();

                for (int i = 0; i < temp.Count; i++)
                {
                    if (!temp[i].End.Visited)
                    {
                        queue.Enqueue(temp[i].End);
                        temp[i].End.Visited = true;
                    }
                }
            }

            for (int i = 0; i < vertices.Count; i++) { vertices[i].Visited = false; };

        }

        public void Dijkstra(Vertex<T> start)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i].Visited = false;
                vertices[i].Distance = double.PositiveInfinity;
                vertices[i].Founder = null;
            }
            dijkstra.Clear();
            PriorityQueue<Vertex<T>> queue = new PriorityQueue<Vertex<T>>(10);
            start.Distance = 0;
            queue.Enqueue(start);
            start.Visited = true;

            while(!queue.IsEmpty())
            {
                Vertex<T> current = queue.Dequeue();
                for (int i = 0; i < current.EdgeList.Count; i++)
                {
                    queue.Enqueue(current.EdgeList[i].End);
                    double tempDistance = current.Distance + current.EdgeList[i].Weight;
                    if (tempDistance < current.EdgeList[i].End.Distance)
                    {
                        current.EdgeList[i].End.Distance = tempDistance;
                        current.EdgeList[i].End.Founder = current;
                    }
                }
                dijkstra.Add(current);
                current.Visited = true;

            }


        }

        public Edge<T> GetEdge(Vertex<T> start, Vertex<T> end)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].Start.Equals(start) && edges[i].End.Equals(end))
                {
                    return edges[i];
                }
            }
            return null;
        }

    }
}
