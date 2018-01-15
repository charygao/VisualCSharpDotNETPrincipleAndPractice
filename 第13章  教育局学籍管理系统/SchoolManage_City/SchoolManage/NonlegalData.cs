using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// NonlegalData 的摘要说明。
	/// </summary>
	public class NonlegalData : System.Windows.Forms.Form
	{
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

		public NonlegalData()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			string str_Sql="Select  School_ID AS 学校代码,School_Name AS 学校名称,Class_Type_Name AS 班级类别,Class_Name AS 班级名 FROM View_ClassSchool inner join Class_Type on View_ClassSchool.Class_Type_ID=Class_Type.Class_Type_ID WHERE (View_ClassSchool.School_Type_ID=0 AND(View_ClassSchool.Class_Type_ID>5 OR View_ClassSchool.Class_Type_ID<0)) OR (View_ClassSchool.School_Type_ID=1 AND(View_ClassSchool.Class_Type_ID<6 OR View_ClassSchool.Class_Type_ID>8)) OR (View_ClassSchool.School_Type_ID=2 AND(View_ClassSchool.Class_Type_ID<9 OR View_ClassSchool.Class_Type_ID>11)) OR (View_ClassSchool.School_Type_ID=3 AND(View_ClassSchool.Class_Type_ID<12 OR View_ClassSchool.Class_Type_ID>17)) OR (View_ClassSchool.School_Type_ID=4 AND(View_ClassSchool.Class_Type_ID<18 OR View_ClassSchool.Class_Type_ID>26)) OR (View_ClassSchool.School_Type_ID=5 AND(View_ClassSchool.Class_Type_ID<30 OR View_ClassSchool.Class_Type_ID>32)) OR (View_ClassSchool.School_Type_ID=6 AND(View_ClassSchool.Class_Type_ID<33 OR View_ClassSchool.Class_Type_ID>44))"; 
			string errorstring=conn.Fill(str_Sql);
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
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
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
			this.DataGrid1.CaptionText = "                现有不合理班级情况";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(40, 30);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 90;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 20;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(600, 300);
			this.DataGrid1.TabIndex = 45;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(360, 368);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 47;
			this.button2.Text = "退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(192, 368);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 46;
			this.button1.Text = "打印";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// NonlegalData
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(680, 413);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DataGrid1);
			this.Name = "NonlegalData";
			this.Text = "非法数据查询";
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

			string str_Sql="Select  School_ID AS 学校代码,School_Name AS 学校名称,Class_Type_Name AS 班级类别,Class_Name AS 班级名 FROM View_ClassSchool inner join Class_Type on View_ClassSchool.Class_Type_ID=Class_Type.Class_Type_ID WHERE (View_ClassSchool.School_Type_ID=0 AND(View_ClassSchool.Class_Type_ID>5 OR View_ClassSchool.Class_Type_ID<0)) OR (View_ClassSchool.School_Type_ID=1 AND(View_ClassSchool.Class_Type_ID<6 OR View_ClassSchool.Class_Type_ID>8)) OR (View_ClassSchool.School_Type_ID=2 AND(View_ClassSchool.Class_Type_ID<9 OR View_ClassSchool.Class_Type_ID>11)) OR (View_ClassSchool.School_Type_ID=3 AND(View_ClassSchool.Class_Type_ID<12 OR View_ClassSchool.Class_Type_ID>17)) OR (View_ClassSchool.School_Type_ID=4 AND(View_ClassSchool.Class_Type_ID<18 OR View_ClassSchool.Class_Type_ID>26)) OR (View_ClassSchool.School_Type_ID=5 AND(View_ClassSchool.Class_Type_ID<30 OR View_ClassSchool.Class_Type_ID>32)) OR (View_ClassSchool.School_Type_ID=6 AND(View_ClassSchool.Class_Type_ID<33 OR View_ClassSchool.Class_Type_ID>44))"; 
			
			try
			{
				//设置表头
				excelSheet.Cells[1,1]="学校代码";
				excelSheet.Cells[1,2]="学校名称";
				excelSheet.Cells[1,3]="班级类别";
				excelSheet.Cells[1,4]="班级名";
			
				//设置报表头格式
				excelSheet.get_Range(excelSheet.Cells[1,1],excelSheet.Cells[1,4]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
				excelSheet.get_Range(excelSheet.Cells[1,1],excelSheet.Cells[1,4]).Font.Bold = true;
			
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
