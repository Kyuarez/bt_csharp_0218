using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        protected bool isRunning;
        protected int stageLevel;

        public bool IsRunning
        {
            get { return isRunning; }
            set 
            {
                isRunning = value;
            }
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
                        Wall wall = new Wall(new Vector2(x, y), map[y][x]);
                        scene.Instantiate(wall);
                    }
                    else if (map[y][x] == Define.SHAPE_FLOOR)
                    {
                        //Floor floor = new Floor(new Vector2(x, y), map[y][x]);
                        //Instantiate(floor);
                    }
                    else if (map[y][x] == Define.SHAPE_PLAYER)
                    {
                        Player player = new Player(new Vector2(x, y), map[y][x]);
                        scene.Instantiate(player);
                    }
                    else if (map[y][x] == Define.SHAPE_MONSTER)
                    {
                        Monster monster = new Monster(new Vector2(x, y), map[y][x]);
                        scene.Instantiate(monster);
                    }
                    else if (map[y][x] == Define.SHAPE_GOAL)
                    {
                        Goal goal = new Goal(new Vector2(x, y), map[y][x]);
                        scene.Instantiate(goal);
                    }

                    Floor floor = new Floor(new Vector2(x, y), Define.SHAPE_FLOOR);
                    scene.Instantiate(floor);
                }
            }
            
            scene.Sort();
        }

        //public void Load(int stageLevel)
        //{
        //    scene = new Scene(stageLevel);
        //    scene.Sort();
        //}

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
            Console.Clear();
            scene.Render();
        }


        public void Run()
        {
            isRunning = true;

            while (isRunning) 
            {
                FixedUpate();
                ProcessInput();
                Update();
                Render();
            }

            if (false == isRunning) 
            {
                OnApplicationQuit();
            }
        }

        private void OnApplicationQuit()
        {
            Console.Clear();
            Console.WriteLine("게임 오버");
            Console.WriteLine($"클리어한 횟수 : {stageLevel}");
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
