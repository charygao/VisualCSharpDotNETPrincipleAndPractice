using System;

namespace Library.DataLevel
{
	/// <summary>
	/// DataBaseConnection 的摘要说明。
	/// </summary>
	public class DataBaseConnection
	{
		public string databaseConnection;
		public DataBaseConnection()
		{
			string dataSource=GetMachineName();
			string ConnString="Data Source="+dataSource+";";
			ConnString+="Initial Catalog=LibraryManage;";
			ConnString+="User ID=sa;";
			//ConnString+="Password=123;";
			databaseConnection=ConnString;	
		}
		private static string GetMachineName()
		{         
			return Environment.GetEnvironmentVariable("COMPUTERNAME");
		}
	}
}
