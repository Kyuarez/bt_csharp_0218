using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    public class Program
    {
        public static int Compare(GameObject first, GameObject second)
        {
            SpriteRenderer spr1 = first.GetComponent<SpriteRenderer>();
            SpriteRenderer spr2 = second.GetComponent<SpriteRenderer>();

            if (spr1 == null || spr2 == null)
            {
                return 0;
            }

            return spr1.orderLayer - spr2.orderLayer;
        }

        public static void Main(string[] args)
        {
            Engine.Instance.Init();

            Engine.Instance.SetSortCompare(Compare);
            Engine.Instance.Load("level01.map");
            Engine.Instance.Run();

            Engine.Instance.Quit();
        }
    }
}
