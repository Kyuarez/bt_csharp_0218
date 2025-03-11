using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class GameManager : Component
    {
        protected static GameManager _instance;
        public static GameManager Instance
        {
            get 
            { 
                return _instance; 
            }
        }

        public bool isGameOver = false;

        public bool isFinish = false;

        public override void Awake()
        {
            base.Awake();
            _instance = this;
        }

        public override void Update()
        {
            if(isGameOver == true)
            {
                if(GameObject.Find("UI_Fail") == null)
                {
                    Console.WriteLine("으앙 죽음 ㅠㅠ");
                    GameObject failObj = new GameObject();
                    failObj.Name = "UI_Fail";
                    TextRenderer textRenderer = failObj.AddComponent(new TextRenderer());
                    textRenderer.SetText("으앙 죽음ㅠㅠ");
                    textRenderer.color.r = 255;
                    textRenderer.color.g = 0;
                    textRenderer.color.b = 0;
                    textRenderer.transform.position = new Vector2(100, 100);
                    Engine.Instance.scene.Instantiate(failObj);
                }
            }

            if (isFinish == true) 
            {
                if (GameObject.Find("UI_Succeed") == null)
                {
                    Console.WriteLine("목적지 도착!");
                    GameObject succeedObj = new GameObject();
                    succeedObj.Name = "UI_Succeed";
                    TextRenderer textRenderer = succeedObj.AddComponent(new TextRenderer());
                    textRenderer.SetText("목적지 도착!");
                    textRenderer.color.r = 255;
                    textRenderer.color.g = 0;
                    textRenderer.color.b = 255;
                    textRenderer.transform.position = new Vector2(100, 100);
                    Engine.Instance.scene.Instantiate(succeedObj);
                }
            }
        }
    }
}
