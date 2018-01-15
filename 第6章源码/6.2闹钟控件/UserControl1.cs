using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
//右键解决方案，添加控件测试项目，右键控件测试，设置项目依赖项，设置控件测试为启动项目
namespace clock
{
	/// <summary>
	/// UserControl1 的摘要说明。
	/// </summary>
public delegate void My_EventHandler(DateTime pdteTime,string pstrMessage); //我添加的委托
    public class myclock : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label lbTime;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;
		//在通用区域声明
		private Font myFont=new Font("宋体", 21.75F);
		private bool TimerEnable=false;
		private string ShowCont;
		private bool _visible=true;
		private string message_context="时间到了";
		//定义一个事件
	    public event My_EventHandler OnTime;            //**********************新建事件
        int alreadyrun = 0;
public myclock()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
			//将事件与委托关联起来,通过委托调用my_method2
            this.OnTime += new My_EventHandler(my_method2); //*************************绑定;	
		}
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
            this.components = new System.ComponentModel.Container();
            this.lbTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbTime
            // 
            this.lbTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.ForeColor = System.Drawing.Color.Coral;
            this.lbTime.Location = new System.Drawing.Point(-2, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(151, 33);
            this.lbTime.TabIndex = 0;
            this.lbTime.Text = "dd:dd:dd";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // myclock
            // 
            this.AllowDrop = true;
            this.AutoSize = true;
            this.Controls.Add(this.lbTime);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.Name = "myclock";
            this.Size = new System.Drawing.Size(146, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

public string GetTime()
		{
			string TimeInString="";
			int hour=DateTime.Now.Hour;
			int min=DateTime.Now.Minute;
			int sec=DateTime.Now.Second;

			TimeInString=(hour < 10)?"0" + hour.ToString() :hour.ToString();
			TimeInString+=":" + ((min<10)?"0" + min.ToString() :min.ToString());
			TimeInString+=":" + ((sec<10)?"0" + sec.ToString() :sec.ToString());
			return TimeInString;
		}
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.lbTime.Text=GetTime(); 
			if (ShowCont!=""&& this.lbTime.Text==ShowCont)
				OnTime(DateTime.Now, message_context);
		}
		//组件中的Visible属性，控件中字体是否可见
[DefaultValue(true),Description("控件中字体是否可见"),Category("Appearance")] 
public  bool FontVisible
		{
			get{  return _visible ;}
			set
			{
				_visible = value;
				this.lbTime.Visible=value;//标签Visible属性			    
			}
		}
		//定时是否启动
public bool Timer_Enable
		{
			get{  return TimerEnable ;}
			set
			{
				TimerEnable = value;
				this.timer1.Enabled=TimerEnable;	
			}
		}
		//Show_IntervalInterval属性的循环延迟（单位：毫秒）。默认为1000。
[DefaultValue(100),Description("循环延迟 单位：毫秒"),Category("Appearance")] 
public  int Show_Interval  //只读
		{
			get{  return timer1.Interval ;}
		}
//SetCall：设置闹铃时间。格式为“ 时：分：秒”；
		[Description("闹铃时间,格式为 时：分：秒")] 
public string SetCall
		{
			get{  return ShowCont ;}
			set
			{
				ShowCont= value;
			}
		}
		private void  my_method2(DateTime pdteTime,string pstrMessage)//*************************新建消息
		{
            //alreadyrun++;
            //if (alreadyrun == 1)
            //{
                DialogResult s = MessageBox.Show(pstrMessage);
                if (s == DialogResult.OK)
                    alreadyrun = 0;
            //}
            
		}
public Font set_myFont
		{   
			get{  return myFont ;}
			set
			{
				myFont=value;
				this.lbTime.Font=myFont; 
				this.lbTime.Invalidate();
			}
		}
[DefaultValue("HotTrack"),Description("字体颜色"),Category("Appearance")] 
		public override Color ForeColor
		{
			get 
			{
				return this.lbTime.ForeColor;
			}
			set 
			{
				this.lbTime.ForeColor=value;
				this.Invalidate();
			}
		}
public void AddTime(string pdteTime,string pstrMessage)
		{
            ShowCont=pdteTime;
			message_context=pstrMessage;
		}
	}
}
