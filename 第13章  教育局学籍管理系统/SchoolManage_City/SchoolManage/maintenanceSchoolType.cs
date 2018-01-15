using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SchoolManage
{
	/// <summary>
	/// maintenanceSchoolType 的摘要说明。
	/// </summary>
	public class maintenanceSchoolType : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_School_Type_Name;
		private System.Windows.Forms.TextBox textBox_School_Type_ID;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGrid DataGrid1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;

		protected config conn=new config();

		public maintenanceSchoolType()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//绑定DataGrid显示,未选中任何有效的项button1.Enabled=false;
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
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_School_Type_Name = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_School_Type_ID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
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
			this.DataGrid1.Location = new System.Drawing.Point(72, 48);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 90;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(312, 184);
			this.DataGrid1.TabIndex = 0;
			this.DataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(392, 253);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "确认修改";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(56, 256);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "编号";
			// 
			// textBox_School_Type_Name
			// 
			this.textBox_School_Type_Name.Location = new System.Drawing.Point(176, 254);
			this.textBox_School_Type_Name.Name = "textBox_School_Type_Name";
			this.textBox_School_Type_Name.Size = new System.Drawing.Size(80, 21);
			this.textBox_School_Type_Name.TabIndex = 3;
			this.textBox_School_Type_Name.Text = "";
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(128, 304);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(200, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "与系统相关,不能删除已有的类别！";
			// 
			// textBox_School_Type_ID
			// 
			this.textBox_School_Type_ID.Enabled = false;
			this.textBox_School_Type_ID.Location = new System.Drawing.Point(88, 254);
			this.textBox_School_Type_ID.Name = "textBox_School_Type_ID";
			this.textBox_School_Type_ID.Size = new System.Drawing.Size(24, 21);
			this.textBox_School_Type_ID.TabIndex = 3;
			this.textBox_School_Type_ID.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(120, 256);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "类别名称";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(264, 256);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "学制年数";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(392, 296);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(328, 256);
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
			this.numericUpDown1.TabIndex = 18;
			this.numericUpDown1.Value = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 0});
			this.numericUpDown1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown1_KeyPress);
			// 
			// maintenanceSchoolType
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(504, 341);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_School_Type_Name);
			this.Controls.Add(this.textBox_School_Type_ID);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DataGrid1);
			this.Controls.Add(this.label3);
			this.Name = "maintenanceSchoolType";
			this.Text = "学校类别维护";
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

			//去除'"?%=空格,修改学校类型表
			string str_Sql,errorstring="";
			str_Sql="UPDATE School_Type SET School_Type_Name='"+conn.KickOut(textBox_School_Type_Name.Text)
				+"',School_Type_Year="+numericUpDown1.Value.ToString()
				+" WHERE School_Type_ID="+textBox_School_Type_ID.Text;
			errorstring=conn.ExeSql(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("修改不成功！请检查数据库！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			MessageBox.Show("成功修改！", "提醒！",
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			
			//刷新DataGrid显示,置空各信息项,等待选中新的有效项
			str_Sql="SELECT School_Type_ID As 学校类别代码,School_Type_Name As 学校类别名,School_Type_Year As 学校类别学制 FROM School_Type";
			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");

			textBox_School_Type_ID.Text="";
			textBox_School_Type_Name.Text="";

			button1.Enabled=false;
		}

		//根据当前选中的单元格,根据当前行的情况设定当前选中的学校类型的原有信息,此时修改按钮有效
		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			DataGrid1.Select(DataGrid1.CurrentRowIndex);

			textBox_School_Type_ID.Text=DataGrid1[DataGrid1.CurrentRowIndex,0].ToString();
			textBox_School_Type_Name.Text=conn.School_Type_IDtoWhat(textBox_School_Type_ID.Text,"School_Type_Name");

			button1.Enabled=true;
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
