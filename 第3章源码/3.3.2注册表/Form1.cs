using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32 ;  //导入使用到的名称空间
namespace 注册表
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(24, 24);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(128, 184);
			this.listBox1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(176, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 32);
			this.button1.TabIndex = 1;
			this.button1.Text = "读取注册表";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(176, 80);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 32);
			this.button2.TabIndex = 2;
			this.button2.Text = "创建子键";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(176, 128);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(80, 32);
			this.button3.TabIndex = 3;
			this.button3.Text = "创建主键";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(176, 176);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(80, 32);
			this.button4.TabIndex = 4;
			this.button4.Text = "重命名键值";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(104, 216);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(104, 24);
			this.button5.TabIndex = 5;
			this.button5.Text = "button5";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 246);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listBox1);
			this.Name = "Form1";
			this.Text = "创建和修改注册信息";
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
          //以列表形式显示"HARDWARE"下面一层的子键和键值
		private void button1_Click(object sender, System.EventArgs e)//读取注册表
		{
			listBox1.Items.Clear ( ) ;
			RegistryKey hklm = Registry.LocalMachine ;
            //打开"HARDWARE"子键
            RegistryKey software = hklm.OpenSubKey("HARDWARE");////打开"SYSTEM"子键
			foreach ( string site in software.GetSubKeyNames ( ) )
				//开始遍历由子键名称组成的字符串数组
			{
				listBox1.Items.Add ( site ) ;
				//在列表中加入子键名称
				RegistryKey sitekey = software.OpenSubKey ( site ) ;
				//打开此子键
				foreach ( string sValName in sitekey.GetValueNames ( ) )
					//开始遍历由指定子键拥有的键值名称组成的字符串数组
				{
					listBox1.Items.Add ( " " + sValName + ": " + sitekey.GetValue ( sValName ) ) ;
					//在列表中加入键名称和对应的键值
				}
			}
		}
          //创建子键和键值
		private void button2_Click(object sender, System.EventArgs e)//创建子键
		{
			listBox1.Items.Clear ( ) ;
			RegistryKey hklm = Registry.LocalMachine ;
			RegistryKey software = hklm.OpenSubKey ( "HARDWARE", true ) ;
			RegistryKey ddd = software.CreateSubKey ( "ddd" ) ;
			ddd.SetValue ( "www" , "1234" );
		}
         //创建一个主键并创建一个键值
		private void button3_Click(object sender, System.EventArgs e)
		{
			listBox1.Items.Clear ( ) ;
			RegistryKey hklm = Registry.LocalMachine ;
			RegistryKey software = hklm.OpenSubKey ( "HARDWARE", true ) ;
			RegistryKey main1 = software.CreateSubKey ( "main" ) ;
			RegistryKey ddd = main1.CreateSubKey ( "sub" ) ;
			ddd.SetValue ( "value" , "1234" ) ;
		}
          //重命名一个存在的键值
		private void button4_Click(object sender, System.EventArgs e)
		{
			listBox1.Items.Clear ( ) ;
			RegistryKey hklm = Registry.LocalMachine ;
			RegistryKey software = hklm.OpenSubKey ( "HARDWARE", true ) ;
			RegistryKey dddw = software.OpenSubKey ( "main" , true ) ;
			dddw.SetValue ( "sub" , "abcd" ) ;
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
		//OpenSubKey打开Run子键			
		RegistryKey KeyCon=Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run",true);
	    string myKey= "myProgram2";
	    //设置注册表中的启动键
	    if((string)KeyCon.GetValue(myKey,"noname") == "noname")//指定的键不存在
        {
	         string Path = "c:\\windows\\calc.exe";
	         KeyCon.SetValue(myKey,Path); //calc.exe加入注册表中
			 MessageBox.Show("calc.exe成功设为自启动程序"); 
         }
		}

	}
}
