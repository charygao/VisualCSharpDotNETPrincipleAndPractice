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
using System.IO;//add
using System.Xml;//add
namespace liu_yan_book
{
	/// <summary>
	/// guestpost 的摘要说明。
	/// </summary>
	public class guestpost : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label errmess;
		protected System.Web.UI.WebControls.TextBox Name;
		protected System.Web.UI.WebControls.TextBox Email;
		protected System.Web.UI.WebControls.TextBox Comments;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.Button Button1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.LinkButton1.Click += new System.EventHandler(this.LinkButton1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			//保存数据的XML文件的路径 
			string dataFile = "guest.xml" ; 
			//运用一个Try-Catch块完成信息添加功能 
			try
			{ 
				//仅当页面是有效的时候才处理它 
				if(Page.IsValid)
				{ 
					errmess.Text="" ; 
					//以读的模式打开一个FileStream来访问数据库 
					FileStream fin; 
					fin= new FileStream(Server.MapPath(dataFile),FileMode.Open, 
						FileAccess.Read,FileShare.ReadWrite); 
					//建立一个数据库对象 
					DataSet guestData = new DataSet(); 
					//仅从数据库读取XML Schema 
					guestData.ReadXml(fin); 
					fin.Close(); 
					//从数据集的Schema新建一个数据行 
					DataRow newRow = guestData.Tables[0].NewRow(); 
					//用相应值填写数据行 
					newRow["Name"]=Name.Text; 
					newRow["Email"]=Email.Text; 
					newRow["Comments"]=Comments.Text; 
					newRow["DateTime"]=DateTime.Now.ToString(); 
					//填写完毕，将数据行添加到数据集 
					guestData.Tables[0].Rows.Add(newRow); 
					//为数据库文件新建另一个写模式的FileStream，并保存文件 
					FileStream fout ; 
					fout = new FileStream(Server.MapPath(dataFile),FileMode.Create , 
						FileAccess.Write,FileShare.ReadWrite); 
					guestData.WriteXml(fout); 
					fout.Close(); 
					//隐藏当前的面板 
					//formPanel.Visible=false; 
					//显示带有感谢信息的面板 
					//thankPanel.Visible=true; 
					

				} 
			} 
			catch (Exception edd) 
			{ 
				//捕捉异常 
				errmess.Text="写入XML文件出错，原因："+edd.ToString() ; 
			} 	
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			//判断文件是否存在 
			if(!File.Exists(Server.MapPath("guest.xml"))) 
			{ 
				Response.Write("guest.xml留言文件名不存在"); 
				Response.End() ; 
			} 
			XmlDocument xmlDoc = new XmlDocument ( ) ;
			xmlDoc.Load(Server.MapPath("guest.xml"));
			//往<NewDataSet>节点中插入一个<news>节点：			
			XmlNode root=xmlDoc.SelectSingleNode("NewDataSet");//查找<NewDataSet>
			XmlElement xe1=xmlDoc.CreateElement("news");//创建一个<news>节点
			XmlElement xesub1=xmlDoc.CreateElement("name");
			xesub1.InnerText=Name.Text;//设置文本节点
			xe1.AppendChild(xesub1);//添加到<book>节点中

			XmlElement xesub2=xmlDoc.CreateElement("Email");
			xesub2.InnerText=Email.Text;
			xe1.AppendChild(xesub2);

			XmlElement xesub3=xmlDoc.CreateElement("Comments");
			xesub3.InnerText=Comments.Text;
			xe1.AppendChild(xesub3);

			XmlElement xesub4=xmlDoc.CreateElement("DateTime");
			xesub4.InnerText=DateTime.Now.ToString();
			xe1.AppendChild(xesub4);
			root.AppendChild(xe1);//添加到<NewDataSet>节点中
			xmlDoc.Save(Server.MapPath("guest.xml"));
			errmess.Text="留言成功写入"; 
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
		   Response.Redirect("view.aspx"); 
		}

		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
		   Response.Redirect("index.aspx"); 
		}
	}
}
