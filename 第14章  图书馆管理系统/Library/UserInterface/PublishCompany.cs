using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Library.DataLevel;
namespace Library.UserInterface
{
	/// <summary>
	/// Publishing 的摘要说明。
	/// </summary>
	public class Publishing : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textEmail;
		private System.Windows.Forms.TextBox textAdress;
		private System.Windows.Forms.TextBox textName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textTelNo;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnApply;
		private Library.UserInterface.DataSetPublishing objDataSetPublishing;
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
		public Publishing(string Query,string username,string usersort)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			this.userName=username;			
			this.userSort=usersort;
			sqlQuery="select * from PublishCompany where PublishName='"+Query+"'";
			InitializeComponent();
			conn.ConnectionString=dbc.databaseConnection;
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		public Publishing(string username,string usersort)
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textEmail = new System.Windows.Forms.TextBox();
			this.objDataSetPublishing = new Library.UserInterface.DataSetPublishing();
			this.textAdress = new System.Windows.Forms.TextBox();
			this.textName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textTelNo = new System.Windows.Forms.TextBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.conn = new System.Data.SqlClient.SqlConnection();
			this.da = new System.Data.SqlClient.SqlDataAdapter();
			this.delComm = new System.Data.SqlClient.SqlCommand();
			this.insertComm = new System.Data.SqlClient.SqlCommand();
			this.selectComm = new System.Data.SqlClient.SqlCommand();
			this.updateComm = new System.Data.SqlClient.SqlCommand();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.objDataSetPublishing)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textEmail);
			this.groupBox1.Controls.Add(this.textAdress);
			this.groupBox1.Controls.Add(this.textName);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textTelNo);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox1.Location = new System.Drawing.Point(52, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(316, 232);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "出版社信息维护";
			// 
			// textEmail
			// 
			this.textEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetPublishing, "PublishCompany.PbulishEmail"));
			this.textEmail.Location = new System.Drawing.Point(96, 112);
			this.textEmail.Name = "textEmail";
			this.textEmail.Size = new System.Drawing.Size(208, 23);
			this.textEmail.TabIndex = 10;
			this.textEmail.Text = "";
			// 
			// objDataSetPublishing
			// 
			this.objDataSetPublishing.DataSetName = "DataSetPublishing";
			this.objDataSetPublishing.Locale = new System.Globalization.CultureInfo("zh-CN");
			// 
			// textAdress
			// 
			this.textAdress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetPublishing, "PublishCompany.PublishAddress"));
			this.textAdress.Location = new System.Drawing.Point(96, 66);
			this.textAdress.Name = "textAdress";
			this.textAdress.Size = new System.Drawing.Size(208, 23);
			this.textAdress.TabIndex = 8;
			this.textAdress.Text = "";
			// 
			// textName
			// 
			this.textName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetPublishing, "PublishCompany.PublishName"));
			this.textName.Location = new System.Drawing.Point(96, 24);
			this.textName.Name = "textName";
			this.textName.Size = new System.Drawing.Size(208, 23);
			this.textName.TabIndex = 7;
			this.textName.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "出版社Email";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "出版社地址";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "出版社名称";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 160);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "联系电话";
			// 
			// textTelNo
			// 
			this.textTelNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetPublishing, "PublishCompany.PublishPhoneNo"));
			this.textTelNo.Location = new System.Drawing.Point(96, 160);
			this.textTelNo.Name = "textTelNo";
			this.textTelNo.Size = new System.Drawing.Size(208, 23);
			this.textTelNo.TabIndex = 9;
			this.textTelNo.Text = "";
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(416, 224);
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
			this.groupBox3.Location = new System.Drawing.Point(384, 64);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(144, 96);
			this.groupBox3.TabIndex = 29;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "添加/ 修改";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(16, 56);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(56, 24);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "取消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(80, 56);
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
																						 new System.Data.Common.DataTableMapping("Table", "PublishCompany", new System.Data.Common.DataColumnMapping[] {
																																																		   new System.Data.Common.DataColumnMapping("PublishName", "PublishName"),
																																																		   new System.Data.Common.DataColumnMapping("PublishAddress", "PublishAddress"),
																																																		   new System.Data.Common.DataColumnMapping("PublishPhoneNo", "PublishPhoneNo"),
																																																		   new System.Data.Common.DataColumnMapping("PbulishEmail", "PbulishEmail")})});
			this.da.UpdateCommand = this.updateComm;
			// 
			// delComm
			// 
			this.delComm.CommandText = @"DELETE FROM PublishCompany WHERE (PublishName = @Original_PublishName) AND (PbulishEmail = @Original_PbulishEmail OR @Original_PbulishEmail IS NULL AND PbulishEmail IS NULL) AND (PublishAddress = @Original_PublishAddress OR @Original_PublishAddress IS NULL AND PublishAddress IS NULL) AND (PublishPhoneNo = @Original_PublishPhoneNo OR @Original_PublishPhoneNo IS NULL AND PublishPhoneNo IS NULL)";
			this.delComm.Connection = this.conn;
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PublishName", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PublishName", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PbulishEmail", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PbulishEmail", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PublishAddress", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PublishAddress", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PublishPhoneNo", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PublishPhoneNo", System.Data.DataRowVersion.Original, null));
			// 
			// insertComm
			// 
			this.insertComm.CommandText = @"INSERT INTO PublishCompany(PublishName, PublishAddress, PublishPhoneNo, PbulishEmail) VALUES (@PublishName, @PublishAddress, @PublishPhoneNo, @PbulishEmail); SELECT PublishName, PublishAddress, PublishPhoneNo, PbulishEmail FROM PublishCompany WHERE (PublishName = @PublishName)";
			this.insertComm.Connection = this.conn;
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PublishName", System.Data.SqlDbType.VarChar, 50, "PublishName"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PublishAddress", System.Data.SqlDbType.VarChar, 50, "PublishAddress"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PublishPhoneNo", System.Data.SqlDbType.VarChar, 15, "PublishPhoneNo"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PbulishEmail", System.Data.SqlDbType.VarChar, 30, "PbulishEmail"));
			// 
			// selectComm
			// 
			this.selectComm.CommandText = "SELECT PublishName, PublishAddress, PublishPhoneNo, PbulishEmail FROM PublishComp" +
				"any";
			this.selectComm.Connection = this.conn;
			// 
			// updateComm
			// 
			this.updateComm.CommandText = @"UPDATE PublishCompany SET PublishName = @PublishName, PublishAddress = @PublishAddress, PublishPhoneNo = @PublishPhoneNo, PbulishEmail = @PbulishEmail WHERE (PublishName = @Original_PublishName) AND (PbulishEmail = @Original_PbulishEmail OR @Original_PbulishEmail IS NULL AND PbulishEmail IS NULL) AND (PublishAddress = @Original_PublishAddress OR @Original_PublishAddress IS NULL AND PublishAddress IS NULL) AND (PublishPhoneNo = @Original_PublishPhoneNo OR @Original_PublishPhoneNo IS NULL AND PublishPhoneNo IS NULL); SELECT PublishName, PublishAddress, PublishPhoneNo, PbulishEmail FROM PublishCompany WHERE (PublishName = @PublishName)";
			this.updateComm.Connection = this.conn;
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PublishName", System.Data.SqlDbType.VarChar, 50, "PublishName"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PublishAddress", System.Data.SqlDbType.VarChar, 50, "PublishAddress"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PublishPhoneNo", System.Data.SqlDbType.VarChar, 15, "PublishPhoneNo"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PbulishEmail", System.Data.SqlDbType.VarChar, 30, "PbulishEmail"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PublishName", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PublishName", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PbulishEmail", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PbulishEmail", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PublishAddress", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PublishAddress", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PublishPhoneNo", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PublishPhoneNo", System.Data.DataRowVersion.Original, null));
			// 
			// Publishing
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.LightBlue;
			this.ClientSize = new System.Drawing.Size(544, 318);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.groupBox3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Publishing";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "出版社信息维护";
			this.Load += new System.EventHandler(this.Publishing_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.objDataSetPublishing)).EndInit();
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
				this.textName.Enabled=true;
				this.textAdress.Enabled=true;
				
				this.textEmail.Enabled=true;				
				this.textTelNo.Enabled=true;	
				
				
			}
			else
			{
				this.textName.Enabled=false;
				this.textAdress.Enabled=false;
				
				this.textEmail.Enabled=false;				
				this.textTelNo.Enabled=false;
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
			DataSetPublishing objDataSetTemp=new DataSetPublishing();
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
				this.objDataSetPublishing.Clear();
				this.objDataSetPublishing.Merge(objDataSetTemp);
			}
			catch(System.Exception E) 
			{
				// 在此处添加错误处理代码。
				this.ErrorHandle(E);
			}
			
		}
		
		private void FillDataSet(DataSetPublishing dataset,string sqlQuery)
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

		private void Publishing_Load(object sender, System.EventArgs e)
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
				addnewPublishing();
			}
		
		
		}
		

		private void addnewPublishing()
		{
		
			try
			{
				this.BindingContext[this.objDataSetPublishing,"PublishCompany"].AddNew();
			}
			catch(System.Exception E)
			{
				this.ErrorHandle(E);
			}
			this.TextEnableControl(true);
			this.ButtonEnableControl(true);
		
		}
		

		

		

				

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			addnewPublishing();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if((this.BindingContext[this.objDataSetPublishing,"PublishCompany"].Count>0)&
				(MessageBox.Show("真的要删除此记录吗","确定删除",MessageBoxButtons.OKCancel,MessageBoxIcon.Question).Equals(DialogResult.OK)))
			{
				try
				{
					int currentPosition=this.BindingContext[this.objDataSetPublishing,"PublishCompany"].Position;
					this.objDataSetPublishing.Tables[0].Rows[currentPosition].Delete();
				}
				catch(System.Exception E)
				{
					this.ErrorHandle(E);
				}
				
			}
			else
				return;
		}

		
		

		
		public void UpdateDataSet()
		{
			this.BindingContext[this.objDataSetPublishing,"PublishCompany"].EndCurrentEdit();
			DataSetPublishing objDataSetTemp=new DataSetPublishing();
			objDataSetTemp=(DataSetPublishing)(this.objDataSetPublishing.GetChanges());
			try
			{
				this.UpdateDataSource(objDataSetTemp);
				this.objDataSetPublishing.Merge(objDataSetTemp);
				this.objDataSetPublishing.AcceptChanges();
			}
			catch(System.Exception E)
			{
				this.ErrorHandle(E);
			}
		}
		

		public void UpdateDataSource(DataSetPublishing Changerows)
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
				this.BindingContext[this.objDataSetPublishing,"PublishCompany"].CancelCurrentEdit();
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

		private void btnQuery_Click_1(object sender, System.EventArgs e)
		{
		
		}		

	}
}
