using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work07
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        double perRight;
        double perLeft;
        double degreePlus;
        double degreeReduce;

        Pen pen = Pens.Black;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int n = trackBar1.Value;
            int length = trackBar2.Value;
            perRight = trackBar3.Value / 100.0;
            perLeft = trackBar4.Value / 100.0;
            degreePlus = trackBar5.Value * Math.PI / 180.0;
            degreeReduce = trackBar6.Value * Math.PI / 180.0;
            switch (comboBox1.SelectedIndex)
            {
                case 0: pen = Pens.Black; break;
                case 1: pen = Pens.Yellow; break;
                case 2: pen = Pens.Blue; break;
                case 3: pen = Pens.Red; break;
                case 4: pen = Pens.Green; break;
                default: pen = Pens.Purple; break;
            }
            if (graphics == null) graphics = panel1.CreateGraphics();
            graphics.Clear(Color.WhiteSmoke);
            drawCayleyTree(n, (panel1.Width-groupBox1.Width)/2, panel1.Height, length, -Math.PI / 2);
        }
        void drawCayleyTree(int n,double x0,double y0,double length,double degree)
        {
            if (n == 0) return;
            double x1 = x0 + length * Math.Cos(degree);
            double y1 = y0 + length * Math.Sin(degree);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, length * perRight, degree + degreePlus);
            drawCayleyTree(n - 1, x1, y1, length * perLeft, degree - degreeReduce);
        }
        void drawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            labelN.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            labelLength.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            labelThR.Text = trackBar3.Value.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            labelThL.Text = trackBar4.Value.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            labelDegreeP.Text = trackBar5.Value.ToString();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            labelDegreeR.Text = trackBar6.Value.ToString();
        }
    }
}
