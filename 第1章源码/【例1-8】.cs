//【例1-8】使用参数数组应用程序清单。
using System;
namespace  P1_8
{  
	class Test_params
	{
		static void F(params int[] a) 
		{
			Console.WriteLine ("a contains {0} items:", a.Length);
			for (int i=0;i< a.Length;i++)
			{
				a[i]=a[i]+1; 				
				Console.Write ("a[{0}]={1}  ",i, a[i]); 				
			}
			Console.WriteLine();
		}
		static void Main() 
		{
			int i = 1, j = 2, k = 3;
			int[] v= {5, 6,7,8,9};
			F(v);
			for (int m=0;m< v.Length;m++)
			{Console.Write ("v[{0}]={1}  ",m, v[m]);} 
   		    Console.WriteLine();
			F(i, j, k); //值传递
			Console.Write ("i={0}   j={1}  k={2} ",i, j,k);
			string a1;
			a1=Console.ReadLine();
		}
	}
}
