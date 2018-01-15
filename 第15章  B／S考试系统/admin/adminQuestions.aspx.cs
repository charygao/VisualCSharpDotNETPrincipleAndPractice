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
	/// adminquestions 的摘要说明。
	/// </summary>
	public class adminquestions : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_Title;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList DDLTx;
		protected System.Web.UI.WebControls.Panel Panel_dan;
		protected System.Web.UI.WebControls.TextBox TXTdanxzd;
		protected System.Web.UI.WebControls.TextBox TXTdanxzc;
		protected System.Web.UI.WebControls.TextBox TXTdanxzb;
		protected System.Web.UI.WebControls.TextBox TXTdantg;
		protected System.Web.UI.WebControls.TextBox TXTdanxza;
		protected System.Web.UI.WebControls.RadioButtonList RBLdanzqda;
		protected System.Web.UI.WebControls.TextBox TXTduoxzd;
		protected System.Web.UI.WebControls.TextBox TXTduoxzc;
		protected System.Web.UI.WebControls.TextBox TXTduoxzb;
		protected System.Web.UI.WebControls.TextBox TXTduoxza;
		protected System.Web.UI.WebControls.TextBox TXTduotg;
		protected System.Web.UI.WebControls.Panel Panel_duo;
		protected System.Web.UI.WebControls.CheckBoxList CBLduozqda;
		protected System.Web.UI.WebControls.DropDownList DDLdansszj;
		protected System.Web.UI.WebControls.DropDownList DDLduosszj;
		protected System.Web.UI.WebControls.TextBox TXTtiantg;
		protected System.Web.UI.WebControls.Panel Panel_tian;
		protected System.Web.UI.WebControls.DropDownList DDLtiantks;
		protected System.Web.UI.WebControls.DropDownList DDLtiansszj;
		protected System.Web.UI.WebControls.Panel Panel_pan;
		protected System.Web.UI.WebControls.Panel Panel_jian;
		protected System.Web.UI.WebControls.Panel Panel_bian;
		protected System.Web.UI.WebControls.Button BTNsave;
		protected System.Web.UI.WebControls.Button BTNreturn;
		protected System.Web.UI.WebControls.Button BTNreset;
		protected System.Web.UI.WebControls.TextBox TXTtiankong1;
		protected System.Web.UI.WebControls.TextBox TXTtiankong2;
		protected System.Web.UI.WebControls.TextBox TXTtiankong3;
		protected System.Web.UI.WebControls.TextBox TXTtiankong4;
		protected System.Web.UI.HtmlControls.HtmlTable table_tian;
		protected System.Web.UI.WebControls.TextBox TXTpantg;
		protected System.Web.UI.WebControls.DropDownList DDLpanzqda;
		protected System.Web.UI.WebControls.DropDownList DDLpansszj;
		protected System.Web.UI.WebControls.TextBox TXTjiantg;
		protected System.Web.UI.WebControls.TextBox TXTjianzqda;
		protected System.Web.UI.WebControls.DropDownList DDLjiansszj;
		protected System.Web.UI.WebControls.TextBox TXTbiantg;
		protected System.Web.UI.WebControls.TextBox TXTbianzqda;
		protected System.Web.UI.WebControls.Panel panel_add;
	
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
				 lbl_Title.Text="题库管理";
				 DropDownList[] ddl={DDLdansszj,DDLduosszj,DDLtiansszj,DDLpansszj,DDLjiansszj};
				 new MyMethods().fill_dropdownlist(ddl,Application["connstr"].ToString(),"select * from 章节","章节名称","章节号");//对所有的用来显示章节的下拉列表进行绑定
				 BTNsave.Attributes.Add("OnClick", "JavaScript:return confirm('您真要保存吗？')");//为保存按钮增加脚本程序
				 set_tiankong_visible(Convert.ToInt16(DDLtiantks.SelectedValue));//根据用户选择的填空题的填空数，显示相应个数用来输入填空答案的文本框
				if (Request["id"]!=null)//如果页面参数不为空，则证明该页是从题库列表中的试题的删除按钮传来的，则显示该试题的详细信息
				{
					DDLTx.SelectedValue=Convert.ToString(Session["tixing"]);
					DDLTx.Enabled=false;
					set_panel_visible(Convert.ToString(Session["tixing"])); //根据不同题型显示不同的录入界面（界面集成在Panel中）
					string sql="select * from "+Convert.ToString(Session["tixing"])+" where id='"+Request["id"]+"'";
					MyData md=new MyData(Application["connstr"].ToString());
					OleDbDataReader dr=md.eSelect(sql);
					if(dr.Read())
					{
						switch(Convert.ToString(Session["tixing"]))
						{
							case "单选题":
								DDLdansszj.SelectedValue=Convert.ToString(dr["章节号"]);
						        TXTdantg.Text=Convert.ToString(dr["题干"]);
								TXTdanxza.Text=Convert.ToString(dr["选项A"]);
								TXTdanxzb.Text=Convert.ToString(dr["选项B"]);
							    TXTdanxzc.Text=Convert.ToString(dr["选项C"]);
								TXTdanxzd.Text=Convert.ToString(dr["选项D"]);
								RBLdanzqda.SelectedValue=Convert.ToString(dr["正确答案"]);
								break;
							case "多选题":
								DDLduosszj.SelectedValue=Convert.ToString(dr["章节号"]);
								TXTduotg.Text=Convert.ToString(dr["题干"]);
								TXTduoxza.Text=Convert.ToString(dr["选项A"]);
								TXTduoxzb.Text=Convert.ToString(dr["选项B"]);
								TXTduoxzc.Text=Convert.ToString(dr["选项C"]);
								TXTduoxzd.Text=Convert.ToString(dr["选项D"]);
								string zqda=Convert.ToString(dr["正确答案"]);
								
								   for(int i=0;i<4;i++)//将数据库中该试题的正确答案反映在各CheckBox中
								 	 if(zqda.IndexOf(CBLduozqda.Items[i].Value)!=-1)
										 CBLduozqda.Items[i].Selected=true;
							         else
										 CBLduozqda.Items[i].Selected=false;
								
								break;
							case "填空题":
								DDLtiansszj.SelectedValue=Convert.ToString(dr["章节号"]);
								TXTtiantg.Text=Convert.ToString(dr["题干"]);
								DDLtiantks.SelectedValue=Convert.ToString(dr["填空数"]);
								set_tiankong_visible(Convert.ToInt16(DDLtiantks.SelectedValue));
								TXTtiankong1.Text=Convert.ToString(dr["填空1答案"]);
								TXTtiankong2.Text=Convert.ToString(dr["填空2答案"]);
								TXTtiankong3.Text=Convert.ToString(dr["填空3答案"]);
								TXTtiankong4.Text=Convert.ToString(dr["填空4答案"]);	
								break;
							case "判断题":
								DDLpansszj.SelectedValue=Convert.ToString(dr["章节号"]);
								TXTpantg.Text=Convert.ToString(dr["题干"]);
								DDLpanzqda.SelectedValue=Convert.ToString(dr["正确答案"]);
								break;
							case "简答题":
								DDLjiansszj.SelectedValue=Convert.ToString(dr["章节号"]);
								TXTjiantg.Text=Convert.ToString(dr["题干"]);
								TXTjianzqda.Text=Convert.ToString(dr["正确答案"]);
								break;
							case "编程题":
							
								TXTbiantg.Text=Convert.ToString(dr["题干"]);
								TXTbianzqda.Text=Convert.ToString(dr["正确答案"]);
								break;
						
						}
					}
					md.CloseConn();
				 
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
			this.DDLTx.SelectedIndexChanged += new System.EventHandler(this.DDLTx_SelectedIndexChanged);
			this.DDLtiantks.SelectedIndexChanged += new System.EventHandler(this.DDLtiantks_SelectedIndexChanged);
			this.BTNsave.Click += new System.EventHandler(this.BTNsave_Click);
			this.BTNreturn.Click += new System.EventHandler(this.BTNreturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void DDLTx_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			set_panel_visible(DDLTx.SelectedValue);
			
		}
		private void set_panel_visible(string tixing)
		{
			Panel_dan.Visible=false;
			Panel_duo.Visible=false;
			Panel_tian.Visible=false;
			Panel_pan.Visible=false;
			Panel_jian.Visible=false;
			Panel_bian.Visible=false;
			Panel curr_panel=(Panel)this.FindControl(find_panel(tixing));
			curr_panel.Visible=true;

		}
		private string find_panel(string tixing)
		{
			string curr_panel_name="";
			switch(tixing)
			{
				case "单选题":
					curr_panel_name="Panel_dan";
					break;
				case "多选题":
					curr_panel_name="Panel_duo";
					break;
				case "填空题":
					curr_panel_name="Panel_tian";
					break;
				case "判断题":
					curr_panel_name="Panel_pan";
					break;
				case "简答题":
					curr_panel_name="Panel_jian";
					break;
				case "编程题":
					curr_panel_name="Panel_bian";
					break;
				
			}
			return curr_panel_name;
		}
		private void set_tiankong_visible(int tiankong_num)
		{
			for(int i=0;i<tiankong_num;i++)
			{
				table_tian.Rows[i].Visible=true;
			}
			for(int i=tiankong_num;i<4;i++)
		    {
                table_tian.Rows[i].Visible=false;
			 }

		}
		
		private void BTNsave_Click(object sender, System.EventArgs e)
		{
			string sql="",strid=new MyMethods().DateId();
			if (Request["id"]==null)
			{//如果页面参数id为空，则执行添加操作,否则执行更新操作
				switch(DDLTx.SelectedItem.Text.ToString())
				{
					case "单选题":							
						sql="insert into 单选题 (id,章节号,题干,选项A,选项B,选项C,选项D,正确答案)values('"+strid+"','"+DDLdansszj.SelectedValue.ToString()+"','"+TXTdantg.Text+"','"+TXTdanxza.Text+"','"+TXTdanxzb.Text+"','"+TXTdanxzc.Text+"','"+TXTdanxzd.Text+"','"+RBLdanzqda.SelectedValue+"')";		
						break;
					case "多选题":
						string str_da="";
						for(int i=0;i<4;i++)//将用户在四个CheckBox上标出来的多选题答案组成答案字符串.
						{
							if (CBLduozqda.Items[i].Selected)
								str_da+=CBLduozqda.Items[i].Value;
						}
						sql="insert into 多选题 (id,章节号,题干,选项A,选项B,选项C,选项D,正确答案)values('"+strid+"','"+DDLduosszj.SelectedValue.ToString()+"','"+TXTduotg.Text+"','"+TXTduoxza.Text+"','"+TXTduoxzb.Text+"','"+TXTduoxzc.Text+"','"+TXTduoxzd.Text+"','"+str_da+"')";		
						break;
					case "填空题":
						sql="insert into 填空题 (id,章节号,题干,填空数,填空1答案,填空2答案,填空3答案,填空4答案)values('"+strid+"','"+DDLtiansszj.SelectedValue.ToString()+"','"+TXTtiantg.Text+"','"+DDLtiantks.SelectedValue+"','"+TXTtiankong1.Text+"','"+TXTtiankong2.Text+"','"+TXTtiankong3.Text+"','"+TXTtiankong4.Text+"')";		
						break;
					case "判断题":
						sql="insert into 判断题 (id,章节号,题干,正确答案)values('"+strid+"','"+DDLpansszj.SelectedValue.ToString()+"','"+TXTpantg.Text+"','"+DDLpanzqda.SelectedValue+"')";
						break;
					case "简答题":
						sql="insert into 简答题 (id,章节号,题干,正确答案)values('"+strid+"','"+DDLjiansszj.SelectedValue.ToString()+"','"+TXTjiantg.Text+"','"+TXTjianzqda.Text+"')";
						break;
					case "编程题":
						sql="insert into 编程题 (id,题干,正确答案)values('"+strid+"','"+TXTbiantg.Text+"','"+TXTbianzqda.Text+"')";
						break;			
				}
			}
			else
			{
				switch(DDLTx.SelectedItem.Text.ToString())
				{
					case "单选题":							
						sql="update 单选题 set 章节号='"+DDLdansszj.SelectedValue.ToString()+"',题干='"+TXTdantg.Text+"',选项A='"+TXTdanxza.Text+"',选项B='"+TXTdanxzb.Text+"',选项C='"+TXTdanxzc.Text+"',选项D='"+TXTdanxzd.Text+"',正确答案='"+RBLdanzqda.SelectedValue+"' where id='"+Request["id"]+"'";		
						break;
					case "多选题":
						string str_da="";
						for(int i=0;i<4;i++)
						{
							if (CBLduozqda.Items[i].Selected)
								str_da+=CBLduozqda.Items[i].Value;
						}
						sql="update 多选题 set 章节号='"+DDLduosszj.SelectedValue.ToString()+"',题干='"+TXTduotg.Text+"',选项A='"+TXTduoxza.Text+"',选项B='"+TXTduoxzb.Text+"',选项C='"+TXTduoxzc.Text+"',选项D='"+TXTduoxzd.Text+"',正确答案='"+str_da+"' where id='"+Request["id"]+"'";		
						break;
					case "填空题":
						sql="update 填空题 set 章节号='"+DDLtiansszj.SelectedValue.ToString()+"',题干='"+TXTtiantg.Text+"',填空数='"+DDLtiantks.SelectedValue+"',填空1答案='"+TXTtiankong1.Text+"',填空2答案='"+TXTtiankong2.Text+"',填空3答案='"+TXTtiankong3.Text+"',填空4答案='"+TXTtiankong4.Text+"' where id='"+Request["id"]+"'";
						break;
					case "判断题":
						sql="update 判断题 set 章节号='"+DDLpansszj.SelectedValue.ToString()+"',题干='"+TXTpantg.Text+"',正确答案='"+DDLpanzqda.SelectedValue+"' where id='"+Request["id"]+"'";
						break;
					case "简答题":
						sql="update 简答题 set 章节号='"+DDLjiansszj.SelectedValue.ToString()+"',题干='"+TXTjiantg.Text+"',正确答案='"+TXTjianzqda.Text+"' where id='"+Request["id"]+"'";
						break;
					case "编程题":
						sql="update 编程题 set 题干='"+TXTbiantg.Text+"',正确答案='"+TXTbianzqda.Text+"' where id='"+Request["id"]+"'";
						break;			
				}
			}
			new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
			Response.Write("<script>alert('保存成功!')</script>");
			
		}

		private void DDLtiantks_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			set_tiankong_visible(Convert.ToInt16(DDLtiantks.SelectedValue));
		}

		private void BTNreturn_Click(object sender, System.EventArgs e)
		{
		    Response.Redirect("adminquestionslist.aspx");
		}
	}
}
