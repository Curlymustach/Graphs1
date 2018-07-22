using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class UnderictedGraph<T>
    {
        List<Vertex<T>>[] adj;
        List<Vertex<T>> vertices;
        public List<Vertex<T>> dft;
        public List<Vertex<T>> bft;
        int count;
        public UnderictedGraph() : this(10) {}
        public UnderictedGraph(int size)
        {
            adj = new List<Vertex<T>>[size];
            dft = new List<Vertex<T>>();
            bft = new List<Vertex<T>>();
            vertices = new List<Vertex<T>>();
            for (int i = 0; i < adj.Length; i++)
            {
                adj[i] = new List<Vertex<T>>();
            }
            count = 0;
        }

        public void AddVertex(Vertex<T> vertex)
        {
            vertices.Add(vertex);
            adj[count] = vertex.AdjacentList;
            count++;
            if(count == adj.Length)
            {
                Update();
            }
        }

        public void RemoveVertex(Vertex<T> vertex)
        {

        }

        public void AddEdge(Vertex<T> a, Vertex<T> b)
        {
            a.addNeighbors(b);
            b.addNeighbors(a);
        }

        public void RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            a.removeNeighbors(b);
            b.removeNeighbors(a);
        }

        public void DepthFirstTraversal(Vertex<T> node)
        {
            node.Visited = true;
            dft.Add(node);
            for (int i = 0; i < node.Neighbors; i++)
            { 
                if (node.AdjacentList[i].Visited == false)
                {
                    DepthFirstTraversal(node.AdjacentList[i]);
                }
            }
        }

        public void BreadthFirstTraversal(Vertex<T> node)
        {
            for(int i = 0; i < vertices.Count; i++) { vertices[i].Visited = false; };
            LinkedList<Vertex<T>> queue = new LinkedList<Vertex<T>>();
            for(int i = 0; i < node.AdjacentList.Count; i++)
            {
                queue.AddLast(node.AdjacentList[i]);
            }
            while(queue.Count != 0)
            {
                queue.First.Value.Visited = true;
                for(int i = 0; i < queue.First.Value.AdjacentList.Count; i++)
                {
                    if(queue.First.Value.Visited == false)
                    {
                        queue.AddLast(queue.First.Value.AdjacentList[i]);
                    }
                }
                bft.Add(queue.First.Value);
                queue.RemoveFirst();

            }

        }

        public void Update()
        {
            List<Vertex<T>>[] temp = new List<Vertex<T>>[adj.Length * 2];
            for(int i = 0; i < adj.Length; i++)
            {
                temp[i] = adj[i];
            }
            adj = temp;
        }
    }
}
