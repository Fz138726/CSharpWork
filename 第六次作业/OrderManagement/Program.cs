using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            Order order1 = new Order("张强");
            Order order2 = new Order("小丽");
            OrderItem orderItem11 = new OrderItem("ipad", 4500, 2);
            OrderItem orderItem12 = new OrderItem("iphone", 8000, 1);
            OrderItem orderItem21 = new OrderItem("裙子", 400, 1);
            OrderItem orderItem22 = new OrderItem("防晒霜", 65, 3);
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            order1.AddItem(orderItem11);
            order1.AddItem(orderItem12);
            order2.AddItem(orderItem21);
            order2.AddItem(orderItem22);

            Console.WriteLine(order1.ToString());
            Console.WriteLine(order2.ToString());
            Console.WriteLine("***操作向导***");
            Console.WriteLine("删除订单按1；添加订单按2；修改订单按3；查找订单按4；" +
                "对张强的订单明细项操作按5；对小丽的订单明细项操作按6；" +
                "对订单序列化按7；对订单反序列化按8");
            try
            {
                int num = Convert.ToInt32(Console.ReadLine());
                switch (num)
                {
                    case 1: 
                        Console.WriteLine("删除张强按1；删除小丽按2");
                        int num2 = Convert.ToInt32(Console.ReadLine());
                        switch (num2)
                        {
                            case 1: orderService.DelOrder(0); break;
                            case 2: orderService.DelOrder(1); break;
                            default: Console.WriteLine("输入参数错误"); break;
                        }                  
                        break;
                    case 2: 
                        Console.WriteLine("请输入添加订单的客户名：");
                        Order order = new Order(Console.ReadLine());
                        orderService.AddOrder(order);
                        break;
                    case 3: Console.WriteLine("修改张强订单按1；修改小丽订单按2");
                         int num3 = Convert.ToInt32(Console.ReadLine());
                        switch (num3)
                        {
                            case 1:
                                Console.WriteLine("请输入修改后的客户名：");
                                Order order3 = new Order(Console.ReadLine());
                                orderService.AlterOrder(0, order3); break;
                            case 2:
                                Console.WriteLine("请输入修改后的客户名：");
                                Order order4 = new Order(Console.ReadLine());
                                orderService.AlterOrder(1, order4); break;
                            default: Console.WriteLine("输入参数错误"); break;
                        }
                        break;
                    case 4:
                        Console.WriteLine("通过订单号查找按1；通过商品名查找按2；通过客户名查找按3");
                        int num4 = Convert.ToInt32(Console.ReadLine());
                        switch (num4)
                        {
                            case 1:
                                Console.WriteLine("请输入订单号：");
                                int num45 = Convert.ToInt32(Console.ReadLine());
                                orderService.Search2(num45);
                                break;
                            case 2:
                                Console.WriteLine("请输入商品名：");
                                orderService.Search3(Console.ReadLine());
                                break;
                            case 3:
                                Console.WriteLine("请输入客户名：");
                                orderService.Search1(Console.ReadLine());
                                break;
                            default: Console.WriteLine("输入参数错误"); break;
                        }
                        break;
                    //case 5,case 6 对明细项操作
                    case 5:
                        Console.WriteLine("添加明细项按1；删除明细项按2；修改明细项按3");
                        int num5 = Convert.ToInt32(Console.ReadLine());
                        switch (num5)
                        {
                            case 1:
                                Console.WriteLine("请输入商品名：");
                                String name = Console.ReadLine();
                                Console.WriteLine("请输入商品价格：");
                                int price = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("请输入商品数量：");
                                int number = Convert.ToInt32(Console.ReadLine());
                                OrderItem orderItem = new OrderItem(name, price, number);
                                order1.AddItem(orderItem);
                                break;
                            case 2:
                                Console.WriteLine("请输入要删除的明细项的商品名：");
                                order1.DelItem(Console.ReadLine());
                                break;
                            case 3:
                                Console.WriteLine("请输入要修改的明细项：（ipad请按1，iphone请按2）");
                                int index = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("请输入替换掉它的明细项的商品名：");
                                String name2 = Console.ReadLine();
                                Console.WriteLine("请输入替换掉它的明细项的商品价格：");
                                int price2 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("请输入替换掉它的明细项的商品数量：");
                                int number2 = Convert.ToInt32(Console.ReadLine());
                                order1.AlterItem(index, name2, price2, number2);
                                break;
                            default: Console.WriteLine("输入参数错误"); break;
                        }
                        break;
                    case 6:
                        Console.WriteLine("添加明细项按1；删除明细项按2；修改明细项按3");
                        int num6 = Convert.ToInt32(Console.ReadLine());
                        switch (num6)
                        {
                            case 1:
                                Console.WriteLine("请输入商品名：");
                                String name = Console.ReadLine();
                                Console.WriteLine("请输入商品价格：");
                                int price = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("请输入商品数量：");
                                int number = Convert.ToInt32(Console.ReadLine());
                                OrderItem orderItem = new OrderItem(name, price, number);
                                order2.AddItem(orderItem);
                                break;
                            case 2:
                                Console.WriteLine("请输入要删除的明细项的商品名：");
                                order2.DelItem(Console.ReadLine());
                                break;
                            case 3:
                                Console.WriteLine("请输入要修改的明细项：（裙子请按1，防晒霜请按2）");
                                int index = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("请输入替换掉它的明细项的商品名：");
                                String name2 = Console.ReadLine();
                                Console.WriteLine("请输入替换掉它的明细项的商品价格：");
                                int price2 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("请输入替换掉它的明细项的商品数量：");
                                int number2 = Convert.ToInt32(Console.ReadLine());
                                order2.AlterItem(index, name2, price2, number2);
                                break;
                            default: Console.WriteLine("输入参数错误"); break;
                        }
                        break;
                    case 7:orderService.Export();
                        break;
                    case 8:orderService.Import();
                        break;
                    default:Console.WriteLine("输入参数错误");break;
                }
            }
            catch
            {
                Console.WriteLine("输入参数错误");
            }
        }
    }
}
