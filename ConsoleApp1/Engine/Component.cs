using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Component
    {
        //@tk : virtual은 메소드 배열을 가지게 되는 부담 크다. 
        //@tk : 차라리, Reflection으로 런타임 호출이 더 좋다.
        protected GameObject _gameObject;
        protected Transform _transform;

        public GameObject gameObject
        {
            get { return _gameObject; }
        }

        public Transform transform
        {
            get { return _transform; }
        }

        public void SetGameObject(GameObject gameObject)
        {
            _gameObject = gameObject;
            _transform = gameObject.transform;
        }

        public T GetComponent<T>() where T : Component
        {
            List<Component> components = gameObject.AllComponents;
            foreach (var cp in components)
            {
                if (cp is T)
                {
                    return cp as T;
                }
            }

            return null;
        }

        public virtual void Awake()
        {

        }



        public abstract void Update();

        public static void Destroy()
        {

        }
    }
}
