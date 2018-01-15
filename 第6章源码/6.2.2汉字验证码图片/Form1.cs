using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text; //add
using System.Drawing;  
namespace 汉字验证码图片
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
			this.button1.Location = new System.Drawing.Point(72, 152);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "汉字验证码";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(72, 56);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(152, 40);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 266);
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

		private void button1_Click(object sender, System.EventArgs e)
		{
//获取GB2312编码页（表） 
Encoding gb=Encoding.GetEncoding("gb2312"); 
//调用函数产生4个随机中文汉字编码 
object[] bytes=CreateRegionCode(4);  
//根据汉字编码的字节数组解码出中文汉字 
			string str1=gb.GetString((byte[])Convert.ChangeType(bytes[0], typeof(byte[]))); 
			string str2=gb.GetString((byte[])Convert.ChangeType(bytes[1], typeof(byte[]))); 
			string str3=gb.GetString((byte[])Convert.ChangeType(bytes[2], typeof(byte[]))); 
			string str4=gb.GetString((byte[])Convert.ChangeType(bytes[3], typeof(byte[]))); 
string s=str1 + str2 +str3 +str4;//输出
//			Graphics g  = this.pictureBox1.CreateGraphics();
//			Font font1   = new System.Drawing.Font("Arial", 18);
//			SolidBrush  brush2=  new System.Drawing.SolidBrush(Color.Red );
//			g.Clear(pictureBox1.BackColor); 
//			g.DrawString(s, font1, brush2,1,1);
//pictureBox1.Image.Save("aa.bmp"); 
//pictureBox1.Height =200;
			Bitmap memBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			Graphics g = Graphics.FromImage(memBitmap);
			SolidBrush brush = new System.Drawing.SolidBrush(Color.Red);
Font drawFont = new Font("Arial", 18);
g.DrawString(s, drawFont, brush, 0, 0);
pictureBox1.Image = memBitmap ;//	贴图  
pictureBox1.Image.Save(s+".bmp"); 
　　    } 
/* 此CreateRegionCode函数在汉字编码范围内随机创建含两个元素的十六进制字节数组，每个字节数组代表一个汉字，并将四个字节数组存储在object数组中。 
参数：strlength，代表需要产生的汉字个数*/ 
		public static object[] CreateRegionCode(int strlength) 
		{ 
//定义一个字符串数组储存汉字编码的组成元素 
			string[] rBase=new String [16]{"0","1","2","3","4","5","6","7","8","9","a","b","c","d","e","f"}; 
Random rnd=new Random(); 
//定义一个object数组用来 
			object[] bytes=new object[strlength]; 
/*每循环一次产生一个含两个元素的十六进制字节数组，并将其放入bject数组中每个汉字有四个区位码组成  区位码第1位和区位码第2位作为字节数组第一个元素 
 区位码第3位和区位码第4位作为字节数组第二个元素*/ 
			for(int i=0;i<strlength;i++) 
			{ 
//区位码第1位 
int r1=rnd.Next(11,14); 
				string str_r1=rBase[r1].Trim(); 
//区位码第2位 
rnd=new Random(r1*unchecked((int)DateTime.Now.Ticks)+i);//更换随机数发生器的种子避免产生重复值 
int r2; 
				if (r1==13) 
				{ 
r2=rnd.Next(0,7); 
				} 
				else 
				{ 
r2=rnd.Next(0,16); 
				} 
				string str_r2=rBase[r2].Trim(); 
//区位码第3位 
rnd=new Random(r2*unchecked((int)DateTime.Now.Ticks)+i); 
int r3=rnd.Next(10,16); 
				string str_r3=rBase[r3].Trim(); 
//区位码第4位 
rnd=new Random(r3*unchecked((int)DateTime.Now.Ticks)+i); 
int r4; 
				if (r3==10) 
				{ 
r4=rnd.Next(1,16); 
				} 
				else if (r3==15) 
				{ 
r4=rnd.Next(0,15); 
				} 
				else 
				{ 
r4=rnd.Next(0,16); 
				} 
				string str_r4=rBase[r4].Trim(); 
//定义两个字节变量存储产生的随机汉字区位码 
				byte byte1=Convert.ToByte(str_r1 + str_r2,16); 
				byte byte2=Convert.ToByte(str_r3 + str_r4,16); 
//将两个字节变量存储在字节数组中 
				byte[] str_r=new byte[]{byte1,byte2};  
//将产生的一个汉字的字节数组放入object数组中 
				bytes.SetValue(str_r,i);                  
			} 
 			return bytes; 	 
		}
	}
}
