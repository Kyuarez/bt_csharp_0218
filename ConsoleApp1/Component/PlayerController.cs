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
        public CharacterController2D characterController;

        public override void Awake()
        {
            base.Awake();
            spr = gameObject.GetComponent<SpriteRenderer>();
            characterController = gameObject.GetComponent<CharacterController2D>();
        }

        public override void Update()
        {
            Vector2 move = gameObject.transform.position;
            if (true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_w) || true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_UP))
            {
                spr.SpriteIndexY = 2;
                characterController.Move(new Vector2(move.x, move.y - 1));
                
            }
            else if (true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_s) || true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_DOWN))
            {
                spr.SpriteIndexY = 3;
                characterController.Move(new Vector2(move.x, move.y + 1));
            }
            else if (true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_a) || true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_LEFT))
            {
                spr.SpriteIndexY = 0;
                characterController.Move(new Vector2(move.x - 1, move.y));
                
            }
            else if (true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_d) || true == Input.GetKeyDown(SDL.SDL_Keycode.SDLK_RIGHT))
            {
                spr.SpriteIndexY = 1;
                characterController.Move(new Vector2(move.x + 1, move.y));
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.Name == "monster")
            {
                GameManager.Instance.isGameOver = true;
            }
            if(other.gameObject.Name == "goal")
            {
                GameManager.Instance.isFinish = true;
            }
        }
    }
}
