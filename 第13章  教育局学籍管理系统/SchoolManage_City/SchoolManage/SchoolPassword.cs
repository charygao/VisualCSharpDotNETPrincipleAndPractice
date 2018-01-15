using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace SchoolManage
{
	/// <summary>
	/// SchoolPassword 的摘要说明。
	/// </summary>
	public class SchoolPassword : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox_openFile;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected config conn=new config();
		public DataSet myDataSet;

		//创建应用程序,工作表,工作簿
		private bool useExcel;
		private Excel._Application excelApp;
		private Excel.Workbook excelBook;
		private Excel.Worksheet excelSheet;

		public SchoolPassword()
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
			this.label2 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox_openFile = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(128, 202);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(360, 48);
			this.label2.TabIndex = 11;
			this.label2.Text = "保证Excel文件第一列为学校编号,第二列为学校名称,则运行之后第三列为其上传密码。第一行为标题,不会参与运算.";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(312, 130);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(64, 23);
			this.button3.TabIndex = 10;
			this.button3.Text = "退出";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(160, 130);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 23);
			this.button2.TabIndex = 9;
			this.button2.Text = "添加密码列";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(536, 58);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(24, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "=";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox_openFile
			// 
			this.textBox_openFile.Location = new System.Drawing.Point(208, 58);
			this.textBox_openFile.Name = "textBox_openFile";
			this.textBox_openFile.Size = new System.Drawing.Size(320, 21);
			this.textBox_openFile.TabIndex = 7;
			this.textBox_openFile.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "选择已经编辑好的Excel文件";
			// 
			// SchoolPassword
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(616, 309);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox_openFile);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Name = "SchoolPassword";
			this.Text = "密码生成器";
			this.ResumeLayout(false);

		}
		#endregion
		
		//选择已经编辑好的Excel文件
		private void button1_Click(object sender, System.EventArgs e)
		{			
			string fileName;
			DialogResult result = openFileDialog1.ShowDialog();
			if( result == DialogResult.OK )
			{
				fileName = openFileDialog1.FileName;;
				textBox_openFile.Text=fileName;
			}
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			string str_School_ID,SchoolPassword;
			int i;

			useExcel=true;
			excelApp = new Excel.ApplicationClass();
			Excel.Workbook excelBook =excelApp.Workbooks.Add(1);
			Excel.Worksheet excelSheet=(Excel.Worksheet)excelBook.Worksheets[1];

			if (textBox_openFile.Text=="") 
			{
				MessageBox.Show("必须输入争取文件名！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			string Excelfileloc=textBox_openFile.Text;
			string Excelfilename=conn.GetLastStr(Excelfileloc,"\\");
			string Excelfiletype=conn.GetLastStr(Excelfilename,".").Trim();
			if(Excelfiletype!="xls")
			{
				MessageBox.Show("必须输入Excel文件！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			//创建一个数据链接
			string strCon = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source ="+Excelfileloc+";Extended Properties=Excel 8.0" ;
			OleDbConnection myConn = new OleDbConnection ( strCon ) ;
			string strCom = " SELECT * FROM [Sheet1$] " ;
			myConn.Open() ;
			//打开数据链接，得到一个数据集
			OleDbDataAdapter myCommand = new OleDbDataAdapter (strCom,myConn) ;
			//创建一个 DataSet对象
			myDataSet = new DataSet();
			//f得到自己的DataSet对象
			myCommand.Fill( myDataSet,"[Sheet1$]");
			//关闭此数据链接
			myConn.Close(); 

			//取出各行数据，第二列学校名,第一列School_ID—>算出来有效的密码,存入myDataSet
			for(i=0;i<myDataSet.Tables[0].Rows.Count;i++)
			{
				str_School_ID=myDataSet.Tables[0].Rows[i][0].ToString();
				SchoolPassword=conn.ValidUploadPassword(str_School_ID);
				myDataSet.Tables[0].Rows[i][2]=SchoolPassword;
			}
						
			//逐行填入
			for(i=0;i<myDataSet.Tables[0].Rows.Count;i++)
			{
				excelSheet.Cells[i,1]=myDataSet.Tables[0].Rows[i][0].ToString();
				excelSheet.Cells[i,2]=myDataSet.Tables[0].Rows[i][1].ToString();
				excelSheet.Cells[i,3]=myDataSet.Tables[0].Rows[i][2].ToString();
			}
			excelApp.Visible=true;
		}
	}
}
