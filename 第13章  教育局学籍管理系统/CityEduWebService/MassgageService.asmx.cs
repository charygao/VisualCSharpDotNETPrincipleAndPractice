using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Text;

namespace CityEduWebService
{
	/// <summary>
	/// MassgageService 的摘要说明。
	/// </summary>
	public class MassgageService : System.Web.Services.WebService
	{
		
		protected config conn=new config();
		private string[] ArraytSql=new String[1111];

		public MassgageService()
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
		public string DataBaseModifyToSchool()//返回修改数据库的Sql语句
		{
			string str_Sql="";
			StreamReader sr = new StreamReader(Server.MapPath(".")+"\\修改数据库.sql",Encoding.GetEncoding("gb2312"));
			
			try	{str_Sql="\r\n"+sr.ReadToEnd()+"\r\n";}
			catch{//对话框
			}
			try{sr.Close();}
			catch{//对话框
			}
			
			return  str_Sql;
		}
	}
}
