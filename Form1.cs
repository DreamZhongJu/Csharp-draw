using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;

namespace Dashboard
{
    public partial class Form1 : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse

         );

        static Form1 _obj;
        public static Form1 Instance
        {
            get {
                if (_obj == null)
                {
                    _obj = new Form1();
                }
                return _obj;
            }
        }
        public Button BackButton
        {
            get { return button3; }
            set { button3 = value; }
        }

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panel1.Height = button1.Height;
            panel1.Top = button1.Top;
            panel1.Left = button1.Left;
            button1.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Height = button1.Height;
            panel1.Top = button1.Top;
            panel1.Left = button1.Left;
            button1.BackColor = Color.FromArgb(46,51,73);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Height = pictureBox1.Height;
            panel1.Top = pictureBox1.Top;
            panel1.Left = pictureBox1.Left;
            pictureBox1.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Height = button2.Height;
            panel1.Top = button2.Top;
            panel1.Left = button2.Left;
            button2.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Height = button4.Height;
            panel1.Top = button4.Top;
            panel1.Left = button4.Left;
            button4.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Height = button5.Height;
            panel1.Top = button5.Top;
            panel1.Left = button5.Left;
            button5.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Height = button6.Height;
            panel1.Top = button6.Top;
            panel1.Left = button6.Left;
            button6.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
