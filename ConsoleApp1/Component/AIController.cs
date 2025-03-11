using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AIController : Component
    {
        private float elapsedTime = 0.0f;

        public override void Update()
        {
            if (elapsedTime > 100f)
            {
                elapsedTime = 0.0f;
                Random random = new Random();
                int rndNum = random.Next(0, 4);
                Vector2 move = gameObject.transform.position;

                if (rndNum == 0)
                {
                    move = new Vector2(move.x, move.y - 1);
                    //if (false == PredictCollision(new Vector2(move.x, move.y - 1)))
                    //{
                    //    move = new Vector2(move.x, move.y - 1);
                    //}
                }
                else if (rndNum == 1)
                {
                    move = new Vector2(move.x, move.y + 1);

                }
                else if (rndNum == 2)
                {
                    move = new Vector2(move.x - 1, move.y);

                }
                else if (rndNum == 3)
                {
                    move = new Vector2(move.x + 1, move.y);

                }

                gameObject.transform.position = move;
            }

            elapsedTime += Time.DeltaTime;
        }
    }
}
