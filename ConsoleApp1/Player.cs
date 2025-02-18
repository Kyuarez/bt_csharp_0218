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
            this.position = position;
            this.shape = shape;
        }
        public override void FixedUpdate()
        {
            CheckOnCollision();
        }
        public override void Update()
        {
            Vector2 move = position;
            if (true == Input.GetKeyDonw(ConsoleKey.UpArrow))
            {
                move = new Vector2(position.x, position.y - 1);
            }
            else if (true == Input.GetKeyDonw(ConsoleKey.DownArrow))
            {
                move = new Vector2(position.x, position.y + 1);
            }
            else if (true == Input.GetKeyDonw(ConsoleKey.LeftArrow))
            {
                move = new Vector2(position.x - 1, position.y);
            }
            else if (true == Input.GetKeyDonw(ConsoleKey.RightArrow))
            {
                move = new Vector2(position.x + 1, position.y);
            }

            if (OnCollisionByShape(move, Define.SHAPE_WALL))
            {

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
                case Define.SHAPE_MONSTER:
                    Engine.Instance.IsRunning = false;
                    break;
                case Define.SHAPE_GOAL:
                    Engine.Instance.UpgradeNextStage();
                    break;
                default:
                    break;
            }
        }
    }
}
