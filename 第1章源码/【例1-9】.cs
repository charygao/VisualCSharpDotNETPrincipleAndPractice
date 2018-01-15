//【例1-9】演示静态方法和非静态方法的规则。
using System;
namespace  P1_9
{
	class Test
	{
		private int x;
		static private int y;
		public void Fn()       // 非静态方法
		{      
			x = 1;			// 相当于 this.x = 1
			y = 1;			// 相当于Test.y = 1
			Console.WriteLine("x = {0}; y={1}" , x , y);
		}
		public static void Gn()   //静态方法
		{ 
			//x = 2;			// Error, 静态方法不能访问非静态成员x
			y = 2;	
			Console.WriteLine(" y={0}" ,  y);
		}
		static void Main() 
		{
			Test t = new Test();
            t.Fn();
			Test.Gn();
			t.x = 2;			// Ok
			//t.y = 1;			// Error, 不能通过实例访问静态成员
			//Test.x = 1;		// Error, 不能通过类名访问实例成员
			Test.y =2;		// Ok
			Console.WriteLine("x = {0}; y={1}" , t.x , Test.y);
			string a1;
			a1=Console.ReadLine();
		}
	}
}
