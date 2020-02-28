using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num1;
            double num2;
            try
            {
                num1 = double.Parse(textBox1.Text);
                num2 = double.Parse(textBox2.Text);
            }
            catch
            {
                labelResult.Text = "请输入数字";
                return;
            }

            switch (textBox3.Text)
            {
                case "+":
                    labelResult.Text = "结果：" + (num1 + num2);
                    break;
                case "-":
                    labelResult.Text = "结果：" + (num1 - num2);
                    break;
                case "*":
                    labelResult.Text = "结果：" + (num1 * num2);
                    break;
                case "/":
                    if (num2 != 0)
                        labelResult.Text = "结果：" + (num1 / num2);
                    else
                        labelResult.Text = "0不能作为除数";
                    break;
                default:labelResult.Text="请从“+”“-”“*”“/”中选择";
                    break;
            }
        }
    }
}
