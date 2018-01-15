using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
namespace 例3_2
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 32);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(224, 184);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "textBox1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(264, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 32);
			this.button1.TabIndex = 1;
			this.button1.Text = "保存";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(264, 80);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 32);
			this.button2.TabIndex = 2;
			this.button2.Text = "清空";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(264, 128);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 32);
			this.button3.TabIndex = 3;
			this.button3.Text = "打开";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(264, 184);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(96, 32);
			this.button4.TabIndex = 4;
			this.button4.Text = "退出";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(384, 246);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Name = "Form1";
			this.Text = "例3_1";
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

		private void button1_Click(object sender, System.EventArgs e)//保存文件
		{   //以打开和创建，只能写的方式创建文件流MyFile
			FileStream MyFile=new FileStream("C:\\EXAMPLE1.TXT"
				,FileMode.OpenOrCreate ,FileAccess.Write);
			byte a;char ch;
			int i; 
			for(i=0;i<textBox1.Text.Length ;i++)//遍历所有的字符
			{
					ch=textBox1.Text[i];//读取一个字符
				a=(byte)ch;//把该字符转换成字节型
				MyFile.WriteByte(a);//把该字节写到文件中去
			}
			MyFile.Flush();//刷新文件
			MyFile.Close();//关闭文件
		}
		private void button3_Click(object sender, System.EventArgs e)//打开显示文件
		{
				string MyText="",ch;//MyText存放要显示的文件内容,称之为结果字符串
			int a=0;
			//以打开，只读的方式创建文件流MyFile
			FileStream MyFile=new FileStream("C:\\EXAMPLE1.TXT"
				,FileMode.Open,FileAccess.Read );
			a=MyFile.ReadByte();//从文件中读取一个字节
			while(a!=-1)//如果不是文件的结尾
			{
					ch=((char)a).ToString();//把读取的字节转换为字符串型
				MyText=MyText+ch;//把该字符串连接到结果字符串的末尾
				a=MyFile.ReadByte();//再读一个字节
			}
			textBox1.Text =MyText;//把结果字符串在文本框中显示出来
			MyFile.Close();//关闭文件
		}
		private void button2_Click(object sender, System.EventArgs e) //清空按钮
		{
			textBox1.Clear();
		}
		private void button4_Click(object sender, System.EventArgs e)//退出
		{
			Application.Exit();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

	}
}
