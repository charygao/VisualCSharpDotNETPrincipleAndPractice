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
namespace Test.admin
{
	/// <summary>
	/// adminpanjuan 的摘要说明。
	/// </summary>
	public class adminpanjuan : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_Title;
		protected System.Web.UI.WebControls.DropDownList DDLtixing;
		protected System.Web.UI.WebControls.DropDownList DdlSearchKind;
		protected System.Web.UI.WebControls.DropDownList DdlSelectcondition;
		protected System.Web.UI.WebControls.TextBox TxtSearchContent;
		protected System.Web.UI.WebControls.DropDownList DdlConnect;
		protected System.Web.UI.WebControls.Button BtnAdd;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.Button BtnSearch;
		protected System.Web.UI.WebControls.Button BtnAll;
		protected System.Web.UI.WebControls.Label lbl_S_Title;
		protected System.Web.UI.WebControls.ListBox DdlSelected;
		protected System.Web.UI.WebControls.DataGrid DG_tian;
		protected System.Web.UI.WebControls.Panel Panel_dan;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.Panel Panel3;
		protected System.Web.UI.WebControls.DataGrid DG_jian;
		protected System.Web.UI.WebControls.DataGrid DG_bian;
		protected System.Web.UI.WebControls.Button btn_Complete;
		protected System.Web.UI.WebControls.Panel Panel4;
	    protected static string ddlselectedtext,ddlselectedvalue,curr_SortField,curr_SortDirection;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!IsPostBack)
			{
			
				if(Session["Teacher_ID"]==null)
				{
					new MyMethods().AlertAndRedirect("您尚未登录！", "/test/login.aspx");
					return;
				}
				lbl_Title.Text="判卷管理";
				ddlselectedvalue="";
				ddlselectedtext="";
				curr_SortField="答卷.学号";
				curr_SortDirection="ASC";
				DG_bind(DDLtixing.SelectedValue,ddlselectedvalue,curr_SortField+" "+curr_SortDirection);
				

			}
		}
		
		private void set_datagrid_visible(bool tian_visible,bool pan_jian_visible,bool bian_visible)
		{
			
			DG_tian.Visible=tian_visible;
			DG_jian.Visible=pan_jian_visible;
			DG_bian.Visible=bian_visible;
		}
		private void DG_bind(string tixing,string SearchCondition,string SortExpression)
		{
			DataGrid curr_dg=(DataGrid)this.FindControl(find_DG(tixing));
			string strsql="SELECT * from (((((答卷 inner join 学生 on 答卷.学号=学生.学号) inner join 班级 on 学生.班级编号=班级.id) inner join 系部 on 班级.系部编号=系部.系部编号) inner join 分值 on 答卷.试卷号=分值.试卷号) inner join "+tixing+" on 答卷.试题编号="+tixing+".id) where 答卷.题型='"+tixing+"'";
		    new MyMethods().DG_bind(curr_dg,strsql,SearchCondition,SortExpression,Application["connstr"].ToString());
		}
		private string find_DG(string tixing)
		{
			string curr_dg_name="";
			switch(tixing)
			{		
				case "填空题":
					curr_dg_name="DG_tian";
					break;
				case "判断题":
				case "简答题":
					curr_dg_name="DG_jian";
					break;
				case "编程题":
					curr_dg_name="DG_bian";
					break;
				
			}
			return curr_dg_name;
		}

		public bool IsNumberic(string oText)
		{
			try
			{
				int var1=Convert.ToInt32 (oText);
				return true;
			}
			catch
			{
				return false;
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
			this.DDLtixing.SelectedIndexChanged += new System.EventHandler(this.DDLtixing_SelectedIndexChanged);
			this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
			this.BtnAll.Click += new System.EventHandler(this.BtnAll_Click);
			this.btn_Complete.Click += new System.EventHandler(this.btn_Complete_Click);
			this.DG_tian.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DG_tian.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.SortCommand);
			this.DG_jian.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DG_bian.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid curr_dg=(DataGrid)source;
			if (e.CommandName=="Edit")
			{						
				curr_dg.EditItemIndex=e.Item.ItemIndex;		   
				DG_bind(DDLtixing.SelectedValue,ddlselectedvalue,curr_SortField+" "+curr_SortDirection);					
			}
			if (e.CommandName=="Update")
			{
				TextBox tb1;
				int col_defen=0;
				switch (curr_dg.ID)
				{
					case "DG_tian":
						col_defen=12;
						break;
					case "DG_jian":
						col_defen=8;
						break;
					case "DG_bian":
						col_defen=8;
						break;
				}
				tb1=(TextBox)e.Item.Cells[col_defen].Controls[0];
				if(!IsNumberic(tb1.Text))
				{
					Response.Write("<script>alert('您输入的不是数字,不能作为分数存储！')</script>");
					return;
				}
				
				if(Convert.ToInt16(tb1.Text)>Convert.ToInt16(e.Item.Cells[col_defen-1].Text))
				{
					Response.Write("<script>alert('您输入的数字已经超过了该题的分值,请重新输入！')</script>");
					return;
				}		
				string sql = "update 答卷 set 得分=" + tb1.Text + " where dati_id=" + curr_dg.DataKeys[e.Item.ItemIndex] + "";
				new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
				curr_dg.EditItemIndex=-1;
				DG_bind(DDLtixing.SelectedValue,ddlselectedvalue,curr_SortField+" "+curr_SortDirection);
			
				
			}
			if(e.CommandName=="Cancel")
			{
				curr_dg.EditItemIndex=-1;   
				DG_bind(DDLtixing.SelectedValue,ddlselectedvalue,curr_SortField+" "+curr_SortDirection);			
			}

		}

		private void DDLtixing_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch(DDLtixing.SelectedItem.Text.ToString())
			{			
				case "填空题":
					set_datagrid_visible(true,false,false);
					break;
				case "简答题":
					set_datagrid_visible(false,true,false);
					break;
				case "编程题":
					set_datagrid_visible(false,false,true);
					break;
			}
			Session["tixing"]=DDLtixing.SelectedValue;
			DG_bind(DDLtixing.SelectedValue,ddlselectedvalue,curr_SortField+" "+curr_SortDirection);		
		}
		private void btn_Complete_Click(object sender, System.EventArgs e)
		{
			new MyData(Application["connstr"].ToString()).eInsertUpdateDelete("delete from 成绩");
			string strsql="insert into 成绩 select 学号,试卷号,sum(得分) as 得分 from 答卷 group by 学号,试卷号";
			new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(strsql);
		
		}

		private void BtnAdd_Click(object sender, System.EventArgs e)
		{
			if (TxtSearchContent.Text == "") 
			{
				Response.Write("<script>alert('请输入关键字！')</script>");
				return;
			}
			if (ddlselectedtext != "") 
			{
				string str=ddlselectedtext;				
				if((str.IndexOf("并且",str.Length-2)==-1)&&(str.IndexOf("或者",str.Length-2)==-1))
				{
					Response.Write("<script>alert('条件错误，请重新选择条件！')</script>");
					return;
				}
			}
			ddlselectedtext = ddlselectedtext + DdlSearchKind.SelectedItem.Text + DdlSelectcondition.SelectedItem.Text + TxtSearchContent.Text + DdlConnect.SelectedItem.Text;
			string strcontent;
			if (DdlSelectcondition.SelectedItem.Value == "like")
				strcontent = "'%" + TxtSearchContent.Text + "%'";
			else
				strcontent = "'" + TxtSearchContent.Text + "'";      
			ddlselectedvalue = ddlselectedvalue + DdlSearchKind.SelectedItem.Value + " " + DdlSelectcondition.SelectedItem.Value + " " + strcontent + " " + DdlConnect.SelectedItem.Value + " ";
			ListItem listitem1=new ListItem();
			listitem1.Text = ddlselectedtext;
			listitem1.Value =ddlselectedvalue;
			DdlSelected.Items.Clear();
			DdlSelected.Items.Add(listitem1);
			DdlConnect.SelectedIndex = 0;
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			ddlselectedtext = "";
			ddlselectedvalue = "";
			DdlSelected.Items.Clear();
		}

		private void BtnSearch_Click(object sender, System.EventArgs e)
		{
			string str=ddlselectedtext;
			if ( str== "")
			{
				Response.Write("<script>alert('请增加条件！')</script>");
				return;
			}
			if ((str.Substring(str.Length-2)=="或者") ||(str.Substring(str.Length-2)=="并且"))
			{
				Response.Write("<script>alert('条件错误，条件不完整！')</script>");
				return;
			}
			DataGrid curr_dg=(DataGrid)this.FindControl(find_DG(DDLtixing.SelectedValue));			
			curr_dg.CurrentPageIndex = 0;
			Session["curr_page"] = "0";
			DG_bind(DDLtixing.SelectedValue,ddlselectedvalue,curr_SortField+" "+curr_SortDirection);		
		}

		private void BtnAll_Click(object sender, System.EventArgs e)
		{
			ddlselectedtext = "";
			ddlselectedvalue = "";
			DdlSelected.Items.Clear();
			DG_bind(DDLtixing.SelectedValue,ddlselectedvalue,curr_SortField+" "+curr_SortDirection);				
		}

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
			DG_bind(DDLtixing.SelectedValue,ddlselectedvalue,curr_SortField+" "+curr_SortDirection);			
		}
	}
}
