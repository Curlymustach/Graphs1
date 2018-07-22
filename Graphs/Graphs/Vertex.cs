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
        public List<Vertex<T>> AdjacentList;
        public int Neighbors;
        public bool Visited { get; set; }

        public Vertex(T value)
        {
            this.Value = value;
            AdjacentList = new List<Vertex<T>>();
        }

        public void addNeighbors(Vertex<T> v)
        {
            AdjacentList.Add(v);
            Neighbors++;
        }

        public void removeNeighbors(Vertex<T> v)
        {
            AdjacentList.Remove(v);
            Neighbors--;
        }
    }
}
