using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Define
    {
        public const char SHAPE_WALL = '*';
        public const char SHAPE_FLOOR = ' ';
        public const char SHAPE_PLAYER = 'P';
        public const char SHAPE_MONSTER = 'M';
        public const char SHAPE_GOAL = 'G';
    }

    public struct Vector2
    {
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return v1.x == v2.x && v1.y == v2.y;
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return !(v1 == v2);
        }

        public int x;
        public int y;
    }
}
