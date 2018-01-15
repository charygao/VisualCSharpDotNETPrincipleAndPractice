//【例1-6】多个变量使用相同的存储位置程序清单。
using System;
namespace  P1_6
{  
	public class same_ref
	{
		public string s;
		public void F(ref string a, ref string b) 
		{
			
			a = "Two";
			b = "Three";
		}
		static void Main () 
		{
			same_ref c=new same_ref();
			c.F(ref c.s, ref c.s);
			Console.WriteLine("s = {0}", c.s);
			Console.ReadLine();
		}
	}
}
