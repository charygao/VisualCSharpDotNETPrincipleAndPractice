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
using System.Xml;//add 
namespace 例10_2
{
	/// <summary>
	/// WebForm1 的摘要说明。
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//创建一个XmlTextReader实例，来读取XML文件
			XmlTextReader objXMLReader = new XmlTextReader(Server.MapPath("My1.xml"));
			string strNodeResult = "";
			XmlNodeType objNodeType;
			while(objXMLReader.Read())    
			{
				objNodeType = objXMLReader.NodeType;				
				switch(objNodeType)//判断当前读取得节点类型
				{
					case XmlNodeType.XmlDeclaration:
						//读取XML文件头
						strNodeResult += "XML Declaration: <b>" 
							+ objXMLReader.Name 
							+ " " + objXMLReader.Value + "</b><br />";
						break;
					case XmlNodeType.Element:
						//读取元素
						strNodeResult += "Element: <b>" 
							+ objXMLReader.Name + "</b><br />";
						break;
					case XmlNodeType.Text:
						//读取节点文本内容值
						strNodeResult += "&nbsp; - Value: <b>" 
							+ objXMLReader.Value + "</b><br />";
						break;
				}
				//判断该节点是否有属性
				if(objXMLReader.AttributeCount > 0) 
				{
					//用循环判断完所有节点
					while(objXMLReader.MoveToNextAttribute())           
					{
						//取属性和值
						strNodeResult +=  "&nbsp; - Attribute: " + objXMLReader.Name 
							+ "&nbsp; Value: " + objXMLReader.Value	+ "<br />";
					}
				}
				Label1.Text = strNodeResult;
			}
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
