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
        public SpriteRenderer spr;

        public override void Awake()
        {
            base.Awake();
            spr = gameObject.GetComponent<SpriteRenderer>();
        }

        public override void Update()
        {
            Vector2 move = gameObject.transform.position;
            if (true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_w) || true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_UP))
            {
                spr.SpriteIndexY = 2;
                move = new Vector2(move.x, move.y - 1);
                //if (false == PredictCollision(new Vector2(position.x, position.y - 1)))
                //{
                //}
            }
            else if (true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_s) || true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_DOWN))
            {
                spr.SpriteIndexY = 3;
                move = new Vector2(move.x, move.y + 1);
            }
            else if (true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_a) || true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_LEFT))
            {
                spr.SpriteIndexY = 0;
                move = new Vector2(move.x - 1, move.y);
            }
            else if (true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_d) || true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_RIGHT))
            {
                spr.SpriteIndexY = 1;
                move = new Vector2(move.x + 1, move.y);
            }

            gameObject.transform.position = move;
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
