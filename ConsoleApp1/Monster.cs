using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Monster : GameObject
    {
        private float elapsedTime = 0.0f;

        public Monster(Vector2 position, char shape)
        {
            this.name = GetType().Name;
            this.position = position;
            this.shape = shape;
            orderLayer = 5;
            isTrigger = true;

            color.r = 255;
            color.g = 0;
            color.b = 0;
            color.a = 255;
        }

        public override void FixedUpdate()
        {
            //CheckOnCollision();
        }

        public override void Update()
        {
            if(elapsedTime > 0.005f)
            {
                elapsedTime = 0.0f;
                Random random = new Random();
                int rndNum = random.Next(0, 4);
                Vector2 move = position;

                if (rndNum == 0)
                {
                    if (false == PredictCollision(new Vector2(position.x, position.y - 1)))
                    {
                        move = new Vector2(position.x, position.y - 1);
                    }
                }
                else if (rndNum == 1)
                {
                    if (false == PredictCollision(new Vector2(position.x, position.y + 1)))
                    {
                        move = new Vector2(position.x, position.y + 1);
                    }
                }
                else if (rndNum == 2)
                {
                    if (false == PredictCollision(new Vector2(position.x - 1, position.y)))
                    {
                        move = new Vector2(position.x - 1, position.y);
                    }
                }
                else if (rndNum == 3)
                {
                    if (false == PredictCollision(new Vector2(position.x + 1, position.y)))
                    {
                        move = new Vector2(position.x + 1, position.y);
                    }
                }

                position = move;
            }

            elapsedTime += Time.DeltaTime;
        }
    }
}
