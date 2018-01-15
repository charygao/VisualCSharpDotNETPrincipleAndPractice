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
using System.Data.OleDb;
namespace Test.kaoshi
{
	/// <summary>
	/// chaxun 的摘要说明。
	/// </summary>
	public class chaxun : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_Title;
		protected System.Web.UI.WebControls.DropDownList DdlSearchKind;
		protected System.Web.UI.WebControls.TextBox TxtSearchContent;
		protected System.Web.UI.WebControls.Button BtnSearch;
		protected System.Web.UI.WebControls.Button BtnAll;
		protected System.Web.UI.WebControls.DataGrid DG_chengji;
		protected System.Web.UI.WebControls.Panel Panel_dan;
		protected static string curr_search,curr_SortField,curr_SortDirection;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!IsPostBack)
			{
				 lbl_Title.Text="查询成绩";
				curr_search="";
				curr_SortField="成绩.学号";
				curr_SortDirection="ASC";
				DG_bind(curr_search,curr_SortField+" "+curr_SortDirection);
			}
		}
		private void DG_bind(string SearchCondition,string SortExpression)
		{
			string  strsql="SELECT * from ((成绩 inner join 学生 on 成绩.学号=学生.学号) inner join 班级 on 学生.班级编号=班级.id) inner join 系部 on 班级.系部编号=系部.系部编号";
			new MyMethods().DG_bind(DG_chengji,strsql,SearchCondition,SortExpression,Application["connstr"].ToString());
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
			this.DdlSearchKind.SelectedIndexChanged += new System.EventHandler(this.DdlSearchKind_SelectedIndexChanged);
			this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
			this.BtnAll.Click += new System.EventHandler(this.BtnAll_Click);
			this.DG_chengji.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.SortCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if(e.SortExpression!=curr_SortField)
			{
				curr_SortField=e.SortExpression;
				curr_SortDirection="ASC";
			}
			else
			{
				if(curr_SortDirection=="ASC")
					curr_SortDirection="DESC";
				else
					curr_SortDirection="ASC";
			}
			DG_bind(curr_search,curr_SortField+" "+curr_SortDirection);
		}

		private void BtnSearch_Click(object sender, System.EventArgs e)
		{
		    curr_search=DdlSearchKind.SelectedValue+" like '%"+TxtSearchContent.Text+"%'"; 
			DG_bind(curr_search,curr_SortField+" "+curr_SortDirection);
		}

		private void BtnAll_Click(object sender, System.EventArgs e)
		{
			curr_search="";
			DG_bind(curr_search,curr_SortField+" "+curr_SortDirection);
		
		}

		private void DdlSearchKind_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		
		}
	}
}
