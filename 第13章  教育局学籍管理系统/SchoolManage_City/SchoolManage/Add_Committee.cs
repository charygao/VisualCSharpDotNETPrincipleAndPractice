using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolManage
{
	/// <summary>
	/// Add_Committee 的摘要说明。
	/// </summary>
	public class Add_Committee : System.Windows.Forms.Form
	{
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Button button2;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Button button1;
	private System.Windows.Forms.DataGrid DataGrid1;
	private System.Windows.Forms.Label label3;
			/// <summary>
			/// 必需的设计器变量。
			/// </summary>
	private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ComboBox comboBox_Office;
		private System.Windows.Forms.ComboBox comboBox_QuXian;
		private System.Windows.Forms.TextBox textBox_Committee_Name;
		private System.Windows.Forms.TextBox textBox_Committee_ID;

	protected config conn=new config();

	public Add_Committee()
	{
				//
				// Windows 窗体设计器支持所必需的
				//
		InitializeComponent();

					//按数据库里边存储的区县绑定下拉列表
		string str_Sql,errorstring;
		errorstring=conn.BindComboBox("Select * from QuXian WHERE QuXian_ID<>9",comboBox_QuXian,"QuXian_ID","QuXian_Name");
		if(errorstring!="OK")
		{
			MessageBox.Show("请检查数据库！"+errorstring, "提醒！", 
			MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			button1.Enabled=false;
			return;
		}

		//按数据库里边存储的办事处绑定下拉列表
		errorstring=conn.BindComboBox("Select * from Office Where QuXian_ID_OfficeIn="+comboBox_QuXian.SelectedValue.ToString(),comboBox_Office,"Office_ID","Office_Name");
		if(errorstring!="OK")
		{
			MessageBox.Show("请检查数据库！"+errorstring, "提醒！", 
				MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			button1.Enabled=false;
			return;
		}
					//按区县办事处内联显示名称,绑定DataGrid显示
		str_Sql="SELECT Committee_ID AS 居委会代码,Committee_Name AS 居委会名称,Office_Name AS 办事处名称,QuXian_Name AS 区县名称 FROM View_Committee";

		conn.Fill(str_Sql);
		DataGrid1.SetDataBinding(conn.ds,"TableIn");
					
		textBox_Committee_ID.Text=conn.GetMaxId("Committee_ID","Committee");
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
		this.comboBox_QuXian = new System.Windows.Forms.ComboBox();
		this.label4 = new System.Windows.Forms.Label();
		this.button2 = new System.Windows.Forms.Button();
		this.label2 = new System.Windows.Forms.Label();
		this.textBox_Committee_Name = new System.Windows.Forms.TextBox();
		this.textBox_Committee_ID = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.DataGrid1 = new System.Windows.Forms.DataGrid();
		this.comboBox_Office = new System.Windows.Forms.ComboBox();
		this.label3 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
		this.SuspendLayout();
		// 
		// comboBox_QuXian
		// 
		this.comboBox_QuXian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_QuXian.Location = new System.Drawing.Point(200, 456);
		this.comboBox_QuXian.Name = "comboBox_QuXian";
		this.comboBox_QuXian.Size = new System.Drawing.Size(96, 20);
		this.comboBox_QuXian.TabIndex = 52;
		this.comboBox_QuXian.SelectionChangeCommitted += new System.EventHandler(this.comboBox_QuXian_SelectionChangeCommitted);
		// 
		// label4
		// 
		this.label4.Location = new System.Drawing.Point(104, 458);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(96, 16);
		this.label4.TabIndex = 51;
		this.label4.Text = "居委会所在区县";
		// 
		// button2
		// 
		this.button2.Location = new System.Drawing.Point(296, 520);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(72, 23);
		this.button2.TabIndex = 50;
		this.button2.Text = "退出";
		this.button2.Click += new System.EventHandler(this.button2_Click);
		// 
		// label2
		// 
		this.label2.Location = new System.Drawing.Point(200, 488);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(56, 16);
		this.label2.TabIndex = 49;
		this.label2.Text = "居委会名称";
		// 
		// textBox_Committee_Name
		// 
		this.textBox_Committee_Name.Location = new System.Drawing.Point(264, 486);
		this.textBox_Committee_Name.Name = "textBox_Committee_Name";
		this.textBox_Committee_Name.Size = new System.Drawing.Size(232, 21);
		this.textBox_Committee_Name.TabIndex = 48;
		this.textBox_Committee_Name.Text = "";
		// 
		// textBox_Committee_ID
		// 
		this.textBox_Committee_ID.Enabled = false;
		this.textBox_Committee_ID.Location = new System.Drawing.Point(144, 486);
		this.textBox_Committee_ID.Name = "textBox_Committee_ID";
		this.textBox_Committee_ID.Size = new System.Drawing.Size(24, 21);
		this.textBox_Committee_ID.TabIndex = 47;
		this.textBox_Committee_ID.Text = "";
		// 
		// label1
		// 
		this.label1.Location = new System.Drawing.Point(104, 488);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(32, 16);
		this.label1.TabIndex = 46;
		this.label1.Text = "编号";
		// 
		// button1
		// 
		this.button1.Location = new System.Drawing.Point(144, 520);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(72, 23);
		this.button1.TabIndex = 45;
		this.button1.Text = "确认添加";
		this.button1.Click += new System.EventHandler(this.button1_Click);
		// 
		// DataGrid1
		// 
		this.DataGrid1.AlternatingBackColor = System.Drawing.SystemColors.Window;
		this.DataGrid1.BackgroundColor = System.Drawing.Color.LightGray;
		this.DataGrid1.CaptionText = "                                       现有居委会情况";
		this.DataGrid1.DataMember = "";
		this.DataGrid1.GridLineColor = System.Drawing.SystemColors.Control;
		this.DataGrid1.HeaderBackColor = System.Drawing.SystemColors.Control;
		this.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.DataGrid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.DataGrid1.LinkColor = System.Drawing.SystemColors.HotTrack;
		this.DataGrid1.Location = new System.Drawing.Point(30, 30);
		this.DataGrid1.Name = "DataGrid1";
		this.DataGrid1.PreferredColumnWidth = 100;
		this.DataGrid1.ReadOnly = true;
		this.DataGrid1.RowHeaderWidth = 20;
		this.DataGrid1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
		this.DataGrid1.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.DataGrid1.Size = new System.Drawing.Size(550, 400);
		this.DataGrid1.TabIndex = 44;
		// 
		// comboBox_Office
		// 
		this.comboBox_Office.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_Office.Location = new System.Drawing.Point(400, 456);
		this.comboBox_Office.Name = "comboBox_Office";
		this.comboBox_Office.Size = new System.Drawing.Size(96, 20);
		this.comboBox_Office.TabIndex = 54;
		// 
		// label3
		// 
		this.label3.Location = new System.Drawing.Point(296, 458);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(104, 16);
		this.label3.TabIndex = 53;
		this.label3.Text = "居委会所在办事处";
		// 
		// Add_Committee
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.ClientSize = new System.Drawing.Size(616, 565);
		this.Controls.Add(this.comboBox_Office);
		this.Controls.Add(this.label3);
		this.Controls.Add(this.comboBox_QuXian);
		this.Controls.Add(this.label4);
		this.Controls.Add(this.button2);
		this.Controls.Add(this.label2);
		this.Controls.Add(this.textBox_Committee_Name);
		this.Controls.Add(this.textBox_Committee_ID);
		this.Controls.Add(this.label1);
		this.Controls.Add(this.button1);
		this.Controls.Add(this.DataGrid1);
		this.Name = "Add_Committee";
		this.Text = "居委会添加";
		((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
		this.ResumeLayout(false);

	}
	#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(comboBox_Office.SelectedItem==null)
			{
				MessageBox.Show("请选择该居委会所在办事处！", "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			if (conn.KickOut(textBox_Committee_Name.Text)=="") 
			{
				MessageBox.Show("必须输入居委会名称！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (textBox_Committee_Name.Text.Length>15)
			{
				MessageBox.Show("请不要超长输入居委会名称！", "警告！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			//去除'"?%=空格,插入办事处表
			string str_Sql,errorstring="";
			str_Sql="INSERT INTO Committee (Committee_ID,Committee_Name,Office_ID) values("
				+conn.KickOut(textBox_Committee_ID.Text.Trim())+",'"
				+conn.KickOut(textBox_Committee_Name.Text.Trim())
				+"',"+comboBox_Office.SelectedValue.ToString()+")";
			errorstring=conn.ExeSql(str_Sql);
			if(errorstring!="OK")
			{
				MessageBox.Show("未成功添加！请检查数据库！"+errorstring, "提醒！", 
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				button1.Enabled=false;
				return;
			}
			//MessageBox.Show("成功添加！", "提醒！",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			
			//刷新DataGrid显示,选中最后一行反色显示
			str_Sql="SELECT Committee_ID AS 居委会代码,Committee_Name AS 居委会名称,Office_Name AS 办事处名称,QuXian_Name AS 区县名称 FROM View_Committee";
			conn.Fill(str_Sql);
			DataGrid1.SetDataBinding(conn.ds,"TableIn");
			DataGrid1.Select(conn.ds.Tables["TableIn"].Rows.Count-1);

			textBox_Committee_ID.Text=conn.GetMaxId("Committee_ID","Committee");
			textBox_Committee_Name.Text="";
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Dispose();		
		}

		private void comboBox_QuXian_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			conn.BindComboBox("Select * from Office WHERE QuXian_ID_OfficeIn="+comboBox_QuXian.SelectedValue.ToString(),comboBox_Office,"Office_ID","Office_Name");	
		}
	}
}