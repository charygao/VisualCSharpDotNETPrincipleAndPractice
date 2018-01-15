using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml ;
namespace 例10_4
{
	/// <summary>
	/// WebForm1 的摘要说明。
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button Button1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			Label1.Text=""; //清空标签 
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			XmlDocument xmlDoc=new XmlDocument(); 
			xmlDoc.Load(Server.MapPath("data.xml")); 
			XmlNode root=xmlDoc.SelectSingleNode("Employees");//查找<Employees> 
			XmlElement xe1=xmlDoc.CreateElement("Book");//创建一个<Book>节点 
			XmlElement xesub1=xmlDoc.CreateElement("title"); 
			xesub1.InnerText="C#入门帮助";//设置文本节点 
			xe1.AppendChild(xesub1);//添加到<Book>节点中 
			XmlElement xesub2=xmlDoc.CreateElement("author"); 
			xesub2.InnerText="高手"; 
			xe1.AppendChild(xesub2); 
			XmlElement xesub3=xmlDoc.CreateElement("price"); 
			xesub3.InnerText="158.3"; 
			xe1.AppendChild(xesub3); 
			root.AppendChild(xe1);//添加到<Employees>节点中 
			xmlDoc.Save ( Server.MapPath("data.xml") ); 
			Label1.Text="添加成功";
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			XmlDocument xmlDoc=new XmlDocument(); 
			xmlDoc.Load( Server.MapPath("data.xml") ); 
			//获取Employees节点的所有<Book >子节点
			XmlNodeList nodeList=xmlDoc.SelectSingleNode("Employees").ChildNodes; 
			foreach(XmlNode xn in nodeList)//遍历所有子节点 
			{ 
				XmlElement xe=(XmlElement)xn;//将子节点类型转换为XmlElement类型 
				XmlNodeList nls=xe.ChildNodes;//继续获取xe子节点的所有子节点 
				foreach(XmlNode xn1 in nls)//遍历 
				{ 
					XmlElement xe2=(XmlElement)xn1;//转换类型 
					if(xe2.Name=="author" && xe2.InnerText=="高手")//如果找到 
					{ 
						xe2.InnerText="高严";//则修改 
						Label1.Text="修改成功";
					} 
				} 
			}
			xmlDoc.Save( Server.MapPath("data.xml") );//保存		
		}
		private void Button3_Click(object sender, System.EventArgs e)
		{
			XmlDocument xmlDoc=new XmlDocument(); 
			xmlDoc.Load( Server.MapPath("data.xml") ); 
			XmlNode root=xmlDoc.SelectSingleNode("Employees"); 
			XmlNodeList xnl=xmlDoc.SelectSingleNode("Employees").ChildNodes; 
			for(int i=0;i<xnl.Count;i++) 
			{ 
				XmlElement xe=(XmlElement)xnl.Item(i);
				XmlElement xe1=(XmlElement)xe.ChildNodes[0]; 
				if(xe1.Name=="title" && xe1.InnerText =="C#入门帮助")//如果找到 
				{ 
					root.RemoveChild(xe); 
					if(i<xnl.Count)i=i-1;
					Label1.Text="删除成功";
				} 
			} 
			xmlDoc.Save( Server.MapPath("data.xml") ); 
		}
	}
}
