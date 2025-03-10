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
        private List<GameObject> renderObjList = new List<GameObject>();

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
            renderObjList = new List<GameObject>();
            for (int i = 0; i < gameObjects.Count; i++)
            {
                SpriteRenderer spr = gameObjects[i].GetComponent<SpriteRenderer>();

                if(spr == null)
                {
                    continue;
                }

                renderObjList.Add(gameObjects[i]);
            }


            for (int i = 0; i < renderObjList.Count; i++)
            {
                for (int j = i + 1; j < renderObjList.Count; j++)
                {
                    SpriteRenderer spr1 = renderObjList[i].GetComponent<SpriteRenderer>();
                    SpriteRenderer spr2 = renderObjList[j].GetComponent<SpriteRenderer>();
                    
                    if (spr1.orderLayer - spr2.orderLayer > 0)
                    {
                        GameObject tempObj = renderObjList[i];
                        renderObjList[i] = renderObjList[j];
                        renderObjList[j] = tempObj;
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
                foreach (var component in gameObjects[i].AllComponents)
                {
                    component.Update();
                }
            }
        }

        public void Render()
        {
            for (int i = 0; i < renderObjList.Count; i++)
            {
                SpriteRenderer spriteRenderer = renderObjList[i].GetComponent<SpriteRenderer>();
                spriteRenderer.Render();
            }
        }
    }
}
