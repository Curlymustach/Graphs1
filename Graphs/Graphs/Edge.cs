using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Edge<T>
    {
        public Vertex<T> Start;
        public Vertex<T> End;
        public double Weight;
        public bool Visited { get; set; }

        public Edge(Vertex<T> start, Vertex<T> end, double weight)
        {
            Start = start;
            End = end;
            Weight = weight;
        }
    }
}
