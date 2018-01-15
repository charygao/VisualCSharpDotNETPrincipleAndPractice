//¡¾Àý1¡¿hello word
using System;
namespace ConsoleApplication1
{
    class Class1
    {
        enum week { monday, tuesday, wednesday, thursday, friday, saturday, sunday };
        static void Main()
        {
            week day = week.friday;
            int a = (int)day;
            int b = (int)week.saturday;
            Console.WriteLine("a={0},b={1}", a, b);
            Console.ReadLine();
        }
    }
}
