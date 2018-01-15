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
	/// adminstudent 的摘要说明。
	/// </summary>
	public class adminstudent : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_Title;
	    protected static string search_kind,search_content,sort_field,sort_direction;
		protected System.Web.UI.WebControls.DataGrid Dg_xuesheng;
		protected System.Web.UI.WebControls.TextBox TXTxh;
		protected System.Web.UI.WebControls.DropDownList DDLxb;
		protected System.Web.UI.WebControls.DropDownList DDLbj;
		protected System.Web.UI.WebControls.TextBox TXTmm;
		protected System.Web.UI.WebControls.TextBox TXTmmqr;
		protected System.Web.UI.WebControls.Button BtnSave;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.Button BtnAll;
		protected System.Web.UI.WebControls.Button BtnSearch;
		protected System.Web.UI.WebControls.TextBox TxtSearchContent;
		protected System.Web.UI.WebControls.DropDownList DdlSearchKind;
		protected System.Web.UI.WebControls.TextBox TXTxm;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if (!IsPostBack)
			{
				if(Session["Teacher_ID"]==null)
				{
					new MyMethods().AlertAndRedirect("您尚未登录！", "/test/login.aspx");
					return;
				}
				 lbl_Title.Text="学生管理";
				BtnSave.Attributes.Add("OnClick", "JavaScript:return confirm('您真要保存吗？')");
				search_kind = "";
				search_content = "";
				sort_field="学号";
				sort_direction="ASC";
				fill_xb(DDLxb);
				DG_bind();
			}
			else
			{//如果是此次Page_Load的执行是由于页面回传引起的
				string curr_object=Request.Form["__EVENTTARGET"];//获取发生回传的源对象
				if (curr_object.IndexOf("DDLdgxb")!=-1)
				{//如果发生回传的源控件是系部下拉列表,则获取当前选择的系部,并将该系下的所有班级信息绑定到班级下拉列表中
					 DropDownList ddl=(DropDownList)Dg_xuesheng.Items[Dg_xuesheng.EditItemIndex].Cells[2].FindControl("DDLdgxb");
                     fill_banji((DropDownList)Dg_xuesheng.Items[Dg_xuesheng.EditItemIndex].Cells[3].FindControl("DDLdgbj"),ddl.SelectedValue);
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
			this.TXTxm.TextChanged += new System.EventHandler(this.TXTxm_TextChanged);
			this.Dg_xuesheng.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.Dg_xuesheng.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.PageIndexChanged);
			this.Dg_xuesheng.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.SortCommand);
			this.Dg_xuesheng.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void BtnSave_Click(object sender, System.EventArgs e)
		{
			string msg="";
			if(TXTxm.Text=="")		
				msg+="姓名不能为空!";
			if(TXTxh.Text=="")
				msg+="学号不能为空!";
		    if(DDLbj.SelectedValue=="")
				msg+="班级不能为空!";
			if(TXTmm.Text=="")
				msg+="密码不能为空!";
			if (TXTmm.Text!=TXTmmqr.Text)
			{
				msg+="两次密码输入不一致!";
			}
			if(msg!="")
			{
				Response.Write("<script>alert('"+msg+"')</script>");
				return;
			}
			string strid =new MyMethods().DateId();
			string sql = "insert into 学生(学号,姓名,班级编号,密码) values ('" + TXTxh.Text + "','" +TXTxm.Text + "','"+DDLbj.SelectedValue+"','"+TXTmm.Text+"')";
			if(new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql)==0)
			{
				Response.Write("<script>alert('输入的学号与数据库中某一记录重复,请重输!')</script>");
				return;
			}
			Clear_Input();
			DG_bind();
			Response.Write("<script>alert('添加成功!')</script>");
		}
		private void Clear_Input()
		{
			TXTxm.Text="";
			TXTxh.Text="";
			TXTmm.Text="";
			TXTmmqr.Text="";
		}
		private void fill_xb(DropDownList ddl)
		{
			DropDownList[] ddlArr={ddl};
			new MyMethods().fill_dropdownlist(ddlArr,Application["connstr"].ToString(),"select * from 系部","系部名称","系部编号");
				
		}
		private void fill_banji(DropDownList ddl,string xbbh)
		{	
			string strsql="select * from 班级 where 系部编号='"+xbbh+"'";	
			DropDownList[] ddlArr={ddl};
			new MyMethods().fill_dropdownlist(ddlArr,Application["connstr"].ToString(),strsql,"班级名称","id");
				
		}
		private void DDLxb_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_banji(DDLbj,Convert.ToString(DDLxb.SelectedValue));
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Clear_Input();
		}
		private void DG_bind()
		{	
			string searchCondition="";
			if ((search_kind != "" && search_content != ""))
				searchCondition=search_kind + " like '%" + search_content + "%'";
			string strsql= "select 学生.姓名 as 姓名,学生.学号 as 学号,学生.密码 as 密码,班级.id as 班级编号,班级.班级名称 as 班级名称,系部.系部编号 as 系部编号,系部.系部名称 as 系部名称  from 学生,班级,系部 where 学生.班级编号=班级.id and 班级.系部编号=系部.系部编号";
			new MyMethods().DG_bind(Dg_xuesheng,strsql,searchCondition,sort_field+" "+sort_direction,Application["connstr"].ToString());
			
		}
		private void ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Edit")
			{				
				Dg_xuesheng.EditItemIndex=e.Item.ItemIndex;		   
				DG_bind();
				DropDownList ddl1=(DropDownList)Dg_xuesheng.Items[e.Item.ItemIndex].Cells[2].FindControl("DDLdgxb");	
				fill_xb(ddl1);
				ddl1.SelectedValue=e.Item.Cells[6].Text;//第六列为隐藏列,其内容为当前学生信息的系部编号
				ddl1=(DropDownList)Dg_xuesheng.Items[e.Item.ItemIndex].Cells[3].FindControl("DDLdgbj");
				fill_banji(ddl1,e.Item.Cells[6].Text);
				ddl1.SelectedValue=e.Item.Cells[7].Text;//第七列为隐藏列,其内容为当前学生信息的班级编号
			}
			else
			{
				if (e.CommandName=="Update")
				{
					TextBox tb1,tb2;
					tb1=(TextBox)e.Item.Cells[0].Controls[0];
					tb2=(TextBox)e.Item.Cells[1].Controls[0];
					DropDownList ddl1;
					ddl1=(DropDownList)e.Item.Cells[3].FindControl("DDLdgbj");
					string sql = "update 学生 set 姓名='" + tb1.Text + "',学号='" + tb2.Text + "',班级编号='"+ddl1.SelectedValue+"' where 学号='" + Dg_xuesheng.DataKeys[e.Item.ItemIndex] + "'";
					if(new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql)==0)
					{
						Response.Write("<script>alert('输入的学号与数据库中某一记录重复,请重输!')</script>");
						return;
					}
					Dg_xuesheng.EditItemIndex=-1;
				
				}

				if (e.CommandName == "Delete") 
				{
					string sql= "delete from 学生 where 学号='" + Dg_xuesheng.DataKeys[e.Item.ItemIndex] + "'";
				    new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
				}
				if(e.CommandName=="Cancel")		
					Dg_xuesheng.EditItemIndex=-1;
				DG_bind();
			}
		}

		private void ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			LinkButton lbtn;
			if (e.Item.Cells[4].Text != "&nbsp;")
			{
				lbtn = (LinkButton)e.Item.Cells[4].Controls[0];
				if (lbtn!=null) 
					if (lbtn.Text=="更新")
						lbtn.Attributes.Add("OnClick", "JavaScript:return confirm('您真要更新吗？')");
            
			}
			if (e.Item.Cells[5].Text != "&nbsp;")
			{
				lbtn = (LinkButton)e.Item.Cells[5].Controls[0];
				if (lbtn!=null) 
					lbtn.Attributes.Add("OnClick", "JavaScript:return confirm('您真要删除吗？')");
            
			}
			if (e.Item.ItemType==ListItemType.EditItem)   
			{ //控制EditTemplate显示下各列的宽度  
						 
						WebControl cur=(WebControl)e.Item.Cells[0].Controls[0];   
						cur.Width=60;
						cur=(WebControl)e.Item.Cells[1].Controls[0];   
						cur.Width=90;
						cur=(WebControl)e.Item.Cells[2].FindControl("DDLdgxb");
						cur.Width=70;
						cur=(WebControl)e.Item.Cells[3].FindControl("DDLdgbj");
						cur.Width=70;				
			}   

		
		}
		private void BtnSearch_Click(object sender, System.EventArgs e)
		{
			 Dg_xuesheng.CurrentPageIndex = 0;
			 search_kind=DdlSearchKind.SelectedValue;
			 search_content=TxtSearchContent.Text;
             DG_bind();
		}

		private void BtnAll_Click(object sender, System.EventArgs e)
		{
			Dg_xuesheng.CurrentPageIndex = 0;
			search_kind="";
			search_content="";
			DG_bind();
		}

		private void SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
		
			if(e.SortExpression==sort_field)
			{
				if (sort_direction=="ASC")
					sort_direction="DESC";
				else
					sort_direction="ASC";
			}
			else
			{
				sort_field=e.SortExpression;
				sort_direction="ASC";

			}
			DG_bind();
	          
		}
		private void PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			Dg_xuesheng.CurrentPageIndex=e.NewPageIndex;
			DG_bind();
		}

		private void TXTxm_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
