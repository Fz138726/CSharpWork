using System;

namespace Calculator1
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1;
            double n2;
            try
            {
                Console.WriteLine("输入数1:");
                n1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("输入数2:");
                n2 = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("错误！请输入正确的数字");
                return;
            }
            Console.WriteLine("输入运算符:");
            switch (Console.ReadLine())
            {
                case "+": Console.WriteLine("结果：" + (n1 + n2));
                    break;
                case "-": Console.WriteLine("结果：" + (n1 - n2));
                    break;
                case "*": Console.WriteLine("结果：" + n1 * n2); 
                    break;
                case "/":
                    if (n2 != 0)
                        Console.WriteLine("结果：" + n1 / n2);
                    else
                        Console.WriteLine("除数不可为0");
                    break;
                default:
                    Console.WriteLine("错误！请输入正确的运算符（“+”“-”“*”“/”）");
                    break;
            }
        }
    }
}

