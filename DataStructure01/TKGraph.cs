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
