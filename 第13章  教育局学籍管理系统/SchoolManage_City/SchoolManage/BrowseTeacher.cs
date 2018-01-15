using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// BrowseTeacher 的摘要说明。
	/// </summary>
	public class BrowseTeacher : System.Windows.Forms.Form
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
		private System.Windows.Forms.Label label_School_ID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox_School;
		private System.Windows.Forms.ComboBox comboBox_School_Type;
		private System.Windows.Forms.Label label_;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox_QuXian;
		private Excel.Worksheet excelSheet;

		public BrowseTeacher()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			conn.BindComboBox("SELECT QuXian_Code,QuXian_Name FROM QuXian",comboBox_QuXian,"QuXian_Code","QuXian_Name");
			conn.BindComboBox("SELECT School_Type_ID,School_Type_Name FROM School_Type",comboBox_School_Type,"School_Type_ID","School_Type_Name");
			
			//绑定DataGrid显示
			string str_Sql,errorstring;
			str_Sql="SELECT View_Class.Class_ID AS 班级代码,View_Class.Class_Type_Name AS 班级类别,View_Class.Class_Name AS 班级名,View_Class.TeacherInCharge AS 班主任 FROM View_Class";
			errorstring=conn.Fill(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("请检查数据库！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			str_Sql="Select * from School"; 
			if(conn.GetRowCount(str_Sql)==0)
			{
				MessageBox.Show("请先输入学校信息！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;				
				return;
			}

			conn.BindComboBox("Select * FROM School WHERE School_Type_ID="+comboBox_School_Type.SelectedValue+" AND School_ID Like '____"+comboBox_QuXian.SelectedValue+"%' Order By School_Type_ID,School_ID",comboBox_School,"School_ID","School_Name");	
			
			str_Sql="SELECT Teacher_ID As 身份证号码,Name As 姓名,Sex AS 性别,convert(char(10),Birthday,120) As 出生日期,convert(char(10),WorkTime,120) As 参加工作时间,SchoolType AS 学历,PostCan AS 职称,PostIn AS 职务,SchoolGrad AS 毕业院校,convert(char(10),GradTime,120)  毕业日期,SpecialIn AS 所学专业,InWorkSheet As 在编,IsFullTime AS 专任教师,LessonTeach AS 担任课程 FROM Teacher WHERE School_ID='000'";
			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");

			DataGridTableStyle MyStyle =new DataGridTableStyle();
			MyStyle.MappingName = "TableIn";
			DataGrid1.TableStyles.Add(MyStyle);
			MyStyle.GridColumnStyles["身份证号码"].Width=120;
			MyStyle.GridColumnStyles["性别"].Width=30;
			MyStyle.GridColumnStyles["在编"].Width=30;
			MyStyle.GridColumnStyles["专任教师"].Width=60;
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
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label_School_ID = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox_School = new System.Windows.Forms.ComboBox();
			this.comboBox_School_Type = new System.Windows.Forms.ComboBox();
			this.label_ = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox_QuXian = new System.Windows.Forms.ComboBox();
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
			this.DataGrid1.CaptionText = "                                       该校现有教师";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.FlatMode = true;
			this.DataGrid1.ForeColor = System.Drawing.Color.Black;
			this.DataGrid1.GridLineColor = System.Drawing.Color.Black;
			this.DataGrid1.HeaderBackColor = System.Drawing.Color.Silver;
			this.DataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DataGrid1.LinkColor = System.Drawing.Color.Navy;
			this.DataGrid1.Location = new System.Drawing.Point(30, 130);
			this.DataGrid1.Name = "DataGrid1";
			this.DataGrid1.ParentRowsBackColor = System.Drawing.Color.White;
			this.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
			this.DataGrid1.PreferredColumnWidth = 40;
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.RowHeaderWidth = 10;
			this.DataGrid1.SelectionBackColor = System.Drawing.Color.Navy;
			this.DataGrid1.SelectionForeColor = System.Drawing.Color.White;
			this.DataGrid1.Size = new System.Drawing.Size(600, 400);
			this.DataGrid1.TabIndex = 84;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(384, 560);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 87;
			this.button2.Text = "退出";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(216, 560);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 86;
			this.button1.Text = "打印";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label_School_ID
			// 
			this.label_School_ID.Location = new System.Drawing.Point(552, 560);
			this.label_School_ID.Name = "label_School_ID";
			this.label_School_ID.TabIndex = 88;
			this.label_School_ID.Text = "label1";
			this.label_School_ID.Visible = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(64, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 90;
			this.label1.Text = "学校";
			// 
			// comboBox_School
			// 
			this.comboBox_School.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_School.Location = new System.Drawing.Point(112, 80);
			this.comboBox_School.Name = "comboBox_School";
			this.comboBox_School.Size = new System.Drawing.Size(240, 20);
			this.comboBox_School.TabIndex = 89;
			this.comboBox_School.SelectionChangeCommitted += new System.EventHandler(this.comboBox_School_SelectionChangeCommitted);
			// 
			// comboBox_School_Type
			// 
			this.comboBox_School_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_School_Type.Items.AddRange(new object[] {
																	  "男",
																	  "女"});
			this.comboBox_School_Type.Location = new System.Drawing.Point(440, 32);
			this.comboBox_School_Type.Name = "comboBox_School_Type";
			this.comboBox_School_Type.Size = new System.Drawing.Size(96, 20);
			this.comboBox_School_Type.TabIndex = 94;
			this.comboBox_School_Type.SelectionChangeCommitted += new System.EventHandler(this.comboBox_School_Type_SelectionChangeCommitted);
			// 
			// label_
			// 
			this.label_.Location = new System.Drawing.Point(360, 40);
			this.label_.Name = "label_";
			this.label_.Size = new System.Drawing.Size(56, 16);
			this.label_.TabIndex = 93;
			this.label_.Text = "学校类别";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(64, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 92;
			this.label2.Text = "区县";
			// 
			// comboBox_QuXian
			// 
			this.comboBox_QuXian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_QuXian.Location = new System.Drawing.Point(112, 32);
			this.comboBox_QuXian.Name = "comboBox_QuXian";
			this.comboBox_QuXian.Size = new System.Drawing.Size(240, 20);
			this.comboBox_QuXian.TabIndex = 91;
			this.comboBox_QuXian.SelectionChangeCommitted += new System.EventHandler(this.comboBox_QuXian_SelectionChangeCommitted);
			// 
			// BrowseTeacher
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(672, 605);
			this.Controls.Add(this.comboBox_School_Type);
			this.Controls.Add(this.label_);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBox_QuXian);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox_School);
			this.Controls.Add(this.label_School_ID);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DataGrid1);
			this.Name = "BrowseTeacher";
			this.Text = "浏览教师信息";
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
			useExcel=true;
			excelApp = new Excel.ApplicationClass();
			//Excel.Workbook 
			excelBook =excelApp.Workbooks.Add(1);
			//Excel.Worksheet 
			excelSheet=(Excel.Worksheet)excelBook.Worksheets[1];
			
			if(conn.ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show("无可打印内容！", "提醒！",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			try
			{
				//创建应用程序,工作表,工作簿		
				int i,j=0;
				
				excelApp.Visible=true;

				//设置表头
				excelSheet.Cells[1,1]=conn.School_IDtoWhat(comboBox_School.SelectedValue.ToString(),"School_Name");
				excelSheet.Cells[2,1]="身份证号码";
				excelSheet.Cells[2,2]="姓名";
				excelSheet.Cells[2,3]="性别";
				excelSheet.Cells[2,4]="出生日期";
				excelSheet.Cells[2,5]="参加工作时间";
				excelSheet.Cells[2,6]="学历";
				excelSheet.Cells[2,7]="职称";
				excelSheet.Cells[2,8]="职务";
				excelSheet.Cells[2,9]="毕业院校";
				excelSheet.Cells[2,10]="毕业日期";
				excelSheet.Cells[2,11]="所学专业";
				excelSheet.Cells[2,12]="是否在编";
				excelSheet.Cells[2,13]="是否专任教师";
				excelSheet.Cells[2,14]="担任课程";
			
				//设置表头格式
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,14]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
				excelSheet.get_Range(excelSheet.Cells[2,1],excelSheet.Cells[2,14]).Font.Bold = true;
							
				string str_Sql="SELECT Teacher_ID As 身份证号码,Name As 姓名,Sex AS 性别,convert(char(10),Birthday,120) As 出生日期,convert(char(10),WorkTime,120) As 参加工作时间,SchoolType AS 学历,PostCan AS 职称,PostIn AS 职务,SchoolGrad AS 毕业院校,convert(char(10),GradTime,120)  毕业日期,SpecialIn AS 所学专业,InWorkSheet As 在编,IsFullTime AS 专任教师,LessonTeach AS 担任课程 FROM Teacher WHERE School_ID='"+comboBox_School.SelectedValue.ToString()+"'";
				string errorstring=conn.Fill(str_Sql);
				if(errorstring!="OK")
				{
					MessageBox.Show("请检查数据库！"+errorstring, "提醒！", 
						MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					button1.Enabled=false;
					return;
				}

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
			}
			catch
			{
				throw new Exception("Excel error");
			}

		}

		private void comboBox_School_SelectionChangeCommitted(object sender, System.EventArgs e)
		{			
			string str_Sql,errorstring;
			str_Sql="SELECT Teacher_ID As 身份证号码,Name As 姓名,Sex AS 性别,convert(char(10),Birthday,120) As 出生日期,convert(char(10),WorkTime,120) As 参加工作时间,SchoolType AS 学历,PostCan AS 职称,PostIn AS 职务,SchoolGrad AS 毕业院校,convert(char(10),GradTime,120)  毕业日期,SpecialIn AS 所学专业,InWorkSheet As 在编,IsFullTime AS 专任教师,LessonTeach AS 担任课程 FROM Teacher WHERE School_ID='"+comboBox_School.SelectedValue.ToString()+"'";
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

		private void comboBox_QuXian_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			//绑定DataGrid显示
			string str_Sql,errorstring;
			conn.BindComboBox("Select * FROM School WHERE School_Type_ID="+comboBox_School_Type.SelectedValue+" AND School_ID Like '____"+comboBox_QuXian.SelectedValue+"%' Order By School_Type_ID,School_ID",comboBox_School,"School_ID","School_Name");	
			
			if(comboBox_School.Items.Count!=0)
			{
				str_Sql="SELECT Teacher_ID As 身份证号码,Name As 姓名,Sex AS 性别,convert(char(10),Birthday,120) As 出生日期,convert(char(10),WorkTime,120) As 参加工作时间,SchoolType AS 学历,PostCan AS 职称,PostIn AS 职务,SchoolGrad AS 毕业院校,convert(char(10),GradTime,120)  毕业日期,SpecialIn AS 所学专业,InWorkSheet As 在编,IsFullTime AS 专任教师,LessonTeach AS 担任课程 FROM Teacher WHERE School_ID='"+comboBox_School.SelectedValue.ToString()+"'";
				errorstring=conn.Fill(str_Sql);
				DataGrid1.SetDataBinding(conn.ds,"TableIn");
			}
		}

		private void comboBox_School_Type_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			//绑定DataGrid显示
			string str_Sql,errorstring;
			conn.BindComboBox("Select * FROM School WHERE School_Type_ID="+comboBox_School_Type.SelectedValue+" AND School_ID Like '____"+comboBox_QuXian.SelectedValue+"%' Order By School_Type_ID,School_ID",comboBox_School,"School_ID","School_Name");	
			
			if(comboBox_School.Items.Count!=0)
			{
				str_Sql="SELECT Teacher_ID As 身份证号码,Name As 姓名,Sex AS 性别,convert(char(10),Birthday,120) As 出生日期,convert(char(10),WorkTime,120) As 参加工作时间,SchoolType AS 学历,PostCan AS 职称,PostIn AS 职务,SchoolGrad AS 毕业院校,convert(char(10),GradTime,120)  毕业日期,SpecialIn AS 所学专业,InWorkSheet As 在编,IsFullTime AS 专任教师,LessonTeach AS 担任课程 FROM Teacher WHERE School_ID='"+comboBox_School.SelectedValue.ToString()+"'";
				errorstring=conn.Fill(str_Sql);
				DataGrid1.SetDataBinding(conn.ds,"TableIn");
			}
		}
	}
}
