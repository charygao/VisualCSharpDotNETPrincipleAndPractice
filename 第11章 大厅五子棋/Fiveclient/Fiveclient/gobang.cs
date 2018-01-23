using System.Drawing;
using System.Windows.Forms;

namespace Fiveclient
{
    public class Gobang
    {
        #region Fields and Properties

        private Bitmap _bmp;
        private Bitmap _bmpb;
        private Bitmap _bmpw;
        public int Cellx, Celly;
        private int _oldcellx;
        private int _oldcelly;
        public readonly int[,] down = new int[25, 25];
        public bool Myturn = true;
        private int _whitenum;
        private int _blacknum;
        public int Pointx, Pointy;
        private readonly int _r = 35;

        #endregion

        #region  Constructors

        ~Gobang()
        {
        }

        #endregion

        #region  Methods

        public void AddBmp(Bitmap map, Bitmap white, Bitmap black)
        {
            _bmp = map;
            _bmpw = white;
            _bmpb = black;
        }

        /// <summary>
        ///     返回是否可以在此处下子
        /// </summary>
        /// <returns></returns>
        public bool CanDown()
        {
            if (down[Cellx, Celly] == 0) return true;
            return false;
        }

        /// <summary>
        ///     画出的棋子移动
        /// </summary>
        public void cheesemove(PictureBox p1, bool myturn)
        {
            if (!myturn) return;
            Cellx = Pointx / _r;
            Celly = Pointy / _r;
            var x = Pointx % _r;
            var y = Pointy % _r;
            if (x > _r / 2) Cellx++;
            if (y > _r / 2) Celly++;
            if (_oldcellx == Cellx && _oldcelly == Celly || Cellx > 14 || Celly > 14) return;
            DrawPiece(p1);
        }

        /// <summary>
        ///     在棋盘上下一个棋子
        /// </summary>
        public Bitmap DownthePoint(out string txt1, out string txt2)
        {
            if (Myturn)
            {
                _whitenum++;
                down[Cellx, Celly] = 1;
            }
            else
            {
                _blacknum++;
                down[Cellx, Celly] = -1;
            }

            txt1 = _whitenum.ToString();
            txt2 = _blacknum.ToString();

            var newmap = Down();
            Myturn = !Myturn;
            return newmap;
        }

        /// <summary>
        ///     图片棋子
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

        private Bitmap Down()
        {
            var x = Cellx * _r + 5;
            var y = Celly * _r + 8;
            if (Myturn)
                for (var w = 0; w < _bmpw.Width; w++)
                for (var h = 0; h < _bmpw.Height; h++)
                {
                    var color = _bmpw.GetPixel(w, h);
                    if (color.R == 0 && color.G == 0 && color.B == 255)
                        continue;
                    _bmp.SetPixel(w + x, h + y, color);
                }
            else
                for (var w = 0; w < _bmpw.Width; w++)
                for (var h = 0; h < _bmpw.Height; h++)
                {
                    var color = _bmpb.GetPixel(w, h);
                    if (color.R == 0 && color.G == 0 && color.B == 255)
                        continue;
                    _bmp.SetPixel(w + x, h + y, color);
                }

            return _bmp;
            //			this.pictureBox1.Image=bmp;
        }

        private void DrawPiece(PictureBox p1)
        {
            p1.Refresh();
            if (CanDown())
            {
                var g = p1.CreateGraphics();

                if (Myturn)
                {
                    Brush br = new SolidBrush(Color.White);
                    g.FillEllipse(br, Cellx * _r - _r / 2 + 21, Celly * _r + 24 - _r / 2, _r, _r);
                    br.Dispose();
                }
                else
                {
                    Brush br = new SolidBrush(Color.Black);
                    g.FillEllipse(br, Cellx * _r - _r / 2 + 21, Celly * _r + 24 - _r / 2, _r, _r);
                    br.Dispose();
                }

                _oldcellx = Cellx;
                _oldcelly = Celly;

                p1.Cursor = Cursors.Hand;
            }
            else
            {
                p1.Cursor = Cursors.No;
            }
        }

        #endregion
    }
}