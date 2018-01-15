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
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.HScrollBar HsbR;
		private System.Windows.Forms.HScrollBar HsbG;
		private System.Windows.Forms.HScrollBar HsbB;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label Lblcolor;
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
            this.HsbR = new System.Windows.Forms.HScrollBar();
            this.HsbG = new System.Windows.Forms.HScrollBar();
            this.HsbB = new System.Windows.Forms.HScrollBar();
            this.Lblcolor = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(10, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(272, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "通过滚动条设置文本框的背景色和字体颜色";
            // 
            // HsbR
            // 
            this.HsbR.Location = new System.Drawing.Point(32, 72);
            this.HsbR.Maximum = 255;
            this.HsbR.Name = "HsbR";
            this.HsbR.Size = new System.Drawing.Size(192, 24);
            this.HsbR.TabIndex = 1;
            this.HsbR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HsbR_Scroll);
            // 
            // HsbG
            // 
            this.HsbG.Location = new System.Drawing.Point(32, 120);
            this.HsbG.Maximum = 255;
            this.HsbG.Name = "HsbG";
            this.HsbG.Size = new System.Drawing.Size(192, 24);
            this.HsbG.TabIndex = 2;
            this.HsbG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HsbG_Scroll);
            // 
            // HsbB
            // 
            this.HsbB.Location = new System.Drawing.Point(32, 168);
            this.HsbB.Maximum = 255;
            this.HsbB.Name = "HsbB";
            this.HsbB.Size = new System.Drawing.Size(192, 24);
            this.HsbB.TabIndex = 3;
            this.HsbB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HsbB_Scroll);
            // 
            // Lblcolor
            // 
            this.Lblcolor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Lblcolor.Location = new System.Drawing.Point(240, 112);
            this.Lblcolor.Name = "Lblcolor";
            this.Lblcolor.Size = new System.Drawing.Size(40, 32);
            this.Lblcolor.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "设置背景色";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(144, 216);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 32);
            this.button2.TabIndex = 6;
            this.button2.Text = "设置字体颜色";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Lblcolor);
            this.Controls.Add(this.HsbB);
            this.Controls.Add(this.HsbG);
            this.Controls.Add(this.HsbR);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "利用滚动条控件调配颜色";
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
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
		  textBox1.BackColor = Lblcolor.BackColor;// 将textBox1的背景设置为预设的颜色
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			textBox1.ForeColor  = Lblcolor.BackColor;// 将textBox1的字体设置为预设的颜色
		}

		private void HsbB_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
		   Lblcolor.BackColor = Color.FromArgb(HsbR.Value, HsbG.Value, HsbB.Value);
		}

		private void HsbG_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{ 
			Lblcolor.BackColor = Color.FromArgb(HsbR.Value, HsbG.Value, HsbB.Value);	
		}

		private void HsbR_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
	    	Lblcolor.BackColor = Color.FromArgb(HsbR.Value, HsbG.Value, HsbB.Value);
		}
	}
}
