using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Library.UserInterface;
using Library.DataLevel;
namespace Library.UserInterface
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class BorrowReturn : System.Windows.Forms.Form
	{		
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private DataSet dataSet1=new DataSet();
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnBorrow;
		private System.Windows.Forms.Button btnReturn;
		private System.Windows.Forms.Label lblReaderID;
		private System.Windows.Forms.Label lblBookID;		
		private System.Windows.Forms.TextBox textReaderID;
		private System.Windows.Forms.TextBox textBookID;
		private Library.UserInterface.DataSetBorrowReturn objDataSetBorrowReturn;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private string userSort;
		private string userName;
		private System.ComponentModel.Container components = null;		
		DataBaseConnection dbc=new DataBaseConnection();
		private System.Data.SqlClient.SqlConnection conn;
		private System.Data.SqlClient.SqlDataAdapter da;
		private System.Data.SqlClient.SqlCommand delComm;
		private System.Data.SqlClient.SqlCommand insertComm;
		private System.Data.SqlClient.SqlCommand selectComm;
		private System.Data.SqlClient.SqlCommand updateComm;
		private System.Windows.Forms.DataGrid dg;
		private System.Windows.Forms.GroupBox groupBox1;
		
		public BorrowReturn(string username,string usersort)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			this.userName=username;			

			InitializeComponent();
			conn.ConnectionString=dbc.databaseConnection;
			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(BorrowReturn));
			this.dg = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.textReaderID = new System.Windows.Forms.TextBox();
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnBorrow = new System.Windows.Forms.Button();
			this.textBookID = new System.Windows.Forms.TextBox();
			this.btnReturn = new System.Windows.Forms.Button();
			this.conn = new System.Data.SqlClient.SqlConnection();
			this.da = new System.Data.SqlClient.SqlDataAdapter();
			this.delComm = new System.Data.SqlClient.SqlCommand();
			this.insertComm = new System.Data.SqlClient.SqlCommand();
			this.selectComm = new System.Data.SqlClient.SqlCommand();
			this.updateComm = new System.Data.SqlClient.SqlCommand();
			this.lblReaderID = new System.Windows.Forms.Label();
			this.lblBookID = new System.Windows.Forms.Label();
			this.objDataSetBorrowReturn = new Library.UserInterface.DataSetBorrowReturn();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objDataSetBorrowReturn)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dg
			// 
			this.dg.AlternatingBackColor = System.Drawing.Color.White;
			this.dg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dg.BackColor = System.Drawing.Color.White;
			this.dg.BackgroundColor = System.Drawing.Color.Gainsboro;
			this.dg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dg.CaptionBackColor = System.Drawing.Color.Silver;
			this.dg.CaptionFont = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
			this.dg.CaptionForeColor = System.Drawing.Color.Black;
			this.dg.DataMember = "";
			this.dg.Enabled = false;
			this.dg.FlatMode = true;
			this.dg.Font = new System.Drawing.Font("Courier New", 9F);
			this.dg.ForeColor = System.Drawing.Color.DarkSlateGray;
			this.dg.GridLineColor = System.Drawing.Color.DarkGray;
			this.dg.HeaderBackColor = System.Drawing.Color.DarkGreen;
			this.dg.HeaderFont = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
			this.dg.HeaderForeColor = System.Drawing.Color.White;
			this.dg.LinkColor = System.Drawing.Color.DarkGreen;
			this.dg.Location = new System.Drawing.Point(16, 104);
			this.dg.Name = "dg";
			this.dg.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dg.ParentRowsForeColor = System.Drawing.Color.Black;
			this.dg.ReadOnly = true;
			this.dg.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
			this.dg.SelectionForeColor = System.Drawing.Color.Black;
			this.dg.Size = new System.Drawing.Size(456, 224);
			this.dg.TabIndex = 0;
			this.dg.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																						   this.dataGridTableStyle1});
			this.dg.CurrentCellChanged += new System.EventHandler(this.dg_CurrentCellChanged);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dg;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "BorrowBook";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "读者";
			this.dataGridTextBoxColumn1.MappingName = "ReaderID";
			this.dataGridTextBoxColumn1.Width = 50;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "书号";
			this.dataGridTextBoxColumn2.MappingName = "BookID";
			this.dataGridTextBoxColumn2.Width = 50;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "借书日期";
			this.dataGridTextBoxColumn3.MappingName = "BorrowDate";
			this.dataGridTextBoxColumn3.Width = 75;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "应还书日期";
			this.dataGridTextBoxColumn4.MappingName = "ReturnDate";
			this.dataGridTextBoxColumn4.Width = 75;
			// 
			// textReaderID
			// 
			this.textReaderID.Location = new System.Drawing.Point(80, 16);
			this.textReaderID.Name = "textReaderID";
			this.textReaderID.Size = new System.Drawing.Size(96, 21);
			this.textReaderID.TabIndex = 2;
			this.textReaderID.Text = "";
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(8, 24);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(75, 24);
			this.btnLoad.TabIndex = 3;
			this.btnLoad.Text = "借阅记录";
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnBorrow
			// 
			this.btnBorrow.Location = new System.Drawing.Point(100, 24);
			this.btnBorrow.Name = "btnBorrow";
			this.btnBorrow.Size = new System.Drawing.Size(75, 24);
			this.btnBorrow.TabIndex = 4;
			this.btnBorrow.Text = "借阅图书";
			this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
			// 
			// textBookID
			// 
			this.textBookID.Location = new System.Drawing.Point(80, 56);
			this.textBookID.Name = "textBookID";
			this.textBookID.Size = new System.Drawing.Size(96, 21);
			this.textBookID.TabIndex = 5;
			this.textBookID.Text = "";
			// 
			// btnReturn
			// 
			this.btnReturn.Location = new System.Drawing.Point(189, 24);
			this.btnReturn.Name = "btnReturn";
			this.btnReturn.Size = new System.Drawing.Size(75, 24);
			this.btnReturn.TabIndex = 6;
			this.btnReturn.Text = "归还图书";
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			// 
			// conn
			// 
			this.conn.ConnectionString = "workstation id=MICHAEL;packet size=4096;integrated security=SSPI;data source=MICH" +
				"AEL;persist security info=False;initial catalog=BookManager";
			// 
			// da
			// 
			this.da.DeleteCommand = this.delComm;
			this.da.InsertCommand = this.insertComm;
			this.da.SelectCommand = this.selectComm;
			this.da.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																						 new System.Data.Common.DataTableMapping("Table", "BorrowBook", new System.Data.Common.DataColumnMapping[] {
																																																	   new System.Data.Common.DataColumnMapping("ReaderID", "ReaderID"),
																																																	   new System.Data.Common.DataColumnMapping("BookID", "BookID"),
																																																	   new System.Data.Common.DataColumnMapping("BorrowDate", "BorrowDate"),
																																																	   new System.Data.Common.DataColumnMapping("ReturnDate", "ReturnDate"),
																																																	   new System.Data.Common.DataColumnMapping("FactReturnDate", "FactReturnDate")})});
			this.da.UpdateCommand = this.updateComm;
			// 
			// delComm
			// 
			this.delComm.CommandText = @"DELETE FROM BorrowBook WHERE (BookID = @Original_BookID) AND (ReaderID = @Original_ReaderID) AND (BorrowDate = @Original_BorrowDate OR @Original_BorrowDate IS NULL AND BorrowDate IS NULL) AND (FactReturnDate = @Original_FactReturnDate OR @Original_FactReturnDate IS NULL AND FactReturnDate IS NULL) AND (ReturnDate = @Original_ReturnDate OR @Original_ReturnDate IS NULL AND ReturnDate IS NULL)";
			this.delComm.Connection = this.conn;
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookID", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookID", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReaderID", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReaderID", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BorrowDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BorrowDate", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FactReturnDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FactReturnDate", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReturnDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReturnDate", System.Data.DataRowVersion.Original, null));
			// 
			// insertComm
			// 
			this.insertComm.CommandText = @"INSERT INTO BorrowBook(ReaderID, BookID, BorrowDate, ReturnDate, FactReturnDate) VALUES (@ReaderID, @BookID, @BorrowDate, @ReturnDate, @FactReturnDate); SELECT ReaderID, BookID, BorrowDate, ReturnDate, FactReturnDate FROM BorrowBook WHERE (BookID = @BookID) AND (ReaderID = @ReaderID)";
			this.insertComm.Connection = this.conn;
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReaderID", System.Data.SqlDbType.VarChar, 6, "ReaderID"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookID", System.Data.SqlDbType.VarChar, 10, "BookID"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BorrowDate", System.Data.SqlDbType.DateTime, 8, "BorrowDate"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReturnDate", System.Data.SqlDbType.DateTime, 8, "ReturnDate"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FactReturnDate", System.Data.SqlDbType.DateTime, 8, "FactReturnDate"));
			// 
			// selectComm
			// 
			this.selectComm.CommandText = "SELECT ReaderID, BookID, BorrowDate, ReturnDate, FactReturnDate FROM BorrowBook";
			this.selectComm.Connection = this.conn;
			// 
			// updateComm
			// 
			this.updateComm.CommandText = @"UPDATE BorrowBook SET ReaderID = @ReaderID, BookID = @BookID, BorrowDate = @BorrowDate, ReturnDate = @ReturnDate, FactReturnDate = @FactReturnDate WHERE (BookID = @Original_BookID) AND (ReaderID = @Original_ReaderID) AND (BorrowDate = @Original_BorrowDate OR @Original_BorrowDate IS NULL AND BorrowDate IS NULL) AND (FactReturnDate = @Original_FactReturnDate OR @Original_FactReturnDate IS NULL AND FactReturnDate IS NULL) AND (ReturnDate = @Original_ReturnDate OR @Original_ReturnDate IS NULL AND ReturnDate IS NULL); SELECT ReaderID, BookID, BorrowDate, ReturnDate, FactReturnDate FROM BorrowBook WHERE (BookID = @BookID) AND (ReaderID = @ReaderID)";
			this.updateComm.Connection = this.conn;
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReaderID", System.Data.SqlDbType.VarChar, 6, "ReaderID"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookID", System.Data.SqlDbType.VarChar, 10, "BookID"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BorrowDate", System.Data.SqlDbType.DateTime, 8, "BorrowDate"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReturnDate", System.Data.SqlDbType.DateTime, 8, "ReturnDate"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FactReturnDate", System.Data.SqlDbType.DateTime, 8, "FactReturnDate"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookID", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookID", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReaderID", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReaderID", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BorrowDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BorrowDate", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FactReturnDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FactReturnDate", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReturnDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReturnDate", System.Data.DataRowVersion.Original, null));
			// 
			// lblReaderID
			// 
			this.lblReaderID.Location = new System.Drawing.Point(8, 24);
			this.lblReaderID.Name = "lblReaderID";
			this.lblReaderID.Size = new System.Drawing.Size(56, 16);
			this.lblReaderID.TabIndex = 8;
			this.lblReaderID.Text = "读者号码";
			// 
			// lblBookID
			// 
			this.lblBookID.Location = new System.Drawing.Point(8, 56);
			this.lblBookID.Name = "lblBookID";
			this.lblBookID.Size = new System.Drawing.Size(56, 16);
			this.lblBookID.TabIndex = 9;
			this.lblBookID.Text = "图书号码";
			// 
			// objDataSetBorrowReturn
			// 
			this.objDataSetBorrowReturn.DataSetName = "DataSetBorrowReturn";
			this.objDataSetBorrowReturn.Locale = new System.Globalization.CultureInfo("zh-CN");
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnLoad);
			this.groupBox1.Controls.Add(this.btnBorrow);
			this.groupBox1.Controls.Add(this.btnReturn);
			this.groupBox1.Location = new System.Drawing.Point(192, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(272, 56);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "借还书操作";
			// 
			// BorrowReturn
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.LightBlue;
			this.ClientSize = new System.Drawing.Size(488, 325);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lblBookID);
			this.Controls.Add(this.lblReaderID);
			this.Controls.Add(this.textBookID);
			this.Controls.Add(this.textReaderID);
			this.Controls.Add(this.dg);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BorrowReturn";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "借还书窗体";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objDataSetBorrowReturn)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		
		public void ErrorHandle(System.Exception E)
		{
			MessageBox.Show(E.ToString());
		}	

		private void btnBorrow_Click(object sender, System.EventArgs e)
		{			
			DataRow row=this.objDataSetBorrowReturn.Tables["BorrowBook"].NewRow();
			row["ReaderID"]=this.textReaderID.Text;
			row["BookID"]=this.textBookID.Text;
			row["BorrowDate"]=System.DateTime.Today;
			row["ReturnDate"]=DateTime.Today.AddMonths(1);
			this.objDataSetBorrowReturn.Tables["BorrowBook"].Rows.Add(row);
			if(BorrowBook(this.textBookID.Text)&&BorrowReader(this.textReaderID.Text))
			{
				this.UpdateDataSet();						
				dg.Refresh();
				MessageBox.Show(this.textReaderID.Text+"借阅图书"+this.textBookID.Text+"成功");
			}						
		}
		private bool BorrowBook(string BookID)
		{
			if(BorrowBookNumber(this.textBookID.Text)>0)
			{
				SqlCommand borrowbook=new SqlCommand();
				borrowbook.Connection=conn;
				borrowbook.CommandType=CommandType.StoredProcedure;
				borrowbook.CommandText="dbo.SP_BorrowBook";
				SqlParameter parinput=borrowbook.Parameters.Add("@BookID",SqlDbType.Char);
				parinput.Direction=ParameterDirection.Input;
				parinput.Value=BookID;
				try
				{
					conn.Open();			
					borrowbook.ExecuteNonQuery();
					conn.Close();
					return true;
				}
				catch(System.Exception e)
				{
					this.ErrorHandle(e);
					conn.Close();
					return false;
				}
			}
			else
				return false;
		}
		private int BorrowBookNumber(string BookID)
		{
			SqlCommand borrowbook=new SqlCommand();
			borrowbook.Connection=conn;
			borrowbook.CommandType=CommandType.StoredProcedure;
			borrowbook.CommandText="dbo.SP_BookNumber";
			SqlParameter parinput=borrowbook.Parameters.Add("@BookID",SqlDbType.Char);
			parinput.Direction=ParameterDirection.Input;
			parinput.Value=BookID;
			SqlParameter paroutput=borrowbook.Parameters.Add("@BookNumber",SqlDbType.Int);
			paroutput.Direction=ParameterDirection.Output;
			try
			{
				conn.Open();			
				borrowbook.ExecuteNonQuery();
				conn.Close();
				return Convert.ToInt16(paroutput.Value);
			}
			catch(System.Exception e)
			{
				this.ErrorHandle(e);				
				conn.Close();
				return 0;
			}
		}
		private int ReaderBorrowedNumber(string ReaderID)
		{
			SqlCommand borrowbook=new SqlCommand();
			borrowbook.Connection=conn;
			borrowbook.CommandType=CommandType.StoredProcedure;
			borrowbook.CommandText="dbo.SP_ReaderBorrowedNumber";
			SqlParameter parinput=borrowbook.Parameters.Add("@ReaderID",SqlDbType.Char);
			parinput.Direction=ParameterDirection.Input;
			parinput.Value=ReaderID;
			SqlParameter paroutput=borrowbook.Parameters.Add("@BorrowedNumber",SqlDbType.Int);
			paroutput.Direction=ParameterDirection.Output;
			try
			{
				conn.Open();			
				borrowbook.ExecuteNonQuery();
				conn.Close();
				return Convert.ToInt16(paroutput.Value);
			}
			catch(System.Exception e)
			{
				this.ErrorHandle(e);				
				conn.Close();
				return 8;
			}
		}

		private bool BorrowReader(string ReaderID)
		{
			if(ReaderBorrowedNumber(ReaderID)<8)
			{
				SqlCommand borrowbook=new SqlCommand();
				borrowbook.Connection=conn;
				borrowbook.CommandType=CommandType.StoredProcedure;
				borrowbook.CommandText="dbo.SP_BorrowReader";
				SqlParameter parinput=borrowbook.Parameters.Add("@ReaderID",SqlDbType.Char);
				parinput.Direction=ParameterDirection.Input;
				parinput.Value=ReaderID;
				try
				{
					conn.Open();			
					borrowbook.ExecuteNonQuery();
					conn.Close();
					return true;
				}
				catch(System.Exception e)
				{
					this.ErrorHandle(e);					
					conn.Close();
					return false;
				}
			}
			else
				return false;
		}
		private bool ReturnBook(string BookID)
		{
			SqlCommand returnbook=new SqlCommand();
			returnbook.Connection=conn;
			returnbook.CommandType=CommandType.StoredProcedure;
			returnbook.CommandText="dbo.SP_ReturnBook";
			SqlParameter parinput=returnbook.Parameters.Add("@BookID",SqlDbType.Char);
			parinput.Direction=ParameterDirection.Input;
			parinput.Value=BookID;
			try
			{
				conn.Open();			
				returnbook.ExecuteNonQuery();
				conn.Close();
				return true;
			}
			catch(System.Exception e)
			{
				this.ErrorHandle(e);				
				conn.Close();
				return false;

			}
		}
		private bool ReturnReader(string ReaderID)
		{
			SqlCommand returnbook=new SqlCommand();
			returnbook.Connection=conn;
			returnbook.CommandType=CommandType.StoredProcedure;
			returnbook.CommandText="dbo.SP_ReturnReader";
			SqlParameter parinput=returnbook.Parameters.Add("@ReaderID",SqlDbType.Char);
			parinput.Direction=ParameterDirection.Input;
			parinput.Value=ReaderID;
			try
			{
				conn.Open();			
				returnbook.ExecuteNonQuery();
				conn.Close();
				return true;
			}
			catch(System.Exception e)
			{
				this.ErrorHandle(e);				
				conn.Close();
				return false;
			}
		}


		
		private void dg_CurrentCellChanged(object sender, System.EventArgs e)
		{
			this.textBookID.Text=dg.CurrentCell.ToString();
			this.textBookID.Refresh();
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			
			DataRow[] rows=this.GetSpecialRecord(this.textReaderID.Text,this.textBookID.Text);
			
			foreach(DataRow drow in rows)
			{
				int dday=System.DateTime.Today.DayOfYear-((System.DateTime)drow["ReturnDate"]).DayOfYear;
				if(dday>0)
					if(MessageBox.Show(this.textReaderID.Text+"读者你的"+this.textBookID.Text+"图书已经过期"+Convert.ToString(dday)
						+"天,罚	款"+Convert.ToString(dday/10)+"元RMB","过期",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.Cancel)
					{
						return;
					}

				
				drow.Delete();
			}			

			if(ReturnReader(this.textReaderID.Text)&&ReturnBook(this.textBookID.Text))
			{
				UpdateDataSet();	
				dg.Refresh();
				MessageBox.Show(this.textReaderID.Text+"归还图书"+this.textBookID.Text+"成功");
			}			

			
		}
		
		public DataRow[] GetSpecialRecord(string ReaderID,string BookID)
		{					
			
			try
			{
				DataRow[] rows =this.objDataSetBorrowReturn.Tables["BorrowBook"].Select("ReaderID= '"+ ReaderID+"'"+"and BookID='"+BookID+"'");				
				return rows;
			}
			catch(Exception ex)
			{
				Console.WriteLine("GetSpecialExpert failed in ExpertAccess!"+ex.StackTrace.ToString());
				return null;
			}
		}

		private void btnLoad_Click(object sender, System.EventArgs e)
		{
			string source="select ReaderID,BookID,BorrowDate,ReturnDate from BorrowBook where ReaderID="+this.textReaderID.Text;			
			da.SelectCommand.CommandType=CommandType.Text;
			da.SelectCommand.CommandText=source;
			da.SelectCommand.Connection=conn;		
			this.objDataSetBorrowReturn.Clear();
			da.Fill(this.objDataSetBorrowReturn,"BorrowBook");
			dg.DataSource=this.objDataSetBorrowReturn;			
			dg.DataMember="BorrowBook";		
			dg.Refresh();
			MessageBox.Show("查询读者"+this.textReaderID.Text+"记录"+"成功");
		}
		public void UpdateDataSet()
		{			
			DataSetBorrowReturn objDataSetTemp=new DataSetBorrowReturn();
			objDataSetTemp=(DataSetBorrowReturn)(this.objDataSetBorrowReturn.GetChanges());
			try
			{
				this.UpdateDataSource(objDataSetTemp);
				this.objDataSetBorrowReturn.Merge(objDataSetTemp);
				this.objDataSetBorrowReturn.AcceptChanges();
			}
			catch(System.Exception E)
			{
				this.ErrorHandle(E);
			}
		}
		
		public void UpdateDataSource(DataSetBorrowReturn  Changerows)
		{
			try
			{
				conn.Open();
				da.Update(Changerows);
			}
			catch(System.Exception E)
			{
				this.ErrorHandle(E);
			}
			finally
			{
				conn.Close();

			}	
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			try
			{
				conn.Open();				
				da.Fill(this.objDataSetBorrowReturn,"BorrowBook");
			}
			catch(System.Exception ex)
			{
				this.ErrorHandle(ex);
				MessageBox.Show("数据集初始失败");
			}
			conn.Close();
		}
	}
}
