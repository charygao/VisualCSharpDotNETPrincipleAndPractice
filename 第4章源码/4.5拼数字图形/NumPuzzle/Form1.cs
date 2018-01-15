using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace NumPuzzle
{
	/// <summary>
	/// Form2 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		int GameSize;              //布局大小
		byte[] Position;           //绝对地址  
		Button[] Buttons;          //表现按扭
		const int MAP_WIDTH = 260; //图片宽度
		bool IsRun = false;        //游戏状态
		int Clicks = 0;            //总移动数

		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
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

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 296);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(608, 22);
			this.statusBar1.TabIndex = 0;
			this.statusBar1.Text = "请选择难度";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(344, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(260, 260);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4,
																					  this.menuItem5});
			this.menuItem1.Text = "游戏";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "2*2格";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "3*3格";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "4*4格";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "退出";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.SystemColors.Desktop;
			this.ClientSize = new System.Drawing.Size(608, 318);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.statusBar1);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "人物拼图游戏";
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyUp);
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
		//初始化游戏相关设置
		private void InitGame()
		{
			//清除已有棋盘按扭
			if(Buttons != null)
			{
				for(int i=0;i<Buttons.Length;i++)
					Buttons[i].Dispose();			    
			}
			Buttons = new Button[GameSize*GameSize];
			Position = new byte[GameSize*GameSize];

			Position[0] = 0;         //空的位置
			for(int i=1;i<Position.Length;i++)
			{
				Position[i] = (byte)i;//初始化数组
			}
			//随机打乱数组算法
			byte[] key = new byte[GameSize*GameSize];
			Random Rnd1= new Random();
			Rnd1.NextBytes(key);
			Array.Sort(key,Position);
			//动态生成按扭，其实可以用GDI画
			int BWidth = MAP_WIDTH / GameSize;
			for(int i=0;i<Buttons.Length;i++)
			{
				Buttons[i] = new Button();
				Buttons[i].Size = new Size(BWidth,BWidth);
				int j = i / GameSize;
				int k = i % GameSize;
				Buttons[i].Location = new Point(24+k*BWidth,16+j*BWidth);
				if(Position[i] == 0)
				{
					Buttons[i].Visible = false;
				}
				Buttons[i].Text = Position[i].ToString();
				//设置按钮背景图片***************
				Buttons[i].BackgroundImage= create_image(Convert.ToInt16( Position[i].ToString()));
				Buttons[i].Enabled = false;
				this.Controls.Add(Buttons[i]);
			}
			IsRun = true; //设置游戏运行标志
			this.Clicks = 0;		
		}

		private void DoChange(Keys key)
		{			
    		int offest = -1;
    		int MoveIndex = -1;
			for(int i=0;i<Position.Length;i++)//寻找空位置
			{
				if(Position[i] == 0)
				{
					offest = i;//offest记录空位置
					break;
				}
			}
			 //判断玩家按键，根据空位置推算被移动的按钮
			switch(key)
			{
				case Keys.Up:
					MoveIndex = offest + GameSize;
					break;
				case Keys.Down:
					MoveIndex = offest - GameSize;
					break;
				case Keys.Left:
					MoveIndex = offest + 1;
					if(offest % GameSize == GameSize - 1) 
						return;
					break;
				case Keys.Right:
					MoveIndex = offest - 1;
					if(offest % GameSize == 0) 
						return;
					break;
				default:
					break;
			}//End Switch
			//判断有效范围,判断是否能移动
			if(MoveIndex < 0 || MoveIndex >= Position.Length)
				return;
			Clicks++;
			this.statusBar1.Text = Clicks.ToString()+" Move";
			PlaySound.Play("MOVE.WAV");
			byte temp;
			//交换数组中offest和MoveIndex位置
			temp = Position[offest];
			Position[offest] = Position[MoveIndex];
			Position[MoveIndex] = temp;

			//更新游戏界面
			UpDataUI(offest,MoveIndex);
			//检查游戏是否过关 
			CheckWin();
		}

		private void UpDataUI(int offest,int MoveIndex)
		{
			if(this.IsRun == false)
				return;
			Buttons[offest].Visible = true;
			Buttons[offest].Text = Position[offest].ToString();
			Buttons[offest].BackgroundImage= create_image(Convert.ToInt16( Position[offest].ToString()));
			Buttons[MoveIndex].Visible = false;
		}

		//检查是否胜利
		private void CheckWin()
		{
			for(int i=1;i<Position.Length;i++)
			{
				if(Position[i] != (byte)i)
				{
					return;  //不符合条件返回
				}
			}
			//显示去掉的拼块
			Buttons[0].Visible = true;
			Buttons[0].Text = "0";
			Buttons[0].BackgroundImage= create_image(0);			
			 //过关后播放相应音乐
			PlaySound.Play("WIN.WAV");
			IsRun = false;
			this.statusBar1.Text+=" 过关！";
		}

		private void Form2_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(IsRun == false)
				return;
			switch (e.KeyCode)
			{
				case Keys.Up:
				case Keys.Down:
				case Keys.Right:
				case Keys.Left:
					DoChange(e.KeyCode);
					break;
				default:
					break;
			}
		}
		private Bitmap create_image(int n)//按标号n截图
		{
			int W = MAP_WIDTH /GameSize ;
			Bitmap bit = new Bitmap( W, W );
			Graphics g = Graphics.FromImage( bit );
			//截图
			g.DrawImage( pictureBox1.Image,	new Rectangle( 0, 0, W,W ),
				new Rectangle( n%GameSize*W,n/GameSize* W, W,W )/*Copy W*W part from source image */,
				GraphicsUnit.Pixel );  
			return bit;
		}
		private void menuItem2_Click(object sender, System.EventArgs e)//2*2格
		{
			GameSize = 2;
			InitGame();
		}
		private void menuItem3_Click(object sender, System.EventArgs e)//3*3格
		{
			GameSize = 3;
			InitGame();
		}		
		private void menuItem4_Click(object sender, System.EventArgs e)//4*4格
		{
			GameSize = 4;
			InitGame();
		}
		private void menuItem5_Click(object sender, System.EventArgs e)//退出
		{
			Application.Exit(); 
		}
	}
}
