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
            this.position = position;
            this.shape = shape;
        }

        
    }
}
