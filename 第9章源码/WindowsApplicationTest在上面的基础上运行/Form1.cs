using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
//先运行CityEduWebService不支持长路径，选中StringReverse.asmx，复制浏览器中的URL地址到localhostStringReverse的URL属性
namespace WindowsApplicationTest
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form_test : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button_do;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_Origin;
		private System.Windows.Forms.Label label_New;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form_test()
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
            this.textBox_Origin = new System.Windows.Forms.TextBox();
            this.button_do = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_New = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Origin
            // 
            this.textBox_Origin.Location = new System.Drawing.Point(48, 32);
            this.textBox_Origin.Name = "textBox_Origin";
            this.textBox_Origin.Size = new System.Drawing.Size(100, 21);
            this.textBox_Origin.TabIndex = 0;
            // 
            // button_do
            // 
            this.button_do.Location = new System.Drawing.Point(176, 32);
            this.button_do.Name = "button_do";
            this.button_do.Size = new System.Drawing.Size(75, 23);
            this.button_do.TabIndex = 1;
            this.button_do.Text = "字符串反转";
            this.button_do.Click += new System.EventHandler(this.button_do_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(48, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "反转的字符串";
            // 
            // label_New
            // 
            this.label_New.Location = new System.Drawing.Point(176, 80);
            this.label_New.Name = "label_New";
            this.label_New.Size = new System.Drawing.Size(100, 23);
            this.label_New.TabIndex = 3;
            // 
            // Form_test
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.label_New);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_do);
            this.Controls.Add(this.textBox_Origin);
            this.Name = "Form_test";
            this.Text = "字符串反转";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form_test());
		}

		private void button_do_Click(object sender, System.EventArgs e)
		{
			localhostStringReverse.StringReverse sr=new WindowsApplicationTest.localhostStringReverse.StringReverse();
			label_New.Text=sr.WebMethod_StringReverse(textBox_Origin.Text);
		}
	}
}
