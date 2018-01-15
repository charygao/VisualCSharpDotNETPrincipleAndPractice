using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;


namespace Test
{
	/// <summary>
	/// CH7_12 的摘要说明。
	/// </summary>
	public class test : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Repeater Repeater1;
		protected System.Web.UI.WebControls.TextBox TextBox1;	
        protected static System.Text.StringBuilder dan_head=new System.Text.StringBuilder(),duo_head=new System.Text.StringBuilder(),pan_head=new System.Text.StringBuilder(),jian_head=new System.Text.StringBuilder(),bian_head=new System.Text.StringBuilder(),tian_head=new System.Text.StringBuilder();
		protected static int num_of_kong;
		protected System.Web.UI.WebControls.Label xuehao;
		protected System.Web.UI.WebControls.Label name;
		protected System.Web.UI.WebControls.Button save1;
		protected System.Web.UI.WebControls.Button Submit1;
		protected System.Web.UI.WebControls.Repeater rpCust1;
		protected System.Web.UI.WebControls.Repeater rpCust2;
		protected System.Web.UI.WebControls.Repeater rpCust3;
		protected System.Web.UI.WebControls.Repeater rpCust4;
		protected System.Web.UI.WebControls.Label xuehao2;
		protected System.Web.UI.WebControls.Label name2;
		protected System.Web.UI.WebControls.Button save2;
		protected System.Web.UI.WebControls.Repeater rpCust5;
		protected System.Web.UI.WebControls.Repeater rpCust6;
		protected System.Web.UI.WebControls.Button Submit;
		protected static DataSet[] ds=new DataSet[6];
		protected System.Web.UI.HtmlControls.HtmlInputText hid;
		protected System.Web.UI.WebControls.Button BtnDown;

	
		private void Page_Load(object sender, System.EventArgs e)
		{ 
			Response.Buffer=true;
			Response.ExpiresAbsolute=DateTime.Now.AddSeconds(-1);
			Response.Expires=0;
			Response.CacheControl="no-cache";

			MyData md;
			if(Session["Student_ID"]==null)
			{
				new MyMethods().AlertAndRedirect("'必须登陆才能进行考试！", "/test/login.aspx");
				return;
			}
			DateTime FirstLoginTime=DateTime.Parse(Session["logintime"].ToString());
			System.TimeSpan remain_time=DateTime.Now.Date.AddDays(1)-FirstLoginTime;//计算第一次登陆时间距离第二日凌晨的时差
			if(remain_time.TotalSeconds<7200)
			{//如果不足120分钟，则考试时间限定在凌晨前１分钟结束
				remain_time=DateTime.Now.Date.AddDays(1)-DateTime.Now;
				Session["Time"]=(int)remain_time.TotalSeconds-60;
			}
			else
			{//否则计算计算此时到考试登陆之后１２０分钟的时差
				remain_time=DateTime.Now-FirstLoginTime;
				Session["Time"]=7200-(int)remain_time.TotalSeconds;
			}	
			if(!IsPostBack)
			{
				
				
				xuehao.Text=Convert.ToString(Session["Student_ID"]);//将学号显示页面上方
				name.Text=Convert.ToString(Session["Student_name"]);//将姓名显示在页面上方
				xuehao2.Text=xuehao.Text;//将学号显示页面下方
				name2.Text=name.Text;//将姓名显示在页面下方
				int shijuan_total,curr_tixing_num=0;//前者记录可选试卷数,后者记录该试卷当前题型的的序号
				string StrSQL;
				OleDbDataReader DR;
				if(Session["shijuanhao"]!=null)
				{//如果学生非第一次登陆
					StrSQL="select * from 分值 where 试卷号='"+Session["shijuanhao"].ToString()+"'";
					md=new MyData(Application["connstr"].ToString());
					DR=md.eSelect(StrSQL);
					DR.Read();
					BtnDown.Visible=true;
					
				}
				else
				{//如果学生第一次登陆
					StrSQL="select count(*) as 试卷数 from 分值 where 使用日期=#"+DateTime.Now.ToShortDateString()+"#" ;	//统计可选试卷数
					md=new MyData(Application["connstr"].ToString());
					DR=md.eSelect(StrSQL);
					bool ishasdata=DR.Read(); 			
					shijuan_total=Convert.ToInt16(DR["试卷数"]);
					DR.Close();
					md.CloseConn();
					Random r = new Random(unchecked((int)DateTime.Now.Ticks));//随机到的试卷的位置
					int curr_shijuan_num=(int)((shijuan_total)*r.NextDouble()+1); 
					StrSQL="select * from 分值 where 使用日期=#"+DateTime.Now.ToShortDateString()+"# order by 试卷号";
					md=new MyData(Application["connstr"].ToString());
					DR=md.eSelect(StrSQL);
					for(int i=1;i<=curr_shijuan_num;i++)		
						DR.Read();//定位到该试卷
					Session["shijuanhao"]=Convert.ToString(DR["试卷号"]);
					
					new MyData(Application["connstr"].ToString()).eInsertUpdateDelete("update 学生 set 本次试卷号='"+Session["shijuanhao"].ToString()+"' where 学号='"+xuehao.Text+"'");//记录学生首次登陆使用的试卷
				}
				
				for(int i=0;i<=5;i++)
				{//设置各题型题头信息的显示
					string curr_tixing=null;
					System.Text.StringBuilder curr_head=null;
					GetHeadVariables(ref curr_tixing,ref curr_head,i);//该方法可根据i值,返回不同的题型给curr_tixing,返回不同的用来存题头信息的变量的引用
					string str_tl_last,str_fz_last;
					if(i==2)
					{//填空题
						str_tl_last="题空量";
						str_fz_last="题每空分值";
					}
					else
					{//其他题
						str_tl_last="题量";
						str_fz_last="题每题分值";
					}
					
					if (Convert.ToString(DR[curr_tixing+str_tl_last])!="0")
					{//如果当前题型的题量不为0,则设置题头信息
						curr_tixing_num+=1;
						curr_head.Remove(0,curr_head.ToString().Length);
						curr_head.Append(num_to_word(curr_tixing_num)+"、"+curr_tixing+"题（共"+Convert.ToString(DR[curr_tixing+str_tl_last])+"题，每题"+Convert.ToString(DR[curr_tixing+str_fz_last])+"分)");
					}
					else
					{//否则题头信息为空
						curr_head.Append("");
					}

				}
				
				DR.Close();
				md.CloseConn();
				
				
				for(int j=0;j<=5;j++)
				{//将本试卷各题型的试题取出,并绑定到相应的Repeater
					Repeater rp=null;
					string tixing="";
					switch(j)
					{
						case 0:tixing="单选题";rp=rpCust1;break;
						case 1:tixing="多选题";rp=rpCust2;break;
						case 2:tixing="判断题";rp=rpCust3;break;
						case 3:tixing="简答题";rp=rpCust4;break;
						case 4:tixing="编程题";rp=rpCust5;break;
						case 5:tixing="填空题";rp=rpCust6;break;
					}
					String strSQL="select  * from "+tixing+",组卷 where "+tixing+".id=组卷.试题编号 and 组卷.题型='"+tixing+"' and 组卷.试卷号='"+Session["shijuanhao"].ToString()+"' order by 顺序号 ASC"; 
					new MyMethods().Repeater_bind(rp,ref ds[j],strSQL,Application["connstr"].ToString());
					
				}
			}
			else
			{
					
			}
			
		
		}
		private void GetHeadVariables(ref string tixing,ref System.Text.StringBuilder curr_head,int i)
		{
					switch(i)
					{
						case 0: tixing="单选";curr_head=dan_head;break;
						case 1: tixing="多选";curr_head=duo_head;break;
						case 2: tixing="填空";curr_head=tian_head;break;
						case 3: tixing="判断";curr_head=pan_head;break;
						case 4: tixing="简答";curr_head=jian_head;break;
						case 5: tixing="编程";curr_head=bian_head;break;

					}
					
		}
	
