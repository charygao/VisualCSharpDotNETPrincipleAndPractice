namespace 屏幕捕获
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Trayicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.Notifyiconmnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.捕获当前屏幕ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Notifyiconmnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Trayicon
            // 
            this.Trayicon.ContextMenuStrip = this.Notifyiconmnu;
            this.Trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("Trayicon.Icon")));
            this.Trayicon.Text = "用C#做的Screen Capture程序";
            this.Trayicon.Visible = true;
            // 
            // Notifyiconmnu
            // 
            this.Notifyiconmnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.捕获当前屏幕ToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出系统ToolStripMenuItem});
            this.Notifyiconmnu.Name = "Notifyiconmnu";
            this.Notifyiconmnu.Size = new System.Drawing.Size(153, 76);
            // 
            // 捕获当前屏幕ToolStripMenuItem
            // 
            this.捕获当前屏幕ToolStripMenuItem.Name = "捕获当前屏幕ToolStripMenuItem";
            this.捕获当前屏幕ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.捕获当前屏幕ToolStripMenuItem.Text = "捕获当前屏幕";
            this.捕获当前屏幕ToolStripMenuItem.Click += new System.EventHandler(this.捕获当前屏幕ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出系统ToolStripMenuItem.Text = "退出系统";
            this.退出系统ToolStripMenuItem.Click += new System.EventHandler(this.退出系统ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 52);
            this.ControlBox = false;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "用C#做的Screen Capture程序！";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Notifyiconmnu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon Trayicon;
        private System.Windows.Forms.ContextMenuStrip Notifyiconmnu;
        private System.Windows.Forms.ToolStripMenuItem 捕获当前屏幕ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
    }
}

