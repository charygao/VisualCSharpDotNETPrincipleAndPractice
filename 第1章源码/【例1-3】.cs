//【例1-3】类的声明程序清单。
using System;
namespace P1_3
{
    public class employee
    {
        private int No;
        private string name;
        private char sex;
        private string address;
        public employee(int n, string na, char s, string addr)
        {
            No = n; name = na;
            sex = s; address = addr;
        }
        public void disp_employee()
        {
            Console.WriteLine("职工号：{0} 职工姓名：{1}", No, name);
            Console.WriteLine("性别：{0} 住址：{1}", sex, address);
        }
        public static void Main() { Console.ReadLine(); }
    }
}
