using System.Text;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Engine.Instance.Init();

            Engine.Instance.Load("level01.map");
            Engine.Instance.Run();
        
            Engine.Instance.Quit();
        }
    }
}
