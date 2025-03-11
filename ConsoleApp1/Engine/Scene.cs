using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    // @tk:  World에서 Scene으로 대체
    public class Scene
    {
        //public static GameObject[] gameObjects;
        private List<GameObject> gameObjects = new List<GameObject>();  

        public delegate int SortCompare(GameObject first, GameObject second);
        public SortCompare sortCompare;

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
                    if (sortCompare(gameObjects[i], gameObjects[j]) > 0)
                    {
                        GameObject tempObj = gameObjects[i];
                        gameObjects[i] = gameObjects[j];
                        gameObjects[j] = tempObj;
                    }
                }
            }
        }

        public void Awake()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                foreach (var component in gameObjects[i].AllComponents)
                {
                    component.Awake();
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
                foreach (var component in gameObjects[i].AllComponents)
                {
                    component.Update();
                }
            }
        }

        public void Render()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                SpriteRenderer spriteRenderer = gameObjects[i].GetComponent<SpriteRenderer>();
                if (spriteRenderer == null)
                {
                    continue;
                }

                spriteRenderer.Render();
            }
        }
    }
}
