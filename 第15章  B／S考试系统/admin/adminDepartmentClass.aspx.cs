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
	/// adminxibubanji 的摘要说明。
	/// </summary>
	public class adminxibubanji : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_Title;
		protected System.Web.UI.WebControls.TextBox TXTxbmc;
		protected System.Web.UI.WebControls.DataGrid Dg_xb;
		protected System.Web.UI.WebControls.Panel Panel_xb;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.DataGrid Dg_bj;
		protected System.Web.UI.WebControls.Panel Panel_bj;
		protected System.Web.UI.WebControls.Button BtnSaveBj;
		protected System.Web.UI.WebControls.TextBox TXTbjmc;
		protected System.Web.UI.WebControls.Button BtnClose;
		protected System.Web.UI.WebControls.Button BtnSave;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if (!IsPostBack)
			{
				MyMethods mm=new MyMethods();
				if(Session["Teacher_ID"]==null)
				{
					mm.AlertAndRedirect("您尚未登录！", "/test/login.aspx");
					return;
				}
				 lbl_Title.Text="系部班级管理";
				BtnSave.Attributes.Add("OnClick", "JavaScript:return confirm('您真要保存吗？')");
				BtnSaveBj.Attributes.Add("OnClick", "JavaScript:return confirm('您真要保存吗？')");
				mm.DG_bind(Dg_xb,"select * from 系部","","",Application["connstr"].ToString());
	         
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
			this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
			this.Dg_xb.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.Dg_xb.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.PageIndexChanged);
			this.Dg_xb.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.ItemDataBound);
			this.BtnSaveBj.Click += new System.EventHandler(this.BtnSaveBj_Click);
			this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
			this.Dg_bj.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.Dg_bj.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.PageIndexChanged);
			this.Dg_bj.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		private void BtnSave_Click(object sender, System.EventArgs e)
		{
			if(TXTxbmc.Text=="")
			{
				Response.Write("<script>alert('系部名称不能为空!')</script>");
				return;
			}
			MyMethods mm=new MyMethods();
			string strid = mm.DateId();
			string sql = "insert into 系部 values ('" + strid + "','" + TXTxbmc.Text + "')";
			new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
            TXTxbmc.Text="";
			mm.DG_bind(Dg_xb,"select * from 系部","","",Application["connstr"].ToString());
			Response.Write("<script>alert('添加成功!')</script>");
		}
		private void ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
		    DataGrid curr_dg=(DataGrid)source;
			MyMethods mm=new MyMethods();
			if (curr_dg.ID=="Dg_xb")
			{
				if (e.CommandName=="Select")
				{
					Panel_bj.Visible =true;
					string strsql="select * from 班级 where 系部编号='"+Convert.ToString(Dg_xb.DataKeys[e.Item.ItemIndex])+"'";
					mm.DG_bind(Dg_bj,strsql,"","",Application["connstr"].ToString());
				}
				else
				{
					if (e.CommandName=="Edit")
					{
						Dg_xb.EditItemIndex=e.Item.ItemIndex;
						Panel_bj.Visible =false;
					}
					if (e.CommandName=="Update")
					{
						TextBox tb1;
						tb1=(TextBox)e.Item.Cells[0].Controls[0];
						if(tb1.Text=="")
						{
							Response.Write("<script>alert('章节名称不能为空!')</script>");
							return;
						}
					
						string sql = "update 系部 set 系部名称='" + tb1.Text + "' where 系部编号='" + Dg_xb.DataKeys[e.Item.ItemIndex] + "'";
						new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
						Dg_xb.EditItemIndex=-1;
						Panel_bj.Visible =false;
					}

					if (e.CommandName == "Delete") 
					{
				
						string sql="select * from 班级 where 系部编号='"+Dg_xb.DataKeys[e.Item.ItemIndex] + "'";
						MyData md=new MyData(Application["connstr"].ToString());
						OleDbDataReader dr=md.eSelect(sql);
						if(dr.Read())
						{
							dr.Close();
							md.CloseConn();
							Response.Write("<script>alert('由于该系部下有班级信息,必须删除其所有下属班级信息,才允许删除系部信息!')</script>");
						}
						else
						{
							dr.Close();
							md.CloseConn();
							sql = "delete from 系部 where 系部编号='" + Dg_xb.DataKeys[e.Item.ItemIndex] + "'";
							new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
							Panel_bj.Visible =false;
						}
					}
					if(e.CommandName=="Cancel")
					{
						Dg_xb.EditItemIndex=-1;
						Panel_bj.Visible=false;
					}
					mm.DG_bind(Dg_xb,"select * from 系部","","",Application["connstr"].ToString());
				}
			}
			else
			{
				if (e.CommandName=="Edit")
				{
					Dg_bj.EditItemIndex=e.Item.ItemIndex;			
				}
				if (e.CommandName=="Update")
				{
					TextBox tb1,tb2;
					tb1=(TextBox)e.Item.Cells[0].Controls[0];
					tb2=(TextBox)e.Item.Cells[1].Controls[0];
					string msg="";
					if(tb1.Text=="")
					{
						msg+="班级名称不能为空!";
						return;
					}
					if (tb2.Text!="")
					{
						try   
						{   
							Convert.ToDateTime(tb2.Text);   
						}   
						catch(Exception)   
						{   
						
							msg+="输入的允许考试日期不是正确的日期类型正确写法如:2007-2-9!";  
							return;
						}   

					}
					if(msg!="")
					{
						Response.Write("<script>alert('"+msg+"')</script>");
				        return;
					}
					string sql;
					if(tb2.Text=="")
					{
						sql = "update 班级 set 班级名称='" + tb1.Text + "' where id='" + Dg_bj.DataKeys[e.Item.ItemIndex] + "'";
					}
					else
					{
						sql = "update 班级 set 班级名称='" + tb1.Text + "',允许考试日期=#"+tb2.Text+"# where id='" + Dg_bj.DataKeys[e.Item.ItemIndex] + "'";

					}
					new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
					Dg_bj.EditItemIndex=-1;
				}

				if (e.CommandName == "Delete") 
				{				
					MyData md=new MyData(Application["connstr"].ToString());
					OleDbDataReader dr=md.eSelect("select * from 学生 where 班级编号='"+Dg_bj.DataKeys[e.Item.ItemIndex] + "'");
					if(dr.Read())
					{
						dr.Close();
						Response.Write("<script>alert('由于该班级下有学生信息,必须删除其所有下属学生信息,才允许删除班级信息!')</script>");
					}
					else
					{
						dr.Close();
						md.CloseConn();
						new MyData(Application["connstr"].ToString()).eInsertUpdateDelete("delete from 班级 where id='" + Dg_bj.DataKeys[e.Item.ItemIndex] + "'");
					}
				}
				if(e.CommandName=="Cancel")
				{
					Dg_bj.EditItemIndex=-1;		
				}
				string strsql="select * from 班级 where 系部编号='"+Convert.ToString(Dg_xb.DataKeys[Dg_xb.SelectedIndex])+"'";
				mm.DG_bind(Dg_bj,strsql,"","",Application["connstr"].ToString());
			}

		}

		private void BtnSaveBj_Click(object sender, System.EventArgs e)
		{
			if(TXTbjmc.Text=="")
			{
				Response.Write("<script>alert('班级名称不能为空!')</script>");
				return;
			}
			MyMethods mm=new MyMethods();
			string strid = mm.DateId();
			string sql = "insert into 班级(id,班级名称,系部编号) values ('" + strid + "','" + TXTbjmc.Text + "','"+Dg_xb.DataKeys[Dg_xb.SelectedIndex]+"')";
			new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
			TXTbjmc.Text="";
			string strsql="select * from 班级 where 系部编号='"+Convert.ToString(Dg_xb.DataKeys[Dg_xb.SelectedIndex])+"'";
			mm.DG_bind(Dg_bj,strsql,"","",Application["connstr"].ToString());
			Response.Write("<script>alert('添加成功!')</script>");
		}

		private void BtnClose_Click(object sender, System.EventArgs e)
		{
			Panel_bj.Visible=false;
		}

		private void ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			LinkButton lbtn;
			DataGrid curr_dg=(DataGrid)sender;
			int update_col_num;
			if(curr_dg.ID=="Dg_xb")
				update_col_num=1;
			else
				update_col_num=2;
			if (e.Item.Cells[update_col_num].Text != "&nbsp;")
			{
				lbtn = (LinkButton)e.Item.Cells[update_col_num].Controls[0];
				if (lbtn!=null) 
					if (lbtn.Text=="更新")
						lbtn.Attributes.Add("OnClick", "JavaScript:return confirm('您真要更新吗？')");
            
			}
			if (e.Item.Cells[update_col_num+1].Text != "&nbsp;")
			{
				lbtn = (LinkButton)e.Item.Cells[update_col_num+1].Controls[0];
				if (lbtn!=null) 
					lbtn.Attributes.Add("OnClick", "JavaScript:return confirm('您真要删除吗？')");
            
			}
		}

		private void PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid curr_dg=(DataGrid)source;
			curr_dg.CurrentPageIndex=e.NewPageIndex;
			MyMethods mm=new MyMethods();
			if(curr_dg.ID=="Dg_xb")
			{
				mm.DG_bind(Dg_xb,"select * from 系部","","",Application["connstr"].ToString());
			}
			else
			{
				string strsql="select * from 班级 where 系部编号='"+Convert.ToString(Dg_xb.DataKeys[Dg_xb.SelectedIndex])+"'";
				mm.DG_bind(Dg_bj,strsql,"","",Application["connstr"].ToString());
					
			}
		}
		
	}
}
