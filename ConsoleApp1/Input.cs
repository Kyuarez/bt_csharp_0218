using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Input
    {
        protected static ConsoleKeyInfo keyInfo;

        public Input() { }

        public static void Process()
        {
            //Console 용
            //if (true == Console.KeyAvailable)
            //{
            //    keyInfo = Console.ReadKey(true);
            //}
        }

        public static void ClearInput()
        {
            keyInfo = new ConsoleKeyInfo();
        }

        public static bool GetKeyDown(ConsoleKey keycode)
        {
            return keyInfo.Key == keycode;
        }
        public static bool GetKey(SDL.SDL_Keycode key)
        {
            return Engine.Instance.myEvent.key.keysym.sym == key;
        }
        public static bool GetKeyDown(SDL.SDL_Keycode key)
        {
            if(Engine.Instance.myEvent.type == SDL.SDL_EventType.SDL_KEYDOWN)
            {
                return Engine.Instance.myEvent.key.keysym.sym == key;
            }

            return false;
        }
    }
}
