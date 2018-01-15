using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;//add
namespace 定时抓取当前程序窗口
{
    public partial class Form1 : Form
    {
        private int n=0;
        public Form1()
        {
            InitializeComponent();
        }
public void SaveWindowsScreen(string filename)
{
Image newImage = new Bitmap(this.Width, this.Height);
Graphics newGraphics = Graphics.FromImage(newImage);
IntPtr ImageDc = newGraphics.GetHdc();
IntPtr SourceDc = NativeMethods.GetWindowDC(this.Handle);
NativeMethods.BitBlt(ImageDc, 0, 0,this.Width, this.Height, SourceDc, 0, 0, 13369376);
newGraphics.ReleaseHdc(ImageDc);
newImage.Save(filename);
}

private void timer1_Tick(object sender, EventArgs e)
{
    label1.Text = DateTime.Now.ToString();
    n = n + 1;
    SaveWindowsScreen("screenshot" + n.ToString() + ".jpg");
}

private void button1_Click(object sender, EventArgs e)
{
    timer1.Enabled = true;
}

private void button2_Click(object sender, EventArgs e)
{
    timer1.Enabled = false;
}
}
internal class NativeMethods//form必须是第一个类
{//internal 关键字是类型和类型成员的访问修饰符。只有在同一程序集的文件中，内部类型或成员才是可访问的
#region DLL导入
[DllImport("user32.dll")]
public extern static IntPtr GetDesktopWindow();
[DllImport("user32.DLL")]
public static extern IntPtr GetWindowDC(IntPtr hwnd);
[DllImport("gdi32.DLL")]
public static extern UInt64 BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight,
                            IntPtr hSrcDC,int xSrc, int ySrc, Int32 dwRop);//System.Int32
#endregion
}
}
