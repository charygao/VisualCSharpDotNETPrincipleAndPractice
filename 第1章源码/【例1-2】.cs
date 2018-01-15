//【例1-2】异常处理程序。
using System;
namespace ConsoleApplication2
{
    class Test
    {
        static void F()
        {
            try
            {
                G();
            }
            catch (Exception err)
            {
                Console.WriteLine("方法F中捕获到: " + err.Message);
                throw;  //重新抛出当前正在由 catch 块处理的异常err
            }
        }
        static void G()
        {
            throw new Exception("方法G中抛出的异常。");
        }
        static void Main()
        {
            try
            {
                F();
            }
            catch (Exception err)
            {
                Console.WriteLine("方法Main中捕获到:" + err.Message);
            }
            Console.ReadLine();
        }
    }
}
