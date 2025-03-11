using DataStructureTK;
using System.Collections;

namespace DataStructure01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        public int Solution(List<int> numbers, int target)
        {
            return DFS(numbers, target, 0, 0);
        }

        private int DFS(List<int> numbers, int target, int start, int total)
        {

            if(total == target)
            {
                return 1;
            }
            else
            {
                return 0;
            }

            
            return 0;
        }
    }
}
