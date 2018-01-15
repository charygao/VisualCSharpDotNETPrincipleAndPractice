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
using System.Xml ;//add
namespace 例10_1
{
	/// <summary>
	/// WebForm1 的摘要说明。
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			XmlDocument xmldoc ;
			XmlNode xmlnode ;
			XmlElement xmlelem, xmlelem2 ;
			XmlText xmltext ;
			xmldoc = new XmlDocument ( ) ;
			//加入XML的声明段落
			xmlnode = xmldoc.CreateNode ( XmlNodeType.XmlDeclaration , "" , "" ) ;
			xmldoc.AppendChild ( xmlnode ) ;
			//加入一个根元素book
			xmlelem = xmldoc.CreateElement ( "" , "book" , "" ) ;
			xmltext = xmldoc.CreateTextNode ( "计算机图书" ) ;
			xmlelem.AppendChild ( xmltext ) ;
			xmldoc.AppendChild ( xmlelem ) ;
			//根元素book下加入另外一个元素title
			xmlelem2 = xmldoc.CreateElement ("title" ) ;
			xmltext = xmldoc.CreateTextNode ( "XML入门精解" ) ;
			xmlelem2.AppendChild ( xmltext ) ;
			xmldoc.ChildNodes.Item(1).AppendChild ( xmlelem2 ) ;
			//根元素book下加入另外一个元素author
			xmlelem2 = xmldoc.CreateElement ("author" ) ;
			xmltext = xmldoc.CreateTextNode ( "张华" ) ;
			xmlelem2.AppendChild ( xmltext ) ;
			xmldoc.ChildNodes.Item(1).AppendChild ( xmlelem2 ) ;
			//author下加入另外一个元素birthday
			xmlelem2 = xmldoc.CreateElement ("birthday" ) ;		
			xmltext = xmldoc.CreateTextNode ( "1971-3-24 ") ;
			xmlelem2.AppendChild ( xmltext ) ;
			xmldoc.ChildNodes.Item(1).ChildNodes.Item(2). AppendChild ( xmlelem2 ) ;
			//保存创建好的XML文件
			xmldoc.Save ( Server.MapPath("data.xml" )) ;
			Response.Write("写入成功"); 
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
