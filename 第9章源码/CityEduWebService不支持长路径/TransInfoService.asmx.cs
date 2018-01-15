using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Text;
using System.Data.OleDb;
using System.Configuration;

namespace CityEduWebService
{
	/// <summary>
	/// TransInfoService 的摘要说明。
	/// </summary>
	public class TransInfoService : System.Web.Services.WebService
	{		
		protected config conn=new config();

		public TransInfoService()
		{
			//CODEGEN: 该调用是 ASP.NET Web 服务设计器所必需的
			InitializeComponent();
		}

		#region 组件设计器生成的代码
		
		//Web 服务设计器所必需的
		private IContainer components = null;
				
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		// WEB 服务示例
		// HelloWorld() 示例服务返回字符串 Hello World
		// 若要生成，请取消注释下列行，然后保存并生成项目
		// 若要测试此 Web 服务，请按 F5 键
		[WebMethod]
		public int School_Receive(DataSet dsReceived)
		{
			int iCount = dsReceived.Tables[0].Rows.Count; //传来的DataSet中的记录总数
			int iSuccessCount = 0; //返回成功处理的记录数
			string errorstring,str_Sql="";
			
			try
			{				
				//一条一条存入中心数据库
				for(int i=0;i<iCount;i++)
				{
					//用户应该先调用School_Receive,以上传学校信息,上传前删除所有School_ID相关信息:学校,班级,学生
					str_Sql="Delete From Student WHERE School_ID='"+Convert.ToString(dsReceived.Tables[0].Rows[0]["School_ID"])+"'";
					errorstring=conn.ExeSql(str_Sql);

					str_Sql="Delete From Class WHERE School_ID='"+Convert.ToString(dsReceived.Tables[0].Rows[0]["School_ID"])+"'";
					errorstring=conn.ExeSql(str_Sql);
	
					str_Sql="Delete From Teacher WHERE School_ID='"+Convert.ToString(dsReceived.Tables[0].Rows[0]["School_ID"])+"'";
					errorstring=conn.ExeSql(str_Sql);

					str_Sql="Delete From School WHERE School_ID='"+Convert.ToString(dsReceived.Tables[0].Rows[0]["School_ID"])+"'";
					errorstring=conn.ExeSql(str_Sql);

					str_Sql="insert into School (School_ID,School_Name,School_Type_ID,Schoolmaster,School_Tel,School_Zip,School_Address,QuXian_Code) VALUES (";

					//构造参数
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_ID"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_Name"])+"',";
					str_Sql=str_Sql+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_Type_ID"])+",";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Schoolmaster"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_Tel"])+"',";
					str_Sql=str_Sql+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_Zip"])+",";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_Address"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["QuXian_Code"])+"')";

