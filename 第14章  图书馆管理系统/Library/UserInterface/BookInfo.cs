using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using Library.UserInterface;
namespace Library.UserInterface
{
	/// <summary>
	/// BookInfo 的摘要说明。
	/// </summary>
	public class BookInfo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView lv;
		private System.Windows.Forms.TextBox txtQuery;
		private System.Windows.Forms.Button btnQuery;
		private UserInterface.Initialize Ini=new Initialize();
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnModify;
		private System.Windows.Forms.Button btnDelete;
		private UserInterface.CommonMethod.DeleteData dd=new Library.UserInterface.CommonMethod.DeleteData();
		
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private string userSort;
		private System.Windows.Forms.Panel pnlLV;
		private System.Windows.Forms.Panel pnlEdit;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel pnlQuery;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel pnlData;
		private string userName;
		public BookInfo(string username,string usersort)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			
			this.userName=username;			
		this.userSort=usersort;
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
			this.lv = new System.Windows.Forms.ListView();
			this.txtQuery = new System.Windows.Forms.TextBox();
			this.btnQuery = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnModify = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.pnlLV = new System.Windows.Forms.Panel();
			this.pnlEdit = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.pnlQuery = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlData = new System.Windows.Forms.Panel();
			this.pnlLV.SuspendLayout();
			this.pnlEdit.SuspendLayout();
			this.pnlQuery.SuspendLayout();
			this.pnlData.SuspendLayout();
			this.SuspendLayout();
			// 
			// lv
			// 
			this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lv.Location = new System.Drawing.Point(0, 0);
			this.lv.Name = "lv";
			this.lv.Size = new System.Drawing.Size(936, 199);
			this.lv.TabIndex = 1;
			this.lv.DoubleClick += new System.EventHandler(this.lv_DoubleClick);
			// 
			// txtQuery
			// 
			this.txtQuery.Location = new System.Drawing.Point(280, 8);
			this.txtQuery.Name = "txtQuery";
			this.txtQuery.Size = new System.Drawing.Size(144, 21);
			this.txtQuery.TabIndex = 3;
			this.txtQuery.Text = "";
			this.txtQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyEnter);
			// 
			// btnQuery
			// 
			this.btnQuery.Location = new System.Drawing.Point(456, 8);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.Size = new System.Drawing.Size(48, 24);
			this.btnQuery.TabIndex = 4;
			this.btnQuery.Text = "查询";
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.Location = new System.Drawing.Point(144, 0);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(56, 24);
			this.btnAdd.TabIndex = 14;
			this.btnAdd.Text = "添加";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnModify
			// 
			this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnModify.Location = new System.Drawing.Point(272, 0);
			this.btnModify.Name = "btnModify";
			this.btnModify.Size = new System.Drawing.Size(56, 24);
			this.btnModify.TabIndex = 16;
			this.btnModify.Text = "修改";
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDelete.Location = new System.Drawing.Point(424, 0);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(56, 24);
			this.btnDelete.TabIndex = 29;
			this.btnDelete.Text = "删除";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// pnlLV
			// 
			this.pnlLV.Controls.Add(this.lv);
			this.pnlLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlLV.Location = new System.Drawing.Point(0, 0);
			this.pnlLV.Name = "pnlLV";
			this.pnlLV.Size = new System.Drawing.Size(936, 199);
			this.pnlLV.TabIndex = 30;
			// 
			// pnlEdit
			// 
			this.pnlEdit.BackColor = System.Drawing.Color.Linen;
			this.pnlEdit.Controls.Add(this.btnAdd);
			this.pnlEdit.Controls.Add(this.btnModify);
			this.pnlEdit.Controls.Add(this.btnDelete);
			this.pnlEdit.Controls.Add(this.btnClose);
			this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlEdit.Location = new System.Drawing.Point(0, 199);
			this.pnlEdit.Name = "pnlEdit";
			this.pnlEdit.Size = new System.Drawing.Size(936, 24);
			this.pnlEdit.TabIndex = 31;
			// 
			// btnClose
			// 
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Location = new System.Drawing.Point(560, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(56, 24);
			this.btnClose.TabIndex = 29;
			this.btnClose.Text = "关闭";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// pnlQuery
			// 
			this.pnlQuery.BackColor = System.Drawing.Color.Linen;
			this.pnlQuery.Controls.Add(this.btnQuery);
			this.pnlQuery.Controls.Add(this.txtQuery);
			this.pnlQuery.Controls.Add(this.label1);
			this.pnlQuery.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlQuery.Location = new System.Drawing.Point(0, 0);
			this.pnlQuery.Name = "pnlQuery";
			this.pnlQuery.Size = new System.Drawing.Size(936, 32);
			this.pnlQuery.TabIndex = 30;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(88, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(165, 17);
			this.label1.TabIndex = 32;
			this.label1.Text = "请输入要查询的书名或是书号";
			// 
			// pnlData
			// 
			this.pnlData.Controls.Add(this.pnlLV);
			this.pnlData.Controls.Add(this.pnlEdit);
			this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlData.Location = new System.Drawing.Point(0, 32);
			this.pnlData.Name = "pnlData";
			this.pnlData.Size = new System.Drawing.Size(936, 223);
			this.pnlData.TabIndex = 32;
			// 
			// BookInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.LightCyan;
			this.ClientSize = new System.Drawing.Size(936, 255);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.pnlQuery);
			this.Name = "BookInfo";
			this.Load += new System.EventHandler(this.BookInfo_Load);
			this.pnlLV.ResumeLayout(false);
			this.pnlEdit.ResumeLayout(false);
			this.pnlQuery.ResumeLayout(false);
			this.pnlData.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void BookInfo_Load(object sender, System.EventArgs e)
		{
		
			Ini.setListView("Book",lv);
			if(this.userSort=="reader")
			{
				ButtonEnable(false);	
			}
			else
			{
				ButtonEnable(true);
			}
		}

		private void lv_DoubleClick(object sender, System.EventArgs e)
		{
			enterFormbook(tableID());
		}

		private string tableID()
		{
			ListViewItem newItem; 
			newItem=this.lv.SelectedItems[0]; 
			string bookid=newItem.SubItems[0].Text.Trim();
			return bookid;
		}
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			lv.Clear();
			Querying();
		}
		private void keyEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==(char)13)
			{
				lv.Clear();
				Querying();
			
			}
		}
	
		private void Querying()
		{
		
			if(txtQuery.Text!="")
			{
		
				Ini.setListView("Book","BookID","BookName",txtQuery.Text,lv);
			}
			else
			{
				Ini.setListView("Book",lv);
			}
		
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			enterFormbook();
		}

		private void enterFormbook()
		{
			Form bookForm=new Book(this.userName,this.userSort);
			bookForm.ShowDialog();
			Ini.setListView("Book",lv);
		}

		private void enterFormbook(string queryID)
		{
			Form bookForm=new Book(queryID,this.userName,this.userSort);
			bookForm.ShowDialog();
			Ini.setListView("Book",lv);
		
		}
		private void btnModify_Click(object sender, System.EventArgs e)
		{
			if(this.lv.SelectedItems.Count.ToString()!="0")
			{
				enterFormbook(tableID());
			}
			
			else
			{
				if(this.userSort!="reader")
				{
					MessageBox.Show("请选择需要修改的项目！！");
				}
				else
				{
					MessageBox.Show("请选择需要查询的项目！！");
					
				}
				
			}
			
		}
		private void ButtonEnable(bool valid)
		{
			if(valid)
			{
				this.btnAdd.Enabled=true;
				this.btnDelete.Enabled=true;
			
			}
			
			else
			{
				this.btnAdd.Enabled=false;
				this.btnDelete.Enabled=false;
				this.btnModify.Text="查询";
			}
		
		}
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if(this.lv.SelectedItems.Count.ToString()!="0")
			{
				if(MessageBox.Show("真的要删除此记录吗","确定删除",MessageBoxButtons.OKCancel,MessageBoxIcon.Question).Equals(DialogResult.OK))
				{
					try
					{
						string ID=tableID();
						dd.delBookdata(ID);
						Ini.setListView("Book",lv);
					}
					catch (Exception E)
					{
						MessageBox.Show(E.Message);
					}
				}
				else
				{
					return;
				}
			}
	
			else
			{
				MessageBox.Show("请选择需要删除的项目！！");
			
			}
		
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		
	}
}