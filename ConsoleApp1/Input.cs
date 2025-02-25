using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Input
    {
        protected static ConsoleKeyInfo keyInfo;

        public Input() { }

        public static void Process()
        {
            if (true == Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
            }
        }

        public static void ClearInput()
        {
            keyInfo = new ConsoleKeyInfo();
        }

        public static bool GetKeyDonw(ConsoleKey keycode)
        {
            return keyInfo.Key == keycode;
        }
    }
}
