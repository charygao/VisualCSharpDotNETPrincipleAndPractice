namespace Fiveclient
{
    partial class FiveGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiveGame));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.username = new System.Windows.Forms.ColumnHeader();
            this.userlevel = new System.Windows.Forms.ColumnHeader();
            this.userip = new System.Windows.Forms.ColumnHeader();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Rebuildbutton = new System.Windows.Forms.Button();
            this.StopNetbutton = new System.Windows.Forms.Button();
            this.buildGamebutton = new System.Windows.Forms.Button();
            this.Joinbutton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.userspeak = new System.Windows.Forms.TextBox();
            this.sendmsg = new System.Windows.Forms.Button();
            this.show_label1 = new System.Windows.Forms.Label();
            this.black_label2 = new System.Windows.Forms.Label();
            this.white_label3 = new System.Windows.Forms.Label();
            this.overgame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.IPtextBox = new System.Windows.Forms.TextBox();
            this.st = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.status = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(536, 536);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(182)))), ((int)(((byte)(146)))));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.username,
            this.userlevel,
            this.userip});
            this.listView1.Location = new System.Drawing.Point(562, 43);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(206, 80);
            this.listView1.TabIndex = 22;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // username
            // 
            this.username.Text = "用户名";
            this.username.Width = 48;
            // 
            // userlevel
            // 
            this.userlevel.Text = "等级";
            this.userlevel.Width = 69;
            // 
            // userip
            // 
            this.userip.Text = "IP";
            this.userip.Width = 88;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(605, 129);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 33);
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(605, 168);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 33);
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // Rebuildbutton
            // 
            this.Rebuildbutton.Enabled = false;
            this.Rebuildbutton.Location = new System.Drawing.Point(572, 223);
            this.Rebuildbutton.Name = "Rebuildbutton";
            this.Rebuildbutton.Size = new System.Drawing.Size(72, 20);
            this.Rebuildbutton.TabIndex = 25;
            this.Rebuildbutton.Text = "从新开始";
            this.Rebuildbutton.Click += new System.EventHandler(this.Rebuildbutton_Click);
            // 
            // StopNetbutton
            // 
            this.StopNetbutton.Enabled = false;
            this.StopNetbutton.Location = new System.Drawing.Point(656, 255);
            this.StopNetbutton.Name = "StopNetbutton";
            this.StopNetbutton.Size = new System.Drawing.Size(72, 21);
            this.StopNetbutton.TabIndex = 26;
            this.StopNetbutton.Text = "停止网络";
            this.StopNetbutton.Click += new System.EventHandler(this.StopNetbutton_Click);
            // 
            // buildGamebutton
            // 
            this.buildGamebutton.Location = new System.Drawing.Point(572, 255);
            this.buildGamebutton.Name = "buildGamebutton";
            this.buildGamebutton.Size = new System.Drawing.Size(72, 21);
            this.buildGamebutton.TabIndex = 27;
            this.buildGamebutton.Text = "建立游戏";
            this.buildGamebutton.Click += new System.EventHandler(this.NewGamebutton_Click);
            // 
            // Joinbutton
            // 
            this.Joinbutton.Location = new System.Drawing.Point(688, 326);
            this.Joinbutton.Name = "Joinbutton";
            this.Joinbutton.Size = new System.Drawing.Size(57, 21);
            this.Joinbutton.TabIndex = 28;
            this.Joinbutton.Text = "加入";
            this.Joinbutton.Click += new System.EventHandler(this.Joinbutton_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(182)))), ((int)(((byte)(146)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(572, 354);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(174, 112);
            this.listBox1.TabIndex = 29;
            // 
            // userspeak
            // 
            this.userspeak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(182)))), ((int)(((byte)(146)))));
            this.userspeak.Location = new System.Drawing.Point(571, 474);
            this.userspeak.Name = "userspeak";
            this.userspeak.Size = new System.Drawing.Size(120, 21);
            this.userspeak.TabIndex = 30;
            this.userspeak.TextChanged += new System.EventHandler(this.userspeak_TextChanged);
            // 
            // sendmsg
            // 
            this.sendmsg.ForeColor = System.Drawing.Color.Firebrick;
            this.sendmsg.Location = new System.Drawing.Point(697, 472);
            this.sendmsg.Name = "sendmsg";
            this.sendmsg.Size = new System.Drawing.Size(48, 23);
            this.sendmsg.TabIndex = 31;
            this.sendmsg.Text = "发送";
            this.sendmsg.Click += new System.EventHandler(this.sendmsg_Click);
            // 
            // show_label1
            // 
            this.show_label1.AutoSize = true;
            this.show_label1.ForeColor = System.Drawing.Color.Blue;
            this.show_label1.Location = new System.Drawing.Point(560, 12);
            this.show_label1.Name = "show_label1";
            this.show_label1.Size = new System.Drawing.Size(101, 12);
            this.show_label1.TabIndex = 32;
            this.show_label1.Text = "网络五子棋状态：";
            // 
            // black_label2
            // 
            this.black_label2.AutoSize = true;
            this.black_label2.Location = new System.Drawing.Point(570, 139);
            this.black_label2.Name = "black_label2";
            this.black_label2.Size = new System.Drawing.Size(29, 12);
            this.black_label2.TabIndex = 33;
            this.black_label2.Text = "黑方";
            // 
            // white_label3
            // 
            this.white_label3.AutoSize = true;
            this.white_label3.Location = new System.Drawing.Point(570, 178);
            this.white_label3.Name = "white_label3";
            this.white_label3.Size = new System.Drawing.Size(29, 12);
            this.white_label3.TabIndex = 34;
            this.white_label3.Text = "白方";
            // 
            // overgame
            // 
            this.overgame.Enabled = false;
            this.overgame.Location = new System.Drawing.Point(656, 223);
            this.overgame.Name = "overgame";
            this.overgame.Size = new System.Drawing.Size(72, 20);
            this.overgame.TabIndex = 36;
            this.overgame.Text = "认输";
            this.overgame.Click += new System.EventHandler(this.overgame_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(644, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(644, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 38;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // IPtextBox
            // 
            this.IPtextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(182)))), ((int)(((byte)(146)))));
            this.IPtextBox.Location = new System.Drawing.Point(571, 327);
            this.IPtextBox.Name = "IPtextBox";
            this.IPtextBox.Size = new System.Drawing.Size(111, 21);
            this.IPtextBox.TabIndex = 39;
            this.IPtextBox.Text = "192.168.1.165";
            this.IPtextBox.TextChanged += new System.EventHandler(this.IPtextBox_TextChanged);
            // 
            // st
            // 
            this.st.Location = new System.Drawing.Point(569, 303);
            this.st.Name = "st";
            this.st.Size = new System.Drawing.Size(110, 21);
            this.st.TabIndex = 40;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(679, 168);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(33, 33);
            this.pictureBox4.TabIndex = 41;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(679, 129);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(33, 33);
            this.pictureBox5.TabIndex = 42;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 541);
            this.panel1.TabIndex = 43;
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(659, 12);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(41, 12);
            this.status.TabIndex = 44;
            this.status.Text = "label3";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // FiveGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(182)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(800, 565);
            this.Controls.Add(this.status);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.st);
            this.Controls.Add(this.IPtextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.overgame);
            this.Controls.Add(this.white_label3);
            this.Controls.Add(this.black_label2);
            this.Controls.Add(this.show_label1);
            this.Controls.Add(this.sendmsg);
            this.Controls.Add(this.userspeak);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Joinbutton);
            this.Controls.Add(this.buildGamebutton);
            this.Controls.Add(this.StopNetbutton);
            this.Controls.Add(this.Rebuildbutton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FiveGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "五子棋对战";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FiveGame_FormClosed);
            this.Load += new System.EventHandler(this.FiveGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader username;
        private System.Windows.Forms.ColumnHeader userlevel;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button Rebuildbutton;
        private System.Windows.Forms.Button StopNetbutton;
        private System.Windows.Forms.Button buildGamebutton;
        private System.Windows.Forms.Button Joinbutton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox userspeak;
        private System.Windows.Forms.Button sendmsg;
        private System.Windows.Forms.Label show_label1;
        private System.Windows.Forms.Label black_label2;
        private System.Windows.Forms.Label white_label3;
        private System.Windows.Forms.Button overgame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox IPtextBox;
        private System.Windows.Forms.Label st;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader userip;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Timer timer2;
    }
}