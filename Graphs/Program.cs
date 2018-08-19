using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            UnderictedGraph<int> graph = new UnderictedGraph<int>();
            Vertex<int> a = new Vertex<int>(1);
            Vertex<int> b = new Vertex<int>(2);
            Vertex<int> c = new Vertex<int>(3);
            Vertex<int> d = new Vertex<int>(4);
            Vertex<int> e = new Vertex<int>(5);
            Vertex<int> f = new Vertex<int>(6);

            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddVertex(c);
            graph.AddVertex(d);
            graph.AddVertex(e);
            graph.AddVertex(f);
            graph.AddEdge(a, b);
            graph.AddEdge(a, c);
            graph.AddEdge(a, d);
            graph.AddEdge(b, e);
            graph.AddEdge(b, f);
            graph.AddEdge(c, e);
            graph.AddEdge(c, f);
            //graph.DepthFirstTraversal(a);

            //for(int i = 0; i < graph.dft.Count; i++)
            //{
            //    Console.Write(graph.dft[i].Value);
            //}
            
            //graph.BreadthFirstTraversal(a);
            //for (int i = 0; i < graph.bft.Count; i++)
            //{
            //    Console.Write($"{graph.bft[i].Value} ");
            //}
            //Console.WriteLine();
            //graph.RemoveVertex(c);

            //graph.BreadthFirstTraversal(a);
            //for (int i = 0; i < graph.bft.Count; i++)
            //{
            //    Console.WriteLine($"{graph.bft[i].Value} ");
            //}



            DirectedGraph<int> dgraph = new DirectedGraph<int>();
            Vertex<int> g = new Vertex<int>(1);
            Vertex<int> h = new Vertex<int>(2);
            Vertex<int> ii = new Vertex<int>(3);
            Vertex<int> j = new Vertex<int>(4);
            Vertex<int> k = new Vertex<int>(5);
            Vertex<int> l = new Vertex<int>(6);

            dgraph.AddVertex(g);
            dgraph.AddVertex(h);
            dgraph.AddVertex(ii);
            dgraph.AddVertex(j);
            dgraph.AddVertex(k);
            dgraph.AddVertex(l);
            dgraph.AddEdge(g, h, 5);
            dgraph.AddEdge(h, g, 6);
            dgraph.AddEdge(g, ii, 3);
            dgraph.AddEdge(g, j, 2);
            dgraph.AddEdge(h, k, 7);
            dgraph.AddEdge(h, l, 1);
            dgraph.AddEdge(ii, k, 2);
            dgraph.AddEdge(ii, l, 3);

            //dgraph.DepthFirstTraversal(h);
            //for (int i = 0; i < dgraph.dft.Count; i++)
            //{
            //    Console.Write($"{dgraph.dft[i].Value} ");
            //}
            //Console.WriteLine();
            //Console.WriteLine(dgraph.Dft + "\n");

            //dgraph.BreadthFirstTraversal(h);
            //for (int i = 0; i < dgraph.bft.Count; i++)
            //{
            //    Console.Write($"{dgraph.bft[i].Value} ");
            //}
            //Console.WriteLine();
            //Console.WriteLine(dgraph.Bft);

            dgraph.Dijkstra(h);
            Console.ReadKey();

        }
    }
}
