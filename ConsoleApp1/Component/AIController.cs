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
        private CharacterController2D characterController;

        public override void Awake()
        {
            base.Awake();
            characterController = GetComponent<CharacterController2D>();
        }

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
                    characterController.Move(new Vector2(move.x, move.y - 1));
                }
                else if (rndNum == 1)
                {
                    characterController.Move(new Vector2(move.x, move.y + 1));
                }
                else if (rndNum == 2)
                {
                    characterController.Move(new Vector2(move.x + 1, move.y));
                }
                else if (rndNum == 3)
                {
                    characterController.Move(new Vector2(move.x - 1, move.y));
                }
            }

            elapsedTime += Time.DeltaTime;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            Console.WriteLine($"{other.gameObject.Name} 이 오버랩 되었어요~!");
        }
    }
}
