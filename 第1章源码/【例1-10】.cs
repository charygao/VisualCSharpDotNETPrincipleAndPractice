//【例1-10】求体积volume方法中使用重载。
using System;
namespace  P1_10
{ 
	public class TestMethod
	{
		public double volume (double x) //立方体体积
		{return  x*x*x; }
		public double volume (double r, double h)  //圆柱体体积
		{ return  Math.PI*r*h; }
		public double volume (double a, double b, double c)  //长方体体积
		{ return  a*b*c; }
		public static void Main()
		{
			TestMethod t1=new  TestMethod();
			Console.WriteLine("cube volume = {0}" , t1. volume (2.5));
			Console.WriteLine("cylinder volume = {0}" , t1. volume (2,4));
			Console.WriteLine("cuboid volume = {0}" , t1. volume (5,3,4));
			Console.ReadLine();
		}
	}
}
