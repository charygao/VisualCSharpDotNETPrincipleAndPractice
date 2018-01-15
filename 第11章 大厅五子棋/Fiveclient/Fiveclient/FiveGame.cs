using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fiveclient
{
    public partial class FiveGame : Form
    {
        /// <summary>
        /// 是否轮到我
        /// </summary>
        private bool Myturn;
        Bitmap oldbmp, usingbmp; IsWin iswin; gobang five;
        private bool onebodyin = false;
        static public bool isplaying = false;
        static public string speakmessage = "";
        static public string returnid = "";
        static public string reip = "";
        static public string relevel = "";
        NetWork network = new NetWork();
        string infor, oldinfor;        
        public FiveGame()
        {
            InitializeComponent();
        }

        private void FiveGame_Load(object sender, EventArgs e)
        {
            //if(speakmessage != "")
            //{
            //    getmessage(speakmessage);
            //    speakmessage = "";
            //} 
            listBox1.Items.Add(Fivehouse.inreguser+"进入了游戏！");
            usingbmp = oldbmp = new Bitmap(this.pictureBox1.Image);
            listView1.Items.Add(Fivehouse.inreguser, 0);
            listView1.Items[0].SubItems.Add("1");
            listView1.Items[0].SubItems.Add(Convert.ToString(NetWork.getmyIP()));

            
        }
        private void UpdateControls(bool onServer)
        {
                       
            buildGamebutton.Enabled = !onServer;
            Joinbutton.Enabled = !onServer;
            Rebuildbutton.Enabled = onServer;
            overgame.Enabled = onServer;
            StopNetbutton.Enabled = onServer;
            if (onServer)
            {
                status.Text = "连接中...";
            }
            else
            {
                status.Text = "断开连接";
            }
        }
        private void sendmsg_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(Fivehouse.inreguser+"说:"+ userspeak.Text);
            string speakout=userspeak.Text.ToString();
            string userid=Fivehouse.inreguser.ToString();
            network.Send(speakout, userid);
           // getmessage(speakmessage);
            
        }
        public void getmessage(string msg,string id)
        {
           
            listBox1.Items.Add(id + "说:"+msg);            
          
        }
       
        private void Rebuildbutton_Click(object sender, EventArgs e)
        {
            
            usingbmp = oldbmp = new Bitmap(this.pictureBox1.Image);
            pictureBox1.Enabled = true;
            this.pictureBox1.Invalidate();            
            this.pictureBox1.Refresh();            
            //this.panel1.Invalidate(); 
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
                if (onebodyin)
                try
                {
                    five.pointx = e.X - 21;
                    five.pointy = e.Y - 24;
                    five.cheesemove(this.pictureBox1, this.Myturn);
                }
                catch
                {
                }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(this.Myturn)
			{
				if(five.CanDown())
				{ 
					try
					{
						string sendinfor=five.cellx.ToString()+"."+five.celly.ToString()+"."+(five.myturn);
						network.Send(sendinfor);
						string t1,t2;
						this.pictureBox1.Image=five.DownthePoint(out t1,out t2);		
						this.label1.Text=t1;
						this.label2.Text=t2;				
						
					
						Myturn=false;
					}
					catch(Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
                	
			}
			try
			{
				if(iswin.Win(five.cellx,five.celly)==5) 
				{
					MessageBox.Show("游戏结束,白方胜利");
					//this.pictureBox1.Enabled=false;
                    this.pictureBox1.Invalidate();
					this.st.Text="游戏结束,白方胜利";
					//this.timer1.Stop();
					//this.network.StopListen();
				}
				if(iswin.Win(five.cellx,five.celly)==-5) 
				{
					MessageBox.Show("游戏结束,黑方胜利");
					//this.pictureBox1.Enabled=false;
                    this.pictureBox1.Invalidate();
					//this.timer1.Stop();
					//this.network.StopListen();
				}
			}
			catch
			{
				this.st.Text="游戏还没有开始，无法下棋";
			}
			
			
		}

        private void NewGamebutton_Click(object sender, EventArgs e)
        {
            IPtextBox.Text = Convert.ToString(NetWork.getmyIP());
            listBox1.Items.Add(Fivehouse.inreguser + "建立游戏，等待玩家进入");
            UpdateControls(true);
            five=new gobang();
			five.AddBmp(usingbmp,new Bitmap(this.pictureBox4.Image),new Bitmap(this.pictureBox5.Image));
			iswin=new IsWin(five.down);
			this.pictureBox1.Enabled=true;
			this.pictureBox1.Image=oldbmp;
			this.pictureBox1.Refresh();
			network.Listen();
			this.timer1.Start();
			this.Myturn=true;
			this.onebodyin=false;
            
        }
        private void startchess()
        {
            IPtextBox.Text = Convert.ToString(NetWork.getmyIP());
            //listBox1.Items.Add(Fivehouse.inreguser + "建立游戏，等待玩家进入");
            UpdateControls(true);
            five = new gobang();
            five.AddBmp(usingbmp, new Bitmap(this.pictureBox4.Image), new Bitmap(this.pictureBox5.Image));
            iswin = new IsWin(five.down);
            this.pictureBox1.Enabled = true;
            this.pictureBox1.Image = oldbmp;
            this.pictureBox1.Refresh();
            network.Listen();
            this.timer1.Start();
            this.Myturn = true;
            this.onebodyin = false;

        }
        private void Joinbutton_Click(object sender, EventArgs e)
        {
            if(this.IPtextBox.Text=="") 
			{
				MessageBox.Show("对方IP还没有配置，请点击配置");
				return;
			}
			network.IP=IPtextBox.Text;
			string sta="";
			network.Send(ref sta,NetWork.getmyIP()+"加入游戏！");
			if(sta=="")
			{
				startchess();
				listBox1.Items.Add("加入对方主机成功！游戏建立");
                string userid = Fivehouse.inreguser.ToString();
                string userip=Convert.ToString(NetWork.getmyIP());
                network.Send(userid,userip,"1");
				this.onebodyin=true;
				this.Joinbutton.Enabled=false;
				this.buildGamebutton.Enabled=false;
                isplaying = true;

			}
			else
			{
				this.st.Text=sta;
			}
			this.Myturn=false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.st.Text = this.network.sta;
            string nowinfor;
            infor = this.network.infor;
            if (oldinfor != infor)//有新消息
            {
             //   this.netinforlable.Text = infor;
                try
                {
                    int dot = infor.IndexOf(".");
                    five.cellx = Convert.ToInt32(infor.Substring(0, dot));
                    nowinfor = infor.Substring(dot + 1);
                    dot = nowinfor.IndexOf(".");
                    five.celly = Convert.ToInt32(nowinfor.Substring(0, dot));
                    nowinfor = nowinfor.Substring(dot + 1);
                    five.myturn = Convert.ToBoolean(nowinfor);
                    string t1, t2;
                    this.pictureBox1.Image = five.DownthePoint(out t1, out t2);	//对方下棋

                    this.label1.Text = t1;
                    this.label2.Text = t2;
                    if (iswin.Win(five.cellx, five.celly) == 5)
                    {

                        this.st.Text = "游戏结束,白方胜利";
                        this.timer1.Stop();
                        //this.network.StopListen();
                        this.pictureBox1.Enabled = false;
                    }
                    if (iswin.Win(five.cellx, five.celly) == -5)
                    {

                        this.st.Text = "游戏结束,黑方胜利";
                        this.timer1.Stop();
                       // this.network.StopListen();
                        this.pictureBox1.Enabled = false;
                    }
                    this.Myturn = true;
                }
                catch
                {
                    this.st.Text = infor;
                    try
                    {
                        if (infor.IndexOf("加") > 0) onebodyin = true;
                        string joinedip = infor.Substring(0, infor.IndexOf("加"));
                        IPtextBox.Text = network.IP = joinedip;
                    }
                    catch
                    {

                    }
                }
            }
            oldinfor = infor;
        }

        private void IPtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void userspeak_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void StopNetbutton_Click(object sender, EventArgs e)
        {
            network.StopListen();
            UpdateControls(false);
        }

        private void overgame_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            IPtextBox.Text = Fivehouse.other_ip;  //对方IP *********        
            if (speakmessage != "" && returnid!="")
            {
                getmessage(speakmessage,returnid);
                speakmessage = "";
                returnid = "";
            }
            if (returnid != "" && reip != "" & relevel != "")
            {
                setuser(returnid, reip, relevel);
                reip = "";
                returnid = "";
                relevel ="";
            }
        }
        private void setuser(string uid,string uip,string ulevel)
        {
            //string ll=Convert.
            listView1.Items.Add(uid, 0);
            listView1.Items[0].SubItems.Add(ulevel);
            listView1.Items[0].SubItems.Add(uip);
        }

        private void FiveGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer2.Enabled = false;
        }       
		
        }        
    }

