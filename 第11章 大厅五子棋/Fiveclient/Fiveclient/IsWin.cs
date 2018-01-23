using System;

namespace Fiveclient
{
    public class IsWin
    {
        #region Fields and Properties

        private readonly int[,] _down;

        #endregion

        #region  Constructors

        public IsWin(int[,] p)
        {
            _down = p;
        }

        #endregion

        #region  Methods

        public int Win(int cellx, int celly)
        {
            for (var i = 0; i < 5; i++)
            {
                var xall = Wfive(cellx - i, celly);
                if (Math.Abs(xall) == 5) return xall;
                var yall = Hfive(cellx, celly - i);
                if (Math.Abs(yall) == 5) return yall;
                var xyall = Piefive(cellx + i, celly - i);
                if (Math.Abs(xyall) == 5) return xyall;
                xyall = Lafive(cellx - i, celly - i);
                if (Math.Abs(xyall) == 5) return xyall;
            }

            return 0;
        }

        private int Hfive(int x, int ybegin)
        {
            var all = 0;
            for (var i = 0; i < 5; i++)
                try
                {
                    all = all + _down[x, ybegin + i];
                }
                catch
                {
                    return 0;
                }

            return all;
        }

        private int Lafive(int x, int y)
        {
            var all = 0;
            for (var i = 0; i < 5; i++)
                try
                {
                    all = all + _down[x + i, y + i];
                }
                catch
                {
                    return 0;
                }

            return all;
        }

        private int Piefive(int x, int y)
        {
            var all = 0;
            for (var i = 0; i < 5; i++)
                try
                {
                    all = all + _down[x - i, y + i];
                }
                catch
                {
                    return 0;
                }

            return all;
        }

        private int Wfive(int xbegin, int y)
        {
            var all = 0;
            for (var i = 0; i < 5; i++)
                try
                {
                    all = all + _down[xbegin + i, y];
                }
                catch
                {
                    return 0;
                }

            return all;
        }

        #endregion
    }
}