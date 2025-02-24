namespace NPOT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            ulong[] x = { 3, 5, 7 };
            long[] npot = new long[n];

            for (int i = 0; i < n; i++)
            {
                ulong value = 1;
                for(int j = 1; j < 64; j++)
                {
                    value = value << 1;
                    if (x[i] < value)
                    {
                        break;
                    }
                }
                Console.WriteLine(value);
            }

            /*
            for (int i = 0; i < n; i++)
            {
                npot[i] = 0;
                while (x[i] > 0)
                {
                    x[i] = x[i] >> 1;
                    npot[i]++;
                }
                npot[i] = 1 << (int)npot[i];
            }

            long ans = 0;
            for (int i = 0; i < n; i++)
            {
                ans = ans ^ npot[i];
            }

            Console.WriteLine(ans);
             */
        }
    }
}
