using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TextRenderer : Renderer
    {
        public string content;
        public IntPtr surface;
        public IntPtr texture;
        public SDL.SDL_Color color;
        public SDL.SDL_Rect destination;

        public void SetText(string inContent)
        {
            content = inContent;
            surface = SDL_ttf.TTF_RenderUNICODE_Solid(Engine.Instance.myFont, content, color);
            texture = SDL.SDL_CreateTextureFromSurface(Engine.Instance.myRenderer, surface);

            int w = 0;
            int h = 0;
            uint format = 0;
            int access = 0;
            SDL.SDL_QueryTexture(texture, out format, out access, out w, out h);
            destination.x = transform.position.x;
            destination.y = transform.position.y;
            destination.w = w;
            destination.h = h;
        }

        public override void Render()
        {
            SDL.SDL_RenderCopy(Engine.Instance.myRenderer, texture, 0, ref destination);
        }

        public override void Update()
        {
            
        }
    }
}
