//【例1-15】实现委托机制的C#例子。
using System;
namespace P1_15
{
    //步骤1： 声明一个委托MyDelegate
    public delegate void MyDelegate(string input);
    //步骤2：定义2个方法，其参数形式和步骤1中声明的委托的参数必须相同
    class MyClass1
    {
        public void delegateMethod1(string input)
        {
            Console.WriteLine("This is delegateMethod1 and the input is {0}", input);
        }
        public void delegateMethod2(string input)
        {
            Console.WriteLine("This is delegateMethod2 and the input is {0}", input);
        }
    }
    //步骤3：创建一个委托对象d3并将上面的方法包含其中
    class MyClass2
    {
        public MyDelegate createDelegate()
        {
            MyClass1 c2 = new MyClass1();
            MyDelegate d1 = new MyDelegate(c2.delegateMethod1);
            MyDelegate d2 = new MyDelegate(c2.delegateMethod2);
            MyDelegate d3 = d1 + d2;
            return d3;
        }
   //步骤4：通过委托对象d调用包含在其中的方法
        public void callDelegate(MyDelegate d, string input)
        {
            d(input);
        }
    }
    class Driver
    {
        static void Main(string[] args)
        {
            MyClass2 c2 = new MyClass2();
            MyDelegate d = c2.createDelegate();
            c2.callDelegate(d, "Calling the delegate");
            Console.ReadLine(); 
        }
    }
}
