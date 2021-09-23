using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parabolaaa
{
    public partial class Form1 : Form
    {
        private int a, b, c;
        private int x, y;
        private int min, max;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private int XV, YV;


        public Form1()
        {
            InitializeComponent();

            pictureBox1.BackColor = Color.Black;
            button1.BackColor = Color.Purple;

            label1.Text = "a";
            label2.Text = "b";
            label3.Text = "c";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics graphics = Graphics.FromImage(canvas);

            int Ox = pictureBox1.Width / 2;
            int Oy = pictureBox1.Height / 2;

            a = 10; b = 1; c = 50;

            try
            {
                a = int.Parse(textBox1.Text);
                b = int.Parse(textBox2.Text);
                c = int.Parse(textBox3.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }

            int XB = - b/ (2 *a);
            int YB = (a * XB * XB) + (b * XB) + c;

            if (XB < 0 && YB < 0)
            {
                XV = Ox + XB;
                YV = Ox - YB;
            }
            if (XB < 0 && YB > 0)
            {
                XV = Ox + XB;
                YV = Oy - XB;
            }
            if (XB > 0 && YB < 0)
            {
                XV = Ox + XB;
                YV = Oy - YB;
            }
            if (XB == 0 && YB == 0)
            {
                XV = Ox;
                YV = Oy;
            }
            if (XB == 0 && YB > 0)
            {
                XV = Ox;
                YV = Oy - YB;
            }
            if (XB == 0 && YB < 0)
            {
                XV = 0;
                YV = Oy - YB;
            }
            if (XB > 0 && YB== 0)
            {
                XV = XB + Ox;
                YV = Oy;
            }
            if (XB < 0 && YB == 0)
            {
                XV = Ox + XB;
                YV = Oy;
            }
            pictureBox1.BackColor = Color.Black;

            graphics.DrawLine(new Pen(Color.Purple, 2), new Point(0, Oy), new Point(pictureBox1.Width, Oy));

            graphics.DrawLine(new Pen(Color.Purple,2),new Point(Ox,0),new Point(Ox, pictureBox1.Height));

            Point[] P = new Point[1000];

            for (int i = -500; i < 500; i ++ )
            {
                x = i;
                y = Y(a, b, c, x);

                P[i + 500] = new Point(XV+x,YV - y);
            }

            graphics.DrawLines(new Pen(Color.Purple, 1), P);

            pictureBox1.Image = canvas;
        }

        private int Y(int a,int b,int c,int x)
        {
            return (a * x * x) + (b * x) + c;
        }
    }
}
