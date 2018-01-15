using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;//class_id->classes首先配置SQL开启SA用户
namespace csharp7_5_4
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		/// 
		ComboBox comboBox;//添加字段声明；
        private System.Windows.Forms.Label label1;
        private DataSet1 dataSet11;
        private BindingSource stuinfoBindingSource;
        private IContainer components;

		public Form1()
		{// Windows 窗体设计器支持所必需的
InitializeComponent();// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			comboBox=new ComboBox();//产生一个下拉列表控件对象
FillcomboBox();//向对象中添加内容
comboBox.SelectedIndex=0;
comboBox.Visible=false;//隐藏对象
this.comboBox.SelectedIndexChanged+=new System.EventHandler(this.comboBox_SelectedIndexChanged);//注册SelectedIndexChanged事件
this.dataGrid1.Controls.AddRange(new System.Windows.Forms.Control[]{comboBox});//向dataGrid1添加comboBox对象
this.sqlDataAdapter1.Fill(this.dataSet11,"stuinfo");
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataSet11 = new csharp7_5_4.DataSet1();
            this.stuinfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stuinfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlDataAdapter1
            // 
            this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
            this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "stuinfo", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("stu_id", "stu_id"),
                        new System.Data.Common.DataColumnMapping("stu_name", "stu_name"),
                        new System.Data.Common.DataColumnMapping("sex", "sex"),
                        new System.Data.Common.DataColumnMapping("classes", "classes"),
                        new System.Data.Common.DataColumnMapping("ages", "ages")})});
            this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = resources.GetString("sqlDeleteCommand1.CommandText");
            this.sqlDeleteCommand1.Connection = this.sqlConnection1;
            this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_stu_id", System.Data.SqlDbType.NChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "stu_id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_stu_name", System.Data.SqlDbType.NChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "stu_name", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_sex", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "sex", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_sex", System.Data.SqlDbType.NChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "sex", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_classes", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "classes", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_classes", System.Data.SqlDbType.NChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "classes", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_ages", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ages", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_ages", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ages", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=HK-PC\\SQLEXPRESS;Initial Catalog=stumanage;Integrated Security=True";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = resources.GetString("sqlInsertCommand1.CommandText");
            this.sqlInsertCommand1.Connection = this.sqlConnection1;
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@stu_id", System.Data.SqlDbType.NChar, 0, "stu_id"),
            new System.Data.SqlClient.SqlParameter("@stu_name", System.Data.SqlDbType.NChar, 0, "stu_name"),
            new System.Data.SqlClient.SqlParameter("@sex", System.Data.SqlDbType.NChar, 0, "sex"),
            new System.Data.SqlClient.SqlParameter("@classes", System.Data.SqlDbType.NChar, 0, "classes"),
            new System.Data.SqlClient.SqlParameter("@ages", System.Data.SqlDbType.Int, 0, "ages")});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT stu_id, stu_name, sex, classes, ages FROM stuinfo";
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = resources.GetString("sqlUpdateCommand1.CommandText");
            this.sqlUpdateCommand1.Connection = this.sqlConnection1;
            this.sqlUpdateCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@stu_id", System.Data.SqlDbType.NChar, 0, "stu_id"),
            new System.Data.SqlClient.SqlParameter("@stu_name", System.Data.SqlDbType.NChar, 0, "stu_name"),
            new System.Data.SqlClient.SqlParameter("@sex", System.Data.SqlDbType.NChar, 0, "sex"),
            new System.Data.SqlClient.SqlParameter("@classes", System.Data.SqlDbType.NChar, 0, "classes"),
            new System.Data.SqlClient.SqlParameter("@ages", System.Data.SqlDbType.Int, 0, "ages"),
            new System.Data.SqlClient.SqlParameter("@Original_stu_id", System.Data.SqlDbType.NChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "stu_id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_stu_name", System.Data.SqlDbType.NChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "stu_name", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_sex", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "sex", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_sex", System.Data.SqlDbType.NChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "sex", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_classes", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "classes", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_classes", System.Data.SqlDbType.NChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "classes", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_ages", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ages", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_ages", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ages", System.Data.DataRowVersion.Original, null)});
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(176, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "保  存";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(136, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "学 生 基 本 情 况";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.DataSource = this.stuinfoBindingSource;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(24, 38);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 30;
            this.dataGrid1.Size = new System.Drawing.Size(541, 248);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.Scroll += new System.EventHandler(this.dataGrid1_Scroll);
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // dataSet11
            // 
            this.dataSet11.DataSetName = "DataSet1";
            this.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stuinfoBindingSource
            // 
            this.stuinfoBindingSource.DataMember = "stuinfo";
            this.stuinfoBindingSource.DataSource = this.dataSet11;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(589, 326);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stuinfoBindingSource)).EndInit();
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
		private void FillcomboBox()
		{
            string sqlStr = "select DISTINCT  classes from stuinfo order by classes desc";//asc//"select * from stuinfo order by classes";//classinfo防止重复 
SqlConnection con=new SqlConnection(@"server=HK-PC\SQLEXPRESS;uid=sa;pwd = ;database=stumanage");
con.Open();//SqlConnection con=new SqlConnection("Server=(local);uid=sa;pwd=;database=stumanage");
			try
			{
				SqlCommand com=new SqlCommand(sqlStr,con);
				SqlDataReader r=com.ExecuteReader();//将classes列中的数据添加到下拉表框中
				while(r.Read())
				{
					comboBox.Items.Add(r["classes"]);//classes
				}
				r.Close();
				con.Close();
			}
			catch(Exception err)
			{
			    MessageBox.Show(err.Message);
			}
}//添加下列事件，该事件的功能是当用户操作dataGrid1表的第五列中的单元时，自动绘出下拉列表框控件comboBox，
private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
{//并将comboBox中默认选择项的内容放入dataGrid1的当前单元格中
			int col=this.dataGrid1.CurrentCell.ColumnNumber;//获取当前单元格所在列
if(col == 3)//如果是第五列才进行如下操作，注意第一列是0
{
				Rectangle rect=this.dataGrid1.GetCurrentCellBounds();//绘制comboBox
				this.comboBox.Location=this.dataGrid1.PointToClient(new Point(rect.Left,rect.Top));
				comboBox.SetBounds(rect.Left,rect.Top,rect.Width,rect.Height);
				comboBox.Visible=true;
				DataGridCell currentCell=this.dataGrid1.CurrentCell;
				for(int i=0;i<comboBox.Items.Count;i++)//在comboBox中找dataGrid1当前单元格的内容
				{
					if(comboBox.Items[i].ToString().Trim()==this.dataGrid1[currentCell.RowNumber,currentCell.ColumnNumber].ToString().Trim())
					{
						comboBox.SelectedIndex=i;
						break;
					}
				}//将comboBox对应项作为dataGrid1中当前单元格的内容
				this.dataGrid1[currentCell.RowNumber,currentCell.ColumnNumber]=comboBox.SelectedItem;
}
			else
			{
				comboBox.Visible=false;
			}
}

		private void dataGrid1_Scroll(object sender, System.EventArgs e)
		{
			this.comboBox.Visible=false;
		}
		private void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.sqlDataAdapter1.Update(this.dataSet11,"stuinfo");
				MessageBox.Show("保存成功","恭喜");
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message,"保存失败");
			}
		}
		private void comboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataGridCell currentCell=this.dataGrid1.CurrentCell;
			this.comboBox.Text=comboBox.SelectedItem.ToString();
			this.dataGrid1[currentCell.RowNumber,currentCell.ColumnNumber]=comboBox.Text;
		}
	}
}
