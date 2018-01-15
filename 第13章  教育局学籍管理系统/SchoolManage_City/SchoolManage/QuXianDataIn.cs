using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;
namespace SchoolManage
{
	/// <summary>
	/// QuXianDataIn 的摘要说明。
	/// </summary>
	public class QuXianDataIn : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_LocationDBOut;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected config conn=new config();
		protected config connSchool=new config();
		protected config connClass=new config();
		protected config connTeacher=new config();
		protected config connStudent=new config();

		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

		public QuXianDataIn()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			string str_Sql,errorstring;
			str_Sql="SELECT School_Type_ID As 学校类别代码,School_Type_Name As 学校类别名,School_Type_Year As 学校类别学制 FROM School_Type";
			errorstring=connSchool.Fill(str_Sql);
			errorstring=conn.Fill(str_Sql);

			str_Sql="SELECT * FROM Class_Type";
			errorstring=connClass.Fill(str_Sql);
			
			str_Sql="SELECT * FROM Class_Type";
			errorstring=connTeacher.Fill(str_Sql);
			
			str_Sql="SELECT * FROM Class_Type";
			errorstring=connStudent.Fill(str_Sql);			

			if(errorstring!="OK")
			{
				MessageBox.Show("请检查数据库！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.Dispose();
			}
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_LocationDBOut = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(44, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 14;
			this.label1.Text = "当前导入目录";
			// 
			// textBox_LocationDBOut
			// 
			this.textBox_LocationDBOut.Location = new System.Drawing.Point(124, 49);
			this.textBox_LocationDBOut.Name = "textBox_LocationDBOut";
			this.textBox_LocationDBOut.Size = new System.Drawing.Size(320, 21);
			this.textBox_LocationDBOut.TabIndex = 13;
			this.textBox_LocationDBOut.Text = "D:";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(268, 103);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 16;
			this.button2.Text = "退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(148, 103);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 15;
			this.button1.Text = "导入";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(448, 48);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(72, 23);
			this.button3.TabIndex = 17;
			this.button3.Text = "换目录";
			this.button3.Click += new System.EventHandler(this.button3_Click_1);
			// 
			// QuXianDataIn
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(568, 173);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_LocationDBOut);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "QuXianDataIn";
			this.Text = "下级数据批量导入";
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			button1.Enabled=false;
			string str_Sql,errorstring="OK",str_School_ID_In;
			StringBuilder  StringBuilder_Sql=new StringBuilder();

			connSchool.ds.Reset();
			try
			{
				connSchool.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\School.xsd");
				connSchool.ds.ReadXml(textBox_LocationDBOut.Text+"\\School.xml");
			}
			catch
			{//对话框
				MessageBox.Show("School文件打开失败！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			int SchoolCount=connSchool.ds.Tables[0].Rows.Count;

			//导入班级信息
			connClass.ds.Reset();
			try
			{
				connClass.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\Class.xsd");
				connClass.ds.ReadXml(textBox_LocationDBOut.Text+"\\Class.xml");
			}
			catch
			{//对话框
				MessageBox.Show("Class文件打开失败！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			//导入教师信息
			connTeacher.ds.Reset();
			try
			{
				connTeacher.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\Teacher.xsd");
				connTeacher.ds.ReadXml(textBox_LocationDBOut.Text+"\\Teacher.xml");
			}
			catch
			{//对话框
				MessageBox.Show("Teacher文件打开失败！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			//导入学生信息	
			connStudent.ds.Reset();
			try
			{
				connStudent.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\Student.xsd");
				connStudent.ds.ReadXml(textBox_LocationDBOut.Text+"\\Student.xml");
			}
			catch
			{//对话框
				MessageBox.Show("Student文件打开失败！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

            for(int indexSchool=0;indexSchool<SchoolCount;indexSchool++)
			{
				connSchool.dr=connSchool.ds.Tables[0].Rows[indexSchool];
				str_School_ID_In=connSchool.dr["School_ID"].ToString();
			
				DialogResult result;

				/*各种验证
				if(conn.School_ID_Had(str_School_ID_In))
				{
					result=MessageBox.Show(this,"真的要导入学校代码为 "+str_School_ID_In+" 的学校吗?"
						+"其学校名称为"+conn.School_IDtoWhat(str_School_ID_In,"School_Name")
						+"操作会替换该学校原有的所有信息","提醒！",
						MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
				}
				else
				{
					result=MessageBox.Show(this,"真的要导入吗?","提醒！",
						MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
				}
				
				if (result==DialogResult.OK)*/
				{
					//删除该学校代码对应的所有信息,先删除学生,再删除班级,最后删除学校,以防外键冲突
					str_Sql="DELETE from Student WHERE School_ID='"+str_School_ID_In+"'";
					conn.ExeSql(str_Sql);

					str_Sql="DELETE from Class WHERE School_ID='"+str_School_ID_In+"'";
					conn.ExeSql(str_Sql);
				
					str_Sql="DELETE from Teacher WHERE School_ID='"+str_School_ID_In+"'";
					conn.ExeSql(str_Sql);

					str_Sql="DELETE from School WHERE School_ID='"+str_School_ID_In+"'";
					conn.ExeSql(str_Sql);
	
//					str_Sql="insert into School (School_ID,School_Name,School_Type_ID,Schoolmaster,School_Tel,School_Zip,School_Address) values ('"
//						+str_School_ID_In+"','"
//						+connSchool.dr["School_Name"].ToString()+"',"
//						+connSchool.dr["School_Type_ID"].ToString()+",'"
//						+connSchool.dr["Schoolmaster"].ToString()+"','"
//						+connSchool.dr["School_Tel"].ToString()+"','"
//						+connSchool.dr["School_Zip"].ToString()+"','"
//						+connSchool.dr["School_Address"].ToString()+"')";

					str_Sql=StringBuilder_Sql.ToString();
					StringBuilder_Sql.Remove(0,str_Sql.Length);

					StringBuilder_Sql.Append("insert into School (School_ID,School_Name,School_Type_ID,Schoolmaster,School_Tel,School_Zip,School_Address) values ('");
					StringBuilder_Sql.Append(str_School_ID_In);
					StringBuilder_Sql.Append("','");
					StringBuilder_Sql.Append(connSchool.dr["School_Name"].ToString());
					StringBuilder_Sql.Append("',");
					StringBuilder_Sql.Append(connSchool.dr["School_Type_ID"].ToString());
					StringBuilder_Sql.Append(",'");
					StringBuilder_Sql.Append(connSchool.dr["Schoolmaster"].ToString());
					StringBuilder_Sql.Append("','");
					StringBuilder_Sql.Append(connSchool.dr["School_Tel"].ToString());
					StringBuilder_Sql.Append("','");
					StringBuilder_Sql.Append(connSchool.dr["School_Zip"].ToString());
					StringBuilder_Sql.Append("','");
					StringBuilder_Sql.Append(connSchool.dr["School_Address"].ToString());
					StringBuilder_Sql.Append("')");

					str_Sql=StringBuilder_Sql.ToString();

					errorstring=conn.ExeSql(str_Sql);

					if(errorstring!="OK")
					{
						MessageBox.Show("未成功导入学校信息！请检查数据库！"+errorstring, "提醒！", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						button1.Enabled=false;
						return;
					}

					/*提示成功导入
					MessageBox.Show("成功导入学校信息！"+errorstring, "提醒！", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					*/

					//int TeacherCount=connTeacher.ds.Tables[0].Rows.Count;
					//for(int i=0;i<TeacherCount;i++)
					foreach(System.Data.DataRow drtemp in connTeacher.ds.Tables[0].Rows)
					{
						//connTeacher.dr=connTeacher.ds.Tables[0].Rows[i];
						connTeacher.dr=drtemp;
						
						if(connTeacher.dr["School_ID"].ToString()==str_School_ID_In)
						{
							string str_InWorkSheet,str_IsFullTime;
							if(connTeacher.dr["InWorkSheet"].ToString()=="True")
								str_InWorkSheet="1";
							else str_InWorkSheet="0";
							if(connTeacher.dr["IsFullTime"].ToString()=="True")
								str_IsFullTime="1";
							else str_IsFullTime="0";
							 							
//							str_Sql="INSERT INTO Teacher (School_ID,Teacher_ID,Name,Sex,Birthday,WorkTime,SchoolType,PostCan,PostIn,SchoolGrad,GradTime,SpecialIn,LessonTeach,InWorkSheet,IsFullTime) values('"
//								+conn.dr["School_ID"].ToString()
//								+"','"+conn.dr["Teacher_ID"].ToString()
//								+"','"+conn.dr["Name"].ToString()
//								+"','"+conn.dr["Sex"].ToString()
//								+"','"+conn.dr["Birthday"].ToString()
//								+"','"+conn.dr["WorkTime"].ToString()
//								+"','"+conn.dr["SchoolType"].ToString()
//								+"','"+conn.dr["PostCan"].ToString()
//								+"','"+conn.dr["PostIn"].ToString()
//								+"','"+conn.dr["SchoolGrad"].ToString()
//								+"','"+conn.dr["GradTime"].ToString()
//								+"','"+conn.dr["SpecialIn"].ToString()
//								+"','"+conn.dr["LessonTeach"].ToString()
//								+"',"+str_InWorkSheet
//								+","+str_IsFullTime+")";

							StringBuilder_Sql.Remove(0,str_Sql.Length);

							StringBuilder_Sql.Append("INSERT INTO Teacher (School_ID,Teacher_ID,Name,Sex,Birthday,WorkTime,SchoolType,PostCan,PostIn,SchoolGrad,GradTime,SpecialIn,LessonTeach,InWorkSheet,IsFullTime) values('");
							StringBuilder_Sql.Append(connTeacher.dr["School_ID"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["Teacher_ID"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["Name"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["Sex"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["Birthday"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["WorkTime"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["SchoolType"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["PostCan"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["PostIn"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["SchoolGrad"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["GradTime"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["SpecialIn"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connTeacher.dr["LessonTeach"].ToString());
							StringBuilder_Sql.Append("',");
							StringBuilder_Sql.Append(str_InWorkSheet);
							StringBuilder_Sql.Append(",");
							StringBuilder_Sql.Append(str_IsFullTime);
							StringBuilder_Sql.Append(")");

							str_Sql=StringBuilder_Sql.ToString();

							errorstring=connTeacher.ExeSql(str_Sql);
						}
					}
					if(errorstring!="OK")
					{
						MessageBox.Show("未成功导入教师信息！请检查数据库！"+errorstring, "提醒！", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						button1.Enabled=false;
						return;
					}

					/*提示成功导入
					MessageBox.Show("成功导入教师信息！"+errorstring, "提醒！", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);conn.ds.Reset();
					*/
	
					//int ClassCount=connClass.ds.Tables[0].Rows.Count;
					//for(int i=0;i<ClassCount;i++)
					//{
					foreach(System.Data.DataRow drtemp in connClass.ds.Tables[0].Rows)
					{		
						connClass.dr=drtemp;
						
						//connClass.dr=connClass.ds.Tables[0].Rows[i];

						if(connClass.dr["School_ID"].ToString()==str_School_ID_In)
						{
//							str_Sql="INSERT INTO Class  (Class_ID,School_ID,Class_Type_ID,Class_Name,TeacherInCharge) values("
//								+conn.dr["Class_ID"].ToString()+",'"
//								+conn.dr["School_ID"].ToString()+"',"
//								+conn.dr["Class_Type_ID"].ToString()+",'"
//								+conn.dr["Class_Name"].ToString()+"','"
//								+conn.dr["TeacherInCharge"].ToString()+"')";
							
							StringBuilder_Sql.Remove(0,str_Sql.Length);

							StringBuilder_Sql.Append("INSERT INTO Class  (Class_ID,School_ID,Class_Type_ID,Class_Name,TeacherInCharge) values(");
							StringBuilder_Sql.Append(connClass.dr["Class_ID"].ToString());
							StringBuilder_Sql.Append(",'");
							StringBuilder_Sql.Append(connClass.dr["School_ID"].ToString());
							StringBuilder_Sql.Append("',");
							StringBuilder_Sql.Append(connClass.dr["Class_Type_ID"].ToString());
							StringBuilder_Sql.Append(",'");
							StringBuilder_Sql.Append(connClass.dr["Class_Name"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connClass.dr["TeacherInCharge"].ToString());
							StringBuilder_Sql.Append("')");

							str_Sql=StringBuilder_Sql.ToString();

							errorstring=conn.ExeSql(str_Sql);
						}
					}
					if(errorstring!="OK")
					{
						MessageBox.Show("未成功导入班级信息！请检查数据库！"+errorstring, "提醒！", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						button1.Enabled=false;
						return;
					}

					/*提示成功导入
					MessageBox.Show("成功导入班级信息！"+errorstring, "提醒！", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);conn.ds.Reset();
					*/

					//int StudentCount=connStudent.ds.Tables[0].Rows.Count;					
					//for(int i=0;i<connStudent.ds.Tables[0].Rows.Count;i++)
					//{
					//	connStudent.dr=connStudent.ds.Tables[0].Rows[i];

					foreach(System.Data.DataRow drtemp in connStudent.ds.Tables[0].Rows)
					{		
						connStudent.dr=drtemp;
						
						if(connStudent.dr["School_ID"].ToString()==str_School_ID_In)
						{
//							str_Sql="insert into Student (School_ID,Student_ID,Class_ID,Name,Birthday,Sex,Father,Mother,Keeper,StudentTel,QuXian_ID,Office_ID,Committee_ID,Student_Address,Father_Job,Father_XueLi,Mother_Job,Mother_XueLi) values ('"
//								+conn.dr["School_ID"].ToString()+"','"
//								+conn.dr["Student_ID"].ToString()+"',"
//								+conn.dr["Class_ID"].ToString()+",'"
//								+conn.dr["Name"].ToString()+"','"
//								+conn.dr["Birthday"].ToString()+"','"
//								+conn.dr["Sex"].ToString()+"','"
//								+conn.dr["Father"].ToString()+"','"
//								+conn.dr["Mother"].ToString()+"','"
//								+conn.dr["Keeper"].ToString()+"','"
//								+conn.dr["StudentTel"].ToString()+"',"
//								+conn.dr["QuXian_ID"].ToString()+","
//								+conn.dr["Office_ID"].ToString()+",'"
//								+conn.dr["Committee_ID"].ToString()+"','"
//								+conn.dr["Student_Address"].ToString()+"','"
//								+conn.dr["Father_Job"].ToString()+"','"
//								+conn.dr["Father_XueLi"].ToString()+"','"
//								+conn.dr["Mother_Job"].ToString()+"','"
//								+conn.dr["Mother_XueLi"].ToString()+"')";

							StringBuilder_Sql.Remove(0,str_Sql.Length);

							StringBuilder_Sql.Append("insert into Student (School_ID,Student_ID,Class_ID,Name,Birthday,Sex,Father,Mother,Keeper,StudentTel,QuXian_ID,Office_ID,Committee_ID,Student_Address,Father_Job,Father_XueLi,Mother_Job,Mother_XueLi) values ('");
							StringBuilder_Sql.Append(connStudent.dr["School_ID"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Student_ID"].ToString());
							StringBuilder_Sql.Append("',");
							StringBuilder_Sql.Append(connStudent.dr["Class_ID"].ToString());
							StringBuilder_Sql.Append(",'");
							StringBuilder_Sql.Append(connStudent.dr["Name"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Birthday"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Sex"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Father"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Mother"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Keeper"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["StudentTel"].ToString());
							StringBuilder_Sql.Append("',");
							StringBuilder_Sql.Append(connStudent.dr["QuXian_ID"].ToString());
							StringBuilder_Sql.Append(",");
							StringBuilder_Sql.Append(connStudent.dr["Office_ID"].ToString());
							StringBuilder_Sql.Append(",'");
							StringBuilder_Sql.Append(connStudent.dr["Committee_ID"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Student_Address"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Father_Job"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Father_XueLi"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Mother_Job"].ToString());
							StringBuilder_Sql.Append("','");
							StringBuilder_Sql.Append(connStudent.dr["Mother_XueLi"].ToString());
							StringBuilder_Sql.Append("')");

							str_Sql=StringBuilder_Sql.ToString();

							errorstring=connStudent.ExeSql(str_Sql);							
						}
					}
					if(errorstring!="OK")
					{
						MessageBox.Show("未成功导入学生信息！请检查数据库！"+errorstring, "提醒！", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						button1.Enabled=false;
						return;
					}

					/*提示成功导入
					MessageBox.Show("成功导入学生信息！"+errorstring, "提醒！", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					*/
			
				}

				/*对话框if的返回语句
				else
				{
					return;
				}
				*/		
			}
			MessageBox.Show("成功导入"+SchoolCount.ToString()+"个学校信息！"+errorstring, "提醒！", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);conn.ds.Reset();
		}

		private void button3_Click_1(object sender, System.EventArgs e)
		{
			DialogResult resulttemp =  folderBrowserDialog1.ShowDialog();
			if( resulttemp == DialogResult.OK )
			{
				string folderName = folderBrowserDialog1.SelectedPath;
				textBox_LocationDBOut.Text=folderName;
			}
		}
	}
}
