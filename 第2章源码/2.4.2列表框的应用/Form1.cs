using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace 列表框的应用
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
        private IContainer components;
        private int ti_shu, right_shu, result;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label2;
        private ListBox listBox1;
        private TextBox textBox1;
        private Label label1;
        private TabPage tabPage2;
        private Button button1;
        private ComboBox comboBox1;
        private TabPage tabPage3;
        private Button button2;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label4;
        private Button button3;
        private TabPage tabPage4;
        private TextBox textBox4;
        private Button button4;
        private Timer timer1;
        private ListBox listBox2;
        private Button button5;
        private Button button6;
        private Label label3;
	 
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button6 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(201, 286);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(193, 260);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "算术练习";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // listBox1
            // 
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(16, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(160, 172);
            this.listBox1.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88, 21);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "textBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(193, 260);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "随机数技巧";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0-9",
            "a-z",
            "A-Z"});
            this.comboBox1.Location = new System.Drawing.Point(22, 47);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "0-9";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "label3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.textBox3);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(193, 260);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "随机字符串";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "字符串个数";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(24, 127);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox3.Size = new System.Drawing.Size(144, 106);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "得到的随机字符串";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(24, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "";
            this.textBox2.Text = "12";
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "ok";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(112, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "简洁";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button6);
            this.tabPage4.Controls.Add(this.listBox2);
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.textBox4);
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(193, 260);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "随机不同字符";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(5, 11);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "OK";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(70, 11);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(117, 76);
            this.textBox4.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(5, 64);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(58, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "22";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(5, 93);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(182, 160);
            this.listBox2.TabIndex = 3;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(7, 40);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(57, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "sort";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(206, 286);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
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
		private void chu_ti()
		{
			Random randobj=new Random();
			int  a=randobj.Next(10,100) ;
			int  b=randobj.Next(10,100) ;
			int  p =randobj.Next(0,2) ;
			if( p==0)// 出加法题
			{
				label1.Text  =a.ToString()+ " + " +b.ToString()+ " = ";
				result = a + b;
			}
			else    // 出减法题
			{
				if( a < b)
				{int  t = a; a = b; b = t;}
				label1.Text =a.ToString()+ " - " +b.ToString()+ " = ";
				result = a - b;
			}
			ti_shu = ti_shu + 1;// 出题数加1
			textBox1.Text = "";		//清空答题文本框
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		    ti_shu = 0;    // 出题数清零
            right_shu = 0; //答对题数清零
            chu_ti();    // 调用出题方法，出第一道题
		}

		private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			string Item ;
			double k;
			if(e.KeyChar == 13)  // 表示按下的是回车键
			{
				if( Convert.ToInt16(textBox1.Text)== result)
				{
					Item = label1.Text+ textBox1.Text+ " √";
					right_shu = right_shu + 1;
				}
				else
					Item = label1.Text+ textBox1.Text+  " ×";
				//将题目、回答和对错判断插入列表框
				this.listBox1.Items.Add(Item); 
				this.textBox1.Text = "";//添加完毕，文本框置空 
				k= (double)right_shu / ti_shu;
				label2.Text = "共" + ti_shu + "题" + "正确率为:"+k.ToString(); 
				chu_ti();    // 调用出题过程，出下一道题
			}

		}

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: label3.Text = Convert.ToString((char)
                    new System.Random().Next(48, 58)//0-9
                    ); break;
                case 1: label3.Text = Convert.ToString((char)
                    new System.Random().Next(97,123)
                    ); break;//a-z
                case 2: label3.Text = Convert.ToString((char)
                    new System.Random().Next(65,91)//A-Z
                    ); break;
            }//注意：new System.Random().Next(97,123)产生97到122之间的随机整数。
        }

        private void button2_Click(object sender, EventArgs e)
        {
           textBox3.Text = getRandom(Convert.ToInt32(textBox2.Text));
            
        }
        public static string getRandom(int iCnt)//iCnt字符串个数
        {
            string allChar = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,"+ //C/C++续行符“\” 
                               "A,B,C,D,E,F,G,H,I,G,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z" + //VB中续行符"_"
                               ",0,1,2,3,4,5,6,7,8,9";
            string[] allCharArray = allChar.Split(',');
            string  randomCode = "";
            //int temp = -1;
            Random  random = new Random();
            for(int i = 0; i < iCnt; i++)
            {
                int t = random.Next(62);
                randomCode += allCharArray[t];
            }
            return randomCode;
        }
        //更简洁方法：
        private string GenerateCheckCode(int codeCount)//codeCount字符串个数
        {
            int number;
            char code;
            string checkCode = String.Empty;
            System.Random random = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                number = random.Next();
                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));
                checkCode += code.ToString(); 
            }
            return checkCode;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            int I = (int)e.KeyChar;
            if (I == (int)Keys.Enter || I == (int)Keys.Back || I == (int)Keys.Left ||
                I == (int)Keys.Right || I == (int)Keys.Left || I == (int)Keys.Delete)
            {
                return;//什么都不做
            }
            char[] charNum = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            if (Array.IndexOf(charNum, e.KeyChar) < 0)
            {
                e.Handled = true;
                //如果输入的是非数字字符，则提前将这个时间结束掉，而不添加                
            }//最好用KeyPress事件，KeyUp缺点是一直按键不放就能输入其他的字符。
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text =  GenerateCheckCode(Convert.ToInt32(textBox2.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int timu_total = 99;
            Random r = new Random(unchecked((int)DateTime.Now.Ticks));//Ticks是 long 类型，强制到 int 类型肯能报错， 所以加上 ~unchecked 可以避免报错
            int m = r.Next(1, timu_total);
            textBox4.Text += m.ToString();
        }

        private int[] nosame()
        {
            Random rdm = new Random();
            ArrayList al = new ArrayList(30);
            int t = 0;
            while (al.Count < 10)
            {
                t = rdm.Next(1, 200);
                if (!al.Contains(t))
                {
                    al.Add(t);
                }
            }
            al.Sort();
            int[] arr1 = new int[al.Count];
            arr1 = (int[])al.ToArray(typeof(int));
            //注意：ArrayList类是使用大小可按需动态增加的数组。它有两个方法：ArrayList.Add方法将对象添加到ArrayList的结尾处；
            //ArrayList.ToArray方法将ArrayList的元素复制到指定类型的新数组中。
            return arr1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[] arr1 = nosame();
            foreach (var arrs in arr1)
            {
                listBox2.Items.Add(arrs.ToString()); 
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox2.Sorted = true;
        }

       	}
}
