using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            _transform = new Transform();
            AddComponent<Transform>(_transform);
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

        public void ExcuteMethod(string methodName, Object[] param)
        {
            //Reflection
            foreach (var component in AllComponents)
            {
                Type type = component.GetType();
                MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (MethodInfo method in methods)
                {
                    if (method.Name.CompareTo(methodName) == 0)
                    {
                        method.Invoke(component, param);
                    }
                }
            }
        }

        public static GameObject Find(string gameObjectName)
        {
            foreach (var obj in Engine.Instance.scene.GetAllGameObjects)
            {
                if(obj.Name.CompareTo(gameObjectName) == 0)
                {
                    return obj;
                }
            }

            return null;
        }
    }
}
