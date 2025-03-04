using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Wall : GameObject
    {
        public Wall(Vector2 position, char shape)
        {
            this.name = GetType().Name;
            this.position = position;
            this.shape = shape;
            orderLayer = 2;
            isCollide = true;

            color.r = 255;
            color.g = 255;
            color.b = 255;
            color.a = 255;
        }

        
    }
}
