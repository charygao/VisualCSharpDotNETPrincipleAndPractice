using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace SchoolManage
{
	/// <summary>
	/// LocationDBBackup 的摘要说明。
	/// </summary>
	public class LocationDBBackup : System.Windows.Forms.Form
	{
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_LocationDBBackup;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button3;

		private string  folderName;

		public LocationDBBackup()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//显示原先的数据库备份位置
			try
			{
				string path="SchoolManage.exe.config";
				XmlDocument xd=new XmlDocument();
				xd.Load(path);
				foreach(XmlNode xn1 in xd.SelectNodes("/configuration/appSettings/add"))
				{					
					if(xn1.Attributes["key"].Value=="DatabaseBackup")
					{
						textBox_LocationDBBackup.Text=xn1.Attributes["value"].Value;
						break;
					}
				}
			}
			catch
			{
				//return false;
				throw new Exception("Config设置文件读取失败！");
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
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.textBox_LocationDBBackup = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox_LocationDBBackup
			// 
			this.textBox_LocationDBBackup.Location = new System.Drawing.Point(88, 49);
			this.textBox_LocationDBBackup.Name = "textBox_LocationDBBackup";
			this.textBox_LocationDBBackup.Size = new System.Drawing.Size(248, 21);
			this.textBox_LocationDBBackup.TabIndex = 0;
			this.textBox_LocationDBBackup.Text = "D:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "当前备份目录";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(344, 48);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "换目录";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(232, 104);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "放弃退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(64, 104);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "设定退出";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// LocationDBBackup
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(424, 198);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_LocationDBBackup);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button3);
			this.Name = "LocationDBBackup";
			this.Text = "修改备份位置";
			this.ResumeLayout(false);

		}
		#endregion

		//获得新的数据库备份位置
		private void button1_Click(object sender, System.EventArgs e)
		{
			DialogResult result = folderBrowserDialog1.ShowDialog();
			if( result == DialogResult.OK )
			{
				folderName = folderBrowserDialog1.SelectedPath;
				textBox_LocationDBBackup.Text=folderName;
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		//设定新的数据库备份位置
		private void button3_Click(object sender, System.EventArgs e)
		{
			try
			{
				string path="SchoolManage.exe.config";
				XmlDocument xd=new XmlDocument();
				xd.Load(path);
				//判断节点是否存在，如果存在则修改当前节点
				foreach(XmlNode xn1 in xd.SelectNodes("/configuration/appSettings/add"))
				{
					if(xn1.Attributes["key"].Value=="DatabaseBackup")
					{
						xn1.Attributes["value"].Value=textBox_LocationDBBackup.Text;
						break;
					}
				}
				//保存web.config
				xd.Save(path);
				//return true;
				MessageBox.Show("成功修改！", "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch
			{
				//return false;
				throw new Exception("Config设置文件读取失败！");
			}

			this.Dispose();
		}
	}
}
