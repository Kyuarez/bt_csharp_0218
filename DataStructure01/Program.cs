using DataStructureTK;
using System.Collections;

namespace DataStructure01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList reference = new ArrayList();
            //reference.BinarySearch()

            TKArrayList<string> strList = new TKArrayList<string>();
            strList.Add("짜장면");
            strList.Add("짬뽕");
            strList.Add("탕수육");
            strList.Add("팔보채");
            strList.Add("칠리새우");
            strList.Add("크림새우");
            strList.Add("전가복");
            strList.Add("샥스핀");

            strList.WriteArrayList();
            Console.WriteLine();
            Console.WriteLine("--------------str----------------");
            strList.Insert(2, "굴짬뽕");
            strList.Insert(1, "쟁반짜장");
            strList.Insert(4, "해삼탕");
            strList.Remove("전가복");
            strList.WriteArrayList();
            Console.WriteLine();
            Console.WriteLine("--------------reverse----------------");
            strList.Reverse();
            strList.WriteArrayList();
            Console.WriteLine();
            Console.WriteLine("--------------sort----------------");
            strList.Sort();
            strList.WriteArrayList();
        }
    }
}
