using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;

namespace SchoolManage
{
	/// <summary>
	/// DBSet 的摘要说明。
	/// </summary>
	public class DBSet : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_DBServer;
		private System.Windows.Forms.TextBox textBox_DbUser;
		private System.Windows.Forms.TextBox textBox_DbPassWord;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_Database;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DBSet()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//读取config文件里边关键字的原值显示
			try
			{
				string path="SchoolManage.exe.config";
				XmlDocument xd=new XmlDocument();
				xd.Load(path);
				foreach(XmlNode xn1 in xd.SelectNodes("/configuration/appSettings/add"))
				{
					if(xn1.Attributes["key"].Value=="Database")
					{
						textBox_Database.Text=xn1.Attributes["value"].Value;
						//break;
					}
					if(xn1.Attributes["key"].Value=="DatabaseServer")
					{
						textBox_DBServer.Text=xn1.Attributes["value"].Value;
						//break;
					}
					if(xn1.Attributes["key"].Value=="DatabaseUser")
					{
						textBox_DbUser.Text=xn1.Attributes["value"].Value;
						//break;
					}
					if(xn1.Attributes["key"].Value=="DatabasePassword")
					{
						textBox_DbPassWord.Text=xn1.Attributes["value"].Value;
						break;
					}
				}
			}
			catch
			{
				//return false;
				throw new Exception("Config设置文件读取失败！");
			}
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
			this.textBox_DBServer = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_DbUser = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_DbPassWord = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_Database = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox_DBServer
			// 
			this.textBox_DBServer.Location = new System.Drawing.Point(136, 64);
			this.textBox_DBServer.Name = "textBox_DBServer";
			this.textBox_DBServer.Size = new System.Drawing.Size(96, 21);
			this.textBox_DBServer.TabIndex = 0;
			this.textBox_DBServer.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "服务器名";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(40, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "用户名";
			// 
			// textBox_DbUser
			// 
			this.textBox_DbUser.Location = new System.Drawing.Point(136, 96);
			this.textBox_DbUser.Name = "textBox_DbUser";
			this.textBox_DbUser.Size = new System.Drawing.Size(96, 21);
			this.textBox_DbUser.TabIndex = 2;
			this.textBox_DbUser.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(40, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "密码";
			// 
			// textBox_DbPassWord
			// 
			this.textBox_DbPassWord.Location = new System.Drawing.Point(136, 128);
			this.textBox_DbPassWord.Name = "textBox_DbPassWord";
			this.textBox_DbPassWord.Size = new System.Drawing.Size(96, 21);
			this.textBox_DbPassWord.TabIndex = 4;
			this.textBox_DbPassWord.Text = "";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(160, 184);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 50;
			this.button2.Text = "退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(56, 184);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 49;
			this.button1.Text = "修改";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(40, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 23);
			this.label4.TabIndex = 1;
			this.label4.Text = "数据库名";
			// 
			// textBox_Database
			// 
			this.textBox_Database.Location = new System.Drawing.Point(136, 32);
			this.textBox_Database.Name = "textBox_Database";
			this.textBox_Database.Size = new System.Drawing.Size(96, 21);
			this.textBox_Database.TabIndex = 0;
			this.textBox_Database.Text = "";
			// 
			// DBSet
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 245);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox_DbPassWord);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_DbUser);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_DBServer);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox_Database);
			this.Name = "DBSet";
			this.Text = "数据库设定";
			this.ResumeLayout(false);

		}
		#endregion

		//设定config文件里边关键字的值
		private void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				string path="SchoolManage.exe.config";
				XmlDocument xd=new XmlDocument();
				xd.Load(path);
				//判断节点是否存在，如果存在则修改当前节点
				foreach(XmlNode xn1 in xd.SelectNodes("/configuration/appSettings/add"))
				{
					if(xn1.Attributes["key"].Value=="DatabaseServer")
					{
						xn1.Attributes["value"].Value=textBox_DBServer.Text;
						//break;
					}
					if(xn1.Attributes["key"].Value=="Database")
					{
						xn1.Attributes["value"].Value=textBox_Database.Text;
						//break;
					}
					if(xn1.Attributes["key"].Value=="DatabaseUser")
					{
						xn1.Attributes["value"].Value=textBox_DbUser.Text;
						//break;
					}
					
					if(xn1.Attributes["key"].Value=="DatabasePassword")
					{
						xn1.Attributes["value"].Value=textBox_DbPassWord.Text;
						break;
					}
				}
				//保存web.config
				xd.Save(path);
				//return true;
				MessageBox.Show("成功修改！请重新登录", "提醒！", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch
			{
				//return false;
				throw new Exception("Config设置文件读取失败！");
			}

			button1.Enabled=false;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
	}
}
