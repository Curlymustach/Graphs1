using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Vertex<T> 
    {
        public T Value;
        List<T> adjacentList;
        int neighbors;

        public Vertex(T value)
        {
            this.Value = value;
        }

        public void updateNeighbors(T value)
        {
            adjacentList.Add(value);
            neighbors++;
        }

        public void addEdge(Vertex<T> a, Vertex<T> b)
        {
            a.updateNeighbors(b.Value);
            b.updateNeighbors(a.Value);
        }
    }
}
