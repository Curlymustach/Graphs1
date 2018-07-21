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
        //List<Vertex<T>> dft;
        int count;
        public UnderictedGraph() : this(10) {}
        public UnderictedGraph(int size)
        {
            adj = new List<Vertex<T>>[size];
            //dft = new List<Vertex<T>>();
            for (int i = 0; i < adj.Length; i++)
            {
                adj[i] = new List<Vertex<T>>();
            }
            count = 0;
        }

        public void AddVertex(Vertex<T> vertex)
        {
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

        public void DepthFirstTraversal(Vertex<T> start)
        {
            DepthFirstTraversal(start, new List<Vertex<T>>());
        }

        public void DepthFirstTraversal(Vertex<T> start, List<Vertex<T>> dft)
        { 
            Vertex<T> temp = start;
            dft.Add(temp);
            int i;
            for(i = 0; i < temp.AdjacentList.Count; i++)
            {
                if (!dft.Contains(temp.AdjacentList[i]))
                {
                    break;
                }
            }

            DepthFirstTraversal(temp.AdjacentList[i]);

        }

        public void BreadthFirstTraversal(Vertex<T> start)
        {

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
