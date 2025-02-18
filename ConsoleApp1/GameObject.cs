using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class GameObject
    {
        public string name;
        public Vector2 position;
        public char shape;

        public virtual void Update()
        {

        }

        public virtual void Render()
        {
            //x,y 위치에 shape 출력
            Console.SetCursorPosition(position.x, position.y);
            Console.Write(shape);
        }

        public char OnCollision(Vector2 position)
        {
            GameObject obj = Scene.GetGameObjectByVector(position);
            if (obj == null) 
            {
                return Define.SHAPE_FLOOR;
            }

            if(obj.shape == Define.SHAPE_FLOOR)
            {
                return Define.SHAPE_FLOOR;
            }
            return obj.shape;
        }

        //postion : mine, shape : subject that wanted to check 
        public bool OnCollisionByShape(Vector2 position, char shape)
        {
            GameObject obj = Scene.GetGameObjectByVector(position);
            if (obj == null)
            {
                return false;
            }

            if (obj.shape == shape)
            {
                return true;
            }
            return false;
        }
    }
}
