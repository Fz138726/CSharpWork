using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OrderManagement
{
    public class OrderService
    {
        List<Order> orderList = new List<Order>();
        //添加订单
        public bool AddOrder(Order order)
        {
            foreach (Order o in orderList)
            {
                if (order.Equals(o))
                {
                    Console.WriteLine("订单重复");
                    return false;
                }
            }
            orderList.Add(order);
            return true;
        }
        //删除订单
        public void DelOrder(int index)
        {
            if (index < 0 || index >= orderList.Count)
                Console.WriteLine("参数错误，无法删除订单");
            else
                orderList.RemoveAt(index);
        }
        //修改订单
        public void AlterOrder(int index, Order order)
        {
            if (index < 0 || index >= orderList.Count)
                Console.WriteLine("参数错误，无法修改订单");
            else
            {
                orderList.RemoveAt(index);
                orderList.Insert(index, order);
            }
        }
        //排序方法(按照订单号)
        public void OrderSequence()
        {
            orderList.Sort();
        }
        //LINQ查询
        //通过顾客名查找
        public void Search1(String str)
        {
            var query = from ord in orderList
                        where ord.customer == str
                        select ord;
            List<Order> list = query.ToList();
            foreach (Order order in list)
                Console.WriteLine($"订单号：{order.orderNumber} 顾客：{order.customer} 创建时间：{order.DateTime}");
        }
        //通过订单号查找
        public void Search2(int orderNum)
        {
            var query = from ord in orderList
                        where ord.orderNumber == orderNum
                        select ord;
            List<Order> list = query.ToList();
            foreach (Order order in list)
                Console.WriteLine($"订单号：{order.orderNumber} 顾客：{order.customer} 创建时间：{order.DateTime}");
        }
        //通过商品名称查找
        public void Search3(String str)
        {
            List<Order> list = new List<Order>();
            foreach (Order ord in orderList)
            {
                foreach (OrderItem item in ord.orderItems)
                {
                    if (item.name == str)
                    {
                        list.Add(ord);
                        break;
                    }
                }
            }
            foreach (Order order in list)
                Console.WriteLine($"订单号：{order.orderNumber} 顾客：{order.customer} 创建时间：{order.DateTime}");
        }
    }
}
