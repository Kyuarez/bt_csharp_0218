using SDL2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PlayerController : Component
    {
      
        public override void Update()
        {
            //Vector2 move = position;
            //if (true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_w) || true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_UP))
            //{
            //    spriteIndexY = 2;
            //    if (false == PredictCollision(new Vector2(position.x, position.y - 1)))
            //    {
            //        move = new Vector2(position.x, position.y - 1);
            //    }
            //}
            //else if (true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_s) || true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_DOWN))
            //{
            //    spriteIndexY = 3;
            //    if (false == PredictCollision(new Vector2(position.x, position.y + 1)))
            //    {
            //        move = new Vector2(position.x, position.y + 1);
            //    }
            //}
            //else if (true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_a) || true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_LEFT))
            //{
            //    spriteIndexY = 0;
            //    if (false == PredictCollision(new Vector2(position.x - 1, position.y)))
            //    {
            //        move = new Vector2(position.x - 1, position.y);
            //    }
            //}
            //else if (true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_d) || true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_RIGHT))
            //{
            //    spriteIndexY = 1;
            //    if (false == PredictCollision(new Vector2(position.x + 1, position.y)))
            //    {
            //        move = new Vector2(position.x + 1, position.y);
            //    }
            //}

            //position = move;
        }

        public void OnTrigger(Vector2 position)
        {
            for (int i = 0; i < Engine.Instance.scene.GetAllGameObjects.Count; i++)
            {
                GameObject obj = Engine.Instance.scene.GetAllGameObjects[i];

                if (obj.isTrigger == true && obj.transform.position == position)
                {
                    if(obj.GetType() == typeof(Monster))
                    {
                        Engine.Instance.IsRunning = false;
                    }
                    else if (obj.GetType() == typeof(Goal))
                    {
                        Engine.Instance.UpgradeNextStage();
                    }
                }
            }

        }

    }
}
