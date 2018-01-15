using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace C_11_1
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		public Point StartPt,EndPt;//存放起始点的坐标
		public Graphics g;//存放Graphics对象
		public Pen MyPen;//存放画笔对象
		public SolidBrush MyBrush;//存放画刷对象
		public bool DrawShould=false;//是否画轮廓

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

		#region Windows Form Designer generated code
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(216, 118);
			this.Name = "Form1";
			this.Text = "可擦写图形轮廓";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);

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
			g=this.CreateGraphics();//建立Graphics对象
			MyPen=new Pen(Color.Black ,1);//建立画笔对象
			MyBrush=new SolidBrush(Color.Blue);//建立画刷对象
		}

		private void Form1_MouseDown(object sender,MouseEventArgs e)
		{
			this.Capture =true;//捕获鼠标
			DrawShould=true;//启动绘图
			StartPt.X=e.X ;//起始点
			StartPt.Y=e.Y ;
			EndPt=StartPt;//终止点
		}

		private void Form1_MouseMove(object sender,MouseEventArgs e)
		{
				if (DrawShould==true)//如果启动了绘图
				{ MyPen.Color=this.BackColor ;//设置画笔的颜色为背景色
					//清除前面绘制的图形
				  g.DrawEllipse (MyPen,StartPt.X ,StartPt.Y,EndPt.X-StartPt.X ,EndPt.Y-StartPt.Y  );
				  MyPen.Color=Color.Black ;  //设置画笔的颜色为黑色 
					MyPen.DashStyle=DashStyle.Dash;//设置虚线样式
					//绘制轮廓
				  g.DrawEllipse (MyPen,StartPt.X ,StartPt.Y ,e.X-StartPt.X ,e.Y-StartPt.Y  ) ;
				  EndPt.X =e.X ;//把当前点设置为终点
				  EndPt.Y=e.Y;
			   }
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			DrawShould=false;//停止画图
			MyPen.Color=this.BackColor ;//设置图笔颜色为背景色
			//清除先前的轮廓
			g.DrawEllipse (MyPen,StartPt.X ,StartPt.Y,EndPt.X-StartPt.X ,EndPt.Y-StartPt.Y  );
			//绘制以蓝色填充的椭圆
			g.FillEllipse(MyBrush,StartPt.X ,StartPt.Y ,e.X-StartPt.X ,e.Y-StartPt.Y);
			this.Capture =false;//结束鼠标捕获
			
		}
	}
}
