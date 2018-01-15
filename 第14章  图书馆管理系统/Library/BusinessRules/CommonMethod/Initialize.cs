using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using Library.UserInterface;
using Library.DataLevel;
namespace Library.UserInterface
{
	/// <summary>
	/// Initialize 的摘要说明。
	/// </summary>
	public class Initialize
	{
		DataBaseConnection dbc=new DataBaseConnection();
		private System.Data.SqlClient.SqlCommand comm;
		private System.Data.SqlClient.SqlDataReader dr;
		public Initialize()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public void setListView(string dataTable,ListView lv)
		{
			SqlConnection conn=setConnection();
			comm=new SqlCommand();
			comm.Connection=conn;
			string SQLtext="select * from  "+dataTable+"";
			comm.CommandText=SQLtext;
			dr=comm.ExecuteReader();
		
			setTitle(dataTable,lv);
		
		
		}
		public void setListView(string dataTable,string column1,string column2,string sqlQuery,ListView lv)
		{
			SqlConnection conn=setConnection();
			comm=new SqlCommand();
			comm.Connection=conn;
			string SQLtext="select * from "+dataTable + " where "+column1+"='"+sqlQuery+"' or "+column2+"='"+sqlQuery+"'";
			comm.CommandText=SQLtext;
			dr=comm.ExecuteReader();
			setTitle(dataTable,lv);
		}
		private SqlConnection setConnection()
		{
			string ConnString=dbc.databaseConnection;
			SqlConnection conn=new SqlConnection(ConnString);
			conn.Open();
			return conn;
		}

		private void setTitle(string dataTable,ListView lv)
		{
			lv.GridLines = true ;
			lv.FullRowSelect = true ;
			lv.View = View.Details ;
			lv.Scrollable = true ;
			lv.MultiSelect = false ;
			lv.HeaderStyle = ColumnHeaderStyle.Nonclickable ;
			lv.Clear();
			switch(dataTable)
			{
				case"Book":
					lv.Columns.Add("图书号码",100 , HorizontalAlignment.Center );
					lv.Columns.Add("图书名称",100 , HorizontalAlignment.Center );
					lv.Columns.Add("图书作者",100 , HorizontalAlignment.Center );
					lv.Columns.Add("出版社",100 , HorizontalAlignment.Center );
					lv.Columns.Add("出版日期",100 , HorizontalAlignment.Center );
					lv.Columns.Add("图书单价",100 , HorizontalAlignment.Center );
					lv.Columns.Add("图书分类",100 , HorizontalAlignment.Center );
					lv.Columns.Add("总册数",100 , HorizontalAlignment.Center );
					lv.Columns.Add("库存量",100 , HorizontalAlignment.Center );
					break;

				case"Reader":
					lv.Columns.Add("借书证号",100 , HorizontalAlignment.Center );
					lv.Columns.Add("读者姓名",100 , HorizontalAlignment.Center );
					lv.Columns.Add("读者密码",100 , HorizontalAlignment.Center );
					lv.Columns.Add("读者电话号码",100 , HorizontalAlignment.Center );
					lv.Columns.Add("读者邮箱",100 , HorizontalAlignment.Center );
					lv.Columns.Add("读者已借数目",100 , HorizontalAlignment.Center );
					break;

				case"dbo.[User]":
					lv.Columns.Add("用户登录名",100 , HorizontalAlignment.Center );
					lv.Columns.Add("用户姓名",100 , HorizontalAlignment.Center );
					lv.Columns.Add("用户密码",100 , HorizontalAlignment.Center );
					lv.Columns.Add("用户类型",100 , HorizontalAlignment.Center );
					lv.Columns.Add("用户部门",100 , HorizontalAlignment.Center );
					lv.Columns.Add("用户电话号码",100 , HorizontalAlignment.Center );
					break;

					case"PublishCompany":
					lv.Columns.Add("出版社名称",100 , HorizontalAlignment.Center );
					lv.Columns.Add("出版社地址",100 , HorizontalAlignment.Center );
					lv.Columns.Add("出版社电话号码",100 , HorizontalAlignment.Center );
					lv.Columns.Add("出版社邮箱",100 , HorizontalAlignment.Center );
					break;

			}
		setData(lv);
		
		}

		private void setData(ListView lv)
		{
			int i=0;
			i=dr.FieldCount;
			string [] itemsCount=new string[i];
	
//			for (int j=0;j<i;j++)
//			{
//				lv.GridLines = true ;
//				lv.FullRowSelect = true ;
//				lv.View = View.Details ;
//				lv.Scrollable = true ;
//				lv.MultiSelect = false ;
//				lv.HeaderStyle = ColumnHeaderStyle.Nonclickable ;
//				lv.Columns.Add ( dr.GetName(j) , 100 , HorizontalAlignment.Left ) ;	
//			}
			while (dr.Read())
			{
				ListViewItem li = new ListViewItem ( ) ;
				li.SubItems.Clear ( ) ;
				li.SubItems[0].Text = dr[0].ToString ( ) ;
				for(int k=1;k<i;k++)
				{				
					li.SubItems.Add( dr[k].ToString().Trim() ) ;
				}
				lv.Items.Add ( li ) ; 
			}
			dr.Close();
		}
	
	}
}
