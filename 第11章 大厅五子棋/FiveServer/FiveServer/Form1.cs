using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections;
using System.Data.SqlClient;
namespace FiveServer
{
    public partial class FiveServer : Form
    {
        private Socket mainSocket;
        public delegate void UpdateRichEditCallback(string text);
        public delegate void UpdateClientListCallback();
        public AsyncCallback pfnWorkerCallback;
        public string username;
        public int  userpicture;
        private ArrayList workerSocketList = ArrayList.Synchronized(new ArrayList());
        private int clientNum = 0;//客户的编号
        private string all_table;//所有房间座位信息
        static public string clientmsg="";
        public FiveServer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPort.Text == "")
                {
                    MessageBox.Show("请先填写服务器端口！", "提示");
                    return;
                }
                Int32 port = Int32.Parse(txtPort.Text);
                mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint localEP = new IPEndPoint(IPAddress.Any, port);
                mainSocket.Bind(localEP);//将socket绑定到本地终接点上
                mainSocket.Listen(5);
                mainSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);//开始一个异步操作接受客户的连接请求
                UpdateControls(true);

            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message, "提示");
            }
        }

        private void FiveServer_Load(object sender, EventArgs e)
        {
            try
            {
                txtIP.Text = Dns.Resolve(Dns.GetHostName()).AddressList[0].ToString();
                UpdateControls(false);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CloseSockets();
            UpdateControls(false);
            UpdateClientListControl();//更新客户列表
        }

        private void button5_Click(object sender, EventArgs e)//发送
        {
            if (clientList.Items.Count != 0)
            {
                try
                {
                    string msg = txtSendMsg.Text;
                    msg = "####" + msg + "\n";
                    byte[] byData = System.Text.Encoding.UTF8.GetBytes(msg);
                    Socket workerSocket = null;
                    for (int i = 0; i < workerSocketList.Count; i++)
                    {
                        workerSocket = (Socket)workerSocketList[i];
                        if (workerSocket != null)
                        {
                            if (workerSocket.Connected)
                            {
                                workerSocket.Send(byData);
                            }
                        }
                    }
                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.Message, "提示！");
                }
            }
            else
            {
                MessageBox.Show("没有在线客户，不能发送信息", "提示");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CloseSockets();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtRecvMsg.Clear();
        }
        //关闭socket
        void CloseSockets()
        {
            if (mainSocket != null)
            {
                mainSocket.Close();
            }
            Socket workerSocket = null;
            for (int i = 0; i < workerSocketList.Count; i++)
            {
                workerSocket = (Socket)workerSocketList[i];
                if (workerSocket != null)
                {
                    workerSocket.Close();
                    workerSocket = null;
                }
            }
        }
        //更新客户列表
        private void UpdateClientListControl()
        {
            if (InvokeRequired)
            {
                clientList.BeginInvoke(new UpdateClientListCallback(UpdateClientList), null);
            }
            else
            {
                UpdateClientList();
            }
        }
        void UpdateClientList()
        {
            clientList.Items.Clear();
            for (int i = 0; i < workerSocketList.Count; i++)
            {
                string clientkey = Convert.ToString(i + 1);
                Socket workerSocket = (Socket)workerSocketList[i];
                if (workerSocket != null)
                {
                    if (workerSocket.Connected)
                    {
                        clientList.Items.Add(clientkey);
                    }
                }
            }
        }
        //添加信息到txtRecvMsg中
        private void OnUpdateRichEdit(string msg)
        {
            txtRecvMsg.Text = txtRecvMsg.Text + msg;
        }
        private void AppendToRichEditControl(string msg)
        {
            if (InvokeRequired)
            {
                object[] pList ={ msg };
                txtRecvMsg.BeginInvoke(new UpdateRichEditCallback(OnUpdateRichEdit), pList);
            }
            else
            {
                OnUpdateRichEdit(msg);
            }
        }
        private void UpdateControls(bool onServer)
        {
            button1.Enabled = !onServer;
            button2.Enabled = onServer;
            if (onServer)
            {
                status.Text = "服务器启动";
            }
            else
            {
                status.Text = "服务器断开";
            }
        }
        //回调函数
        public void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                Socket workerSocket = mainSocket.EndAccept(asyn);//调用EndAccept完成BeginAccept异步调用，返回一个新的Socket的处理与客户的通信
                Interlocked.Increment(ref clientNum);//增加客户数目
                workerSocketList.Add(workerSocket);//将workersocket socket加入到ArrayList中              
                
                string msg1 = "客户" + clientNum + "连接上服务器\n";
                AppendToRichEditControl(msg1);//客户登陆信息
                //*********************
                string msg = clientNum.ToString();
                SendWelcomeToClient(msg, clientNum);//发送客户编号信息给该客户
                UpdateClientListControl();
                WaitForData(workerSocket, clientNum);//连接上的客户接收数据
                mainSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);//主Socket返回，继续接收其他的连接请求
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n OnclientConnection:Socket 已经关闭！\n");
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message, "提示");
            }
        }
        private void SendWelcomeToClient(string msg, int clientNumber)
        {
            Byte[] byData = System.Text.Encoding.UTF8.GetBytes(msg);
            Socket workerSocket = (Socket)workerSocketList[clientNumber - 1];
            //将数据发给客户           
            workerSocket.Send(byData); 
           // MessageBox.Show("返回客户参数：" + clientNumber+"  "+msg);
            /*
            Socket workerSocket = (Socket)workerSocketList[clientNumber - 1];
            NetworkStream networkstream = new NetworkStream(workerSocket);
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(networkstream);
            streamWriter.WriteLine(msg);
            streamWriter.Flush();
             */
        }
        private void SendToClient(string msg, int clientNumber)
        {
            Byte[] byData = System.Text.Encoding.UTF8.GetBytes(msg);                    
            Socket workerSocket = (Socket)workerSocketList[clientNumber - 1];
            NetworkStream networkstream = new NetworkStream(workerSocket);
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(networkstream);
            streamWriter.WriteLine(msg);
            streamWriter.Flush();
           
        }
        public class SocketPacket
        {
            public System.Net.Sockets.Socket currentSocket;
            public int clientNumber;
            public byte[] dataBuffer = new byte[1024];//发给服务器的数据

            public SocketPacket(System.Net.Sockets.Socket socket, int clientNumber)
            {
                currentSocket = socket;
                this.clientNumber = clientNumber;
            }
        }
        public void WaitForData(System.Net.Sockets.Socket socket, int clientNumber)
        {
            try
            {
                if (pfnWorkerCallback == null)
                {
                    pfnWorkerCallback = new AsyncCallback(OnDataReceived);
                }
                SocketPacket socketpacket = new SocketPacket(socket, clientNumber);
                socket.BeginReceive(socketpacket.dataBuffer, 0, socketpacket.dataBuffer.Length, SocketFlags.None, pfnWorkerCallback, socketpacket);


            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message, "提示");
            }
        }
        public void OnDataReceived(IAsyncResult asyn)
        {
            SocketPacket socketData = (SocketPacket)asyn.AsyncState;
            try
            {
                int iRx = socketData.currentSocket.EndReceive(asyn);
                char[] chars = new char[iRx + 1];
                System.Text.Decoder decoder = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = decoder.GetChars(socketData.dataBuffer, 0, iRx, chars, 0);
                System.String receivemsg = new System.String(chars);
                String substr;
                substr = "";
                if (receivemsg.Length > 4)
                {
                    substr = receivemsg.Substring(0, 4);
                }
                if (substr == "####")//聊天信息
                {
                    MessageBox.Show("sfdsdfdf");
                    String tmp1 = "";
                    tmp1 = receivemsg.Substring(4);
                    string[] s = tmp1.Split(new Char[] { ',' });
                    string clientmsg = "客户" + socketData.clientNumber + " " + s[0] + "说：" + s[1];
                    AppendToRichEditControl(clientmsg);
                }
                if (substr == "%%%%")//退出信息
                {
                    String tmp1 = "";
                    tmp1 = receivemsg.Substring(4);
                    SqlConnection conn = new SqlConnection(@"server=HK-PC\SQLEXPRESS;Integrated Security=SSPI;database=Login_user");//"server=localhost;uid=sa;pwd=123;database=Login_user");
                    conn.Open();
                    string ke_name = tmp1.ToString().Substring(0,tmp1.ToString().Length-3)  ;//tmp1.ToString()含回车换行\r\n\0符需去掉
                    string updata11 = "update userinfo set userinserver=0,userhouseid=0 where username='" + ke_name + "'";
                    
                    SqlCommand comm11 = new SqlCommand(updata11, conn);
                    comm11.ExecuteNonQuery();
                    conn.Close();
                    string outmsg = "客户" + socketData.clientNumber + "已经断开连接！\n";
                    AppendToRichEditControl(outmsg);
                    workerSocketList[socketData.clientNumber - 1] = null;
                    UpdateClientListControl();
                    // disconnect();

                }
                if (substr == ")()(")//房间信息
                {
                    String tmp1 = "";
                    tmp1 = receivemsg.Substring(4);
                    string[] s = tmp1.Split(new Char[] { ',' });
                    all_table = all_table + "," + s[0] + "," + s[1] + "," + s[2] + "," + Convert.ToInt16(s[3]).ToString();
                     //********************向所有用户的客户端大厅发送座位信息
                    for (int i = 1; i <= clientNum; i++)
                    {
                        SendToClient(")()(" + all_table, i);
                    }
                    SqlConnection conn = new SqlConnection(@"server=HK-PC\SQLEXPRESS;Integrated Security=SSPI;database=Login_user");                                     
                    //SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123;database=Login_user");
                    conn.Open(); 
                    string house_id = Convert.ToInt16(s[1]).ToString();//用户选择的房间号
                    string updatehouseid = "update userinfo set userhouseid=" + house_id + " where username='" + s[0].ToString() + "'";
                    SqlCommand comm11 = new SqlCommand(updatehouseid, conn);
                    comm11.ExecuteNonQuery();


                    //*******************判断一个房间同桌是否已经两人
                    string selectstr = "select * from userinfo where userhouseid=" + house_id;
                    SqlCommand da = new SqlCommand(selectstr, conn);                    
                    SqlDataReader myread = da.ExecuteReader();
                    int n = 0;
                    String [ ,]a=new String[2,2] ;
                    int online=0;
                    while (myread.Read())
                    {
                        online = Convert.ToInt32(myread.GetValue(5).ToString());//在线
                        if (online == 1)
                        {
                            a[n,0] = myread.GetValue(4).ToString();//IP
                            a[n,1] = myread.GetValue(2).ToString();//客户号
                            n++;
                        }
                    }
                    if (n == 2)
                    {
                        SendToClient("!!!!" + a[0,0], Convert.ToInt16(a[1,1]));//向一个房间的用户发对方IP
                        SendToClient("!!!!" + a[1, 0], Convert.ToInt16(a[0, 1]));//向一个房间的用户发对方IP
                    }
                    //******************** 
                    conn.Close(); 

                }
                if (substr == "@@@@")//注册信息
                {
                    String tmp1 = "";
                    tmp1 = receivemsg.Substring(4);
                    string[] s = tmp1.Split(new Char[] { ',' });
                    String strsql;
                    strsql = "insert into userinfo (username,userpwd,useremail,userpicture) values ('" + s[0].ToString() + "','" + s[1].ToString() + "','" + s[2].ToString() + "','" + s[3].ToString() + "')";
                    string us = null;
                    us = s[0];
                    string selectstr = "select * from userinfo where username='" + us.ToString() + "' ";
                    SqlConnection conn = new SqlConnection(@"server=HK-PC\SQLEXPRESS;Integrated Security=SSPI;database=Login_user");//"server=localhost;uid=sa;pwd=123;database=Login_user");
                    conn.Open();
                    SqlCommand da = new SqlCommand(selectstr, conn);
                    SqlDataReader myread = da.ExecuteReader();
                    if (myread.Read())
                    {
                        MessageBox.Show(s[0] + "　帐号已经被注册");
                    }
                    else
                    {
                        try
                        {
                            myread.Close();
                            SqlCommand updatauser = new SqlCommand(strsql, conn);
                            updatauser.ExecuteNonQuery();
                            // MessageBox.Show("成功" + "4@" + us.ToString()+ "。");
                            string clientmsg3 = "@@@@" + us.ToString();
                            SendToClient(clientmsg3, clientNum);

                        }
                        catch
                        {
                            // MessageBox.Show("帐号创建失败");
                            string clientmsg0 = "@@";
                           SendToClient(clientmsg0, clientNum);
                        }
                    }
                    conn.Close();

                }
                if (substr == "****")//验证信息
                //****用户名，密码，本机IP，客户编号
                {
                    String tmp1 = "";
                    tmp1 = receivemsg.Substring(4);
                    string[] s = tmp1.Split(new Char[] { ',' });

                    String strsql;
                    strsql = "select * from userinfo where username='" + s[0].ToString() + "' and userpwd= '" + s[1].ToString() + "' ";
                    //string str = @"server=HK-PC\SQLEXPRESS;Integrated Security=SSPI;database=stumanage";
                    SqlConnection conn = new SqlConnection(@"server=HK-PC\SQLEXPRESS;Integrated Security=SSPI;database=Login_user");//"server=localhost;uid=sa;pwd=123;database=Login_user");
                    conn.Open();
                    SqlCommand da = new SqlCommand(strsql, conn);
                    SqlDataReader myread = da.ExecuteReader();
                    if(myread.Read())
                    {
                        // MessageBox.Show(s[0] + "　帐号通过");                            
                        username = myread.GetString(0);
                        userpicture = Convert.ToInt32(myread.GetValue(3).ToString());
                        myread.Close();
                        string updata11 = "update userinfo set userinip= '" + s[2].ToString() + "', id=" + s[3].ToString() + ",  userinserver='1' where username='" + s[0].ToString() + "'";
                        SqlCommand comm11 = new SqlCommand(updata11, conn);
                        comm11.ExecuteNonQuery();
                        clientmsg = "****" + username + "," + userpicture;                                          

                    }
                    else
                    {
                        clientmsg = "**";              
                    }
                    SendToClient(clientmsg, clientNum);
                    //*********向该用户的客户端大厅发送座位信息
                    SendToClient(")()(" + all_table, clientNum);
                    //******
                    clientmsg = "";
                    conn.Close();
                }
                
                //System.String szData = new System.String(chars);
                //string msg = "客户" + socketData.clientNumber + "发的信息" + szData;
                //AppendToRichEditControl(msg);
                WaitForData(socketData.currentSocket, socketData.clientNumber);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived:Socket 已经关闭\n");
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10054)
                {
                    string msg = "客户" + socketData.clientNumber + "已经断开连接！\n";
                    AppendToRichEditControl(msg);
                    workerSocketList[socketData.clientNumber - 1] = null;
                    UpdateClientListControl();
                }
                else
                {
                    MessageBox.Show(se.Message, "提示");
                }
            }
        }
    }
}