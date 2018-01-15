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
using System.Data.OleDb;//add
namespace 例8_10
{
	/// <summary>
	/// WebForm1 的摘要说明。
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;

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
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_CancelCommand);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
			this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void LoadGrid( )
		{
			string strConnection="Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
			strConnection+=Server.MapPath("person.mdb");
			OleDbConnection objConnection=new OleDbConnection(strConnection);
			OleDbDataAdapter objDataAdapter=new 
				OleDbDataAdapter("Select * From grade",objConnection);
			DataSet objDataSet=new DataSet();
			objDataAdapter.Fill(objDataSet);
			DataGrid1.DataSource=objDataSet;
			DataGrid1.DataBind();
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack) 
			{
				LoadGrid( );
			}

		}
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			LoadGrid( );
		}

		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex = e.Item.ItemIndex;
			LoadGrid( );		
		}

		private void DataGrid1_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex = -1;
			LoadGrid( );
		}

private void DataGrid1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
{			
	//更新按钮需要对数据库回写
	string xue_hao = ((TextBox)e.Item.Cells[1].Controls[0]).Text;
	string sex = ((TextBox)e.Item.Cells[2].Controls[0]).Text;
	string name = ((TextBox)e.Item.Cells[3].Controls[0]).Text;
	string yuwen = ((TextBox)e.Item.Cells[4].Controls[0]).Text;
	string math = ((TextBox)e.Item.Cells[5].Controls[0]).Text;
	string english = ((TextBox)e.Item.Cells[6].Controls[0]).Text;
	string strConnection="Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
	strConnection+=Server.MapPath("person.mdb");
	OleDbConnection objConnection=new OleDbConnection(strConnection);
	objConnection.Open();			
	String strSQL="UPDATE grade SET 学号="+xue_hao
		+ ","+"性别 = '" + sex+ "'" 
		+ ","+"姓名 = '" + name+ "'" 
		+ ","+"语文 = '" + yuwen+ "'" 
		+ ","+"数学 = '" + math+ "'" 
		+ ","+"英语 = '" + english+ "'" 
		+" WHERE 学号 = " + DataGrid1.DataKeys[(int)e.Item.ItemIndex];			
	OleDbCommand cm=new OleDbCommand(strSQL,objConnection);			
	cm.ExecuteNonQuery();
	objConnection.Close();
	DataGrid1.EditItemIndex =-1; 
	LoadGrid();		
}
	}
}
