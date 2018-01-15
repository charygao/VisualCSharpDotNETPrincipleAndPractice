using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;//可以先执行一条SQL语句DELETE FROM stuinfo

namespace csharp7_5_3
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Button buttonFirst;
		private System.Windows.Forms.Button buttonPre;
		private System.Windows.Forms.Button buttonCurrent;
		private System.Windows.Forms.Button buttonLast;
		private System.Windows.Forms.Button buttonNext;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		/// 

		DataSet ds;
		string dataMember;
		int recordCount;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;

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
			dataMember="stuinfo";
			BuildData();
			BindData();
			recordCount=this.BindingContext[ds,dataMember].Count;
			ShowPosition();

		}

		//该方法用于显示当前记录位置，并改变trackBar1控件值
		private void ShowPosition()
		{
			if(recordCount==0)
			{
				this.buttonCurrent.Text="无记录";
				textBox1.Text=textBox2.Text=textBox3.Text=textBox4.Text="";

			}
			else
			{
				int position=this.BindingContext[ds,dataMember].Position+1;
				this.buttonCurrent.Text=string.Format("{0} of {1}",position,recordCount);
				this.trackBar1.Value=position-1;
			}
		}

		//该方法用于建立数据集
		private void BuildData()
		{
            string conStr = @"server=HK-PC\SQLEXPRESS;Integrated Security=SSPI;database=stumanage"; 
            //string conStr = "server=(local);integrated Security=SSPI;database=stumanage";
			string sqlStr="select * from stuinfo";
			SqlConnection con=new SqlConnection(conStr);
			SqlDataAdapter adapter=new SqlDataAdapter(sqlStr,con);
			SqlCommandBuilder builder=new SqlCommandBuilder(adapter);
			ds=new DataSet();
			adapter.Fill(ds,dataMember);
		}

		//该方法用于将数据绑定到dataGrid1和4个文本框控件
		private void BindData()
		{
		    this.dataGrid1.AllowSorting=false;
			this.dataGrid1.SetDataBinding(ds,dataMember);
			this.textBox1.DataBindings.Add(new Binding("Text",ds,"stuinfo.stu_id"));
			this.textBox2.DataBindings.Add(new Binding("Text",ds,"stuinfo.stu_name"));
			this.textBox3.DataBindings.Add(new Binding("Text",ds,"stuinfo.sex"));
            this.textBox4.DataBindings.Add(new Binding("Text", ds, "stuinfo.classes"));//class_id
			this.trackBar1.Minimum=0;
			this.trackBar1.Maximum=this.BindingContext[ds,dataMember].Count-1;
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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.buttonLast = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonCurrent = new System.Windows.Forms.Button();
            this.buttonPre = new System.Windows.Forms.Button();
            this.buttonFirst = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(384, 184);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGrid1);
            this.groupBox1.Location = new System.Drawing.Point(8, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 208);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(176, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "学生基本情况";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(417, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 208);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(16, 166);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(120, 21);
            this.textBox4.TabIndex = 3;
            this.textBox4.Text = "textBox4";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(16, 118);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(120, 21);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "textBox3";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(16, 70);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 21);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "textBox2";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(16, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "textBox1";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.trackBar1);
            this.groupBox3.Controls.Add(this.buttonLast);
            this.groupBox3.Controls.Add(this.buttonNext);
            this.groupBox3.Controls.Add(this.buttonCurrent);
            this.groupBox3.Controls.Add(this.buttonPre);
            this.groupBox3.Controls.Add(this.buttonFirst);
            this.groupBox3.Location = new System.Drawing.Point(8, 264);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 80);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(296, 32);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(248, 42);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // buttonLast
            // 
            this.buttonLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLast.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLast.Location = new System.Drawing.Point(216, 32);
            this.buttonLast.Name = "buttonLast";
            this.buttonLast.Size = new System.Drawing.Size(32, 24);
            this.buttonLast.TabIndex = 4;
            this.buttonLast.Text = ">|";
            this.buttonLast.Click += new System.EventHandler(this.buttonLast_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonNext.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNext.Location = new System.Drawing.Point(184, 32);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(32, 24);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = ">";
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonCurrent
            // 
            this.buttonCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCurrent.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCurrent.Location = new System.Drawing.Point(88, 32);
            this.buttonCurrent.Name = "buttonCurrent";
            this.buttonCurrent.Size = new System.Drawing.Size(96, 24);
            this.buttonCurrent.TabIndex = 2;
            this.buttonCurrent.Text = "无记录";
            // 
            // buttonPre
            // 
            this.buttonPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPre.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonPre.Location = new System.Drawing.Point(56, 32);
            this.buttonPre.Name = "buttonPre";
            this.buttonPre.Size = new System.Drawing.Size(32, 24);
            this.buttonPre.TabIndex = 1;
            this.buttonPre.Text = "<";
            this.buttonPre.Click += new System.EventHandler(this.buttonPre_Click);
            // 
            // buttonFirst
            // 
            this.buttonFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonFirst.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonFirst.Location = new System.Drawing.Point(24, 32);
            this.buttonFirst.Name = "buttonFirst";
            this.buttonFirst.Size = new System.Drawing.Size(32, 24);
            this.buttonFirst.TabIndex = 0;
            this.buttonFirst.Text = "|<";
            this.buttonFirst.Click += new System.EventHandler(this.buttonFirst_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(576, 350);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
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

		//该事件用于定位第一条记录
		private void buttonFirst_Click(object sender, System.EventArgs e)
		{
			this.BindingContext[ds,dataMember].Position=0;
			ShowPosition();
		}
		//该事件用于定位前一条记录
		private void buttonPre_Click(object sender, System.EventArgs e)
		{
			if(this.BindingContext[ds,dataMember].Position>0)
			{
			    this.BindingContext[ds,dataMember].Position-=1;
				ShowPosition();
			}
		}
		//该事件用于定位后一条记录
		private void buttonNext_Click(object sender, System.EventArgs e)
		{
			if(this.BindingContext[ds,dataMember].Position<recordCount-1)
			{
				this.BindingContext[ds,dataMember].Position+=1;
				ShowPosition();
			}
		}
		//该事件用于定位最后一条记录
		private void buttonLast_Click(object sender, System.EventArgs e)
		{
			this.BindingContext[ds,dataMember].Position=recordCount-1;
			ShowPosition();
		}
		//该事件可使移动trackBar1标签来定位记录
		private void trackBar1_Scroll(object sender, System.EventArgs e)
		{
			this.BindingContext[ds,dataMember].Position=this.trackBar1.Value;
			ShowPosition();
		}
		//该事件通过单击dataGrid来定位
		private void dataGrid1_Click(object sender, System.EventArgs e)
		{
			this.BindingContext[ds,dataMember].Position=this.dataGrid1.CurrentRowIndex;
			ShowPosition();
		}
		//该事件可以增加数据集中的记录，但不会影响到SQL数据库
		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if(recordCount<=this.dataGrid1.CurrentCell.RowNumber)
			{
			    recordCount=this.dataGrid1.CurrentCell.RowNumber+1;
				this.trackBar1.Maximum=recordCount-1;
			}
			this.BindingContext[ds,dataMember].Position=this.dataGrid1.CurrentCell.RowNumber;
			ShowPosition();
		}	
	}
}
