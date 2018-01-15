using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// SearchSchool 的摘要说明。
	/// </summary>
	public class SearchSchool : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox_QuXian;
		private System.Windows.Forms.CheckBox checkBox_InQuXian;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid DataGrid1;

		protected config conn=new config();
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox_School_ID;
		private System.Windows.Forms.TextBox textBox_School_Name;
		private System.Windows.Forms.ComboBox comboBox_School_Type;
		private System.Windows.Forms.Label label_;
		
		//创建应用程序,工作表,工作簿
		private bool useExcel;
		private Excel._Application excelApp;
		private Excel.Workbook excelBook;
		private Excel.Worksheet excelSheet;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SearchSchool()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			conn.BindComboBox("SELECT QuXian_Code,QuXian_Name FROM QuXian",comboBox_QuXian,"QuXian_Code","QuXian_Name");
			conn.BindComboBox("SELECT School_Type_ID,School_Type_Name FROM School_Type",comboBox_School_Type,"School_Type_ID","School_Type_Name");
			
			//绑定DataGrid显示
			string str_Sql,errorstring;
			str_Sql="SELECT School_ID AS 学校代码,School_Name AS 学校名称,School_Type_Name AS 学校类别,Schoolmaster AS 校长,School_Tel AS 电话,School_Zip AS 邮政编码,School_Address AS 学校地址,School_Type_Year AS 学校学制年限,Student_Count AS 学生人数,Teacher_Count AS 教师人数 FROM View_School Order By School_Type_ID,School_ID";
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
			if(useExcel==true)
			{	
				try
				{
					excelApp.Application.Workbooks.Close();
					excelApp.Application.Quit();
					excelApp.Quit();
					excelBook=null;
					excelSheet=null;
					excelApp=null;
					GC.Collect();
				}
				catch
				{
					throw new Exception("Excel 关闭错误！");
				}
			}

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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox_QuXian = new System.Windows.Forms.ComboBox();
			this.checkBox_InQuXian = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.comboBox_School_Type = new System.Windows.Forms.ComboBox();
			this.textBox_School_Name = new System.Windows.Forms.TextBox();
			this.textBox_School_ID = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label_ = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.comboBox_QuXian);
			this.groupBox1.Controls.Add(this.checkBox_InQuXian);
			this.groupBox1.Location = new System.Drawing.Point(88, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(480, 56);
			this.groupBox1.TabIndex = 58;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "已知学校所在的区县";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 23);
			this.label1.TabIndex = 55;
			this.label1.Text = "区县";
			// 
			// comboBox_QuXian
			// 
			this.comboBox_QuXian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_QuXian.Location = new System.Drawing.Point(80, 17);
			this.comboBox_QuXian.Name = "comboBox_QuXian";
			this.comboBox_QuXian.Size = new System.Drawing.Size(240, 20);
			this.comboBox_QuXian.TabIndex = 54;
			// 
			// checkBox_InQuXian
			// 
			this.checkBox_InQuXian.Location = new System.Drawing.Point(336, 20);
			this.checkBox_InQuXian.Name = "checkBox_InQuXian";
			this.checkBox_InQuXian.Size = new System.Drawing.Size(120, 24);
			this.checkBox_InQuXian.TabIndex = 52;
			this.checkBox_InQuXian.Text = "在某区县内查询";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.comboBox_School_Type);
			this.groupBox2.Controls.Add(this.textBox_School_Name);
			this.groupBox2.Controls.Add(this.textBox_School_ID);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label_);
			this.groupBox2.Location = new System.Drawing.Point(88, 88);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(512, 88);
			this.groupBox2.TabIndex = 60;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "在学校内查询（可以模糊查询）";
			// 
			// comboBox_School_Type
			// 
			this.comboBox_School_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_School_Type.Items.AddRange(new object[] {
																	  "男",
																	  "女"});
			this.comboBox_School_Type.Location = new System.Drawing.Point(112, 56);
			this.comboBox_School_Type.Name = "comboBox_School_Type";
			this.comboBox_School_Type.Size = new System.Drawing.Size(96, 20);
			this.comboBox_School_Type.TabIndex = 54;
			// 
			// textBox_School_Name
			// 
			this.textBox_School_Name.Location = new System.Drawing.Point(376, 24);
			this.textBox_School_Name.Name = "textBox_School_Name";
			this.textBox_School_Name.Size = new System.Drawing.Size(112, 21);
			this.textBox_School_Name.TabIndex = 53;
			this.textBox_School_Name.Text = "";
			// 
			// textBox_School_ID
			// 
			this.textBox_School_ID.Location = new System.Drawing.Point(112, 24);
			this.textBox_School_ID.Name = "textBox_School_ID";
			this.textBox_School_ID.Size = new System.Drawing.Size(184, 21);
			this.textBox_School_ID.TabIndex = 52;
			this.textBox_School_ID.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 26);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 51;
			this.label3.Text = "学校代码";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(312, 26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 51;
			this.label4.Text = "学校名称";
			// 
			// label_
			// 
			this.label_.Location = new System.Drawing.Point(16, 58);
			this.label_.Name = "label_";
			this.label_.Size = new System.Drawing.Size(56, 16);
			this.label_.TabIndex = 51;
			this.label_.Text = "学校类别";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(616, 144);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 59;
			this.button1.Text = "查找";
			this.button1.Click += new System.EventHandler(this.button1_Click);
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
			this.DataGrid1.Location = new System.Drawing.Point(30, 200);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 90;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(860, 320);
			this.DataGrid1.TabIndex = 61;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(712, 144);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(72, 23);
			this.button3.TabIndex = 63;
			this.button3.Text = "打印";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(808, 144);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 62;
			this.button2.Text = "退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// SearchSchool
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(920, 549);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.DataGrid1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox1);
			this.Name = "SearchSchool";
			this.Text = "查询学校信息";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			string str_Sql,errorstring;
			str_Sql="SELECT School_ID AS 学校代码,School_Name AS 学校名称,School_Type_Name AS 学校类别,Schoolmaster AS 校长,School_Tel AS 电话,School_Zip AS 邮政编码,School_Address AS 学校地址,School_Type_Year AS 学校学制年限,Student_Count AS 学生人数,Teacher_Count AS 教师人数 FROM View_School WHERE School_Type_ID="+comboBox_School_Type.SelectedValue;
		
			//条件有输入的内容则参与查找,查找到的内容和DataGrid绑定
			if(checkBox_InQuXian.Checked==true)
			{
				str_Sql=str_Sql+" AND School_ID Like '____"+comboBox_QuXian.SelectedValue+"%'";				
			}
			if(textBox_School_ID.Text!="")
			{
				str_Sql=str_Sql+" AND School_ID LIKE '%"+textBox_School_ID.Text+"%'";
				
			}
			if(textBox_School_Name.Text!="")
			{
				str_Sql=str_Sql+" AND School_Name LIKE '%"+textBox_School_Name.Text+"%'";				
			}

			str_Sql=str_Sql+" Order By School_Type_ID,School_ID ";
			errorstring=conn.Fill(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("查找失败！请检查数据库！"+errorstring, "提醒！", 
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

		private void button3_Click(object sender, System.EventArgs e)
		{
			if(conn.ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show("无可打印内容！", "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			int i,j=0;
			
			useExcel=true;
			excelApp = new Excel.ApplicationClass();
			Excel.Workbook excelBook =excelApp.Workbooks.Add(1);
			Excel.Worksheet excelSheet=(Excel.Worksheet)excelBook.Worksheets[1];

			try
			{
				//设置表头
				excelSheet.Cells[1,1]="学校代码";
				excelSheet.Cells[1,2]="学校名称";
				excelSheet.Cells[1,3]="学校类别";
				excelSheet.Cells[1,4]="校长";
				excelSheet.Cells[1,5]="电话";
				excelSheet.Cells[1,6]="邮政编码";
				excelSheet.Cells[1,7]="学校地址";
				excelSheet.Cells[1,8]="学校学制年限";
				excelSheet.Cells[1,9]="学生人数";
				excelSheet.Cells[1,10]="教师人数";
			
				//设置报表头格式
				excelSheet.get_Range(excelSheet.Cells[1,1],excelSheet.Cells[1,10]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
				excelSheet.get_Range(excelSheet.Cells[1,1],excelSheet.Cells[1,10]).Font.Bold = true;
			
				//填充表中各单元格
				for(i=1;i<=conn.ds.Tables[0].Rows.Count;i++)
				{				
					for(j=1;j<=conn.ds.Tables[0].Columns.Count;j++)
					{
						excelSheet.Cells[i+1,j]="'"+conn.ds.Tables[0].Rows[i-1][j-1].ToString();
					}
				}

				excelSheet.get_Range(excelSheet.Cells[1,1],excelSheet.Cells[i+1,j]).Select();
				excelSheet.get_Range(excelSheet.Cells[1,1],excelSheet.Cells[i+1,j]).Columns.AutoFit();
			
				excelApp.Visible=true;
			}
			catch
			{
				throw new Exception("Excel error");
			}
		}
	}
}
