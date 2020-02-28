using System;

namespace ConsoleApp2_0228_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("2到100的质数有：");
            PrimeNum();

        }
        
        public static void PrimeNum()  //埃氏筛法
        {
            int[] num;
            num = new int[101];
            num[0] = 0;
            num[1] = 0;
            for(int i = 2; i < num.Length; i++)
            {
                num[i] = i;
            }

            int k = 2;
            int max = num[num.Length - 1];
            while ( k*k <= max )
            {
                for (int j = 2; j < num.Length; j++) {
                    if (num[j] == 0 || j <= k)
                    {
                        continue;
                    }

                    if (num[j] % num[k] == 0)
                        num[j] = 0;       //删去值为质数倍数的数（将其值置为0）
                    else
                        max = num[j];    //for循环不断更新了max的值

                    }
                k++;
                while (num[k] == 0)
                {
                    k++;
                }
                
            }
            for (int p = 0; p < num.Length; p++) {   //输出质数
                if (num[p] != 0)
                    Console.WriteLine(num[p]);
                    }
        }
    }
}
