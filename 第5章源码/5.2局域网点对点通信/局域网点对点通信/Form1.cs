using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//add
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
namespace 局域网点对点通信
{
    public partial class Form1 : Form
    {
        delegate void SetCallBack(string tet);//****************跨线程
        private Thread th;//创建线程，用以侦听端口号，接收信息
        private TcpListener tlListen1;//用以侦听端口号
        private bool listenerRun = true;//设定标志位，判断侦听状态
        private NetworkStream tcpStream;//创建传送/接收的基本数据流实例
        private StreamWriter reqStreamW;//用以实现向远程主机传送信息
        private TcpClient tcpc;//用以创建对远程主机的连接//用以创建对远程主机的连接 
        private Socket skSocket;//用以接收远程主机传送来的数据
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//连接远程机
        {
            try
            {//textBox1:远程IP地址:
                tcpc = new TcpClient(textBox1.Text, Int32.Parse(textBox3.Text));//想远程计算机提出连接申请
                tcpStream = tcpc.GetStream();//如果连接申请建立，则获得用以传送数据的数据流
                toolStripStatusLabel1.Text = "成功连接远程计算机!";
                button1.Enabled = false;
                button2.Enabled = true;
                button4.Enabled = true;
            }
            catch (Exception)
            {
                toolStripStatusLabel1.Text = "目标计算机拒绝连接请求！";
            }
        }
private void CallBack(string text)//
{// InvokeRequired required compares the thread ID of the// calling thread to the thread ID of the creating thread.// If these threads are different, it returns true.
if (this.textBox1.InvokeRequired)
{
SetCallBack d = new SetCallBack(CallBack);
this.Invoke(d, new object[] { text });
}
else
{
this.listBox2.Items.Add(text);
}
}// This event handler starts the form's// BackgroundWorker by calling RunWorkerAsync.// The Text property of the TextBox control is set// when the BackgroundWorker raises the RunWorkerCompleted// event.
        private void Listens()//利用Socket来接收信息
        {
            try
            {//textBox2本地端口:
            tlListen1 = new TcpListener(Int32.Parse(textBox2.Text));
            tlListen1.Start();//侦听指定端口号
            toolStripStatusLabel1.Text = "正在监听...";//接受远程计算机的连接请求，并获得用以接收数据的Socket实例
            //button3.Enabled = false;//引发跨线程调用，可能导致资源竞争详见//****************跨线程
            skSocket = tlListen1.AcceptSocket();//获得远程计算机对应的网络远程终结点
            EndPoint tempRemoteEP = skSocket.RemoteEndPoint;
            IPEndPoint tempRemoteIp = (IPEndPoint)tempRemoteEP;
            IPHostEntry host = Dns.GetHostByAddress(tempRemoteIp.Address);
            string HostName = host.HostName;//根据获得的远程计算机对应的网络远程终结点获得远程计算机的名称
            toolStripStatusLabel1.ToolTipText = "" + HostName + "'" + "远程计算机正确连接！";
            while (listenerRun)//循环侦听
            {
                Byte[] stream = new byte[80];//定义从远程计算机接收到数据存放的数据缓冲区
                string time = DateTime.Now.ToString();//获得当前的时间
                int i = skSocket.ReceiveFrom(stream, ref tempRemoteEP);//接收数据，并存放到定义的缓冲区中
                string sMessage = System.Text.Encoding.UTF8.GetString(stream);//以指定的编码从缓冲区中解析出内容
                CallBack(time + "" + HostName + ":");//****************跨线程
                CallBack(sMessage);//显示接收到的数据//****************跨线程
            }
            }
            catch (System.Security.SecurityException)
            {
                MessageBox.Show("防火墙安全错误!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void button2_Click(object sender, EventArgs e)//断开连接
        {
            listenerRun = false;
            tcpc.Close();
            toolStripStatusLabel1.Text = "断开连接！";
            button1.Enabled = true;
            button2.Enabled = false;
            button4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)//侦听端口
        {
            th = new Thread(new ThreadStart(Listens));//以Listen过程来初始化线程实例
            //button3.Enabled = false;
            th.Start();//启动此线程
        }

        private void button4_Click(object sender, EventArgs e)//发送信息
        {
            try
            {
                string sMsg = textBox4.Text;
                string MyName = Dns.GetHostName();//以特定的编码往向数据流中写入数据，默认为UTF8Encoding的实例
                reqStreamW = new StreamWriter(tcpStream);//将字符串写入数据流中
                reqStreamW.Write(sMsg);//清理当前编写器的所有缓冲区，并使所有缓冲数据写入基础流
                reqStreamW.Flush();
                string time = DateTime.Now.ToString();//显示传送的数据和时间
                listBox1.Items.Add(time + " " + MyName + ":");
                listBox1.Items.Add(sMsg);
                textBox4.Clear();
            }
            catch (Exception)//异常处理
            {
                toolStripStatusLabel1.Text = "无法发送信息到目标计算机！";
            }
        }
    }
}
