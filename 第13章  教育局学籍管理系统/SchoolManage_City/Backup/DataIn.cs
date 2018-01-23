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
	/// DataIn 的摘要说明。
	/// </summary>
	public class DataIn : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_LocationDBOut;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

		protected config conn=new config();

		public DataIn()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//测试数据库连接
			string str_Sql,errorstring;
			str_Sql="SELECT School_Type_ID As 学校类别代码,School_Type_Name As 学校类别名,School_Type_Year As 学校类别学制 FROM School_Type";
			errorstring=conn.Fill(str_Sql);
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
			this.button3 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_LocationDBOut = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(432, 48);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(72, 23);
			this.button3.TabIndex = 12;
			this.button3.Text = "换目录";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 9;
			this.label1.Text = "当前导入目录";
			// 
			// textBox_LocationDBOut
			// 
			this.textBox_LocationDBOut.Location = new System.Drawing.Point(104, 48);
			this.textBox_LocationDBOut.Name = "textBox_LocationDBOut";
			this.textBox_LocationDBOut.Size = new System.Drawing.Size(320, 21);
			this.textBox_LocationDBOut.TabIndex = 8;
			this.textBox_LocationDBOut.Text = "D:";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(248, 104);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 11;
			this.button2.Text = "退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(128, 104);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 10;
			this.button1.Text = "导入";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// DataIn
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(544, 157);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_LocationDBOut);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "DataIn";
			this.Text = "下级学校数据导入";
			this.ResumeLayout(false);

		}
		#endregion

		
		//得到备份文件
		private void button3_Click(object sender, System.EventArgs e)
		{
			DialogResult result =  folderBrowserDialog1.ShowDialog();
			if( result == DialogResult.OK )
			{
				string folderName = folderBrowserDialog1.SelectedPath;
				textBox_LocationDBOut.Text=folderName;
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}


		private void button1_Click(object sender, System.EventArgs e)
		{
			button1.Enabled=false;
			string str_Sql,errorstring="OK",str_School_ID_In;
			
			//导入学校信息
			conn.ds.Reset();
			try
			{
				conn.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\School.xsd");
				conn.ds.ReadXml(textBox_LocationDBOut.Text+"\\School.xml");
			}
			catch
			{//对话框
				MessageBox.Show("School文件打开失败！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			conn.dr=conn.ds.Tables[0].Rows[0];
			str_School_ID_In=conn.dr["School_ID"].ToString();
			
			DialogResult result;
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


			if (result==DialogResult.OK)
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

					conn.ds.Reset();
					conn.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\School.xsd");
					conn.ds.ReadXml(textBox_LocationDBOut.Text+"\\School.xml");
						
					conn.dr=conn.ds.Tables[0].Rows[0];
					str_Sql="insert into School (School_ID,School_Name,School_Type_ID,Schoolmaster,School_Tel,School_Zip,School_Address,QuXian_Code) values ('"
							+str_School_ID_In+"','"
							+conn.dr["School_Name"].ToString()+"',"
							+conn.dr["School_Type_ID"].ToString()+",'"
							+conn.dr["Schoolmaster"].ToString()+"','"
							+conn.dr["School_Tel"].ToString()+"','"
							+conn.dr["School_Zip"].ToString()+"','"
							+conn.dr["School_Address"].ToString()+"','"
							+conn.dr["QuXian_Code"].ToString()+"')";
					errorstring=conn.ExeSql(str_Sql);

					if(errorstring!="OK")
					{
						MessageBox.Show("未成功导入学校信息！请检查数据库！"+errorstring, "提醒！", 
								MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						button1.Enabled=false;
						return;
					}
					MessageBox.Show("成功导入学校信息！"+errorstring, "提醒！", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				
					//导入教师信息					
					conn.ds.Reset();
					try
					{
						conn.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\Teacher.xsd");
						conn.ds.ReadXml(textBox_LocationDBOut.Text+"\\Teacher.xml");
					}
					catch
					{//对话框
						MessageBox.Show("Teacher文件打开失败！"+errorstring, "提醒！", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					for(int i=0;i<conn.ds.Tables[0].Rows.Count;i++)
					{
						string str_InWorkSheet,str_IsFullTime;
						conn.dr=conn.ds.Tables[0].Rows[i];
						
						if(conn.dr["InWorkSheet"].ToString()=="True")
							str_InWorkSheet="1";
						else str_InWorkSheet="0";
						if(conn.dr["IsFullTime"].ToString()=="True")
							str_IsFullTime="1";
						else str_IsFullTime="0";
							 
						str_Sql="INSERT INTO Teacher (School_ID,Teacher_ID,Name,Sex,Birthday,WorkTime,SchoolType,PostCan,PostIn,SchoolGrad,GradTime,SpecialIn,LessonTeach,InWorkSheet,IsFullTime) values('"
							+conn.dr["School_ID"].ToString()
							+"','"+conn.dr["Teacher_ID"].ToString()
							+"','"+conn.dr["Name"].ToString()
							+"','"+conn.dr["Sex"].ToString()
							+"','"+conn.dr["Birthday"].ToString()
							+"','"+conn.dr["WorkTime"].ToString()
							+"','"+conn.dr["SchoolType"].ToString()
							+"','"+conn.dr["PostCan"].ToString()
							+"','"+conn.dr["PostIn"].ToString()
							+"','"+conn.dr["SchoolGrad"].ToString()
							+"','"+conn.dr["GradTime"].ToString()
							+"','"+conn.dr["SpecialIn"].ToString()
							+"','"+conn.dr["LessonTeach"].ToString()
							+"',"+str_InWorkSheet
							+","+str_IsFullTime+")";
						errorstring=conn.ExeSql(str_Sql);
					}
					if(errorstring!="OK")
					{
						MessageBox.Show("未成功导入教师信息！请检查数据库！"+errorstring, "提醒！", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						button1.Enabled=false;
						return;
					}
					MessageBox.Show("成功导入教师信息！"+errorstring, "提醒！", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);conn.ds.Reset();

					//导入班级信息					
					conn.ds.Reset();
					try
					{
						conn.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\Class.xsd");
						conn.ds.ReadXml(textBox_LocationDBOut.Text+"\\Class.xml");
					}
					catch
					{//对话框
						MessageBox.Show("Class文件打开失败！"+errorstring, "提醒！", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					for(int i=0;i<conn.ds.Tables[0].Rows.Count;i++)
					{
						conn.dr=conn.ds.Tables[0].Rows[i];
						str_Sql="INSERT INTO Class  (Class_ID,School_ID,Class_Type_ID,Class_Name,TeacherInCharge) values("
							+conn.dr["Class_ID"].ToString()+",'"
							+conn.dr["School_ID"].ToString()+"',"
							+conn.dr["Class_Type_ID"].ToString()+",'"
							+conn.dr["Class_Name"].ToString()+"','"
							+conn.dr["TeacherInCharge"].ToString()+"')";
						errorstring=conn.ExeSql(str_Sql);
					}
					if(errorstring!="OK")
					{
						MessageBox.Show("未成功导入班级信息！请检查数据库！"+errorstring, "提醒！", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						button1.Enabled=false;
						return;
					}
					MessageBox.Show("成功导入班级信息！"+errorstring, "提醒！", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);conn.ds.Reset();

					//导入学生信息					
					conn.ds.Reset();
					try
					{
						conn.ds.ReadXmlSchema(textBox_LocationDBOut.Text+"\\Student.xsd");
						conn.ds.ReadXml(textBox_LocationDBOut.Text+"\\Student.xml");
					}
					catch
					{//对话框
						MessageBox.Show("Student文件打开失败！"+errorstring, "提醒！", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					for(int i=0;i<conn.ds.Tables[0].Rows.Count;i++)
					{
						conn.dr=conn.ds.Tables[0].Rows[i];
						str_Sql="insert into Student (School_ID,Student_ID,Class_ID,Name,Birthday,Sex,Father,Mother,Keeper,StudentTel,QuXian_ID,Office_ID,Committee_ID,Student_Address,Father_Job,Father_XueLi,Mother_Job,Mother_XueLi) values ('"
							+conn.dr["School_ID"].ToString()+"','"
							+conn.dr["Student_ID"].ToString()+"',"
							+conn.dr["Class_ID"].ToString()+",'"
							+conn.dr["Name"].ToString()+"','"
							+conn.dr["Birthday"].ToString()+"','"
							+conn.dr["Sex"].ToString()+"','"
							+conn.dr["Father"].ToString()+"','"
							+conn.dr["Mother"].ToString()+"','"
							+conn.dr["Keeper"].ToString()+"','"
							+conn.dr["StudentTel"].ToString()+"',"
							+conn.dr["QuXian_ID"].ToString()+","
							+conn.dr["Office_ID"].ToString()+",'"
							+conn.dr["Committee_ID"].ToString()+"','"
							+conn.dr["Student_Address"].ToString()+"','"
							+conn.dr["Father_Job"].ToString()+"','"
							+conn.dr["Father_XueLi"].ToString()+"','"
							+conn.dr["Mother_Job"].ToString()+"','"
							+conn.dr["Mother_XueLi"].ToString()+"')";
						errorstring=conn.ExeSql(str_Sql);
					}
					if(errorstring!="OK")
					{
						MessageBox.Show("未成功导入学生信息！请检查数据库！"+errorstring, "提醒！", 
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						button1.Enabled=false;
						return;
					}
					MessageBox.Show("成功导入学生信息！"+errorstring, "提醒！", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

					conn.Close();
					this.Dispose();				
				}
				else
				{
					return;
				}			
		}/**//**/
	}
}
