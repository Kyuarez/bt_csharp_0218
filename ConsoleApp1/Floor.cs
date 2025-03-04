using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Floor : GameObject
    {
        public Floor(Vector2 position, char shape)
        {
            this.name = GetType().Name;
            this.position = position;
            this.shape = shape;
            orderLayer = 1;

            color.r = 0;
            color.g = 0;
            color.b = 0;
            color.a = 255;
        }
    }
}
