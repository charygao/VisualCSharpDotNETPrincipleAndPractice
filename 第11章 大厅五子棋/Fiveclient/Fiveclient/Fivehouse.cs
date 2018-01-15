using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;
namespace Fiveclient
{
    public partial class Fivehouse : Form
    {
        
        private FiveSetconnect setcon;
        static public bool isreguser=false; //判断是否注册用户  
        static public bool isConnecting = false;
        static public int portNum;
        static public string serverip;
        static public string message="";
        public string speakmessage = "";
        static public string inreguser="用户名";//登陆用户名
        static public string inregpicture ="1";//登陆用户照片信息
        static public bool inregposition = false;//登陆用户是否坐上桌子
        static public int in_id ;//登陆用户编号
        static public string other_ip;//对方IP
        static public int table;//用户座位号
        static string all_table;//服务器转发的登陆用户座位信息

        static public string myserveraddress;  
        static public int[]islable ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};  //lable设置        
         
        //网络数据
        private const string infDisconnect = "######DISCONNECT######";//断开标志
        static public NetworkStream networkClient;
        static public Thread recvThread;
        static public TcpClient myclient;
        static public StreamWriter streamWriter;
        static public StreamReader streamReader;        
        public Fivehouse()
        {
            InitializeComponent();
        }
       
