using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class WaitForSeconds
    {
        public float seconds;
        private DateTime startTime;

        public WaitForSeconds(float seconds)
        {
            this.seconds = seconds;
            startTime = DateTime.Now;
        }

        public bool IsReady()
        {
            return (DateTime.Now - startTime).TotalSeconds >= seconds;
        }
    }
}
