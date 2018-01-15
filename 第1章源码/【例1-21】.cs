//【例1-21】求2006年1月1日到今天已经过了多少天？
using System;
public class Test
{
	public static void Main()
	{
		string[] weekDays={"星期日","星期一","星期二","星期三","星期四","星期五","星期六"};
		DateTime now=DateTime.Now;
		Console.WriteLine("{0:现在是yyyy年M月d日，H点m},{1}",
                          now,weekDays[(int)now.DayOfWeek]);
		DateTime start=new DateTime(2006,1,1);
		TimeSpan times=now-start;
		Console.WriteLine("从2006年1月1日起到现在已经过了{0}天！",
                         times.Days);
		Console.Read();
	}
} 
