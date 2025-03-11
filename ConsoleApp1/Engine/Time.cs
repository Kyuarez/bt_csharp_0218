using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Time
    {
        public static float DeltaTime
        {
            get
            {
                return (float)DeltaTimeSpan.TotalMilliseconds;
            }
        }

        protected static TimeSpan DeltaTimeSpan { get; set; }
        protected static DateTime CurrentTime { get; set; }
        protected static DateTime LastTime { get; set; }

        public static void Update()
        {
            CurrentTime = DateTime.Now;
            DeltaTimeSpan = CurrentTime - LastTime;
            LastTime = CurrentTime;
        }
    }
}
