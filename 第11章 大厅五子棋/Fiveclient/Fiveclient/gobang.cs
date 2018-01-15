using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace Fiveclient
{
    public class gobang
    {
        public gobang()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        ~gobang()
        {
        }
        public int[,] down = new int[25, 25];
        public int cellx, celly, oldcellx, oldcelly;
        public bool myturn = true;
        private int r = 35;
        public int whitenum = 0, blacknum = 0, pointx, pointy;
        public Bitmap bmp, bmpb, bmpw;
        public void AddBmp(Bitmap map, Bitmap white, Bitmap black)
        {
            this.bmp = map;
            this.bmpw = white;
            this.bmpb = black;
        }
        /// <summary>
        /// 返回是否可以在此处下子
        /// </summary>
        /// <returns></returns>
        public bool CanDown()
        {
            if (down[cellx, celly] == 0) return true;
            else return false;
        }

        private Bitmap Down()
        {
            int x = cellx * r + 5;
            int y = celly * r + 8;
            if (myturn)
                for (int w = 0; w < bmpw.Width; w++)
                {
                    for (int h = 0; h < bmpw.Height; h++)
                    {
                        Color color = bmpw.GetPixel(w, h);
                        if (color.R == 0 && color.G == 0 && color.B == 255)
                            continue;
                        bmp.SetPixel(w + x, h + y, color);
                    }
                }
            else
                for (int w = 0; w < bmpw.Width; w++)
                {
                    for (int h = 0; h < bmpw.Height; h++)
                    {
                        Color color = bmpb.GetPixel(w, h);
                        if (color.R == 0 && color.G == 0 && color.B == 255)
                            continue;
                        bmp.SetPixel(w + x, h + y, color);
                    }
                }
            return bmp;
            //			this.pictureBox1.Image=bmp;
        }
        /// <summary>
        /// 图片棋子
        /// </summary>
        private void BmpPiece()
        {
            //			if(CanDown())
            //			{
            ////				this.pictureBox1.Cursor=this.pictureBox3.Cursor;
            ////				this.pictureBox1.Refresh();
            //				if(myturn)
            //				{
            //					this.pictureBox4.Location=new Point(cellx*r-r/2+21,celly*r+24-r/2);
            //					this.pictureBox4.Visible=true;
            //					this.pictureBox5.Visible=false;
            //				}
            //				else
            //				{
            //					this.pictureBox5.Location=new Point(cellx*r-r/2+21,celly*r+24-r/2);
            //					this.pictureBox4.Visible=false;
            //					this.pictureBox5.Visible=true;
            //				}
            //				oldcellx=cellx;
            //				oldcelly=celly;				
            //			}
            //			else
            //			{
            //				this.pictureBox1.Cursor=this.pictureBox2.Cursor;
            //			}
        }

        /// <summary>
        /// 在棋盘上下一个棋子
        /// </summary>
        public Bitmap DownthePoint(out string txt1, out string txt2)
        {
            if (myturn)
            {
                whitenum++; down[cellx, celly] = 1;
            }
            else
            {
                blacknum++; down[cellx, celly] = -1;
            }
            txt1 = whitenum.ToString();
            txt2 = blacknum.ToString();

            Bitmap newmap = Down();
            myturn = (!myturn);
            return newmap;
        }

        private void DrawPiece(System.Windows.Forms.PictureBox p1)
        {
            p1.Refresh();
            if (CanDown())
            {
                Graphics g = p1.CreateGraphics();

                if (myturn)
                {
                    Brush br = new SolidBrush(Color.White);
                    g.FillEllipse(br, cellx * r - r / 2 + 21, celly * r + 24 - r / 2, r, r);
                    br.Dispose();
                }
                else
                {
                    Brush br = new SolidBrush(Color.Black);
                    g.FillEllipse(br, cellx * r - r / 2 + 21, celly * r + 24 - r / 2, r, r);
                    br.Dispose();
                }
                oldcellx = cellx;
                oldcelly = celly;

                p1.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            else
            {
                p1.Cursor = System.Windows.Forms.Cursors.No;
            }

        }
        /// <summary>
        /// 画出的棋子移动
        /// </summary>
        public void cheesemove(System.Windows.Forms.PictureBox p1, bool myturn)
        {
            if (!myturn) return;
            cellx = pointx / r;
            celly = pointy / r;
            int x = pointx % r;
            int y = pointy % r;
            if (x > r / 2) cellx++;
            if (y > r / 2) celly++;
            if (oldcellx == cellx && oldcelly == celly || cellx > 14 || celly > 14)
            {
                return;
            }
           // DrawPiece(p1);
        }
    }
}
