using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Edge<T>
    {
        Vertex<T> start;
        Vertex<T> end;
        double weight;

        public Edge(Vertex<T> start, Vertex<T> end, double weight)
        {
            this.start = start;
            this.end = end;
            this.weight = weight;
        }
    }
}
