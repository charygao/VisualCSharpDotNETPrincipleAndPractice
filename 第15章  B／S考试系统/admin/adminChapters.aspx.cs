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
	/// adminzhangjie 的摘要说明。
	/// </summary>
	public class adminzhangjie : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_Title;
		protected System.Web.UI.WebControls.Button BtnSave;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.DropDownList DdlSearchKind;
		protected System.Web.UI.WebControls.TextBox TxtSearchContent;
		protected System.Web.UI.WebControls.Button BtnSearch;
		protected System.Web.UI.WebControls.Button BtnAll;
		protected System.Web.UI.WebControls.TextBox TXTzjmc;
		protected System.Web.UI.WebControls.DataGrid Dg_zhangjie;
		protected System.Web.UI.WebControls.TextBox TXTsmxx;
	    protected static string search_kind,search_content;
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
				 lbl_Title.Text="章节管理";
				BtnSave.Attributes.Add("OnClick", "JavaScript:return confirm('您真要保存吗？')");
				search_kind = "";
				search_content = "";
				DG_bind();
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
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
			this.BtnAll.Click += new System.EventHandler(this.BtnAll_Click);
			this.Dg_zhangjie.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.Dg_zhangjie.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.PageIndexChanged);
			this.Dg_zhangjie.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void Clear_Input()
		{
			TXTzjmc.Text = "";
			TXTsmxx.Text = "";
			
		}
		private void ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Edit")
			{
				Dg_zhangjie.EditItemIndex=e.Item.ItemIndex;
				
			}
			if (e.CommandName=="Update")
			{
				TextBox tb1,tb2;
				tb1=(TextBox)e.Item.Cells[0].Controls[0];
				tb2=(TextBox)e.Item.Cells[1].Controls[0];
				if(tb1.Text=="")
				{
					Response.Write("<script>alert('章节名称不能为空!')</script>");
					return;
				}		
	            string sql = "update 章节 set 章节名称='" + tb1.Text + "',说明信息='" + tb2.Text + "' where 章节号='" + Dg_zhangjie.DataKeys[e.Item.ItemIndex] + "'";
				new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
				
				Dg_zhangjie.EditItemIndex=-1;  
			}

			if (e.CommandName == "Delete") 
			{
				 OleDbDataReader dr=null;
				int i;
				string table_name="";
				for(i=1;i<=6;i++)
				{
					switch(i)
					{
						case 1:
							table_name="单选题";
							break;
						case 2:
							table_name="多选题";
							break;
						case 3:
							table_name="填空题";
							break;
						case 4:
							table_name="判断题";
							break;
						case 5:
							table_name="简答题";
							break;
				
					}
					MyData md=new MyData(Application["connstr"].ToString());
					dr=md.eSelect("select * from "+table_name+" where 章节号='"+ Dg_zhangjie.DataKeys[e.Item.ItemIndex] + "'");		
					if(dr.Read())
					{
						Response.Write("<script>alert('由于题库中已有该章节下的题目,必须删除题库中该章节下的所有题目,才允许删除章节信息!')</script>");
						dr.Close();
						return;
					}
					else
					{
						dr.Close();
					}
				}
					
				
				if (i==7)
				{
					dr.Close();
					MyData md=new MyData(Application["connstr"].ToString());
					md.eInsertUpdateDelete("delete from 章节 where 章节号='" + Dg_zhangjie.DataKeys[e.Item.ItemIndex] + "'");
				}
			}
			if(e.CommandName=="Cancel")
			{
				Dg_zhangjie.EditItemIndex=-1;  
			}
			DG_bind();
	         
		}

		private void ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			LinkButton lbtn;
			if (e.Item.Cells[2].Text != "&nbsp;")
			{
				lbtn = (LinkButton)e.Item.Cells[2].Controls[0];
				if (lbtn!=null) 
				   if (lbtn.Text=="更新")
					lbtn.Attributes.Add("OnClick", "JavaScript:return confirm('您真要更新吗？')");
            
			}
			if (e.Item.Cells[3].Text != "&nbsp;")
			{
				lbtn = (LinkButton)e.Item.Cells[3].Controls[0];
				if (lbtn!=null) 
					lbtn.Attributes.Add("OnClick", "JavaScript:return confirm('您真要删除吗？')");
            
			}
		}

		private void BtnSave_Click(object sender, System.EventArgs e)
		{
			if(TXTzjmc.Text=="")
			{
				Response.Write("<script>alert('章节名称不能为空!')</script>");
				return;
			}	
			string strid=new MyMethods().DateId();
			string sql = "insert into 章节 values ('" + strid + "','" + TXTzjmc.Text + "','" +TXTsmxx.Text + "')";
			MyData md=new MyData(Application["connstr"].ToString());
		    md.eInsertUpdateDelete(sql);	
			Clear_Input();
			DG_bind();
	         
			Response.Write("<script>alert('添加成功!')</script>");
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Clear_Input();
		}

		private void BtnSearch_Click(object sender, System.EventArgs e)
		{
			search_kind = DdlSearchKind.SelectedValue;
			search_content = TxtSearchContent.Text;
			DG_bind();
		}

		private void BtnAll_Click(object sender, System.EventArgs e)
		{
			search_kind = "";
			search_content= "";
			TxtSearchContent.Text = "";
			DG_bind();
		
		}

		private void PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			Dg_zhangjie.CurrentPageIndex = e.NewPageIndex;
			DG_bind();
	         
		}
		private void DG_bind()
		{	
			string searchCondition="";
			if ((search_kind != "" && search_content != ""))
				searchCondition=search_kind + " like '%" + search_content + "%'";
				new MyMethods().DG_bind(Dg_zhangjie,"select * from 章节",searchCondition,"",Application["connstr"].ToString());
			
		}
	}
}
