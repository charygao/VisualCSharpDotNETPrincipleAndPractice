//【例1-7】输出参数应用程序清单。
using System;
namespace  P1_7{  
class Test
{
	 static void SplitPath(string path, out string dir, out string name) 
{
		int i = path.Length;
		while (i > 0) {
			char ch = path[i-1];
			if (ch == '\\') break;
			i--;
		}
		dir = path.Substring(0, i);
		name = path.Substring(i);
	}
	static void Main() {
		string dir, name;
		SplitPath("c:\\Windows\\System\\hello.txt", out dir, out name);
		Console.WriteLine(dir);
		Console.WriteLine(name);
		Console.ReadLine();
	}
}
}
