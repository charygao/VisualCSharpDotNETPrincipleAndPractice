using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;//add
namespace 注册系统热键
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		#region DLLImport
		[DllImport("user32.dll")]
		public extern static int RegisterHotKey(
			IntPtr hWnd, // handle to window//窗口句柄
			int id, // hot key identifier//热键标识
			uint fsModifiers, // key-modifier options//热键标识
			Keys vk // virtual-key code//代号
			);
		[DllImport("user32.dll")]
		public extern static int UnregisterHotKey(
			IntPtr hWnd, // handle to window//窗口句柄
			int id // hot key identifier//热键标识
			);
		#endregion
		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			RegisterHotKey(this.Handle, 100, 2, Keys.T);

		}
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0x0312)//0x0312 是windows消息WM_HOTKEY（表示用户按下了热键，可用于算定义热键等）的十六进制表示形式
			{
				MessageBox.Show("Hot Key\nKeyNo:"+m.WParam.ToString());
			}
			base.WndProc(ref m);
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
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);

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

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			UnregisterHotKey(this.Handle, 100);
		}
	}
}
