//【例1-12】从Box类派生ColorBox类。
using System;
namespace  P1_12
{
	public  class  Box   //父类
	{
		private int width,height;
		public void SetWidth(int w)
		{
			width=w;
		}
		public void SetHeight(int h)
		{
			height=h;
		}
		public void print( )
		{
		 Console.WriteLine("Box Width: {0}, Height{1}", width,height);
		}
	}
	public  class ColorBox: Box //子类ColorBox
	{
		private int color;
		public void SetColor(int c)
		{
			color=c;
		}
		public void c_print( )
		{
			Console.WriteLine("ColorBox color: {0}", color);
		}
	}
	public  class  Test
	{
		public static void Main() 
		{
			Box e1 = new Box ();
			e1.SetWidth(20);
			e1.SetHeight(30);
			e1.print();
			ColorBox e2 = new ColorBox ();
			e2. SetWidth(25);
			e2.SetHeight(35);
			e2.SetColor(1);
			e2.print();
			e2.c_print();
			Console.ReadLine();
		}
	}
}
