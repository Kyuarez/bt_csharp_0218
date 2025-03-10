using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Maze
{
    public enum TileType
    {
        Floor,
        Wall,
    }

    public enum MazeType
    {
        BinaryTree,
        SideWinder,
    }

    public class Board
    {
        public int Size { get; private set; }
        public TileType[,] Maps { get; private set; }

        private const char CIRCLE = '\u25cf';
        
        //@tk : size x size square
        public void Initialize(int size, MazeType mazeType)
        {
            this.Size = size;
            Maps = new TileType[size, size];

            switch (mazeType)
            {
                case MazeType.BinaryTree:
                    GenerateByBinaryTree();
                    break;
                case MazeType.SideWinder:
                    GenerateBySideWinder();
                    break;
                default:
                    throw new ArgumentNullException(nameof(mazeType));
            }
        }

        private void GenerateByBinaryTree()
        {
            //일단 길을 다 막는다.

            //Random으로 길 오, 아래로 뚫기.

            //벽등 예외 처리.
        }

        private void GenerateBySideWinder()
        {

        }

        public void Render()
        {

        }
    }
}
