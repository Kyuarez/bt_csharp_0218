using SDL2;

namespace SDL_Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Unity Engine init
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)
            {
                Console.WriteLine("INIT FAIL");
            }
            else
            {
                //Window 
                IntPtr myWindow = SDL.SDL_CreateWindow(
                    "Game",
                    100, 100,
                    640, 480,
                    SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN
                    );

                //GUI (붓)
                IntPtr myRenderer = SDL.SDL_CreateRenderer(myWindow, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
                    SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC |
                    SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE);

                //Event
                SDL.SDL_Event myEvent;

                byte i = 0;
                while (true)
                {
                    Random rnd = new Random();
                    //Event 처리
                    SDL.SDL_PollEvent(out myEvent);
                    if (myEvent.type == SDL.SDL_EventType.SDL_QUIT)
                    {
                        break;
                    }
                    i++;
                    if (i > 255)
                        i = 0;
                    //Render
                    SDL.SDL_SetRenderDrawColor(myRenderer, i, 0, 0, 0);
                    SDL.SDL_RenderClear(myRenderer);

                    //랜덤으로 100개 사각형 그리기
                    //for (int j = 0; j < 10; j++)
                    //{
                    //    byte r = (byte)rnd.Next(0, 256);
                    //    byte g = (byte)rnd.Next(0, 256);
                    //    byte b = (byte)rnd.Next(0, 256);
                    //    SDL.SDL_Rect rect = GetRectangleRect(myRenderer, rnd);
                    //    SDL.SDL_SetRenderDrawColor(myRenderer, i, r, g, b);
                    //    SDL.SDL_RenderDrawRect(myRenderer, ref rect);
                    //    SDL.SDL_RenderFillRect(myRenderer, ref rect);
                    //}

                    //랜덤으로 3개 원 그리기
                    for (int j = 0; j < 3; j++)
                    {
                        byte r = (byte)rnd.Next(0, 256);
                        byte g = (byte)rnd.Next(0, 256);
                        byte b = (byte)rnd.Next(0, 256);
                        SDL.SDL_SetRenderDrawColor(myRenderer, i, r, g, b);
                        DrawCircleLines(myRenderer, rnd.Next(200, 400), rnd.Next(200, 400), rnd.Next(100, 200));
                        //DrawCircleLinesByRadian(myRenderer, rnd.Next(200, 400), rnd.Next(200, 400), rnd.Next(100, 200));
                    }


                    SDL.SDL_RenderPresent(myRenderer);
                }

                SDL.SDL_DestroyWindow(myWindow);

                SDL.SDL_Quit();
            }
        }

        public static SDL.SDL_Rect GetRectangleRect(IntPtr renderer, Random rnd)
        {
            SDL.SDL_Rect rect = new SDL.SDL_Rect();
            rect.h = rnd.Next(1, 100);
            rect.w = rnd.Next(1, 100);
            rect.x = rnd.Next(0, 640);
            rect.y = rnd.Next(0, 480);
            return rect;
        }

        public static void DrawCirclePoints(IntPtr renderer, int centerX, int centerY, int radius)
        {
            int segments = 360;
            //중점을 기준으로 반지름 돌리면서, 각 점들 위치 구해서 점 찍기?
            for (int i = 0; i < segments; i += 1) 
            {
                //i가 각도일 것 같음.
                double radian = (double)i * (Math.PI / 180);

                int pointX = centerX + (int)(radius * Math.Cos(radian));
                int pointY = centerY + (int)(radius * Math.Sin(radian));
                SDL.SDL_RenderDrawPoint(renderer, pointX, pointY);
            }
            SDL.SDL_RenderPresent(renderer);
        }

        public static void DrawCircleLines(IntPtr renderer, int centerX, int centerY, int radius)
        {
            int segments = 360;

            for (int i = 0; i < segments; i++)
            {
                double radian = (double)i * (Math.PI / 180);
                double radianNext = ((double)i + 1) * (Math.PI / 180);
                int pointX = centerX + (int)(radius * Math.Cos(radian)); //Cos = 밑변 / 빗변(반지름)
                int pointY = centerY + (int)(radius * Math.Sin(radian)); //Sin = 밑변 / 높이(반지름)
                int pointNextX = centerX + (int)(radius * Math.Cos(radianNext));
                int pointNextY = centerY + (int)(radius * Math.Sin(radianNext));

                SDL.SDL_RenderDrawLine(renderer, pointX, pointY, pointNextX, pointNextY);
            }
            SDL.SDL_RenderPresent(renderer);
        }

        public static void DrawCircleLinesByRadian(IntPtr renderer, int centerX, int centerY, int radius)
        {
            double increment = 0.1;
            for (double radian = 0; radian < 2 * Math.PI; radian += increment)
            {
                int pointX = centerX + (int)(radius * Math.Cos(radian)); 
                int pointY = centerY + (int)(radius * Math.Sin(radian)); 
                int pointNextX = centerX + (int)(radius * Math.Cos(radian + increment));
                int pointNextY = centerY + (int)(radius * Math.Sin(radian + increment));

                SDL.SDL_RenderDrawLine(renderer, pointX, pointY, pointNextX, pointNextY);
            }
            SDL.SDL_RenderPresent(renderer);
        }
    }
}
