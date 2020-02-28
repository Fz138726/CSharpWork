using System;

namespace ConsoleApp2_0228_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入数字个数是：");
            int count = int.Parse(Console.ReadLine());
            Console.WriteLine("输入整数数组：");
            int[] num;
            num = new int[count];

            for (int i = 0; i < count; i++)
            {
                num[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("最大值：" + Max(num));
            Console.WriteLine("最小值：" + Min(num));
            Console.WriteLine("平均值：" + Average(num));
            Console.WriteLine("数组元素的和：" + Sum(num));

        }

        public static int Max(int[] num)
        {
            int max = num[0];
            for (int i = 0; i < num.Length; i++)
            {
                if (max < num[i])
                    max = num[i];
            }
            return max;
        }

        public static int Min(int[] num)
        {
            int min=num[0];
            for (int i = 0; i < num.Length; i++)
            {
                if (min > num[i])
                    min = num[i];
            }
            return min;
        }

        public static double Average(int[] num)
        {
            return Sum(num) / (double)num.Length;
        }

        public static int Sum(int[] num)
        {
            int sum = 0;
            for(int i = 0; i < num.Length; i++)
            {
                sum += num[i];
            }
            return sum;
        }
    }
}
