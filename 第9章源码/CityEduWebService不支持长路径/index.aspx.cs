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

namespace CityEduWebService
{
	/// <summary>
	/// index 的摘要说明。
	/// </summary>
	public class index : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton ImageButton_UpClass;
		protected System.Web.UI.WebControls.ImageButton ImageButton_dept;
		protected System.Web.UI.WebControls.ImageButton ImageButton_Coop;
		protected System.Web.UI.WebControls.ImageButton ImageButton_admin;
		protected System.Web.UI.HtmlControls.HtmlTable Table_select;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(Session["PageUser"] == null)Response.Redirect("login.aspx");
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
			this.ImageButton_Coop.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton_Coop_Click);
			this.ImageButton_UpClass.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton_UpClass_Click);
			this.ImageButton_admin.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton_admin_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ImageButton_admin_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("login.aspx");
		}

		private void ImageButton_UpClass_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("Sql_link.aspx");		
		}

		private void ImageButton_Coop_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("DtaBaseModifyToSchool.aspx");		
		}
	}
}
