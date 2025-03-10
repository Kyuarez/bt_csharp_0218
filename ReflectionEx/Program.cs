using System.Reflection;

namespace ReflectionEx
{
    internal class Program
    {
        public class Data
        {
            public int Gold = 1;
            protected int Money = 10;
            private float HP = -10.5f;

            public void Count()
            {
                Console.WriteLine("카운트가 실행되었어요!");
            }

            private void FuncA()
            {
                Console.WriteLine("private FuncA!");
            }

            protected void Sum()
            {
                Console.WriteLine("protected Sum!");
            }

            public void Add(int a, int b)
            {
                Console.WriteLine(a + "+ " + b);
            }
        }

        static void Main(string[] args)
        {
            Data date = new Data();
            Type cType = date.GetType();
            MethodInfo[] publicMethod = cType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] nonPublicMethod = cType.GetMethods(BindingFlags.NonPublic);

            foreach (MethodInfo info in publicMethod)
            {
                Console.WriteLine(info.Name);

                if (info.Name.CompareTo("Count") == 0)
                {
                    info.Invoke(date, null);
                }

                if (info.Name.CompareTo("Add") == 0)
                {
                    Object[] param = { 3, 5 };
                    info.Invoke(date, param);
                }
            }
        }
    }
}
