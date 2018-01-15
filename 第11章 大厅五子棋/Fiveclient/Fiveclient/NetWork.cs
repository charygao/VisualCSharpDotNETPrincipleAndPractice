using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace Fiveclient
{
        public class NetWork
        {
           public NetWork()
		   {
		   }
           public string sta, infor;
           public string speakmsg;
           private string ip;
           public Thread thread;
           System.Net.Sockets.TcpListener tcpl;
           bool listenerRun = true;
           //FiveGame fivegame = new FiveGame();
           public string IP
           {
               get { return ip; }
               set { ip = value; }
           }
           public static string getmyIP()
           {
               String name = Dns.GetHostName();
               IPHostEntry ips = Dns.GetHostByName(name);
               return ips.AddressList[0].ToString();
           }
           public string getHostIP()
           {
               String name = Dns.GetHostName();
               IPHostEntry ips = Dns.GetHostByName(name);
               return ips.AddressList[0].ToString();
           }
           /// <summary>
           /// 开一个线程监听网络
           /// </summary>
           public void Listen()
           {
               thread = new Thread(new ThreadStart(listen));
               thread.Start();
           }
           private void listen()
           {
               string ip = getHostIP();
               try
               {
                   tcpl = new TcpListener(IPAddress.Parse(ip),7100);
                   tcpl.Start();
                   sta = "正在监听...";
                   FiveGame.isplaying = true;
                   while (listenerRun)
                   {
                       Socket s = tcpl.AcceptSocket();
                       Byte[] stream = new Byte[80];
                       int i = s.Receive(stream);
                       String substr = "";
                       String tmp1 = "";
                       string message = System.Text.Encoding.UTF8.GetString(stream);
                       infor = message;
                       if (infor.Length >= 4)
                       {
                           substr = infor.Substring(0, 4);
                           tmp1 = infor.Substring(4);                      
                       }
                       if (substr == "####")
                       {
                           string[] ss = tmp1.Split(new Char[] { ',' });
                           FiveGame.returnid = ss[0].ToString();
                           FiveGame.speakmessage = ss[1].ToString(); ;
                       }
                       if (substr == "%%$$")
                       {
                           string[] ss = tmp1.Split(new Char[] { ',' });
                           FiveGame.returnid = ss[0].ToString();
                           FiveGame.reip = ss[1].ToString();
                           FiveGame.relevel = ss[2].ToString();
                       }
                   }
               }
               catch (System.Security.SecurityException)
               {
                   sta = "防火墙安全错误！";
               }
               catch (Exception ex)
               {
                   sta = "已停止监听！" + ex.Message;
               }

           }
           /// <summary>
           /// 停止监听
           /// </summary>
           public void StopListen()
           {
               listenerRun = false;
               tcpl.Stop();
           }
           public void Send(ref string sta, string infor)
           {
               try
               {
                   string msg = infor;
                   TcpClient tcpc = new TcpClient(ip, 7100);
                   NetworkStream tcpStream = tcpc.GetStream();
                   StreamWriter reqStreamW = new StreamWriter(tcpStream);
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
               string msg = infor;
               TcpClient tcpc = new TcpClient(ip, 7100);
               NetworkStream tcpStream = tcpc.GetStream();
               StreamWriter reqStreamW = new StreamWriter(tcpStream);
               reqStreamW.Write(msg);
               reqStreamW.Flush();
               tcpStream.Close();
               tcpc.Close();

           }
            public void Send(string msg,string id)
            {
                string spkmessage = msg;
                TcpClient tcpc = new TcpClient(ip, 7100);
                NetworkStream tcpStream = tcpc.GetStream();
                StreamWriter reqStreamW = new StreamWriter(tcpStream);
                reqStreamW.Write("####"+id+","+spkmessage);                
                reqStreamW.Flush();
                tcpStream.Close();
                tcpc.Close();

            }
            public void Send(string id ,string userip ,string level)
            {
                //string spkmessage = msg;
                TcpClient tcpc = new TcpClient(ip, 7100);
                NetworkStream tcpStream = tcpc.GetStream();
                StreamWriter reqStreamW = new StreamWriter(tcpStream);
                reqStreamW.Write("%%$$" + id + "," + Convert.ToString(getmyIP())+","+level);
                reqStreamW.Flush();
                tcpStream.Close();
                tcpc.Close();

            }

        }
        
}
