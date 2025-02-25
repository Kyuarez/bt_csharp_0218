using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Player : GameObject
    {
        public Player(Vector2 position, char shape)
        {
            this.name = GetType().Name;
            this.position = position;
            this.shape = shape;
            orderLayer = 4;
            isTrigger = true;
        }
        public override void FixedUpdate()
        {
            OnTrigger(position);
        }
        public override void Update()
        {
            Vector2 move = position;
            if (true == Input.GetKeyDonw(ConsoleKey.UpArrow))
            {
                if(false == PredictCollision(new Vector2(position.x, position.y - 1)))
                {
                    move = new Vector2(position.x, position.y - 1);
                }
            }
            else if (true == Input.GetKeyDonw(ConsoleKey.DownArrow))
            {
                if (false == PredictCollision(new Vector2(position.x, position.y + 1)))
                {
                    move = new Vector2(position.x, position.y + 1);
                }
            }
            else if (true == Input.GetKeyDonw(ConsoleKey.LeftArrow))
            {
                if (false == PredictCollision(new Vector2(position.x - 1, position.y)))
                {
                    move = new Vector2(position.x - 1, position.y);
                }
            }
            else if (true == Input.GetKeyDonw(ConsoleKey.RightArrow))
            {
                if (false == PredictCollision(new Vector2(position.x + 1, position.y)))
                {
                    move = new Vector2(position.x + 1, position.y);
                }
            }

            position = move;
        }

        public override void OnTrigger(Vector2 position)
        {
            for (int i = 0; i < Engine.Instance.scene.GetAllGameObjects.Count; i++)
            {
                GameObject obj = Engine.Instance.scene.GetAllGameObjects[i];

                if (obj.isTrigger == true && obj.position == position)
                {
                    if(obj.GetType() == typeof(Monster))
                    {
                        //Engine.Instance.IsRunning = false;
                    }
                    else if (obj.GetType() == typeof(Goal))
                    {
                        Engine.Instance.UpgradeNextStage();
                    }
                }
            }

        }
    }
}
