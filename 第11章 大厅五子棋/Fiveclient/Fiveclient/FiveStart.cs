using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
namespace Fiveclient
{
    public partial class FiveStart : Form
    {
        static public bool isgoon=false;//没进行验证
        static public string passmsg;//验证内容
        public FiveStart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            passmsg = "";
            passmsg = "****" + textBox1.Text + "," + textBox2.Text;
            isgoon = true;           
            this.Close();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            isgoon = false;
        }

        private void FiveStart_Load(object sender, EventArgs e)
        {
            isgoon = false;
        }
    }
}