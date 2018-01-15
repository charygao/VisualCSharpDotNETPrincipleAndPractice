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
	/// LoginInitialize 的摘要说明。
	/// </summary>
	public class LoginInitialize
	{
		DataBaseConnection dbc=new DataBaseConnection();
		private System.Data.SqlClient.SqlConnection conn;
		public LoginInitialize()
		{
			conn=setConnection();
		}
		private SqlConnection setConnection()
		{
			string ConnString=dbc.databaseConnection;
			SqlConnection conn=new SqlConnection(ConnString);
			conn.Open();
			return conn;
		}
		public void login(TextBox txtID,TextBox txtPSW,Form formLogin)
		{	
			string usercheck=UserCheck(txtID.Text,txtPSW.Text);
			switch(usercheck)
			{
				case"system"://如果当前用户类型是“系统管理员”
					ShowMainform(txtID.Text,txtPSW.Text,"system",formLogin);
					break;
				case"bookmanager"://如果当前用户类型是"图书管理员"
					ShowMainform(txtID.Text,txtPSW.Text,"bookmanager",formLogin);
					break;
				case"reader"://如果当前用户类型是"普通读者"
					ShowMainform(txtID.Text,txtPSW.Text,"reader",formLogin);
					break;
				case"counter"://如果当前用户类型是"借还书管理员"
					ShowMainform(txtID.Text,txtPSW.Text,"counter",formLogin);
					break;
				case"Nobody"://如果当前用户提供的信息无法通过系统的验证
					if(MessageBox.Show("输入用户或密码有误，是否重新登陆","输入有误",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
					{
						txtID.Text="";
						txtPSW.Text="";
						txtID.Focus();
					}
					else//如果用户单击"取消"按钮
					{
						formLogin.Close();
					}
					break;
			}
		}
		string UserCheck(string username,string userpassword)
		{
			string usersort;	
			usersort="nobody";
			try
			{
				if(Identify(username,userpassword))//调用Identify函数验证用户的合法性
				{
					usersort=SetSort(username,userpassword);//调用SetSort函数分配用户权限
					if(usersort!="reader")//当用户权限不是"读者"
					{	
						return usersort;
					}
				
					else   //当用户权限是"读者"
					{
						return "reader";
					}
				}			
				else//当用户验证失败
				{
					return "Nobody";
				}
			}
			catch(Exception e)
			{
				MessageBox.Show(e.ToString());
			}			
			conn.Close();	
			return "nobody";	
		}
		private bool Identify(string username,string userpassword)
		{
			SqlCommand cm=new SqlCommand("SP_selectIdentify",conn);
			cm.CommandType=CommandType.StoredProcedure;
			cm.Parameters.Add(new SqlParameter("@uname",SqlDbType.Char,10));
			cm.Parameters.Add(new SqlParameter("@upwd",SqlDbType.Char,10));
			cm.Parameters["@uname"].Value=username;
			cm.Parameters["@upwd"].Value=userpassword;
			SqlDataReader dr=cm.ExecuteReader();
			if(dr.Read())
			{
				dr.Close();
				return true;
			}
			else
			{
				dr.Close();
				return false;
			}
		}
		private string SetSort(string username,string userpassword)
		{
			string usersort="";
			string txtSql="select UserID,UserPassword,UserSort from dbo.[User] where UserID='"+username+"' AND UserPassword='"+userpassword+"'";
			SqlCommand checkuser=new SqlCommand(txtSql,conn);
			SqlDataReader sqlreader=checkuser.ExecuteReader();
			while(sqlreader.Read())// 当数据读取器找到结果后
			{	
				if((sqlreader[0].ToString().Trim()==username)&&(sqlreader[1].ToString().Trim()==userpassword))//如果用户名和密码验证成功
				{	
					usersort=sqlreader[2].ToString().Trim();
					sqlreader.Close();
					return usersort;						
				}
			}	
			sqlreader.Close();
			return "reader";
		}

		private void ShowMainform(string username,string userpassword,string usersort,Form formLogin)
		{
			formLogin.Visible=false;
			Form mainform=new MainForm(username,usersort);
			try
			{
				mainform.ShowDialog();
				formLogin.Close();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);			
			}
		}

	}
}
