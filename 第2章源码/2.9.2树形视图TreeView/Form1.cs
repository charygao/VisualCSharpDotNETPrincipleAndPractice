using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace 树形视图TreeView
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TextBox textBoxChild;
		private System.Windows.Forms.Button buttonAddRoot;
		private System.Windows.Forms.Button buttonAddChild;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.TextBox textBoxRoot;
		private System.Windows.Forms.Button buttonClear;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.textBoxRoot = new System.Windows.Forms.TextBox();
			this.textBoxChild = new System.Windows.Forms.TextBox();
			this.buttonAddRoot = new System.Windows.Forms.Button();
			this.buttonAddChild = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonClear = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.ImageList = this.imageList1;
			this.treeView1.Location = new System.Drawing.Point(8, 16);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(208, 216);
			this.treeView1.TabIndex = 0;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// textBoxRoot
			// 
			this.textBoxRoot.Location = new System.Drawing.Point(232, 48);
			this.textBoxRoot.Name = "textBoxRoot";
			this.textBoxRoot.Size = new System.Drawing.Size(96, 21);
			this.textBoxRoot.TabIndex = 1;
			this.textBoxRoot.Text = "计科系";
			// 
			// textBoxChild
			// 
			this.textBoxChild.Location = new System.Drawing.Point(232, 104);
			this.textBoxChild.Name = "textBoxChild";
			this.textBoxChild.Size = new System.Drawing.Size(96, 21);
			this.textBoxChild.TabIndex = 2;
			this.textBoxChild.Text = "网络051";
			// 
			// buttonAddRoot
			// 
			this.buttonAddRoot.Location = new System.Drawing.Point(344, 40);
			this.buttonAddRoot.Name = "buttonAddRoot";
			this.buttonAddRoot.Size = new System.Drawing.Size(88, 32);
			this.buttonAddRoot.TabIndex = 3;
			this.buttonAddRoot.Text = "添加系部";
			this.buttonAddRoot.Click += new System.EventHandler(this.buttonAddRoot_Click);
			// 
			// buttonAddChild
			// 
			this.buttonAddChild.Location = new System.Drawing.Point(344, 104);
			this.buttonAddChild.Name = "buttonAddChild";
			this.buttonAddChild.Size = new System.Drawing.Size(88, 32);
			this.buttonAddChild.TabIndex = 4;
			this.buttonAddChild.Text = "添加班级";
			this.buttonAddChild.Click += new System.EventHandler(this.buttonAddChild_Click);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(232, 160);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(96, 32);
			this.buttonDelete.TabIndex = 5;
			this.buttonDelete.Text = "删除节点";
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// buttonClear
			// 
			this.buttonClear.Location = new System.Drawing.Point(344, 160);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(88, 32);
			this.buttonClear.TabIndex = 6;
			this.buttonClear.Text = "清空";
			this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(456, 238);
			this.Controls.Add(this.buttonClear);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.buttonAddChild);
			this.Controls.Add(this.buttonAddRoot);
			this.Controls.Add(this.textBoxChild);
			this.Controls.Add(this.textBoxRoot);
			this.Controls.Add(this.treeView1);
			this.Name = "Form1";
			this.Text = "学校的分层列表";
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

		//添加展开某个节点后发出的AfterExpand事件。
		private void treeView1_AfterExpand(object sender,TreeViewEventArgs e)
		{
			TreeNode selectedNode=this.treeView1.SelectedNode;
			//selectedNode.SelectedImageIndex=1;
			selectedNode.ImageIndex=1;

			e.Node.ImageIndex=3;
			e.Node.SelectedImageIndex=3;			
		}
		//添加折叠某个节点后发出的AfterCollapse事件。
		private void treeView1_AfterCollapse(object sender,TreeViewEventArgs e)
		{
			TreeNode selectedNode=this.treeView1.SelectedNode;
			//selectedNode.SelectedImageIndex=1;
			selectedNode.ImageIndex=0;
		}
		//添加按钮的事件。
		private void buttonAddRoot_Click(object sender, System.EventArgs e)
		{
			//构造节点显示内容、取消选定时显示图像索引号、选定时显示图像索引号
			TreeNode newNode=new  TreeNode(this.textBoxRoot.Text,0,1);
			this.treeView1.Nodes.Add(newNode);
            this.treeView1.Select();//Select()激活控件。（继承自 Control。）
            //Select(Boolean, Boolean)激活子控件。还可以指定从中选择控件的 Tab 键顺序的方向。（继承自 Control。）
		}
		private void buttonAddChild_Click(object sender, System.EventArgs e)
		{
			TreeNode selectedNode=this.treeView1.SelectedNode;
			if(selectedNode==null)
			{
				MessageBox.Show("添加子节点之前必须先选中一个节点。","提示信息");
				return;
			}
			TreeNode newNode=new TreeNode(this.textBoxChild.Text,2,3);
			selectedNode.Nodes.Add(newNode);
			//selectedNode.SelectedImageIndex=1;
			selectedNode.Expand();
			this.treeView1.Select();
		}
		private void buttonDelete_Click(object sender,System.EventArgs e)
		{
			TreeNode selectedNode=this.treeView1.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("删除节点之前先选中一个节点。", "提示信息");
                return;
            }
            TreeNode parentNode = selectedNode.Parent;
            if (parentNode == null)
                this.treeView1.Nodes.Remove(selectedNode);
            else
                parentNode.Nodes.Remove(selectedNode);
//else
//treeView1.Nodes.Remove(selectedNode);
			this.treeView1.Select();
		}
		private void buttonClear_Click(object sender, System.EventArgs e)
		{
			treeView1.Nodes.Clear(); 		
		}

	}
}
