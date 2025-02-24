using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp1
{

    // @tk:  World에서 Scene으로 대체
    public class Scene
    {
        //public static GameObject[] gameObjects;
        private List<GameObject> gameObjects = new List<GameObject> ();        

        public List<GameObject> GetAllGameObjects
        {
            get
            {
                return gameObjects;
            }
        }

        public void Instantiate(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public void Sort()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int j = i + 1; j < gameObjects.Count; j++)
                {
                    if (gameObjects[i].orderLayer - gameObjects[j].orderLayer > 0)
                    {
                        GameObject tempObj = gameObjects[i];
                        gameObjects[i] = gameObjects[j];
                        gameObjects[j] = tempObj;
                    }
                }
            }
        }

        //충돌 체크
        public void FixedUpdate()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].FixedUpdate();
            }
        }

        public void Update()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update();
            }
        }

        public void Render()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Render();
            }
        }
    }
}
