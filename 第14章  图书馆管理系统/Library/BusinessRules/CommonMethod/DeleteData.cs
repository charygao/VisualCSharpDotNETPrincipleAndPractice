using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using Library.UserInterface;
using Library.DataLevel;
namespace Library.UserInterface.CommonMethod
{
	/// <summary>
	/// DeleteData 的摘要说明。
	/// </summary>

	public class DeleteData
	{	
		DataBaseConnection dbc=new DataBaseConnection();
		private System.Data.SqlClient.SqlCommand comm;
		private System.Data.SqlClient.SqlConnection conn;
		public DeleteData()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		
			conn=setConnection();
		}
		private SqlConnection setConnection()
		{
			string ConnString=dbc.databaseConnection;
			SqlConnection conn=new SqlConnection(ConnString);
			conn.Open();
			return conn;
		}
		public void delBookdata(string ID)
		{
			comm=new SqlCommand("SP_delete_Book",conn);
			comm.CommandType=CommandType.StoredProcedure;
			comm.Parameters.Add(new SqlParameter("@BookID",SqlDbType.Char,10));
			comm.Parameters["@BookID"].Value=ID;
			try
			{
				comm.ExecuteNonQuery();
			}
			catch (Exception E)
			{
			MessageBox . Show (E.Message); 
			
			}

		}
	
	public void delPublishdata(string ID)
		{
			comm=new SqlCommand("SP_delete_PublishCompany",conn);
			comm.CommandType=CommandType.StoredProcedure;
			comm.Parameters.Add(new SqlParameter("@PublishName",SqlDbType.Char,10));
			comm.Parameters["@PublishName"].Value=ID;
			try
			{
				comm.ExecuteNonQuery();
			}
			catch (Exception E)
			{
			MessageBox . Show (E.Message); 
			
			}

		}

		public void delReaderdata(string ID)
		{
			comm=new SqlCommand("SP_delete_Reader",conn);
			comm.CommandType=CommandType.StoredProcedure;
			comm.Parameters.Add(new SqlParameter("@ReaderID",SqlDbType.Char,10));
			comm.Parameters["@ReaderID"].Value=ID;
			try
			{
				comm.ExecuteNonQuery();
			}
			catch (Exception E)
			{
			MessageBox . Show (E.Message); 
			
			}

		}
		public void delUserdata(string ID)
		{
			comm=new SqlCommand("SP_delete_User",conn);
			comm.CommandType=CommandType.StoredProcedure;
			comm.Parameters.Add(new SqlParameter("@UserID",SqlDbType.Char,10));
			comm.Parameters["@UserID"].Value=ID;
			try
			{
				comm.ExecuteNonQuery();
			}
			catch (Exception E)
			{
			MessageBox . Show (E.Message); 
			
			}

		}


	}
}
