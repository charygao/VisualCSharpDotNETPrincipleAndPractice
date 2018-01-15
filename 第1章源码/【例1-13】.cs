//【例1-13】演示抽象类。
using System;
namespace P1_13
{
	public abstract class shape  //形状类
	{
		public double area() //公共接口
		{return(0);}
	}
	public class circle:shape  //圆类
	{
		private double a;
		public  circle (double r) 
		{a=r; }
		public new double area() 
		{ return Math.PI*a*a; }
	}
	public class rectangle:shape  //长方形类
	{
		private double a,b,c;
		public  rectangle (double a1,double b1,double c1) 
		{a=a1;b=b1;c=c1; }
		public new double area() 
		{ return a*b*c; }
	}
	public class Test_abstract
	{
		public static void Main()
		{
			circle c1=new circle(5);
			rectangle r2=new rectangle (2,3,4);
			Console.WriteLine("circle area= {0}" , c1. area ());
			Console.WriteLine("rectangle area= {0}" , r2. area ());
			Console.ReadLine();
		}
	}
}
