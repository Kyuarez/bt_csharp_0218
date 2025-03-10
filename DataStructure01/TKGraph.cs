using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureTK
{
    /// <summary>
    /// 인접 리스트 형식 그래프
    /// </summary>
    public class TKGraph
    {
        public int vertexCount;
        public List<int>[] adjacents;

        public TKGraph(int vertexCount)
        {
            this.vertexCount = vertexCount;
            adjacents = new List<int>[vertexCount];
        }

        public void AddEdge(int from, int to)
        {
            if(from < 0 || from >= vertexCount || to < 0 || to >= vertexCount)
            {
                throw new ArgumentOutOfRangeException();
            }

            adjacents[from].Add(to);
            adjacents[to].Add(from);
        }

        public void DFS(int start)
        {
            bool[] visited = new bool[vertexCount];
            DFSRecursive(start, visited);
        }

        private void DFSRecursive(int vertex, bool[] visited)
        {
            visited[vertex] = true;
            //Debug
            Console.WriteLine($"{vertex.ToString()} vertex is visited!");

            foreach (int adjacent in adjacents[vertex])
            {
                if(false == visited[adjacent])
                {
                    DFSRecursive(adjacent, visited);
                }
            }
        }

        public void DFSByStack(int start)
        {
            bool[] visited = new bool[vertexCount];
            Stack<int> stack = new Stack<int>();

            stack.Push(start);

            while(stack.Count > 0)
            {
                int vertex = stack.Pop();

                if(false == visited[vertex])
                {
                    visited[vertex] = true;

                    foreach (int adjacent in adjacents[vertex].OrderByDescending(n => n))
                    {
                        if (false == visited[adjacent])
                        {
                            stack.Push(adjacent);
                        }
                    }
                }
            }
        }

        public void BFS(int start)
        {
            bool[] visited = new bool[vertexCount];
            Queue<int> queue = new Queue<int>();

            visited[start] = true;
            queue.Enqueue(start);

            while (queue.Count > 0) 
            {
                int vertex = queue.Dequeue();

                foreach (int adjacent in adjacents[vertex])
                {
                    if(false == visited[adjacent])
                    {
                        visited[adjacent] = true;
                        queue.Enqueue(adjacent);
                    }
                }
            }
        }
    }

    /// <summary>
    /// 인접 행렬 형식 그래프
    /// </summary>
    public class TKGraphMatrix
    {
        public int vertexCount;
        public int[,] adjacents;

        public TKGraphMatrix(int vertexCount)
        {
            this.vertexCount = vertexCount;
            adjacents = new int[vertexCount, vertexCount];
        }

        public void AddEdge(int from, int to)
        {
            if (from < 0 || from >= vertexCount || to < 0 || to >= vertexCount)
            {
                throw new ArgumentOutOfRangeException();
            }

            adjacents[from, to] = 1;
            adjacents[to, from] = 1;
        }
    }
}
