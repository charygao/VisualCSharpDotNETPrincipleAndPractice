using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging; //add
namespace 分解和合成Gif图像
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ComboBox comboBox1;
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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(40, 120);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "分解gif文件";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(168, 120);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(104, 32);
			this.button2.TabIndex = 1;
			this.button2.Text = "合成gif文件";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(168, 24);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(104, 32);
			this.button3.TabIndex = 2;
			this.button3.Text = "文件格式转换";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.Items.AddRange(new object[] {
														   "*.bmp",
														   "*.jpg",
														   "*.tif",
														   "*.gif"});
			this.comboBox1.Location = new System.Drawing.Point(48, 32);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(96, 20);
			this.comboBox1.TabIndex = 3;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 174);
			this.Controls.Add(this.comboBox1);
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
			Image imgGif = Image.FromFile(@"c:\test.gif");
			//system.drawing.imaging.framedimension .NET Framework 类库. FrameDimension 类. 提供获取图像的框架维度的属性。不可继承。  
            //从imgGif 创建FrameDimension对象
			FrameDimension ImgFrmDim = new FrameDimension( imgGif.FrameDimensionsList[0] );
			//获得gif动画桢的数量
			int nFrameCount = imgGif.GetFrameCount( ImgFrmDim );
			//以Jpeg 格式保存每一桢
			for( int i = 0; i < nFrameCount; i++ )
			{
				//选中一桢
				imgGif.SelectActiveFrame( ImgFrmDim, i );
				imgGif.Save( string.Format( @"c:\Frame{0}.jpg", i ), ImageFormat.Jpeg );
			} 
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
		
		}
        //using System.Drawing.Imaging; //add
		private void button3_Click(object sender, System.EventArgs e)//文件格式转换
		{
			OpenFileDialog file=new OpenFileDialog();
			file.Filter=".jpg和.bmp文件|*.jpg;*.bmp文件|所有文件(*.*)|*.*";
			//"文本文件(*.txt)|*.txt|所有文件(*.*)|*.*"
			if(file.ShowDialog()==DialogResult.OK)
			{ 
				Image m_bitmap = Image.FromFile(@"c:\test.gif");
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "图像另存为";
				sfd.OverwritePrompt = true;
				sfd.CheckPathExists = true;
				sfd.Filter = comboBox1.Text + "|" + comboBox1.Text;
				sfd.ShowHelp = true;
				if(sfd.ShowDialog() == DialogResult.OK)
				{
					string strFileName = sfd.FileName;
					switch(comboBox1.Text)
					{
						case "*.bmp":
							m_bitmap.Save(strFileName, ImageFormat.Bmp);
							break;
						case "*.jpg":
							m_bitmap.Save(strFileName, ImageFormat.Jpeg);
							break;
						case "*.gif":
							m_bitmap.Save(strFileName, ImageFormat.Gif);
							break;
						case "*.tif":
							m_bitmap.Save(strFileName, ImageFormat.Tiff);
							break;
					}
					MessageBox.Show("图象文件格式转换成功！", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}
	}
}
