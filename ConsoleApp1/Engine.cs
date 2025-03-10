using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Engine
    {
        #region Singleton
        private Engine() { }

        private static Engine _instance;

        public static Engine Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Engine();
                }
                return _instance;
            }
        }
        #endregion

        //더블 버퍼링
        static public char[,] backBuffer = new char[20, 40];
        static public char[,] frontBuffer = new char[20, 40];

        protected bool isRunning;
        protected int stageLevel;

        protected CoroutineManager coManager;

        public bool IsRunning
        {
            get { return isRunning; }
            set 
            {
                isRunning = value;
            }
        }

        public IntPtr myWindow;
        public IntPtr myRenderer;
        public SDL.SDL_Event myEvent;

        public bool Init()
        {
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)
            {
                Console.WriteLine("INIT FAIL");
                return false;
            }

            //Window 
            myWindow = SDL.SDL_CreateWindow(
                "Game",
                100, 100,
                640, 480,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN
                );

            //GUI (붓)
            myRenderer = SDL.SDL_CreateRenderer(myWindow, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
                SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC |
                SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE);

            return true;
        }

        public bool Quit()
        {
            SDL.SDL_DestroyRenderer(myRenderer);
            SDL.SDL_DestroyWindow(myWindow);
            SDL.SDL_Quit();
            return true;
        }

        public void Load(string fileName)
        {
            List<string> map = new List<string>();
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(Define.FILEPATH_MAP + fileName);
                while (!sr.EndOfStream)
                {
                    map.Add(sr.ReadLine());
                }

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"{ex.FileName}::{ex.Source} is error that {ex.Message}");
            }
            catch (Exception e)
            {
                //파일 처리 외의 예외 처리
            }
            finally 
            {
                sr.Close();
            }
                
            scene = new Scene();

            for (int y = 0; y < map.Count; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    if (map[y][x] == Define.SHAPE_WALL)
                    {
                        GameObject wall = new GameObject();
                        wall.Name = "wall";
                        wall.transform.position = new Vector2(x, y);
                        SpriteRenderer spr = wall.AddComponent(new SpriteRenderer());
                        spr.LoadBMP("wall.bmp");
                        spr.orderLayer = 1;
                        scene.Instantiate(wall);
                    }
                    else if (map[y][x] == Define.SHAPE_FLOOR)
                    {
                        //Floor floor = new Floor(new Vector2(x, y), map[y][x]);
                        //Instantiate(floor);
                    }
                    else if (map[y][x] == Define.SHAPE_PLAYER)
                    {
                        GameObject player = new GameObject();
                        player.Name = "player";
                        player.transform.position = new Vector2(x, y);

                        player.AddComponent(new PlayerController());

                        SpriteRenderer spr = player.AddComponent(new SpriteRenderer());
                        spr.LoadBMP("player.bmp", true);
                        spr.orderLayer = 5;
                        scene.Instantiate(player);
                    }
                    else if (map[y][x] == Define.SHAPE_MONSTER)
                    {
                        GameObject monster = new GameObject();
                        monster.Name = "monster";
                        monster.transform.position = new Vector2(x, y);

                        monster.AddComponent(new Monster());

                        SpriteRenderer spr = monster.AddComponent(new SpriteRenderer());
                        spr.LoadBMP("monster.bmp");
                        spr.orderLayer = 4;
                        scene.Instantiate(monster);
                    }
                    else if (map[y][x] == Define.SHAPE_GOAL)
                    {
                        GameObject goal = new GameObject();
                        goal.Name = "goal";
                        goal.transform.position = new Vector2(x, y);
                        SpriteRenderer spr = goal.AddComponent(new SpriteRenderer());
                        spr.LoadBMP("goal.bmp");
                        spr.orderLayer = 3;
                        scene.Instantiate(goal);
                    }

                    GameObject floor = new GameObject();
                    floor.Name = "floor";
                    floor.transform.position = new Vector2(x, y);
                    SpriteRenderer spriteRenderer = floor.AddComponent(new SpriteRenderer());
                    spriteRenderer.LoadBMP("floor.bmp");
                    spriteRenderer.orderLayer = 0;
                    scene.Instantiate(floor);
                }
            }
            
            scene.Sort();
            //@tk : 인스턴스 생성한 순간 호출
            scene.Awake();
        }

        public void ProcessInput()
        {
            Input.Process();
        }

        public void FixedUpate()
        {
            scene.FixedUpdate();
        }

        public void Update()
        {
            scene.Update();
        }
        
        public void Render()
        {
            SDL.SDL_SetRenderDrawColor(myRenderer, 0, 0, 0, 0);
            SDL.SDL_RenderClear(myRenderer);
            scene.Render();

            for (int y = 0; y < backBuffer.GetLength(0); y++)
            {
                for (int x = 0; x < backBuffer.GetLength(1); x++)
                {
                    //back <-> front (flip)
                    if (frontBuffer[y, x] != null && frontBuffer[y, x].Equals(backBuffer[y, x]))
                    {
                        continue;
                    }

                    Console.SetCursorPosition(x, y);
                    Console.Write(backBuffer[y, x]);
                    frontBuffer[y, x] = backBuffer[y, x];
                }
            }
            SDL.SDL_RenderPresent(myRenderer);
        }


        public void Run()
        {
            isRunning = true;
            Console.CursorVisible = false;

            //double fps = 1.0 / Time.DeltaTime.TotalMilliseconds;
            float frameTime = 1000.0f / 60.0f;
            float elapsedTime = 0.0f;

            while (isRunning)
            {
                //Event 처리
                SDL.SDL_PollEvent(out myEvent);
                Time.Update();
                switch (myEvent.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        isRunning = false;
                        break;
                    default:
                        break;
                }

                Update();

                Render();
            }
        }

        public void UpgradeNextStage()
        {
            stageLevel++;
            //@tk
            Load("level01.map");
        }

        public Scene scene;
    }
}
