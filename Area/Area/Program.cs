using System;

namespace Area
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shape;
            shape = new Shape[10];

            double areaSum = 0;
            Random random = new Random();
            for (int i=0; i < 10; i++)
            {
                int num = random.Next(0, 3);
                shape[i] = Factory.Creator(num);
                areaSum += shape[i].GetArea();
            }

            Console.WriteLine("随机生成10个形状，面积之和为：" + areaSum);
        }
    }
    abstract class Shape
    {
        public abstract bool IsLegal();
        public abstract double GetArea();
    }

    //长方形
    class Rectangle : Shape
    {
        double border1;
        double border2;
        public Rectangle(double border1, double border2)
        {
            this.border1 = border1;
            this.border2 = border2;
        }
        public override bool IsLegal()
        {
            if (border1 <= 0 || border2 <= 0)
            {
                return false;
            }
            else return true;
        }
        public override double GetArea()
        {
            return border1 * border2;
        }
    }
    //正方形
    class Square : Rectangle
    {
        double border;
        public Square(double border):base(border,border)
        {
        }
    }
    //三角形
    class Triangle : Shape
    {
        double border1, border2, border3;
        public Triangle(double border1,double border2,double border3)
        {
            this.border1 = border1;
            this.border2 = border2;
            this.border3 = border3;
        }
        public override bool IsLegal()
        {
            if (border1 + border2 > border3 && border1 + border3 > border2 && border2 + border3 > border1)
                return true;
            else
                return false;
        }
        public override double GetArea()
        {
            double p = (border1 + border2 + border3) / 2;
            return Math.Sqrt(p*(p - border1)*(p - border2)*(p - border3));
        }
    }
    //工厂类
    class Factory
    {
        public static Shape Creator(int num)
        {
            Random random = new Random();
            int randomNum1 = random.Next(0, 20);
            int randomNum2 = random.Next(0, 20);
            int randomNum3 = random.Next(0, 20);
            switch (num)
            {
                case 0: return new Rectangle(randomNum1, randomNum2);
                case 1: return new Square(randomNum1);
                case 2:
                default: return new Triangle(randomNum1, randomNum2, randomNum3);
            }
        }
    }
}
