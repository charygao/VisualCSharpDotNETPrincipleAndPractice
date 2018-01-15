using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace 绘制棋盘
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox1;
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(304, 264);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "绘制象棋棋盘";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(24, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(248, 296);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(424, 342);
			this.Controls.Add(this.pictureBox1);
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
		private void DrawBoard()
		{
    		int  i, r;
	    	//获取对将用于绘图的图形对象的引用创建图形图像。 
    	   Graphics g  = this.pictureBox1.CreateGraphics();
		   Pen myPen=new Pen(Color.Red);
		   myPen.Width = 1;
		  r = this.pictureBox1.ClientRectangle.Width / 18;
		  pictureBox1.Height = r * 20;
		  for( i = 0;i<=8;i++) //竖线
			{
				if( i == 0 || i ==8)					 
					myPen.Width = 2;
				else
					myPen.Width = 1;
				g.DrawLine(myPen, r + i * 2 * r, r, r + i * 2 * r, r * 2 * 10 - r + 1);
			}
			for( i = 0;i<=9;i++) //横线
			{
				if( i ==0 || i == 9)					 
					myPen.Width = 2;
				else
					myPen.Width = 1;
		        g.DrawLine(myPen, r, r + i * 2 * r, r * 2 * 9 - r, r + i * 2 * r);
		    }
		Rectangle rectangle =new System.Drawing.Rectangle(r + 1, r + r * 8 + 1, r * 9 * 2 - 2 * r - 2, 2 * r - 2);
		SolidBrush  brush1=new System.Drawing.SolidBrush(Color.Brown);
		g.DrawEllipse(System.Drawing.Pens.Black, rectangle);
		g.DrawRectangle(System.Drawing.Pens.Blue, rectangle);
		g.FillRectangle(brush1, rectangle);
		Font font1   = new System.Drawing.Font("Arial", 18);
		SolidBrush  brush2=  new System.Drawing.SolidBrush(Color.Yellow);
		g.DrawString("   汉界       楚河", font1, brush2, (r + 1), (r + r * 8 + 1));
		//画九宫斜线
		g.DrawLine(myPen, r + r * 6 + 1, r + 1, r + r * 6 + r * 4 - 1, r + r * 4 - 1);
		g.DrawLine(myPen, r + r * 6 + 1, r + r * 4 - 1, r + r * 6 + r * 4 - 1, r + 1);
		g.DrawLine(myPen, r + r * 6 + 1, r * 14 + r + 1, r + r * 6 + r * 4 - 1, r * 14 + r + r * 4 - 1);
		g.DrawLine(myPen, r + r * 6 + 1, r * 14 + r + r * 4 - 1, r + r * 6 + r * 4 - 1, r * 14 + r + 1);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
		    DrawBoard();
		}
	}
}
