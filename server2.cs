using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Net.Sockets;
using System.Net;
namespace server2
{
class Program
{
static void Main(string[] args)
{

//创建一个Socket实例对象
Socket mysocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
IPAddress ip = IPAddress.Parse("127.0.0.1");
IPEndPoint iep = new IPEndPoint(ip, 8000);
mysocket.Bind(iep);//将上述实例必须绑定到用于TCP通信的服务器本地IP地址和端口上
mysocket.Listen(10);//服务器用Listen方法等待客户端连接请求
byte[] buffer = new byte[1024];
while (true)
{//Accept方法处理任何传入的连接请求，并返回可用于与远程主机进行数据通信的Socket
Socket myClient = mysocket.Accept();
myClient.Receive(buffer);
Console.WriteLine("recieve data:{0}",System.Text.Encoding.UTF8.GetString(buffer));
}

}
}
}
