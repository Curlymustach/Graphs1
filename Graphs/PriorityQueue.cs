using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class PriorityQueue<T> where T : IComparable<T>
    {
        T[] tree;
        int maxIndex = 0;

        public PriorityQueue(int size)
        {
            tree = new T[size];
        }

        public int Left(int i)
        {
            return i * 2 + 1;
        }

        public int Right(int i)
        {
            return i * 2 + 2;
        }

        public int Parent(int i)
        {
            return (i - 1) / 2;
        }

        public void Swap(int i, int j)
        {
            T temp = tree[i];
            tree[i] = tree[j];
            tree[j] = temp;
        }

        public void Enqueue(T vertex)
        {
            if (maxIndex == tree.Length)
            {
                Resize(tree.Length * 2);
            }
            else
            {
                tree[maxIndex] = vertex;
                HeapifyUp(maxIndex);
                maxIndex++;
            }
        }

        public void HeapifyUp(int i)
        {
            if (i == 0 || tree[i].CompareTo(tree[Parent(i)]) > 0)
            {
                return;
            }

            Swap(i, Parent(i));
            HeapifyUp(Parent(i));
        }

        public T Dequeue()
        {
            T temp = tree[0];
            tree[0] = tree[maxIndex - 1];
            maxIndex--;
            HeapifyDown(0);
            Resize(maxIndex);
            return temp;
        }

        public void HeapifyDown(int i)
        {
            int master = i;
            int left = Left(i);
            int right = Right(i);


            if (left <= maxIndex && tree[master].CompareTo(tree[left]) > 0)
            {
                master = left;
            }
            if (right <= maxIndex && tree[master].CompareTo(tree[right]) > 0)
            {
                master = right;
            }
            if (master == i)
            {
                return;
            }

            Swap(i, master);
            HeapifyDown(master);
        }

        public void Resize(int size)
        {
            T[] tempHeap = new T[size];
            for (int i = 0; i < maxIndex; i++)
            {
                tempHeap[i] = tree[i];
            }
            tree = tempHeap;
        }

        public bool IsEmpty()
        {
            if(tree == null)
            {
                return true;
            }
            return false;
        }
    }
}
