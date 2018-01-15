using System;
using System.Collections.Generic;
using System.Text;
namespace 栈模型的实现
{
    public class Mystack<T>
    {
        private T[] stackarray;
        private int maxSize;
        private int top;             //代表栈顶指示器sp
        public Mystack(int s)
        {
            maxSize = s;
            stackarray = new T[maxSize];
            top = 0;
        }
        public void Push(T data)   //压栈
        {
            if (top == maxSize)
                Console.WriteLine("out of space!");
            stackarray[top++] = data;
        }
        public T Pop()           //出栈
        {
            if (top == 0)
                Console.WriteLine("no data!");
            return stackarray[--top];
        }
        public T GetTop()       //获取栈顶数据
        {
            if (top == 0)
                Console.WriteLine("Stack is empty ");
            return stackarray[top-1];
        }
        public bool Ifemptystack() //栈是否为空
        {
            return (top == 0);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mystack<int> mystack = new Mystack<int>(5);
            mystack.Push(8);
            mystack.Push(6);
            mystack.Push(7);
            mystack.Push(5);
            mystack.Pop();
            Console.WriteLine("Stack Top is {0}", mystack.GetTop());
            Mystack<string> mystack2 = new Mystack<string>(4);
            mystack2.Push("a");
            mystack2.Push("b");
            mystack2.Pop();
            Console.WriteLine("Stack Top is {0}",mystack2.GetTop());
            mystack2.Push("c");
            mystack2.Push("d");
            Console.WriteLine("Stack poped data is {0}", mystack2.Pop());
            Console.ReadLine();
        }
    }
}
//运行结果：
//Stack Top is 7
//Stack Top is a
//Stack poped data is d
