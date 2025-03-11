using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CharacterController2D : Collider2D
    {
        public void Move(Vector2 destination)
        {
            foreach (GameObject other in Engine.Instance.scene.GetAllGameObjects) 
            {
                if(other.GetComponent<Collider2D>() != null)
                {
                    if(other.transform.position.x == destination.x && other.transform.position.y == destination.y)
                    {
                        if(other.GetComponent<Collider2D>().isTrigger == true)
                        {
                            Object[] otherParam = { other.GetComponent<Collider2D>() };
                            gameObject.ExcuteMethod("OnTriggerEnter2D", otherParam);
                            Object[] param = { gameObject.GetComponent<Collider2D>() };
                            other.ExcuteMethod("OnTriggerEnter2D", param);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }

            transform.Translate(destination);
        }
    }
}
