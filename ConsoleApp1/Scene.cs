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
        public static GameObject[] gameObjects;
        
        private int useGameObjectCount = 0;
        
        private int turnCount = 0; // 남은 턴?

        public Scene(int stageLevel)
        {
            int mapSizeX = Define.MAPSIZE_X_DEFAULT + stageLevel;
            int mapSizeY = Define.MAPSIZE_Y_DEFAULT + stageLevel;
            gameObjects = new GameObject[mapSizeX * mapSizeY];
            useGameObjectCount = 0;
            turnCount = 0;

            string[] map = CreateTextMap(mapSizeX, mapSizeY);
            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    if (map[y][x] == Define.SHAPE_WALL)
                    {
                        Wall wall = new Wall(new Vector2(x, y), map[y][x]);
                        Instantiate(wall);
                    }
                    else if (map[y][x] == Define.SHAPE_FLOOR)
                    {
                        Floor floor = new Floor(new Vector2(x, y), map[y][x]);
                        Instantiate(floor);
                    }
                    else if (map[y][x] == Define.SHAPE_PLAYER)
                    {
                        Player player = new Player(new Vector2(x, y), map[y][x]);
                        Instantiate(player);
                    }
                    else if (map[y][x] == Define.SHAPE_MONSTER)
                    {
                        Monster monster = new Monster(new Vector2(x, y), map[y][x]);
                        Instantiate(monster);
                    }
                    else if (map[y][x] == Define.SHAPE_GOAL)
                    {
                        Goal goal = new Goal(new Vector2(x, y), map[y][x]);
                        Instantiate(goal);
                    }
                }
            }

        }

        private string[] CreateTextMap(int x, int y)
        {
            string[] textMap = new string[y];
            for (int i = 0; i < textMap.Length; i++)
            {
                string oneLine = string.Empty;
                if (i == 0 || i == (textMap.Length - 1))
                {
                    oneLine = new string(Define.SHAPE_WALL, x);
                    textMap[i] = oneLine;
                }
                else
                {
                    //일단 고정값. (나중에 랜덤값)
                    //뭔가 Procedural 적인 맵 만들고 싶다.. ㅠㅠ
                    if (i == 1)
                    {
                        oneLine = Define.SHAPE_WALL + new string(Define.SHAPE_PLAYER, 1) + new string(Define.SHAPE_FLOOR, x - 3) + Define.SHAPE_WALL;
                    }
                    else if (i == textMap.Length - 3)
                    {
                        oneLine = Define.SHAPE_WALL + new string(Define.SHAPE_FLOOR, x - 3) + Define.SHAPE_MONSTER + Define.SHAPE_WALL;
                    }
                    else if (i == textMap.Length - 2)
                    {
                        oneLine = Define.SHAPE_WALL + new string(Define.SHAPE_FLOOR, x - 3) + Define.SHAPE_GOAL + Define.SHAPE_WALL;
                    }
                    else
                    {
                        oneLine = Define.SHAPE_WALL + new string(Define.SHAPE_FLOOR, x - 2) + Define.SHAPE_WALL;
                    }
                    textMap[i] = oneLine;
                }
            }
            return textMap;
        }

        private void Instantiate(GameObject gameObject)
        {
            gameObjects[useGameObjectCount] = gameObject;
            useGameObjectCount++;
        }

        //충돌 체크
        public void FixedUpdate()
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].FixedUpdate();
            }
        }

        public void Update()
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].Update();
            }
        }

        public void Render()
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].Render();
            }

            turnCount--;
        }

        public void CheckLimitTurn()
        {
            
        }

        public static GameObject GetGameObjectByVector(Vector2 position)
        {
            GameObject obj = null;

            for (int i = 0; i < gameObjects.Length; i++)
            {
                if(gameObjects[i].position == position)
                {
                    obj = gameObjects[i];
                }
            }
            return obj;
        }
    }
}
