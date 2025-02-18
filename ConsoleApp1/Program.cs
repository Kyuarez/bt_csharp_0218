namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine.Instance.Load();
            Engine.Instance.Run();
        }
    }
}
