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
            this.position = position;
            this.shape = shape;
        }

        public override void Render()
        {
            
        }
    }
}
