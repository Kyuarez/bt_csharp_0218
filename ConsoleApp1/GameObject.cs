using SDL2;
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

        public SDL.SDL_Color color;

        public virtual void FixedUpdate()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Render()
        {
            //x,y 위치에 shape 출력
            //Console.SetCursorPosition(position.x, position.y);
            //Console.Write(shape);

            //Input to Buffer
            Engine.backBuffer[position.y, position.x] = shape;
            SDL.SDL_SetRenderDrawColor(Engine.Instance.myRenderer, color.r, color.g, color.b, color.a);
            SDL.SDL_Rect Rect;
            Rect.x = position.x * 30;
            Rect.y = position.y * 30;
            Rect.w = 30;
            Rect.h = 30;

            SDL.SDL_RenderFillRect(Engine.Instance.myRenderer, ref Rect);
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
