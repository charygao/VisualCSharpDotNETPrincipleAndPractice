using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Media_Player播放器
{
    public partial class Form1 : Form
    {
private int n = 0;
private bool random_mode;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//添加歌曲按钮
        {
            OpenFileDialog myFile = new OpenFileDialog();
            myFile.Filter = "*.mp3;*.wav;*.mpeg;*.avi;*.wmv|*.mp3;*.wav;*.mpeg;*.avi;*.wmv";//过滤掉其他类型的文件
            myFile.CheckFileExists = true;//检测文件和路径是否存在
            myFile.CheckPathExists = true;
            if (myFile.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(myFile.FileName);//axWindowsMediaPlayer1.URL = myFile.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)//顺序播放按钮
        {
            if (listBox1.Items.Count == 0) return;
            this.axWindowsMediaPlayer1.URL = listBox1.Items[0].ToString();
            random_mode = false;
        }

        private void button3_Click(object sender, EventArgs e)//随机播放按钮
        {
            if (listBox1.Items.Count == 0) return;
            random_mode = true;
            Random rdm = new Random(unchecked((int)DateTime.Now.Ticks));
            int m = rdm.Next() % listBox1.Items.Count;
            this.axWindowsMediaPlayer1.URL = listBox1.Items[m].ToString();
        }
//播放状态改变PlayStateChange事件，PlayState：播放状态
        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (this.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                timer1.Start();
            }
        }
//定时器的Tick事件代码
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (!random_mode)//顺序播放
            {
                n++;
                n = n % listBox1.Items.Count;
                this.axWindowsMediaPlayer1.URL = listBox1.Items[n].ToString();
            }
            else//随机模式播放
            {
                n++;
                Random rdm = new Random(unchecked((int)DateTime.Now.Ticks));
                int m = rdm.Next() % listBox1.Items.Count;
                this.axWindowsMediaPlayer1.URL = listBox1.Items[n].ToString();
            }
        }
        
    }
}
