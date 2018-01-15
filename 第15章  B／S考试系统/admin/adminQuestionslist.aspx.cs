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
	/// adminquestionslist 的摘要说明。
	/// </summary>
	public class adminquestionslist : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_Title;
		protected System.Web.UI.WebControls.DropDownList DdlSearchKind;
		protected System.Web.UI.WebControls.DropDownList DdlSelectcondition;
		protected System.Web.UI.WebControls.TextBox TxtSearchContent;
		protected System.Web.UI.WebControls.DropDownList DdlConnect;
		protected System.Web.UI.WebControls.Button BtnAdd;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.Button BtnSearch;
		protected System.Web.UI.WebControls.Button BtnAll;
		protected System.Web.UI.WebControls.Button btn_Add;
		protected System.Web.UI.WebControls.Label lbl_S_Title;
		protected System.Web.UI.WebControls.ListBox DdlSelected;
		protected System.Web.UI.WebControls.DataGrid DG_xuan;
		protected System.Web.UI.WebControls.Panel Panel_dan;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.DataGrid DG_tian;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.Panel Panel3;
		protected System.Web.UI.WebControls.DropDownList DDLtixing;
		protected System.Web.UI.WebControls.DataGrid DG_bian;
		protected System.Web.UI.WebControls.Panel Panel4;
		protected System.Web.UI.WebControls.DataGrid DG_pan_jian;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!IsPostBack)
			{   
				MyMethods mm=new MyMethods();
				if(Session["Teacher_ID"]==null)
				{ //验证教师是否登录
					mm.AlertAndRedirect("您尚未登录！", "/test/login.aspx");
					return;
				}
				if (Session["tixing"]==null)//设置默认显示的题型
					Session["tixing"]="单选题";
				if (Session["curr_page"]==null)
					Session["curr_page"]="0";//记录当前DataGrid的当前页，使的从题库录入页面中编辑后返回该页时仍然能够回到当前页
                if (Session["sort_field"]==null)
				    Session["sort_field"]="题干";//设置DataGrid默认排序字段
				if (Session["sort_direction"]==null)
					Session["sort_direction"]="ASC";//设置DataGrid默认排序方向
				if (Session["ddlselectedvalue"]==null)
					Session["ddlselectedvalue"]="";//如果用户使用了检索功能，该Session用于记录用户的检索条件，以便从题库录入页面中编辑后返回该页时仍然能够显示刚才检索结果
				if (Session["ddlselectedtext"]==null)
					Session["ddlselectedtext"]="";//与上面的Session一样记录检索条件的，但是以中文形式显示在页面第二行的ListBox控件中的文字
				lbl_Title.Text="题库列表";
                DDLtixing.SelectedValue=Convert.ToString(Session["tixing"]);
				set_datagrid_visible(Convert.ToString(Session["tixing"]));;//该方法设置各DataGrid可见属性，只有参数传入的题型所在的DataGrid才可见
				DataGrid curr_dg=(DataGrid)this.FindControl(find_DG(Convert.ToString(Session["tixing"])));//获取当前题型所对应的DataGrid，find_DG方法返回当前参数所代表的题型所对应的DataGrid的ID 
				curr_dg.CurrentPageIndex=Convert.ToInt16(Session["curr_page"]);//将该DataGrid的当前页码设置为Session["curr_page"]中存储的页码
				DG_bind();//调用自定义函数，执行对DataGrid的绑定显示操作
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
			this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
			this.DG_xuan.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DG_xuan.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.PageIndexChanged);
			this.DG_xuan.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.SortCommand);
			this.DG_xuan.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.ItemDataBound);
			this.DG_tian.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DG_tian.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.PageIndexChanged);
			this.DG_tian.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.SortCommand);
			this.DG_tian.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.ItemDataBound);
			this.DG_pan_jian.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DG_pan_jian.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.PageIndexChanged);
			this.DG_pan_jian.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.SortCommand);
			this.DG_pan_jian.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.ItemDataBound);
			this.DG_bian.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DG_bian.SelectedIndexChanged += new System.EventHandler(this.DG_bian_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void DDLtixing_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			    fill_DdlSearchKind(DDLtixing.SelectedValue);//根据当前题型的不同,为检索字段下拉列表设置不同的可选项
			    set_datagrid_visible(DDLtixing.SelectedValue);
			    Session["tixing"]=DDLtixing.SelectedValue;
			    DataGrid curr_dg=(DataGrid)this.FindControl(find_DG(DDLtixing.SelectedValue));
		        curr_dg.CurrentPageIndex=0;
				DG_bind();
		}
		private void fill_DdlSearchKind(string tixing)
		{
			DdlSearchKind.Items.Clear();
			switch(tixing)
			{
				case "单选题":
				case "多选题":
					DdlSearchKind.Items.Add("章节名称");
					DdlSearchKind.Items.Add("题干");
					DdlSearchKind.Items.Add("选项A");
					DdlSearchKind.Items.Add("选项B");
					DdlSearchKind.Items.Add("选项C");
					DdlSearchKind.Items.Add("选项D");
					DdlSearchKind.Items.Add("正确答案");
				    break;
				case "填空题":
					DdlSearchKind.Items.Add("章节名称");
					DdlSearchKind.Items.Add("题干");
					DdlSearchKind.Items.Add("填空数");
					DdlSearchKind.Items.Add("填空1答案");
					DdlSearchKind.Items.Add("填空2答案");
					DdlSearchKind.Items.Add("填空3答案");
					DdlSearchKind.Items.Add("填空4答案");
					
					break;
				case "判断题":
				case "简答题":
					DdlSearchKind.Items.Add("章节名称");
					DdlSearchKind.Items.Add("题干");
					DdlSearchKind.Items.Add("正确答案");
					break;
				case "编程题":
					DdlSearchKind.Items.Add("题干");
					DdlSearchKind.Items.Add("正确答案");
					break;


			}
		}
		private void set_datagrid_visible(string tixing)
		{
			DG_xuan.Visible=false;
			DG_tian.Visible=false;
			DG_pan_jian.Visible=false;
			DG_bian.Visible=false;
			DataGrid curr_dg=(DataGrid)this.FindControl(find_DG(tixing));
		    curr_dg.Visible=true;
		}
		private string find_DG(string tixing)
		{
			string curr_dg_name="";
			switch(tixing)
			{
				case "单选题":
				case "多选题":
					curr_dg_name="DG_xuan";
					break;
				case "填空题":
					curr_dg_name="DG_tian";
					break;
				case "判断题":
				case "简答题":
					curr_dg_name="DG_pan_jian";
					break;
				case "编程题":
					curr_dg_name="DG_bian";
					break;
				
			}
			return curr_dg_name;
		}
		private void DG_bind()
		{
			string curr_tixing=Convert.ToString(Session["tixing"]);
			DataGrid curr_dg=(DataGrid)this.FindControl(find_DG(curr_tixing));
			string  strsql;
			if (curr_tixing=="编程题")
			{
					strsql="select * from "+DDLtixing.SelectedValue;
			}
			else
			{
				    strsql="select * from "+DDLtixing.SelectedValue+",章节 where "+DDLtixing.SelectedValue+".章节号=章节.章节号";
			}
			 new MyMethods().DG_bind(curr_dg,strsql,Convert.ToString(Session["ddlselectedvalue"]),Convert.ToString(Session["sort_field"])+" "+Convert.ToString(Session["sort_direction"]),Application["connstr"].ToString());
		}

		private void PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid curr_dg=(DataGrid)source;
			curr_dg.CurrentPageIndex=e.NewPageIndex;
			DG_bind();
		}

		private void SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if(e.SortExpression!=Convert.ToString(Session["sort_field"]))
			{
				Session["sort_field"]=e.SortExpression;
				Session["sort_direction"]="ASC";
			}
			else
			{
				if(Convert.ToString(Session["sort_direction"])=="ASC")
					Session["sort_direction"]="DESC";
				else
					Session["sort_direction"]="ASC";
			}
			DG_bind();
	 
		}

		private void ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
		    DataGrid curr_dg=(DataGrid)source;
			if (e.CommandName=="Select")
			{
				Session["curr_page"]=curr_dg.CurrentPageIndex;
				Response.Redirect("adminquestions.aspx?id="+curr_dg.DataKeys[e.Item.ItemIndex]);
			}
			if(e.CommandName=="Delete")
			{
				string sql="delete from "+DDLtixing.SelectedValue+" where id='"+curr_dg.DataKeys[e.Item.ItemIndex]+"'";
				new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
				DG_bind();
			}
		}

		private void btn_Add_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("adminquestions.aspx");
		}

		private void ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		    LinkButton lbtn;
			int delete_cell_num=0;
			DataGrid curr_dg=(DataGrid)sender;
			switch(curr_dg.ID)
            {
			    case "DG_xuan":
				case "DG_tian":
					delete_cell_num=8;
				    break;
				case "DG_pan_jian":
					delete_cell_num=4;
					break;
				case "DG_bian":
					delete_cell_num=3;
					break;
			}	
            if (e.Item.Cells[delete_cell_num].Text != "&nbsp;")
		    {
				lbtn = (LinkButton)e.Item.Cells[delete_cell_num].Controls[0];
				if (lbtn!=null) //所得lbtn即删除按钮，以下代码对该按钮添加客户端的OnClick事件，弹出确认对话框
					lbtn.Attributes.Add("OnClick", "JavaScript:return confirm('您真要删除吗？')");
            
		    }
		}

		private void BtnAdd_Click(object sender, System.EventArgs e)
		{
			if (TxtSearchContent.Text == "") 
			{
				Response.Write("<script>alert('请输入关键字！')</script>");
				return;
			}
			if (Convert.ToString(Session["ddlselectedtext"]) != "") 
			{
				string str=Convert.ToString(Session["ddlselectedtext"]);
				
				if((str.IndexOf("并且",str.Length-2)==-1)&&(str.IndexOf("或者",str.Length-2)==-1))
				{
					  Response.Write("<script>alert('条件错误，请重新选择条件！')</script>");
					  return;
				}
			}
			Session["ddlselectedtext"] = Session["ddlselectedtext"] + DdlSearchKind.SelectedItem.Text + DdlSelectcondition.SelectedItem.Text + TxtSearchContent.Text + DdlConnect.SelectedItem.Text;
			string strcontent;
			if (DdlSelectcondition.SelectedItem.Value == "like")
				strcontent = "'%" + TxtSearchContent.Text + "%'";
			else
				strcontent = "'" + TxtSearchContent.Text + "'";
        
			Session["ddlselectedvalue"] = Session["ddlselectedvalue"] + DdlSearchKind.SelectedItem.Value + " " + DdlSelectcondition.SelectedItem.Value + " " + strcontent + " " + DdlConnect.SelectedItem.Value + " ";
			ListItem listitem1=new ListItem();
			listitem1.Text = Convert.ToString(Session["ddlselectedtext"]);
			listitem1.Value = Convert.ToString(Session["ddlselectedvalue"]);
			DdlSelected.Items.Clear();
			DdlSelected.Items.Add(listitem1);
			DdlConnect.SelectedIndex = 0;
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Session["ddlselectedtext"] = "";
			Session["ddlselectedvalue"] = "";
		    DdlSelected.Items.Clear();
		}

		private void BtnSearch_Click(object sender, System.EventArgs e)
		{
			string str=Convert.ToString(Session["ddlselectedtext"]);
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
			DataGrid curr_dg=(DataGrid)this.FindControl(find_DG(Convert.ToString(Session["tixing"])));
				
			curr_dg.CurrentPageIndex = 0;
			Session["curr_page"] = "0";
			DG_bind();
		}

		private void BtnAll_Click(object sender, System.EventArgs e)
		{
			Session["ddlselectedtext"] = "";
			Session["ddlselectedvalue"] = "";

			DdlSelected.Items.Clear();
			DG_bind();
		}

		private void DG_bian_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}	
		
	}
}
