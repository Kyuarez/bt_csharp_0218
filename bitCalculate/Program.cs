namespace bitCalculate
{
    public class BitArray32 
    {
        public uint Data;

        public void Set(int position)
        {
            Data = Data | (uint)(1 << position);
        }

        public void Off(int position)
        {
            Data = Data & ~(uint)(1 << position);
        }

        public bool Check(uint other)
        {
            return (int)(Data & other) > 0 ? true : false;
        }

    }

    public class Program
    {
        static void Main(string[] args)
        {
            //byte a = 0; //0000 0001
            //a = 1 << 1; //0000 0010
            //Console.WriteLine(a);


            //int R = 0xFF;
            //R = 255;
            //R = 0b11111111;

            int[] a = [10, 20, 30, 40, 50];

            unsafe
            {
                fixed (int* p = &a[0])
                {
                    int* p2 = p;
                    Console.WriteLine(*p2);

                    p2 += 1;
                    p2 += 1;
                    Console.WriteLine(*p2);
                    Console.WriteLine("--------");
                    Console.WriteLine(*p);
                }
            }
        }
    }
}
