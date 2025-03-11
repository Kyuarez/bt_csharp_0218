using System;
using SDL2;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SpriteRenderer : Component
    {
        public char shape;
        public SDL.SDL_Color color;

        public int orderLayer; //Rendering Order
        protected int spriteSize = 30;
        protected bool isAnimation = false;
        protected SDL.SDL_Color colorKey;

        protected int spriteIndexX = 0;
        protected int spriteIndexY = 0;

        protected IntPtr mySurface;
        protected IntPtr myTexture;
        protected SDL.SDL_Rect sourceRect;
        protected SDL.SDL_Rect destinationRect;

        protected float animElapsedTime = 0.0f;
        protected string fileName;

        public float processTime = 100.0f;
        public int maxCellCountX = 5;
        public int maxCellCountY = 5;

        //@tk 추후 따로 빼야할 듯.
        public int SpriteIndexY
        {
            get { return spriteIndexY; }
            set
            {
                spriteIndexY = value;
            }
        }


        public SpriteRenderer()
        {

        }
        public SpriteRenderer(string fileName, bool isAnimation = false)
        {
            
        }

        public override void Update()
        {
            //Input to Buffer
            Engine.backBuffer[gameObject.transform.position.y, gameObject.transform.position.x] = shape;
            destinationRect.x = gameObject.transform.position.x * 30;
            destinationRect.y = gameObject.transform.position.y * 30;
            destinationRect.w = 30;
            destinationRect.h = 30;

            //@tk : 이거 null 해야하는데, c#은 제공안해줘서 임시 변수로 만듦. (원본 Rect)
            unsafe
            {
                //TODO : 이미지 정보 가져와서 할 일 있어서 c접근 코드
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);

                if (isAnimation == true)
                {
                    //한 칸 사이즈
                    int sizeX = surface->w / maxCellCountX;
                    int sizeY = surface->h / maxCellCountY;
                    //해당 인덱스의 value
                    sourceRect.x = sizeX * spriteIndexX;
                    sourceRect.y = sizeY * spriteIndexY;
                    sourceRect.w = surface->w / maxCellCountX;
                    sourceRect.h = surface->h / maxCellCountY;

                    animElapsedTime += (float)Time.DeltaTime;
                    if (animElapsedTime >= processTime)
                    {
                        spriteIndexX++;
                        animElapsedTime = 0f;
                    }

                    spriteIndexX %= maxCellCountX;
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
            } 
        }

        public virtual void Render()
        {
            unsafe
            {
                SDL.SDL_RenderCopy(Engine.Instance.myRenderer, myTexture, ref sourceRect, ref destinationRect); 
            }
        }

        public void LoadBMP(string filename, bool isAnimation = false)
        {
            string projectFolder = Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName;
            this.fileName = filename;
            this.isAnimation = isAnimation;

            SetColorKey();

            //SDL C 접근할 수 있는게 없어서 unsafe 처리
            mySurface = SDL.SDL_LoadBMP(projectFolder + "/data/" + filename);
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
            if (isAnimation == true)
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

    }
}