        static public void startthreads()
        {
            if (recvThread == null)
            {
                recvThread = new Thread(new ThreadStart(ReceiveMsg));
                recvThread.Start();
            }
        }
        static public void ReceiveMsg()
        {

            while (isConnecting)
            {                  
             ReceiveMsg(myclient, networkClient);
            }
           // MessageBox.Show("与服务器断开了连接");

        }
        public void getmessage(string message)
        {
          listBox1.Items.Add(message); 
        }
        static public void ReceiveMsg(TcpClient tcpc, NetworkStream ns)
        {            
            try
            {
                String strout;//接收数据               
                String substr = "";
                String tmp1 = "";
                ns = tcpc.GetStream();
                streamReader = new StreamReader(ns);
                strout = streamReader.ReadLine();
                if (strout.Length >= 4)
                {
                    substr = strout.Substring(0, 4);
                    tmp1 = strout.Substring(4);
                }
                if (string.Compare(strout, infDisconnect) == 0)
                {
                    string strdcnt = "连接被中断.\n";
                    MessageBox.Show(strdcnt);
                    ns.Close();
                    tcpc.Close();
                    isConnecting = false;
                }
                if (substr == "####")//获取聊天信息
                {
                    // MessageBox.Show("受到服务器信息");
                    string[] s = tmp1.Split(new Char[] { ',' });                   
                    message = "服务器说：" + s[0].ToString() +" 。";                   

                }
                if (substr == "!!!!")//获取同桌对方IP
                {
                    //MessageBox.Show("获取对方IP", tmp1);
                    other_ip = tmp1;
                }
                if (substr == ")()(")//获取服务器发送的房间座位信息
                {
                    all_table = tmp1;
                    string message2="获取服务器发送的房间座位信息"+ tmp1;
                }
                if (substr == "****")
                {
                    //MessageBox.Show(strout);
                    string[] s = tmp1.Split(new Char[] { ',' });
                    message = "登陆成功...欢迎" + s[0].ToString() + "登陆本系统";                    
                    inreguser = s[0].ToString();
                    inregpicture = s[1].ToString();                    
                    isreguser = true;
                }
                if (strout == "**")
                {
                    
                    message="验证失败！"; 
                   
                }
                if (substr == "@@@@")
                {
                    
                    message="恭喜您，帐号注册成功" ;
                }
                if (strout == "@@")
                {
                  message="抱歉，注册失败..."; 
                }
                if (strout == "%$%$")//获取在线信息
                {
                  
                }
                //else
                //{
                //    MessageBox.Show(strout);
                //} 
            }
            catch 
            {
                MessageBox.Show("安全退出","提示");
            }

        }
        public void disconnect(TcpClient tcpc, NetworkStream ns)
        {
            byte[] write = new byte[64];
            write = Encoding.Unicode.GetBytes(infDisconnect.ToCharArray());
            ns.Write(write, 0, write.Length);
            ns.Close();
            tcpc.Close();
            disconnect();

        }
        public void disconnect()
        {               
            if (isConnecting)
            {
                recvThread.Abort();
            }
            isConnecting = false;//断开标志      
           
        }
        private void Fivehouse_Load(object sender, EventArgs e)
        {
            if (message != "")
            {
                getmessage(message);
                message = "";
            }

            if (isConnecting) //判断是否连接
            {
                if (isreguser)//判断是否登陆
                {
                    speakout.Enabled = true;

                    show_inuser.Text = Convert.ToString(inreguser);

                    if (all_table != null&&all_table!="")
                    {
                        string[] s = all_table.Split(new Char[] { ',' });
                        string new_picture, new_table;
                        for (int i = 1; i < s.Length; i = i + 4)
                        {
                            new_picture = s[i + 3].ToString();//头像
                            new_table = s[i + 2].ToString();//座位信息
                            if (new_table == "1")
                            { islable[1] = 1; label1.Image = Image.FromFile(@"..\..\newface\" + new_picture + ".bmp"); }
                            if (new_table == "2")
                            { islable[2] = 1;    label2.Image = Image.FromFile(@"..\..\newface\" + new_picture + ".bmp");}
                            if (new_table == "3")
                            { islable[3] = 1;    label3.Image = Image.FromFile(@"..\..\newface\" + new_picture + ".bmp");}
                            if (new_table == "4")
                            { islable[4] = 1; label4.Image = Image.FromFile(@"..\..\newface\" + new_picture + ".bmp"); }
                        }
                    }
                    this.Text = other_ip;

                }
                else
                {
                    this.Text = "游戏大厅" + "当前时间" + DateTime.Now.ToString() + " " + DateTime.Now.DayOfWeek.ToString();
                    show_ip.Text = Convert.ToString(NetWork.getmyIP());                    
                    button10.Enabled = true;
                    button11.Enabled = true;
                    stop_return.Enabled = true;
                    con_server.Enabled = false;
                }
            }           
            else
            {
                button10.Enabled = false;
                button11.Enabled = false;
                speakout.Enabled = false;
                stop_return.Enabled = false;
            }
            
        }


        private void button11_Click(object sender, EventArgs e)
        {
             
           　 FiveLogin reg = new FiveLogin();
           　 reg.ShowDialog();
              listBox1.Items.Add("连接注册服务器...");          　   
              SendMsg(networkClient, FiveLogin.regmsg);//发送注册信息
              FiveLogin.regmsg = "";
        }
        static public void SendMsg(NetworkStream ns, string tmp)
        {           
            streamWriter = new StreamWriter(ns);            
            streamWriter.WriteLine(tmp);
            streamWriter.Flush();            
        }
        private void button10_Click(object sender, EventArgs e)
        {
           
            FiveStart go = new FiveStart();
            go.ShowDialog();           
            if (FiveStart.isgoon)
            {
                if (isConnecting)
                {
                    string msg11 = FiveStart.passmsg + ',' + Convert.ToString(NetWork.getmyIP())+','+in_id.ToString() ;
                    listBox1.Items.Add("用户验证中...");
                    SendMsg(networkClient, msg11);//发送验证请求                
                    FiveStart.passmsg = "";
                }
            }
           
        }

        private void con_server_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("准备连接服务器");
            setcon = new FiveSetconnect();
            setcon.ShowDialog();
            if (isConnecting)
            {
                listBox1.Items.Add("连接成功！" + DateTime.Now.ToString());
              //  Fivehouse.startthreads(); 
            }
            else
            {
                listBox1.Items.Add("连接失败！");
            }
           
        }

        public void stop_return_Click(object sender, EventArgs e)
        {
            isreguser = false;            
            for (int i = 0; i <18; i++)
            {
                islable[i] = 0;
            }
           label12=new Label();
           label13.Invalidate();
           label14.Invalidate();
           this.pictureBox1.Invalidate();
           this.listBox1.Items.Add("用户"+inreguser+"已经退出!");
           inreguser = "";
           show_inuser.Text = "";
           this.Invalidate();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tmp = ")()(" + Convert.ToString(inreguser) + "," + "1," + table.ToString() +","+ inregpicture;
            SendMsg(networkClient, tmp);
            FiveGame five = new FiveGame();
            five.ShowDialog();
   
        }
        private void button2_Click(object sender, EventArgs e)
        {

            string tmp = ")()(" + Convert.ToString(inreguser) + "," + "2," + table.ToString() + "," + inregpicture;
            SendMsg(networkClient, tmp);
            FiveGame five = new FiveGame();
            five.ShowDialog();

        }
        private void button3_Click(object sender, EventArgs e)
        {

            string tmp = ")()(" + Convert.ToString(inreguser) + "," + "3," + table.ToString() + "," + inregpicture;
            SendMsg(networkClient, tmp);
            FiveGame five = new FiveGame();
            five.ShowDialog();

        }
        //button4---button9略

        private void label1_Click(object sender, EventArgs e)
        {
            if (islable[1] == 0)
            {
                if (inregposition)
                {
                    MessageBox.Show("你已经坐进了其他位子");
                }
                else
                {
                    label1.Image = Image.FromFile(@"..\..\newface\" + inregpicture + ".bmp");
                    inregposition = true;
                    islable[1] = 1;
                    table = 1;
                    button1.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("已经有人坐在这里了！请换位");
            }

        }
        private void label2_Click(object sender, EventArgs e)
        {
            if (islable[2] == 0)
            {
                if (inregposition)
                {
                    MessageBox.Show("你已经坐进了其他位子");
                }
                else
                {
                    label2.Image = Image.FromFile(@"..\..\newface\" + inregpicture + ".bmp");
                    inregposition = true;
                    islable[2] = 1;
                    table = 2;
                    this.button1.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("已经有人坐在这里了！请换位");
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (islable[3]== 0)
            {
                if (inregposition)
                {
                    MessageBox.Show("你已经坐进了其他位子");
                }
                else
                {
                    label3.Image = Image.FromFile(@"..\..\newface\" + inregpicture + ".bmp");
                    inregposition = true;
                    islable[3] = 1;
                    table = 3;
                    this.button2.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("已经有人坐在这里了！请换位");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (islable[4] == 0)
            {
                if (inregposition)
                {
                    MessageBox.Show("你已经坐进了其他位子");
                }
                else
                {
                    label5.Image = Image.FromFile(@"..\..\newface\" + inregpicture + ".bmp");
                    inregposition = true;
                    islable[4] = 1;
                    table = 4;
                    this.button2.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("已经有人坐在这里了！请换位");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (islable[5] == 0)
            {
                if (inregposition)
                {
                    MessageBox.Show("你已经坐进了其他位子");
                }
                else
                {
                    label4.Image = Image.FromFile(@"..\..\newface\" + inregpicture + ".bmp");
                    inregposition = true;
                    islable[5] = 1;
                    table = 5;
                    this.button3.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("已经有人坐在这里了！请换位");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (islable[6] == 0)
            {
                if (inregposition)
                {
                    MessageBox.Show("你已经坐进了其他位子");
                }
                else
                {
                    label8.Image = Image.FromFile(@"..\..\newface\" + inregpicture + ".bmp");
                    inregposition = true;
                    islable[6] = 1;
                    table = 6;
                    this.button3.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("已经有人坐在这里了！请换位");
            }
        }
        //label7---label18略

        private void speakout_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                speakmessage = "####" + inreguser +","+ textBox1.Text;
                listBox1.Items.Add(inreguser +　"说："　+ textBox1.Text);
                SendMsg(networkClient, speakmessage);
                speakmessage="";
            }
        }

        private void Fivehouse_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isConnecting)
            {    
               
                //listBox1.Items.Add("退出服务器...");
                string msgoutserver = "%%%%" + Convert.ToString(inreguser);
                SendMsg(networkClient, msgoutserver);
                myclient.Close();           
                networkClient.Close();
            }
            isConnecting = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }


    }
}