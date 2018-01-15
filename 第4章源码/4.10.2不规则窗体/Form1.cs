using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace 不规则窗体
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
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
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(88, 64);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "椭圆形";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(88, 128);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 32);
			this.button2.TabIndex = 1;
			this.button2.Text = "扇形";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(88, 184);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 32);
			this.button3.TabIndex = 2;
			this.button3.Text = "环形";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(280, 270);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
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

		private void button1_Click(object sender, System.EventArgs e)
		{
              System.Drawing.Drawing2D.GraphicsPath p= new System.Drawing.Drawing2D.GraphicsPath ( ) ;
　            int   Width = this.ClientSize.Width;
　            int   Height = this.ClientSize.Height;
　            //根据要绘制椭圆的形状来填写AddEllipse方法中椭圆对应的相应参数
			  p.AddEllipse ( 0 , 0 , Width - 50 , Height - 100 ); 　           
　            Region = new Region ( p ); 
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			System.Drawing.Drawing2D.GraphicsPath p= new System.Drawing.Drawing2D.GraphicsPath ( ) ;
            //根据要实现的扇形形状来填写AddPie方法中的相应参数
			p.AddPie ( 10 , 10 , 250 , 250 , 5 , 150 );            
            Region = new Region ( p ); 
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
              System.Drawing.Drawing2D.GraphicsPath p= new System.Drawing.Drawing2D.GraphicsPath ( ) ;
　            int   width = 100;
　            int   Height =this.ClientSize.Height; 
			  //根据环形的形状来分别填写AddEllipse方法中相应的参数　
			  p.AddEllipse ( 0 , 0 , Height , Height ) ;
　            p.AddEllipse ( width , width , Height - ( width * 2 ) , Height - ( width * 2 ) ) ;　            
　            Region = new Region ( p ); 
		}

	}
}
