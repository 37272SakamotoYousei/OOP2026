namespace sample0415
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("array[" + i + "]=");
                array[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();

            //for (int i = 0; i < array.Length; i++)
            //{
            //sum += array[i];
            //}

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("array[" + i + "]:");
                astOut(array[i]);
                Console.WriteLine();
            }

            Console.WriteLine("合計" + array.Where(n => n % 2 == 0).Sum());
        }

        static void astOut(int num)
        {
            for (int j = 0; j < num; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}
