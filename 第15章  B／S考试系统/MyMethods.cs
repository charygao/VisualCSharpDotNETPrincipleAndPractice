using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
namespace Test
{
	/// <summary>
	/// MyMethods 的摘要说明。
	/// </summary>
	public class MyMethods
	{
		public MyMethods()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public void AlertAndRedirect(string msg ,string tourl)//弹出警告对话框，警告信息为参数msg的内容,并返回参数tourl中所指的URL。在验证用户登陆时，如没登陆则调用此方法，警告用户并返回Login.aspx页面
		{
			string js = "<script language=javascript>alert('{0}');window.location.replace('{1}');</script>";
			HttpContext.Current.Response.Write(String.Format(js, msg, tourl));
		}
		public string DateId()//返回当前年月日时分秒毫秒组成的字符串，作为向数据库插入数据时各记录的关键字
		{
			DateTime now=DateTime.Now;
			return now.Year.ToString()+now.Month.ToString()+now.Day.ToString()+now.Hour.ToString()+now.Minute.ToString()+now.Second.ToString()+now.Millisecond.ToString();
		}
		public void DG_bind(DataGrid dg,string sqlstr,string SearchCondition,string SortExpression,string connstr)
		{// 对连接字符串connstr所指的数据库，执行查询语句sqlstr，并用其返回的关系，绑定DataGrid控件dg，SearchCondition为检索时的检索条件，SortExpression为当前数据表格的排序模式
		    MyData md=new MyData(connstr);
		    DataSet ds1=md.FillDataset(sqlstr);
			if (SearchCondition != "")
				ds1.Tables[0].DefaultView.RowFilter = SearchCondition;

			ds1.Tables[0].DefaultView.Sort = SortExpression;
			dg.DataSource = ds1.Tables[0].DefaultView;
			try
			{
				dg.DataBind();
			}
			catch
			{
				dg.CurrentPageIndex-=1;
				dg.DataBind();

			}
		}
		public void Repeater_bind(Repeater rp,ref DataSet ds,string sqlstr,string connstr)
		{   //对连接字符串connstr所指的数据库，执行查询语句sqlstr，并用其返回的关系，绑定Repeater控件rp.函数返回数据集,供进一步操作
			MyData md=new MyData(connstr);
			ds=md.FillDataset(sqlstr);
			
			rp.DataSource=ds.Tables[0].DefaultView;
			rp.DataBind();
			
		}
		public void fill_dropdownlist(DropDownList[] ddl,string connstr,string sql,string textfield,string valuefield)
		{   //对连接字符串connstr所指的数据库，执行查询语句sql，并用其返回的关系的textfield字段和valuefield字段分别绑定给ddl数组中各控件的DataTextField属性和DataValueField属性
			MyData md=new MyData(connstr);
			DataSet ds1 = md.FillDataset(sql); 
			for(int i=0;i<ddl.Length;i++)
			{
				ddl[i].DataSource=ds1.Tables[0].DefaultView;
				ddl[i].DataTextField=textfield;
				ddl[i].DataValueField=valuefield;
				ddl[i].DataBind();
			}
		
		}
	}
}
