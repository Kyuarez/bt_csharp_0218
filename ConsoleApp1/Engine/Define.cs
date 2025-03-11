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

        public const string FILEPATH_MAP = "C:\\Users\\user\\Documents\\GitHub\\bt_csharp_0218\\ConsoleApp1\\";
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

    public class CustomException : Exception
    {
        public CustomException() : base("이거 내가 만든 예외")
        {

        }
    }

    public class WrongPasswordException : Exception
    {
        public WrongPasswordException() : base("비번 틀렸는데요.")
        {

        }
    }
}
