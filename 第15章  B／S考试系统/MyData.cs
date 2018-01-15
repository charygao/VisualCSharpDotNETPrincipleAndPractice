using System;
using System.Data;
using System.Data.OleDb;
namespace Test
{
	/// <summary>
	/// MyData 的摘要说明。
	/// </summary>
	public class MyData
	{
		protected string strconn;
		protected OleDbConnection objconn;
		protected OleDbCommand objcomm;
	    //获取连接字符串，并创建Connection对象
		public MyData(string connectionString)
		{
			strconn = connectionString;
			objconn = new OleDbConnection(strconn);
		}
		
		public int eInsertUpdateDelete(string sqlstr)
		{//执行Insert、Update、Delete语句，并返回影响的行数
			int i=0;
			objconn.Open();
			objcomm=new OleDbCommand(sqlstr,objconn);
		    try
			{
				 i = (int)objcomm.ExecuteNonQuery();
			} 
			catch
			{
				//objcomm.Transaction.Rollback();					
			}
			objconn.Close();
			objconn.Dispose();
			return i;
		}
		public OleDbDataReader eSelect(string sqlstr)
		{
			//执行Select语句，并返回DataReader对象
			OleDbDataReader dr=null;
			objconn.Open();
			objcomm=new OleDbCommand(sqlstr,objconn);
			try
			{
				dr= objcomm.ExecuteReader();
			} 
			catch
			{			
			}
			return dr;

		}
		public DataSet FillDataset(string sqlstr)
		{
			//执行Select语句，并将返回DataSet对象
			OleDbDataAdapter da=new OleDbDataAdapter(sqlstr,objconn);
			DataSet ds=new DataSet();
			try
			{
				da.Fill(ds);
			}
			catch
			{}
			return ds;
			
		}
		public void CloseConn()
		{
			//关闭并销毁Connection对象
			objconn.Close();
			objconn.Dispose();
		}
	}
}