		private string num_to_word(int num)
		{
			string word;
			switch(num)
			{
				case 1:
					  word="一";
					  break;
				case 2:
					word="二";
					break;
				case 3:
					word="三";
					break;
				case 4:
					word="四";
					break;
				case 5:
					word="五";
					break;
				case 6:
					word="六";
					break;
				default:
					word="";
					break;
			}
			return word;
		}
		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.save1.Click += new System.EventHandler(this.save_Click);
			this.Submit1.Click += new System.EventHandler(this.Submit_Click);
			this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
			this.rpCust1.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.ItemDataBound);
			this.rpCust1.ItemCommand += new System.Web.UI.WebControls.RepeaterCommandEventHandler(this.rpCust1_ItemCommand);
			this.rpCust2.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.ItemDataBound);
			this.rpCust6.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.ItemDataBound);
			this.rpCust3.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.ItemDataBound);
			this.rpCust4.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.ItemDataBound);
			this.rpCust5.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.ItemDataBound);
			this.save2.Click += new System.EventHandler(this.save_Click);
			this.Submit.Click += new System.EventHandler(this.Submit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		public string Changechr(string str)
		{
			str=str.Replace("<","&lt;");
			str=str.Replace(">","&gt;");
			str=str.Replace(" ","&nbsp;");
			str=str.Replace("\n","<br>");
			return str;

		}
		
        private void  pan_juan()
		{
			
			//***************************************取出各分值
	        String strSQL="select * from 分值 where 试卷号='"+Session["shijuanhao"].ToString()+"'";
			MyData md=new MyData(Application["connstr"].ToString());
			OleDbDataReader dr=md.eSelect(strSQL);
			dr.Read();
			int dan_fz,duo_fz,pan_fz;
			dan_fz=Convert.ToInt16(dr["单选题每题分值"]);
			duo_fz=Convert.ToInt16(dr["多选题每题分值"]);
			pan_fz=Convert.ToInt16(dr["判断题每题分值"]);		
			dr.Close();
			md.CloseConn();
			//*************************************END
           
			for(int j=0;j<=2;j++)
			{ //每次循环对一种客观题进行阅卷
				int everyscore=0;//存储本次循环所处理的题型的每题(空)分值
				Repeater rp=null;
				switch(j)
				{
					case 0:rp=rpCust1;everyscore=dan_fz;break;
					case 1:rp=rpCust2;everyscore=duo_fz;break;
					case 2:rp=rpCust3;everyscore=pan_fz;break;
				}
				for(int i=0;i<rp.Items.Count;i++)
				{
					string answer="";//存储该考生对当前试题所做答案
					int score;//存储当前试题得分
					switch(j)
					{
						case 0:answer=find_dan_checked(i);break;
						case 1:answer=find_duo_checked(i);break;
						case 2:answer=find_pan_checked(i);break;
					}
					if(answer!=ds[j].Tables[0].Rows[i]["正确答案"].ToString())
						score=0;
					else
					    score=everyscore;
				    strSQL="update 答卷 set 得分="+score+" where 学号='"+Session["Student_ID"]+"' and 试卷号='"+Session["shijuanhao"].ToString()+"' and 题型='"+ds[j].Tables[0].Rows[i]["题型"].ToString()+"' and 试题编号='"+ds[j].Tables[0].Rows[i]["试题编号"].ToString()+"'";
					
					new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(strSQL);//为该生所做的当前题型的当前试题给分.		    
				}
				
			}
			strSQL="update 学生 set 考试登陆时间=#"+DateTime.Now.Date.AddDays(1)+"# where 学号='"+xuehao.Text+"'";
			new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(strSQL);	
			Response.Write("<script>alert('试卷提交成功,考试结束!');window.opener=null;window.close();</script>");
		}

	
		private void Submit_Click(object sender, System.EventArgs e)
		{
			save();
			pan_juan();
		}

		
	
		private void save()
		{
		  
			String StrSQL="Delete from 答卷 where 学号='"+Session["Student_ID"].ToString()+"' and 试卷号='"+Session["shijuanhao"].ToString()+"'";
			new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(StrSQL);//删除该生上次保存的该试卷的答卷
			for(int j=0;j<=5;j++)
			{//每次循环保存一种题型的答卷状态       
				string tixing="",answerchecked="";
				for (int i=0;i<ds[j].Tables[0].Rows.Count;i++)
				{//对存有当前题型所有试题的DataSet进行遍历,每次存储当前题型中一个试题的答卷状态
					switch(j)
					{
						case 0:tixing="单选题";answerchecked=find_dan_checked(i);break;
						case 1:tixing="多选题";answerchecked=find_duo_checked(i);break;
						case 5:tixing="填空题";answerchecked=find_tian_content(i);break;
						case 2:tixing="判断题";answerchecked=find_pan_checked(i);break;
						case 3:tixing="简答题";answerchecked=((TextBox)rpCust4.Items[i].FindControl("txt_jian")).Text;break;
						case 4:tixing="编程题";answerchecked=((TextBox)rpCust5.Items[i].FindControl("txt_bian")).Text;break;

					}
				
					StrSQL="insert into 答卷(学号,试卷号,题型,试题编号,学生答案) values('"+Session["Student_ID"]+"','"+ds[j].Tables[0].Rows[i]["试卷号"]+"','"+tixing+"','"+ds[j].Tables[0].Rows[i]["试题编号"]+"','"+answerchecked+"')";
					new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(StrSQL);
				}
			}
			
		}
		private string find_duo_checked(int curr_row)
		{
			CheckBox rb1=(CheckBox)rpCust2.Items[curr_row].FindControl("cb_xxa");
			CheckBox rb2=(CheckBox)rpCust2.Items[curr_row].FindControl("cb_xxb");
			CheckBox rb3=(CheckBox)rpCust2.Items[curr_row].FindControl("cb_xxc");
			CheckBox rb4=(CheckBox)rpCust2.Items[curr_row].FindControl("cb_xxd");
			string result="";
			if (rb1.Checked)
				result+=rb1.Text;
			if(rb2.Checked)
				result+=rb2.Text;
			if(rb3.Checked)
				result+=rb3.Text;
			if(rb4.Checked)
				result+=rb4.Text;
			return result;

		}
		private string find_tian_content(int curr_row)
		{
			string result;
			TextBox tb1=(TextBox)rpCust6.Items[curr_row].FindControl("txt_tk1");
			TextBox tb2=(TextBox)rpCust6.Items[curr_row].FindControl("txt_tk2");
			TextBox tb3=(TextBox)rpCust6.Items[curr_row].FindControl("txt_tk3");
			TextBox tb4=(TextBox)rpCust6.Items[curr_row].FindControl("txt_tk4");
			result=tb1.Text;
			int num_of_kong=Convert.ToInt16(ds[5].Tables[0].Rows[curr_row][3].ToString());
			if (num_of_kong>1)
			{
				result+=","+tb2.Text;
				if(num_of_kong>2)
				{
					result+=","+tb3.Text;
					if(num_of_kong>3)
						result+=","+tb4.Text;
				}
			}
			return result;
		}
		private string find_dan_checked(int curr_row)
		{
			RadioButton rb1=(RadioButton)rpCust1.Items[curr_row].FindControl("rb_xxa");
			RadioButton rb2=(RadioButton)rpCust1.Items[curr_row].FindControl("rb_xxb");
			RadioButton rb3=(RadioButton)rpCust1.Items[curr_row].FindControl("rb_xxc");
			RadioButton rb4=(RadioButton)rpCust1.Items[curr_row].FindControl("rb_xxd");
			string result="";
			if (rb1.Checked)
				result=rb1.Text;
			if (rb2.Checked)
				result=rb2.Text;
			if (rb3.Checked)
				result=rb3.Text;
			if (rb4.Checked)
				result=rb4.Text;
			return result;
		}
		private string find_pan_checked(int curr_row)
		{
			RadioButton rb1=(RadioButton)rpCust3.Items[curr_row].FindControl("rb_pan1");
			RadioButton rb2=(RadioButton)rpCust3.Items[curr_row].FindControl("rb_pan2");
			string result="";
			if (rb1.Checked)
				result=rb1.Text;
			if (rb2.Checked)
				result=rb2.Text;
			return result;
		}

		private void save_Click(object sender, System.EventArgs e) 
		{
		  save();
		}

	
		private void ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			Repeater rp=(Repeater)sender;
			string curr_lbl_name="",curr_lbl_text="";
			switch(rp.ID)
			{//根据当前控件的不同,选择不同的用来存放题头的label名和预备显示的题头信息
				case "rpCust1":curr_lbl_name="lbl_dan";curr_lbl_text=dan_head.ToString();break;
				case "rpCust2":curr_lbl_name="lbl_duo";curr_lbl_text=duo_head.ToString();break;
				case "rpCust3":curr_lbl_name="lbl_pan";curr_lbl_text=pan_head.ToString();break;
				case "rpCust4":curr_lbl_name="lbl_jian";curr_lbl_text=jian_head.ToString();break;
				case "rpCust5":curr_lbl_name="lbl_bian";curr_lbl_text=bian_head.ToString();break;
				case "rpCust6":curr_lbl_name="lbl_tian";curr_lbl_text=tian_head.ToString();break;
			}
			
			if (rp.ID=="rpCust6")
			{//如果当前控件为rpCust6即填空题所用Repeater控件,则要根据当前填空题的填空数,显示相应数量的用来回答填空问题的TextBox
				
				try
				{
					TextBox tb2=(TextBox)e.Item.FindControl("txt_tk2");
					TextBox tb3=(TextBox)e.Item.FindControl("txt_tk3");
					TextBox tb4=(TextBox)e.Item.FindControl("txt_tk4");
					int num_of_kong=Convert.ToInt16(ds[5].Tables[0].Rows[e.Item.ItemIndex][3].ToString());
						if (num_of_kong>1)
						{
							tb2.Visible=true;
							if(num_of_kong>2)
							{
								tb3.Visible =true;
								if(num_of_kong>3)
									tb4.Visible =true;
							}
						}
				}
				catch{}
			}
			try
			{//为当前Repeater控件设置该控件中所绑定题型的题头
				Label lb=(Label)e.Item.FindControl(curr_lbl_name);
				lb.Text=curr_lbl_text;
			}
			catch
			{
			}

		}

		private void rpCust1_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{
		
		}

		private void BtnDown_Click(object sender, System.EventArgs e)
		{
			
			String StrSQL="select 答卷.试题编号 as 试题编号,答卷.题型 as 题型,答卷.学生答案 as 学生答案 from 答卷,分值 where 答卷.试卷号=分值.试卷号 and 答卷.学号='"+Session["Student_ID"].ToString()+"' and 分值.使用日期=#"+DateTime.Now.ToShortDateString()+"#";
			MyData md=new MyData(Application["connstr"].ToString());//从答卷表中将考试日期为今日的与该生有关的所有试题取出
			OleDbDataReader DR=md.eSelect(StrSQL);
			while(DR.Read())
			{//如果能够取出试题,则遍历所有试题
				if(DR["学生答案"].ToString()!="")
				{//如果当前试题的学生答案字段不为空
					switch(DR["题型"].ToString())
					{
						case "单选题"://如果当前试题为单选题

							for(int i=0;i<rpCust1.Items.Count;i++)
							{//从rpCust1控件中找出该试题,并将学生答案标记在相应的RadioButton上
								Label lbl=(Label)rpCust1.Items[i].FindControl("lbl_dan_stbh");//lbl_dan_stbh里存有当前试题的试题号
								if(DR["试题编号"].ToString()==lbl.Text)
								{
									string rb_name="";
									switch(DR["学生答案"].ToString())
									{
										case "A":
											rb_name="rb_xxa";
											break;
										case "B":
											rb_name="rb_xxb";
											break;
										case "C":
											rb_name="rb_xxc";
											break;
										case "D":
											rb_name="rb_xxd";
											break;
									}
									RadioButton rb=(RadioButton)rpCust1.Items[i].FindControl(rb_name);
									rb.Checked=true;
								}
							}
							break;
						case "多选题"://如果当前试题为多选题

							for(int i=0;i<rpCust2.Items.Count;i++)
							{//从rpCust2控件中找出该试题,并将学生答案标记在相应的CheckBox上
								Label lbl=(Label)rpCust2.Items[i].FindControl("lbl_duo_stbh");//lbl_duo_stbh里存有当前试题的试题号
								if(DR["试题编号"].ToString()==lbl.Text)
								{
									string cb_name="";
									for(int j=0;j<DR["学生答案"].ToString().Length;j++)
									{
										switch(DR["学生答案"].ToString().Substring(j,1))
										{
											case "A":
												cb_name="cb_xxa";
												break;
											case "B":
												cb_name="cb_xxb";
												break;
											case "C":
												cb_name="cb_xxc";
												break;
											case "D":
												cb_name="cb_xxd";
												break;
										}
									
										CheckBox cb=(CheckBox)rpCust2.Items[i].FindControl(cb_name);
										cb.Checked=true;
									}
								}
							}
							break;
						case "判断题"://如果当前试题为判断题

							for(int i=0;i<rpCust3.Items.Count;i++)
							{//从rpCust3控件中找出该试题,并将学生答案标记在相应的RadioButton上
								Label lbl=(Label)rpCust3.Items[i].FindControl("lbl_pan_stbh");//lbl_pan_stbh里存有当前试题的试题号
								if(DR["试题编号"].ToString()==lbl.Text)
								{
									string rb_name="";
									if(DR["学生答案"].ToString()=="对")
									       rb_name="rb_pan1";
									else
										   rb_name="rb_pan2";
									RadioButton rb=(RadioButton)rpCust3.Items[i].FindControl(rb_name);
									rb.Checked=true;
								}
							}
							break;
						case "简答题"://如果当前试题为简答题

							for(int i=0;i<rpCust4.Items.Count;i++)
							{//从rpCust4控件中找出该试题,并将学生答案输出在TextBox上
								Label lbl=(Label)rpCust4.Items[i].FindControl("lbl_jian_stbh");//lbl_jian_stbh里存有当前试题的试题编号
								if(DR["试题编号"].ToString()==lbl.Text)
								{
									TextBox tb=(TextBox)rpCust4.Items[i].FindControl("txt_jian");
									tb.Text=DR["学生答案"].ToString();
								}
							}
							break;
						case "编程题"://如果当前试题为编程题

							for(int i=0;i<rpCust5.Items.Count;i++)
							{//从rpCust5控件中找出该试题,并将学生答案输出在TextBox上
								Label lbl=(Label)rpCust5.Items[i].FindControl("lbl_bian_stbh");//lbl_bian_stbh里存有当前试题的试题编号
								if(DR["试题编号"].ToString()==lbl.Text)
								{
									TextBox tb=(TextBox)rpCust5.Items[i].FindControl("txt_bian");
									tb.Text=DR["学生答案"].ToString();
								}
							}
							break;
						case "填空题"://如果当前试题为填空题

							for(int i=0;i<rpCust6.Items.Count;i++)
							{//从rpCust6控件中找出该试题,并将学生答案输出在相应的TextBox上
								Label lbl=(Label)rpCust6.Items[i].FindControl("lbl_tian_stbh");//lbl_tian_stbh里存有当前试题的试题编号
								if(DR["试题编号"].ToString()==lbl.Text)
								{
									
									string[] daan=DR["学生答案"].ToString().Split(',');
									for(int j=1;j<=daan.Length;j++)
									{
										TextBox tb=(TextBox)rpCust6.Items[i].FindControl("txt_tk"+j);
										tb.Text=daan[j-1];
										if(j>0)
										{
											tb.Visible=true;
										}
										
									}
								}
							}
							break;
					}
				}
			}
			md.CloseConn();
		}
	}
}
