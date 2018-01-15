using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// StatisticsTeacher_QuXian 的摘要说明。
	/// </summary>
	public class StatisticsTeacher_QuXian : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox comboBox_QuXian;
		private System.Windows.Forms.Label label_SchoolCount;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGrid DataGrid1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		protected config conn=new config();

		//创建应用程序,工作表,工作簿
		private bool useExcel;
		private Excel._Application excelApp;
		private Excel.Workbook excelBook;
		private Excel.Worksheet excelSheet;

		public StatisticsTeacher_QuXian()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			conn.BindComboBox("Select * FROM QuXian WHERE QuXian_ID<>9",comboBox_QuXian,"QuXian_Code","QuXian_Name");	
			
			/*
Count(*) AS CountHowmany
[0]["CountHowmany"].ToString();

			string str_Sql="Select * from View_Teacher WHERE QuXian_Code='"+comboBox_QuXian.SelectedValue.ToString()+"'"; 
			string errorstring=conn.Fill(str_Sql);
			label_SchoolCount.Text=conn.ds.Tables[0].Rows.Count.ToString();*/
			string str_Sql="Select Count(*) AS CountHowmany from View_Teacher WHERE QuXian_Code='"+comboBox_QuXian.SelectedValue.ToString()+"'"; 
			string errorstring=conn.Fill(str_Sql);
			label_SchoolCount.Text=conn.ds.Tables[0].Rows[0]["CountHowmany"].ToString();

			//conn.ds.Clear();
			str_Sql="select * FROM View_QuXian_Teacher_Statistics WHERE 区县代码='"+comboBox_QuXian.SelectedValue.ToString()+"'";
			errorstring=conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");

			DataGridTableStyle MyStyle =new DataGridTableStyle();
			MyStyle.MappingName = "TableIn";
			DataGrid1.TableStyles.Add(MyStyle);
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
			this.comboBox_QuXian = new System.Windows.Forms.ComboBox();
			this.label_SchoolCount = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBox_QuXian
			// 
			this.comboBox_QuXian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_QuXian.Location = new System.Drawing.Point(64, 24);
			this.comboBox_QuXian.Name = "comboBox_QuXian";
			this.comboBox_QuXian.Size = new System.Drawing.Size(112, 20);
			this.comboBox_QuXian.TabIndex = 53;
			this.comboBox_QuXian.SelectionChangeCommitted += new System.EventHandler(this.comboBox_QuXian_SelectionChangeCommitted);
			// 
			// label_SchoolCount
			// 
			this.label_SchoolCount.Location = new System.Drawing.Point(216, 24);
			this.label_SchoolCount.Name = "label_SchoolCount";
			this.label_SchoolCount.Size = new System.Drawing.Size(56, 23);
			this.label_SchoolCount.TabIndex = 52;
			this.label_SchoolCount.Text = "共有";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(296, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 51;
			this.label2.Text = "人";
			// 
			// DataGrid1
			// 
			this.DataGrid1.AlternatingBackColor = System.Drawing.Color.LightGray;
			this.DataGrid1.BackColor = System.Drawing.Color.DarkGray;
			this.DataGrid1.BackgroundColor = System.Drawing.Color.LightGray;
			this.DataGrid1.CaptionBackColor = System.Drawing.Color.White;
			this.DataGrid1.CaptionFont = new System.Drawing.Font("Verdana", 10F);
			this.DataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
			this.DataGrid1.CaptionText = "          本辖区教师信息统计";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(40, 70);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 20;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(320, 250);
			this.DataGrid1.TabIndex = 54;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(216, 352);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 56;
			this.button2.Text = "退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(96, 352);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 55;
			this.button1.Text = "打印";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// StatisticsTeacher_QuXian
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(400, 397);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DataGrid1);
			this.Controls.Add(this.comboBox_QuXian);
			this.Controls.Add(this.label_SchoolCount);
			this.Controls.Add(this.label2);
			this.Name = "StatisticsTeacher_QuXian";
			this.Text = "各区县教师信息统计";
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
			string str_Sql,errorstring;
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
				excelSheet.Cells[1,1]=comboBox_QuXian.Text+" 共有教师 "+label_SchoolCount.Text+" 人";
				excelSheet.Cells[2,1]="学历";
				excelSheet.Cells[2,2]="区县代码";
				excelSheet.Cells[2,3]="区县";
				excelSheet.Cells[2,4]="人数";
				//设置表头格式
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,2]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,2]).Font.Bold = true;
							
				str_Sql="select * FROM View_QuXian_Teacher_Statistics WHERE 区县代码='"+comboBox_QuXian.SelectedValue.ToString()+"'";
				errorstring=conn.Fill(str_Sql);
				DataGrid1.SetDataBinding(conn.ds,"TableIn");

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

		private void comboBox_QuXian_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			/*string str_Sql="Select * from View_Teacher WHERE QuXian_Code='"+comboBox_QuXian.SelectedValue.ToString()+"'"; 
			string errorstring=conn.Fill(str_Sql);
			label_SchoolCount.Text=conn.ds.Tables[0].Rows.Count.ToString();*/
			string str_Sql="Select Count(*) AS CountHowmany from View_Teacher WHERE QuXian_Code='"+comboBox_QuXian.SelectedValue.ToString()+"'"; 
			string errorstring=conn.Fill(str_Sql);
			label_SchoolCount.Text=conn.ds.Tables[0].Rows[0]["CountHowmany"].ToString();


			str_Sql="select * FROM View_QuXian_Teacher_Statistics WHERE 区县代码='"+comboBox_QuXian.SelectedValue.ToString()+"'";
			errorstring=conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");		
		}
	}
}
