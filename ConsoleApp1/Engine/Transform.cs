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

        /// <summary>
        /// x, y에 factor 값 더하기
        /// </summary>
        public void Translate(int addX, int addY)
        {
            position.x += addX;
            position.y += addY;
        }
        /// <summary>
        /// destination으로 바로 이동 (대입)
        /// </summary>
        public void Translate(Vector2 destination)
        {
            position = destination;
        }
    }
}
