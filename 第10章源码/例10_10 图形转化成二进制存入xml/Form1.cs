using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace 图形转化成二进制存入xml
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3; 
		private string MyFile = "";    //文件名
		private string MyFileExt = "";//扩展名
		

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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(296, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "浏览选择图片…";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(16, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 224);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(296, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "将图像保存成XML";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(296, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 32);
            this.button3.TabIndex = 3;
            this.button3.Text = "从XML中得到图像";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(424, 266);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "图像和XML格式文件互换例子";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
		public System.Drawing.Imaging.ImageFormat GetImageType(string str) //扩展名得到文件类型
		{ 
			if (str.ToLower() == "jpg") 
			{ 
				return System.Drawing.Imaging.ImageFormat.Jpeg; 
			} 
			else if (str.ToLower() == "gif") 
			{ 
				return System.Drawing.Imaging.ImageFormat.Gif; 
			} 
			else if (str.ToLower() == "tiff") 
			{ 
				return System.Drawing.Imaging.ImageFormat.Tiff; 
			} 
			else if (str.ToLower() == "icon") 
			{ 
				return System.Drawing.Imaging.ImageFormat.Icon; 
			} 
			else if (str.ToLower() == "png") //image/
            { 
				return System.Drawing.Imaging.ImageFormat.Png; 
			} 
			else 
			{ 
				return System.Drawing.Imaging.ImageFormat.MemoryBmp; 
			} 
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog(); 
			openFileDialog1.InitialDirectory = "."; 
			openFileDialog1.Filter = 
                 "PNG(*.png)|*.png|Gif(*.gif)|*.gif|Jpg(*.jpg)|*.jpg|所有图象文件(*.*)|*.*"; 
			openFileDialog1.FilterIndex = 2; 
			openFileDialog1.RestoreDirectory = true; 
			if (openFileDialog1.ShowDialog() == DialogResult.OK) 
			{ 
				MyFile = openFileDialog1.FileName; 
				MyFileExt = MyFile.Substring(MyFile.LastIndexOf(".") + 1); //扩展名

			    pictureBox1.Image = Image.FromFile(MyFile);

            } 
		}
		
		//把图像byte读出，base64编码写入xml相应字段就可以了。
		private void button2_Click(object sender, System.EventArgs e)//图形转化成二进制存入xml
		{
			if (MyFile == "") 
			{ 
				MessageBox.Show("请选择一个图片！", "错误",
					MessageBoxButtons.OK, MessageBoxIcon.Warning); 
				return; 
			} 
			System.Drawing.Image MyImg =System.Drawing.Image.FromFile(MyFile); 
			System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(); 
			MyImg.Save(memoryStream, GetImageType(MyFileExt)); //将图像以指定格式保存到流中
			byte[] b; 
			b = memoryStream.GetBuffer(); 
			string pic = Convert.ToBase64String(b); 
			memoryStream.Close(); 
			System.Xml.XmlDocument MyXml = new System.Xml.XmlDocument(); 
			//字符串形式加载XML
			MyXml.LoadXml("<pic><name>"+MyFile+"</name><photo>" + pic + "</photo></pic>"); 
			MyXml.Save("MyPhoto.xml");
			MessageBox.Show("文件被保存到了：" + "MyPhoto.xml"); 
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			string pic; 
			System.Xml.XmlDocument MyXml = new System.Xml.XmlDocument(); 
			MyXml.Load("MyPhoto.xml"); 
			System.Xml.XmlNode picNode; 
			picNode = MyXml.SelectSingleNode("/pic/photo"); 
			pic = picNode.InnerText; 
			System.IO.MemoryStream memoryStream; 
			memoryStream = new System.IO.MemoryStream(Convert.FromBase64String(pic));
			try
			{
				this.pictureBox1.Image = new System.Drawing.Bitmap(memoryStream); 
				memoryStream.Close(); 
			}
			catch(Exception e2)
            {
				MessageBox.Show(e2.Message,"异常"); 
			}
			MessageBox.Show("显示成功"); 
		}
	}
}
