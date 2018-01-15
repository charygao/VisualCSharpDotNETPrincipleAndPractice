using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace 例7_1
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private 例7_1.DataSet1 dataSet11;
		private System.Windows.Forms.DataGrid dataGrid1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			this.sqlDataAdapter1.Fill(this.dataSet11,"scores");
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.dataSet11 = new 例7_1.DataSet1();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.sqlInsertCommand = new System.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlDataAdapter1
            // 
            this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand;
            this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "scores", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("stu_id", "stu_id"),
                        new System.Data.Common.DataColumnMapping("stu_name", "stu_name"),
                        new System.Data.Common.DataColumnMapping("english_score", "english_score"),
                        new System.Data.Common.DataColumnMapping("math_score", "math_score"),
                        new System.Data.Common.DataColumnMapping("computer_score", "computer_score"),
                        new System.Data.Common.DataColumnMapping("physics_score", "physics_score")})});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=HK-PC\\SQLEXPRESS;Initial Catalog=stumanage;Integrated Security=True;P" +
                "ooling=False";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT stu_id, stu_name, english_score, math_score, computer_score, \r\n      physi" +
                "cs_score\r\nFROM scores";
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            // 
            // dataSet11
            // 
            this.dataSet11.DataSetName = "DataSet1";
            this.dataSet11.Locale = new System.Globalization.CultureInfo("zh-CN");
            this.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.DataSource = this.dataSet11.scores;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.dataGrid1.Location = new System.Drawing.Point(8, 48);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(432, 264);
            this.dataGrid1.TabIndex = 0;
            // 
            // sqlInsertCommand
            // 
            this.sqlInsertCommand.CommandText = "INSERT INTO [scores] ([stu_id], [stu_name], [english_score], [math_score], [compu" +
                "ter_score], [physics_score]) VALUES (@stu_id, @stu_name, @english_score, @math_s" +
                "core, @computer_score, @physics_score)";
            this.sqlInsertCommand.Connection = this.sqlConnection1;
            this.sqlInsertCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@stu_id", System.Data.SqlDbType.NChar, 0, "stu_id"),
            new System.Data.SqlClient.SqlParameter("@stu_name", System.Data.SqlDbType.NChar, 0, "stu_name"),
            new System.Data.SqlClient.SqlParameter("@english_score", System.Data.SqlDbType.Int, 0, "english_score"),
            new System.Data.SqlClient.SqlParameter("@math_score", System.Data.SqlDbType.Int, 0, "math_score"),
            new System.Data.SqlClient.SqlParameter("@computer_score", System.Data.SqlDbType.Int, 0, "computer_score"),
            new System.Data.SqlClient.SqlParameter("@physics_score", System.Data.SqlDbType.Int, 0, "physics_score")});
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(448, 326);
            this.Controls.Add(this.dataGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
