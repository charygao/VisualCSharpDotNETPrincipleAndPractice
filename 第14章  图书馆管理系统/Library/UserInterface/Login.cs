using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using Library.UserInterface;
namespace Library
{
	/// <summary>
	/// Login 的摘要说明。
	/// </summary>
	public class Login : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox textUserID;
		private System.Windows.Forms.TextBox textUserPassword;
		private System.Windows.Forms.Button btnOk;
		private Library.UserInterface.LoginInitialize li=new LoginInitialize();
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Login()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Login));
			this.btnCancel = new System.Windows.Forms.Button();
			this.textUserID = new System.Windows.Forms.TextBox();
			this.textUserPassword = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
			this.btnCancel.Location = new System.Drawing.Point(224, 176);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(40, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// textUserID
			// 
			this.textUserID.Location = new System.Drawing.Point(208, 80);
			this.textUserID.Name = "textUserID";
			this.textUserID.Size = new System.Drawing.Size(96, 21);
			this.textUserID.TabIndex = 0;
			this.textUserID.Text = "";
			this.textUserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPress);
			// 
			// textUserPassword
			// 
			this.textUserPassword.Location = new System.Drawing.Point(208, 112);
			this.textUserPassword.Name = "textUserPassword";
			this.textUserPassword.PasswordChar = '*';
			this.textUserPassword.Size = new System.Drawing.Size(96, 21);
			this.textUserPassword.TabIndex = 1;
			this.textUserPassword.Text = "";
			this.textUserPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPress);
			// 
			// btnOk
			// 
			this.btnOk.BackColor = System.Drawing.SystemColors.Control;
			this.btnOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOk.BackgroundImage")));
			this.btnOk.Location = new System.Drawing.Point(104, 176);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(40, 23);
			this.btnOk.TabIndex = 6;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// Login
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(358, 237);
			this.ControlBox = false;
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.textUserPassword);
			this.Controls.Add(this.textUserID);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Login";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			
			Application.Run(new Login());
		}
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if(textUserID.Text==""&&textUserPassword.Text=="")
			{
				Application.Exit();
			
			}
			else
			{
				this.textUserID.Text="";
				this.textUserPassword.Text="";
				this.textUserID.Focus();
			}
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{	
			li.login(textUserID,textUserPassword,this);
		}

		
		

		
		private void keyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==(char)13)
			{
				if(textUserID.Text!=""&&textUserPassword.Text!="")
				{
					li.login(this.textUserID,this.textUserPassword,this);
				
				}
				else if (textUserID.Text==""&&textUserPassword.Text!="" )
				{
					textUserID.Focus();
				}
				 else if (textUserID.Text!=""&&textUserPassword.Text=="")
				{
					textUserPassword.Focus();
				}
				else if (textUserID.Text==""&&textUserPassword.Text=="")
				{
					MessageBox.Show("请输入用户名和密码");
					textUserID.Focus();
				}
			}
		
			

	}

		
	}
}