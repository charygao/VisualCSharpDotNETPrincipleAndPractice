using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace CityEduWebService
{
	/// <summary>
	/// config 的摘要说明。
	/// </summary>
	public class config
	{
		public System.Data.OleDb.OleDbConnection myConnection; 
		public System.Data.OleDb.OleDbCommand myCommand;
		public System.Data.OleDb.OleDbDataAdapter myAdapter;
		public System.Data.OleDb.OleDbDataReader myReader;
		public System.Data.OleDb.OleDbCommandBuilder myCommandBuilder;

		/*public SqlConnection myConnection; 
		public SqlCommand myCommand;
		public SqlDataAdapter myAdapter;
		public SqlDataAdapter myAdapter1;
		public SqlDataReader myReader;
		public SqlCommandBuilder myCommandBuilder;*/
		public DataSet ds;
		public DataTable dt;
		public DataRow dr;

		public config()
		{
			Open(); // 打开数据库
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		//打开数据连接
		public string Open()
		{  
			string myConnectionStr="Provider=SQLOLEDB.1;Persist Security Info=False;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID="
				+ConfigurationSettings.AppSettings["WorkstationSet"]
				+";Use Encryption for Data=False;Tag with column collation when possible=False;Initial Catalog="
				+ConfigurationSettings.AppSettings["Database"]
				+";Data Source="+ConfigurationSettings.AppSettings["DatabaseServer"]
				+";User ID="+ConfigurationSettings.AppSettings["DatabaseUser"]
				+";Password="+ConfigurationSettings.AppSettings["DatabasePassword"];
			myConnection=new System.Data.OleDb.OleDbConnection(myConnectionStr);
			
			try
			{
				myConnection.Open();
			}
			catch(Exception e)
			{
				string errorMessage = e.Message;				
				return errorMessage;
			}			
			
			return "OK";
		}

		//打开恢复数据库专用的数据连接,用master数据库
		public string DBRestore(string str_Sql)
		{   
			string myConnectionStr="Provider=SQLOLEDB.1;Persist Security Info=False;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=DH;Use Encryption for Data=False;Tag with column collation when possible=False;Initial Catalog=master;Data Source="
				+ConfigurationSettings.AppSettings["Database"]
				+";User ID="+ConfigurationSettings.AppSettings["DatabaseUser"]
				+";Password="+ConfigurationSettings.AppSettings["DatabasePassword"];
			myConnection=new System.Data.OleDb.OleDbConnection(myConnectionStr);
			
			try
			{
				myConnection.Open();
			}
			catch(SqlException e)
			{
				string errorMessage = e.Message;				
				return errorMessage;
			}
			finally
			{
				myConnection.Dispose();	
			}
			//myCommand = new SqlCommand(str_Sql,myConnection);
			//断开SchoolManage的一切连接
			string str_Sql_DisConnect="declare hcforeach cursor global for select 'kill '+rtrim(spid) from master.dbo.sysprocesses where dbid=db_id('"
				+ConfigurationSettings.AppSettings["Database"].ToString()
				+"') exec sp_msforeach_worker '?'";
			myCommand = new System.Data.OleDb.OleDbCommand(str_Sql_DisConnect,myConnection);
			myCommand.ExecuteNonQuery();
			myCommand.Dispose();

			myCommand = new System.Data.OleDb.OleDbCommand(str_Sql,myConnection);
			myCommand.ExecuteNonQuery();
			myCommand.Dispose();

			return "OK";
		}
		/// <summary>
		/// 关闭数据库和清除DateSet对象
		/// </summary>
		public void Close()
		{
			if (ds!=null) // 清除DataSet对象
			{
				ds.Clear();
			}
			if (myConnection!=null)
			{
				myConnection.Close(); // 关闭数据库
			}
		}
		/// <summary>
		/// 建立DataSet对象,用记录填充或构架(如果必要)DataSet对象,DataSet即是数据在内存的缓存
		/// </summary>
		/// <param name="str_Sql">打开表Sql语句</param>
		public string Fill(string str_Sql)
		{  	
			string errorstring=Open();
			if(errorstring!="OK")return errorstring;

			//myAdapter = new SqlDataAdapter(str_Sql,myConnection)
			myAdapter = new System.Data.OleDb.OleDbDataAdapter(str_Sql,myConnection);
			myAdapter.TableMappings.Add("Table", "TaleIn");
			
			ds = new DataSet();
			try
			{
				myAdapter.Fill(ds);	
			}
			catch(SqlException e)
			{
				string errorMessage = e.Message;				
				return errorMessage;
			}
			finally
			{
				myConnection.Dispose();	
			}

			return "OK";
		}

		/// <summary>
		///执行Sql语句
		/// </summary>
		/// <param name="str_Sql">要执行的Sql语句</param>
		public string ExeSql(string str_Sql)
		{   
			string errorstring=Open();
			if(errorstring!="OK")return errorstring;
			
			//myCommand = new SqlCommand(str_Sql,myConnection);
			myCommand = new System.Data.OleDb.OleDbCommand(str_Sql,myConnection);
			
			try
			{
				myCommand.ExecuteNonQuery();
			}
			catch(SqlException e)
			{
				string errorMessage = e.Message;				
				return errorMessage;
			}
			finally
			{
				myCommand.Dispose();
			}

			return "OK";
		}
		/// <summary>
		/// 获得符合该Sql语句的表记录数
		/// </summary>
		/// <param name="str_Sql">Select-SQL语句</param>
		/// <returns>返回表记录条数</returns>
		public int GetRowCount(string str_Sql)
		{
			if(Fill(str_Sql)!="OK")return 0;
			
			try
			{
				int count=ds.Tables[0].Rows.Count;
				
				ds.Clear();
				myConnection.Close();
				return count;
			}
			catch
			{
				ds.Clear();
				myConnection.Close();
				return 0;
			}
		}
		
		/// <summary>
		/// 通过传Sql语句关键key值获得表中一行的数据
		/// </summary>
		/// <param name="str_Sql">带关键Key值参数的Select-SQL语句</param>
		public bool GetRowRecord(string str_Sql)
		{
			if(Fill(str_Sql)!="OK")return false;
			
			//Fill(str_Sql);
			dr=ds.Tables[0].Rows[0];
			myConnection.Close();
			
			return true;
		}

		/// <summary>
		/// 取某个表中某个字段最大值
		/// </summary>
		public string GetMaxId(string id,string tablename)
		{
			string str_Key;
			string str_Sql="select top 1 "+id+" AS MaxId from "+tablename+" order by "+id+" desc";
			//string str_Sql="select max("+id+") AS MaxID from "+tablename;
			if (GetRowCount(str_Sql)==0)
			{
				str_Key="1";
			}
			else
			{
				GetRowRecord(str_Sql);
				str_Key=(int.Parse(dr["MaxID"].ToString())+1).ToString(); // 获得数据库表key值
			}
			return str_Key;
		}

		//用ID查找其他字段值
		public  string School_Type_IDtoWhat(string str_School_Type_ID,string what)
		{
			string str_Sql="select "+what+" from School_Type where School_Type_ID="+str_School_Type_ID;
			if(GetRowRecord(str_Sql)==false)return "";
			return  dr[what].ToString();
		}

		public  string Class_Type_IDtoWhat(string str_Class_Type_ID,string what)
		{
			string str_Sql="select "+what+" from Class_Type where Class_Type_ID="+str_Class_Type_ID;
			if(GetRowRecord(str_Sql)==false)return "";
			return  dr[what].ToString();
		}

		public  string School_IDtoWhat(string str_School_ID,string what)
		{
			string str_Sql="select "+what+" from School where School_ID="+str_School_ID;
			if(GetRowRecord(str_Sql)==false)return "";
			return  dr[what].ToString();
		}

		public  string QuXian_IDtoWhat(string str_QuXian_ID,string what)
		{
			string str_Sql="select "+what+" from QuXian where QuXian_ID="+str_QuXian_ID;
			if(GetRowRecord(str_Sql)==false)return "";
			return  dr[what].ToString();
		}

		public  string Office_IDtoWhat(string str_Office_ID,string what)
		{
			string str_Sql="select "+what+" from Office where Office_ID="+str_Office_ID;
			if(GetRowRecord(str_Sql)==false)return "";
			return  dr[what].ToString();
		}
		public  string Class_IDtoWhat(string str_Calss_ID,string what)
		{
			string str_Sql="select "+what+" from Class where Class_ID="+str_Calss_ID;
			if(GetRowRecord(str_Sql)==false)return "";
			return  dr[what].ToString();
		}
		public  string Student_IDtoWhat(string str_Student_ID,string what)
		{
			string str_Sql="select "+what+" from View_StudentClass where Student_ID='"+str_Student_ID+"'";
			if(GetRowRecord(str_Sql)==false)return "";
			return  dr[what].ToString();
		}
		public  bool Student_ID_Had(string str_Student_ID)
		{
			string str_Sql="select * from Student where Student_ID='"+str_Student_ID+"'";
			//if(GetRowRecord(str_Sql)==false)return false;
			if(GetRowCount(str_Sql)==0)return false;
			return true;
		}

		public  bool UserName_Had(string str_UserName)
		{
			string str_Sql="select * from Users where UserName='"+str_UserName+"'";
			//if(GetRowRecord(str_Sql)==false)return false;
			if(GetRowCount(str_Sql)==0)
				return false;
			return true;
		}

		//判断有效日期
		public bool ValidDate(decimal intYear,decimal intMonth,decimal intDate)
		{
			switch ((int)intMonth)
			{
				case 4:
					if(intDate>30)return false;
					break;
				case 6:
					if(intDate>30)return false;
					break;
				case 9:
					if(intDate>30)return false;
					break;
				case 11:
					if(intDate>30)return false;
					break;
				case 2:
					if(intDate>29)return false;
					if(intDate>28&&(!((intYear%400==0)||((intYear%4==0)&&(intYear%100!=0)))))return false;
				return true;
			}
			return true;
		}

		/// <summary>
		/// 获得某个字符串在另个字符串第一次出现时前面所有字符
		/// </summary>
		/// <param name="strOriginal">要处理的字符</param>
		/// <param name="strSymbol">符号</param>
		/// <returns>返回值</returns>
		public string GetFirstStr(string strOriginal,string strSymbol)
		{
			int strPlace=strOriginal.IndexOf(strSymbol);
			if (strPlace!=-1)
				strOriginal=strOriginal.Substring(0,strPlace);
			return strOriginal;
		}

		/// <summary>
		/// 获得某个字符串在另个字符串最后一次出现时后面所有字符
		/// </summary>
		/// <param name="strOriginal">要处理的字符</param>
		/// <param name="strSymbol">符号</param>
		/// <returns>返回值</returns>
		public string GetLastStr(string strOriginal,string strSymbol)
		{
			int strPlace=strOriginal.LastIndexOf(strSymbol)+strSymbol.Length;
			strOriginal=strOriginal.Substring(strPlace);
			return strOriginal;
		}

		/// <summary>
		/// 获得某个字符串在另个字符串最后一次出现时前面所有字符
		/// </summary>
		public string GetLastStrFront(string strOriginal,string strSymbol)
		{
			int strPlace=strOriginal.LastIndexOf(strSymbol);
			strOriginal=strOriginal.Substring(0,strPlace);
			return strOriginal;
						
		}

		/// <summary>
		/// 返回yyyy-mm-dd hh:mm.ss时间型的year,month,date
		/// </summary>		
		public string GetYMD(string ymd,string what)
		{
			//"1980-7-15 1:02:03"
			if(what=="year")return GetFirstStr(ymd,"-");
			if(what=="month")return GetLastStr(GetLastStrFront(ymd,"-"),"-");
			if(what=="date")return GetFirstStr(GetLastStr(ymd,"-")," ");

			if(what=="hour")return GetLastStr(GetLastStrFront(GetLastStrFront(ymd,":"),":")," ");
			if(what=="minute")return GetLastStr(GetLastStrFront(ymd,":"),":");
			if(what=="second")return GetLastStr(ymd,":");
			
			return ymd;
		}

		/// <summary>
		/// 绑定DataGrid控件并显示数据
		/// </summary>
		/// <param name="str_Sql">Select-SQL语句</param>
		/// <param name="mydatagrid">DataGrid控件id值</param>
		public void BindDataGrid(string str_Sql,DataGrid mydatagrid)
		{
			Fill(str_Sql);
			mydatagrid.DataSource=ds.Tables[0].DefaultView;
			mydatagrid.DataBind();
			//myConnection.Close();
		}

		/// <summary>
		/// 去掉'"?%=空格
		/// </summary>
		/// <param name="strOriginal">要处理的字符</param>
		/// <returns>返回值</returns>
		public string KickOut(string strOriginal)
		{
			strOriginal=strOriginal.Replace("\"","");
			strOriginal=strOriginal.Replace("'","");
			strOriginal=strOriginal.Replace(" ","");
			strOriginal=strOriginal.Replace("?","");
			strOriginal=strOriginal.Replace("%","");
			strOriginal=strOriginal.Replace("=","");
			return strOriginal;
		}

		/// <summary>
		/// 查找是否存在'"?%=空格
		/// </summary>
		/// <param name="strOriginal">要处理的字符</param>
		/// <returns>返回值</returns>
		public bool Sniffer_In(string strOriginal)
		{
			if(strOriginal.IndexOf("\"")!=-1)return true;
			if(strOriginal.IndexOf("'")!=-1)return true;
			if(strOriginal.IndexOf(" ")!=-1)return true;
			if(strOriginal.IndexOf("?")!=-1)return true;
			if(strOriginal.IndexOf("%")!=-1)return true;
			if(strOriginal.IndexOf("=")!=-1)return true;
			return false;
		}

		/// <summary>
		/// 出错时弹出提示对话框
		/// </summary>
		/// <param name="str_Prompt">提示信息</param>
		/// <param name="lbl_Error">Label控件id值</param>
		public void JsIsNull(string str_Prompt,Label lbl_Error)
		{
			lbl_Error.Text="<script language=\"javascript\">alert('"+str_Prompt+"');</"+"script>"; 
		}

	}
}
