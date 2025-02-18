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
            keyInfo = Console.ReadKey();
        }

        public static bool GetKeyDonw(ConsoleKey keycode)
        {
            return keyInfo.Key == keycode;
        }
    }
}
