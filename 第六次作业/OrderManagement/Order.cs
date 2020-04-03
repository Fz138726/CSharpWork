using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement
{
    public class Order : IComparable
    {
        public String customer;
        public DateTime DateTime = DateTime.Now;
        public uint orderNumber { get { return (uint)DateTime.GetHashCode(); } }
        public List<OrderItem> orderItems = new List<OrderItem>();
        public Order(String customer)
        {
            this.customer = customer;
        }
        public Order()
        {
            customer = "匿名买家";
        }
        //增加明细项
        public bool AddItem(OrderItem orderItem)
        {
            foreach (OrderItem ord in orderItems)
            {
                if (ord.Equals(orderItem))
                {
                    Console.WriteLine("明细项重复");
                    return false;
                }
            }
            orderItems.Add(orderItem);
            return true;
        }
        //删除明细项
        public void DelItem(String name)
        {
            int index = 0;
            foreach(OrderItem orderItem in orderItems)
            {
                if (name == orderItem.name)
                    orderItems.RemoveAt(index);
                index++;
            }
        }
        //修改明细项
        public bool AlterItem(int index, String name, double price, int num)
        {
            if (index < 0 || index >= orderItems.Count)
            {
                Console.WriteLine("输入参数错误");
                return false;
            }
            OrderItem orderItem = new OrderItem(name, price, num);
            orderItems.RemoveAt(index);
            orderItems.Insert(index, orderItem);
            return true;
        }
        public override bool Equals(Object ob)
        {
            Order order1 = ob as Order;
            if (order1 == null)
                return false;
            return orderNumber == order1.orderNumber;
        }
        public override int GetHashCode()
        {
            return orderNumber.GetHashCode();
        }
        //ToString
        public override string ToString()
        {
            String str = null;
            foreach (OrderItem orderItem in orderItems)
            {
                str += orderItem.ToString() + "\n";
            }
            return $"订单号：{orderNumber.ToString()}\n" +
                $"买家：{customer}\n" +
                $"订单明细：\n{str}";
        }
        public int CompareTo(object ob)
        {
            Order order = ob as Order;
            if (order == null)
                throw new System.ArgumentException();
            return this.orderNumber.CompareTo(order.orderNumber);
        }
    }
}
