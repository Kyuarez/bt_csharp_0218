using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class GameObject
    {
        private List<Component> components = new List<Component>();

        public string Name;
        static int gameObjectCount = 0;

        protected Transform _transform;

        public bool isTrigger = false;
        public bool isCollide = false;

        public Transform transform
        {
            get 
            {
                return _transform;
            }
        }

        public List<Component> AllComponents
        {
            get { return components; }
        }

        public GameObject() 
        {
            Initialize();
            gameObjectCount++;
            Name = $"GameObject({gameObjectCount})";
        }

        ~GameObject()
        {
            gameObjectCount--;
        }

        public void Initialize() 
        {
            _transform = AddComponent<Transform>(new Transform());
        }


        public T AddComponent<T>(T component) where T : Component
        {
            components.Add(component);
            component.SetGameObject(this);
            return component;
        }

        public void RemoveComponent<T>(T componet) where T : Component
        {

        }
        public T GetComponent<T>() where T : Component
        {
            foreach (var cp in components)
            {
                if (cp is T)
                {
                    return cp as T;
                }
            }

            return null;
        }

        public virtual void FixedUpdate()
        {

        }

        public virtual void Update()
        {

        }

        public bool PredictCollision(Vector2 position)
        {
            for (int i = 0; i < Engine.Instance.scene.GetAllGameObjects.Count; i++)
            {
                GameObject obj = Engine.Instance.scene.GetAllGameObjects[i];

                if (obj.isCollide == true && obj.transform.position == position)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