					errorstring=conn.ExeSql(str_Sql);
					if(errorstring=="OK")
					{
						iSuccessCount ++;
					}					
				}
			}
			catch(SqlException e)
			{
				string s = e.Message;
				
				//若出现错误，直接返回已经成功上传的记录数
				return iSuccessCount;
			}
			finally
			{
				conn.Close();					
			}	
			
			//返回成功上传的记录数
			return iSuccessCount;
		}

		[WebMethod]
		public int Class_Receive(DataSet dsReceived)
		{
			int iCount = dsReceived.Tables[0].Rows.Count; //传来的DataSet中的记录总数
			int iSuccessCount = 0; //返回成功处理的记录数
			
			string errorstring,str_Sql="";
			
			try
			{				
				//一条一条存入中心数据库
				for(int i=0;i<iCount;i++)
				{					
					str_Sql="INSERT INTO Class (Class_ID,School_ID,Class_Type_ID,Class_Name,TeacherInCharge) values(";

					//构造参数
					str_Sql=str_Sql+Convert.ToString(dsReceived.Tables[0].Rows[i]["Class_ID"])+",";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_ID"])+"',";
					str_Sql=str_Sql+Convert.ToString(dsReceived.Tables[0].Rows[i]["Class_Type_ID"])+",";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Class_Name"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["TeacherInCharge"])+"')";
                    
					errorstring=conn.ExeSql(str_Sql);
					if(errorstring=="OK")
					{
						iSuccessCount ++;
					}					
				}
			}
			catch(SqlException e)
			{
				string s = e.Message;
				//若出现错误，直接返回已经成功上传的记录数
				return iSuccessCount;
			}
			finally
			{
				conn.Close();					
			}	
			
			//返回成功上传的记录数
			return iSuccessCount;
		}

		[WebMethod]
		public int Student_Receive(DataSet dsReceived)
		{
			int iCount = dsReceived.Tables[0].Rows.Count; //传来的DataSet中的记录总数
			int iSuccessCount = 0; //返回成功处理的记录数
			
			string errorstring,str_Sql="";
			
			try
			{				
				//一条一条存入中心数据库
				for(int i=0;i<iCount;i++)
				{
					str_Sql="insert into Student (School_ID,Student_ID,Class_ID,Name,Birthday,Sex,Father,Mother,Keeper,StudentTel,QuXian_ID,Office_ID,Committee_ID,Student_Address,Father_Job,Father_XueLi,Mother_Job,Mother_XueLi) VALUES (";
			
					//构造参数
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_ID"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Student_ID"])+"',";
					str_Sql=str_Sql+Convert.ToString(dsReceived.Tables[0].Rows[i]["Class_ID"])+",";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Name"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Birthday"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Sex"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Father"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Mother"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Keeper"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["StudentTel"])+"',";
					str_Sql=str_Sql+Convert.ToString(dsReceived.Tables[0].Rows[i]["QuXian_ID"])+",";
					str_Sql=str_Sql+Convert.ToString(dsReceived.Tables[0].Rows[i]["Office_ID"])+",";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Committee_ID"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Student_Address"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Father_Job"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Father_XueLi"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Mother_Job"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Mother_XueLi"])+"')";
			
					errorstring=conn.ExeSql(str_Sql);
					if(errorstring=="OK")
					{
						iSuccessCount ++;
					}					
				}
			}
			catch(SqlException e)
			{
				string s = e.Message;
				
				//若出现错误，直接返回已经成功上传的记录数
				return iSuccessCount;
			}
			finally
			{
				conn.Close();					
			}	
			
			//返回成功上传的记录数
			return iSuccessCount;
		}

		[WebMethod]
		public int Teacher_Receive(DataSet dsReceived)
		{
			int iCount = dsReceived.Tables[0].Rows.Count; //传来的DataSet中的记录总数
			int iSuccessCount = 0; //返回成功处理的记录数
			
			string errorstring,str_Sql="";
			
			try
			{				
				//一条一条存入中心数据库
				for(int i=0;i<iCount;i++)
				{
					str_Sql="insert into Teacher (School_ID,Teacher_ID,Name,Birthday,WorkTime,Sex,SchoolType,PostCan,PostIn,SchoolGrad,GradTime,SpecialIn,InWorkSheet,IsFullTime,LessonTeach) values (";
			
					//构造参数
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["School_ID"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Teacher_ID"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Name"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Birthday"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["WorkTime"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["Sex"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["SchoolType"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["PostCan"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["PostIn"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["SchoolGrad"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["GradTime"])+"',";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["SpecialIn"])+"',";
					if(Convert.ToString(dsReceived.Tables[0].Rows[i]["InWorkSheet"])=="True")
						str_Sql=str_Sql+"1,";
					else
						str_Sql=str_Sql+"0,";
					if(Convert.ToString(dsReceived.Tables[0].Rows[i]["IsFullTime"])=="True")
						str_Sql=str_Sql+"1,";
					else
						str_Sql=str_Sql+"0,";
					str_Sql=str_Sql+"'"+Convert.ToString(dsReceived.Tables[0].Rows[i]["LessonTeach"])+"')";
				
					errorstring=conn.ExeSql(str_Sql);
					if(errorstring=="OK")
					{
						iSuccessCount ++;
					}					
				}
			}
			catch(SqlException e)
			{
				string s = e.Message;
				
				//若出现错误，直接返回已经成功上传的记录数
				return iSuccessCount;
			}
			finally
			{
				conn.Close();					
			}	
			
			//返回成功上传的记录数
			return iSuccessCount;
		}
	}
}
