using System;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FiveServer
{
    public partial class FiveServer : Form
    {
        #region Fields and Properties

        private AsyncCallback _pfnWorkerCallback;
        private string _username;
        private int _userpicture;
        private Socket _mainSocket;
        private string _allTable; //所有房间座位信息
        private int _clientNum; //客户的编号
        private readonly ArrayList _workerSocketList = ArrayList.Synchronized(new ArrayList());
        private static string _clientmsg = "";

        private delegate void UpdateClientListCallback();

        private delegate void UpdateRichEditCallback(string text);

        private class SocketPacket
        {
            #region Fields and Properties

            public readonly int ClientNumber;
            public readonly Socket CurrentSocket;
            public readonly byte[] DataBuffer = new byte[1024]; //发给服务器的数据

            #endregion

            #region  Constructors

            public SocketPacket(Socket socket, int clientNumber)
            {
                CurrentSocket = socket;
                ClientNumber = clientNumber;
            }

            #endregion
        }

        #endregion

        #region  Constructors

        public FiveServer()
        {
            InitializeComponent();
        }

        #endregion

        #region  Methods

        //回调函数
        private void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                var workerSocket = _mainSocket.EndAccept(asyn); //调用EndAccept完成BeginAccept异步调用，返回一个新的Socket的处理与客户的通信
                Interlocked.Increment(ref _clientNum); //增加客户数目
                _workerSocketList.Add(workerSocket); //将workersocket socket加入到ArrayList中              

                var msg1 = "客户" + _clientNum + "连接上服务器\n";
                AppendToRichEditControl(msg1); //客户登陆信息
                //*********************
                var msg = _clientNum.ToString();
                SendWelcomeToClient(msg, _clientNum); //发送客户编号信息给该客户
                UpdateClientListControl();
                WaitForData(workerSocket, _clientNum); //连接上的客户接收数据
                _mainSocket.BeginAccept(OnClientConnect, null); //主Socket返回，继续接收其他的连接请求
            }
            catch (ObjectDisposedException)
            {
                Debugger.Log(0, "1", "\n OnclientConnection:Socket 已经关闭！\n");
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message, @"提示");
            }
        }

        private void OnDataReceived(IAsyncResult asyn)
        {
            var socketData = (SocketPacket) asyn.AsyncState;
            try
            {
                var iRx = socketData.CurrentSocket.EndReceive(asyn);
                var chars = new char[iRx + 1];
                //var decoder = Encoding.UTF8.GetDecoder();
//decoder.GetChars(socketData.DataBuffer, 0, iRx, chars, 0);
                var receivemsg = new string(chars);
                var substr = "";
                if (receivemsg.Length > 4) substr = receivemsg.Substring(0, 4);
                if (substr == "####") //聊天信息
                {
                    MessageBox.Show(@"sfdsdfdf");
                    var tmp1 = receivemsg.Substring(4);
                    var s = tmp1.Split(',');
                    var clientmsg = "客户" + socketData.ClientNumber + " " + s[0] + "说：" + s[1];
                    AppendToRichEditControl(clientmsg);
                }

                if (substr == "%%%%") //退出信息
                {
                    var tmp1 = receivemsg.Substring(4);
                    var conn = new SqlConnection(
                        @"server=(local)\SQLEXPRESS;Integrated Security=SSPI;database=Login_user"); //"server=localhost;uid=sa;pwd=123;database=Login_user");
                    conn.Open();
                    var keName = tmp1.Substring(0, tmp1.Length - 3); //tmp1.ToString()含回车换行\r\n\0符需去掉
                    var updata11 = "update userinfo set userinserver=0,userhouseid=0 where username='" + keName + "'";

                    var comm11 = new SqlCommand(updata11, conn);
                    comm11.ExecuteNonQuery();
                    conn.Close();
                    var outmsg = "客户" + socketData.ClientNumber + "已经断开连接！\n";
                    AppendToRichEditControl(outmsg);
                    _workerSocketList[socketData.ClientNumber - 1] = null;
                    UpdateClientListControl();
                    // disconnect();
                }

                if (substr == ")()(") //房间信息
                {
                    var tmp1 = receivemsg.Substring(4);
                    var s = tmp1.Split(',');
                    _allTable = _allTable + "," + s[0] + "," + s[1] + "," + s[2] + "," + Convert.ToInt16(s[3]);
                    //********************向所有用户的客户端大厅发送座位信息
                    for (var i = 1; i <= _clientNum; i++) SendToClient(")()(" + _allTable, i);
                    var conn = new SqlConnection(
                        @"server=(local)\SQLEXPRESS;Integrated Security=SSPI;database=Login_user");
                    //SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123;database=Login_user");
                    conn.Open();
                    var houseId = Convert.ToInt16(s[1]).ToString(); //用户选择的房间号
                    var updatehouseid = "update userinfo set userhouseid=" + houseId + " where username='" + s[0] +
                                        "'";
                    var comm11 = new SqlCommand(updatehouseid, conn);
                    comm11.ExecuteNonQuery();


                    //*******************判断一个房间同桌是否已经两人
                    var selectstr = "select * from userinfo where userhouseid=" + houseId;
                    var da = new SqlCommand(selectstr, conn);
                    var myread = da.ExecuteReader();
                    var n = 0;
                    var a = new string[2, 2];
                    while (myread.Read())
                    {
                        var online = Convert.ToInt32(myread.GetValue(5).ToString());
                        if (online == 1)
                        {
                            a[n, 0] = myread.GetValue(4).ToString(); //IP
                            a[n, 1] = myread.GetValue(2).ToString(); //客户号
                            n++;
                        }
                    }

                    if (n == 2)
                    {
                        SendToClient("!!!!" + a[0, 0], Convert.ToInt16(a[1, 1])); //向一个房间的用户发对方IP
                        SendToClient("!!!!" + a[1, 0], Convert.ToInt16(a[0, 1])); //向一个房间的用户发对方IP
                    }

                    //******************** 
                    conn.Close();
                }

                if (substr == "@@@@") //注册信息
                {
                    var tmp1 = receivemsg.Substring(4);
                    var s = tmp1.Split(',');
                    var strsql = "insert into userinfo (username,userpwd,useremail,userpicture) values ('" + s[0] + "','" +
                                    s[1] + "','" + s[2] + "','" + s[3] + "')";
                    var us = s[0];
                    var selectstr = "select * from userinfo where username='" + us + "' ";
                    var conn = new SqlConnection(
                        @"server=(local)\SQLEXPRESS;Integrated Security=SSPI;database=Login_user"); //"server=localhost;uid=sa;pwd=123;database=Login_user");
                    conn.Open();
                    var da = new SqlCommand(selectstr, conn);
                    var myread = da.ExecuteReader();
                    if (myread.Read())
                        MessageBox.Show(s[0] + @"　帐号已经被注册");
                    else
                        try
                        {
                            myread.Close();
                            var updatauser = new SqlCommand(strsql, conn);
                            updatauser.ExecuteNonQuery();
                            // MessageBox.Show("成功" + "4@" + us.ToString()+ "。");
                            var clientmsg3 = "@@@@" + us;
                            SendToClient(clientmsg3, _clientNum);
                        }
                        catch
                        {
                            // MessageBox.Show("帐号创建失败");
                            var clientmsg0 = "@@";
                            SendToClient(clientmsg0, _clientNum);
                        }

                    conn.Close();
                }

                if (substr == "****") //验证信息
                    //****用户名，密码，本机IP，客户编号
                {
                    var tmp1 = receivemsg.Substring(4);
                    var s = tmp1.Split(',');

                    var strsql = "select * from userinfo where username='" + s[0] + "' and userpwd= '" + s[1] + "' ";
                    //string str = @"server=HK-PC\SQLEXPRESS;Integrated Security=SSPI;database=stumanage";
                    var conn = new SqlConnection(
                        @"server=(local)\SQLEXPRESS;Integrated Security=SSPI;database=Login_user"); //"server=localhost;uid=sa;pwd=123;database=Login_user");
                    conn.Open();
                    var da = new SqlCommand(strsql, conn);
                    var myread = da.ExecuteReader();
                    if (myread.Read())
                    {
                        // MessageBox.Show(s[0] + "　帐号通过");                            
                        _username = myread.GetString(0);
                        _userpicture = Convert.ToInt32(myread.GetValue(3).ToString());
                        myread.Close();
                        var updata11 = "update userinfo set userinip= '" + s[2] + "', id=" + s[3] +
                                       ",  userinserver='1' where username='" + s[0] + "'";
                        var comm11 = new SqlCommand(updata11, conn);
                        comm11.ExecuteNonQuery();
                        _clientmsg = "****" + _username + "," + _userpicture;
                    }
                    else
                    {
                        _clientmsg = "**";
                    }

                    SendToClient(_clientmsg, _clientNum);
                    //*********向该用户的客户端大厅发送座位信息
                    SendToClient(")()(" + _allTable, _clientNum);
                    //******
                    _clientmsg = "";
                    conn.Close();
                }

                //System.String szData = new System.String(chars);
                //string msg = "客户" + socketData.clientNumber + "发的信息" + szData;
                //AppendToRichEditControl(msg);
                WaitForData(socketData.CurrentSocket, socketData.ClientNumber);
            }
            catch (ObjectDisposedException)
            {
                Debugger.Log(0, "1", "\nOnDataReceived:Socket 已经关闭\n");
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10054)
                {
                    var msg = "客户" + socketData.ClientNumber + "已经断开连接！\n";
                    AppendToRichEditControl(msg);
                    _workerSocketList[socketData.ClientNumber - 1] = null;
                    UpdateClientListControl();
                }
                else
                {
                    MessageBox.Show(se.Message, @"提示");
                }
            }
        }

        private void WaitForData(Socket socket, int clientNumber)
        {
            try
            {
                if (_pfnWorkerCallback == null) _pfnWorkerCallback = OnDataReceived;
                var socketpacket = new SocketPacket(socket, clientNumber);
                socket.BeginReceive(socketpacket.DataBuffer, 0, socketpacket.DataBuffer.Length, SocketFlags.None,
                    _pfnWorkerCallback, socketpacket);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message, @"提示");
            }
        }

        private void AppendToRichEditControl(string msg)
        {
            if (InvokeRequired)
            {
                object[] pList = {msg};
                txtRecvMsg.BeginInvoke(new UpdateRichEditCallback(OnUpdateRichEdit), pList);
            }
            else
            {
                OnUpdateRichEdit(msg);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPort.Text == "")
                {
                    MessageBox.Show(@"请先填写服务器端口！", @"提示");
                    return;
                }

                var port = int.Parse(txtPort.Text);
                _mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var localEp = new IPEndPoint(IPAddress.Any, port);
                _mainSocket.Bind(localEp); //将socket绑定到本地终接点上
                _mainSocket.Listen(5);
                _mainSocket.BeginAccept(OnClientConnect, null); //开始一个异步操作接受客户的连接请求
                UpdateControls(true);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message, @"提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CloseSockets();
            UpdateControls(false);
            UpdateClientListControl(); //更新客户列表
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtRecvMsg.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CloseSockets();
            Close();
        }

        private void button5_Click(object sender, EventArgs e) //发送
        {
            if (clientList.Items.Count != 0)
                try
                {
                    var msg = txtSendMsg.Text;
                    msg = "####" + msg + "\n";
                    var byData = Encoding.UTF8.GetBytes(msg);
                    for (var i = 0; i < _workerSocketList.Count; i++)
                    {
                        var workerSocket = (Socket) _workerSocketList[i];
                        if (workerSocket != null)
                            if (workerSocket.Connected)
                                workerSocket.Send(byData);
                    }
                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.Message, @"提示！");
                }
            else
                MessageBox.Show(@"没有在线客户，不能发送信息", @"提示");
        }

        //关闭socket
        private void CloseSockets()
        {
            _mainSocket?.Close();

            for (var i = 0; i < _workerSocketList.Count; i++)
            {
                var workerSocket = (Socket) _workerSocketList[i];
                workerSocket?.Close();
            }
        }

        private void FiveServer_Load(object sender, EventArgs e)
        {
            try
            {
                txtIP.Text = Dns.GetHostEntry(Dns.GetHostName()).AddressList[2].ToString(); //Dns.Resolve(Dns.GetHostName()).AddressList[0].ToString();
                UpdateControls(false);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"提示");
            }
        }

        //添加信息到txtRecvMsg中
        private void OnUpdateRichEdit(string msg)
        {
            txtRecvMsg.Text = txtRecvMsg.Text + msg;
        }

        private void SendToClient(string msg, int clientNumber)
        {
            var workerSocket = (Socket) _workerSocketList[clientNumber - 1];
            var networkstream = new NetworkStream(workerSocket);
            var streamWriter = new StreamWriter(networkstream);
            streamWriter.WriteLine(msg);
            streamWriter.Flush();
        }

        private void SendWelcomeToClient(string msg, int clientNumber)
        {
            var byData = Encoding.UTF8.GetBytes(msg);
            var workerSocket = (Socket) _workerSocketList[clientNumber - 1];
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

        private void UpdateClientList()
        {
            clientList.Items.Clear();
            for (var i = 0; i < _workerSocketList.Count; i++)
            {
                var clientkey = Convert.ToString(i + 1);
                var workerSocket = (Socket) _workerSocketList[i];
                if (workerSocket != null)
                    if (workerSocket.Connected)
                        clientList.Items.Add(clientkey);
            }
        }

        //更新客户列表
        private void UpdateClientListControl()
        {
            if (InvokeRequired)
                clientList.BeginInvoke(new UpdateClientListCallback(UpdateClientList), null);
            else
                UpdateClientList();
        }

        private void UpdateControls(bool onServer)
        {
            button1.Enabled = !onServer;
            button2.Enabled = onServer;
            status.Text = onServer ? "服务器启动" : "服务器断开";
        }

        #endregion
    }
}