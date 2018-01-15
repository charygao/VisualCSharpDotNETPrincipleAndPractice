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
	/// Reader 的摘要说明。
	/// </summary>
	public class Reader : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textPassword;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.TextBox textBorrowBooks;
		private System.Windows.Forms.TextBox textEmail;
		private System.Windows.Forms.TextBox textTelNo;
		private System.Windows.Forms.TextBox textName;
		private System.Windows.Forms.TextBox textId;
		private Library.UserInterface.DataSetReader objDataSetReader;
		private string sqlQuery="";
	
		private string userSort;
		private string userName;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Data.SqlClient.SqlConnection conn;
		private System.Data.SqlClient.SqlDataAdapter da;
		private System.Data.SqlClient.SqlCommand delComm;
		private System.Data.SqlClient.SqlCommand insertComm;
		private System.Data.SqlClient.SqlCommand selectComm;
		private System.Data.SqlClient.SqlCommand updateComm;
		DataBaseConnection dbc=new DataBaseConnection();
		public Reader(string username,string usersort,string Query)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			this.userName=username;
			this.userSort=usersort;
			sqlQuery="select * from Reader where ReaderID='"+Query+"'";
			InitializeComponent();
			conn.ConnectionString=dbc.databaseConnection;
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		public Reader(string username,string usersort)
		{
			this.userName=username;
			this.userSort=usersort;
			InitializeComponent();
			conn.ConnectionString=dbc.databaseConnection;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Reader));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textPassword = new System.Windows.Forms.TextBox();
			this.objDataSetReader = new Library.UserInterface.DataSetReader();
			this.label7 = new System.Windows.Forms.Label();
			this.textEmail = new System.Windows.Forms.TextBox();
			this.textName = new System.Windows.Forms.TextBox();
			this.textId = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textTelNo = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBorrowBooks = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.conn = new System.Data.SqlClient.SqlConnection();
			this.da = new System.Data.SqlClient.SqlDataAdapter();
			this.delComm = new System.Data.SqlClient.SqlCommand();
			this.insertComm = new System.Data.SqlClient.SqlCommand();
			this.selectComm = new System.Data.SqlClient.SqlCommand();
			this.updateComm = new System.Data.SqlClient.SqlCommand();
			this.btnExit = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.objDataSetReader)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textPassword);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.textEmail);
			this.groupBox1.Controls.Add(this.textName);
			this.groupBox1.Controls.Add(this.textId);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textTelNo);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.textBorrowBooks);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox1.Location = new System.Drawing.Point(8, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(408, 160);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "读者基本信息维护";
			// 
			// textPassword
			// 
			this.textPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetReader, "Reader.ReaderPassword"));
			this.textPassword.Location = new System.Drawing.Point(88, 112);
			this.textPassword.Name = "textPassword";
			this.textPassword.TabIndex = 13;
			this.textPassword.Text = "";
			// 
			// objDataSetReader
			// 
			this.objDataSetReader.DataSetName = "DataSetReader";
			this.objDataSetReader.Locale = new System.Globalization.CultureInfo("zh-CN");
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 120);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 23);
			this.label7.TabIndex = 12;
			this.label7.Text = "读者密码";
			// 
			// textEmail
			// 
			this.textEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetReader, "Reader.ReaderEmail"));
			this.textEmail.Location = new System.Drawing.Point(288, 48);
			this.textEmail.Name = "textEmail";
			this.textEmail.TabIndex = 10;
			this.textEmail.Text = "";
			// 
			// textName
			// 
			this.textName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetReader, "Reader.ReaderName"));
			this.textName.Location = new System.Drawing.Point(88, 80);
			this.textName.Name = "textName";
			this.textName.TabIndex = 8;
			this.textName.Text = "";
			// 
			// textId
			// 
			this.textId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetReader, "Reader.ReaderID"));
			this.textId.Location = new System.Drawing.Point(88, 48);
			this.textId.Name = "textId";
			this.textId.TabIndex = 7;
			this.textId.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(216, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "电子邮件";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "读者姓名";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "借书证号";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(216, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "联系电话";
			// 
			// textTelNo
			// 
			this.textTelNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetReader, "Reader.ReaderPhoneNo"));
			this.textTelNo.Location = new System.Drawing.Point(288, 80);
			this.textTelNo.Name = "textTelNo";
			this.textTelNo.TabIndex = 9;
			this.textTelNo.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(216, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "借书数目";
			// 
			// textBorrowBooks
			// 
			this.textBorrowBooks.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetReader, "Reader.ReaderBorrowedbooks"));
			this.textBorrowBooks.Location = new System.Drawing.Point(288, 112);
			this.textBorrowBooks.Name = "textBorrowBooks";
			this.textBorrowBooks.TabIndex = 11;
			this.textBorrowBooks.Text = "";
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(144, 40);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(56, 24);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "取消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnApply
			// 
			this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnApply.Location = new System.Drawing.Point(40, 40);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(56, 24);
			this.btnApply.TabIndex = 12;
			this.btnApply.Text = "确定";
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// conn
			// 
			this.conn.ConnectionString = "workstation id=YXY1681;packet size=4096;integrated security=SSPI;data source=yxy1" +
				"681;persist security info=False;initial catalog=BookManager";
			// 
			// da
			// 
			this.da.DeleteCommand = this.delComm;
			this.da.InsertCommand = this.insertComm;
			this.da.SelectCommand = this.selectComm;
			this.da.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																						 new System.Data.Common.DataTableMapping("Table", "Reader", new System.Data.Common.DataColumnMapping[] {
																																																   new System.Data.Common.DataColumnMapping("ReaderID", "ReaderID"),
																																																   new System.Data.Common.DataColumnMapping("ReaderName", "ReaderName"),
																																																   new System.Data.Common.DataColumnMapping("ReaderPassword", "ReaderPassword"),
																																																   new System.Data.Common.DataColumnMapping("ReaderPhoneNo", "ReaderPhoneNo"),
																																																   new System.Data.Common.DataColumnMapping("ReaderEmail", "ReaderEmail"),
																																																   new System.Data.Common.DataColumnMapping("ReaderBorrowedbooks", "ReaderBorrowedbooks")})});
			this.da.UpdateCommand = this.updateComm;
			// 
			// delComm
			// 
			this.delComm.CommandText = @"DELETE FROM Reader WHERE (ReaderID = @Original_ReaderID) AND (ReaderBorrowedbooks = @Original_ReaderBorrowedbooks OR @Original_ReaderBorrowedbooks IS NULL AND ReaderBorrowedbooks IS NULL) AND (ReaderEmail = @Original_ReaderEmail OR @Original_ReaderEmail IS NULL AND ReaderEmail IS NULL) AND (ReaderName = @Original_ReaderName OR @Original_ReaderName IS NULL AND ReaderName IS NULL) AND (ReaderPassword = @Original_ReaderPassword OR @Original_ReaderPassword IS NULL AND ReaderPassword IS NULL) AND (ReaderPhoneNo = @Original_ReaderPhoneNo OR @Original_ReaderPhoneNo IS NULL AND ReaderPhoneNo IS NULL)";
			this.delComm.Connection = this.conn;
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReaderID", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReaderID", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReaderBorrowedbooks", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReaderBorrowedbooks", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReaderEmail", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReaderEmail", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReaderName", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReaderName", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReaderPassword", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReaderPassword", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReaderPhoneNo", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReaderPhoneNo", System.Data.DataRowVersion.Original, null));
			// 
			// insertComm
			// 
			this.insertComm.CommandText = @"INSERT INTO Reader(ReaderID, ReaderName, ReaderPassword, ReaderPhoneNo, ReaderEmail, ReaderBorrowedbooks) VALUES (@ReaderID, @ReaderName, @ReaderPassword, @ReaderPhoneNo, @ReaderEmail, @ReaderBorrowedbooks); SELECT ReaderID, ReaderName, ReaderPassword, ReaderPhoneNo, ReaderEmail, ReaderBorrowedbooks FROM Reader WHERE (ReaderID = @ReaderID)";
			this.insertComm.Connection = this.conn;
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReaderID", System.Data.SqlDbType.VarChar, 6, "ReaderID"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReaderName", System.Data.SqlDbType.VarChar, 20, "ReaderName"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReaderPassword", System.Data.SqlDbType.VarChar, 10, "ReaderPassword"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReaderPhoneNo", System.Data.SqlDbType.VarChar, 15, "ReaderPhoneNo"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReaderEmail", System.Data.SqlDbType.VarChar, 50, "ReaderEmail"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReaderBorrowedbooks", System.Data.SqlDbType.Int, 4, "ReaderBorrowedbooks"));
			// 
			// selectComm
			// 
			this.selectComm.CommandText = "SELECT ReaderID, ReaderName, ReaderPassword, ReaderPhoneNo, ReaderEmail, ReaderBo" +
				"rrowedbooks FROM Reader";
			this.selectComm.Connection = this.conn;
			// 
			// updateComm
			// 
			this.updateComm.CommandText = @"UPDATE Reader SET ReaderID = @ReaderID, ReaderName = @ReaderName, ReaderPassword = @ReaderPassword, ReaderPhoneNo = @ReaderPhoneNo, ReaderEmail = @ReaderEmail, ReaderBorrowedbooks = @ReaderBorrowedbooks WHERE (ReaderID = @Original_ReaderID) AND (ReaderBorrowedbooks = @Original_ReaderBorrowedbooks OR @Original_ReaderBorrowedbooks IS NULL AND ReaderBorrowedbooks IS NULL) AND (ReaderEmail = @Original_ReaderEmail OR @Original_ReaderEmail IS NULL AND ReaderEmail IS NULL) AND (ReaderName = @Original_ReaderName OR @Original_ReaderName IS NULL AND ReaderName IS NULL) AND (ReaderPassword = @Original_ReaderPassword OR @Original_ReaderPassword IS NULL AND ReaderPassword IS NULL) AND (ReaderPhoneNo = @Original_ReaderPhoneNo OR @Original_ReaderPhoneNo IS NULL AND ReaderPhoneNo IS NULL); SELECT ReaderID, ReaderName, ReaderPassword, ReaderPhoneNo, ReaderEmail, ReaderBorrowedbooks FROM Reader WHERE (ReaderID = @ReaderID)";
			this.updateComm.Connection = this.conn;
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReaderID", System.Data.SqlDbType.VarChar, 6, "ReaderID"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReaderName", System.Data.SqlDbType.VarChar, 20, "ReaderName"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReaderPassword", System.Data.SqlDbType.VarChar, 10, "ReaderPassword"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReaderPhoneNo", System.Data.SqlDbType.VarChar, 15, "ReaderPhoneNo"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReaderEmail", System.Data.SqlDbType.VarChar, 50, "ReaderEmail"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReaderBorrowedbooks", System.Data.SqlDbType.Int, 4, "ReaderBorrowedbooks"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReaderID", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReaderID", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReaderBorrowedbooks", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReaderBorrowedbooks", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReaderEmail", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReaderEmail", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReaderName", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReaderName", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReaderPassword", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReaderPassword", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReaderPhoneNo", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReaderPhoneNo", System.Data.DataRowVersion.Original, null));
			// 
			// btnExit
			// 
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Location = new System.Drawing.Point(288, 216);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(72, 32);
			this.btnExit.TabIndex = 14;
			this.btnExit.Text = "退出";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnCancel);
			this.groupBox3.Controls.Add(this.btnApply);
			this.groupBox3.Location = new System.Drawing.Point(8, 184);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(232, 96);
			this.groupBox3.TabIndex = 19;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "编辑记录";
			// 
			// Reader
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.LightBlue;
			this.ClientSize = new System.Drawing.Size(442, 293);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.groupBox3);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Reader";
			this.Text = "读者信息维护";
			this.Load += new System.EventHandler(this.Reader_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.objDataSetReader)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion		
	
		public void ErrorHandle(System.Exception E)
		{
			MessageBox.Show(E.ToString());
		}		

		
		
		

		private void TextEnableControl(bool valid)
		{
			if(valid)
			{
				this.textId.Enabled=false;
				this.textName.Enabled=true;
				this.textBorrowBooks.Enabled=true;
				this.textEmail.Enabled=true;				
				this.textTelNo.Enabled=true;
				this.textPassword.Enabled=true;
				//this.chkValid.Enabled=true;
				
			}
			else
			{
				this.textId.Enabled=false;
				this.textName.Enabled=false;
				this.textBorrowBooks.Enabled=false;
				//this.textEmail.Enabled=false;				
				//this.textTelNo.Enabled=false;
				//this.textPassword.Enabled=false;
				//this.chkValid.Enabled=false;
			}
		}

		private void ButtonEnableControl(bool valid)
		{
			if(valid)
			{
				this.btnCancel.Enabled=true;
				this.btnApply.Enabled=true;
			}
			else
			{
				this.btnCancel.Enabled=false;
				this.btnApply.Enabled=false;
			}
		}
						
		private void LoadDataSet(string sqlQuery)
		{
			DataSetReader objDataSetTemp=new DataSetReader();
			try
			{
				this.FillDataSet(objDataSetTemp,sqlQuery);
			}
			catch (System.Exception E) 
			{
				// 在此处添加错误处理代码。
				this.ErrorHandle(E);
			}
			try
			{
				this.objDataSetReader.Clear();//清空当前数据集
				this.objDataSetReader.Merge(objDataSetTemp);//合并数据集
			}
			catch(System.Exception E) 
			{
				// 在此处添加错误处理代码。
				this.ErrorHandle(E);
			}
		}
		
		private void FillDataSet(DataSetReader dataset,string sqlQuery)
		{
			dataset.EnforceConstraints=false;
			try
			{
				da.SelectCommand.CommandText=sqlQuery;
				conn.Open();
				da.Fill(dataset);
			}
			catch(System.Exception E)
			{
				this.ErrorHandle(E);
			}
		
			finally
			{
				dataset.EnforceConstraints=true;
				conn.Close();
			}
		}

		private void Reader_Load(object sender, System.EventArgs e)
		{
		
			if(this.userSort!="reader")//如果当前用户类型不是"读者"
			{
				if(this.sqlQuery!="")
				{
					this.LoadDataSet(sqlQuery);
					this.TextEnableControl(true);
					this.ButtonEnableControl(true);
				}
				else//如果查询条件为空
				{
					addReader();
				}
			}
			else//如果当前用户类型不是"读者"
			{
				this.LoadDataSet(sqlQuery);
				this.TextEnableControl(false);
				//this.ButtonEnableControl(false);
			}
		}
		
		private void addReader()
		{
			try
			{
				this.BindingContext[this.objDataSetReader,"Reader"].AddNew();
			}
			catch(System.Exception E)
			{
				this.ErrorHandle(E);
			}
			
			this.TextEnableControl(true);
			this.ButtonEnableControl(true);
		
		
		}

		public void UpdateDataSet()
		{
			this.BindingContext[this.objDataSetReader,"Reader"].EndCurrentEdit();
			DataSetReader objDataSetTemp=new DataSetReader();
			objDataSetTemp=(DataSetReader)(this.objDataSetReader.GetChanges());
			try
			{
				this.UpdateDataSource(objDataSetTemp);
				this.objDataSetReader.Merge(objDataSetTemp);
				this.objDataSetReader.AcceptChanges();
			}
			catch(System.Exception E)
			{
				this.ErrorHandle(E);
			}
		}
		

		public void UpdateDataSource(DataSetReader Changerows)
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

		private void btnApply_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.UpdateDataSet();
			}
			catch(System.Exception E)
			{
				this.ErrorHandle(E);
			}			
			this.TextEnableControl(false);
			this.ButtonEnableControl(false);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.BindingContext[this.objDataSetReader,"Reader"].CancelCurrentEdit();
			}
			catch(System.Exception E)
			{
				this.ErrorHandle(E);
			}			
			this.TextEnableControl(false);
			this.TextEnableControl(false);
			this.ButtonEnableControl(false);
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

							
    }
}
