using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// AddSchool_Type 的摘要说明。
	/// </summary>
	public class AddSchool_Type : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_School_Type_Name;
		private System.Windows.Forms.TextBox textBox_School_Type_ID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid DataGrid1;
		
		protected config conn=new config();
		private System.Windows.Forms.NumericUpDown numericUpDown1;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddSchool_Type()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

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
			DataGrid1.SetDataBinding(conn.ds,"TableIn");

			textBox_School_Type_ID.Text=conn.GetMaxId("School_Type_ID","School_Type");

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
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_School_Type_Name = new System.Windows.Forms.TextBox();
			this.textBox_School_Type_ID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(256, 312);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 16;
			this.button2.Text = "退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(244, 266);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 15;
			this.label4.Text = "学制年数";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(100, 266);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 14;
			this.label2.Text = "类别名称";
			// 
			// textBox_School_Type_Name
			// 
			this.textBox_School_Type_Name.Location = new System.Drawing.Point(156, 264);
			this.textBox_School_Type_Name.Name = "textBox_School_Type_Name";
			this.textBox_School_Type_Name.Size = new System.Drawing.Size(80, 21);
			this.textBox_School_Type_Name.TabIndex = 12;
			this.textBox_School_Type_Name.Text = "";
			// 
			// textBox_School_Type_ID
			// 
			this.textBox_School_Type_ID.Enabled = false;
			this.textBox_School_Type_ID.Location = new System.Drawing.Point(68, 264);
			this.textBox_School_Type_ID.Name = "textBox_School_Type_ID";
			this.textBox_School_Type_ID.Size = new System.Drawing.Size(24, 21);
			this.textBox_School_Type_ID.TabIndex = 11;
			this.textBox_School_Type_ID.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(36, 266);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "编号";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(120, 312);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 8;
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
			this.DataGrid1.CaptionText = "            现有几种学校类别情况";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(52, 40);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 90;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(312, 184);
			this.DataGrid1.TabIndex = 7;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(304, 264);
			this.numericUpDown1.Maximum = new System.Decimal(new int[] {
																		   20,
																		   0,
																		   0,
																		   0});
			this.numericUpDown1.Minimum = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(40, 21);
			this.numericUpDown1.TabIndex = 17;
			this.numericUpDown1.Value = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 0});
			this.numericUpDown1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown1_KeyPress);
			// 
			// AddSchool_Type
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(480, 365);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_School_Type_Name);
			this.Controls.Add(this.textBox_School_Type_ID);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DataGrid1);
			this.Name = "AddSchool_Type";
			this.Text = "学校类别添加";
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			
			if (conn.KickOut(textBox_School_Type_Name.Text)=="") 
			{
				MessageBox.Show("必须输入学校类型名称！", "警告！", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (textBox_School_Type_Name.Text.Length>15)
			{
				MessageBox.Show("请不要超长输入学校类型名称！", "警告！", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			
			string str_Sql,errorstring="";
			str_Sql="INSERT INTO School_Type values("+textBox_School_Type_ID.Text.Trim()+",'"
													+conn.KickOut(textBox_School_Type_Name.Text.Trim())+"',"
													+numericUpDown1.Value.ToString()+")";
			errorstring=conn.ExeSql(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("未成功添加！请检查数据库！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			MessageBox.Show("成功添加！", "提醒！", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

			str_Sql="SELECT School_Type_ID As 学校类别代码,School_Type_Name As 学校类别名,School_Type_Year As 学校类别学制 FROM School_Type";
			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
			DataGrid1.Select(conn.ds.Tables["TableIn"].Rows.Count-1);

			textBox_School_Type_ID.Text=conn.GetMaxId("School_Type_ID","School_Type");

		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void numericUpDown1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = true;
		}
	}
}
