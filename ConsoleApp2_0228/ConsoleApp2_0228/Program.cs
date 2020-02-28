using System;

namespace ConsoleApp2_0228
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个正整数：");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num <= 1)
            {
                Console.WriteLine("该数无质数因子");
                return;
            }
            int count = 0;
            Console.WriteLine("其质数因子为：");
            for(int i = 2; i < num; i++)
            {
                if (num % i == 0 && IsPrimeNum(i))
                {

                    Console.WriteLine(i);
                    count++;
                }
                
            }
            if (count == 0)
                Console.WriteLine("null");

        }

        public static bool IsPrimeNum(int num)
        {
            for(int i=2;i<num; i++)
            {
                if (num % i == 0)
                    return false;

            }
            return true;
        }
    }
}
