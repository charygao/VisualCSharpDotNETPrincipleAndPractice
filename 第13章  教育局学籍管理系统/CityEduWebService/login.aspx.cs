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
using System.Configuration;

namespace CityEduWebService
{
	/// <summary>
	/// login 的摘要说明。
	/// </summary>
	public class login : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox TextBox_PagePassword;
		protected System.Web.UI.WebControls.TextBox TextBox_PageUser;
	
		protected config conn=new config();

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{	
			//用户名密码正确,创建Session变量，可以访问其他页面
			//str_Sql="Select * FROM Users WHERE UserName= '"+textBox_User.Text+"' AND PassWord='"+textBox_PassWord.Text+"'";
			string str_Sql="Select * FROM Users WHERE UserName= '"+TextBox_PageUser.Text+"' AND PassWord='"+TextBox_PagePassword.Text+"' AND ReadOnly=0";
			if(conn.GetRowCount(str_Sql)==1)
			{
				Session["PageUser"]=TextBox_PageUser.Text;
				Response.Redirect("index.aspx");
			}
			else
				Response.Redirect("noright.aspx");

		}
	}
}
