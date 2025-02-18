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
        public Monster(Vector2 position, char shape)
        {
            this.position = position;
            this.shape = shape;
        }

        public override void FixedUpdate()
        {
            CheckOnCollision();
        }

        public override void Update()
        {
            Random random = new Random();
            int rndNum = random.Next(0, 4);
            Vector2 move = position;

            if (rndNum == 0)
            {
                move.y--;
            }
            else if (rndNum == 1)
            {
                move.y++;
            }
            else if (rndNum == 2)
            {
                move.x--;
            }
            else if (rndNum == 3)
            {
                move.y++;
            }


            if (OnCollisionByShape(move, Define.SHAPE_WALL) || OnCollisionByShape(move, Define.SHAPE_GOAL))
            {
                CheckOnCollision();
                return;
            }
            position = move;
            CheckOnCollision();
        }

        private void CheckOnCollision()
        {
            char collisionShape = OnCollision(position);
            switch (collisionShape)
            {
                case Define.SHAPE_PLAYER:
                    Engine.Instance.IsRunning = false;
                    break;
                default:
                    break;
            }
        }

    }
}
