using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


/*******************************************************
 *            RedSnake V1.0 C#
 *       Code by Red_angelX  Just For Fun
 *         Otherwise, Can you offer me A job?!
 * ****************************************************/
namespace RedSnake
{
	/// <summary>
	/// RedSnake主窗体。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		//每次增加SegMent个数
		private const int GROWTH_FACTOR = 1;
		//Segmen的宽度  Pixels
		private const int SNAKE_WIDTH = 8;

		private Snake m_snake;
		private Control m_control;


		private bool m_running = false;
		private bool m_growing = false;

		//存放food size &Location
		private Rectangle m_foodrec;
		private int m_score;


		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label GameHint;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.PictureBox PictureBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label score;
		private System.Windows.Forms.Label snakelen;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.ComponentModel.IContainer components;

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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.GameHint = new System.Windows.Forms.Label();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label4 = new System.Windows.Forms.Label();
			this.score = new System.Windows.Forms.Label();
			this.snakelen = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem6});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4,
																					  this.menuItem5});
			this.menuItem1.Text = "文件(&F)";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.F2;
			this.menuItem2.Text = "开始(Enter)";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.menuItem3.Text = "暂停(Pause)";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "-";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "退出(&X)";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 1;
			this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem7,
																					  this.menuItem8});
			this.menuItem6.Text = "帮助(&H)";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 0;
			this.menuItem7.Text = "帮助说明(&H)";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 1;
			this.menuItem8.Text = "关于(&A)";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.snakelen);
			this.groupBox1.Controls.Add(this.score);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
			this.groupBox1.Location = new System.Drawing.Point(384, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(168, 397);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "状态";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 160);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "当前长度:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 128);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "当前得分:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(64, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 24);
			this.label1.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.GameHint);
			this.groupBox2.Controls.Add(this.PictureBox1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(384, 397);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// GameHint
			// 
			this.GameHint.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.GameHint.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.GameHint.Location = new System.Drawing.Point(88, 152);
			this.GameHint.Name = "GameHint";
			this.GameHint.Size = new System.Drawing.Size(200, 80);
			this.GameHint.TabIndex = 1;
			this.GameHint.Text = "Welcome To Play RedSnake ^_^ Press Enter To Start";
			this.GameHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// PictureBox1
			// 
			this.PictureBox1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PictureBox1.Location = new System.Drawing.Point(3, 17);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(378, 377);
			this.PictureBox1.TabIndex = 0;
			this.PictureBox1.TabStop = false;
			this.PictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1_Paint);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 24);
			this.label4.TabIndex = 3;
			this.label4.Text = "Food坐标";
			// 
			// score
			// 
			this.score.Location = new System.Drawing.Point(80, 128);
			this.score.Name = "score";
			this.score.Size = new System.Drawing.Size(72, 16);
			this.score.TabIndex = 4;
			// 
			// snakelen
			// 
			this.snakelen.Location = new System.Drawing.Point(80, 160);
			this.snakelen.Name = "snakelen";
			this.snakelen.Size = new System.Drawing.Size(72, 16);
			this.snakelen.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label5.Location = new System.Drawing.Point(16, 368);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(136, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "Powered By Red_angelX";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 248);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(136, 16);
			this.label6.TabIndex = 7;
			this.label6.Text = "Tips:";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 272);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(136, 48);
			this.label7.TabIndex = 8;
			this.label7.Text = "开始游戏快捷键 F2   暂停游戏快捷键 F3   方向 →右←左↑上↓上  ";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(552, 397);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "RedSnake C# By Red_angelX";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
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

		private void Form1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.Enter:
					//Start a New Game
					HideMsg();
					break;
				case Keys.Escape:
					if(m_running)
						ShowMsg("Game is Paused,Press Enter to Continue,Esc to Exit");
					else
						Close();
					break;
			}
		}

		private void ShowMsg(string msg)
		{
			GameHint.Text = msg;
			GameHint.Visible = true;
			m_running = false;
			timer1.Stop();
		}

		private void HideMsg()
		{
			GameHint.Visible = false;
			m_running = true;
			timer1.Start();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			//Update Game
			UpdateSnake();

			//重绘画面
			this.PictureBox1.Invalidate();		
		}


		private void Form1_Load(object sender, System.EventArgs e)
		{
			InitGame();
		}

		private void InitGame()
		{
			this.m_score = 0;
			m_foodrec = new Rectangle(0,0,SNAKE_WIDTH,SNAKE_WIDTH);
			//随机生成food
			PlaceFood();
			Point startPt =  new Point(((int) Math.Round((double) (((((double) this.PictureBox1.ClientSize.Width) / 2) / SNAKE_WIDTH) + 0.5))) * SNAKE_WIDTH,
				((int) Math.Round((double) (((((double) this.PictureBox1.ClientSize.Height) / 2) / SNAKE_WIDTH) + 0.5))) * SNAKE_WIDTH);
			this.m_snake = new Snake(startPt, SNAKE_WIDTH, 1);
			this.m_control = new Control(SNAKE_WIDTH,m_snake.Head.Location,Control.SnakeDirection.Left);

			this.m_growing = true;

			this.score.Text = "0";
			this.snakelen.Text = "1";

		}

		static int targetgrowth = GROWTH_FACTOR;
		static int segmentsadded;
		private void UpdateSnake()
		{

			if(m_running != true)
				return;

			m_control.Move();
			if(m_control.Location.X<0 || m_control.Location.Y<0 || m_control.Location.X>=this.PictureBox1.ClientRectangle.Width || m_control.Location.Y>=this.PictureBox1.ClientRectangle.Height)
			{
				targetgrowth = 0;
				segmentsadded = 0;
				//Kill the Poor Guy
				KillSnake();
				return;
			}

			if(m_snake.PointOnSnake(this.m_control.Location))
			{
				targetgrowth = 0;
				segmentsadded = 0;
				//Kill the Poor Guy
				KillSnake();
				return;
			}
			else if(m_foodrec.Contains(m_control.Location))
			{
				targetgrowth += GROWTH_FACTOR;
				m_growing = true;

				PlaceFood();

				m_score += 1;
				this.score.Text = m_score.ToString();
				this.snakelen.Text = m_snake.Length.ToString();
			}

			if(m_growing)
			{
				if(targetgrowth < GROWTH_FACTOR)
					targetgrowth = GROWTH_FACTOR;

				if(segmentsadded >= targetgrowth)
				{
					m_growing = false;
					segmentsadded = 0;
					targetgrowth = 0;

					m_snake.Slither(m_control.Location);
				}
				else
				{
					m_snake.Add(m_control.Location);
					segmentsadded += 1;
				}
			}
			else
			{
				m_snake.Slither(m_control.Location);
			}

		}

		public Point GetRandomPoint()
		{
			Random rd = new Random(DateTime.Now.Second);
			int field_width = ((this.PictureBox1.ClientRectangle.Width / SNAKE_WIDTH) - 2) * SNAKE_WIDTH;
			int field_height = ((this.PictureBox1.ClientRectangle.Height / SNAKE_WIDTH) - 2) * SNAKE_WIDTH;
			int randx = rd.Next(0, field_width);
			int randy = rd.Next(0, field_height);
			randx = (randx / SNAKE_WIDTH) * SNAKE_WIDTH;
			randy = (randy / SNAKE_WIDTH) * SNAKE_WIDTH;
			return new Point(randx, randy);
		}

		public void PlaceFood()
		{
			Point footPt;
			do
			{
				footPt = this.GetRandomPoint();
			}
			while ((this.m_snake != null) && this.m_snake.PointOnSnake(footPt));
			this.m_foodrec.Location = footPt;
			this.label1.Text = "X:"+footPt.X.ToString()+" Y:"+footPt.Y.ToString();
		}

		private void KillSnake()
		{
			this.ShowMsg("Game Over,Wanna RePlay? Press Enter or Esc");
			MessageBox.Show("Oh My Poor Guys,You die","Game Over");
			InitGame();
		}

		private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Right:
				case Keys.NumPad6:
					this.m_control.Direction = Control.SnakeDirection.Right;
					return;

				case Keys.Down:
				case Keys.NumPad2:
					this.m_control.Direction = Control.SnakeDirection.Down;
					return;

				case Keys.Left:
				case Keys.NumPad4:
					this.m_control.Direction = Control.SnakeDirection.Left;
					return;

				case Keys.Up:
				case Keys.NumPad8:
					this.m_control.Direction = Control.SnakeDirection.Up;
					return;

				case Keys.OemOpenBrackets:
					this.m_control.TurnLeft();
					return;

				case Keys.OemCloseBrackets:
					this.m_control.TurnRight();
					break;
			}

		}

		private void PictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if(m_running == false)
			{
				e.Graphics.Clear(PictureBox1.BackColor);
				return;
			}

			e.Graphics.FillEllipse(Brushes.Cornsilk,m_foodrec);

			
			foreach (SnakeSegment thisSeg in m_snake.Segments)
			{
				e.Graphics.FillRectangle(Brushes.LightGreen,thisSeg.Rectangle);
			}
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			HideMsg();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			if(m_running)
				ShowMsg("Game is Paused,Press Enter to Continue,Esc to Exit");		
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			About ab = new About();
			ab.ShowDialog();
		}

 


 




 

	}
}
