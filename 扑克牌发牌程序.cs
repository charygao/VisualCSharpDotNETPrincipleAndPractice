using System;
using System.Collections.Generic;
using System.Text;
//扑克牌发牌程序
namespace 发牌程序
{
    class card
    {
        // Suit指的是花色，1为梅花，2为方钻，3为红心，4为黑桃  
        public byte Suit;
        public byte FaceNum ;   // FaceNum 指的是牌面数字 1--13 
        public card(byte Suit, byte FaceNum )//构造函数
        {
            this.FaceNum  = FaceNum ;
            this.Suit = Suit;
        }
        public int pic_order()//牌的顺序号
        {
            return (Suit - 1) * 13 + FaceNum ;
        }
        public override string ToString()//重载ToString()方法
        {
            string SuitName;//花色名
            switch (Suit)
            {
                case 1:
                    SuitName = "梅";
                    break;
                case 2:
                    SuitName = "方";
                    break;
                case 3:
                    SuitName = "红";
                    break;
                case 4:
                    SuitName = "黑";
                    break;
                default:
                    SuitName = "";
                    break;
            }
            string FaceNumName;//牌面点数名
            switch (FaceNum )
            {
                case 1:
                    FaceNumName = "A";
                    break;
                case 11:
                    FaceNumName = "J";
                    break;
                case 12:
                    FaceNumName = "Q";
                    break;
                case 13:
                    FaceNumName = "K";
                    break;
                default:
                    FaceNumName = FaceNum .ToString();
                    break;
            }
            return string.Format("{0}{1}", SuitName, FaceNumName);
        }
    }
    class Poke//一副牌
    {   //牌列表CardList
        public static List<card> CardList = new List<card>();
        public static Random r = new Random();
        public Poke()
        {
            for (byte i = 1; i <= 4; i++)
            {
                for (byte j = 1; j <= 13; j++)
                {
                    CardList.Add(new card(i, j));
                }
            }
        }
        public card Shuffle()//发牌
        {
            if (CardList.Count <= 0) return null;
            card c = null;
            int i = (int)(CardList.Count * r.NextDouble());//随机产生索引号
            c = CardList[i];//获取索引号为ｉ的牌
            CardList.RemoveAt(i);//从列表中删除此张牌
            return c;//返回抽取索引号为ｉ的牌
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Poke Poke1 = new Poke();//Poke实例Poke1
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine("{0}号牌手:", i);
                for (int j = 1; j <= 13; j++)
                {
                    card card1 = Poke1.Shuffle();//获取一张牌
                    if (card1 != null)
                    {
                        Console.Write(" {0}", card1.ToString());
                        //Console.Write(":{0}", card1.pic_order());
                    }             
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
