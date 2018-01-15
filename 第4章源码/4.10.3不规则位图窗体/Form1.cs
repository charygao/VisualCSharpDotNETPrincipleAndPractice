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
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Point mouseOffset; //记录鼠标指针的坐标
		private bool isMouseDown = false;//记录鼠标按键是否按下
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem 关闭;
		private System.Windows.Forms.MenuItem 更换背景;
		private System.Windows.Forms.PictureBox pictureBox1; 

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.关闭 = new System.Windows.Forms.MenuItem();
            this.更换背景 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.关闭,
            this.更换背景});
            // 
            // 关闭
            // 
            this.关闭.Index = 0;
            this.关闭.Text = "关闭";
            this.关闭.Click += new System.EventHandler(this.关闭_Click);
            // 
            // 更换背景
            // 
            this.更换背景.Index = 1;
            this.更换背景.Text = "更换背景";
            this.更换背景.Click += new System.EventHandler(this.更换背景_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(126, 144);
            this.ContextMenu = this.contextMenu1;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "不规则窗体";
            this.TransparencyKey = System.Drawing.Color.Blue;
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
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

		private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int xOffset;
			int yOffset;
			if (e.Button == MouseButtons.Left)
			{
				xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
				yOffset = -e.Y - SystemInformation.CaptionHeight -
					SystemInformation.FrameBorderSize.Height;
				mouseOffset = new Point(xOffset, yOffset);
				isMouseDown = true;
			}
		
		}

		private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// 修改鼠标状态isMouseDown的值
			// 确保只有鼠标左键按下并移动时，才移动窗体
			if (e.Button == MouseButtons.Left) 
			{
				isMouseDown = false;
			}		
		}
		private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (isMouseDown)
			{
				Point mousePos = Control.MousePosition;
				mousePos.Offset(mouseOffset.X, mouseOffset.Y);
				Location = mousePos;
			}
		}

		private void 关闭_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void 更换背景_Click(object sender, System.EventArgs e)
		{
            Image m_bitmap = Image.FromFile(@"巴布豆.bmp");
			this.BackgroundImage= m_bitmap;
		}
	}
}
