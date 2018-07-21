using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Graph<T>
    {
        public Graph()
        {

        }

        public void AddVertex(T value)
        {
            Vertex<T> vertex = new Vertex<T>(value);
        }

        public void RemoveVertex(Vertex<T> vertex)
        {

        }

        public void AddEdge(Vertex<T> a, Vertex<T> b)
        {
            
        }

        public void RemoveEdge(Vertex<T> a, Vertex<T> b)
        {

        }

        public void DepthFirstTraversal(Vertex<T> start)
        {


        }

        public void BreadthFirstTraversal(Vertex<T> start)
        {

        }
    }
}
