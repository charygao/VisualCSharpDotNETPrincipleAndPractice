using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace 滚动条
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Timer timer2;
        private Button button1;
		private System.ComponentModel.IContainer components;

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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(368, 266);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "飘动窗体程序";
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
			Point p = new Point (0 ,240);
			this.DesktopLocation = p ; //设定窗体的左上角的二维位置。
            timer1.Enabled = true ;
            

		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			//窗体的左上角横坐标随着timer1不断加1 
			Point p = new Point ( this.DesktopLocation.X + 10 , this.DesktopLocation.Y ) ; 
			this.DesktopLocation = p ; 
			if(p.X == 550)//当窗体左上角位置的横坐标为550时，timer1停止timer2启动
			{
				timer1.Enabled = false ; 
				timer2.Enabled = true ; 
			}

		}

		private void timer2_Tick(object sender, System.EventArgs e)
		{
			//窗体的左上角横坐标随着timer2不断减1
			Point p = new Point ( this.DesktopLocation.X - 10 , this.DesktopLocation.Y ) ; 
			this.DesktopLocation = p ; 
			if(p.X == -150)//当窗体左上角位置的横坐标为-150时，timer2停止timer1启动
			{
				timer1.Enabled = true ; 
				timer2.Enabled = false ;
			}

		}
	}
}
