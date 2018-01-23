using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace Image_Process
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemOpen;
		private System.Windows.Forms.MenuItem menuItemSave;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemEdit;
		private System.Windows.Forms.MenuItem menuItemCopy;
		private System.Windows.Forms.MenuItem menuItemPaste;
		private System.Windows.Forms.MenuItem menuItemProcess;
		private System.Windows.Forms.MenuItem menuItemTransform;
		private System.Windows.Forms.MenuItem menuItemDisplay;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.TextBox textBoxX;
		private System.Windows.Forms.TextBox textBoxR;
		private System.Windows.Forms.TextBox textBoxG;
		private System.Windows.Forms.TextBox textBoxB;
		private System.Windows.Forms.TextBox textBoxY;
		private System.Windows.Forms.TextBox textBoxMY;
		private System.Windows.Forms.TextBox textBoxRA;
		private System.Windows.Forms.TextBox textBoxPY;
		private System.Windows.Forms.TextBox textBoxPX;
		private System.Windows.Forms.TextBox textBoxMX;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.Label label11;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
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
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItemFile = new System.Windows.Forms.MenuItem();
			this.menuItemOpen = new System.Windows.Forms.MenuItem();
			this.menuItemSave = new System.Windows.Forms.MenuItem();
			this.menuItemExit = new System.Windows.Forms.MenuItem();
			this.menuItemEdit = new System.Windows.Forms.MenuItem();
			this.menuItemCopy = new System.Windows.Forms.MenuItem();
			this.menuItemPaste = new System.Windows.Forms.MenuItem();
			this.menuItemProcess = new System.Windows.Forms.MenuItem();
			this.menuItemTransform = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItemDisplay = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxY = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxB = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxG = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxR = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxX = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxMY = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxRA = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBoxPY = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBoxPX = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBoxMX = new System.Windows.Forms.TextBox();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Image files (JPeg, Gif, Bmp, etc.)|*.jpg;*.jpeg;*.gif;*.bmp;*.tif; *.tiff; *.png|" +
				" JPeg files (*.jpg;*.jpeg)|*.jpg;*.jpeg |GIF files (*.gif)|*.gif |BMP files (*.b" +
				"mp)|*.bmp|Tiff files (*.tif;*.tiff)|*.tif;*.tiff|Png files (*.png)| *.png |All f" +
				"iles (*.*)|*.*";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton6);
			this.groupBox1.Controls.Add(this.radioButton5);
			this.groupBox1.Controls.Add(this.radioButton4);
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(16, 376);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(96, 168);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "图像保存格式";
			// 
			// radioButton6
			// 
			this.radioButton6.Location = new System.Drawing.Point(8, 144);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(72, 16);
			this.radioButton6.TabIndex = 5;
			this.radioButton6.Text = "Wmf格式";
			// 
			// radioButton5
			// 
			this.radioButton5.Location = new System.Drawing.Point(8, 120);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(72, 16);
			this.radioButton5.TabIndex = 4;
			this.radioButton5.Text = "Tiff格式";
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(8, 96);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(72, 16);
			this.radioButton4.TabIndex = 3;
			this.radioButton4.Text = "Png格式";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(8, 72);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(72, 16);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.Text = "Jpeg格式";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(8, 48);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(72, 16);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "Gif格式";
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(8, 24);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(72, 16);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Bmp格式";
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(440, 352);
			this.panel1.TabIndex = 4;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(192, 168);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItemFile,
																					  this.menuItemEdit,
																					  this.menuItemProcess,
																					  this.menuItemDisplay,
																					  this.menuItem2,
																					  this.menuItem14,
																					  this.menuItem18});
			// 
			// menuItemFile
			// 
			this.menuItemFile.Index = 0;
			this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItemOpen,
																						 this.menuItemSave,
																						 this.menuItemExit});
			this.menuItemFile.Text = "文件(&F)";
			// 
			// menuItemOpen
			// 
			this.menuItemOpen.Index = 0;
			this.menuItemOpen.Text = "打开";
			this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
			// 
			// menuItemSave
			// 
			this.menuItemSave.Index = 1;
			this.menuItemSave.Text = "保存";
			this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
			// 
			// menuItemExit
			// 
			this.menuItemExit.Index = 2;
			this.menuItemExit.Text = "退出";
			this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
			// 
			// menuItemEdit
			// 
			this.menuItemEdit.Index = 1;
			this.menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItemCopy,
																						 this.menuItemPaste});
			this.menuItemEdit.Text = "编辑(&E)";
			// 
			// menuItemCopy
			// 
			this.menuItemCopy.Index = 0;
			this.menuItemCopy.Text = "复制";
			this.menuItemCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
			// 
			// menuItemPaste
			// 
			this.menuItemPaste.Index = 1;
			this.menuItemPaste.Text = "粘贴";
			this.menuItemPaste.Click += new System.EventHandler(this.menuItemPaste_Click);
			// 
			// menuItemProcess
			// 
			this.menuItemProcess.Index = 2;
			this.menuItemProcess.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.menuItemTransform,
																							this.menuItem1,
																							this.menuItem3,
																							this.menuItem4,
																							this.menuItem8});
			this.menuItemProcess.Text = "处理(&P)";
			// 
			// menuItemTransform
			// 
			this.menuItemTransform.Index = 0;
			this.menuItemTransform.Text = "彩色灰度转换";
			this.menuItemTransform.Click += new System.EventHandler(this.menuItemTransform_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.Text = "反色";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "柔化";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "锐化";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 4;
			this.menuItem8.Text = "雾化";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItemDisplay
			// 
			this.menuItemDisplay.Index = 3;
			this.menuItemDisplay.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.menuItem7,
																							this.menuItem9,
																							this.menuItem10,
																							this.menuItem11,
																							this.menuItem12,
																							this.menuItem13});
			this.menuItemDisplay.Text = "显示(&D)";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 0;
			this.menuItem7.Text = "水平百叶窗";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 1;
			this.menuItem9.Text = "从上向下拉伸";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 2;
			this.menuItem10.Text = "从左到右";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 3;
			this.menuItem11.Text = "中心向四周扩散";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 4;
			this.menuItem12.Text = "翻转";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 5;
			this.menuItem13.Text = "中心向两边拉伸";
			this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 4;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem5,
																					  this.menuItem6,
																					  this.menuItem20});
			this.menuItem2.Text = "特效(&E)";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.Text = "浮雕";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 1;
			this.menuItem6.Text = "水彩画";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 2;
			this.menuItem20.Text = "显示缩略图";
			this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 5;
			this.menuItem14.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem15,
																					   this.menuItem16,
																					   this.menuItem17});
			this.menuItem14.Text = "几何变换(&T)";
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 0;
			this.menuItem15.Text = "平移变换";
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 1;
			this.menuItem16.Text = "比例变换";
			this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 2;
			this.menuItem17.Text = "旋转";
			this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 6;
			this.menuItem18.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem19});
			this.menuItem18.Text = "帮助(&H)";
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 0;
			this.menuItem19.Text = "关于...";
			// 
			// panel2
			// 
			this.panel2.AutoScroll = true;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.pictureBox2);
			this.panel2.Location = new System.Drawing.Point(464, 8);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(440, 352);
			this.panel2.TabIndex = 5;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(0, 0);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(192, 168);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.textBoxY);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.textBoxB);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.textBoxG);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.textBoxR);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.textBoxX);
			this.groupBox2.Location = new System.Drawing.Point(136, 376);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(104, 168);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "当前像素点";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 52);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(16, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "Y";
			// 
			// textBoxY
			// 
			this.textBoxY.Location = new System.Drawing.Point(32, 48);
			this.textBoxY.Name = "textBoxY";
			this.textBoxY.Size = new System.Drawing.Size(56, 21);
			this.textBoxY.TabIndex = 8;
			this.textBoxY.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 140);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(16, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "B";
			// 
			// textBoxB
			// 
			this.textBoxB.Location = new System.Drawing.Point(32, 136);
			this.textBoxB.Name = "textBoxB";
			this.textBoxB.Size = new System.Drawing.Size(56, 21);
			this.textBoxB.TabIndex = 6;
			this.textBoxB.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 116);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "G";
			// 
			// textBoxG
			// 
			this.textBoxG.Location = new System.Drawing.Point(32, 112);
			this.textBoxG.Name = "textBoxG";
			this.textBoxG.Size = new System.Drawing.Size(56, 21);
			this.textBoxG.TabIndex = 4;
			this.textBoxG.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 92);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "R";
			// 
			// textBoxR
			// 
			this.textBoxR.Location = new System.Drawing.Point(32, 88);
			this.textBoxR.Name = "textBoxR";
			this.textBoxR.Size = new System.Drawing.Size(56, 21);
			this.textBoxR.TabIndex = 2;
			this.textBoxR.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(16, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "X";
			// 
			// textBoxX
			// 
			this.textBoxX.Location = new System.Drawing.Point(32, 24);
			this.textBoxX.Name = "textBoxX";
			this.textBoxX.Size = new System.Drawing.Size(56, 21);
			this.textBoxX.TabIndex = 0;
			this.textBoxX.Text = "";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox11);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.textBoxMY);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.textBoxRA);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.textBoxPY);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.textBoxPX);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.textBoxMX);
			this.groupBox3.Controls.Add(this.textBox12);
			this.groupBox3.Controls.Add(this.textBox13);
			this.groupBox3.Location = new System.Drawing.Point(264, 376);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(136, 168);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "几何变换";
			// 
			// textBox11
			// 
			this.textBox11.BackColor = System.Drawing.SystemColors.Control;
			this.textBox11.Location = new System.Drawing.Point(16, 32);
			this.textBox11.Multiline = true;
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(18, 30);
			this.textBox11.TabIndex = 10;
			this.textBox11.Text = "平移";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(40, 52);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(24, 16);
			this.label6.TabIndex = 9;
			this.label6.Text = "MY";
			// 
			// textBoxMY
			// 
			this.textBoxMY.Location = new System.Drawing.Point(64, 48);
			this.textBoxMY.Name = "textBoxMY";
			this.textBoxMY.Size = new System.Drawing.Size(56, 21);
			this.textBoxMY.TabIndex = 8;
			this.textBoxMY.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(40, 140);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(24, 16);
			this.label7.TabIndex = 7;
			this.label7.Text = "RA";
			// 
			// textBoxRA
			// 
			this.textBoxRA.Location = new System.Drawing.Point(64, 136);
			this.textBoxRA.Name = "textBoxRA";
			this.textBoxRA.Size = new System.Drawing.Size(56, 21);
			this.textBoxRA.TabIndex = 6;
			this.textBoxRA.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(40, 108);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(24, 16);
			this.label8.TabIndex = 5;
			this.label8.Text = "PY";
			// 
			// textBoxPY
			// 
			this.textBoxPY.Location = new System.Drawing.Point(64, 104);
			this.textBoxPY.Name = "textBoxPY";
			this.textBoxPY.Size = new System.Drawing.Size(56, 21);
			this.textBoxPY.TabIndex = 4;
			this.textBoxPY.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(40, 84);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(24, 16);
			this.label9.TabIndex = 3;
			this.label9.Text = "PX";
			// 
			// textBoxPX
			// 
			this.textBoxPX.Location = new System.Drawing.Point(64, 80);
			this.textBoxPX.Name = "textBoxPX";
			this.textBoxPX.Size = new System.Drawing.Size(56, 21);
			this.textBoxPX.TabIndex = 2;
			this.textBoxPX.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(40, 28);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(24, 16);
			this.label10.TabIndex = 1;
			this.label10.Text = "MX";
			// 
			// textBoxMX
			// 
			this.textBoxMX.Location = new System.Drawing.Point(64, 24);
			this.textBoxMX.Name = "textBoxMX";
			this.textBoxMX.Size = new System.Drawing.Size(56, 21);
			this.textBoxMX.TabIndex = 0;
			this.textBoxMX.Text = "";
			// 
			// textBox12
			// 
			this.textBox12.BackColor = System.Drawing.SystemColors.Control;
			this.textBox12.Location = new System.Drawing.Point(16, 88);
			this.textBox12.Multiline = true;
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new System.Drawing.Size(18, 30);
			this.textBox12.TabIndex = 10;
			this.textBox12.Text = "比例";
			// 
			// textBox13
			// 
			this.textBox13.BackColor = System.Drawing.SystemColors.Control;
			this.textBox13.Location = new System.Drawing.Point(16, 132);
			this.textBox13.Multiline = true;
			this.textBox13.Name = "textBox13";
			this.textBox13.Size = new System.Drawing.Size(18, 30);
			this.textBox13.TabIndex = 10;
			this.textBox13.Text = "旋转";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(432, 376);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(104, 16);
			this.label11.TabIndex = 8;
			this.label11.Text = "缩略图";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(912, 550);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "简单图像处理";
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
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

		
		private void menuItemOpen_Click(object sender, System.EventArgs e)
		{
			//打开图像文件并显示
			this.openFileDialog1.ShowDialog();
			if(this.openFileDialog1.FileName.Trim()=="")
				return;
			try
			{
				this.pictureBox1.Image=System.Drawing.Bitmap.FromFile(this.openFileDialog1.FileName);
				this.pictureBox2.Image=System.Drawing.Bitmap.FromFile(this.openFileDialog1.FileName);
			}
			catch(Exception Err)
			{
				MessageBox.Show(this,"打开图像文件错误！","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		private void menuItemSave_Click(object sender, System.EventArgs e)
		{
			//指定图像文件格式并保存
			this.saveFileDialog1.ShowDialog();
			System.String StrFileName=this.saveFileDialog1.FileName;
			if(StrFileName.Trim()=="")
				return;
			try
			{			
				if(this.radioButton1.Checked)//bmp
				{
					this.pictureBox2.Image.Save(StrFileName+".bmp",System.Drawing.Imaging.ImageFormat.Bmp);			
				}
				if(this.radioButton2.Checked)//gif
				{
					this.pictureBox2.Image.Save(StrFileName+".gif",System.Drawing.Imaging.ImageFormat.Gif);			
				}
				if(this.radioButton3.Checked)//jpg
				{
					this.pictureBox2.Image.Save(StrFileName+".jpg",System.Drawing.Imaging.ImageFormat.Jpeg);			
				}
				if(this.radioButton4.Checked)//png
				{
					this.pictureBox2.Image.Save(StrFileName+".png",System.Drawing.Imaging.ImageFormat.Png);			
				}
				if(this.radioButton5.Checked)//tif
				{
					this.pictureBox2.Image.Save(StrFileName+".tif",System.Drawing.Imaging.ImageFormat.Tiff);			
				}
				if(this.radioButton6.Checked)//wmf
				{
					this.pictureBox2.Image.Save(StrFileName+".wmf",System.Drawing.Imaging.ImageFormat.Wmf);			
				}		
			}
			catch(Exception Error)
			{
				MessageBox.Show(this,"保存图像文件时发生错误！","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//当前鼠标位置和颜色
			Bitmap bmp=(Bitmap)this.pictureBox1.Image;			
			try 
			{
				Color pixelColor=bmp.GetPixel(e.X,e.Y);
				this.textBoxX.Text  = e.X.ToString ();
				this.textBoxY.Text  = e.Y.ToString ();
				this.textBoxR.Text  = pixelColor.R.ToString();
				this.textBoxG.Text  = pixelColor.G.ToString();
				this.textBoxB.Text  = pixelColor.B.ToString();
			}
			catch {}
		}

		private void pictureBox2_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//当前鼠标位置和颜色
			Bitmap bmp=(Bitmap)this.pictureBox2.Image;
			try 
			{
				Color pixelColor=bmp.GetPixel(e.X,e.Y);
				this.textBoxX.Text  = e.X.ToString ();
				this.textBoxY.Text  = e.Y.ToString ();
				this.textBoxR.Text  = pixelColor.R.ToString();
				this.textBoxG.Text  = pixelColor.G.ToString();
				this.textBoxB.Text  = pixelColor.B.ToString();
			}
			catch {}
		}

		private void menuItemExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit ();
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			//浮雕			
			int Height=this.pictureBox1.Image.Height;
			int Width=this.pictureBox1.Image.Width;
			Bitmap bitmap=new Bitmap(Width,Height);
			Bitmap MyBitmap=(Bitmap)this.pictureBox1.Image;
			Color pixel1,pixel2;
			for(int x=0;x<Width-1;x++)
			{
				for(int y=0;y<Height-1;y++)
				{
					int r=0,g=0,b=0;
					pixel1=MyBitmap.GetPixel(x,y);						
					pixel2=MyBitmap.GetPixel(x+1,y+1);
					r=Math.Abs(pixel1.R-pixel2.R+128);
					g=Math.Abs(pixel1.G-pixel2.G+128);
					b=Math.Abs(pixel1.B-pixel2.B+128);
					
					//处理颜色值溢出
					r=r>255?255:r;
					r=r<0?0:r;
					g=g>255?255:g;
					g=g<0?0:g;
					b=b>255?255:b;
					b=b<0?0:b;
					bitmap.SetPixel(x,y,Color.FromArgb(r,g,b));			
				}
			}
			this.pictureBox2.Image=bitmap;	
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			//水彩画			
			int Height=this.pictureBox1.Image.Height;
			int Width=this.pictureBox1.Image.Width;
			Bitmap bitmap=new Bitmap(Width,Height);
			Bitmap MyBitmap=(Bitmap)this.pictureBox1.Image;
			Color pixel; 
			System.Random   MyRandom=new Random();                               
			for(int x=1;x<Width-1;x++)
			{
				for(int y=1;y<Height-1;y++)
				{
										
					int k=MyRandom.Next(0,8);	
					//确定位置
					switch (k)
					{
						case 0:pixel=MyBitmap.GetPixel(x-1,y-1);break;
						case 1:pixel=MyBitmap.GetPixel(x-1,y);break;
						case 2:pixel=MyBitmap.GetPixel(x-1,y+1);break;
						case 3:pixel=MyBitmap.GetPixel(x,y-1);break;
						case 4:pixel=MyBitmap.GetPixel(x,y+1);break;
						case 5:pixel=MyBitmap.GetPixel(x+1,y-1);break;
						case 6:pixel=MyBitmap.GetPixel(x+1,y);break;
						case 7:pixel=MyBitmap.GetPixel(x+1,y+1);break;
						default:pixel=MyBitmap.GetPixel(x,y);break;
					}
					bitmap.SetPixel(x,y,pixel);			
				}
			}
			this.pictureBox2.Image=bitmap;	
		
		}

		private void menuItemTransform_Click(object sender, System.EventArgs e)
		{
			//彩色到灰度转换
			Bitmap bmp;
			bmp=new Bitmap(this.openFileDialog1.FileName);
			for (int i=0;i<bmp.Width-1;i++)
			{
				for(int j=0;j<bmp.Height-1;j++)
				{
					Color Color1=bmp.GetPixel(i,j);
					int rgb=(Color1.R+Color1.G+Color1.B)/3;
					//颜色处理
					bmp.SetPixel(i,j,Color.FromArgb(rgb,rgb,rgb));
				}
			}
			this.pictureBox2.Image=bmp;	
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			//反色			
			int Height=this.pictureBox1.Image.Height;
			int Width=this.pictureBox1.Image.Width;
			Bitmap bitmap=new Bitmap(Width,Height);
			Bitmap MyBitmap=(Bitmap)this.pictureBox1.Image;
			Color pixel;
			for(int x=1;x<Width;x++)
			{
				for(int y=1;y<Height;y++)
				{
					int r,g,b;
					pixel=MyBitmap.GetPixel(x,y);						
					r=255-pixel.R;
					g=255-pixel.G;
					b=255-pixel.B;
					bitmap.SetPixel(x,y,Color.FromArgb(r,g,b));			
				}
			}
			this.pictureBox2.Image=bitmap;	
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			//柔化			
			int Height=this.pictureBox1.Image.Height;
			int Width=this.pictureBox1.Image.Width;
			Bitmap bitmap=new Bitmap(Width,Height);
			Bitmap MyBitmap=(Bitmap)this.pictureBox1.Image;
			Color pixel;
 		                             
			for(int x=1;x<Width-1;x++)
				for(int y=1;y<Height-1;y++)
				{
					int r=0,g=0,b=0;
					int Index=0;
					
					for(int col=-1;col<=1;col++)
						for(int row=-1;row<=1;row++)
						{							
							pixel=MyBitmap.GetPixel(x+row,y+col);						
							r+=pixel.R;
							g+=pixel.G;
							b+=pixel.B;
							Index++;
						}
					r/=9;
					g/=9;
					b/=9;
					//处理颜色值溢出
					r=r>255?255:r;
					r=r<0?0:r;
					g=g>255?255:g;
					g=g<0?0:g;
					b=b>255?255:b;
					b=b<0?0:b;
					bitmap.SetPixel(x-1,y-1,Color.FromArgb(r,g,b));			
				}
			this.pictureBox2.Image=bitmap;
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{			
			//锐化
			int Height=this.pictureBox1.Image.Height;
			int Width=this.pictureBox1.Image.Width;
			Bitmap bitmap=new Bitmap(Width,Height);
			Bitmap MyBitmap=(Bitmap)this.pictureBox1.Image;
			Color pixel1;
			Color pixel2;	
	   
			for(int x=1;x<Width-1;x++)
			{
				for(int y=1;y<Height-1;y++)
				{
					int r=0,g=0,b=0;
																
					pixel1=MyBitmap.GetPixel(x,y);
					pixel2=MyBitmap.GetPixel(x-1,y-1);
						
					r = pixel1.R + Math.Abs(pixel1.R - pixel2.R)/4;
					g = pixel1.G + Math.Abs(pixel1.G - pixel2.G)/4;
					b = pixel1.B + Math.Abs(pixel1.B - pixel2.B)/4;
											
					//处理颜色值溢出
					r=r>255?255:r;
					r=r<0?0:r;
					g=g>255?255:g;
					g=g<0?0:g;
					b=b>255?255:b;
					b=b<0?0:b;
					bitmap.SetPixel(x-1,y-1,Color.FromArgb(r,g,b));			
				}
			}
			this.pictureBox2.Image=bitmap;
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			//雾化
			int Height=this.pictureBox1.Image.Height;
			int Width=this.pictureBox1.Image.Width;
			Bitmap bitmap=new Bitmap(Width,Height);
			Bitmap MyBitmap=(Bitmap)this.pictureBox1.Image;
			Color pixel; 
			System.Random   MyRandom=new Random();				                                   
			for(int x=1;x<Width-1;x++)
				for(int y=1;y<Height-1;y++)
				{
					int k=MyRandom.Next(111111);	
					//像素块大小
					int dx=x+k%20;
					int dy=y+k%20;
					if(dx>=Width)
						dx=Width-1;
					if(dy>=Height)
						dy=Height-1;
					pixel=MyBitmap.GetPixel(dx,dy);
					bitmap.SetPixel(x,y,pixel);			
				}
			this.pictureBox2.Image=bitmap;
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			//水平百叶窗
		    try
		    {
		        Bitmap MyBitmap;
		        MyBitmap=(Bitmap)this.pictureBox1.Image.Clone();
		        int dh=MyBitmap.Height/30;
		        int dw=MyBitmap.Width;
		        Point []MyPoint=new Point[30];
		        for(int y=0;y< 30; y++)
		        {
		            MyPoint[y].X=0;
		            MyPoint[y].Y=y*dh;
		        }
		        Bitmap bitmap=new Bitmap(MyBitmap.Width,MyBitmap.Height);
		        for(int i=0;i<dh;i++)
		        {
		            for(int j=0;j<20;j++)
		            {
		                for(int k=0;k<dw;k++)
		                {
		                    bitmap.SetPixel(MyPoint[j].X+k,MyPoint[j].Y+i,MyBitmap.GetPixel(MyPoint[j].X+k,MyPoint[j].Y+i));
		                }
		            }
		            this.pictureBox2.Refresh();
		            this.pictureBox2.Image=bitmap;			
		            Thread.Sleep(100);
		        }
		    }
		    catch (Exception exception)
		    {
		        Console.WriteLine(exception);
		        throw;
		    }
        }

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			//从左到右拉伸显示
			Bitmap MyBitmap;
			MyBitmap=new Bitmap(this.pictureBox1.Image);
			int iWidth=this.pictureBox1.Width; //图像宽度	
			int iHeight=this.pictureBox1.Height; //图像高度
			this.pictureBox2.Image = this.pictureBox1.Image;
			
			//取得Graphics对象
			Graphics g=this.pictureBox2.CreateGraphics();
			g.Clear(Color.Gray); //初始为灰色
			for(int x=0;x<=iWidth;x++)
			{
				g.DrawImage(MyBitmap,0,0,x,iHeight);
			    System.Threading.Thread.Sleep(10);
            }

		   

		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			//从上到下拉伸显示
			Bitmap MyBitmap;
			MyBitmap=new Bitmap(this.pictureBox1.Image);
			this.pictureBox2.Image = this.pictureBox1.Image;
			int iWidth=this.pictureBox1.Width; //图像宽度	
			int iHeight=this.pictureBox1.Height; //图像高度
			
			//取得Graphics对象
			Graphics g=this.pictureBox2.CreateGraphics();
			g.Clear(Color.Gray); //初始为灰色
			for(int y=0;y<=iHeight;y++)			
			{
				g.DrawImage(MyBitmap,0,0,iWidth,y);
			       Thread.Sleep(10);
            }
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			//中心扩散显示
			Bitmap MyBitmap;
			this.pictureBox2.Image = this.pictureBox1.Image;
			MyBitmap=new Bitmap(this.pictureBox2.Image);
			
			int iWidth=this.pictureBox2.Width; //图像宽度	
			int iHeight=this.pictureBox2.Height; //图像高度
			
			//取得Graphics对象
			Graphics g=this.pictureBox2.CreateGraphics();
			g.Clear(Color.Gray); //初始为灰色
			for(int x=0;x<=iWidth/2;x++)			
			{
				Rectangle DestRect=new Rectangle(iWidth/2-x,iHeight/2-x,2*x,2*x);
				Rectangle SrcRect=new  Rectangle(0,0,MyBitmap.Width,MyBitmap.Height);
				g.DrawImage(MyBitmap,DestRect,SrcRect,GraphicsUnit.Pixel);
			    Thread.Sleep(10);
            }
		}

		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			//反转
			Bitmap MyBitmap;
			this.pictureBox2.Image = this.pictureBox1.Image;
			MyBitmap=new Bitmap(this.pictureBox2.Image);

			int iWidth=this.pictureBox2.Width; //图像宽度	
			int iHeight=this.pictureBox2.Height; //图像高度

			//取得Graphics对象
			Graphics g=this.pictureBox2.CreateGraphics();
			g.Clear(Color.Gray); //初始为灰色
			for(int x=-iWidth/2;x<=iWidth/2;x++)		
			{
				Rectangle DestRect=new Rectangle(0,iHeight/2-x,iWidth,2*x);
				Rectangle SrcRect=new Rectangle(0,0,MyBitmap.Width,MyBitmap.Height);	
				g.DrawImage(MyBitmap,DestRect,SrcRect,GraphicsUnit.Pixel);
			    Thread.Sleep(10);
            }
		}

		private void menuItem13_Click(object sender, System.EventArgs e)
		{
			//两边拉伸显示
			Bitmap MyBitmap;
			this.pictureBox2.Image = this.pictureBox1.Image;
			MyBitmap=new Bitmap(this.pictureBox2.Image);

			int iWidth=this.pictureBox2.Width; //图像宽度	
			int iHeight=this.pictureBox2.Height; //图像高度

			//取得Graphics对象
			Graphics g=this.pictureBox2.CreateGraphics();
			g.Clear(Color.Gray); //初始为灰色
			for(int y=0;y<=iWidth/2;y++)			
			{
				Rectangle DestRect=new Rectangle(iWidth/2-y,0,2*y,iHeight);
				Rectangle SrcRect=new Rectangle(0,0,MyBitmap.Width,MyBitmap.Height);
				g.DrawImage(MyBitmap,DestRect,SrcRect,GraphicsUnit.Pixel);
			    Thread.Sleep(10);
            }
		}

		private void menuItemCopy_Click(object sender, System.EventArgs e)
		{
			//复制图像
			if(this.pictureBox1.Image.Size.Height<1)
			{
				MessageBox.Show("请打开图像文件后再执行本操作！","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			Clipboard.SetDataObject(this.pictureBox1.Image.Clone());
			MessageBox.Show("图像成功复制到剪贴板！","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Information);			
		
		}

		private void menuItemPaste_Click(object sender, System.EventArgs e)
		{
			//粘贴图像
			try
			{
				IDataObject MyData = Clipboard.GetDataObject ( ) ;//得到剪贴板数据
				
				if ( MyData.GetDataPresent ( DataFormats.Bitmap ) ) //剪切板中数据是位图
				{
					//获得位图对象
					Bitmap MyBitmap = ( Bitmap ) MyData.GetData ( DataFormats.Bitmap ) ;
					//显示图片 
					this.pictureBox1.Image=MyBitmap;
					this.pictureBox2.Image=MyBitmap;
					MessageBox.Show("图像粘贴成功！","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
				else
				{//如果剪贴板上没有图像数据，提示用户
					MessageBox.Show("剪贴板上没有图像，无法粘贴！","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			}
			catch(Exception Err)
			{//粘贴剪贴板数据出错		
				MessageBox.Show("错误信息是： "+Err.Message,"信息提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void menuItem15_Click(object sender, System.EventArgs e)
		{
			//平移变换
			int dx=0;
			int dy=0;
			if (this.textBoxMX.Text == "" || this.textBoxMY.Text =="")
			{
				MessageBox.Show("请输入平移后图像位置坐标(MX，MY)！","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			Bitmap bitmap=new Bitmap(this.pictureBox1.Image);
			Bitmap MyBitmap=new Bitmap(this.pictureBox2.Image);
			Graphics g = pictureBox2.CreateGraphics ();
			dx = Convert.ToInt32 (this.textBoxMX.Text );
			dy = Convert.ToInt32 (this.textBoxMY.Text );

			g.Clear (this.pictureBox2 .BackColor );//清除
			g.TranslateTransform (dx,dy);//向右、向下平移dx, dy
			g.DrawImage(bitmap,this.pictureBox2.ClientRectangle,0,0,MyBitmap.Width ,MyBitmap.Height ,GraphicsUnit.Pixel);//重画picturebox2
 			
		}

		private void menuItem16_Click(object sender, System.EventArgs e)
		{
			//比例变换
			float dx=0;
			float dy=0;
			if (this.textBoxPX.Text == "" || this.textBoxPY.Text =="")
			{
				MessageBox.Show("请输入图像变换比例(PX，PY)！","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			Bitmap bitmap=new Bitmap(this.pictureBox1.Image);
			Bitmap MyBitmap=new Bitmap(this.pictureBox1.Image);
			Graphics g = pictureBox2.CreateGraphics ();
			g.Clear (this.pictureBox2 .BackColor );//清除
			dx = Convert.ToSingle(this.textBoxPX.Text);
			dy = Convert.ToSingle(this.textBoxPY.Text);
			g.ScaleTransform (dx,dy);//X方向缩放dx,Y方向缩放dy
			g.DrawImage(bitmap,this.pictureBox2.ClientRectangle,0,0,MyBitmap.Width ,MyBitmap.Height ,GraphicsUnit.Pixel);//重画picturebox2
		
		}

		private void menuItem17_Click(object sender, System.EventArgs e)
		{
			//旋转
			float ra=0;
			if (this.textBoxRA.Text == "" )
			{
				MessageBox.Show("请输入图像旋转角度(RA)！","信息提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			ra = Convert.ToSingle(this.textBoxRA.Text);
			Bitmap bitmap=new Bitmap(this.pictureBox1.Image);
			Bitmap MyBitmap=new Bitmap(this.pictureBox1.Image);
			Graphics g = pictureBox2.CreateGraphics ();
			g.Clear (this.pictureBox2 .BackColor );//清除
			g.RotateTransform (ra);//旋转ra度
			g.DrawImage(bitmap,this.pictureBox2.ClientRectangle,0,0,MyBitmap.Width ,MyBitmap.Height ,GraphicsUnit.Pixel);//重画picturebox2
		
		}

		private void menuItem20_Click(object sender, System.EventArgs e)
		{
		    try
		    {
		        //创建缩略图
		        Image image = new Bitmap(this.pictureBox1.Image );
		        int dx = this.pictureBox1.Image.Size.Width/130;//确定缩略图Y方向比例, X方向为130
		        int dy =(int)(this.pictureBox1.Image.Size.Height/(dx+0.01)) ;//
		        Image pThumbnail = image.GetThumbnailImage(130, dy, null, new IntPtr());
			
		        this.CreateGraphics().DrawImage( pThumbnail,432,400,pThumbnail.Width,pThumbnail.Height);

		    }
		    catch (Exception exception)
		    {
		        Console.WriteLine(exception);
		        throw;
		    }
		}

		private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Cursor.Current = Cursors.Default;
		}
	}
}
