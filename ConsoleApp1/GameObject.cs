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
        public int orderLayer; //Rendering Order
        public bool isTrigger = false;
        public bool isCollide = false;

        public virtual void FixedUpdate()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Render()
        {
            //x,y 위치에 shape 출력
            Console.SetCursorPosition(position.x, position.y);
            Console.Write(shape);
        }

        public bool PredictCollision(Vector2 position)
        {
            for (int i = 0; i < Engine.Instance.scene.GetAllGameObjects.Count; i++)
            {
                GameObject obj = Engine.Instance.scene.GetAllGameObjects[i];

                if (obj.isCollide == true && obj.position == position)
                {
                    return true;
                }
            }

            return false;
        }

        public virtual void OnTrigger(Vector2 position)
        {

        }
        
    }
}
