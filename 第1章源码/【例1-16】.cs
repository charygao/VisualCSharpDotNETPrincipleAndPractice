//【例1-16】使用C#事件机制实现产生当前时间的例子。
using System;
namespace P1_16{
public class EventClass
{
//首先声明一个委托类型CustomEventHandler
    public delegate void CustomEventHandler(object sender, EventArgs e);
    //用委托类型声明事件CustomEvent
    public event CustomEventHandler CustomEvent;
    public void InvokeEvent() 
    {
        if (CustomEvent != null) //判断事件与事件处理函数是否联系起来
        CustomEvent(this, EventArgs.Empty);//调用事件
    }
}
class TestClass
{
//创建事件处理函数
private static void CustomEvent1(object sender, EventArgs e)
{
    Console.WriteLine("Fire Event1 is{0}",DateTime.Now);
}
private static void CustomEvent2(object sender, EventArgs e)
{
    Console.WriteLine("Fire Event2 is{0}",DateTime.Now);
}
static void Main(string[] args)
{
EventClass my = new EventClass();
// 将事件CustomEvent与事件处理函数CustomEvent1联系起来
my.CustomEvent += new EventClass.CustomEventHandler(CustomEvent1);
my.InvokeEvent();//引发事件
// 将事件CustomEvent与事件处理函数CustomEvent2联系取消
my.CustomEvent -= new EventClass.CustomEventHandler(CustomEvent1);
my.InvokeEvent();//引发事件，不产生任何结果
my.CustomEvent += new EventClass.CustomEventHandler(CustomEvent2);
my.InvokeEvent();//引发事件
Console.ReadLine();
}
}
}
