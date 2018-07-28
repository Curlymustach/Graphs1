using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class UnderictedGraph<T>
    {
        List<List<Vertex<T>>> adj;
        List<Vertex<T>> vertices;

        public List<Vertex<T>> dft;
        public List<Vertex<T>> bft;
        int count;
        public UnderictedGraph() : this(10) {}
        public UnderictedGraph(int size)
        {
            adj = new List<List<Vertex<T>>>();
            dft = new List<Vertex<T>>();
            bft = new List<Vertex<T>>();
            vertices = new List<Vertex<T>>();
            count = 0;
        }

        public void AddVertex(Vertex<T> vertex)
        {
            vertices.Add(vertex);
            adj.Add(vertex.AdjacentList);
            count++;
        }

        public void RemoveVertex(Vertex<T> vertex)
        {
            for(int i = 0; i < vertices.Count; i++)
            {
                for(int j = 0; j < vertices[i].AdjacentList.Count; j++)
                {
                    if(vertices[i].AdjacentList[j].Equals(vertex))
                    {
                        vertices[i].AdjacentList.RemoveAt(j);
                        j--;
                    }
                }
            }
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
            for (int i = 0; i < vertices.Count; i++) { vertices[i].Visited = false; };
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            node.Visited = true;
            bft.Add(node);
            for(int i = 0; i < node.AdjacentList.Count; i++)
            {
                node.AdjacentList[i].Visited = true;
                queue.Enqueue(node.AdjacentList[i]);
            }
            while (queue.Count != 0)
            {
                List<Vertex<T>> temp = new List<Vertex<T>>();
                temp = queue.Peek().AdjacentList;
                bft.Add(queue.Peek());
                queue.Dequeue();
                for(int i = 0; i < temp.Count; i++)
                {
                    if(!temp[i].Visited)
                    {
                        temp[i].Visited = true;
                        queue.Enqueue(temp[i]);
                    }
                }
            }
            for (int i = 0; i < vertices.Count; i++) { vertices[i].Visited = false; };
        }

    }
}
