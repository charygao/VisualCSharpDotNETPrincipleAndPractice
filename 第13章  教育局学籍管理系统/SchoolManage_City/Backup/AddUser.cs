using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// AddUser 的摘要说明。
	/// </summary>
	public class AddUser : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid DataGrid1;
		private System.Windows.Forms.TextBox textBox_UserName;
		private System.Windows.Forms.TextBox textBox_PassWord;
		private System.Windows.Forms.CheckBox checkBox_ReadOnly;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected config conn=new config();
		public AddUser()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			
			//按数据库里边存储的用户绑定绑定DataGrid显示
			string str_Sql,errorstring;
			str_Sql="SELECT UserName AS 用户名,PassWord AS 密码,ReadOnly AS 仅为只读用户 FROM Users";
			errorstring=conn.Fill(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("请检查数据库！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
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
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_PassWord = new System.Windows.Forms.TextBox();
			this.textBox_UserName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.checkBox_ReadOnly = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(284, 440);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 50;
			this.button2.Text = "退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(168, 392);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 49;
			this.label2.Text = "密码";
			// 
			// textBox_PassWord
			// 
			this.textBox_PassWord.Location = new System.Drawing.Point(208, 392);
			this.textBox_PassWord.Name = "textBox_PassWord";
			this.textBox_PassWord.Size = new System.Drawing.Size(104, 21);
			this.textBox_PassWord.TabIndex = 48;
			this.textBox_PassWord.Text = "";
			// 
			// textBox_UserName
			// 
			this.textBox_UserName.Location = new System.Drawing.Point(80, 392);
			this.textBox_UserName.Name = "textBox_UserName";
			this.textBox_UserName.Size = new System.Drawing.Size(72, 21);
			this.textBox_UserName.TabIndex = 47;
			this.textBox_UserName.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 392);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 46;
			this.label1.Text = "用户名";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(132, 440);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 45;
			this.button1.Text = "确认添加";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// DataGrid1
			// 
			this.DataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.DataGrid1.BackColor = System.Drawing.Color.DarkGray;
			this.DataGrid1.BackgroundColor = System.Drawing.Color.LightGray;
			this.DataGrid1.CaptionBackColor = System.Drawing.Color.White;
			this.DataGrid1.CaptionFont = new System.Drawing.Font("Verdana", 10F);
			this.DataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
			this.DataGrid1.CaptionText = "                   现有用户情况";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(124, 30);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 90;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(312, 320);
			this.DataGrid1.TabIndex = 44;
			// 
			// checkBox_ReadOnly
			// 
			this.checkBox_ReadOnly.Location = new System.Drawing.Point(352, 392);
			this.checkBox_ReadOnly.Name = "checkBox_ReadOnly";
			this.checkBox_ReadOnly.TabIndex = 52;
			this.checkBox_ReadOnly.Text = "仅为只读用户";
			// 
			// AddUser
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(576, 494);
			this.Controls.Add(this.checkBox_ReadOnly);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_PassWord);
			this.Controls.Add(this.textBox_UserName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DataGrid1);
			this.Name = "AddUser";
			this.Text = "添加用户";
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (conn.KickOut(textBox_UserName.Text)=="") 
			{
				MessageBox.Show("必须输入用户名！", "警告！", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (textBox_UserName.Text.Length>20)
			{
				MessageBox.Show("请不要超长输入用户名！", "警告！", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			bool bool_UserName_Had=true;
			try
			{
				bool_UserName_Had=conn.UserName_Had(textBox_UserName.Text);
			}
			catch
			{
				MessageBox.Show("数据库错误！！", "警告！", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			if (bool_UserName_Had==true)
			{
				MessageBox.Show("请不要输入重复的用户名！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (textBox_PassWord.Text=="") 
			{
				MessageBox.Show("必须输入密码！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (textBox_PassWord.Text.Length>20)
			{
				MessageBox.Show("请不要超长输入密码！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (conn.Sniffer_In(textBox_PassWord.Text)||conn.Sniffer_In(textBox_UserName.Text))
			{
				MessageBox.Show("用户名或密码不得用空格或者'\"?%=空格！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			
			//去除'"?%=空格,插入办事处表
			string errorstring="",str_ReadOnly,str_Sql;
			if(checkBox_ReadOnly.Checked==true)str_ReadOnly="1";
			else str_ReadOnly="0";
			str_Sql="insert into Users (UserName,PassWord,ReadOnly) values ('"
				+conn.KickOut(textBox_UserName.Text)+"','"+conn.KickOut(textBox_PassWord.Text)+"',"+str_ReadOnly+")";

			errorstring=conn.ExeSql(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("未成功添加！请检查数据库！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			MessageBox.Show("成功添加！", "提醒！", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

			//刷新DataGrid显示
			str_Sql="SELECT UserName AS 用户名,PassWord AS 密码,ReadOnly AS 仅为只读用户 FROM Users";
			try
			{
				errorstring=conn.Fill(str_Sql);
			}
			catch
			{				
				MessageBox.Show(errorstring, "提醒！",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				conn.Close();
			}
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
			
			textBox_UserName.Text="";
			textBox_PassWord.Text="";
			checkBox_ReadOnly.Checked=true;
		}
	}
}
