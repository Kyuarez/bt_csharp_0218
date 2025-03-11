using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CharacterController2D : Collider2D
    {
        public bool Move(Vector2 destination)
        {
            foreach (var other in Engine.Instance.scene.GetAllGameObjects) 
            {
                if(other.GetComponent<Collider2D>() != null)
                {
                    if(other.transform.position.x == destination.x && other.transform.position.y == destination.y)
                    {
                        return false;
                    }
                }
            }
         
            return true;
        }
    }
}
