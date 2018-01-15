using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 控件测试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshState();
        }
        void RefreshState()
        {
            toolStripStatusLabel1.Text = mk.GetTime();//获取当前时间
            toolStripStatusLabel1.Text += "|" + mk.Show_Interval.ToString();
            //mk.Timer_Enable = true;
            toolStripStatusLabel1.Text += "|" + mk.Timer_Enable.ToString();
            //MessageBox.Show("|字体：" + mk.set_myFont.ToString());
            toolStripStatusLabel1.Text += "|" + mk.set_myFont.Name;//.ToString();
            //MessageBox.Show("|前景颜色：" + mk.ForeColor.ToString());
            //colorDialog1.ShowDialog();
            //mk.ForeColor = colorDialog1.Color;
            toolStripStatusLabel1.Text += "|" + mk.ForeColor.Name;
            //mk.FontVisible = false;//true;
            toolStripStatusLabel1.Text += "|" + mk.FontVisible.ToString();
            toolStripStatusLabel1.Text += "|" + mk.SetCall;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (mk.Timer_Enable == false)
            {
                mk.Timer_Enable = true;//定时启动
            }
            else
            {
                mk.Timer_Enable = false;
            }
            RefreshState();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            mk.set_myFont = fontDialog1.Font;
            RefreshState();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            mk.ForeColor = colorDialog1.Color;
            RefreshState();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mk.AddTime(textBox1.Text, textBox2.Text);
            RefreshState();
        }
    }
}
