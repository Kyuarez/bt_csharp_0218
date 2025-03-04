using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CoroutineManager
    {
        protected static List<Coroutine> coroutines = new List<Coroutine>();

        public CoroutineManager()
        {
            coroutines.Clear();
        }

        public static void StartCoroutine(IEnumerator co)
        {
            coroutines.Add(new Coroutine(co));
        }

        public void Update()
        {
            for (int i = coroutines.Count - 1; i >= 0; i--)
            {
                Coroutine co = coroutines[i];

                if(false == co.MoveNext())
                {
                    coroutines.RemoveAt(i);
                }
            }
        }
    }

    public class Coroutine
    {
        private IEnumerator co;
        private float waitTime = 0f;

        public Coroutine(IEnumerator co) 
        {
            this.co = co;
        }

        public bool MoveNext()
        {
            if (waitTime > 0f)
            {
                waitTime -= Time.DeltaTime;
                return true;
            }

            if (!co.MoveNext())
                return false;

            if (co.Current is WaitForSeconds wait)
            {
                waitTime = wait.seconds;
            }

            return true;
        }
    }
}
