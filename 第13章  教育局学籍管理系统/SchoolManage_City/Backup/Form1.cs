using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;

namespace SchoolManage
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem_In;
		private System.Windows.Forms.MenuItem menuItem_System;
		private System.Windows.Forms.MenuItem menuItem_Browse;
		private System.Windows.Forms.MenuItem menuItem_BrowseSchool;
		private System.Windows.Forms.MenuItem menuItem_SearchBrowseStudent;
		private System.Windows.Forms.MenuItem menuItem_BrowseClass;
		private System.Windows.Forms.MenuItem menuItem_Modify;
		private System.Windows.Forms.MenuItem menuItem_ModifySchool;
		private System.Windows.Forms.MenuItem menuItem_maintenanceSchoolType;
		private System.Windows.Forms.MenuItem menuItem_maintenanceClassType;
		private System.Windows.Forms.MenuItem menuItem_maintenanceXianqu;
		private System.Windows.Forms.MenuItem menuItem_maintenanceOffice;
		private System.Windows.Forms.MenuItem menuItem_maintenanceCommittee;
		private System.Windows.Forms.MenuItem menuItem_maintenanceType;
		private System.Windows.Forms.MenuItem menuItem_Data;
		private System.Windows.Forms.MenuItem menuItem_BackupDB;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem_AddSchool_Type;
		private System.Windows.Forms.MenuItem menuItem_AddClass_Type;
		private System.Windows.Forms.MenuItem menuItem_AddQuXian;
		private System.Windows.Forms.MenuItem menuItem_Add_Office;
		private System.Windows.Forms.MenuItem menuItem_Add_Committee;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem_RestoreDB;
		private System.Windows.Forms.MenuItem menuItem_BrowseStudent;
		private System.Windows.Forms.MenuItem menuItem_AddSchool;
		private System.Windows.Forms.MenuItem menuItem6;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.MenuItem menuItem_LocationDBBackup;
		private System.Windows.Forms.MenuItem menuItem_ModifyUser;
		private System.Windows.Forms.MenuItem menuItem_AddUser;
		private System.Windows.Forms.MenuItem menuItem_DeleteUser;
		private System.Windows.Forms.MenuItem menuItem_DataIn;
		private System.Windows.Forms.MenuItem menuItem_DeleteOld;
		private System.Windows.Forms.MenuItem menuItem_BrowseTeacher;
		private System.Windows.Forms.MenuItem menuItem_DataOut;
		private System.Windows.Forms.MenuItem menuItem_QuXianDataIn;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem_StatisticsStudent;
		private System.Windows.Forms.MenuItem menuItem_StatisticsTeacher;
		private System.Windows.Forms.MenuItem menuItem_StatisticsClass;
		private System.Windows.Forms.MenuItem menuItem_StatisticsSchool;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem_StatisticsClass_City;
		private System.Windows.Forms.MenuItem menuItem_StatisticsStudent_City;
		private System.Windows.Forms.MenuItem menuItem_StatisticsTeacher_City;
		private System.Windows.Forms.MenuItem menuItem_StatisticsSchool_QuXian;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem_StatisticsTeacher_QuXian;
		private System.Windows.Forms.MenuItem menuItem_StatisticsClass_QuXian;
		private System.Windows.Forms.MenuItem menuItem_StatisticsStudent_QuXian;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem_SchoolPassword;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem_StudentTeacherCount;
		private System.Windows.Forms.MenuItem menuItem_ModifySchool_ID;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem_QuXian_Office_Committee;
		private System.Windows.Forms.MenuItem menuItem_SearchSchool;
		private System.Windows.Forms.MenuItem menuItem_SearchTeacher;
		private System.Windows.Forms.MenuItem menuItem_NonlegalData;
		private System.Windows.Forms.MenuItem menuItem_DeleteManyOld;
		private System.Windows.Forms.MenuItem menuItem_QuXianDataOut;
		
		protected config conn=new config();

		public Form1(string str_User_login)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			/*区县用户看不到的
			menuItem_StatisticsSchool_QuXian.Visible=false;
			menuItem_StatisticsTeacher_QuXian.Visible=false;
			menuItem_StatisticsClass_QuXian.Visible=false;
			menuItem_StatisticsStudent_QuXian.Visible=false;
			menuItem_maintenanceType.Visible=false;*/

			//只读用户看不到的
			if(conn.UserName_ToWhat(str_User_login,"ReadOnly")=="True")
			{			
				menuItem_System.Visible=false;
				menuItem_In.Visible=false;
				menuItem_Modify.Visible=false;
				menuItem_Data.Visible=false;
				menuItem_maintenanceType.Visible=false;
			}
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem_System = new System.Windows.Forms.MenuItem();
			this.menuItem_AddUser = new System.Windows.Forms.MenuItem();
			this.menuItem_ModifyUser = new System.Windows.Forms.MenuItem();
			this.menuItem_DeleteUser = new System.Windows.Forms.MenuItem();
			this.menuItem_In = new System.Windows.Forms.MenuItem();
			this.menuItem_AddSchool = new System.Windows.Forms.MenuItem();
			this.menuItem_Browse = new System.Windows.Forms.MenuItem();
			this.menuItem_BrowseSchool = new System.Windows.Forms.MenuItem();
			this.menuItem_BrowseClass = new System.Windows.Forms.MenuItem();
			this.menuItem_BrowseStudent = new System.Windows.Forms.MenuItem();
			this.menuItem_BrowseTeacher = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem_SearchSchool = new System.Windows.Forms.MenuItem();
			this.menuItem_SearchTeacher = new System.Windows.Forms.MenuItem();
			this.menuItem_SearchBrowseStudent = new System.Windows.Forms.MenuItem();
			this.menuItem_Modify = new System.Windows.Forms.MenuItem();
			this.menuItem_ModifySchool = new System.Windows.Forms.MenuItem();
			this.menuItem_ModifySchool_ID = new System.Windows.Forms.MenuItem();
			this.menuItem_Data = new System.Windows.Forms.MenuItem();
			this.menuItem_LocationDBBackup = new System.Windows.Forms.MenuItem();
			this.menuItem_BackupDB = new System.Windows.Forms.MenuItem();
			this.menuItem_RestoreDB = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem_DeleteOld = new System.Windows.Forms.MenuItem();
			this.menuItem_DeleteManyOld = new System.Windows.Forms.MenuItem();
			this.menuItem_DataIn = new System.Windows.Forms.MenuItem();
			this.menuItem_QuXianDataIn = new System.Windows.Forms.MenuItem();
			this.menuItem_DataOut = new System.Windows.Forms.MenuItem();
			this.menuItem_QuXianDataOut = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsClass = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsStudent = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsTeacher = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsSchool = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsClass_City = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsStudent_City = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsTeacher_City = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsSchool_QuXian = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsTeacher_QuXian = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsClass_QuXian = new System.Windows.Forms.MenuItem();
			this.menuItem_StatisticsStudent_QuXian = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem_QuXian_Office_Committee = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem_NonlegalData = new System.Windows.Forms.MenuItem();
			this.menuItem_StudentTeacherCount = new System.Windows.Forms.MenuItem();
			this.menuItem_maintenanceType = new System.Windows.Forms.MenuItem();
			this.menuItem_AddSchool_Type = new System.Windows.Forms.MenuItem();
			this.menuItem_AddClass_Type = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem_maintenanceSchoolType = new System.Windows.Forms.MenuItem();
			this.menuItem_maintenanceClassType = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem_AddQuXian = new System.Windows.Forms.MenuItem();
			this.menuItem_Add_Office = new System.Windows.Forms.MenuItem();
			this.menuItem_Add_Committee = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem_maintenanceXianqu = new System.Windows.Forms.MenuItem();
			this.menuItem_maintenanceOffice = new System.Windows.Forms.MenuItem();
			this.menuItem_maintenanceCommittee = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem_SchoolPassword = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem_System,
																					  this.menuItem_In,
																					  this.menuItem_Browse,
																					  this.menuItem_Modify,
																					  this.menuItem_Data,
																					  this.menuItem1,
																					  this.menuItem_maintenanceType});
			// 
			// menuItem_System
			// 
			this.menuItem_System.Index = 0;
			this.menuItem_System.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.menuItem_AddUser,
																							this.menuItem_ModifyUser,
																							this.menuItem_DeleteUser});
			this.menuItem_System.Text = "用户管理";
			// 
			// menuItem_AddUser
			// 
			this.menuItem_AddUser.Index = 0;
			this.menuItem_AddUser.Text = "添加用户";
			this.menuItem_AddUser.Click += new System.EventHandler(this.menuItem_AddUser_Click);
			// 
			// menuItem_ModifyUser
			// 
			this.menuItem_ModifyUser.Index = 1;
			this.menuItem_ModifyUser.Text = "修改用户";
			this.menuItem_ModifyUser.Click += new System.EventHandler(this.menuItem_ModifyUser_Click);
			// 
			// menuItem_DeleteUser
			// 
			this.menuItem_DeleteUser.Index = 2;
			this.menuItem_DeleteUser.Text = "删除用户";
			this.menuItem_DeleteUser.Click += new System.EventHandler(this.menuItem_DeleteUser_Click);
			// 
			// menuItem_In
			// 
			this.menuItem_In.Index = 1;
			this.menuItem_In.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.menuItem_AddSchool});
			this.menuItem_In.Text = "录入添加";
			// 
			// menuItem_AddSchool
			// 
			this.menuItem_AddSchool.Index = 0;
			this.menuItem_AddSchool.Text = "录入学校信息";
			this.menuItem_AddSchool.Click += new System.EventHandler(this.menuItem_AddSchool_Click);
			// 
			// menuItem_Browse
			// 
			this.menuItem_Browse.Index = 2;
			this.menuItem_Browse.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.menuItem_BrowseSchool,
																							this.menuItem_BrowseClass,
																							this.menuItem_BrowseStudent,
																							this.menuItem_BrowseTeacher,
																							this.menuItem6,
																							this.menuItem_SearchSchool,
																							this.menuItem_SearchTeacher,
																							this.menuItem_SearchBrowseStudent});
			this.menuItem_Browse.Text = "查询浏览";
			// 
			// menuItem_BrowseSchool
			// 
			this.menuItem_BrowseSchool.Index = 0;
			this.menuItem_BrowseSchool.Text = "浏览学校信息";
			this.menuItem_BrowseSchool.Click += new System.EventHandler(this.menuItem_BrowseSchool_Click);
			// 
			// menuItem_BrowseClass
			// 
			this.menuItem_BrowseClass.Index = 1;
			this.menuItem_BrowseClass.Text = "浏览班级信息";
			this.menuItem_BrowseClass.Click += new System.EventHandler(this.menuItem_BrowseClass_Click);
			// 
			// menuItem_BrowseStudent
			// 
			this.menuItem_BrowseStudent.Index = 2;
			this.menuItem_BrowseStudent.Text = "浏览学生信息";
			this.menuItem_BrowseStudent.Click += new System.EventHandler(this.menuItem_BrowseStudent_Click);
			// 
			// menuItem_BrowseTeacher
			// 
			this.menuItem_BrowseTeacher.Index = 3;
			this.menuItem_BrowseTeacher.Text = "浏览教师信息";
			this.menuItem_BrowseTeacher.Click += new System.EventHandler(this.menuItem_BrowseTeacher_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 4;
			this.menuItem6.Text = "-";
			// 
			// menuItem_SearchSchool
			// 
			this.menuItem_SearchSchool.Index = 5;
			this.menuItem_SearchSchool.Text = "查询学校信息";
			this.menuItem_SearchSchool.Click += new System.EventHandler(this.menuItem_SearchSchool_Click);
			// 
			// menuItem_SearchTeacher
			// 
			this.menuItem_SearchTeacher.Index = 6;
			this.menuItem_SearchTeacher.Text = "查询教师信息";
			this.menuItem_SearchTeacher.Click += new System.EventHandler(this.menuItem_SearchTeacher_Click);
			// 
			// menuItem_SearchBrowseStudent
			// 
			this.menuItem_SearchBrowseStudent.Index = 7;
			this.menuItem_SearchBrowseStudent.Text = "查询学生信息";
			this.menuItem_SearchBrowseStudent.Click += new System.EventHandler(this.menuItem_SearchBrowseStudent_Click);
			// 
			// menuItem_Modify
			// 
			this.menuItem_Modify.Index = 3;
			this.menuItem_Modify.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.menuItem_ModifySchool,
																							this.menuItem_ModifySchool_ID});
			this.menuItem_Modify.Text = "修改";
			// 
			// menuItem_ModifySchool
			// 
			this.menuItem_ModifySchool.Index = 0;
			this.menuItem_ModifySchool.Text = "修改学校信息";
			this.menuItem_ModifySchool.Click += new System.EventHandler(this.menuItem_ModifySchool_Click);
			// 
			// menuItem_ModifySchool_ID
			// 
			this.menuItem_ModifySchool_ID.Index = 1;
			this.menuItem_ModifySchool_ID.Text = "修改学校代码";
			this.menuItem_ModifySchool_ID.Click += new System.EventHandler(this.menuItem_ModifySchool_ID_Click);
			// 
			// menuItem_Data
			// 
			this.menuItem_Data.Index = 4;
			this.menuItem_Data.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.menuItem_LocationDBBackup,
																						  this.menuItem_BackupDB,
																						  this.menuItem_RestoreDB,
																						  this.menuItem3,
																						  this.menuItem_DeleteOld,
																						  this.menuItem_DeleteManyOld,
																						  this.menuItem_DataIn,
																						  this.menuItem_QuXianDataIn,
																						  this.menuItem_DataOut,
																						  this.menuItem_QuXianDataOut});
			this.menuItem_Data.Text = "数据维护";
			// 
			// menuItem_LocationDBBackup
			// 
			this.menuItem_LocationDBBackup.Index = 0;
			this.menuItem_LocationDBBackup.Text = "数据库备份位置设定";
			this.menuItem_LocationDBBackup.Click += new System.EventHandler(this.menuItem_LocationDBBackup_Click);
			// 
			// menuItem_BackupDB
			// 
			this.menuItem_BackupDB.Index = 1;
			this.menuItem_BackupDB.Text = "备份本机数据";
			this.menuItem_BackupDB.Click += new System.EventHandler(this.menuItem_BackupDB_Click);
			// 
			// menuItem_RestoreDB
			// 
			this.menuItem_RestoreDB.Index = 2;
			this.menuItem_RestoreDB.Text = "恢复本机数据";
			this.menuItem_RestoreDB.Click += new System.EventHandler(this.menuItem_RestoreDB_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 3;
			this.menuItem3.Text = "-";
			// 
			// menuItem_DeleteOld
			// 
			this.menuItem_DeleteOld.Index = 4;
			this.menuItem_DeleteOld.Text = "删除旧信息";
			this.menuItem_DeleteOld.Click += new System.EventHandler(this.menuItem_DalataOld_Click);
			// 
			// menuItem_DeleteManyOld
			// 
			this.menuItem_DeleteManyOld.Index = 5;
			this.menuItem_DeleteManyOld.Text = "批量删除旧信息";
			this.menuItem_DeleteManyOld.Click += new System.EventHandler(this.menuItem_DeleteManyOld_Click);
			// 
			// menuItem_DataIn
			// 
			this.menuItem_DataIn.Index = 6;
			this.menuItem_DataIn.Text = "下级学校数据导入";
			this.menuItem_DataIn.Click += new System.EventHandler(this.menuItem_DataIn_Click);
			// 
			// menuItem_QuXianDataIn
			// 
			this.menuItem_QuXianDataIn.Index = 7;
			this.menuItem_QuXianDataIn.Text = "下级数据批量导入";
			this.menuItem_QuXianDataIn.Click += new System.EventHandler(this.menuItem_QuXianDataIn_Click);
			// 
			// menuItem_DataOut
			// 
			this.menuItem_DataOut.Index = 8;
			this.menuItem_DataOut.Text = "下级数据批量导出";
			this.menuItem_DataOut.Click += new System.EventHandler(this.menuItem_DataOut_Click);
			// 
			// menuItem_QuXianDataOut
			// 
			this.menuItem_QuXianDataOut.Index = 9;
			this.menuItem_QuXianDataOut.Text = "按区县批量导出";
			this.menuItem_QuXianDataOut.Click += new System.EventHandler(this.menuItem_QuXianDataOut_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 5;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem_StatisticsClass,
																					  this.menuItem_StatisticsStudent,
																					  this.menuItem_StatisticsTeacher,
																					  this.menuItem7,
																					  this.menuItem_StatisticsSchool,
																					  this.menuItem_StatisticsClass_City,
																					  this.menuItem_StatisticsStudent_City,
																					  this.menuItem_StatisticsTeacher_City,
																					  this.menuItem9,
																					  this.menuItem_StatisticsSchool_QuXian,
																					  this.menuItem_StatisticsClass_QuXian,
																					  this.menuItem_StatisticsStudent_QuXian,
																					  this.menuItem_StatisticsTeacher_QuXian,
																					  this.menuItem10,
																					  this.menuItem_QuXian_Office_Committee,
																					  this.menuItem8,
																					  this.menuItem_NonlegalData,
																					  this.menuItem_StudentTeacherCount});
			this.menuItem1.Text = "统计信息";
			// 
			// menuItem_StatisticsClass
			// 
			this.menuItem_StatisticsClass.Index = 0;
			this.menuItem_StatisticsClass.Text = "各学校班级信息统计";
			this.menuItem_StatisticsClass.Click += new System.EventHandler(this.menuItem_StatisticsClass_Click);
			// 
			// menuItem_StatisticsStudent
			// 
			this.menuItem_StatisticsStudent.Index = 1;
			this.menuItem_StatisticsStudent.Text = "各学校学生信息统计";
			this.menuItem_StatisticsStudent.Click += new System.EventHandler(this.menuItem_StatisticsStudent_Click);
			// 
			// menuItem_StatisticsTeacher
			// 
			this.menuItem_StatisticsTeacher.Index = 2;
			this.menuItem_StatisticsTeacher.Text = "各学校教师信息统计";
			this.menuItem_StatisticsTeacher.Click += new System.EventHandler(this.menuItem_StatisticsTeacher_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 3;
			this.menuItem7.Text = "-";
			// 
			// menuItem_StatisticsSchool
			// 
			this.menuItem_StatisticsSchool.Index = 4;
			this.menuItem_StatisticsSchool.Text = "本辖区学校信息统计";
			this.menuItem_StatisticsSchool.Click += new System.EventHandler(this.menuItem_StatisticsSchool_Click);
			// 
			// menuItem_StatisticsClass_City
			// 
			this.menuItem_StatisticsClass_City.Index = 5;
			this.menuItem_StatisticsClass_City.Text = "本辖区班级信息统计";
			this.menuItem_StatisticsClass_City.Click += new System.EventHandler(this.menuItem_StatisticsClass_City_Click);
			// 
			// menuItem_StatisticsStudent_City
			// 
			this.menuItem_StatisticsStudent_City.Index = 6;
			this.menuItem_StatisticsStudent_City.Text = "本辖区学生信息统计";
			this.menuItem_StatisticsStudent_City.Click += new System.EventHandler(this.menuItem_StatisticsStudent_City_Click);
			// 
			// menuItem_StatisticsTeacher_City
			// 
			this.menuItem_StatisticsTeacher_City.Index = 7;
			this.menuItem_StatisticsTeacher_City.Text = "本辖区教师信息统计";
			this.menuItem_StatisticsTeacher_City.Click += new System.EventHandler(this.menuItem_StatisticsTeacher_City_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 8;
			this.menuItem9.Text = "-";
			// 
			// menuItem_StatisticsSchool_QuXian
			// 
			this.menuItem_StatisticsSchool_QuXian.Index = 9;
			this.menuItem_StatisticsSchool_QuXian.Text = "各区县学校信息统计";
			this.menuItem_StatisticsSchool_QuXian.Click += new System.EventHandler(this.menuItem_StatisticsSchool_QuXian_Click);
			// 
			// menuItem_StatisticsTeacher_QuXian
			// 
			this.menuItem_StatisticsTeacher_QuXian.Index = 12;
			this.menuItem_StatisticsTeacher_QuXian.Text = "各区县教师信息统计";
			this.menuItem_StatisticsTeacher_QuXian.Click += new System.EventHandler(this.menuItem_StatisticsTeacher_QuXian_Click);
			// 
			// menuItem_StatisticsClass_QuXian
			// 
			this.menuItem_StatisticsClass_QuXian.Index = 10;
			this.menuItem_StatisticsClass_QuXian.Text = "各区县班级信息统计";
			this.menuItem_StatisticsClass_QuXian.Click += new System.EventHandler(this.menuItem_StatisticsClass_QuXian_Click);
			// 
			// menuItem_StatisticsStudent_QuXian
			// 
			this.menuItem_StatisticsStudent_QuXian.Index = 11;
			this.menuItem_StatisticsStudent_QuXian.Text = "各区县学生信息统计";
			this.menuItem_StatisticsStudent_QuXian.Click += new System.EventHandler(this.menuItem_StatisticsStudent_QuXian_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 13;
			this.menuItem10.Text = "-";
			// 
			// menuItem_QuXian_Office_Committee
			// 
			this.menuItem_QuXian_Office_Committee.Index = 14;
			this.menuItem_QuXian_Office_Committee.Text = " 分区县_办事处_社区统计";
			this.menuItem_QuXian_Office_Committee.Click += new System.EventHandler(this.menuItem_QuXian_Office_Committee_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 15;
			this.menuItem8.Text = "-";
			// 
			// menuItem_NonlegalData
			// 
			this.menuItem_NonlegalData.Index = 16;
			this.menuItem_NonlegalData.Text = "非法数据查询";
			this.menuItem_NonlegalData.Click += new System.EventHandler(this.menuItem_NonlegalData_Click);
			// 
			// menuItem_StudentTeacherCount
			// 
			this.menuItem_StudentTeacherCount.Index = 17;
			this.menuItem_StudentTeacherCount.Text = "预统计";
			this.menuItem_StudentTeacherCount.Click += new System.EventHandler(this.menuItem_StudentTeacherCount_Click);
			// 
			// menuItem_maintenanceType
			// 
			this.menuItem_maintenanceType.Index = 6;
			this.menuItem_maintenanceType.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																									 this.menuItem_AddSchool_Type,
																									 this.menuItem_AddClass_Type,
																									 this.menuItem4,
																									 this.menuItem_maintenanceSchoolType,
																									 this.menuItem_maintenanceClassType,
																									 this.menuItem2,
																									 this.menuItem_AddQuXian,
																									 this.menuItem_Add_Office,
																									 this.menuItem_Add_Committee,
																									 this.menuItem5,
																									 this.menuItem_maintenanceXianqu,
																									 this.menuItem_maintenanceOffice,
																									 this.menuItem_maintenanceCommittee,
																									 this.menuItem11,
																									 this.menuItem_SchoolPassword});
			this.menuItem_maintenanceType.Text = "类型维护";
			// 
			// menuItem_AddSchool_Type
			// 
			this.menuItem_AddSchool_Type.Index = 0;
			this.menuItem_AddSchool_Type.Text = "学校类别添加";
			this.menuItem_AddSchool_Type.Click += new System.EventHandler(this.menuItem_AddSchool_Type_Click);
			// 
			// menuItem_AddClass_Type
			// 
			this.menuItem_AddClass_Type.Index = 1;
			this.menuItem_AddClass_Type.Text = "班级类别添加";
			this.menuItem_AddClass_Type.Click += new System.EventHandler(this.menuItem_AddClass_Type_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "-";
			// 
			// menuItem_maintenanceSchoolType
			// 
			this.menuItem_maintenanceSchoolType.Index = 3;
			this.menuItem_maintenanceSchoolType.Text = "学校类别修改";
			this.menuItem_maintenanceSchoolType.Click += new System.EventHandler(this.menuItem_maintenanceSchoolType_Click);
			// 
			// menuItem_maintenanceClassType
			// 
			this.menuItem_maintenanceClassType.Index = 4;
			this.menuItem_maintenanceClassType.Text = "班级类别修改";
			this.menuItem_maintenanceClassType.Click += new System.EventHandler(this.menuItem_maintenanceClassType_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 5;
			this.menuItem2.Text = "-";
			// 
			// menuItem_AddQuXian
			// 
			this.menuItem_AddQuXian.Index = 6;
			this.menuItem_AddQuXian.Text = "区县添加";
			this.menuItem_AddQuXian.Click += new System.EventHandler(this.menuItem_AddQuXian_Click);
			// 
			// menuItem_Add_Office
			// 
			this.menuItem_Add_Office.Index = 7;
			this.menuItem_Add_Office.Text = "办事处添加";
			this.menuItem_Add_Office.Click += new System.EventHandler(this.menuItem_Add_Office_Click);
			// 
			// menuItem_Add_Committee
			// 
			this.menuItem_Add_Committee.Index = 8;
			this.menuItem_Add_Committee.Text = "居委会添加";
			this.menuItem_Add_Committee.Click += new System.EventHandler(this.menuItem_Add_Committee_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 9;
			this.menuItem5.Text = "-";
			// 
			// menuItem_maintenanceXianqu
			// 
			this.menuItem_maintenanceXianqu.Index = 10;
			this.menuItem_maintenanceXianqu.Text = "区县修改";
			this.menuItem_maintenanceXianqu.Click += new System.EventHandler(this.menuItem_maintenanceXianqu_Click);
			// 
			// menuItem_maintenanceOffice
			// 
			this.menuItem_maintenanceOffice.Index = 11;
			this.menuItem_maintenanceOffice.Text = "办事处修改";
			this.menuItem_maintenanceOffice.Click += new System.EventHandler(this.menuItem_maintenanceOffice_Click);
			// 
			// menuItem_maintenanceCommittee
			// 
			this.menuItem_maintenanceCommittee.Index = 12;
			this.menuItem_maintenanceCommittee.Text = "居委会修改";
			this.menuItem_maintenanceCommittee.Click += new System.EventHandler(this.menuItem_maintenanceCommittee_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 13;
			this.menuItem11.Text = "-";
			// 
			// menuItem_SchoolPassword
			// 
			this.menuItem_SchoolPassword.Index = 14;
			this.menuItem_SchoolPassword.Text = "密码生成器";
			this.menuItem_SchoolPassword.Click += new System.EventHandler(this.menuItem_SchoolPassword_Click_1);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(792, 545);
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "教育统计质量监控系统－教委版";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

		}
		#endregion

		private void menuItem_InSchool_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			InSchool child_InSchool=new InSchool();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_maintenanceSchoolType_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			maintenanceSchoolType child_InSchool=new maintenanceSchoolType();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		
		}

		private void menuItem_maintenanceClassType_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			maintenanceClassType child_InSchool=new maintenanceClassType();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_AddSchool_Type_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				 this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			 }

			AddSchool_Type child_InSchool=new AddSchool_Type();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		
		}

		private void menuItem_AddClass_Type_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				 this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			 }

			AddClass_Type child_InSchool=new AddClass_Type();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		
		}

		private void menuItem_AddQuXian_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
			 this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			 }

			AddQuXian child_InSchool=new AddQuXian();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		
		}

		private void menuItem_maintenanceXianqu_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			maintenanceXianqu child_InSchool=new maintenanceXianqu();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_maintenanceOffice_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			maintenanceOffice child_InSchool=new maintenanceOffice();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_AddSchool_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			InSchool child_InSchool=new InSchool();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_Add_Office_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			Add_Office child_InSchool=new Add_Office();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		
		}

		private void menuItem_BrowseSchool_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			BrowseSchool child_InSchool=new BrowseSchool();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_BrowseClass_Click(object sender, System.EventArgs e)
		{
			string str_Sql="Select * from School"; 
			if(conn.GetRowCount(str_Sql)==0)
			{
				MessageBox.Show("请先输入学校信息！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			BrowseClass child_InSchool=new BrowseClass();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_BrowseStudent_Click(object sender, System.EventArgs e)
		{
			string str_Sql="Select * from Class"; 
			if(conn.GetRowCount(str_Sql)==0)
			{
				MessageBox.Show("请先输入班级信息！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			BrowseStudent child_InSchool=new BrowseStudent();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();		
		}

		private void menuItem_SearchBrowseStudent_Click(object sender, System.EventArgs e)
		{
			string str_Sql="Select * from Class"; 
			if(conn.GetRowCount(str_Sql)==0)
			{
				MessageBox.Show("请先输入班级信息！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			SearchBrowseStudent child_InSchool=new SearchBrowseStudent();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();		
		}

		private void menuItem_ModifySchool_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			ModifySchool child_InSchool=new ModifySchool();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_DBSet_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			DBSet child_InSchool=new DBSet();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		
		}

		//数据库备份
		private void menuItem_BackupDB_Click(object sender, System.EventArgs e)
		{
			string str_LocationDBBackup="";
			string str_Sql,errorstring;

			try
			{
				string path="SchoolManage.exe.config";
				XmlDocument xd=new XmlDocument();
				xd.Load(path);
				foreach(XmlNode xn1 in xd.SelectNodes("/configuration/appSettings/add"))
				{
					if(xn1.Attributes["key"].Value=="DatabaseBackup")
					{
						str_LocationDBBackup=xn1.Attributes["value"].Value;
						break;
					}
				}
			}
			catch
			{
				//return false;
				throw new Exception("Config设置文件读取失败！");
			}
			//备份文件命名原则:备份时间yyyy-mm-dd hh-mm-ss-对教育统计质量监控系统的数据备份.bak
			//str_Sql="Select * FROM School";
			//conn.GetRowRecord(str_Sql);
			//string str_School_ID=conn.dr["School_ID"].ToString();
			//string str_School_Name=conn.School_IDtoWhat(str_School_ID,"School_Name");
			str_Sql="backup database "+ConfigurationSettings.AppSettings["Database"]
				+" TO disk='"+str_LocationDBBackup+"\\在"+System.DateTime.Now.ToString().Replace(":","-")+"对教育统计质量监控系统的数据备份.bak'";
			
			try
			{
				//errorstring=conn.ExeSql(str_Sql);
				errorstring=conn.DBRestore(str_Sql);
			}
			catch
			{				
				MessageBox.Show("备份失败！", "提醒！",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				conn.Close();
			}
			
			MessageBox.Show("成功备份于  "+str_LocationDBBackup+" ！", "提醒！",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void menuItem_LocationDBBackup_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			LocationDBBackup child_InSchool=new LocationDBBackup();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();			
		}

		private void menuItem_RestoreDB_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			RestoreDB child_InSchool=new RestoreDB();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();		
		}

		private void menuItem_ModifyUser_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			ModifyUser child_InSchool=new ModifyUser();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		
		}

		private void menuItem_AddUser_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			AddUser child_InSchool=new AddUser();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_DeleteUser_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			DeleteUser child_InSchool=new DeleteUser();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_DataIn_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			DataIn child_InSchool=new DataIn();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_SchoolPassword_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			SchoolPassword child_InSchool=new SchoolPassword();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_Add_Committee_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			Add_Committee child_InSchool=new Add_Committee();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_maintenanceCommittee_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			maintenanceCommittee child_InSchool=new maintenanceCommittee();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_DalataOld_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			DeleteOld child_InSchool=new DeleteOld();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		
		}

		private void menuItem_BrowseTeacher_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			BrowseTeacher child_InSchool=new BrowseTeacher();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_DataOut_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			DataOut child_InSchool=new DataOut();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_QuXianDataIn_Click(object sender, System.EventArgs e)
		{		
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			QuXianDataIn child_InSchool=new QuXianDataIn();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_StatisticsStudent_Click(object sender, System.EventArgs e)
		{			
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			StatisticsStudent child_InSchool=new StatisticsStudent();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_StatisticsTeacher_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			StatisticsTeacher child_InSchool=new StatisticsTeacher();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_StatisticsClass_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			StatisticsClass child_InSchool=new StatisticsClass();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_StatisticsSchool_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			StatisticsSchool child_InSchool=new StatisticsSchool();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_StatisticsClassInCity_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			//StatisticsClassInCity child_InSchool=new StatisticsClassInCity();
			//child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			//child_InSchool.Show();
		}

		private void menuItem_StatisticsTeacher_City_Click(object sender, System.EventArgs e)
		{		
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			StatisticsTeacher_City child_InSchool=new StatisticsTeacher_City();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_StatisticsStudent_City_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			StatisticsStudent_City child_InSchool=new StatisticsStudent_City();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_StatisticsClass_City_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			StatisticsClass_City child_InSchool=new StatisticsClass_City();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_StatisticsSchool_QuXian_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			StatisticsSchool_QuXian child_InSchool=new StatisticsSchool_QuXian();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		
		}

		private void menuItem_StatisticsTeacher_QuXian_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			StatisticsTeacher_QuXian child_InSchool=new StatisticsTeacher_QuXian();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_StatisticsClass_QuXian_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			StatisticsClass_QuXian child_InSchool=new StatisticsClass_QuXian();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_StatisticsStudent_QuXian_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			StatisticsStudent_QuXian child_InSchool=new StatisticsStudent_QuXian();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();		
		}

		private void menuItem_SchoolPassword_Click_1(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			SchoolPassword child_InSchool=new SchoolPassword();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();		
		}

		private void menuItem_StudentTeacherCount_Click(object sender, System.EventArgs e)
		{
			//学生人数统计
			string str_Sql="select School_ID,Count(Student_ID) AS Student_Count FROM Student Group By School_ID";
			string errorstring=conn.Fill(str_Sql);

			int SchoolCount=conn.ds.Tables[0].Rows.Count;
			for(int indexSchool=0;indexSchool<SchoolCount;indexSchool++)
			{
				conn.dr=conn.ds.Tables[0].Rows[indexSchool];
				
				str_Sql="Update School Set Student_Count="+conn.dr["Student_Count"].ToString()
					+" Where School_ID='"+conn.dr["School_ID"].ToString()+"'";
				errorstring=conn.ExeSql(str_Sql);
			}

			//教师人数统计
			str_Sql="select School_ID,Count(Teacher_ID) AS Teacher_Count FROM Teacher Group By School_ID";
			errorstring=conn.Fill(str_Sql);
			
			SchoolCount=conn.ds.Tables[0].Rows.Count;
			for(int indexSchool=0;indexSchool<SchoolCount;indexSchool++)
			{
				conn.dr=conn.ds.Tables[0].Rows[indexSchool];
			
				str_Sql="Update School Set Teacher_Count="+conn.dr["Teacher_Count"].ToString()
					+" Where School_ID='"+conn.dr["School_ID"].ToString()+"'";
				errorstring=conn.ExeSql(str_Sql);

				//学校区域码填充
				str_Sql="Update School Set QuXian_Code='"+conn.dr["School_ID"].ToString().Substring(4,2)
					+"' Where School_ID='"+conn.dr["School_ID"].ToString()+"'";
				errorstring=conn.ExeSql(str_Sql);
			}

			//班级学生人数统计
			str_Sql="select School_ID,Class_ID,Count(Student_ID) AS Student_Count FROM Student Group By School_ID,Class_ID";
			errorstring=conn.Fill(str_Sql);

			SchoolCount=conn.ds.Tables[0].Rows.Count;
			for(int indexSchool=0;indexSchool<SchoolCount;indexSchool++)
			{
				conn.dr=conn.ds.Tables[0].Rows[indexSchool];
				
				str_Sql="Update Class Set Student_Count="+conn.dr["Student_Count"].ToString()
					+" Where School_ID='"+conn.dr["School_ID"].ToString()+"' AND Class_ID="+conn.dr["Class_ID"].ToString();
				errorstring=conn.ExeSql(str_Sql);
			}

			MessageBox.Show("成功按照班级和学校统计学生人数！\n成功按照学校统计教师人数！"+errorstring, "提醒！", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

			
		}

		private void menuItem_ModifySchool_ID_Click(object sender, System.EventArgs e)
        {
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			ModifySchool_ID child_InSchool=new ModifySchool_ID();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_QuXian_Office_Committee_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			QuXian_Office_Committee child_InSchool=new QuXian_Office_Committee();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_SearchSchool_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			SearchSchool child_InSchool=new SearchSchool();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		
		}

		private void menuItem_SearchTeacher_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			SearchTeacher child_InSchool=new SearchTeacher();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_NonlegalData_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			NonlegalData child_InSchool=new NonlegalData();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_DeleteManyOld_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			DeleteManyOld child_InSchool=new DeleteManyOld();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();
		}

		private void menuItem_QuXianDataOut_Click(object sender, System.EventArgs e)
		{
			if (this.ActiveMdiChild!=null)
			{
				this.ActiveMdiChild.Close(); //关闭已经打开的子窗体
			}

			QuXianDataOut child_InSchool=new QuXianDataOut();
			child_InSchool.MdiParent=this;//this表示本窗体为其父窗体
			child_InSchool.Show();		
		
		}		
	}
}
