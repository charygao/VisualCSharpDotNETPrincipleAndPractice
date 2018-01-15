using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace aa
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Button[] BT_NUM; 
		private Button[] Operator;
		string sOper;	bool bDot, bEqu;
		double dblAcc, dblDes, dblResult;


		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
	
			BT_NUM=new Button[10] ; 
			Operator=new Button[6];

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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBox1.Location = new System.Drawing.Point(16, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(192, 26);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(232, 278);
			this.Controls.Add(this.textBox1);
			this.Name = "Form1";
			this.Text = "计算器";
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
			int  i;
			for( i = 0;i<=9;i++)
			{
				BT_NUM[i] = new Button();
				this.Controls.Add(BT_NUM[i]);
				BT_NUM[i].Left = 10 + 50 * (i%3);
				BT_NUM[i].Top = 50 * (int)(i/3) + 70;
				BT_NUM[i].Width = 40;
				BT_NUM[i].Height = 40;
				BT_NUM[i].Name = "BT_NUM" +i.ToString();
				BT_NUM[i].Text = i.ToString();
				BT_NUM[i].Click+=new System.EventHandler(bt_Click);
			}
			for( i = 0;i<=5;i++)
			{
				Operator[i] = new Button();
				this.Controls.Add(Operator[i]);
				Operator[i].Left = 10 + 50 * 3;
				Operator[i].Top = 50 * i + 70;
				Operator[i].Width = 40;
				Operator[i].Height = 40;
				Operator[i].Click+=new System.EventHandler(bt_Click);
				//AddHandler( CType(Operator[i], Button).Click, AddressOf bt_Click);
			}
			Operator[0].Text = "+";
			Operator[1].Text = "-";
			Operator[2].Text = "*";
			Operator[3].Text = "/";
			Operator[4].Text = "=";
			Operator[5].Text = "CE";
			Operator[4].Left = 10 + 50 * 2;
			Operator[4].Top = 50 * 3 + 70;
			Operator[5].Left = 10 + 50 * 1;
			Operator[5].Top = 50 * 3 + 70;
		}
		private void bt_Click(object sender, System.EventArgs e)
			//这里处理公共事件
		{
			String sText; 
			Button  bClick=(Button)sender;//将被点击的按钮赋给定义的bClick变量
			sText = bClick.Text;//获取按钮的文字
			switch( sText)//通过按钮文字属性来判断是哪个Button被点击，并执行相应的操作					
			{
				case  "1":
				case  "2":
				case  "3":
				case  "4":
				case  "5":
				case  "6":
				case  "7":
				case  "8":
				case  "9":
				case  "0":	//输入为数字
					if( bEqu)	textBox1.Text = "";
					//如果已经执行过一次计算，那么再次输入数字时，应清空textBox1
					bEqu = false;
					textBox1.Text = textBox1.Text + sText; //  将输入的字符累加
					break;
				case "+":
				case "-":
				case "*":
				case "/":	dblAcc = Convert.ToDouble(textBox1.Text);
					textBox1.Text = "";
					sOper = sText;// 记下被操作数及操作符
					break;
				case "=":
					bDot = false;
					if(!bEqu) dblDes = Convert.ToDouble(textBox1.Text);
					//如果本次对“=”的点击是连续的第二次点击，那么操作数不变
					bEqu = true;
				switch( sOper)//根据操作符的不同执行相应的计算
				{
					case "+": dblResult = dblAcc + dblDes;break;//执行加法操作
					case "-": dblResult = dblAcc - dblDes;break;//执行减法操作
					case "*": dblResult = dblAcc * dblDes;break;//执行乘法操作
					case "/": dblResult = dblAcc / dblDes;break;//执行乘法操作
				}			
					textBox1.Text = dblResult.ToString();
					dblAcc = dblResult;
					//将计算结果赋给被操作数，以便执行连续的第二次操作
					break;
				case "CE":	
					textBox1.Text = "";//清除文本框内容
					break;
//				case ".":
//					textBox1.Text = textBox1.Text+".";
//					break;
                    

			}
		}

	}
}
