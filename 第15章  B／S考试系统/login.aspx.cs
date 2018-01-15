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
	/// denglu 的摘要说明。
	/// </summary>
	public class denglu : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DDLdlsf;
		protected System.Web.UI.WebControls.TextBox TXTdlmm;
		protected System.Web.UI.WebControls.Button Btndenglu;
		protected System.Web.UI.WebControls.Button Btnxiugai;
		protected System.Web.UI.WebControls.Panel Panel_dl;
		protected System.Web.UI.WebControls.Button Btnqueren;
		protected System.Web.UI.WebControls.Button Btnfanhui;
		protected System.Web.UI.WebControls.Panel Panel_xgmm;
		protected System.Web.UI.WebControls.DropDownList DDLxgsf;
		protected System.Web.UI.WebControls.TextBox TXTxgdlid;
		protected System.Web.UI.WebControls.TextBox TXTxgjmm;
		protected System.Web.UI.WebControls.TextBox TXTxgxmm;
		protected System.Web.UI.WebControls.TextBox TXTxgxmmqr;
		protected System.Web.UI.WebControls.TextBox TXTdldlid;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			
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
			this.Btndenglu.Click += new System.EventHandler(this.Btndenglu_Click);
			this.Btnxiugai.Click += new System.EventHandler(this.Btnxiugai_Click);
			this.Btnqueren.Click += new System.EventHandler(this.Btnqueren_Click);
			this.Btnfanhui.Click += new System.EventHandler(this.Btnfanhui_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		private void Btndenglu_Click(object sender, System.EventArgs e)
		{

			if (DDLdlsf.SelectedValue=="学生")
			{
				MyData md=new MyData(Application["connstr"].ToString());
				String StrSQL="select * from 学生,班级 where 学生.班级编号=班级.id and 学号='"+TXTdldlid.Text+"'";
				OleDbDataReader DR=md.eSelect(StrSQL);
				if(DR.Read())
				{
					if(Convert.ToString(DR["密码"])==TXTdlmm.Text)
					{
						if(DR["允许考试日期"].GetType().Name=="DBNull"||Convert.ToDateTime(DR["允许考试日期"]).ToShortDateString()!=DateTime.Now.ToShortDateString())						
							Response.Write("<script>alert('您的考试日期不是今天!')</script>");					
						else
						{	
							if(DR["考试登陆时间"].GetType().Name=="DBNull"||(System.DateTime)DR["允许考试日期"]>=(System.DateTime)DR["考试登陆时间"])
							{
								StrSQL="update 学生 set 考试登陆时间=#"+DateTime.Now.ToString()+"# where 学号='"+TXTdldlid.Text+"'";
								new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(StrSQL);		
								Session["logintime"]=DateTime.Now.ToString();
								Session["Student_ID"]=DR["学号"];
								Session["Student_Name"]=DR["姓名"];
								Response.Redirect("kaoshi/exam.aspx");
							}
							else
							{
								System.TimeSpan remain_time=DateTime.Now-(DateTime)DR["考试登陆时间"];
								if(remain_time.TotalSeconds>0&&remain_time.TotalSeconds<7200)					
								{		
									Session["logintime"]=DR["考试登陆时间"].ToString();
									Session["shijuanhao"]=DR["本次试卷号"];
									Session["Student_ID"]=DR["学号"];
									Session["Student_Name"]=DR["姓名"];
									
									Response.Redirect("kaoshi/exam.aspx");
								}	
								else
									Response.Write("<script>alert('您的考试时间已到,或者您已经提交了试卷!')</script>");			
							}
						
						}
						
					}
					else
					{
						Response.Write("<script>alert('密码不正确!')</script>");
					}
					
				}
				else
				{
					Response.Write("<script>alert('没有此登陆ID!')</script>");
				}
				md.CloseConn();
			}
			else
			{
				String StrSQL="select * from 教师 where 教师号='"+TXTdldlid.Text+"'";
			    MyData md=new MyData(Application["connstr"].ToString());
				OleDbDataReader DR=md.eSelect(StrSQL);
				if(DR.Read())
				{
					if(Convert.ToString(DR["密码"])==TXTdlmm.Text)
					{
						Session["Teacher_ID"]=DR["教师号"];
						
						Response.Redirect("AdminMain.htm");

					}
					else
					{
						Response.Write("<script>alert('密码不正确!')</script>");
					}
				}
				else
				{
					Response.Write("<script>alert('没有此登陆ID!')</script>");
				}
				md.CloseConn();
			}
		}

		private void Btnxiugai_Click(object sender, System.EventArgs e)
		{
			Panel_dl.Visible=false;
			Panel_xgmm.Visible=true;

		}

		private void Btnfanhui_Click(object sender, System.EventArgs e)
		{
			Panel_dl.Visible=true;
			Panel_xgmm.Visible=false;
		}

		private void Btnqueren_Click(object sender, System.EventArgs e)
		{
			if(TXTxgxmm.Text!=TXTxgxmmqr.Text)
			{
				Response.Write("<script>alert('两次密码输入不一致!')</script>");
			}
			else
			{
				string dengluID;
				if(DDLxgsf.SelectedValue=="学生")
					dengluID="学号";
				else
					dengluID="教师号";
				String StrSQL="update "+DDLxgsf.SelectedValue+" set 密码='"+TXTxgxmm.Text+"' where "+dengluID+"='"+TXTxgdlid.Text+"' and 密码='"+TXTxgjmm.Text+"'";
				if(new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(StrSQL)==0)
				{
					Response.Write("<script>alert('登陆ID或旧密码错误!')</script>");
				}
				else
				{
					Response.Write("<script>alert('新密码修改成功!')</script>");
					Panel_dl.Visible=true;
					Panel_xgmm.Visible=false;
				}

			}
				
		}
	}
}
