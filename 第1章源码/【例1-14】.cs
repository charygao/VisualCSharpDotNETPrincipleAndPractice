//【例1-14】通过虚方法实现运行时的多态性。比如我们现在有一个Vehicle的类需要调用Drive方法，不管我们有什么样的车，Bike，Car，Jeep，尽管它们的Drive方式不同，但如果它们传递给我们的Vehicle类实例，通过运行时的多态性，就可以调用它们自己的Drive方法。
using System;
namespace P1_14
{
	public class Vehicle  
	{    
		protected float speed;  	
		public Vehicle(float s)  
		{  
			speed=s; 		
		}
		public Vehicle()  
		{  	
		} 
		public void ShowSpeed()       //定义基类的非虚方法
		{  
			Console.WriteLine("Vehicle speed: {0}  ", speed );
		}  
		public virtual void  Drive()  //定义基类的虚方法
		{
			Console.WriteLine("drive ");
		}  
	}    
	public class Car :Vehicle    
	{    
		public Car(int s)
		{
				speed=s;
		}
		public override void Drive() //定义子类的虚方法 
		{
			Console.WriteLine("car drive by four wheel"); 
		}
		new public void ShowSpeed()  
		{  
			Console.WriteLine("car speed: {0}  ", speed );
		} 

	}    
	class Bike:Vehicle    
	{    
		new public  void Drive()  //定义子类的虚方法 
		{
			Console.WriteLine("car drive by two wheel "); 
		}
	}    
	public  class  TestVirtual
	{
		public static void test(Vehicle c )
		{
			c.Drive();              //调用虚方法
			c. ShowSpeed();        //调用Vehicle类自身的非虚方法
		}
		public static void Main() 
		{
			Vehicle a=new Vehicle(120);  
			Car b=new Car(140);
			test(a);
			test(b);
			string a1=Console.ReadLine();
		}
	}
}
