using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Library.UserInterface;
using Library.DataLevel;
namespace Library.UserInterface
{
	/// <summary>
	/// Book 的摘要说明。
	/// </summary>
	public class Book : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textName;
		private System.Windows.Forms.TextBox textId;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;		
		private System.Windows.Forms.TextBox textWriter;
		private System.Windows.Forms.TextBox textPublish;
		private System.Windows.Forms.TextBox textPublishDate;
		private System.Windows.Forms.TextBox textSort;
		private System.Windows.Forms.TextBox textRemain;
		private System.Windows.Forms.TextBox textPrice;
		private System.Windows.Forms.TextBox textAmount;
		private Library.UserInterface.DataSetBook objDataSetBook;
		private string sqlQuery="";
		private string userSort;
		private string userName;
		//private Library.DataSetBook objDataSetBook;
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
		public Book(string Query,string username,string usersort)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			this.userName=username;			
			this.userSort=usersort;
			sqlQuery="select * from Book where BookID='"+Query+"'";
			InitializeComponent();
			conn.ConnectionString=dbc.databaseConnection;
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		
		public Book(string username,string usersort)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Book));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textAmount = new System.Windows.Forms.TextBox();
			this.objDataSetBook = new Library.UserInterface.DataSetBook();
			this.label9 = new System.Windows.Forms.Label();
			this.textPrice = new System.Windows.Forms.TextBox();
			this.textRemain = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textWriter = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textPublish = new System.Windows.Forms.TextBox();
			this.textName = new System.Windows.Forms.TextBox();
			this.textId = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textPublishDate = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textSort = new System.Windows.Forms.TextBox();
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
			((System.ComponentModel.ISupportInitialize)(this.objDataSetBook)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textAmount);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.textPrice);
			this.groupBox1.Controls.Add(this.textRemain);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.textWriter);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.textPublish);
			this.groupBox1.Controls.Add(this.textName);
			this.groupBox1.Controls.Add(this.textId);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textPublishDate);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.textSort);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox1.Location = new System.Drawing.Point(24, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(464, 216);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "图书信息维护";
			// 
			// textAmount
			// 
			this.textAmount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetBook, "Book.BookAmount"));
			this.textAmount.Location = new System.Drawing.Point(336, 144);
			this.textAmount.Name = "textAmount";
			this.textAmount.Size = new System.Drawing.Size(104, 23);
			this.textAmount.TabIndex = 31;
			this.textAmount.Text = "";
			// 
			// objDataSetBook
			// 
			this.objDataSetBook.DataSetName = "DataSetBook";
			this.objDataSetBook.Locale = new System.Globalization.CultureInfo("zh-CN");
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(256, 144);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 23);
			this.label9.TabIndex = 30;
			this.label9.Text = "总册数";
			// 
			// textPrice
			// 
			this.textPrice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetBook, "Book.BookPrice"));
			this.textPrice.Location = new System.Drawing.Point(96, 174);
			this.textPrice.Name = "textPrice";
			this.textPrice.Size = new System.Drawing.Size(104, 23);
			this.textPrice.TabIndex = 29;
			this.textPrice.Text = "";
			// 
			// textRemain
			// 
			this.textRemain.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetBook, "Book.BookRemain"));
			this.textRemain.Location = new System.Drawing.Point(336, 176);
			this.textRemain.Name = "textRemain";
			this.textRemain.Size = new System.Drawing.Size(104, 23);
			this.textRemain.TabIndex = 28;
			this.textRemain.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(24, 176);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 23);
			this.label8.TabIndex = 27;
			this.label8.Text = "图书单价";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(256, 176);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 23);
			this.label6.TabIndex = 26;
			this.label6.Text = "库存量";
			// 
			// textWriter
			// 
			this.textWriter.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetBook, "Book.BookWriter"));
			this.textWriter.Location = new System.Drawing.Point(96, 140);
			this.textWriter.Name = "textWriter";
			this.textWriter.Size = new System.Drawing.Size(104, 23);
			this.textWriter.TabIndex = 13;
			this.textWriter.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(24, 144);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 23);
			this.label7.TabIndex = 12;
			this.label7.Text = "图书作者";
			// 
			// textPublish
			// 
			this.textPublish.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetBook, "Book.BookPublish"));
			this.textPublish.Location = new System.Drawing.Point(336, 40);
			this.textPublish.Name = "textPublish";
			this.textPublish.Size = new System.Drawing.Size(104, 23);
			this.textPublish.TabIndex = 10;
			this.textPublish.Text = "";
			// 
			// textName
			// 
			this.textName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetBook, "Book.BookName"));
			this.textName.Location = new System.Drawing.Point(96, 106);
			this.textName.Name = "textName";
			this.textName.Size = new System.Drawing.Size(104, 23);
			this.textName.TabIndex = 8;
			this.textName.Text = "";
			// 
			// textId
			// 
			this.textId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetBook, "Book.BookID"));
			this.textId.Location = new System.Drawing.Point(96, 72);
			this.textId.Name = "textId";
			this.textId.Size = new System.Drawing.Size(104, 23);
			this.textId.TabIndex = 7;
			this.textId.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(256, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "图书分类";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "图书名称";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "图书号码";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(256, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "出版社";
			// 
			// textPublishDate
			// 
			this.textPublishDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetBook, "Book.BookPublishDate"));
			this.textPublishDate.Location = new System.Drawing.Point(336, 72);
			this.textPublishDate.Name = "textPublishDate";
			this.textPublishDate.Size = new System.Drawing.Size(104, 23);
			this.textPublishDate.TabIndex = 9;
			this.textPublishDate.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(256, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "出版时间";
			// 
			// textSort
			// 
			this.textSort.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.objDataSetBook, "Book.BookSort"));
			this.textSort.Location = new System.Drawing.Point(336, 112);
			this.textSort.Name = "textSort";
			this.textSort.Size = new System.Drawing.Size(104, 23);
			this.textSort.TabIndex = 11;
			this.textSort.Text = "";
			// 
			// btnExit
			// 
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Location = new System.Drawing.Point(328, 296);
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
			this.groupBox3.Location = new System.Drawing.Point(24, 256);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(208, 80);
			this.groupBox3.TabIndex = 29;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "编辑记录";
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(120, 32);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(56, 24);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "取消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnApply
			// 
			this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnApply.Location = new System.Drawing.Point(24, 32);
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
																						 new System.Data.Common.DataTableMapping("Table", "Book", new System.Data.Common.DataColumnMapping[] {
																																																 new System.Data.Common.DataColumnMapping("BookID", "BookID"),
																																																 new System.Data.Common.DataColumnMapping("BookName", "BookName"),
																																																 new System.Data.Common.DataColumnMapping("BookWriter", "BookWriter"),
																																																 new System.Data.Common.DataColumnMapping("BookPublish", "BookPublish"),
																																																 new System.Data.Common.DataColumnMapping("BookPublishDate", "BookPublishDate"),
																																																 new System.Data.Common.DataColumnMapping("BookPrice", "BookPrice"),
																																																 new System.Data.Common.DataColumnMapping("BookSort", "BookSort"),
																																																 new System.Data.Common.DataColumnMapping("BookAmount", "BookAmount"),
																																																 new System.Data.Common.DataColumnMapping("BookRemain", "BookRemain")})});
			this.da.UpdateCommand = this.updateComm;
			// 
			// delComm
			// 
			this.delComm.CommandText = @"DELETE FROM Book WHERE (BookID = @Original_BookID) AND (BookAmount = @Original_BookAmount OR @Original_BookAmount IS NULL AND BookAmount IS NULL) AND (BookName = @Original_BookName OR @Original_BookName IS NULL AND BookName IS NULL) AND (BookPrice = @Original_BookPrice OR @Original_BookPrice IS NULL AND BookPrice IS NULL) AND (BookPublish = @Original_BookPublish OR @Original_BookPublish IS NULL AND BookPublish IS NULL) AND (BookPublishDate = @Original_BookPublishDate OR @Original_BookPublishDate IS NULL AND BookPublishDate IS NULL) AND (BookRemain = @Original_BookRemain OR @Original_BookRemain IS NULL AND BookRemain IS NULL) AND (BookSort = @Original_BookSort OR @Original_BookSort IS NULL AND BookSort IS NULL) AND (BookWriter = @Original_BookWriter OR @Original_BookWriter IS NULL AND BookWriter IS NULL)";
			this.delComm.Connection = this.conn;
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookID", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookID", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookAmount", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookAmount", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookName", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookName", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookPrice", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookPrice", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookPublish", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookPublish", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookPublishDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookPublishDate", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookRemain", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookRemain", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookSort", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookSort", System.Data.DataRowVersion.Original, null));
			this.delComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookWriter", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookWriter", System.Data.DataRowVersion.Original, null));
			// 
			// insertComm
			// 
			this.insertComm.CommandText = @"INSERT INTO Book(BookID, BookName, BookWriter, BookPublish, BookPublishDate, BookPrice, BookSort, BookAmount, BookRemain) VALUES (@BookID, @BookName, @BookWriter, @BookPublish, @BookPublishDate, @BookPrice, @BookSort, @BookAmount, @BookRemain); SELECT BookID, BookName, BookWriter, BookPublish, BookPublishDate, BookPrice, BookSort, BookAmount, BookRemain FROM Book WHERE (BookID = @BookID)";
			this.insertComm.Connection = this.conn;
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookID", System.Data.SqlDbType.VarChar, 10, "BookID"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookName", System.Data.SqlDbType.VarChar, 30, "BookName"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookWriter", System.Data.SqlDbType.VarChar, 20, "BookWriter"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookPublish", System.Data.SqlDbType.VarChar, 50, "BookPublish"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookPublishDate", System.Data.SqlDbType.DateTime, 8, "BookPublishDate"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookPrice", System.Data.SqlDbType.Float, 8, "BookPrice"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookSort", System.Data.SqlDbType.VarChar, 20, "BookSort"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookAmount", System.Data.SqlDbType.Int, 4, "BookAmount"));
			this.insertComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookRemain", System.Data.SqlDbType.Int, 4, "BookRemain"));
			// 
			// selectComm
			// 
			this.selectComm.CommandText = "SELECT BookID, BookName, BookWriter, BookPublish, BookPublishDate, BookPrice, Boo" +
				"kSort, BookAmount, BookRemain FROM Book";
			this.selectComm.Connection = this.conn;
			// 
			// updateComm
			// 
			this.updateComm.CommandText = @"UPDATE Book SET BookID = @BookID, BookName = @BookName, BookWriter = @BookWriter, BookPublish = @BookPublish, BookPublishDate = @BookPublishDate, BookPrice = @BookPrice, BookSort = @BookSort, BookAmount = @BookAmount, BookRemain = @BookRemain WHERE (BookID = @Original_BookID) AND (BookAmount = @Original_BookAmount OR @Original_BookAmount IS NULL AND BookAmount IS NULL) AND (BookName = @Original_BookName OR @Original_BookName IS NULL AND BookName IS NULL) AND (BookPrice = @Original_BookPrice OR @Original_BookPrice IS NULL AND BookPrice IS NULL) AND (BookPublish = @Original_BookPublish OR @Original_BookPublish IS NULL AND BookPublish IS NULL) AND (BookPublishDate = @Original_BookPublishDate OR @Original_BookPublishDate IS NULL AND BookPublishDate IS NULL) AND (BookRemain = @Original_BookRemain OR @Original_BookRemain IS NULL AND BookRemain IS NULL) AND (BookSort = @Original_BookSort OR @Original_BookSort IS NULL AND BookSort IS NULL) AND (BookWriter = @Original_BookWriter OR @Original_BookWriter IS NULL AND BookWriter IS NULL); SELECT BookID, BookName, BookWriter, BookPublish, BookPublishDate, BookPrice, BookSort, BookAmount, BookRemain FROM Book WHERE (BookID = @BookID)";
			this.updateComm.Connection = this.conn;
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookID", System.Data.SqlDbType.VarChar, 10, "BookID"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookName", System.Data.SqlDbType.VarChar, 30, "BookName"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookWriter", System.Data.SqlDbType.VarChar, 20, "BookWriter"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookPublish", System.Data.SqlDbType.VarChar, 50, "BookPublish"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookPublishDate", System.Data.SqlDbType.DateTime, 8, "BookPublishDate"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookPrice", System.Data.SqlDbType.Float, 8, "BookPrice"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookSort", System.Data.SqlDbType.VarChar, 20, "BookSort"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookAmount", System.Data.SqlDbType.Int, 4, "BookAmount"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BookRemain", System.Data.SqlDbType.Int, 4, "BookRemain"));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookID", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookID", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookAmount", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookAmount", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookName", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookName", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookPrice", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookPrice", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookPublish", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookPublish", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookPublishDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookPublishDate", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookRemain", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookRemain", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookSort", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookSort", System.Data.DataRowVersion.Original, null));
			this.updateComm.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BookWriter", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BookWriter", System.Data.DataRowVersion.Original, null));
			// 
			// Book
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.LightBlue;
			this.ClientSize = new System.Drawing.Size(498, 352);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.groupBox3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Book";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "图书信息维护";
			this.Load += new System.EventHandler(this.Book_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.objDataSetBook)).EndInit();
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
				this.textName.Enabled=true;
				this.textPrice.Enabled=true;
				this.textPublish.Enabled=true;				
				this.textPublishDate.Enabled=true;
				this.textWriter.Enabled=true;
				this.textSort.Enabled=true;
				this.textAmount.Enabled=true;
				this.textRemain.Enabled=true;				
				
			}
			else
			{
				this.textId.Enabled=false;
				this.textName.Enabled=false;								
				this.textPrice.Enabled=false;
				this.textPublish.Enabled=false;				
				this.textPublishDate.Enabled=false;
				this.textWriter.Enabled=false;
				this.textSort.Enabled=false;
				this.textAmount.Enabled=false;
				this.textRemain.Enabled=false;				
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
			DataSetBook objDataSetTemp=new DataSetBook();
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
				this.objDataSetBook.Clear();
				this.objDataSetBook.Merge(objDataSetTemp);
			}
			catch(System.Exception E) 
			{
				// 在此处添加错误处理代码。
				this.ErrorHandle(E);
			}
			
		}
		
	
		private void FillDataSet(DataSetBook dataset,string sqlQuery)
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

		private void Book_Load(object sender, System.EventArgs e)
		{
			
			if(this.userSort!="reader")
			{
				if( this.sqlQuery!="")
				{
					this.LoadDataSet(sqlQuery);
					this.TextEnableControl(true);
					this.ButtonEnableControl(true);
				}
				else
				{
					addnewBook();
				}
			}
			
			else
			{
				this.LoadDataSet(sqlQuery);
				this.TextEnableControl(false);
				this.ButtonEnableControl(false);
			}

		}
		
		

		private void addnewBook()
		{
		
		try
			{
				this.BindingContext[this.objDataSetBook,"Book"].AddNew();
			}
			catch(System.Exception E)
			{
				this.ErrorHandle(E);
			}
			this.TextEnableControl(true);
			this.ButtonEnableControl(true);
		
		}


		private void btnQuery_Click(object sender, System.EventArgs e)
		{

		
		}
		
		public void UpdateDataSet()
		{
			this.BindingContext[this.objDataSetBook,"Book"].EndCurrentEdit();
			DataSetBook objDataSetTemp=new DataSetBook();
			objDataSetTemp=(DataSetBook)(this.objDataSetBook.GetChanges());
			try
			{
				this.UpdateDataSource(objDataSetTemp);
				this.objDataSetBook.Merge(objDataSetTemp);
				this.objDataSetBook.AcceptChanges();
			}
			catch(System.Exception E)
			{
				this.ErrorHandle(E);
			}
		}
		

		public void UpdateDataSource(DataSetBook Changerows)
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
				this.BindingContext[this.objDataSetBook,"Book"].CancelCurrentEdit();
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

		private void btnReport_Click(object sender, System.EventArgs e)
		{
		
		}		

	}
}
