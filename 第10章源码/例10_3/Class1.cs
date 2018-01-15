using System;
using System.Xml;  
namespace WriteXML
{
	class Class1
	{
		[STAThread]
		static void Main( string[] args )
		{
			try
			{
				// 创建XmlTextWriter类的实例对象
				XmlTextWriter textWriter = new XmlTextWriter("sky.xml", null);
				textWriter.Formatting = Formatting.Indented;
				// 开始写过程，调用WriteStartDocument方法
				textWriter.WriteStartDocument();  
				// 写入说明
				textWriter.WriteComment("First Comment XmlTextWriter Sample Example");
				textWriter.WriteComment("sky.xml in root dir");   
				//创建一个节点
				textWriter.WriteStartElement("Administrator");
				textWriter.WriteElementString("Name", "formble");
				textWriter.WriteElementString("site", "w3sky.com");
				textWriter.WriteEndElement();
				// 写文档结束，调用WriteEndDocument方法
				textWriter.WriteEndDocument();
				// 关闭textWriter
				textWriter.Close();
			}
			catch(System.Exception e)
			{
				Console.WriteLine(e.ToString());
			}               
            Console.ReadKey();
		}
	}
}

