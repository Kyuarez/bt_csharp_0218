using System.Text;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //string tempScene = string.Empty;
            //byte[] buffer = new byte[1024];
            //FileStream fs = new FileStream(Define.FILEPATH_MAP + "level01.map", FileMode.Open);

            ////Get File Size
            //fs.Seek(0, SeekOrigin.End);
            //long fileSize = fs.Position;
            //fs.Seek(0, SeekOrigin.Begin);

            //fs.Read(buffer, 0, (int)fileSize);
            //tempScene = Encoding.UTF8.GetString(buffer);
            //tempScene.Replace("\0", "");
            //string[] scene = tempScene.Split("\r\n");
            //fs.Close();

            //stream reader
            
           
            Engine.Instance.Load("level01.map");
            Engine.Instance.Run();
        }
    }
}
