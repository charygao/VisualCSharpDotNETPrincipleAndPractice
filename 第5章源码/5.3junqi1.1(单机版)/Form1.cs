using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
namespace 四国军旗
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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		//在类class Form1中声明私有的数据成员变量
		private PictureBox[] Qizi_Pic; 
		private int Pic_Width;
		private int [ ]Q;
		private int [ , ]Map;
		bool _isDragging = false;
		bool Layout_Flag=true;//布阵标志
		bool first=true;//布阵时第一次单击标志
		int mouse_x, mouse_y;
		int old_x,old_y; //棋盘坐标
		int old_Left,old_Top;
		int tempx,tempy;//布阵时第一次单击坐标
		bool IsMyTurn;
		enum PlayerColor{Red,Black,Green,Glue}; 
		PlayerColor player;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Button button3;//棋子原始位置(像素)
		int r;//兵站间隔距离
	
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.qi_pan = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.button3 = new System.Windows.Forms.Button();
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(488, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(488, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 32);
			this.label2.TabIndex = 3;
			this.label2.Text = "label2";
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
			this.listBox1.Location = new System.Drawing.Point(488, 136);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(120, 184);
			this.listBox1.TabIndex = 6;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 464);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(640, 22);
			this.statusBar1.TabIndex = 7;
			this.statusBar1.Text = "欢迎使用快乐军旗1.0";
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
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(640, 486);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.qi_pan);
			this.Name = "Form1";
			this.Text = "军旗2.1";
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
			String filename="", path;
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
				if(i<50&&i>=25)
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
			PictureBox  picBox1=(PictureBox)sender;//将被击的赋给定义的picBox1变量
			int i=Convert.ToInt16(picBox1.Tag);				
			if(Q[i%25]==30||Q[i%25]==29)return; //地雷不能动
			if(IsBigHome(old_x,old_y))return;  //大本营中棋子不能动
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

				if(old_x==x&&old_y==y)return ;				
				if(IsmyChess2(idx)&&Go_Juge(old_x,old_y,x,y))//&&Q[idx%25]!=29 &&Q[idx%25]!=30不能走地雷与军旗	
				{
					go_chess(old_x,old_y,x,y,idx);

					PlaySound.Play(path+"move.wav");
					IsMyTurn=!IsMyTurn;
					reverse();
				}
				else //不能走棋
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
					
					if(player==PlayerColor.Red)MessageBox.Show("红胜利了");
					else MessageBox.Show("绿胜利了");					
					return;
				}					
				statusBar1.Text=Map[x,y].ToString(); 

			}	
		}
		private void reverse()
		{
			if(!IsMyTurn)
			{
				player=PlayerColor.Green ;
				statusBar1.Text= "该对方走棋";
			}
			else
			{
				player=PlayerColor.Red;
				statusBar1.Text= "该自己方走棋";
			}
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
			if(Map[old_x,old_y]==4 && y1==12)
				return false;
			if(Map[x1,y1]==4 && old_y==12)
				return false;//炸弹控件编号4，5,第一排(y1=12)不允许放置炸弹
			if(Map[old_x,old_y]==5 && y1==12)
				return false;
			if(Map[x1,y1]==5 && old_y==12)
				return false;//炸弹控件编号4，5,第一排(y1=12)不允许放置炸弹
			if(Map[old_x,old_y]==0 && !(x1==8&&y1==17||x1==10&&y1==17))
				return false;//自己的军旗控件编号0,只能放置在大本营
			if(Map[x1,y1]==0 && !(old_x==8&&old_y==17||old_x==10&&old_y==17))
				return false;//自己的军旗控件编号0,只能放置在大本营
			if(Q[Map[x1,y1]]==30 && !(old_y==16||old_y==17))
				return false;//第1，2，3，4排不允许放置地雷，
			if(Q[Map[old_x,old_y]]==30 && !(y1==16||y1==17))
				return false;//第1，2，3，4排不允许放置地雷，       
              
			return true;//其余情况均可以 

		}
		private bool Go_Juge(int old_x,int old_y,int x,int y)//判断走棋的位置是否适当
		{
			label1.Text=old_x.ToString()+"old_x:old_y"+old_y.ToString();
			label2.Text=x.ToString()+"x:y"+y.ToString()+Map[x,y].ToString() ;
			//是否是棋子区域
			if( (x<=6 && y>=1 && y<=6) || (x>=12 && y>=1 && y<=6) ||
				(x<=6 && y>=12 && y<=17) || (x>=12 && y>=12 && y<=17)|| y>17 )
				return false;
			//目标位置是自己方的棋子
			if(IsmyChess(x,y)) return false;

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

		private bool IsmyChess(int x,int y)//是否是自己放棋子
		{
			int idx=Map[x,y];
			if(idx==101)return false;
			else return IsmyChess2(idx);

		}
		private bool IsmyChess2(int idx)//根据索引判断是否是自己放棋子
		{
			if(IsMyTurn)
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
			begin_pos(2);	//从布阵棋谱文件中读取位置，放置棋子			
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
				label1.Text=x.ToString()+","+y.ToString()+","+idx.ToString()+";";
				if(idx!=101){MoveChess(idx,x,y);Qizi_Pic[idx].Visible=true; }
				listBox1.Items.Add(label1.Text);
			}
			Myfile.Close();			
		}
		private void write_qi_pu()
		{
			FileStream fw = new  FileStream("MyFile.txt",FileMode.Create,FileAccess.Write);
			//将棋子Map写入布阵文件中
			for(byte x=7;x<=11;x++)
				for(byte y=12;y<=17;y++)
				{
					fw.WriteByte(x);
					fw.WriteByte(y);
					fw.WriteByte((byte)Map[x,y]);
					label2.Text=x.ToString()+","+y.ToString()+","+Map[x,y].ToString()+"*";
					listBox1.Items.Add(label2.Text); 					
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
			get_message();
			IsMyTurn=true;
			player=PlayerColor.Red;
			statusBar1.Text= "自己Red方先走棋";
			string path = System.Windows.Forms.Application.StartupPath;// bin路径
			path += "\\..\\..\\wav\\";
			PlaySound.Play(path+"junqistart.wav");
		}
		private void get_message()//读取对方布阵棋子信息
		{
			//读取对方棋子
			FileStream Myfile = new  FileStream("MyFile2.txt",FileMode.Open,FileAccess.Read );
			int  x,y,idx;
			int x2,y2;
			int a,i;
			byte[ ]m=new byte[90]; //30*3；注意不是25*3
			for(i=0;(a=Myfile.ReadByte())!=-1;i++) 
				m[i]=(byte)a;
			Myfile.Close();	
			for(i=0;i<90;i+=3)
			{
				x=m[i];
				y=m[i+1]; 				
				x2=18-x;//OneConvertTwo(x,y,x2,y2)
				y2=18-y;
				idx=m[i+2]; 
				label1.Text=x2.ToString()+","+y2.ToString()+","+(idx+25).ToString()+"$";
				if(idx!=101){MoveChess(idx+25,x2,y2);Qizi_Pic[idx+25].Visible=true; }
				listBox1.Items.Add(label1.Text);
			}
		}


	}
}
