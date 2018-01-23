using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// QuXian_Office_Committee 的摘要说明。
	/// </summary>
	public class QuXian_Office_Committee : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox_QuXian;
		private System.Windows.Forms.ComboBox comboBox_Committee;
		private System.Windows.Forms.ComboBox comboBox_Office;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGrid DataGrid1;
		private System.Windows.Forms.Button button_QuXian;
		private System.Windows.Forms.Button button_Office;
		private System.Windows.Forms.Button button_Committee;
		private System.Windows.Forms.Button button1;

		//创建应用程序,工作表,工作簿
		private bool useExcel;
		private Excel._Application excelApp;
		private Excel.Workbook excelBook;
		private Excel.Worksheet excelSheet;

		protected config conn=new config();

		public QuXian_Office_Committee()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//绑定下拉列表显示区县
			string str_Sql,errorstring;

			button1.Enabled=false;

			errorstring=conn.BindComboBox("Select * from QuXian WHERE QuXian_ID<>9",comboBox_QuXian,"QuXian_ID","QuXian_Name");
			if(errorstring!="OK")
			{
				MessageBox.Show("请检查数据库！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button_QuXian.Enabled=false;
				button_Office.Enabled=false;
				button_Committee.Enabled=false;
				return;
			}
			
			conn.BindComboBox("Select * from Office WHERE QuXian_ID_OfficeIn="+comboBox_QuXian.SelectedValue.ToString(),comboBox_Office,"Office_ID","Office_Name");
			if(comboBox_Office.Items.Count==0)
				conn.BindComboBox("Select * from Office WHERE Office_ID=0",comboBox_Office,"Office_ID","Office_Name");
			conn.BindComboBox("Select * from Committee WHERE Office_ID="+comboBox_Office.SelectedValue.ToString(),comboBox_Committee,"Committee_ID","Committee_Name");
			if(comboBox_Committee.Items.Count==0)
				conn.BindComboBox("Select * from Committee WHERE Committee_ID=0",comboBox_Committee,"Committee_ID","Committee_Name");

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
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox_QuXian = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox_Committee = new System.Windows.Forms.ComboBox();
			this.comboBox_Office = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button_QuXian = new System.Windows.Forms.Button();
			this.button_Office = new System.Windows.Forms.Button();
			this.button_Committee = new System.Windows.Forms.Button();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.comboBox_QuXian);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.comboBox_Committee);
			this.groupBox1.Controls.Add(this.comboBox_Office);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(64, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(336, 160);
			this.groupBox1.TabIndex = 55;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "请选择要浏览的区县_办事处_社区";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(40, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 23);
			this.label3.TabIndex = 53;
			this.label3.Text = "区县";
			// 
			// comboBox_QuXian
			// 
			this.comboBox_QuXian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_QuXian.Location = new System.Drawing.Point(112, 32);
			this.comboBox_QuXian.Name = "comboBox_QuXian";
			this.comboBox_QuXian.Size = new System.Drawing.Size(176, 20);
			this.comboBox_QuXian.TabIndex = 52;
			this.comboBox_QuXian.SelectionChangeCommitted += new System.EventHandler(this.comboBox_QuXian_SelectionChangeCommitted);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(40, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 51;
			this.label2.Text = "办事处";
			// 
			// comboBox_Committee
			// 
			this.comboBox_Committee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Committee.Location = new System.Drawing.Point(112, 112);
			this.comboBox_Committee.Name = "comboBox_Committee";
			this.comboBox_Committee.Size = new System.Drawing.Size(176, 20);
			this.comboBox_Committee.TabIndex = 2;
			// 
			// comboBox_Office
			// 
			this.comboBox_Office.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Office.Location = new System.Drawing.Point(112, 72);
			this.comboBox_Office.Name = "comboBox_Office";
			this.comboBox_Office.Size = new System.Drawing.Size(176, 20);
			this.comboBox_Office.TabIndex = 1;
			this.comboBox_Office.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Office_SelectionChangeCommitted);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 120);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 51;
			this.label1.Text = "社区";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(536, 176);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 55;
			this.button2.Text = "退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button_QuXian
			// 
			this.button_QuXian.Location = new System.Drawing.Point(416, 40);
			this.button_QuXian.Name = "button_QuXian";
			this.button_QuXian.Size = new System.Drawing.Size(216, 23);
			this.button_QuXian.TabIndex = 54;
			this.button_QuXian.Text = "统计各县区学生人数";
			this.button_QuXian.Click += new System.EventHandler(this.button_QuXian_Click);
			// 
			// button_Office
			// 
			this.button_Office.Location = new System.Drawing.Point(416, 80);
			this.button_Office.Name = "button_Office";
			this.button_Office.Size = new System.Drawing.Size(216, 23);
			this.button_Office.TabIndex = 54;
			this.button_Office.Text = "统计选中县区下属各办事处学生人数";
			this.button_Office.Click += new System.EventHandler(this.button_Office_Click);
			// 
			// button_Committee
			// 
			this.button_Committee.Location = new System.Drawing.Point(416, 120);
			this.button_Committee.Name = "button_Committee";
			this.button_Committee.Size = new System.Drawing.Size(216, 23);
			this.button_Committee.TabIndex = 54;
			this.button_Committee.Text = "统计选中办事处下属各社区学生人数";
			this.button_Committee.Click += new System.EventHandler(this.button_Committee_Click);
			// 
			// DataGrid1
			// 
			this.DataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.DataGrid1.BackColor = System.Drawing.Color.DarkGray;
			this.DataGrid1.BackgroundColor = System.Drawing.Color.LightGray;
			this.DataGrid1.CaptionBackColor = System.Drawing.Color.White;
			this.DataGrid1.CaptionFont = new System.Drawing.Font("Verdana", 10F);
			this.DataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
			this.DataGrid1.CaptionText = "                                        学生数统计";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(100, 250);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 90;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(500, 300);
			this.DataGrid1.TabIndex = 56;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(424, 176);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 55;
			this.button1.Text = "打印";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// QuXian_Office_Committee
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(664, 597);
			this.Controls.Add(this.DataGrid1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button_QuXian);
			this.Controls.Add(this.button_Office);
			this.Controls.Add(this.button_Committee);
			this.Controls.Add(this.button1);
			this.Name = "QuXian_Office_Committee";
			this.Text = " 分区县_办事处_社区学生数统计";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void comboBox_QuXian_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			conn.BindComboBox("Select * from Office WHERE QuXian_ID_OfficeIn="+comboBox_QuXian.SelectedValue.ToString(),comboBox_Office,"Office_ID","Office_Name");	

			if(comboBox_Office.Items.Count==0)
				conn.BindComboBox("Select * from Office WHERE Office_ID=0",comboBox_Office,"Office_ID","Office_Name");
			
			conn.BindComboBox("Select * from Committee WHERE Office_ID="+comboBox_Office.SelectedValue.ToString(),comboBox_Committee,"Committee_ID","Committee_Name");
			if(comboBox_Committee.Items.Count==0)
				conn.BindComboBox("Select * from Committee WHERE Committee_ID=0",comboBox_Committee,"Committee_ID","Committee_Name");
	
		}

		private void comboBox_Office_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			conn.BindComboBox("Select * from Committee WHERE Office_ID="+comboBox_Office.SelectedValue.ToString(),comboBox_Committee,"Committee_ID","Committee_Name");
			if(comboBox_Committee.Items.Count==0)
				conn.BindComboBox("Select * from Committee WHERE Committee_ID=0",comboBox_Committee,"Committee_ID","Committee_Name");
	
		}

		private void button_QuXian_Click(object sender, System.EventArgs e)
		{
			button1.Enabled=true;

			//绑定DataGrid显示
			string str_Sql="select QuXian_Name AS 区县,Count(Student_ID) AS 学生数 FROM View_StudentClass_Detail_City4 Group By QuXian_Name";

			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
		}

		private void button_Office_Click(object sender, System.EventArgs e)
		{
			button1.Enabled=true;

			//绑定DataGrid显示
			string str_Sql="select Office_Name AS 办事处,Count(Student_ID) AS 学生数 FROM View_StudentClass_Detail_City4 where QuXian_ID="
				+comboBox_QuXian.SelectedValue.ToString()+" Group By Office_Name";

			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
			
		}

		private void button_Committee_Click(object sender, System.EventArgs e)
		{
			button1.Enabled=true;

			//绑定DataGrid显示
			string str_Sql="select Committee_Name AS 社区,Count(Student_ID) AS 学生数 FROM View_StudentClass_Detail_City4 where Office_ID="
				+comboBox_Office.SelectedValue.ToString()+"Group By Committee_Name";

			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
		
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();	
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			useExcel=true;
			int i=0,j=0;

			excelApp = new Excel.ApplicationClass();
			Excel.Workbook excelBook =excelApp.Workbooks.Add(1);
			Excel.Worksheet excelSheet=(Excel.Worksheet)excelBook.Worksheets[1];

			if(conn.ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show("无可打印内容！", "提醒！",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			try
			{
				//设置表头
				excelSheet.Cells[2,1]="区域";				
				excelSheet.Cells[2,2]="学生人数";
			
				//设置表头格式
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,2]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,2]).Font.Bold = true;
							
				//填充表中各单元格
				for(i=1;i<=conn.ds.Tables[0].Rows.Count;i++)
				{				
					for(j=1;j<=conn.ds.Tables[0].Columns.Count;j++)
					{
						excelSheet.Cells[i+2,j]="'"+conn.ds.Tables[0].Rows[i-1][j-1].ToString();
					}
				}
				//设置报表表格为最适应宽度
				excelSheet.get_Range(excelSheet.Cells[1,1],excelSheet.Cells[i+1,j]).Select();
				excelSheet.get_Range(excelSheet.Cells[1,1],excelSheet.Cells[i+1,j]).Columns.AutoFit();
			
				excelApp.Visible=true;
				//excelApp.Quit();
			}
			catch
			{
				throw new Exception("Excel error");
			}
		}
	}
}
