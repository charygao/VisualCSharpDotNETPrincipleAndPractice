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
using System.IO;
using System.Text;

namespace CityEduWebService
{
	/// <summary>
	/// DtaBaseModifyToSchool 的摘要说明。
	/// </summary>
	public class DtaBaseModifyToSchool : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox TextBox_MessageUpdateDB;
		protected System.Web.UI.WebControls.Label Label;
	
		private string[] ArraytSql=new String[1111];
		protected System.Web.UI.WebControls.Label lbl_Error;
		protected config conn=new config();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面

			//未登录不允许修改
			if(Session["PageUser"] == null)Response.Redirect("login.aspx");

			if (!Page.IsPostBack)
			{//显示修改数据库.sql文件内容
				StreamReader sr = new StreamReader(Server.MapPath(".")+"\\修改数据库.sql",Encoding.GetEncoding("gb2312"));
				try
				{
					TextBox_MessageUpdateDB.Text=sr.ReadToEnd();
				}
				catch
				{
					conn.JsIsNull("修改数据库.sql文件打开出错！",lbl_Error);
				}
				try
				{
					sr.Close();
				}
				catch
				{//对话框
				}
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			//写回修改数据库.sql文件
			WriteToFile();
		}
		
		//写回修改数据库.sql文件
		private void WriteToFile()
		{
			//HttpContext.Current.Request.MapPath(".");
			StreamWriter sw=new StreamWriter(Server.MapPath(".")+"\\修改数据库.sql",false,Encoding.GetEncoding("gb2312"));
			
			try
			{
				sw.Write(TextBox_MessageUpdateDB.Text);
			}
			catch
			{
				conn.JsIsNull("修改数据库.sql文件写入出错！",lbl_Error);//对话框
			}
			try
			{
				sw.Close();
			}
			catch
			{
				conn.JsIsNull("修改数据库.sql文件关闭出错！",lbl_Error);//对话框
			}
			//对话框
			Button1.Enabled=false;
		}
	}
}
