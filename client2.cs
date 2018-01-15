using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
namespace client2
{
class Program
{
static void Main(string[] args)
{//创建一个Socket类，基于TCP/IP的网络上通信
Socket sock = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
//创建Socket类，通过Socket类的构造方法类实现：
//public Socket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType);
//其中addressFamily参数指定Socket使用的寻址方案，AddressFamily.InterNetwork表示IPv4地址;
//socketType参数指定Socket的类型，SocketType.Stream表明连接是基于流套接字的，SocketType.Dgram表示连接是基于数据报套接字的
//ProtocolType参数指定Socket使用的协议，ProtocolType.Tcp表明连接协议是TCP，而ProtocolType.Udp表明连接协议是UDP
IPAddress remoteAddr = IPAddress.Parse("127.0.0.1");//服务器端IP
EndPoint ep = new IPEndPoint(remoteAddr, 8000);//创建服务器EndPoint实例。
//IPAddress类包含计算机在IP网络上的地址，其中Parse可将IP地址字符串转换为IPAddress实例。
//在Internet中，TCP/IP使用一个网络地址和一个服务端口号来唯一标识设备。网络地址标识网络上的特定设备，端口号标识要连接到的
//该设备上的特定服务。网络地址和服务端口的组合称为终结点，在.NET中用EndPoint类表示，它提供表示网络资源或服务的抽象，用以
//标志网络地址等信息。            
sock.Connect(ep);//连接到服务器,该方法可用在客户端，进行连接后，可以运用套接字的Connected属性来验证连接是否成功
if (sock.Connected) Console.WriteLine("connect succeed!");
//连接成功后，就可以用Send()和Receive()方法进行通信
//public int Send(byte[] buffer, int size, SocketFlags socketFlags);返回一个System.Int32类型的值，表明了已发送数据的大小。
//buffer包含了要发送的数据，size表示要发送数据的大小，
//而socketFlags可以为SocketFlags.None、SocketFlags.DontRoute、SocketFlags.OutOfBand
//重载函数：public int Send(byte[] buffer);public int Send(byte[] buffer, SocketFlags socketFlags);
//public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags);
byte[] mybyte = Encoding.ASCII.GetBytes("hello world!");
sock.Send(mybyte);
//Receive()方法原型,public int Receive(byte[] buffer, int size, SocketFlags socketFlags);
//重载，public int Receive(byte[] buffer);public int Receive(byte[] buffer, SocketFlags socketFlags);
//public int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags);
sock.Shutdown(SocketShutdown.Both);//通信完后，我们就通过ShutDown()方法禁用Socket
//原型如下public void Shutdown(SocketShutdown how);how表示禁用的类型，
//SocketShutdown.Send表示关闭用于发送的套接字，SocketShutdown.Receive关闭接收套接字
sock.Close();//在调用前，必须先调用Shutdown()以确保在Socket关闭之前已发送或接收所有挂起的数据。
Console.ReadKey();//一旦Shutdown()调用完毕，就调用Close()来关闭
}
}
}
