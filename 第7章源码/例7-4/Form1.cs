using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace csharp7_4_1
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listBox1;
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
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("楷体_GB2312", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(88, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "学生基本信息";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button1.Location = new System.Drawing.Point(96, 312);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(136, 40);
			this.button1.TabIndex = 13;
			this.button1.Text = "顺序读取";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(16, 56);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(328, 244);
			this.listBox1.TabIndex = 14;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(360, 366);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "顺序读取示例";
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private void button1_Click(object sender, System.EventArgs e)
		{
            string str=@"server=HK-PC\SQLEXPRESS;Integrated Security=SSPI;database=stumanage";
			//string str="server=(local);Integrated Security=SSPI;database=stumanage";
			string sqlstr="select * from stuinfo where sex='男'";
			string strRow="";//用该字符串变量存放把数据集中读取的数据转换成的字符串
			SqlConnection con=new SqlConnection(str);//创建连接对象
			con.Open();//打开连接
			SqlCommand cmd=new SqlCommand(sqlstr,con);//创建command对象
			cmd.Connection=con;//通过con连接对象操作数据库
			cmd.CommandType=CommandType.Text;//设置命令类型
			cmd.CommandText=sqlstr;//设置要执行的命令
			SqlDataReader dr=cmd.ExecuteReader();//执行SELECT命令得到男生数据集
			
			while(dr.Read())//循环读取数据集中的每一条记录的数据
			{
				strRow=dr.GetString(0);//读取stu_id列的值
				strRow=strRow+" : "+dr.GetString(1)+"  ";//加：
				strRow=strRow+dr.GetString(2)+"  ";//姓名
				strRow=strRow+Convert.ToString(dr.GetInt32(3))+"  ";//年龄
				strRow=strRow+dr.GetString(4)+"  ";//班级//strRow=strRow+dr.GetString(5)+" ";
				this.listBox1.Items.Add(strRow);//把当前行的数据连接到ListBox控件中
			}
			dr.Close();//关闭顺序数据集
			con.Close();//关闭连接
		}

	}
}
