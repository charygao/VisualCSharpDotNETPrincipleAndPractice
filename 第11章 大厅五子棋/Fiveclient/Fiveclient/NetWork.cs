using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading;

namespace Fiveclient
{
    public class NetWork
    {
        #region Fields and Properties

        public string Sta, Infor;
        private Thread _thread;
        private bool _listenerRun = true;

        private TcpListener _tcpl;

        //FiveGame fivegame = new FiveGame();
        public string Ip { private get; set; }

        #endregion

        #region  Constructors

        #endregion

        #region  Methods

        public static string GetMyIP()
        {
            //var name = Dns.GetHostName();
            //var ips = Dns.GetHostByName(name);
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList[2].ToString();//ips.AddressList[0].ToString();
        }

        private string GetHostIP()
        {
            //var name = Dns.GetHostName();
            //var ips = Dns.GetHostByName(name);
            //return ips.AddressList[0].ToString();
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList[2].ToString();//ips.AddressList[0].ToString();
        }

        /// <summary>
        ///     开一个线程监听网络
        /// </summary>
        public void Listen()
        {
            _thread = new Thread(listen);
            _thread.Start();
        }

        public void Send(ref string sta, string infor)
        {
            try
            {
                var msg = infor;
                var tcpc = new TcpClient(Ip, 7100);
                var tcpStream = tcpc.GetStream();
                var reqStreamW = new StreamWriter(tcpStream);
                reqStreamW.Write(msg);
                reqStreamW.Flush();
                tcpStream.Close();
                tcpc.Close();
            }
            catch
            {
                sta = "目标计算机拒绝连接请求！";
            }
        }

        public void Send(string infor)
        {
            var msg = infor;
            var tcpc = new TcpClient(Ip, 7100);
            var tcpStream = tcpc.GetStream();
            var reqStreamW = new StreamWriter(tcpStream);
            reqStreamW.Write(msg);
            reqStreamW.Flush();
            tcpStream.Close();
            tcpc.Close();
        }

        public void Send(string msg, string id)
        {
            var spkmessage = msg;
            var tcpc = new TcpClient(Ip, 7100);
            var tcpStream = tcpc.GetStream();
            var reqStreamW = new StreamWriter(tcpStream);
            reqStreamW.Write("####" + id + "," + spkmessage);
            reqStreamW.Flush();
            tcpStream.Close();
            tcpc.Close();
        }

        public void Send(string id, string userip, string level)
        {
            //string spkmessage = msg;
            var tcpc = new TcpClient(Ip, 7100);
            var tcpStream = tcpc.GetStream();
            var reqStreamW = new StreamWriter(tcpStream);
            reqStreamW.Write(userip + ":%%$$" + id + "," + Convert.ToString(GetMyIP()) + "," + level);
            reqStreamW.Flush();
            tcpStream.Close();
            tcpc.Close();
        }

        /// <summary>
        ///     停止监听
        /// </summary>
        public void StopListen()
        {
            _listenerRun = false;
            _tcpl.Stop();
        }

        private void listen()
        {
            var ip = GetHostIP();
            try
            {
                _tcpl = new TcpListener(IPAddress.Parse(ip), 7100);
                _tcpl.Start();
                Sta = "正在监听...";
                FiveGame.isplaying = true;
                while (_listenerRun)
                {
                    var s = _tcpl.AcceptSocket();
                    var stream = new byte[80];
                    s.Receive(stream);
                    var substr = "";
                    var tmp1 = "";
                    var message = Encoding.UTF8.GetString(stream);
                    Infor = message;
                    if (Infor.Length >= 4)
                    {
                        substr = Infor.Substring(0, 4);
                        tmp1 = Infor.Substring(4);
                    }

                    if (substr == "####")
                    {
                        var ss = tmp1.Split(',');
                        FiveGame.returnid = ss[0];
                        FiveGame.speakmessage = ss[1];
                    }

                    if (substr == "%%$$")
                    {
                        var ss = tmp1.Split(',');
                        FiveGame.returnid = ss[0];
                        FiveGame.reip = ss[1];
                        FiveGame.relevel = ss[2];
                    }
                }
            }
            catch (SecurityException)
            {
                Sta = "防火墙安全错误！";
            }
            catch (Exception ex)
            {
                Sta = "已停止监听！" + ex.Message;
            }
        }

        #endregion
    }
}