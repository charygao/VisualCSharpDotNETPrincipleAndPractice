using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Library.UserInterface;
using Library.DataLevel;

namespace Library
{
	/// <summary>
	/// User 的摘要说明。
	/// </summary>
	public class User : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textSort;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textId;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.TextBox textPassword;
		private string sqlQuery="";
		private string userSort;
		private string userName;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtDepart;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Data.SqlClient.SqlDataAdapter da;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.SqlClient.SqlConnection conn;
		private Library.UserInterface.DataSetUser objDataSetUser;
		DataBaseConnection dbc=new DataBaseConnection();
		public User(string Query ,string username,string usersort)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			sqlQuery="select * from dbo.[User] where UserID='"+Query+"'";
			InitializeComponent();
			this.userName=username;			
			this.userSort=usersort;
			conn.ConnectionString=dbc.databaseConnection;
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		public User(string username,string usersort)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(User));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textPassword = new System.Windows.Forms.TextBox();
			this.objDataSetUser = new Library.UserInterface.DataSetUser();
			this.textSort = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textId = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtDepart = new System.Windows.Forms.TextBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.da = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.conn = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.objDataSetUser)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textPassword);
			this.groupBox1.Controls.Add(this.textSort);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.textId);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtName);
			this.groupBox1.Controls.Add(this.txtDepart);
			this.groupBox1.Controls.Add(this.txtPhone);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox1.Location = new System.Drawing.Point(8, 32);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(408, 176);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "用户信息维护";
			// 
			// textPassword
			// 
			this.textPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetUser, "User.UserPassword"));
			this.textPassword.Location = new System.Drawing.Point(104, 88);
			this.textPassword.Name = "textPassword";
			this.textPassword.Size = new System.Drawing.Size(96, 23);
			this.textPassword.TabIndex = 14;
			this.textPassword.Text = "";
			// 
			// objDataSetUser
			// 
			this.objDataSetUser.DataSetName = "DataSetUser";
			this.objDataSetUser.Locale = new System.Globalization.CultureInfo("zh-CN");
			// 
			// textSort
			// 
			this.textSort.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetUser, "User.UserSort"));
			this.textSort.Location = new System.Drawing.Point(104, 120);
			this.textSort.Name = "textSort";
			this.textSort.Size = new System.Drawing.Size(96, 23);
			this.textSort.TabIndex = 13;
			this.textSort.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 128);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 23);
			this.label7.TabIndex = 12;
			this.label7.Text = "用户类别";
			// 
			// textId
			// 
			this.textId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetUser, "User.UserID"));
			this.textId.Location = new System.Drawing.Point(104, 56);
			this.textId.Name = "textId";
			this.textId.Size = new System.Drawing.Size(96, 23);
			this.textId.TabIndex = 7;
			this.textId.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "用户密码";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "用户账号";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(224, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "用户姓名";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(224, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "用户部门";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(224, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "电话号码";
			// 
			// txtName
			// 
			this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetUser, "User.UserName"));
			this.txtName.Location = new System.Drawing.Point(304, 56);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(96, 23);
			this.txtName.TabIndex = 7;
			this.txtName.Text = "";
			// 
			// txtDepart
			// 
			this.txtDepart.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetUser, "User.UserDepart"));
			this.txtDepart.Location = new System.Drawing.Point(304, 88);
			this.txtDepart.Name = "txtDepart";
			this.txtDepart.Size = new System.Drawing.Size(96, 23);
			this.txtDepart.TabIndex = 7;
			this.txtDepart.Text = "";
			// 
			// txtPhone
			// 
			this.txtPhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetUser, "User.UserPhone"));
			this.txtPhone.Location = new System.Drawing.Point(304, 120);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(96, 23);
			this.txtPhone.TabIndex = 7;
			this.txtPhone.Text = "";
			// 
			// btnExit
			// 
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Location = new System.Drawing.Point(488, 176);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(72, 32);
			this.btnExit.TabIndex = 27;
			this.btnExit.Text = "退出";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnCancel);
			this.groupBox3.Controls.Add(this.btnApply);
			this.groupBox3.Location = new System.Drawing.Point(432, 40);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(144, 80);
			this.groupBox3.TabIndex = 29;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "编辑记录";
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(80, 48);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(56, 24);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "取消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnApply
			// 
			this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnApply.Location = new System.Drawing.Point(8, 48);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(56, 24);
			this.btnApply.TabIndex = 12;
			this.btnApply.Text = "确定";
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// da
			// 
			this.da.DeleteCommand = this.sqlDeleteCommand1;
			this.da.InsertCommand = this.sqlInsertCommand1;
			this.da.SelectCommand = this.sqlSelectCommand1;
			this.da.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																						 new System.Data.Common.DataTableMapping("Table", "User", new System.Data.Common.DataColumnMapping[] {
																																																 new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																 new System.Data.Common.DataColumnMapping("UserName", "UserName"),
																																																 new System.Data.Common.DataColumnMapping("UserPassword", "UserPassword"),
																																																 new System.Data.Common.DataColumnMapping("UserSort", "UserSort"),
																																																 new System.Data.Common.DataColumnMapping("UserDepart", "UserDepart"),
																																																 new System.Data.Common.DataColumnMapping("UserPhone", "UserPhone")})});
			this.da.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM [User] WHERE (UserID = @Original_UserID) AND (UserDepart = @Original_UserDepart OR @Original_UserDepart IS NULL AND UserDepart IS NULL) AND (UserName = @Original_UserName OR @Original_UserName IS NULL AND UserName IS NULL) AND (UserPassword = @Original_UserPassword OR @Original_UserPassword IS NULL AND UserPassword IS NULL) AND (UserPhone = @Original_UserPhone OR @Original_UserPhone IS NULL AND UserPhone IS NULL) AND (UserSort = @Original_UserSort OR @Original_UserSort IS NULL AND UserSort IS NULL)";
			this.sqlDeleteCommand1.Connection = this.conn;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserID", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserDepart", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserDepart", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserName", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserName", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserPassword", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserPassword", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserPhone", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserPhone", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserSort", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserSort", System.Data.DataRowVersion.Original, null));
			// 
			// conn
			// 
			this.conn.ConnectionString = "workstation id=user05;packet size=4096;integrated security=SSPI;data source=USER0" +
				"5;persist security info=False;initial catalog=LibraryManage";
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO [User] (UserID, UserName, UserPassword, UserSort, UserDepart, UserPhone) VALUES (@UserID, @UserName, @UserPassword, @UserSort, @UserDepart, @UserPhone); SELECT UserID, UserName, UserPassword, UserSort, UserDepart, UserPhone FROM [User] WHERE (UserID = @UserID)";
			this.sqlInsertCommand1.Connection = this.conn;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.VarChar, 10, "UserID"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserName", System.Data.SqlDbType.VarChar, 10, "UserName"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserPassword", System.Data.SqlDbType.VarChar, 10, "UserPassword"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserSort", System.Data.SqlDbType.VarChar, 20, "UserSort"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserDepart", System.Data.SqlDbType.VarChar, 10, "UserDepart"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserPhone", System.Data.SqlDbType.VarChar, 10, "UserPhone"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT UserID, UserName, UserPassword, UserSort, UserDepart, UserPhone FROM [User" +
				"]";
			this.sqlSelectCommand1.Connection = this.conn;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE [User] SET UserID = @UserID, UserName = @UserName, UserPassword = @UserPassword, UserSort = @UserSort, UserDepart = @UserDepart, UserPhone = @UserPhone WHERE (UserID = @Original_UserID) AND (UserDepart = @Original_UserDepart OR @Original_UserDepart IS NULL AND UserDepart IS NULL) AND (UserName = @Original_UserName OR @Original_UserName IS NULL AND UserName IS NULL) AND (UserPassword = @Original_UserPassword OR @Original_UserPassword IS NULL AND UserPassword IS NULL) AND (UserPhone = @Original_UserPhone OR @Original_UserPhone IS NULL AND UserPhone IS NULL) AND (UserSort = @Original_UserSort OR @Original_UserSort IS NULL AND UserSort IS NULL); SELECT UserID, UserName, UserPassword, UserSort, UserDepart, UserPhone FROM [User] WHERE (UserID = @UserID)";
			this.sqlUpdateCommand1.Connection = this.conn;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.VarChar, 10, "UserID"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserName", System.Data.SqlDbType.VarChar, 10, "UserName"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserPassword", System.Data.SqlDbType.VarChar, 10, "UserPassword"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserSort", System.Data.SqlDbType.VarChar, 20, "UserSort"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserDepart", System.Data.SqlDbType.VarChar, 10, "UserDepart"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserPhone", System.Data.SqlDbType.VarChar, 10, "UserPhone"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserID", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserDepart", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserDepart", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserName", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserName", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserPassword", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserPassword", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserPhone", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserPhone", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserSort", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserSort", System.Data.DataRowVersion.Original, null));
			// 
			// User
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.LightBlue;
			this.ClientSize = new System.Drawing.Size(626, 237);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.groupBox3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "User";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "用户信息维护";
			this.Load += new System.EventHandler(this.User_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.objDataSetUser)).EndInit();
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
				this.textId.Enabled=true;				
				this.textSort.Enabled=true;
				this.textPassword.Enabled=true;
				//this.chkValid.Enabled=true;
				
			}
			else
			{
				this.textId.Enabled=false;				
				this.textSort.Enabled=false;
				this.textPassword.Enabled=false;
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
						
		private void LoadDataSet(string Query)
		{
			DataSetUser objDataSetTemp=new DataSetUser();
			try
			{
				this.FillDataSet(objDataSetTemp,Query);

			}
			catch (System.Exception E) 
			{
				// 在此处添加错误处理代码。
				this.ErrorHandle(E);
			}
			try
			{
				this.objDataSetUser.Clear();
				this.objDataSetUser.Merge(objDataSetTemp);
			}
			catch(System.Exception E) 
			{
				// 在此处添加错误处理代码。
				this.ErrorHandle(E);
			}
			
		}
		
		private void FillDataSet(DataSetUser dataset,string sqlQuery)
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

		private void User_Load(object sender, System.EventArgs e)
		{
		
			if(this.sqlQuery!="")
			{
				this.LoadDataSet(sqlQuery);
				
				this.TextEnableControl(false);
				this.ButtonEnableControl(false);
				this.TextEnableControl(true);
				this.ButtonEnableControl(true);
			}
			else
			{
				addUser();
			
			}
		
		}
		
		private void addUser()
		{
		
		try
			{
				this.BindingContext[this.objDataSetUser,"User"].AddNew();
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
			this.BindingContext[this.objDataSetUser,"User"].EndCurrentEdit();
			DataSetUser objDataSetTemp=new DataSetUser();
			objDataSetTemp=(DataSetUser)(this.objDataSetUser.GetChanges());
			try
			{
				this.UpdateDataSource(objDataSetTemp);
				this.objDataSetUser.Merge(objDataSetTemp);
				this.objDataSetUser.AcceptChanges();
			}
			catch(System.Exception E)
			{
				this.ErrorHandle(E);
			}
		}
		

		public void UpdateDataSource(DataSetUser Changerows)
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
				this.BindingContext[this.objDataSetUser,"User"].CancelCurrentEdit();
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
