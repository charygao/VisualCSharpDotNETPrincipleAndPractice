using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace FolderBrowser
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FolderDialog : System.Windows.Forms.Form
	{
        private System.Windows.Forms.TreeView FolderTree;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.IContainer components;

		public FolderDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FolderDialog));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.FolderTree = new System.Windows.Forms.TreeView();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// FolderTree
			// 
			this.FolderTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.FolderTree.ImageList = this.imageList1;
			this.FolderTree.Location = new System.Drawing.Point(0, 0);
			this.FolderTree.Name = "FolderTree";
			this.FolderTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																				   new System.Windows.Forms.TreeNode("我的电脑", 0, 0)});
			this.FolderTree.Size = new System.Drawing.Size(336, 350);
			this.FolderTree.TabIndex = 0;
			this.FolderTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FolderTree_AfterSelect);
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2});
			this.listView1.Location = new System.Drawing.Point(336, 8);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(296, 336);
			this.listView1.TabIndex = 1;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "文件名";
			this.columnHeader1.Width = 180;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "创建时间";
			this.columnHeader2.Width = 120;
			// 
			// FolderDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(632, 353);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.FolderTree);
			this.Name = "FolderDialog";
			this.Text = "浏览我的电脑";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FolderDialog());
		}

        private void FolderTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
			if(e.Node.Text.ToString()!="我的电脑")
			{
				EnumDirectories(e.Node);
                listView1.Items.Clear(); 
				//获取指定目录下的所有文件
				string[] files=Directory.GetFiles(e.Node.Tag.ToString() );//directory
				for(int i=0;i<files.Length;i++)
				{
					//listView1.Items.Add(files[i]);//全部路径
					string[] item={files[i].Substring(files[i].LastIndexOf(@"\")+1),File.GetCreationTime(files[i]).ToString()};
					listView1.Items.Insert(listView1.Items.Count,new ListViewItem(item) );//文件名与创建时间
				}				
			}
			else
				EnumDrives(e.Node);
        }

        private void EnumDrives(TreeNode ParentNode)
        {
            if(ParentNode.Nodes.Count==0)
            {    
                foreach(string drive in Directory.GetLogicalDrives())
                {
                    FolderTree.SelectedNode=ParentNode;
                    TreeNode TempNode=new TreeNode();
                    TempNode.Text=drive.Substring(0,drive.Length-1);
                    TempNode.Tag=drive;
                    TempNode.ImageIndex=1;
                    TempNode.SelectedImageIndex=1; 
                    FolderTree.SelectedNode.Nodes.Add(TempNode);
                    FolderTree.SelectedNode.Nodes[FolderTree.SelectedNode.Nodes.Count-1].EnsureVisible();//确保可见
                }
            }
        }

        private void EnumDirectories(TreeNode ParentNode)
        {
            FolderTree.SelectedNode=ParentNode;
            string DirectoryPath=ParentNode.Tag.ToString();
            if(ParentNode.Nodes.Count==0)
            {
                if(DirectoryPath.Substring(DirectoryPath.Length-1)!=@"\")
                    DirectoryPath+=@"\";
                try
                {
                    foreach(string directory in Directory.GetDirectories(DirectoryPath))
                    {
                        TreeNode TempNode=new TreeNode();
                        TempNode.Text=directory.Substring(directory.LastIndexOf(@"\")+1);
                        TempNode.Tag=directory;
                        TempNode.ImageIndex=3;
                        TempNode.SelectedImageIndex=2;
                        FolderTree.SelectedNode.Nodes.Add(TempNode);
                        FolderTree.SelectedNode.Nodes[FolderTree.SelectedNode.Nodes.Count - 1].EnsureVisible();//确保可见
                    }
                }
                catch(Exception)
                {
                }
            }
        }
	}
}
