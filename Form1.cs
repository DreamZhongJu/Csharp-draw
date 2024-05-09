using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;

// 绘图
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

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

        // 绘图
        // 使用pen绘制基础图形
        private void button7_Click(object sender, EventArgs e)
        {
            panelClear();
            Graphics g = panel3.CreateGraphics();
            Pen pen = new Pen(Color.Blue, 3);

            // 矩形
            g.DrawRectangle(pen, new Rectangle(10, 10, 100, 50));
            // 椭圆
            g.DrawEllipse(pen, new Rectangle(120, 10, 100, 50));
            // 线段
            g.DrawLine(pen, new Point(10, 70), new Point(230, 70));
        }

        // 使用LinearGradientBrush实现渐变色字体
        private void button8_Click(object sender, EventArgs e)
        {
            panelClear();
            Graphics g = panel3.CreateGraphics();
            string text = textBox1.Text.ToString();
            Font font = new Font(selectedFontFamily, 20, FontStyle.Bold);
            Rectangle textRect = new Rectangle(10, 90, 2000, 200);
            LinearGradientBrush lgb = new LinearGradientBrush(textRect, Color.Red, Color.Blue, 45);
            g.DrawString(text, font, lgb, textRect);
        }

        // 使用GraphicsPath实现艺术字
        private void button9_Click(object sender, EventArgs e)
        {
            panelClear();
            Graphics g = panel3.CreateGraphics();
            GraphicsPath gp = new GraphicsPath(FillMode.Winding);
            string text = textBox1.Text.ToString();
            gp.AddString(
                text, new FontFamily(selectedFontFamily), (int)FontStyle.Regular,
                80, new PointF(10, 150), new StringFormat());

            Brush brush = new LinearGradientBrush(new Rectangle(10, 150, 300, 100), Color.Green, Color.Yellow, 45);
            g.DrawPath(Pens.Green, gp);
            g.FillPath(brush, gp);
        }

        // 清空
        private void button10_Click(object sender, EventArgs e)
        {
            panelClear();
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
        }
        private void panelClear()
        {
            panel3.Invalidate();
            panel3.Update();
        }

        // 选择字体
        private string selectedFontFamily = "Arial";
        private void button11_Click(object sender, EventArgs e)
        {
            // 加载所有字体到 comboBox1
            InstalledFontCollection installedFonts = new InstalledFontCollection();
            foreach (FontFamily font in installedFonts.Families)
            {
                comboBox1.Items.Add(font.Name);
            }

            // 订阅 comboBox1 的 SelectedIndexChanged 事件
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 更新选中的字体
            selectedFontFamily = comboBox1.SelectedItem.ToString();
        }
    }
}
