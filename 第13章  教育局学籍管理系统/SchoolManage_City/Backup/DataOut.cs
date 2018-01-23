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
	/// DataOut 的摘要说明。
	/// </summary>
	public class DataOut : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox textBox_LocationDBOut;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button3;

		protected config conn=new config();

		public DataOut()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			string str_Sql="Select * from School"; 
			if(conn.GetRowCount(str_Sql)==0)
			{
				MessageBox.Show("请先输入学校信息！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;				
				return;
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
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "当前导出目录";
			// 
			// textBox_LocationDBOut
			// 
			this.textBox_LocationDBOut.Location = new System.Drawing.Point(104, 32);
			this.textBox_LocationDBOut.Name = "textBox_LocationDBOut";
			this.textBox_LocationDBOut.Size = new System.Drawing.Size(248, 21);
			this.textBox_LocationDBOut.TabIndex = 3;
			this.textBox_LocationDBOut.Text = "D:";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(248, 88);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(128, 88);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "导出";
			this.button1.Click += new System.EventHandler(this.button3_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(360, 32);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(72, 23);
			this.button3.TabIndex = 13;
			this.button3.Text = "换目录";
			this.button3.Click += new System.EventHandler(this.button3_Click_1);
			// 
			// DataOut
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(512, 133);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_LocationDBOut);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "DataOut";
			this.Text = "下级数据导出";
			this.ResumeLayout(false);

		}
		#endregion

		//设定备份文件位置
		private void button1_Click(object sender, System.EventArgs e)
		{	
			DialogResult result =  folderBrowserDialog1.ShowDialog();
			if( result == DialogResult.OK )
			{
				string folderName = folderBrowserDialog1.SelectedPath;
				textBox_LocationDBOut.Text=folderName;
			}
		}

		//DataSet数据->xml文件,格式->xsd文件
		private void button3_Click(object sender, System.EventArgs e)
		{
			//测试数据库
			string str_Sql="SELECT School_ID,School_Name,School_Type_ID,Schoolmaster,School_Tel,School_Zip,School_Address FROM School";
			string errorstring=conn.Fill(str_Sql);
			if(errorstring!="OK")
			{				
				MessageBox.Show("请检查数据库！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			
			str_Sql="SELECT School_ID,School_Name,School_Type_ID,Schoolmaster,School_Tel,School_Zip,School_Address,QuXian_Code FROM School";
			conn.Fill(str_Sql);
			conn.ds.WriteXmlSchema(textBox_LocationDBOut.Text+"\\School.xsd");
			conn.ds.WriteXml(textBox_LocationDBOut.Text+"\\School.xml");

			str_Sql="SELECT Class_ID,School_ID,Class_Type_ID,Class_Name,TeacherInCharge FROM Class";
			conn.Fill(str_Sql);
			conn.ds.WriteXmlSchema(textBox_LocationDBOut.Text+"\\Class.xsd");
			conn.ds.WriteXml(textBox_LocationDBOut.Text+"\\Class.xml");

			str_Sql="SELECT Student_ID,School_ID,Class_ID,Name,Sex,Birthday,Father,Mother,Keeper,StudentTel,QuXian_ID,Office_ID,Committee_ID,Student_Address,Father_Job,Father_XueLi,Mother_Job,Mother_XueLi FROM Student";
			conn.Fill(str_Sql);
			conn.ds.WriteXmlSchema(textBox_LocationDBOut.Text+"\\Student.xsd");
			conn.ds.WriteXml(textBox_LocationDBOut.Text+"\\Student.xml");

			str_Sql="SELECT School_ID,Teacher_ID,Name,Sex,Birthday,WorkTime,SchoolType,PostCan,PostIn,SchoolGrad,GradTime,SpecialIn,InWorkSheet,IsFullTime,LessonTeach FROM Teacher";
			conn.Fill(str_Sql);
			conn.ds.WriteXmlSchema(textBox_LocationDBOut.Text+"\\Teacher.xsd");
			conn.ds.WriteXml(textBox_LocationDBOut.Text+"\\Teacher.xml");

			/*
			StreamWriter sw=new StreamWriter(textBox_LocationDBOut.Text+"\\UploadPassword.xml",false,Encoding.GetEncoding("gb2312"));
			try
			{
				sw.Write(textBox_UploadPassword.Text);
			}
			catch
			{
				MessageBox.Show("上传密码存储出错！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			try
			{
				sw.Close();
			}
			catch
			{
				MessageBox.Show("上传密码存储出错！"+errorstring, "提醒！", 
				 MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			},UploadPassword.xml七*/

			MessageBox.Show("请检查"+textBox_LocationDBOut.Text+"处是否有School.xml,Class.xml,Student.xml,Teacher.xml,Teacher.xsd,School.xsd,Class.xsd,Student.xsd八个文件！请全部拷贝上报", "提醒！", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void button3_Click_1(object sender, System.EventArgs e)
		{
			DialogResult result =  folderBrowserDialog1.ShowDialog();
			if( result == DialogResult.OK )
			{
				string folderName = folderBrowserDialog1.SelectedPath;
				textBox_LocationDBOut.Text=folderName;
			}
		}
	}
}
