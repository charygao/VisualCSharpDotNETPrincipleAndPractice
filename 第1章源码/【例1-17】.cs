//【例1-17】接口示例。
using System;
namespace P1_17{
    interface IMyExample1 
    { 
        int add(int x,int y);
    }
    interface IMyExample2
    {
        string Point { get; set; }
    }
    class mytest : IMyExample1, IMyExample2
    {
        private string mystr;
        public mytest(string s)
        { mystr = s; }
        //实现接口IMyExample1中add(int x,int y)方法
        public int add(int x,int y)
        {
            return x+y;
        }
        //实现接口IMyExample2中Point 属性
        public string Point 
        {
            get{return mystr;}
            set{mystr=value;}
        }
    }
    class TestClass
    {
        static void Main(string[] args)
        {
            mytest a = new mytest("hello");
            Console.WriteLine(a.add(23, 4));
            Console.WriteLine(a.Point);
            Console.ReadLine();
        }
    }   
}
