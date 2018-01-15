//【例1-11】通过属性访问器访问类的属性。
using System;
namespace  P1_11
{
	public class Button 
	{ 
		private string caption; 
		public string Caption 
		{   
			get 
			{              // get访问器
				return caption; 
			} 
			set 
			{              // set访问器
				caption = value; 
			}
		}
		public static void Main() 
		//有了上面的定义，就可以对Button进行读取和设置它的Caption属性
		{
			Button b = new Button(); 
			b.Caption = "china";       // 设置Caption
			string s = b.Caption;       // 读取Caption
			b.Caption += "people";   // 读取且设置
			Console.ReadLine();
		} 
	}
}
