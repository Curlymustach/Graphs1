﻿using System;
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
        public List<Edge<T>> EdgeList;
        public bool Visited { get; set; }
        public int InDegree { get; set; }
        public int OutDegree { get; set; }

        public Vertex(T value)
        {
            this.Value = value;
            AdjacentList = new List<Vertex<T>>();
            EdgeList = new List<Edge<T>>();
        }

        public void AddEdge(Edge<T> e)
        {
            EdgeList.Add(e);
        }

        public void AddNeighbors(Vertex<T> v)
        {
            AdjacentList.Add(v);
        }
        public void AddNeighbors(Vertex<T> v, Edge<T> e)
        {
            AdjacentList.Add(v);
            EdgeList.Add(e);
        }
        public void RemoveNeighbors(Vertex<T> v)
        {
            AdjacentList.Remove(v);
        }
    }
}
