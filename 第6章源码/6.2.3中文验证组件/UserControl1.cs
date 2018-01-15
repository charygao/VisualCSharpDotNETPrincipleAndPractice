using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text; //add
namespace 中文验证组件
{
	/// <summary>
	/// UserControl1 的摘要说明。
	/// </summary>
	public class verifyControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private string chinese_char;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public verifyControl()
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(0, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(144, 64);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// verifyControl
			// 
			this.Controls.Add(this.pictureBox1);
			this.Name = "verifyControl";
			this.Size = new System.Drawing.Size(110, 50);
			this.Load += new System.EventHandler(this.verifyControl_Load);
			this.ResumeLayout(false);

		}
		#endregion
		[Description("验证码图形中对应汉字字符串"),Category("Appearance")] 
		public string ChineseChar
		{
			get{  return chinese_char ;}
            //set
            //{
            //    chinese_char = value;					    
            //}
		}
		public static object[] CreateRegionCode(int strlength) 
		{ 
//定义一个字符串数组储存汉字编码的组成元素 
			string[] rBase=new String [16]{"0","1","2","3","4","5","6","7","8","9","a","b","c","d","e","f"}; 
Random rnd=new Random(); 
object[] bytes=new object[strlength];//定义一个object数组用来 
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
string str_r4=rBase[r4].Trim();//定义两个字节变量存储产生的随机汉字区位码 
byte byte1=Convert.ToByte(str_r1 + str_r2,16); 
byte byte2=Convert.ToByte(str_r3 + str_r4,16);//将两个字节变量存储在字节数组中 
byte[] str_r=new byte[]{byte1,byte2};//将产生的一个汉字的字节数组放入object数组中 
bytes.SetValue(str_r,i);                  
			} 
			return bytes; 	 
		}
		private void create()////输出验证码图形并获取验证码汉字
		{
			Encoding gb=Encoding.GetEncoding("gb2312");//获取GB2312编码页（表） 
			object[] bytes=CreateRegionCode(4);//调用函数产生4个随机中文汉字编码 
//根据汉字编码的字节数组解码出中文汉字 
			string str1=gb.GetString((byte[])Convert.ChangeType(bytes[0], typeof(byte[]))); 
			string str2=gb.GetString((byte[])Convert.ChangeType(bytes[1], typeof(byte[]))); 
			string str3=gb.GetString((byte[])Convert.ChangeType(bytes[2], typeof(byte[]))); 
			string str4=gb.GetString((byte[])Convert.ChangeType(bytes[3], typeof(byte[]))); 
//验证码汉字 
　　        string s=str1 + str2 +str3 +str4;
			chinese_char=s;
//输出验证码图形
			Bitmap memBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			Graphics g = Graphics.FromImage(memBitmap);
			SolidBrush brush = new System.Drawing.SolidBrush(Color.Red);
			Font drawFont = new Font("Arial", 18);
			g.DrawString(s, drawFont, brush, 0, 0);
			pictureBox1.Image = memBitmap ;//贴图 
		}
		private void verifyControl_Load(object sender, System.EventArgs e)
		{
			create();//图片上单击产生新的验证码图片
			
		}
		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
            create();
		}

	}
}
