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

namespace liu_yan_book
{
	/// <summary>
	/// View 的摘要说明。
	/// </summary>
	public class View : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.DataGrid Dg1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Repeater Repeater1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//包含所有数据的XML文件的路径 
			string datafile = "guest.xml" ; 
			//运用一个Try-Catch块完成信息读取功能 
			try 
			{ 

				DataSet da1=new DataSet ();
				da1.ReadXml (Server.MapPath (datafile));
				//将第一个表中的数据集付给Repeater 
				Repeater1.DataSource = da1.Tables[0].DefaultView; 
				Repeater1.DataBind(); 

			} 
			catch (Exception edd) 
			{ 
				//捕捉异常 
				Label1.Text="不能从XML文件读入数据，原因："+edd.ToString() ; 
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
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		private void Button2_Click(object sender, System.EventArgs e)
		{
			//包含所有数据的XML文件的路径 
			string datafile = "guest.xml" ; 
			DataSet da1=new DataSet ();
			da1.ReadXml (Server.MapPath (datafile));
			Dg1.DataSource=da1.Tables[0].DefaultView;
			Dg1.DataBind() ;
		}
	}
}
