namespace SecretMap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //2^16 : int cover 가능
            //2^64 : long으로 

            int n = 6;

            int[] arr1 = { 46, 33, 33, 22, 31, 50 };
            int[] arr2 = { 27, 56, 19, 14, 14, 10 };

            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = arr1[i] | arr2[i];       
            }

            int bitMask = 0b10000000;
            for (int i = 0; i < result.Length; i++)
            {
                bitMask = 1 << n - 1;

                for (int j = 0; j < n; j++)
                {
                    Console.Write((bitMask & result[i]) > 0 ? "#" : " ");
                    bitMask >>= 1;
                }
                Console.WriteLine();
                //Console.WriteLine(Convert.ToString(result[i], 2).Replace('1', '#').Replace('0', ' '));
            }
        }
    }

}
