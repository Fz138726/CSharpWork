using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement
{
    public class OrderItem
    {
        public String name { get; set; }
        double price { get; set; }
        int num { get; set; }
        public OrderItem(String name, double price, int num)
        {
            this.name = name;
            this.price = price;
            this.num = num;
        }
        public override bool Equals(object obj)
        {
            OrderItem o = obj as OrderItem;
            if (o == null)
                return false;
            return name == o.name && price == o.price && num == o.num;
        }
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
        public override string ToString()
        {
            return $"商品：{name.ToString()}，价格：{price.ToString()}，数量：{num.ToString()}";
        }
    }
}
