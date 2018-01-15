using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Library.UserInterface;
using Library.DataLevel;
namespace Library
{
	/// <summary>
	/// Query 的摘要说明。
	/// </summary>
	public class Query : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox comboDataTable;
		private System.Windows.Forms.ComboBox comboDataItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textValue;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnQuery;
		public string SqlString;
		public string OrderString;
		public string QueryString;
		private System.Windows.Forms.ComboBox comboCondition;
		private System.Windows.Forms.GroupBox groupBox1;
		
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		DataBaseConnection dbc=new DataBaseConnection();
		private string userSort;
		private System.Data.SqlClient.SqlConnection conn;
		private System.Windows.Forms.DataGrid dg;
		private string userName;
		public Query(string username,string usersort)
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
			this.comboDataTable = new System.Windows.Forms.ComboBox();
			this.comboDataItem = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textValue = new System.Windows.Forms.TextBox();
			this.dg = new System.Windows.Forms.DataGrid();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnQuery = new System.Windows.Forms.Button();
			this.conn = new System.Data.SqlClient.SqlConnection();
			this.comboCondition = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboDataTable
			// 
			this.comboDataTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboDataTable.Items.AddRange(new object[] {
																"读者信息",
																"图书信息",
																"出版社信息",
																"借阅信息"});
			this.comboDataTable.Location = new System.Drawing.Point(104, 24);
			this.comboDataTable.Name = "comboDataTable";
			this.comboDataTable.Size = new System.Drawing.Size(104, 20);
			this.comboDataTable.TabIndex = 0;
			this.comboDataTable.SelectedIndexChanged += new System.EventHandler(this.comboDataTable_SelectedIndexChanged);
			// 
			// comboDataItem
			// 
			this.comboDataItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboDataItem.Location = new System.Drawing.Point(104, 56);
			this.comboDataItem.Name = "comboDataItem";
			this.comboDataItem.Size = new System.Drawing.Size(104, 20);
			this.comboDataItem.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "选择查询信息";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "选择查询项";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(240, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "选择查询条件";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(320, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "输入指定值";
			// 
			// textValue
			// 
			this.textValue.Location = new System.Drawing.Point(320, 48);
			this.textValue.Name = "textValue";
			this.textValue.Size = new System.Drawing.Size(88, 21);
			this.textValue.TabIndex = 7;
			this.textValue.Text = "";
			// 
			// dg
			// 
			this.dg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dg.DataMember = "";
			this.dg.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dg.Location = new System.Drawing.Point(16, 128);
			this.dg.Name = "dg";
			this.dg.ReadOnly = true;
			this.dg.Size = new System.Drawing.Size(504, 223);
			this.dg.TabIndex = 8;
			// 
			// btnClear
			// 
			this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClear.Location = new System.Drawing.Point(456, 48);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(64, 24);
			this.btnClear.TabIndex = 9;
			this.btnClear.Text = "重置";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnExit
			// 
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Location = new System.Drawing.Point(456, 80);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(64, 24);
			this.btnExit.TabIndex = 10;
			this.btnExit.Text = "退出";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnQuery
			// 
			this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnQuery.Location = new System.Drawing.Point(456, 16);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.Size = new System.Drawing.Size(64, 23);
			this.btnQuery.TabIndex = 11;
			this.btnQuery.Text = "查询";
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			// 
			// conn
			// 
			this.conn.ConnectionString = "workstation id=YXY1681;packet size=4096;integrated security=SSPI;data source=yxy1" +
				"681;persist security info=False;initial catalog=BookManager";
			// 
			// comboCondition
			// 
			this.comboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboCondition.Items.AddRange(new object[] {
																"=",
																">",
																">=",
																"<",
																"<=",
																"<>",
																"Like"});
			this.comboCondition.Location = new System.Drawing.Point(224, 48);
			this.comboCondition.Name = "comboCondition";
			this.comboCondition.Size = new System.Drawing.Size(80, 20);
			this.comboCondition.TabIndex = 12;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboDataTable);
			this.groupBox1.Controls.Add(this.comboDataItem);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.textValue);
			this.groupBox1.Controls.Add(this.comboCondition);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(424, 96);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "查询条件";
			// 
			// Query
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.LightBlue;
			this.ClientSize = new System.Drawing.Size(536, 373);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnQuery);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.dg);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Query";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "综合查询";
			this.Load += new System.EventHandler(this.Query_Load);
			((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void ErrorHandle(System.Exception E)
		{
			MessageBox.Show(E.ToString());
		}		


		
		
		

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void comboDataTable_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string strTable=this.comboDataTable.SelectedItem.ToString();
			SetcomboDataItem(strTable);	
		}
			
			
	
		
		private void SetcomboDataItem(string strTable)
		{
				switch(strTable)
				{
					case"读者信息"://当列表框的"读者信息"项被选中
						this.comboDataItem.Items.Clear();
						this.comboDataItem.Items.Add("借书证号");
						this.comboDataItem.Items.Add("读者姓名");
						this.comboDataItem.Items.Add("读者密码");
						this.comboDataItem.Items.Add("读者电话号码");
						this.comboDataItem.Items.Add("读者邮箱");
						this.comboDataItem.Items.Add("读者已借书数目");
						break;
				
					case"图书信息"://当列表框的"图书信息"项被选中
						this.comboDataItem.Items.Clear();
						this.comboDataItem.Items.Add("图书编号");
						this.comboDataItem.Items.Add("书名");
						this.comboDataItem.Items.Add("作者");
						this.comboDataItem.Items.Add("出版社");
						this.comboDataItem.Items.Add("出版日期");
						this.comboDataItem.Items.Add("单价");
						this.comboDataItem.Items.Add("类型");
						this.comboDataItem.Items.Add("馆藏总数");
						this.comboDataItem.Items.Add("剩余数目");
						break;
				
					case"出版社信息"://当列表框的"出版社信息"项被选中
						this.comboDataItem.Items.Clear();
						this.comboDataItem.Items.Add("出版社名");
						this.comboDataItem.Items.Add("地址");
						this.comboDataItem.Items.Add("电话号码");
						this.comboDataItem.Items.Add("邮箱");
						break;
				
					case"借阅信息"://当列表框的"借阅信息"项被选中
						this.comboDataItem.Items.Clear();
						this.comboDataItem.Items.Add("借书证号");
						this.comboDataItem.Items.Add("图书编号");
						this.comboDataItem.Items.Add("借书日期");
						this.comboDataItem.Items.Add("应还书日期");
						this.comboDataItem.Items.Add("实际还书日期");
						break;
				}
		}
		
		
		private void btnClear_Click(object sender, System.EventArgs e)
		{
			this.comboDataTable.Text="";
			this.comboDataItem.Text="";
			this.comboCondition.Text="";
			this.textValue.Text="";
		}

		private string SetSelectTable(string strTable)
		{
			string SqlString="";
			switch(strTable)
			{
				case"图书信息"://当列表框的"图书信息"项被选中
					SqlString="SELECT BookID AS 图书编号, BookName AS 书名, BookWriter AS 作者, ";
					SqlString+="BookPublish AS 出版社, BookPublishDate AS 出版日期, BookPrice AS 单价, ";
					SqlString+="  BookSort AS 类型, BookAmount AS 馆藏总数, BookRemain AS 剩余数目";
					SqlString+="  FROM dbo.Book";
					break;
					
				case"读者信息"://当列表框的"读者信息"项被选中
					SqlString="SELECT ReaderID AS 借书证号, ReaderName AS 读者姓名, ReaderPassword AS 读者密码, ";
					SqlString+="  ReaderPhoneNo AS 读者电话号码, ReaderEmail AS 读者邮箱, ";
					SqlString+="  ReaderBorrowedbooks AS 读者已借书数目";
					SqlString+=" FROM dbo.Reader";
					break;
				case"出版社信息"://当列表框的"出版社信息"项被选中
					SqlString="SELECT PublishName AS 出版社名, PublishAddress AS 地址, ";
					SqlString+="  PublishPhoneNo AS 电话号码, PbulishEmail AS 邮箱 ";
					SqlString+=" FROM dbo.PublishCompany";
					break;
				case"借阅信息"://当列表框的"借阅信息"项被选中
					SqlString="SELECT ReaderID AS 借书证号, BookID AS 图书编号, BorrowDate AS 借书日期, ";
					SqlString+="  ReturnDate AS 应还书日期, FactReturnDate AS 实际还书日期";
					SqlString+="  FROM dbo.BorrowBook";
					break;
			}
			return SqlString;
		}
		private string SetSelectData(string dataItem)
		{
			string Item="";
			switch(dataItem)
			{
				case"借书证号"://当列表框的"借书证号"项被选中
					Item=" ReaderID";
					break;
				case"读者姓名"://当列表框的"读者姓名"项被选中
					Item=" ReaderName ";
					break;
				case"读者密码"://当列表框的"读者密码"项被选中
					Item=" ReaderPassword";
					break;
				case"读者邮箱"://当列表框的"读者邮箱"项被选中
					Item=" ReaderEmail";
					break;
				case"读者已借书数目"://当列表框的"读者已借书目"项被选中
					Item=" ReaderBorrowedbooks";
					break;
				case"读者电话号码": ////当列表框的"读者电话号码"项被选中
					Item=" ReaderPhoneNo";
					break;
				case"图书编号":
					Item=" BookID";
					break;
				case"书名":
					Item=" BookName";
					break;
				case"作者":
					Item=" BookWriter";
					break;
				case"出版社":
					Item=" BookPublish";
					break;
				case"出版日期":
					Item=" BookPublishDate";
					break;
				case"单价":
					Item=" BookPrice";
					break;
				case"类型":
					Item=" BookSort";
					break;
				case"馆藏总数":
					Item=" BookAmount";
					break;
				case"剩余数目":
					Item=" BookRemain";
					break;
				case"出版社名":
					Item=" PublishName";
					break;
				case"地址":
					Item=" PublishAddress";
					break;
				case"电话号码":
					Item=" PublishPhoneNo";
					break;
				case"邮箱":
					Item=" PbulishEmail";
					break;
				case"借书日期":
					Item=" BorrowDate";
					break;
				case"应还书日期":
					Item=" ReturnDate";
					break;
				case"实际还书日期":
					Item=" FactReturnDate";
					break;
			}
			return Item;
		}
		private string SetTableName(string tableName)
		{
			string TableName="";
			switch(tableName)
			{
				case"图书信息":
					TableName="Book";
					break;
				case"读者信息":
					TableName="Reader";
					break;
				case"出版社信息":
					TableName="PublishCompany";
					break;
				case"借阅信息":
					TableName="BorrowBook";
					break;
			
			}
			return TableName;
		}
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			string conValue = this.textValue.Text;//指定的条件值
			string strTable=this.comboDataTable.Text;
			SqlString=SetSelectTable(strTable);
			if ((this.comboCondition.Text == "Like") && (this.textValue.Text != ""))
				conValue = "%"+this.textValue.Text+"%";
			string dataItem=SetSelectData(this.comboDataItem.Text);
			if ((this.comboDataItem.Text != "") && (this.comboCondition.Text != "") && (this.textValue.Text != ""))
				SqlString=SqlString+" where "+dataItem+" "+this.comboCondition.Text+" '"+conValue+"'";
				DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(SqlString,conn);
			try
			{
				da.Fill(ds,"Query");
				dg.DataSource=ds.Tables["Query"].DefaultView;
				
			}
			catch(System.Exception E)
			{
				this.ErrorHandle(E);
			}
		}

		private void Query_Load(object sender, System.EventArgs e)
		{
			
		}

		
	}
}
