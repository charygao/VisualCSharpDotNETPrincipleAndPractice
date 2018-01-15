using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace WindowsControlLibrary
{
	/// <summary>
	/// EllipseButton 的摘要说明。
	/// </summary>
	public class EllipseButton :    Button //System.Windows.Forms.Control
	{
		private Color startColor=Color.White; //渐变起始色 
        private Color endColor = Color.Red;   //渐变终止色 
[Description("设定渐变的起始色"),Category("Appearance")] 
		public Color StartColor 
		{ 
			get 
			{ 
				return startColor; 
			} 
			set 
			{
				startColor=value; 
				RePaint();
			} 
		}
[Description("设定渐变的终止色"),Category("Appearance")] 
		public Color EndColor 
		{ 
			get 
			{ 
				return endColor; 
			} 
			set 
			{ 
				endColor=value; 
				RePaint();
			} 
		} 
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EllipseButton()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitComponent 调用后添加任何初始化
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region 组件设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // EllipseButton
            // 
            this.Size = new System.Drawing.Size(100, 100);
            this.TextChanged += new System.EventHandler(this.EllipseButton_TextChanged);//************按钮上的字
            this.Resize += new System.EventHandler(this.EllipseButton_Resize);
            this.ResumeLayout(false);

		}
		#endregion
		protected override void OnPaint(PaintEventArgs pe)//重载事件
		{
			base.OnPaint(pe);// 调用基类 OnPaint// TODO: 在此添加自定义绘画代码
			Graphics g=pe.Graphics;
g.Clear(this.BackColor);
Rectangle rect=new Rectangle(0,0,this.Width,this.Height);//从左上到右下的渐变
LinearGradientBrush myBrush = new LinearGradientBrush(rect,startColor,endColor,LinearGradientMode.ForwardDiagonal);
g.FillEllipse(myBrush,rect);
myBrush.Dispose();
	StringFormat format=new StringFormat(); 
	format.LineAlignment=StringAlignment.Center; 
format.Alignment=StringAlignment.Center; 
g.DrawString(this.Text,this.Font,new SolidBrush(this.ForeColor),rect,format);//************按钮上的字
		}
		private void EllipseButton_Resize(object sender, System.EventArgs e)
		{
			RePaint();
		}
		private void EllipseButton_TextChanged(object sender, System.EventArgs e)
		{
			RePaint();
		}
		private void RePaint()
		{
			Rectangle rect=new Rectangle(0,0,this.Width,this.Height);
			OnPaint(new PaintEventArgs(this.CreateGraphics(),rect));
		}
	}
}
