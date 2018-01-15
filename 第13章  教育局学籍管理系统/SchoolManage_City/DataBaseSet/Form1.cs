using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Data;
using System.Threading;

namespace DataBaseSet
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_PassWord;
		private System.Windows.Forms.TextBox textBox_User;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		const int ERROR_FILE_NOT_FOUND =2;
		const int ERROR_ACCESS_DENIED = 5;

		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			textBox_PassWord.PasswordChar='*';

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
			this.button3 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_PassWord = new System.Windows.Forms.TextBox();
			this.textBox_User = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(80, 112);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(88, 23);
			this.button3.TabIndex = 56;
			this.button3.Text = "初始化系统";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(72, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 23);
			this.label3.TabIndex = 60;
			this.label3.Text = "密码";
			// 
			// textBox_PassWord
			// 
			this.textBox_PassWord.Location = new System.Drawing.Point(184, 64);
			this.textBox_PassWord.Name = "textBox_PassWord";
			this.textBox_PassWord.Size = new System.Drawing.Size(96, 21);
			this.textBox_PassWord.TabIndex = 59;
			this.textBox_PassWord.Text = "";
			// 
			// textBox_User
			// 
			this.textBox_User.Location = new System.Drawing.Point(184, 32);
			this.textBox_User.Name = "textBox_User";
			this.textBox_User.Size = new System.Drawing.Size(96, 21);
			this.textBox_User.TabIndex = 57;
			this.textBox_User.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(72, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 23);
			this.label2.TabIndex = 58;
			this.label2.Text = "初始化专用用户名";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(240, 112);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 63;
			this.button2.Text = "退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(400, 165);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox_PassWord);
			this.Controls.Add(this.textBox_User);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button3);
			this.Name = "Form1";
			this.Text = "建立数据库";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			button3.Enabled=false;
			if(!(textBox_User.Text=="initialuser"&&textBox_PassWord.Text=="initialpassword"))
			{
				MessageBox.Show("用户名或者密码不正确！", "提醒！",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			string str_Sql,errorstring="";
			string str_DatabaseServer;

			DialogResult result=MessageBox.Show(this,"真的要进行初始化吗?数据库会被清空到初始状态！","提醒！",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
			if (result==DialogResult.OK)
			{				
				Process myProcess = new Process();
				try
				{
					myProcess.StartInfo.FileName ="启动数据库.bat"; 
					myProcess.StartInfo.CreateNoWindow = true;
					myProcess.Start();
				}
				catch (Win32Exception ebat)
				{
					if(ebat.NativeErrorCode == ERROR_FILE_NOT_FOUND)
					{
						Console.WriteLine(ebat.Message + ". Check the path.");
					} 
					else if (ebat.NativeErrorCode == ERROR_ACCESS_DENIED)
					{
						Console.WriteLine(ebat.Message +". You do not have permission to run this file.");
					}
				}

				Thread.Sleep(1111);

				str_DatabaseServer=SystemInformation.ComputerName+"\\MSDEDH";
				config connTest=new config();
				if(connTest.TestOpen(str_DatabaseServer,"sa","dhsa.")=="OK")
				{
					MessageBox.Show("数据库连接信息正确！", "提醒！", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show("连接不正确！", "提醒！",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);				
				}

				try
				{
					str_Sql="restore database "+ConfigurationSettings.AppSettings["Database"]
						+" from disk='"+System.IO.Directory.GetCurrentDirectory()+"\\DBCityEdu.bak"
						+"' with replace";
					errorstring=connTest.DBCreate(str_Sql);
				}
				catch
				{
					//return false;
					throw new Exception(errorstring+"数据库未重建！");
				}
				MessageBox.Show(errorstring+"成功建立数据库！", "提醒！",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);					
				config connFirst=new config();
				//测试数据库连接
				str_Sql="SELECT School_Type_ID As 学校类别代码,School_Type_Name As 学校类别名,School_Type_Year As 学校类别学制 FROM School_Type";
				errorstring=connFirst.Fill(str_Sql);
				if(errorstring!="OK")
				{
					MessageBox.Show("数据库有问题！"+errorstring, "提醒！", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					connFirst.Close();
					return;
				}
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
	}
}
