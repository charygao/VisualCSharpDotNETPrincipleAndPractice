using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WindowsApplication1
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private string file_name="";//添加窗体变量

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
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(56, 224);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "显示";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(208, 224);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 32);
			this.button2.TabIndex = 0;
			this.button2.Text = "保存";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(392, 278);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button2);
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

		private void button1_Click(object sender, System.EventArgs e)//显示
		{
			OpenFileDialog file=new OpenFileDialog();
			file.Filter="jpg|*.jpg|bmp|*.bmp|*|*.*";//“文本文件(*.txt)|*.txt|所有文件(*.*)|*.*”
            //file.FilterIndex = 1;
			if(file.ShowDialog()==DialogResult.OK)
			{ 
				file_name=file.FileName;
				Bitmap bitmap = new Bitmap(file_name);
				Graphics g = this.CreateGraphics();
				//原图大小显示
				g.DrawImage(bitmap,0,0,bitmap.Width, bitmap.Height);
	            //缩半显示
				g.DrawImage(bitmap,200,0,bitmap.Width/2, bitmap.Height/2);
               // //***********************************************************
               // //构造一个指定区域大小的空图像
               // Bitmap image2=new Bitmap(bitmap.Width/2,bitmap.Height/2);
               // //根据指定区域得到Graphics对象
               // Graphics g2=Graphics.FromImage(image2);
               // //设置图像的背景色
               // g2.Clear(this.BackColor);
               // Rectangle dest=new Rectangle(0,0,bitmap.Width/2, bitmap.Height/2);
               // Rectangle scr=new Rectangle(0,0,bitmap.Width, bitmap.Height);
               // g2.DrawImage(bitmap,dest,scr,GraphicsUnit.Pixel );
               // //保存画到image2对象中的图形
               // image2.Save(@"c:\tu1.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
               ////********************************	



				bitmap.Dispose();//释放占用的资源				
				g.Dispose();
                //image2.Dispose();//释放占用的资源				
                //g2.Dispose();
			

			}
		}

		private void button2_Click(object sender, System.EventArgs e)//保存
		{
			//构造一个指定区域的空图像
			Bitmap image=new Bitmap(this.Width,this.Height);
			//根据指定区域得到Graphics对象
			Graphics g=Graphics.FromImage(image);
			//将图形画到Graphics对象中
			//设置图像的背景色
            g.Clear(this.BackColor);//Color.Black);//清除整个绘图面并以指定背景色填充。
			if(file_name=="")
			{
				MessageBox.Show("未显示图像文件");
				return;
			}
			//Bitmap bitmap = new Bitmap(file_name);
			//原图大小
			//g.DrawImage(bitmap,0,0,bitmap.Width, bitmap.Height);
			//缩半
			//g.DrawImage(bitmap,200,0,bitmap.Width/2, bitmap.Height/2);
			try
			{
				//保存画到Graphics对象中的图形
				image.Save(@"c:\tu1.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
				MessageBox.Show("保存成功！","恭喜");
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
			image.Dispose();
			g.Dispose();		
		}

	}
}
