using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace 复选框
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox1;
		private string [] ti_mu=new string[4] ;	// 存放题目
		private string [,] Item=new string[4,5]; //存放A、B、C、D四个选择项	
		private string [] Answer=new string[4]; //存放题目答案如“AC”
		private int s;                  	// 题号

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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "判断对错";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(168, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 32);
            this.button2.TabIndex = 6;
            this.button2.Text = "下一题";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 224);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // checkBox4
            // 
            this.checkBox4.Location = new System.Drawing.Point(16, 183);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(216, 32);
            this.checkBox4.TabIndex = 8;
            this.checkBox4.Text = "checkBox4";
            // 
            // checkBox3
            // 
            this.checkBox3.Location = new System.Drawing.Point(16, 138);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(216, 32);
            this.checkBox3.TabIndex = 7;
            this.checkBox3.Text = "checkBox3";
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(16, 85);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(216, 40);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "checkBox2";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(16, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(216, 32);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "checkBox1";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(320, 294);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "多项选择";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
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
            Application.Run(new Form2());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			string d="";
			if(checkBox1.Checked) d=d+"A";
			if(checkBox2.Checked) d=d+"B";
			if(checkBox3.Checked) d=d+"C";
			if(checkBox4.Checked) d=d+"D";				
			if(d==Answer[s])
				MessageBox.Show("恭喜，你选对了！");
			else
				MessageBox.Show("选择错误！");

		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			s = s + 1;
			//取消选中状态
			if(checkBox1.Checked) checkBox1.Checked=false;
			if(checkBox2.Checked) checkBox2.Checked=false;
			if(checkBox3.Checked) checkBox3.Checked=false;
			if(checkBox4.Checked) checkBox4.Checked=false;	
			if( s > 3 )
				MessageBox.Show("恭喜你，题目已经作完！");
			else
				chu_ti();	

		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			ti_mu[1] = "下列关于构造函数的描述中，正确的是（   ）";
			ti_mu[2] = " C#的合法注释是（    ）";
			ti_mu[3] = "窗体Form1的Text属性为frm，则其Load事件名为（）";
			Item[1, 1] = "A. 构造函数可以设置默认参数";
			Item[1, 2] = "B. 构造函数可以有多个参数 ";
			Item[1, 3] = "C. 构造函数可以是显示调用";
			Item[1, 4] = "D. 构造函数不可以重载";
			Item[2, 1] = "A. /*This is a C program/*";
			Item[2, 2] = "B. // This is a C program ";
			Item[2, 3] = "C. /This is a C program/";
			Item[2, 4] = "D. /*This is a C program*/";
			Item[3, 1] = "A. Form_Load";		Item[3, 2] = "B. Form1_Load";
			Item[3, 3] = "C. Frm_Load";		Item[3, 4] = "D. Me_Load";
			Answer[1] = "AB";
			Answer[2] = "BD";
			Answer[3] = "A";
			s = 1;
			chu_ti();	

		}
		private void chu_ti()
		{
			label1.Text  = ti_mu[s];
			checkBox1.Text = Item[s, 1];
			checkBox2.Text = Item[s, 2];
			checkBox3.Text = Item[s, 3];
			checkBox4.Text = Item[s, 4];
		}

	}
}
