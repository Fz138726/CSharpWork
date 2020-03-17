using System;
using System.Threading;

namespace TimeEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = 00, minute = 00, second = 00;
            Console.WriteLine("请设置闹钟：\n");
            try
            {
                Console.WriteLine("时：(0到23的整数)");
                hour = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("分：(0到59的整数)");
                minute = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("秒：(0到59的整数)");
                second = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("**请输入正确的闹铃时间");
            }
            Form form = new Form();
            form.ClockRing2.MakeTheAlarm(hour, minute, second);
            form.ClockRing1.MakeTheTick();
        }
    }
    public delegate void Ring(object sender,ClockTime args);
    public class ClockTime
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
    }
    public class ClockRing
    {
        public event Ring Tick;
        public event Ring Alarm;
        public void MakeTheTick()
        {
            String timeNow = DateTime.Now.ToString("hh:mm:ss");
            ClockTime args = new ClockTime();
            Tick(this,args);
        }
        public void MakeTheAlarm(int h, int m, int s)
        {
            ClockTime args = new ClockTime()
            {
                Hour = h,
                Minute = m,
                Second = s
            };
            Alarm(this, args);
        }
    }
    public class Form
    {
        public ClockRing ClockRing1 = new ClockRing();//tick
        public ClockRing ClockRing2 = new ClockRing();//alarm

        public Form()
        {
            ClockRing1.Tick += TimeGoes;
            ClockRing2.Alarm += TimeIsUp;
        }
        void TimeGoes(object sender, ClockTime args)
        {
            while (true) {
                Console.WriteLine(DateTime.Now.ToLongTimeString());
                Thread.Sleep(1000);
            }
        }
        void TimeIsUp(object sender, ClockTime args)
        {
            while (true)
            {
                String timeNow = DateTime.Now.ToString("hh:mm:ss");
                try
                {
                    Console.WriteLine(timeNow);
                    if (args.Hour == Convert.ToInt32(timeNow.Substring(0, 2)) && args.Minute == Convert.ToInt32(timeNow.Substring(3, 2))
                    && args.Second == Convert.ToInt32(timeNow.Substring(6, 2)))
                    {
                        Console.WriteLine("RING...RING...RING...RING...RING...RING...RING...");
                    }
                }
                catch
                {
                    Console.WriteLine("error");
                }
                Thread.Sleep(1000);
            }
        }
    }
}
