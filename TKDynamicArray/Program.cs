namespace TKDynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TKDynamicArray<int> list = new TKDynamicArray<int>()
            { 
                1, 100, 52, 1000, 56, 86, 79
            };

            for (int i = 0; i < list.Count; i++) 
            {
                Console.WriteLine(list[i]);
            }

            Console.WriteLine();

            list.SortBubble();

            foreach (int i in list) 
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            TKDynamicArray<string> strList = new TKDynamicArray<string>() 
            {
                "리오넬 메시",
                "루이스 수아레스",
                "라민 야말",
                "네이마르",
                "사비 에르난데스",
                "안드레스 이니에스타",
                "부스케츠",
                "쿠바르시",
                "호나우지뉴",
                "조르디 알바",
                "피케",
                "푸욜",
                "페드리",
                "가비",
                "레반도프스키",
            };

            foreach (var element in strList)
            {
                Console.WriteLine($"{element}");
            }

            Console.WriteLine();

            strList.SortBubble();
            foreach (var element in strList)
            {
                Console.WriteLine($"{element}");
            }



        }
    }
}
