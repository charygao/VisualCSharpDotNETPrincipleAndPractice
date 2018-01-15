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
using System.IO;//ADD
namespace 例8_12
{
	/// <summary>
	/// WebForm1 的摘要说明。
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl MARQUEE1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
		  this.MARQUEE1.InnerText=GetString(); 
		}
		private string GetString()
		{
			StreamReader sr=File.OpenText(Server.MapPath("news.txt"));
			string s1,s="";
			while((s1=sr.ReadLine())!=null)
			{
				s+=s1+"\u3000\u3000";//\u3000为全角空格
			}
			sr.Close();
			return s;
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
