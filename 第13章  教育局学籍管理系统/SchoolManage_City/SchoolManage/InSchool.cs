using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// InSchool 的摘要说明。
	/// </summary>
	public class InSchool : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox_School_ID;
		private System.Windows.Forms.TextBox textBox2_School_Name;
		private System.Windows.Forms.TextBox textBox_Schoolmaster;
		private System.Windows.Forms.TextBox textBox_School_Tel;
		private System.Windows.Forms.TextBox textBox_School_Zip;
		private System.Windows.Forms.TextBox textBox_School_Address;
		private System.Windows.Forms.ComboBox comboBox1_School_Type;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGrid DataGrid1;
		protected config conn=new config();

		public InSchool()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//判断数据库连通
			string str_Sql,errorstring;
			str_Sql="SELECT School_Type_ID As 学校类别代码,School_Type_Name As 学校类别名,School_Type_Year As 学校类别学制 FROM School_Type";
			errorstring=conn.Fill(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("请检查数据库！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}

			//无数据的时候不绑定DataGrid
			str_Sql="SELECT School_ID AS 学校代码,School_Name AS 学校名称,School_Type_Name AS 学校类别,Schoolmaster AS 校长,School_Tel AS 电话,School_Zip AS 邮政编码,School_Address AS 学校地址,School_Type_Year AS 学校学制年限 FROM View_School Order By School_Type_ID,School_ID";
			errorstring=conn.Fill(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("数据库为空！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
			
			//按数据库里边存储的学校类型绑定下拉列表
			conn.BindComboBox("Select * from School_Type",comboBox1_School_Type,"School_Type_ID","School_Type_Name");
		
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
			this.textBox_School_ID = new System.Windows.Forms.TextBox();
			this.textBox2_School_Name = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_Schoolmaster = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_School_Tel = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_School_Zip = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox_School_Address = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.comboBox1_School_Type = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(72, 319);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "学校代码：";
			// 
			// textBox_School_ID
			// 
			this.textBox_School_ID.Location = new System.Drawing.Point(152, 320);
			this.textBox_School_ID.Name = "textBox_School_ID";
			this.textBox_School_ID.Size = new System.Drawing.Size(96, 21);
			this.textBox_School_ID.TabIndex = 1;
			this.textBox_School_ID.Text = "";
			// 
			// textBox2_School_Name
			// 
			this.textBox2_School_Name.Location = new System.Drawing.Point(376, 320);
			this.textBox2_School_Name.Name = "textBox2_School_Name";
			this.textBox2_School_Name.Size = new System.Drawing.Size(192, 21);
			this.textBox2_School_Name.TabIndex = 3;
			this.textBox2_School_Name.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(296, 319);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "学校名称：";
			// 
			// textBox_Schoolmaster
			// 
			this.textBox_Schoolmaster.Location = new System.Drawing.Point(376, 360);
			this.textBox_Schoolmaster.Name = "textBox_Schoolmaster";
			this.textBox_Schoolmaster.Size = new System.Drawing.Size(96, 21);
			this.textBox_Schoolmaster.TabIndex = 5;
			this.textBox_Schoolmaster.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(296, 360);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "校长：";
			// 
			// textBox_School_Tel
			// 
			this.textBox_School_Tel.Location = new System.Drawing.Point(152, 400);
			this.textBox_School_Tel.Name = "textBox_School_Tel";
			this.textBox_School_Tel.Size = new System.Drawing.Size(96, 21);
			this.textBox_School_Tel.TabIndex = 7;
			this.textBox_School_Tel.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(72, 399);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "电话：";
			// 
			// textBox_School_Zip
			// 
			this.textBox_School_Zip.Location = new System.Drawing.Point(376, 400);
			this.textBox_School_Zip.Name = "textBox_School_Zip";
			this.textBox_School_Zip.Size = new System.Drawing.Size(96, 21);
			this.textBox_School_Zip.TabIndex = 9;
			this.textBox_School_Zip.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(296, 399);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "邮政编码：";
			// 
			// textBox_School_Address
			// 
			this.textBox_School_Address.Location = new System.Drawing.Point(152, 440);
			this.textBox_School_Address.Name = "textBox_School_Address";
			this.textBox_School_Address.Size = new System.Drawing.Size(384, 21);
			this.textBox_School_Address.TabIndex = 11;
			this.textBox_School_Address.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(72, 448);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 23);
			this.label6.TabIndex = 10;
			this.label6.Text = "学校地址：";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(72, 360);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 23);
			this.label7.TabIndex = 12;
			this.label7.Text = "学校类别：";
			// 
			// comboBox1_School_Type
			// 
			this.comboBox1_School_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1_School_Type.Location = new System.Drawing.Point(152, 360);
			this.comboBox1_School_Type.Name = "comboBox1_School_Type";
			this.comboBox1_School_Type.Size = new System.Drawing.Size(96, 20);
			this.comboBox1_School_Type.TabIndex = 13;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(200, 480);
			this.button1.Name = "button1";
			this.button1.TabIndex = 14;
			this.button1.Text = "确定";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(368, 480);
			this.button2.Name = "button2";
			this.button2.TabIndex = 15;
			this.button2.Text = "退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// DataGrid1
			// 
			this.DataGrid1.AllowDrop = true;
			this.DataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.DataGrid1.BackColor = System.Drawing.Color.DarkGray;
			this.DataGrid1.BackgroundColor = System.Drawing.Color.LightGray;
			this.DataGrid1.CaptionBackColor = System.Drawing.Color.White;
			this.DataGrid1.CaptionFont = new System.Drawing.Font("Verdana", 10F);
			this.DataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
			this.DataGrid1.CaptionText = "                                     学校信息";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(30, 30);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 90;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(600, 270);
			this.DataGrid1.TabIndex = 46;
			// 
			// InSchool
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(656, 533);
			this.Controls.Add(this.DataGrid1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.comboBox1_School_Type);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBox_School_Address);
			this.Controls.Add(this.textBox_School_Zip);
			this.Controls.Add(this.textBox_School_Tel);
			this.Controls.Add(this.textBox_Schoolmaster);
			this.Controls.Add(this.textBox2_School_Name);
			this.Controls.Add(this.textBox_School_ID);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "InSchool";
			this.Text = "录入学校信息";
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			string str_Sql,errorstring="";

			if (conn.KickOut(textBox_School_ID.Text)=="") 
			{
				MessageBox.Show("必须输入学校代码！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (conn.KickOut(textBox2_School_Name.Text)=="") 
			{
				MessageBox.Show("必须输入学校名称！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (textBox_School_ID.Text.Length!=12)
			{
				MessageBox.Show("学校代码只能为12位！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			if (textBox2_School_Name.Text.Length>50)
			{
				MessageBox.Show("请不要超长输入学校名称！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (textBox_Schoolmaster.Text.Length>50) 
			{
				MessageBox.Show("请不要超长输入校长名！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (textBox_School_Tel.Text.Length>20)
			{
				MessageBox.Show("请不要超长输入电话号码！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (textBox_School_Zip.Text.Length!=6) 
			{
				MessageBox.Show("邮编只能为六位数！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (textBox_School_Address.Text.Length>100) 
			{
				MessageBox.Show("请不要超长输入地址！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (conn.School_ID_Had(textBox_School_ID.Text))
			{
				MessageBox.Show("请不要输入重复的学校代码！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
		
			//去除'"?%=空格,插入办事处表
			str_Sql="insert into School (School_ID,School_Name,School_Type_ID,Schoolmaster,School_Tel,School_Zip,School_Address) values ('"
				+conn.KickOut(textBox_School_ID.Text)+"','"+conn.KickOut(textBox2_School_Name.Text)+"',"
				+comboBox1_School_Type.SelectedValue.ToString()+",'"				
				+conn.KickOut(textBox_Schoolmaster.Text)+"','"
				+conn.KickOut(textBox_School_Tel.Text)+"','"
				+conn.KickOut(textBox_School_Zip.Text)+"','"
				+conn.KickOut(textBox_School_Address.Text)+"')";

			errorstring=conn.ExeSql(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("未成功添加！请检查数据库！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			MessageBox.Show("成功添加！"+errorstring, "提醒！", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

			//刷新DataGrid显示
			str_Sql="SELECT School_ID AS 学校代码,School_Name AS 学校名称,School_Type_Name AS 学校类别,Schoolmaster AS 校长,School_Tel AS 电话,School_Zip AS 邮政编码,School_Address AS 学校地址,School_Type_Year AS 学校学制年限 FROM View_School";
			errorstring=conn.Fill(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("请检查数据库！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			DataGrid1.SetDataBinding(conn.ds,"TableIn");			
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();

		}
	}
}
