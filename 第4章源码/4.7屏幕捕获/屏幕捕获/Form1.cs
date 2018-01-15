using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//add
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
namespace 屏幕捕获
{
    public partial class Form1 : Form
    {
private Bitmap MyImage = null;
        public Form1()
        {
            InitializeComponent(); //定义中添加
        }
#region DLL导入
        [DllImport("GDI32.DLL")]//DllImportAttribute()//, EntryPoint = "BitBlt"
        private extern static bool BitBlt(
IntPtr hdcDest,//目标设备的句柄
int nXDest,//目标对象的左上角的X坐标
int nYDest,//目标对象的左上角的Y坐标
int nWidth,//目标对象的矩形的宽度
int nHeight,//目标对象的矩形的长度
IntPtr hdcSrc,//源设备的句柄
int nXSrc,//源设备的左上角的X坐标
int nYSrc,//源对象的左上角的Y坐标
System.Int32 dwRop//光栅的操作值
);
[System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]//EntryPoint = "CreateDC"
private static extern IntPtr CreateDC(
string lpszDriver,//驱动名称
string lpszDevice,//设备名称
string lpszOutput,//无用，可以设定为NULL
IntPtr lpInitData//任意的打印机数据
);
#endregion

private void Form1_Load(object sender, EventArgs e)
{
    //add设定图片程序的各个属性
}

private void 捕获当前屏幕ToolStripMenuItem_Click(object sender, EventArgs e)
{
    this.Visible = false;
    IntPtr dc1 = CreateDC("display", null, null, (IntPtr)null);//创建显示器的DC
    Graphics g1 = Graphics.FromHdc(dc1);//由一个指定设备的句柄创建一个新的Graphics对象
    MyImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, g1);//根据屏幕大小创建一个与之相同大小的Bitmap对象
    Graphics g2 = Graphics.FromImage(MyImage);//获得屏幕的句柄
    IntPtr dc3 = g1.GetHdc();//获得位图的句柄
    IntPtr dc2 = g2.GetHdc();//把当前屏幕捕获到位图对象中
    BitBlt(dc2, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, dc3, 0, 0, 13369376);//scrcopy=13369376//代表图片转移时的操作方式为覆盖 
    //把当前屏幕复制到位图中
    g1.ReleaseHdc(dc3);//释放屏幕句柄
    g2.ReleaseHdc(dc2);//释放位图句柄
    MyImage.Save("MyJpeg.jpg", ImageFormat.Jpeg);
    MessageBox.Show("已经把当前屏幕保存到MyJpeg.jpg文件中！");
    this.Visible = true;
}

private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
{
    Trayicon.Visible = false;//隐藏托盘程序的图标
    this.Close();//关闭系统
}
    }
}
