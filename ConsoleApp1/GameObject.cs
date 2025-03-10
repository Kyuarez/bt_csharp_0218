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
        private List<Component> components = new List<Component>();

        public string name;
        public Vector2 position;
        public char shape;
        public int orderLayer; //Rendering Order
        public bool isTrigger = false;
        public bool isCollide = false;

        //public SDL.SDL_Color color;
        protected int spriteSize = 30;
        protected bool isAnimation = false;
        protected SDL.SDL_Color colorKey;

        protected int spriteIndexX = 0;
        protected int spriteIndexY = 0;

        protected IntPtr mySurface;
        protected IntPtr myTexture;


        protected float animElapsedTime = 0.0f;

        public void AddComponent<T>(T component) where T : Component
        {
            components.Add(component);
        }

        public void RemoveComponent<T>(T componet) where T : Component
        {

        }

        public T GetComponent<T>(T component) where T : Component
        {
            //T result = components.Find(component);

            return default(T);
        }

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
            SDL.SDL_Rect Rect;
            Rect.x = position.x * 30;
            Rect.y = position.y * 30;
            Rect.w = 30;
            Rect.h = 30;

            //SDL.SDL_SetRenderDrawColor(Engine.Instance.myRenderer, color.r, color.g, color.b, color.a);
            //SDL.SDL_RenderFillRect(Engine.Instance.myRenderer, ref Rect);

            //@tk : 이거 null 해야하는데, c#은 제공안해줘서 임시 변수로 만듦. (원본 Rect)
            unsafe
            {
                //TODO : 이미지 정보 가져와서 할 일 있어서 c접근 코드
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);
                SDL.SDL_Rect sourceRect;

                if(isAnimation == true)
                {
                    //한 칸 사이즈
                    int sizeX = surface->w / 5;
                    int sizeY = surface->h / 5;
                    //해당 인덱스의 value
                    sourceRect.x = sizeX * spriteIndexX;
                    sourceRect.y = sizeY * spriteIndexY;
                    sourceRect.w = surface->w / 5;
                    sourceRect.h = surface->h / 5;
                    
                    animElapsedTime += (float)Time.DeltaTime;
                    if (animElapsedTime >= 100f)
                    {
                        spriteIndexX++;
                        animElapsedTime = 0f;
                    }
                    
                    spriteIndexX %= 5;
                    //spriteIndexY++;
                    //spriteIndexY %= 5;
                }
                else
                {
                    sourceRect.x = 0;
                    sourceRect.y = 0;
                    sourceRect.w = surface->w;
                    sourceRect.h = surface->h;
                }
                
                SDL.SDL_RenderCopy(Engine.Instance.myRenderer, myTexture, ref sourceRect, ref Rect);
            }
        }

        protected void LoadBMP(string filename)
        {
            SetColorKey();

            //SDL C 접근할 수 있는게 없어서 unsafe 처리
            mySurface = SDL.SDL_LoadBMP(filename);
            unsafe
            {
                //누끼 따기 (칼리키 설정)
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);
                SDL.SDL_SetColorKey(mySurface, 1, SDL.SDL_MapRGB(surface->format, colorKey.r, colorKey.g, colorKey.b));
            }

            //RAM(surface) > VRAM(texture)
            myTexture = SDL.SDL_CreateTextureFromSurface(Engine.Instance.myRenderer, mySurface);
        }

        protected void SetColorKey()
        {
            if(isAnimation == true)
            {
                colorKey.r = 255;
                colorKey.g = 0;
                colorKey.b = 255;
                colorKey.a = 255;
            }
            else
            {
                colorKey.r = 255;
                colorKey.g = 255;
                colorKey.b = 255;
                colorKey.a = 255;
            }
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
