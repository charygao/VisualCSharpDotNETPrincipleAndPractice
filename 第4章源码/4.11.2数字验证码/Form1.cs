using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace 数字验证码
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        private  string str_ValidateCode;
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(136, 56);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(80, 16);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(88, 104);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 32);
			this.button1.TabIndex = 1;
			this.button1.Text = "验证";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(32, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(105, 22);
			this.label1.TabIndex = 2;
			this.label1.Text = "请输入验证码";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(32, 56);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(88, 21);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(256, 182);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form1";
			this.Text = "登陆";
			this.Load += new System.EventHandler(this.Form1_Load);
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
		//  生成随机数字字符串
public string GetRandomNumberString(int int_NumberLength)
{
string str_Number = string.Empty;
Random theRandomNumber = new Random();
for (int int_index = 0; int_index < int_NumberLength; int_index++)
str_Number += theRandomNumber.Next(10).ToString();
return str_Number;
}
		//生成随机颜色
public Color GetRandomColor()
{
Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
//  对于C#的随机数，没什么好说的
System.Threading.Thread.Sleep(RandomNum_First.Next(50));
Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);       
//  为了在白色背景上显示，尽量生成深色
int int_Red = RandomNum_First.Next(256);
int int_Green = RandomNum_Sencond.Next(256);
int int_Blue = (int_Red + int_Green > 400) ? 0 : 400 - int_Red - int_Green;
int_Blue = (int_Blue > 255) ? 255 : int_Blue;
return Color.FromArgb(int_Red, int_Green, int_Blue);
}
		//根据验证字符串生成最终图象
public void CreateImage(string str_ValidateCode)
{
int int_ImageWidth = str_ValidateCode.Length * 13;
Random newRandom = new Random();
//  图高20px
Bitmap theBitmap = new Bitmap(int_ImageWidth, 20);
Graphics theGraphics = Graphics.FromImage(theBitmap);
//  白色背景
theGraphics.Clear(Color.White);
//  灰色边框
theGraphics.DrawRectangle(new Pen(Color.LightGray, 1), 0, 0, int_ImageWidth - 1, 19);
//  10pt的字体
Font theFont = new Font("Arial", 10);
for (int int_index = 0; int_index < str_ValidateCode.Length; int_index++)
{            
string str_char = str_ValidateCode.Substring(int_index, 1);
Brush newBrush = new SolidBrush(GetRandomColor());
Point thePos = new Point(int_index * 13 + 1 + newRandom.Next(3), 1 + newRandom.Next(3));
theGraphics.DrawString(str_char, theFont, newBrush, thePos);
}
//  将生成的图片显示到图片框中
pictureBox1.Image=theBitmap;
}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			//  4位数字的验证码
			str_ValidateCode = GetRandomNumberString(4);
			CreateImage(str_ValidateCode);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
		   if(str_ValidateCode==textBox1.Text)
			   MessageBox.Show ("验证通过");
			else
			   MessageBox.Show ("验证失败,清在输入一次");

		}
	}
}
