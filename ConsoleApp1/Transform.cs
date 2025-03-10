using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Transform : Component
    {
        public Vector2 position;

        public override void Update()
        {
            
        }

        public void Translate(int addX, int addY)
        {
            position.x += addX;
            position.y += addY;
        }
        public void Translate(Vector2 pos)
        {
            position.x += pos.x;
            position.y += pos.y;
        }
    }
}
