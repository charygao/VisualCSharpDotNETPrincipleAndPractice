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

namespace Test.admin
{
	/// <summary>
	/// adminzujuan 的摘要说明。
	/// </summary>
	public class adminzujuan : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_Title;
		protected System.Web.UI.WebControls.Panel panel_add;
		protected System.Web.UI.WebControls.TextBox TXTdantl;
		protected System.Web.UI.WebControls.TextBox TXTdanfz;
		protected System.Web.UI.WebControls.TextBox TXTduotl;
		protected System.Web.UI.WebControls.TextBox TXTduofz;
		protected System.Web.UI.WebControls.TextBox TXTtiankl;
		protected System.Web.UI.WebControls.TextBox TXTtianfz;
		protected System.Web.UI.WebControls.TextBox TXTpantl;
		protected System.Web.UI.WebControls.TextBox TXTpanfz;
		protected System.Web.UI.WebControls.TextBox TXTjiantl;
		protected System.Web.UI.WebControls.TextBox TXTjianfz;
		protected System.Web.UI.WebControls.TextBox TXTbiantl;
		protected System.Web.UI.WebControls.TextBox TXTbianfz;
		protected System.Web.UI.WebControls.TextBox TXTzjs;
		protected System.Web.UI.WebControls.DropDownList DDLdancqfs;
		protected System.Web.UI.WebControls.DropDownList DDLjianzj;
		protected System.Web.UI.WebControls.TextBox TXTjianzjtl;
		protected System.Web.UI.WebControls.Button BtnAddJian;
		protected System.Web.UI.WebControls.DataGrid Dg_jian;
		protected System.Web.UI.WebControls.DataGrid Dg_dan;
		protected System.Web.UI.WebControls.Button BtnAddDan;
		protected System.Web.UI.WebControls.TextBox TXTdanzjtl;
		protected System.Web.UI.WebControls.DropDownList DDLdanzj;
		protected System.Web.UI.WebControls.DropDownList DDLduocqfs;
		protected System.Web.UI.WebControls.Button BtnAddDuo;
		protected System.Web.UI.WebControls.TextBox TXTduozjtl;
		protected System.Web.UI.WebControls.DropDownList DDLduozj;
		protected System.Web.UI.WebControls.DropDownList DDLtiancqfs;
		protected System.Web.UI.WebControls.DataGrid Dg_tian;
		protected System.Web.UI.WebControls.Button BtnAddTian;
		protected System.Web.UI.WebControls.TextBox TXTtianzjtl;
		protected System.Web.UI.WebControls.DropDownList DDLtianzj;
		protected System.Web.UI.WebControls.DropDownList DDLpancqfs;
		protected System.Web.UI.WebControls.DataGrid Dg_pan;
		protected System.Web.UI.WebControls.Button BtnAddPan;
		protected System.Web.UI.WebControls.TextBox TXTpanzjtl;
		protected System.Web.UI.WebControls.DropDownList DDLpanzj;
		protected System.Web.UI.WebControls.Panel Panel_txtl;
		protected System.Web.UI.WebControls.Panel Panel_cqfs;
		protected System.Web.UI.WebControls.Button BtnCreate;
		protected System.Web.UI.WebControls.Panel Panel_dan;
		protected System.Web.UI.WebControls.Panel Panel_duo;
		protected System.Web.UI.WebControls.Panel Panel_tian;
		protected System.Web.UI.WebControls.Panel Panel_pan;
		protected System.Web.UI.WebControls.Button BtnPre;
		protected System.Web.UI.WebControls.DataGrid Dg_duo;
		protected System.Web.UI.WebControls.DropDownList DDLjiancqfs;
		protected System.Web.UI.WebControls.Label lbl_dan;
		protected System.Web.UI.WebControls.Label lbl_duo;
		protected System.Web.UI.WebControls.Label lbl_tian;
		protected System.Web.UI.WebControls.Label lbl_pan;
		protected System.Web.UI.WebControls.Label lbl_jian;
		protected System.Web.UI.WebControls.Label lbl_dan_yx;
		protected System.Web.UI.WebControls.Label lbl_duo_yx;
		protected System.Web.UI.WebControls.Label lbl_tian_yx;
		protected System.Web.UI.WebControls.Label lbl_pan_yx;
		protected System.Web.UI.WebControls.Label lbl_jian_yx;
		protected System.Web.UI.WebControls.Panel Panel_jian;
		protected System.Web.UI.WebControls.TextBox TXTsjsyrq;
		protected System.Web.UI.WebControls.Button BtnNext;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!IsPostBack)
			{
				if(Session["Teacher_ID"]==null)
				{
					new MyMethods().AlertAndRedirect("您尚未登录！", "/test/login.aspx");
					return;
				}
				 lbl_Title.Text="组卷管理";
				DropDownList[] ddl={DDLdanzj,DDLduozj,DDLtianzj,DDLpanzj,DDLjianzj};
				new MyMethods().fill_dropdownlist(ddl,Application["connstr"].ToString(),"select * from 章节","章节名称","章节号");
				ViewState["dtDan"]=CreateDataTable();
				ViewState["dtDuo"]=CreateDataTable();
				ViewState["dtPan"]=CreateDataTable();
				ViewState["dtTian"]=CreateDataTable();
				ViewState["dtJian"]=CreateDataTable();
			}
		
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
			this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
			this.DDLdancqfs.SelectedIndexChanged += new System.EventHandler(this.DDL_SelectedIndexChanged);
			this.BtnAddDan.Click += new System.EventHandler(this.BtnAdd_Click);
			this.Dg_dan.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DDLduocqfs.SelectedIndexChanged += new System.EventHandler(this.DDL_SelectedIndexChanged);
			this.BtnAddDuo.Click += new System.EventHandler(this.BtnAdd_Click);
			this.Dg_duo.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DDLtiancqfs.SelectedIndexChanged += new System.EventHandler(this.DDL_SelectedIndexChanged);
			this.BtnAddTian.Click += new System.EventHandler(this.BtnAdd_Click);
			this.Dg_tian.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DDLpancqfs.SelectedIndexChanged += new System.EventHandler(this.DDL_SelectedIndexChanged);
			this.BtnAddPan.Click += new System.EventHandler(this.BtnAdd_Click);
			this.Dg_pan.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DDLjiancqfs.SelectedIndexChanged += new System.EventHandler(this.DDL_SelectedIndexChanged);
			this.BtnAddJian.Click += new System.EventHandler(this.BtnAdd_Click);
			this.Dg_jian.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.BtnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
			this.BtnPre.Click += new System.EventHandler(this.BtnPre_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		private void BtnNext_Click(object sender, System.EventArgs e)
		{
			if (TXTzjs.Text=="")
			{
				Response.Write("<script>alert('您的设置有误,必须输入组卷数量!')</script>");
				return;

			}
			if((String_to_Num(TXTdantl.Text)*String_to_Num(TXTdanfz.Text)+String_to_Num(TXTduotl.Text)*String_to_Num(TXTduofz.Text)+String_to_Num(TXTtiankl.Text)*String_to_Num(TXTtianfz.Text)+String_to_Num(TXTpantl.Text)*String_to_Num(TXTpanfz.Text)+String_to_Num(TXTjiantl.Text)*String_to_Num(TXTjianfz.Text)+String_to_Num(TXTbiantl.Text)*String_to_Num(TXTbianfz.Text))!=100)
			{
				Response.Write("<script>alert('您的设置有误,总分必须等于100分,请重新设置!')</script>");
				return;
			}
			else
			{
				Panel_txtl.Visible=false;
				Panel_cqfs.Visible =true;
				lbl_dan.Text=String_to_Num(TXTdantl.Text).ToString();
				lbl_dan_yx.Text="0";
				lbl_duo.Text=String_to_Num(TXTduotl.Text).ToString() ;
				lbl_duo_yx.Text="0";
				lbl_pan.Text=String_to_Num(TXTpantl.Text).ToString();
				lbl_pan_yx.Text="0";
				lbl_tian.Text=String_to_Num(TXTtiankl.Text).ToString();
				lbl_tian_yx.Text="0";
				lbl_jian.Text=String_to_Num(TXTjiantl.Text).ToString();
				lbl_jian_yx.Text="0";

			}

		}
		private int String_to_Num(string strtxt)
		{
			if (strtxt=="")
			{
				return 0;
			}
			else
			{
				return Convert.ToInt16(strtxt);
			}
		}
		private void DDL_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DropDownList curr_ddl=(DropDownList)sender; //获取当前产生该事件的下拉列表
			string curr_panel_id="Panel_"+curr_ddl.ID.Substring(3,curr_ddl.ID.Length-7);//由于各题型下拉列表的ID为“DDL题型名cqfs”，而该题型的按章节比重抽取时的设置界面的ID为“Panel_题型名”，故采用此方法获得Panel名
			if(curr_ddl.SelectedValue=="完全随机")
			{
				
				((Panel)FindControl(curr_panel_id)).Enabled =false;
			}
			else
			{
				((Panel)FindControl(curr_panel_id)).Enabled  =true;
			}
		
		}

		private void DataGrid_Bind(DataGrid dg,DataTable dt)
		{
			dg.Visible =true;
			dg.DataSource=dt.DefaultView;
			dg.DataBind();

		}
		private DataTable CreateDataTable()
		{
			DataTable dt=new DataTable();
		    
			DataColumn dc=new DataColumn();
		    dc.ColumnName="章节名称";
			dc.DataType=System.Type.GetType("System.String");
			dt.Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="题量";
			dc.DataType=System.Type.GetType("System.String");
			dt.Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="章节编号";

			dc.DataType=System.Type.GetType("System.String");
			
			dt.Columns.Add(dc);
			DataColumn[] dcs={dc};
		    dt.PrimaryKey=dcs;
			return dt;
		}
		private void BtnAdd_Click(object sender, System.EventArgs e)
		{
			Button curr_button=(Button)sender;
			string commonstr=curr_button.ID.Substring(6);
			Label curr_lbl_yx=(Label)FindControl("lbl_"+commonstr.ToLower()+"_yx");//获取标识当前题型已选题量的Label
			Label curr_lbl=(Label)FindControl("lbl_"+commonstr.ToLower());//获取标识当前题型总题量的Label
			TextBox curr_txt_zjtl=(TextBox)FindControl("TXT"+commonstr.ToLower()+"zjtl");//获取用来设置当前题型的某章节题量的TextBox
			DropDownList curr_ddl_zj=(DropDownList)FindControl("DDL"+commonstr+"zj");//获取当前题型的章节下拉列表框
			DataGrid curr_dg=(DataGrid)FindControl("Dg_"+commonstr.ToLower());//获取当前题型按章节比重设置界面中的DataGrid
			if ((String_to_Num(curr_lbl_yx.Text)+String_to_Num(curr_txt_zjtl.Text))<=String_to_Num(curr_lbl.Text)) 
			{
				try
				{
					
					DataTable dt=(DataTable)ViewState["dt"+commonstr];
					DataRow dr=dt.NewRow();
					dr["章节名称"]=curr_ddl_zj.SelectedItem.Text;
					dr["题量"]=curr_txt_zjtl.Text;
					dr["章节编号"]=curr_ddl_zj.SelectedValue;
					dt.Rows.Add(dr);
					DataGrid_Bind(curr_dg,dt);
					curr_lbl_yx.Text=(String_to_Num(curr_lbl_yx.Text)+String_to_Num(curr_txt_zjtl.Text)).ToString();
				}
				catch(ConstraintException ex)
				{
					Response.Write("<script>alert('"+ex.Message+"')</script>");
				}
			}
			else
			{
				string tixing="";
				switch(commonstr)
				{
					case "Dan":tixing="单选";break;
					case "Duo":tixing="多选";break;
					case "Tian":tixing="填空";break;
					case "Pan":tixing="判断";break;
					case "Jian":tixing="简答";break;
				}
                Response.Write("<script>alert('您的设置有误,"+tixing+"题总量必须等于"+lbl_dan.Text+"道,请重新设置!')</script>");
			}
		}
		

		private void ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid curr_dg=(DataGrid)source;	
			DataTable dt=(DataTable)ViewState["dt"+curr_dg.ID.Substring(3,1).ToUpper()+curr_dg.ID.Substring(4)];//因从DataGrid的ID中得来的代表题型名的字符串首字母为小写,其对应的DataTable的ID中代表题型名的字符串首字母为大写,所以此句实现首字母大写的转换
			Label curr_lbl_yx=(Label)FindControl("lbl_"+curr_dg.ID.Substring(3)+"_yx");
			Label curr_lbl=(Label)FindControl("lbl_"+curr_dg.ID.Substring(3));
			
			if (e.CommandName=="Delete")
			{//点击删除按钮所执行的代码
				
				DataRow dr=dt.Rows.Find(e.Item.Cells[4].Text);
				curr_lbl_yx.Text=Convert.ToString(Convert.ToInt16(curr_lbl_yx.Text)-Convert.ToInt16(e.Item.Cells[1].Text));
				dt.Rows.Remove(dr);
				DataGrid_Bind(curr_dg,dt);
				  
			}
			if (e.CommandName=="Edit")
			{//点击编辑按钮所执行的代码
				ViewState["curr_edit_row_key"]=e.Item.Cells[4].Text;
				ViewState["curr_edit_row_tl"]=e.Item.Cells[1].Text;
				curr_dg.EditItemIndex=e.Item.ItemIndex;
				DataGrid_Bind(curr_dg,dt);
			    
			}
			if (e.CommandName=="Update")
			{//点击更新按钮(更新按钮在点编辑按钮后显示)所执行的代码
				DataRow dr=dt.Rows.Find(ViewState["curr_edit_row_key"].ToString());
				TextBox tb2=(TextBox)e.Item.Cells[1].Controls[0];
				int curr_total_num=Convert.ToInt16(curr_lbl_yx.Text)-Convert.ToInt16(dr["题量"])+Convert.ToInt16(tb2.Text);//计算修改后将得到的已设置的总题量
				if(curr_total_num>Convert.ToInt16(curr_lbl.Text))
				{
					Response.Write("<script>alert('您的设置有误,此次输入使得已选题量超出了该题型抽取总题量,请重新设置!')</script>");
					return;

				}
				else
				{
					curr_lbl_yx.Text=curr_total_num.ToString();
			   
					dr["题量"]=tb2.Text;
				
					curr_dg.EditItemIndex=-1;
			    
					DataGrid_Bind(curr_dg,dt);
				}
			}
			if (e.CommandName=="Cancel")
			{//点击取消按钮(取消按钮在点编辑按钮后显示)所执行的代码	
				curr_dg.EditItemIndex=-1;
				DataGrid_Bind(curr_dg,dt);
			}
		}
		private void GetObjects( ref string tixing,ref DataGrid curr_dg,ref DropDownList curr_ddl,ref TextBox txt_tiliang,int j)
		{
			switch(j)
			{
				case 0:
					tixing="单选题";
					curr_dg=Dg_dan;
					curr_ddl=DDLdancqfs;
					txt_tiliang=TXTdantl;
					break;
				case 1:
					tixing="多选题";
					curr_dg=Dg_duo;
					curr_ddl=DDLduocqfs;
					txt_tiliang=TXTduotl;
					break;
				case 2:
					tixing="填空题";
					curr_dg=Dg_tian;
					curr_ddl=DDLtiancqfs;
					txt_tiliang=TXTtiankl;
					break;
				case 3:
					tixing="判断题";
					curr_dg=Dg_pan;
					curr_ddl=DDLpancqfs;
					txt_tiliang=TXTpantl;
					break;
				case 4:
					tixing="简答题";
					curr_dg=Dg_jian;
					curr_ddl=DDLjiancqfs;
					txt_tiliang=TXTjiantl;
					break;
				case 5:
					tixing="编程题";
					txt_tiliang=TXTbiantl;
					break;
			}
		}

		private void BtnCreate_Click(object sender, System.EventArgs e)
		{
			if((lbl_dan.Text!="0"&&(DDLdancqfs.SelectedValue)=="控制章节比重"&&lbl_dan.Text!=lbl_dan_yx.Text)||(lbl_duo.Text!="0"&&(DDLduocqfs.SelectedValue)=="控制章节比重"&&lbl_duo.Text!=lbl_duo_yx.Text)||(lbl_tian.Text!="0"&&(DDLtiancqfs.SelectedValue)=="控制章节比重"&&lbl_tian.Text!=lbl_tian_yx.Text)||(lbl_pan.Text!="0"&&(DDLpancqfs.SelectedValue)=="控制章节比重"&&lbl_pan.Text!=lbl_pan_yx.Text)||(lbl_jian.Text!="0"&&(DDLjiancqfs.SelectedValue)=="控制章节比重"&&lbl_jian.Text!=lbl_jian_yx.Text))
			{
				Response.Write("<script>alert('您的设置有误,如果您选择了控制章节比重的抽取方式,必须为其添加各章节的题量,且总题量必须等于该题型预先设置的题量，否则请选择完全随机方式,系统将自动按总题量抽题,请重新设置!')</script>");
				return;

			}
            else
			{
				for(int j=0;j<=5;j++)
				{//每次循环判断一种题型所设置的各种题量是否超出该题型库的题量
					string tixing=null;//存储当前题型,根据下面switch语句得到
					TextBox txt_tiliang=null;//存储组卷设置第一步中用来输入当前题型的题量的TextBox
					DataGrid curr_dg=null;//存储当前题型的按章节比重抽取方式的设置界面中的DataGrid
					DropDownList curr_ddl=null;//存储当前题型的抽取方式下拉列表
					GetObjects(ref tixing,ref curr_dg,ref curr_ddl,ref txt_tiliang,j);
					if(curr_ddl!=null)
					{//如果当前为非编程题
						if(curr_ddl.SelectedValue=="完全随机")
						{ //完全随机的情况下判断设置的当前题型总题量是否超额
							if(get_zongtishu(tixing,"")< String_to_Num(txt_tiliang.Text))
							{
								Response.Write("<script>alert('您的设置有误,"+tixing+"题库中的题量只有"+get_zongtishu(tixing,"")+"个,不足以抽取,请重新设置!')</script>");
								return;
							}
						}
						else
						{//按章节比重抽取的情况下要判断所设置的每一个章节的题量是否超额
							for(int i=0;i<curr_dg.Items.Count;i++)
							{
								if (get_zongtishu(tixing,curr_dg.Items[i].Cells[4].Text)<Convert.ToInt16(curr_dg.Items[i].Cells[1].Text))
								{
									Response.Write("<script>alert('您的设置有误,"+tixing+"题库中的"+curr_dg.Items[i].Cells[0].Text+"一章中的题量只有"+get_zongtishu(tixing,curr_dg.Items[i].Cells[4].Text)+"个,不足以抽区,请重新设置!')</script>");
									return;
								}
							}
						}
					}
					else
					{//如果当前为编程题
						if(get_zongtishu(tixing,"")< String_to_Num(txt_tiliang.Text))
						{
							Response.Write("<script>alert('您的设置有误,"+tixing+"题库中的题量只有"+get_zongtishu(tixing,"")+"个,不足以抽取,请重新设置!')</script>");
							return;
						}
					}

				}
				

				string[] shijuanhaos=new string[Convert.ToInt16(TXTzjs.Text)];
				for(int i=0;i<Convert.ToInt16(TXTzjs.Text);i++)
				{
					shijuanhaos[i]=new MyMethods().DateId();
					String StrSQL="insert into 分值 values('"+shijuanhaos[i]+"','"+String_to_Num(TXTdantl.Text)+"','"+String_to_Num(TXTduotl.Text)+"','"+String_to_Num(TXTtiankl.Text)+"','"+String_to_Num(TXTpantl.Text)+"','"+String_to_Num(TXTjiantl.Text)+"','"+String_to_Num(TXTbiantl.Text)+"'";
					StrSQL+=",'"+String_to_Num(TXTdanfz.Text)+"','"+String_to_Num(TXTduofz.Text)+"','"+String_to_Num(TXTtianfz.Text)+"','"+String_to_Num(TXTpanfz.Text)+"','"+String_to_Num(TXTjianfz.Text)+"','"+String_to_Num(TXTbianfz.Text)+"','"+TXTsjsyrq.Text+"')";
					MyData md=new MyData(Application["connstr"].ToString());
					md.eInsertUpdateDelete(StrSQL);
					for(int k=0;k<=4;k++)
					{
						string tixing=null;//存储当前题型,根据下面switch语句得到
						TextBox txt_tiliang=null;//存储组卷设置第一步中用来输入当前题型的题量的TextBox
						DataGrid curr_dg=null;//存储当前题型的按章节比重抽取方式的设置界面中的DataGrid
						DropDownList curr_ddl=null;//存储当前题型的抽取方式下拉列表
						GetObjects(ref tixing,ref curr_dg,ref curr_ddl,ref txt_tiliang,k);
						if (curr_ddl.SelectedValue=="完全随机")
						{
							chouqu(tixing,Convert.ToInt16(txt_tiliang.Text),"",shijuanhaos[i],0);
					
						}
						else
						{
							int shunxuhao_begin=0;
							for(int j=0;j<curr_dg.Items.Count;j++)
							{
						

								chouqu(tixing,Convert.ToInt16(curr_dg.Items[j].Cells[1].Text),curr_dg.Items[j].Cells[4].Text,shijuanhaos[i],shunxuhao_begin);
								shunxuhao_begin+=Convert.ToInt16(curr_dg.Items[j].Cells[1].Text);
							}
						}
					}
					chouqu("编程题",String_to_Num(TXTbiantl.Text),"",shijuanhaos[i],0);

				}
			}
			
		}
		private int get_zongtishu(string tixing,string zhangjiehao)
		{
			String StrSQL;
			if (tixing!="填空题")
			{
				if (zhangjiehao=="")
				{
					StrSQL="select count(*) as 题数 from "+tixing ;//统计指定题型库中全部题数	
				}
				else
				{
					StrSQL="select count(*) as 题数 from "+tixing+" where 章节号='"+zhangjiehao+"'" ;	//统计属于题型库中指定章节的全部题数
				}
			}
			else
			{
				if (zhangjiehao=="")
				{
					StrSQL="select count(填空数) as 题数 from "+tixing ;	//统计填空题库中填空总空数
				}
				else
				{
					StrSQL="select count(填空数) as 题数 from "+tixing+" where 章节号='"+zhangjiehao+"'" ;	//统计填空库中属于指定章的的总空数
				}
			}
			MyData md=new MyData(Application["connstr"].ToString());	
			OleDbDataReader DR=md.eSelect(StrSQL);
			DR.Read(); 
			int ti_total=Convert.ToInt16(DR["题数"]);//总题数
			DR.Close();
			md.CloseConn();
			return ti_total;
		}
		private void chouqu(string tixing,int tishu,string zhangjiehao,string shijuanhao,int shunxuhao_begin)
		{
		
			MyData md;
			String StrSQL;
			int ti_total=get_zongtishu(tixing,zhangjiehao);
			ArrayList tihaos=new ArrayList();//暂存此次已抽出来的所有题号
			string curr_tihao;
			int i=1,curr_shunxu=1;
				while(i<=tishu)//i为当前抽取到的题数（如果是填空题，则为空数），当抽取到的题（空）数还没达到要抽取的总题数时继续抽取
				{
			
					Random r = new Random(unchecked((int)DateTime.Now.Ticks));
					int curr_ti_num=(int)((ti_total)*r.NextDouble()+1);//本次随机出来的题在所有题中的位置 
					if (zhangjiehao=="")//若是是完全随机的抽取方式
					{
						StrSQL="select * from "+tixing+" order by id";
					}
					else
					{//如果是按章节比重的抽取方式
						StrSQL="select * from "+tixing+" where 章节号='"+zhangjiehao+"' order by id";
					}
					md=new MyData(Application["connstr"].ToString());
					OleDbDataReader DR=md.eSelect(StrSQL);
					for(int j=1;j<=curr_ti_num;j++)
					{//找出本次随机出来的题
						DR.Read();
					}
					curr_tihao=Convert.ToString(DR["id"]);//记录其题号
					int tiankongshu=0;
					if(tixing=="填空题")
					{//如果本次抽取的是填空题，则判断当前已有空数加上此次随机到的填空题空熟是否超出最大抽取数，超出则重抽
						tiankongshu=Convert.ToInt16(DR["填空数"]);
						if ((i<=tishu)&&((i+tiankongshu)>tishu+1))
						{
							DR.Close();
							continue;
						}
					}
					if (tihaos.Contains(curr_tihao))
					{//判断此次随机出来的题的题号时候已经本此调用chouqu函数时被抽出，如果已被抽出则重新抽取
						DR.Close();
					}
					else
					{//如果该题在本次调用chouqu函数时尚未被抽出，则确定抽取该题，并插入数据库
						tihaos.Add(curr_tihao);
						
						DR.Close();
					
						StrSQL="insert into 组卷(试卷号,顺序号,题型,试题编号) values('"+shijuanhao+"','"+(curr_shunxu+shunxuhao_begin)+"','"+tixing+"','"+curr_tihao+"')";
						new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(StrSQL);
						curr_shunxu++;
						if(tixing=="填空题")
						{
							i+=tiankongshu;
						}
						else
						{
							i++;
						}
					}
					md.CloseConn();

				}
				
			}

		

		private void BtnPre_Click(object sender, System.EventArgs e)
		{
			Panel_cqfs.Visible=false;
			Panel_txtl.Visible=true;
		}
		}	
	}

