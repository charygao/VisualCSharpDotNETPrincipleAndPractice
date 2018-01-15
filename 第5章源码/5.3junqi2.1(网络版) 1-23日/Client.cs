using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

//add
using System.Net ;
using System.Net.Sockets ;
using System.Text;
using System.Threading ;

namespace 军旗
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;		
		private System.Windows.Forms.PictureBox qi_pan;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Button button3;		
		private System.Windows.Forms.TextBox txt_remoteport;
		private System.Windows.Forms.TextBox txt_port;
		private System.Windows.Forms.TextBox txt_IP;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;

		//在类class Form1中声明私有的数据成员变量
		private PictureBox[] Qizi_Pic; 
		private int Pic_Width;
		private int [ ]Q;
		private int [ , ]Map;
		private bool can_go=false;  //能否走棋
		bool _isDragging = false;
		bool Layout_Flag=true;//布阵标志
		bool first=true;//布阵时第一次单击标志
		int mouse_x, mouse_y;
		int old_x,old_y; //棋盘坐标
		int old_Left,old_Top;//棋子原始位置(像素)
		int tempx,tempy;//布阵时第一次单击坐标
		bool IsMyTurn=false;
		enum PlayerColor{Red,Black,Green,Glue}; 
		PlayerColor player=PlayerColor.Green;
		string path;// bin路径
		int r;//兵站间隔距离

		//网络通信部分
		private bool ReadFlag = true ;
		//设定侦听标示位，通过它来设定是否侦听端口号
		private Thread th ;//定义一个线程，在线程接收信息
		private IPEndPoint remote ;
		private bool Reset_flag=false;//重新开始标记
		private bool th_flag=false;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button6;
		//定义一个远程结点，用以获取远程计算机IP地址和发送的信息
		private UdpClient udpclient ;//创建一个UDP网络服务

	
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
            try//5-04
            {
                ReadFlag = false;
                if (udpclient != null) udpclient.Close();
                if (th != null) th.Abort();
                th = null;
            }
            catch { } 

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.qi_pan = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.button3 = new System.Windows.Forms.Button();
			this.txt_remoteport = new System.Windows.Forms.TextBox();
			this.txt_port = new System.Windows.Forms.TextBox();
			this.txt_IP = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// qi_pan
			// 
			this.qi_pan.Image = ((System.Drawing.Image)(resources.GetObject("qi_pan.Image")));
			this.qi_pan.Location = new System.Drawing.Point(32, 0);
			this.qi_pan.Name = "qi_pan";
			this.qi_pan.Size = new System.Drawing.Size(447, 446);
			this.qi_pan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.qi_pan.TabIndex = 1;
			this.qi_pan.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(344, 320);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 24);
			this.button1.TabIndex = 4;
			this.button1.Text = "保存布阵";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(344, 360);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(64, 24);
			this.button2.TabIndex = 5;
			this.button2.Text = "读取布阵";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(496, 192);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(200, 64);
			this.listBox1.TabIndex = 6;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 464);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(704, 22);
			this.statusBar1.TabIndex = 7;
			this.statusBar1.Text = "欢迎使用快乐军旗2.1";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(344, 408);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(64, 24);
			this.button3.TabIndex = 8;
			this.button3.Text = "开始对战";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// txt_remoteport
			// 
			this.txt_remoteport.Location = new System.Drawing.Point(576, 120);
			this.txt_remoteport.Name = "txt_remoteport";
			this.txt_remoteport.Size = new System.Drawing.Size(120, 21);
			this.txt_remoteport.TabIndex = 11;
			this.txt_remoteport.Text = "4444";
			// 
			// txt_port
			// 
			this.txt_port.Location = new System.Drawing.Point(576, 80);
			this.txt_port.Name = "txt_port";
			this.txt_port.Size = new System.Drawing.Size(120, 21);
			this.txt_port.TabIndex = 10;
			this.txt_port.Text = "3333";
			// 
			// txt_IP
			// 
			this.txt_IP.Location = new System.Drawing.Point(576, 40);
			this.txt_IP.Name = "txt_IP";
			this.txt_IP.Size = new System.Drawing.Size(120, 21);
			this.txt_IP.TabIndex = 9;
			this.txt_IP.Text = "127.0.0.1";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(504, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 24);
			this.label5.TabIndex = 14;
			this.label5.Text = "对方端口";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(504, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 24);
			this.label4.TabIndex = 13;
			this.label4.Text = "本地端口";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(504, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 24);
			this.label3.TabIndex = 12;
			this.label3.Text = "对方IP";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(600, 280);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(80, 32);
			this.button4.TabIndex = 15;
			this.button4.Text = "联  机";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(600, 328);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(80, 32);
			this.button5.TabIndex = 16;
			this.button5.Text = "重新开始";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(480, 336);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 32);
			this.label1.TabIndex = 17;
			this.label1.Text = "label1";
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(496, 152);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(88, 32);
			this.radioButton1.TabIndex = 18;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "主机";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(592, 152);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(88, 24);
			this.radioButton2.TabIndex = 19;
			this.radioButton2.Text = "从机";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(480, 384);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 23);
			this.label2.TabIndex = 20;
			this.label2.Text = "label2";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(600, 384);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(80, 32);
			this.button6.TabIndex = 21;
			this.button6.Text = "结束退出";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(704, 486);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_remoteport);
			this.Controls.Add(this.txt_port);
			this.Controls.Add(this.txt_IP);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.qi_pan);
			this.Name = "Form1";
			this.Text = "军旗2.1";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
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
		//添加处理棋子起始位置方法
		private void begin_pos(int m)
		{
			string filename="";
			path = System.Windows.Forms.Application.StartupPath;// bin路径
			Qizi_Pic=new PictureBox[25*m];
			int  i;
			int n=1;
			for( i = 0;i<25*m;i++)//添加25*m个棋子
			{
				Qizi_Pic[i] = new PictureBox();
				this.Controls.Add(Qizi_Pic[i]);
				Qizi_Pic[i].Width = 22;
				Qizi_Pic[i].Height = 22;
				Qizi_Pic[i].Name = "R" +i.ToString();
				Qizi_Pic[i].Tag = i.ToString();
				Qizi_Pic[i].Parent = qi_pan;
				if(i<25)
				{
					filename = path + "\\..\\..\\bmp\\" + Q[i].ToString() + ".bmp";}
				if(i>=25&& i<50)
				{
					filename = path + "\\..\\..\\bmp\\G" + Q[i%25].ToString() + ".bmp";
					//暗棋filename = path + "\\..\\..\\bmp\\G.bmp";
				}
				Qizi_Pic[i].Image = Image.FromFile(filename);
				Qizi_Pic[i].Click+=new System.EventHandler(bt_Click);
				Qizi_Pic[i].MouseDown+=new System.Windows.Forms.MouseEventHandler(bt_MouseDown); 
				Qizi_Pic[i].MouseMove+=new System.Windows.Forms.MouseEventHandler(bt_MouseMove); 
				Qizi_Pic[i].MouseUp+=new System.Windows.Forms.MouseEventHandler(bt_MouseUp); 
				if(i%5==0)n++;
				Qizi_Pic[i].Top = 250+n*24;Qizi_Pic[i].Left = 10 + 23 *(i%5);
				Qizi_Pic[i].Visible=false; 

			}
				
		}
		private void bt_Click(object sender, System.EventArgs e) //这里处理单击事件过程
		{
			int x1,y1;						
			PictureBox  picBox1=(PictureBox)sender;
			int i=Convert.ToInt16(picBox1.Tag);
			//转换成棋盘坐标(x1,y1)
			x1=(picBox1.Left -10+picBox1.Width/2)/r+1;
			y1=(picBox1.Top -10+picBox1.Width/2)/r+1;
			if(Layout_Flag==true) //是否布局
			{
				if(first==true){tempx=x1;tempy=y1;first=false;return; }
				else{old_x=tempx;old_y=tempy;first=true;}
				if(Layout_Juge(old_x,old_y,x1,y1))//是否可以改变布局
					if(Map[x1,y1]==101)//没有棋子
					{
						MoveChess(Map[old_x,old_y],x1,y1);
						Map[old_x,old_y]=101;
					}					 
					else //对调棋子
					{ MoveChess(Map[old_x,old_y],x1,y1); MoveChess(i,old_x,old_y);}
				else 
					//statusBar1.Text="不能改变原有布局";
					MessageBox.Show("第一排不允许放置炸弹，放置地雷在后两排，军旗只能在大本营",
                       "违反军旗布局规则");
			}
		}
		private void bt_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (can_go!=true) 
			{statusBar1.Text ="不能走棋，请等对方";return;}
			PictureBox  picBox1=(PictureBox)sender;//将被击的赋给定义的picBox1变量
			int i=Convert.ToInt16(picBox1.Tag);				
			if(Q[i%25]==30||Q[i%25]==29)return; //地雷不能动
			if(IsBigHome(old_x,old_y))return;  //大本营中棋子不能动
			if(!IsMyTurn){statusBar1.Text="该对方走棋，请等对方";return;}
			if (_isDragging)
			{
				picBox1.Left = picBox1.Left - mouse_x + e.X;
				picBox1.Top = picBox1.Top - mouse_y + e.Y;
			}
			picBox1.BringToFront();
		}
		private bool IsBigHome(int old_x,int old_y) //判断是否大本营
		{
			if(old_x==8&& old_y==17)return true;
			if(old_x==8&& old_y==10)return true;
			if(old_x==8&& old_y==1)return true;
			if(old_x==10&&old_y==17)return true;
			if(old_y==8&& old_x==17)return true;
			if(old_y==8&& old_x==10)return true;
			if(old_y==8&& old_x==1)return true;
			if(old_y==10&&old_x==17)return true;
			return false;
		}
		private void bt_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			_isDragging = false;
			int x,y;
			string path = System.Windows.Forms.Application.StartupPath;// bin路径
			path += "\\..\\..\\wav\\";
			
			PictureBox  picBox1=(PictureBox)sender;
            int idx=Convert.ToInt16(picBox1.Tag);
			//转换成棋盘坐标(x1,y1)
			x=(picBox1.Left -10+picBox1.Width/2)/r+1;
			y=(picBox1.Top -10+picBox1.Width/2)/r+1;
			if(Layout_Flag==true) //是否布局
			{
				if(!(x<=12&&x>=7 &&y>=12 && y<=17))
				{
					picBox1.Left=old_Left;picBox1.Top=old_Top;
					MessageBox.Show("只能在南区布局","违反军旗布局区域");
				}

			}
			else //走棋状态
			{
				if(!IsMyTurn){MessageBox.Show ("该对方走棋，请等对方");picBox1.Left=old_Left;picBox1.Top=old_Top;return;}
				if(old_x==x&&old_y==y)return ;				
				if(Go_Juge(old_x,old_y,x,y))//IsmyChess2(idx) 	
				{
					go_chess(old_x,old_y,x,y,idx);

					PlaySound.Play(path+"move.wav");
					//*********************

					string str_send="move|"+(18-x).ToString()+"|"+(18-y).ToString()+"|"+Map[x,y].ToString()+"|"
						+(18-old_x).ToString()+"|"+(18-old_y).ToString()+"|"+idx.ToString();
					statusBar1.Text=str_send;
					send(str_send);
                    IsMyTurn=!IsMyTurn;
					reverse();
				}
				else //不符合规则，不能走棋
				{	picBox1.Left=old_Left;picBox1.Top=old_Top;}
			}
		}
		private void go_chess(int old_x,int old_y,int x,int y,int idx)//完成走棋吃子功能
		{
			if(Map[x,y]==101)//目标处无棋子					
			{
				MoveChess(idx,x,y);
				Map[old_x,old_y]=101;
			}
			else//目标有棋子 判断是否吃子
			{
				int other_idx=Map[x,y];
				int other_big=Q[other_idx%25];
				int my_idx=idx;
				int my_big=Q[my_idx%25];
				MoveChess(idx,x,y);//移动自己的棋子
				Map[old_x,old_y]=101;
				//判断保留那方棋子
				//(1)均为兵到司令
				if(my_big>=32 && my_big<=40 &&other_big>=32 &&other_big<=40) //均为兵到司令
				{
					if(other_big<my_big) //对方被吃掉，Map[x,y]变为新棋子
					{
						Qizi_Pic[other_idx].Visible=false; 
						Map[x,y]=my_idx;
					}
					else if(other_big==my_big)//双方均去掉
					{
						Qizi_Pic[other_idx].Visible=false; 
						Qizi_Pic[my_idx].Visible=false; 
						Map[x,y]=101;

					}
					else//自己被吃掉，Map[x,y]不变
					{
						Qizi_Pic[my_idx].Visible=false; 
						Map[x,y]=other_idx;
					}
					return;
				}
				//(2)一方为炸弹，同时去掉
				if(other_big==31||my_big==31)
				{
					Qizi_Pic[other_idx].Visible=false; 
					Qizi_Pic[my_idx].Visible=false; 
					Map[x,y]=101;
					return;
				}
				//(3)一方为地雷(30),对方为兵(32)
				if((other_big==30&&my_big==32)||(other_big==32&&my_big==30))
				{
					if(other_big==30){Qizi_Pic[other_idx].Visible=false; Map[x,y]=my_idx;}
					if(my_big==30){Qizi_Pic[my_idx].Visible=false; Map[x,y]=other_idx;}
					return;
							
				}
				//(3)一方为地雷(30),对方不为兵(32)
				if((other_big==30&&my_big!=32)||(other_big!=32&&my_big==30))
				{
					if(other_big==30){Qizi_Pic[my_idx].Visible=false; Map[x,y]=other_idx;}
					if(my_big==30){Qizi_Pic[other_idx].Visible=false; Map[x,y]=other_idx;}
					return;
							
				}
				//(4)对方为军旗,则赢了
				if(other_big==29)//29代表军旗
				{
					string m="绿方";
					if(player==PlayerColor.Red)
					{
						MessageBox.Show("红胜利了");
						m="红方";
					}
					else MessageBox.Show("绿胜利了");
					string str_send="over|"+m;
					statusBar1.Text=str_send+"胜利了";
					if(m=="绿方")//将对方棋子全部去掉
					{
						for(int k=0;k<25;k++)
							Qizi_Pic[k].Visible=false;
					}
					else
					{
						for(int k=25;k<50;k++)
							Qizi_Pic[k].Visible=false;
					}
					send(str_send);
					return;
				}					
				statusBar1.Text=Map[x,y].ToString(); 

			}	
		}
		private void reverse()
		{
			if(!IsMyTurn)statusBar1.Text= "该对方走棋";
			else		statusBar1.Text= "该自己方走棋";			
		}
		private void bt_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Cursor.Current = Cursors.Hand ;	
			PictureBox  picBox1=(PictureBox)sender;			
			old_x=(picBox1.Left-10)/r+1;
			old_y=(picBox1.Top-10)/r+1; 
			old_Left=picBox1.Left;
			old_Top=picBox1.Top; 
			if (e.Button == MouseButtons.Left)
			{
				mouse_x = e.X;	mouse_y = e.Y;
				_isDragging = true;
			}			
		}
		private void MoveChess(int  idx ,int x,int y)//移动棋子
			//idx棋子索引号，（x,y)目标位置
		{			
			Qizi_Pic[idx].Left =  (x - 1) *  r+10;
			Qizi_Pic[idx].Top =  (y - 1) *  r+10 ;
			Map[x, y] = idx;
		}
		private bool Layout_Juge(int old_x,int old_y,int x1,int y1) //判断布局棋子的位置是否适当
		{
			//第一排不允许放置炸弹，第1，2，3，4排不允许放置地雷，
			//自己的军旗只能放置在大本营
			//炸弹控件编号4，5,第一排(y1=12)不允许放置炸弹
			if(Q[Map[old_x,old_y]%25]==31 && y1==12)
				return false;
			if(Q[Map[x1,y1]%25]==31 && old_y==12)
				return false;//第一排(y1=12)不允许放置炸弹
			if(Q[Map[old_x,old_y]%25]==29 && !(x1==8&&y1==17||x1==10&&y1==17))
				return false;//自己的军旗控件,只能放置在大本营
			if(Q[Map[x1,y1]%25]==29 && !(old_x==8&&old_y==17||old_x==10&&old_y==17))
				return false;//自己的军旗控件,只能放置在大本营
			if(Q[Map[x1,y1]%25]==30 && !(old_y==16||old_y==17))
				return false;//第1，2，3，4排不允许放置地雷，
			if(Q[Map[old_x,old_y]%25]==30 && !(y1==16||y1==17))
				return false;//第1，2，3，4排不允许放置地雷，       
              
			return true;//其余情况均可以 

		}
		private bool Go_Juge(int old_x,int old_y,int x,int y)//判断走棋的位置是否适当
		{
			label1.Text=old_x.ToString()+"old_x:old_y"+old_y.ToString()+":"+Map[old_x,old_y].ToString();
			label2.Text=x.ToString()+"x:y"+y.ToString()+Map[x,y].ToString() ;
			//是否是棋子区域
			if( (x<=6 && y>=1 && y<=6) || (x>=12 && y>=1 && y<=6) ||
				(x<=6 && y>=12 && y<=17) || (x>=12 && y>=12 && y<=17)|| y>17 )
				return false;
			//目标位置是自己方的棋子
			//Why***********if(IsmyChess(x,y)) return false;

			//到行营，行营是否有子
			if(Is_Home( x, y)&& Map[x,y]!=101)return false;

			//如“士”斜线从行营中出来**********
			if(Is_Home( old_x, old_y)&& Map[x,y]==101&& Math.Abs(x-old_x)*Math.Abs(y-old_y)==1 )return true;

			//如“士”斜线走入行营************
			if(Is_Home( x, y)&& Map[x,y]==101 && Math.Abs(x-old_x)*Math.Abs(y-old_y)==1 )return true;


			//移动一步
			if( Math.Abs(x-old_x)==1 && y==old_y ||Math.Abs(y-old_y)==1 && x==old_x) return  true;
			//铁道线
			if(T_Juge(old_x,old_y,x,y))	return true;
			//if(T_Juge(old_y,old_x,y,x))	return true;
			
			return false;
			
		}
		private bool T_Juge(int old_x,int old_y, int x,int y)//铁道线可以走否
		{
			//长垂直铁路线与弯道铁道线
			if(old_x==7)
			{
				if(x==7 && y<17 &&y>1 &&y!=8 &&y!=10 && VLine_Juge(old_y,y,x))return true;//长垂直铁路线
				if(x<7 &&x>1 &&y==7 && old_y<=7
					&&VLine_Juge(old_y,y,old_x)&&HLine_Juge(old_x,x,y))return true;
				if(x<7 &&x>1 &&y==11 && old_y>=11
					&&VLine_Juge(old_y,y,old_x)&&HLine_Juge(old_x,x,y))return true;
			}
			if(old_x==11)
			{
				if(x==11 && y<17 &&y>1&&y!=8 &&y!=10 && VLine_Juge(old_y,y,x))return true;//长垂直铁路线
				if(x<17 &&x>=12 &&y==7 && old_y<=7
					&&VLine_Juge(old_y,y,old_x)&&HLine_Juge(old_x,x,y))return true;
				if(x<17 &&x>=12 &&y==11 && old_y>=11
					&&VLine_Juge(old_y,y,old_x)&&HLine_Juge(old_x,x,y))return true;
			}
			//短水平铁路线
			if(old_y==2||old_y==6||old_y==12||old_y==16)
				if(y==old_y && Math.Abs(x-old_x)<=4 && HLine_Juge(old_x,x,y))
					return true;
			//********************************
			//长水平铁路线与弯道铁道线
			if(old_y==7)
			{
				if(y==7 && x<17 &&x>1 &&x!=8 &&x!=10 && HLine_Juge(old_x,x,y))return true;
				//************
				if(y<7 &&y>1 &&x==7 && old_x<=7
					&&HLine_Juge(old_x,x,old_y)&&VLine_Juge(old_y,y,x))return true;
				if(y<7 &&y>1 &&x==11 && old_x>=11
					&&HLine_Juge(old_x,x,old_y)&&VLine_Juge(old_y,y,x))return true;

			}
			if(old_y==11)
			{
				if(y==11 && x<17 &&x>1 &&x!=8 &&x!=10 && HLine_Juge(old_x,x,y))return true;
				//*************************
				if(y<17 &&y>=12 &&x==7 && old_x<=7
					&&HLine_Juge(old_x,x,old_y)&&VLine_Juge(old_y,y,x))return true;
				if(y<17 &&y>=12 &&x==11 && old_x>=11
					&&HLine_Juge(old_x,x,old_y)&&VLine_Juge(old_y,y,x))return true;			}
			//短垂直铁路线
			if(old_x==2||old_x==6||old_x==12||old_x==16)
				if(x==old_x && Math.Abs(y-old_y)<=4 && VLine_Juge(old_y,y,x))
					return true;
			//***********************************
			//中间“田字”铁路线
			if(old_y==9)
			{
				if(y==9 && x<=12 &&x>=6 &&x!=8 &&x!=10 && HLine_Juge(old_x,x,y))return true;
			}
			if(old_x==9)
			{
				if(x==9 && y<=12 &&y>=6 &&y!=8 &&y!=10 && VLine_Juge(old_y,y,x))return true;
			}
			return false;
		}


		//垂直方向判断是否有别的棋子挡路
		private bool VLine_Juge(int m,int n, int x)
		{
			int t=Math.Max(m,n);
			m=Math.Min(m,n);
			n=t;
			for(int i=m+1;i<n;i++)
				if(Map[x,i]!=101) //有别的棋子
					return false;
			return true;
		}
		//水平方向判断是否有别的棋子挡路
		private bool HLine_Juge(int m,int n, int y)
		{
			int t=Math.Max(m,n);
			m=Math.Min(m,n);
			n=t;
			for(int i=m+1;i<n;i++)
				if(Map[i,y]!=101) //有别的棋子
					return false;
			return true;
		}
		//是否是行营
		private bool Is_HalfHome(int x, int y)
		{
			if(
				(x==8&&y==3)||(x==8&&y==5)||(x==10&&y==3)||(x==10&&y==5)||
				(x==8&&y==13)||(x==8&&y==15)||(x==10&&y==13)||(x==10&&y==15)||
				(x==9&&y==4)||(x==9&&y==14)
				)return true;
			else return false;
		}
		private bool Is_Home(int x, int y)
		{
			if(Is_HalfHome(x, y)||Is_HalfHome(y,x))
				return true;
			else
				return false;
		}

		private bool IsmyChess(int x,int y)//是否是自己方棋子
		{
			int idx=Map[x,y];
			if(idx==101)return false;
			else return IsmyChess2(idx);

		}
		private bool IsmyChess2(int idx)//根据索引判断是否是自己方棋子
		{
			if(player==PlayerColor.Red)
			{
				if(idx>=0&& idx<=24) //单机版 四国时24+25
					return true;
				else
					return false;
			}
			else
			{
				if(!(idx>=0&& idx<=24)) //单机版 四国时24+25
					return true;
				else
					return false;
			}
		}																																	
        
		private void Form1_Load(object sender, System.EventArgs e)
		{
            Pic_Width=qi_pan.Width;  //棋盘大小
            r=(Pic_Width)/17;
            Map=new int[18,18];
		    for(int i=1;i<18;i++)
			  for(int j=1;j<18;j++)
			   Map[i,j]=101;  //101表示(i,j)处没放置棋子
			qi_index();     //棋子编号并设置对应棋子含义
			begin_pos(2);	//加载不可见棋子
			button1.Visible=false; //保存布阵按钮
			button2.Visible=false; //读取布阵按钮
			button3.Visible=false; //开始对战按钮
			button5.Enabled=false; //重新开始按钮
		}
		private void qi_index()
		{
			Q=new int[25];
			Q[0]=29; //军旗29
			Q[1]=30;Q[2]=30;Q[3]=30;//地雷30
		    Q[4]=31;Q[5]=31;//炸弹31
			Q[6]=32;Q[7]=32;Q[8]=32;//工兵32
			Q[9]=33;Q[10]=33;Q[11]=33;//排长33
			Q[12]=34;Q[13]=34;Q[14]=34;//连长34
			Q[15]=35;Q[16]=35;//营长35
			Q[17]=36;Q[18]=36;//团长36
			Q[19]=37;Q[20]=37;//旅长37
			Q[21]=38;Q[22]=38;//师长38
			Q[23]=39;//军长39
			Q[24]=40;//司令40
		}
		private void read_qi_pu()//从布阵棋谱文件中读取位置，放置棋子
		{
			FileStream Myfile = new  FileStream("MyFile.txt",FileMode.Open,FileAccess.Read );
			int  x,y,idx;
			while((x=Myfile.ReadByte())!=-1)
			{				
				y=Myfile.ReadByte(); 
				idx=Myfile.ReadByte(); 
				
				if(idx!=101)
				{
					if(player==PlayerColor.Red)
					{
						MoveChess(idx,x,y);Qizi_Pic[idx].Visible=true; 
					}
					else
					{
						MoveChess(idx+25,x,y);Qizi_Pic[idx+25].Visible=true; 
					}
				}
				
			}
			Myfile.Close();			
		}
		private void write_qi_pu()
		{
			FileStream fw = new  FileStream("MyFile.txt",FileMode.Create,FileAccess.Write);
			//将棋子Map写入布阵文件MyFile.txt中			
			for(byte x=7;x<=11;x++)
				for(byte y=12;y<=17;y++)
				{
					fw.WriteByte(x);
					fw.WriteByte(y);
					if(Map[x,y]>=25 && Map[x,y]!=101)
						fw.WriteByte((byte)(Map[x,y]-25));
					else
						fw.WriteByte((byte)Map[x,y]);
						
				}
			fw.Flush();  //刷新文件，将缓冲区数据写入文件
			fw.Close();
		}
		private void button1_Click(object sender, System.EventArgs e)//保存布阵
		{
			write_qi_pu();		
		}

		private void button2_Click(object sender, System.EventArgs e)//读取布阵
		{
			read_qi_pu();		
		}

		private void button3_Click(object sender, System.EventArgs e)//开始游戏对战
		{
			Layout_Flag=false;//布阵标志
			
			string str_send;
			//允许对方布阵
			if(player==PlayerColor.Red )
			{
				str_send="begin_layout|"+player.ToString();
				send(str_send);
			}

			str_send="layout|";
			byte []m=new byte[90];
			int i=0;
			for(int  x=7;x<=11;x++)
				for(int  y=12;y<=17;y++)
				{
					m[i]=(byte)(18-x);
					m[i+1]=(byte)(18-y);
					m[i+2]=(byte)Map[x,y];						
					str_send+=(18-x).ToString()+","+(18-y).ToString()+","+Map[x,y].ToString()+",";   
				}			
			//str_send="layout|"+Encoding.ASCII.GetString(m);
			statusBar1.Text="布阵完成";
			send(str_send);//发送布阵信息
			can_go=true;
			string path = System.Windows.Forms.Application.StartupPath;// bin路径
			path += "\\..\\..\\wav\\";
			PlaySound.Play(path+"junqistart.wav");
			button1.Visible=false; 
			button2.Visible=false; 
			button3.Visible=false; 
			button5.Enabled=true; 
		}
		private void get_message(string a)
		//读取对方布阵棋子信息并且将对方棋子图片改为暗棋图片
		{
			//读取对方棋子		//30*3；注意不是25*3	
			int  x,y,idx;
			int x2,y2;
			int i;			
			string []m=new string[91]; 
			m=a.Split(',');

			string filename;

			for(i=0;i<90;i+=3)
			{
				x=Convert.ToInt16( m[i]);
				y=Convert.ToInt16( m[i+1]); 				
				//x2=18-x;//OneConvertTwo(x,y,x2,y2)
				//y2=18-y;
				x2=x;
				y2=y;

				idx=Convert.ToInt16( m[i+2]); 
				if(idx!=101)
				{
					if (player!=PlayerColor.Green)
					{
						MoveChess(idx,x2,y2);
						//将对方棋子图片改为暗棋图片
						filename= path + "\\..\\..\\bmp\\G.bmp";
						Qizi_Pic[idx].Image = Image.FromFile(filename);
					    Qizi_Pic[idx].Visible=true;											 
					} 
					else
					{
						MoveChess(idx,x2,y2);
						//将对方棋子图片改为暗棋图片
						filename= path + "\\..\\..\\bmp\\R.bmp";
						Qizi_Pic[idx].Image = Image.FromFile(filename);
						Qizi_Pic[idx].Visible=true;
					} 

				}				
			}
		}
		private void get_message1(string m)//读取对方布阵棋子信息
		{
			//读取对方棋子		//30*3；注意不是25*3	
			int  x,y,idx;
			int x2,y2;
			int i;			
			for(i=0;i<90;i+=3)
			{
				x=m[i];
				y=m[i+1]; 				
				x2=18-x;//OneConvertTwo(x,y,x2,y2)
				y2=18-y;
				idx=m[i+2]; 
				if(idx!=101){
					if (player!=PlayerColor.Green)
							 {MoveChess(idx+25,x2,y2);Qizi_Pic[idx+25].Visible=true;} 
					else
							 {MoveChess(idx,x2,y2);Qizi_Pic[idx].Visible=true;} 

				}				
			}
		}

		
		private void read ( )
		{
			//侦听本地的端口号
			udpclient = new UdpClient ( Convert.ToInt32(txt_port.Text)  ) ;
			remote = null ;
			//设定编码类型
			Encoding enc = Encoding.Unicode ;
			int x,y,old_x,old_y,idx,old_idx;
			while ( ReadFlag == true )
			{
				try
				{
				Byte[] data = udpclient.Receive ( ref remote ) ;
				//得到对方发送来的信息
				String strData = enc.GetString ( data ) ;
				string []a=new string[5]; 
				a=strData.Split('|');
				switch(a[0])
				{
				case "join":
					//获取传送信息到本地端口号的远程计算机IP地址
					string remoteIP = remote.Address.ToString ( ) ;
					//显示对方计算机IP地址
					statusBar1.Text = remoteIP + "对方已经加入，你是红方请布棋阵" ;			
					//**************************
					//允许己方布阵
					button1.Visible=true; 
					button2.Visible=true; 
					button3.Visible=true; 
					
					player=PlayerColor.Red;										 
					button4.Enabled =false;//联机按钮
					//允许对方布阵
					//string str_send="begin_layout|"+player.ToString();
					//send(str_send);
					break;
				case "begin_layout"://允许对方布阵							
					if(player==PlayerColor.Green &&statusBar1.Text=="程序处于等待联机状态！" )	
					{
						button1.Visible=true; 
						button2.Visible=true; 
						button3.Visible=true; 
					}
					statusBar1.Text="你是绿方，可以开始布阵了";	
					break;
				case "layout"://布阵信息							
					statusBar1.Text="收到对方布阵信息";
					get_message(a[1]);//读取对方布阵棋子信息							
					if(player==PlayerColor.Red){
						IsMyTurn=true; //能走棋
						statusBar1.Text = "对方已经布阵，你是红方请先走棋";
					}
					break;
				case "move"://对方棋子移动信息						
					x=Convert.ToInt16(a[1]);
					y=Convert.ToInt16(a[2]);
					idx=Convert.ToInt16(a[3]);
					old_x=Convert.ToInt16(a[4]);
					old_y=Convert.ToInt16(a[5]);
					old_idx=Convert.ToInt16(a[6]);
					statusBar1.Text ="对方下棋子位置："+ x.ToString()+","+y.ToString();
					//移动对方棋子，修改Map						
					//判断是否有子被吃
					if(Map[x,y]==101)//仅仅走棋，而不是吃子
					{
						MoveChess(old_idx,x,y);
						Map[old_x,old_y]=101;
					}
					else//吃子
					{
						if(Map[x,y]!=idx)//目标处棋子被吃掉
						{
							Qizi_Pic[Map[x,y]].Visible=false; 
							if(idx==101) //同时去掉
							{
								MoveChess(old_idx,x,y);	
								Map[x,y]=101;          
								Qizi_Pic[old_idx].Visible=false; 
							}
							else	MoveChess(old_idx,x,y);										
							Map[old_x,old_y]=101;
						}
						else//目标处棋子保留
						{ 
							Qizi_Pic[old_idx].Visible=false; 
							//MoveChess(old_idx,x,y);
							Map[old_x,old_y]=101;  
						}
					}
					IsMyTurn=true;
					reverse();
					break;
				case "over":
					statusBar1.Text = a[1]+"赢了此局";
					if(a[1]=="绿方")//将对方棋子全部去掉
					{
						for(int k=0;k<25;k++)
							Qizi_Pic[k].Visible=false;
					}
					else
					{
						for(int k=25;k<50;k++)
							Qizi_Pic[k].Visible=false;
					}
					can_go=false;
					button5.Enabled =true;
					break;
				case "reset":
					statusBar1.Text = "对方重新开局了";	
					Cls_Box();//隐藏棋盘所有棋子
					IsMyTurn= false;
					can_go=false;	
					button5.Enabled =true;							
					break;
				}
				}
				catch
				{
					//退出循环，结束线程
					break;
				}
			}
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			txt_port.Text="3333";
			txt_remoteport.Text ="4444"; 
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			txt_port.Text="4444";
			txt_remoteport.Text="3333";
		}
		private void button4_Click(object sender, System.EventArgs e)//联机
		{
			send("join|");
			//创建一个线程
			th = new Thread ( new ThreadStart ( read ) ) ;
			th_flag=true;
			//启动线程
			th.Start ( ) ;
			statusBar1.Text ="程序处于等待联机状态！" ;
			button4.Enabled =false;
		}
		private void Cls_Box()
		{
			for(int k=0;k<50;k++)
				Qizi_Pic[k].Visible=false;	
			button1.Visible=true; 
			button2.Visible=true; 
			button3.Visible=true; 
		}
		private void button5_Click(object sender, System.EventArgs e)//重新开始 
		{	
			Cls_Box();//隐藏棋盘所有棋子
			IsMyTurn= false;
			can_go=false;
			//reset();
			send("reset|");
			//button2.Enabled =false;	
			Reset_flag=true;
		}
		private void send(string info)
		{
			//创建UDP网络服务
			UdpClient SendUdp = new UdpClient ( ) ; 
			IPAddress remoteIP ;
			//判断IP地址的正确性
			try
			{
				remoteIP = IPAddress.Parse ( txt_IP.Text );
			}
			catch
			{
				MessageBox.Show ( "请输入正确的IP地址！" , "错误" ) ;
				return ;
			}
			IPEndPoint remoteep = new IPEndPoint ( remoteIP , Convert.ToInt32 (txt_remoteport.Text )) ;
			Byte [] buffer = null ;
			Encoding enc = Encoding.Unicode ; 
			string str = info ;
			buffer = enc.GetBytes ( str.ToCharArray ( ) ) ;
			//传送信息到指定计算机的txt_remoteport端口号
			SendUdp.Send ( buffer , buffer.Length , remoteep ) ;
			//textBox1.Clear ( ) ;
			//关闭UDP网络服务
			SendUdp.Close ( ) ;
		}
		private void button6_Click(object sender, System.EventArgs e)
		{
			ReadFlag=false;	
			Application.ExitThread(); 
			Application.Exit(); 
		
		}
		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//if(th_flag==true)
			//if(th.IsAlive) 
			th.Abort();
			Application.ExitThread(); 
			Application.Exit(); 
		}
	}
}

