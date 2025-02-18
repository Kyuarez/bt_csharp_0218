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


        public void Load()
        {
            scene = new Scene(0);
        }

        public void Load(int stageLevel)
        {
            scene = new Scene(stageLevel);
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
            Load(stageLevel);
        }


        public Scene scene;
        
    }
}
