using System;
using System.Collections.Generic;
using System.Text;

namespace Fiveclient
{
    public class IsWin
    {
        int[,] down;
        public IsWin(int[,] p)
        {
            down = p;
        }
        public int Win(int cellx, int celly)
        {
            for (int i = 0; i < 5; i++)
            {
                int xall = Wfive(cellx - i, celly);
                if (Math.Abs(xall) == 5) return xall;
                int yall = Hfive(cellx, celly - i);
                if (Math.Abs(yall) == 5) return yall;
                int xyall = Piefive(cellx + i, celly - i);
                if (Math.Abs(xyall) == 5) return xyall;
                xyall = Lafive(cellx - i, celly - i);
                if (Math.Abs(xyall) == 5) return xyall;
            }

            return 0;
        }
        private int Wfive(int xbegin, int y)
        {
            int all = 0;
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    all = all + down[xbegin + i, y];
                }
                catch
                {
                    return 0;
                }
            }
            return all;

        }
        private int Hfive(int x, int ybegin)
        {
            int all = 0;
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    all = all + down[x, ybegin + i];
                }
                catch
                {
                    return 0;
                }
            }
            return all;
        }
        private int Piefive(int x, int y)
        {
            int all = 0;
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    all = all + down[x - i, y + i];
                }
                catch
                {
                    return 0;
                }
            }
            return all;
        }
        private int Lafive(int x, int y)
        {
            int all = 0;
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    all = all + down[x + i, y + i];
                }
                catch
                {
                    return 0;
                }
            }
            return all;
        }
    }
}
