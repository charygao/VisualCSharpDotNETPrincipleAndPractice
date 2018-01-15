using System;
using System.Drawing;
using System.Collections;

namespace RedSnake
{
	/// <summary>
	/// Snake 逻辑单元 
	/// SnakeSegment存放与Queue中
	/// </summary>
	public class Snake
	{
		const int MAXSNAKELENGTH = 512;          //Max Value
		const int DEFAULTLENGTH = 4;              //Defaule Value
		const int DEFAULTWIDTH = 8; 
		Queue m_segs;
		int m_width;

		public int Length
		{
			get
			{
				return m_segs.Count;
			}
		}

		private void InitSnake(Point snakePoint,int snakeWidth,int snakeLength)
		{
			m_width = snakeWidth;
			Point segLocation = snakePoint;
			for(int i=1;i<= snakeLength;i++)
			{
				Add(segLocation);
				//定义下一个segment的位置
				segLocation.X -= m_width;
			}
		}

		public Snake()
		{
			InitSnake(new Point(DEFAULTWIDTH*DEFAULTLENGTH,0),DEFAULTWIDTH,DEFAULTLENGTH);
		}

		//Overload constructor
		public Snake(Point startPoint,int snakeWidth,int snakeLength)
		{
			InitSnake(startPoint,snakeWidth,snakeLength);
		}

		//Add a SegMent to the front of the queue
		public void Add(Point newLocation)
		{
			SnakeSegment newhead = new SnakeSegment(newLocation,m_width);

			//Check if the Queue Exists
			if(m_segs == null)
			{
				m_segs = new Queue(MAXSNAKELENGTH);
			}
			else if(m_segs.Count == MAXSNAKELENGTH)
			{
				//if full
				Slither(newLocation);
				return;
			}

			m_segs.Enqueue(newhead);
		}

		public void Clear()
		{
			m_segs.Clear();
		}

		//ReadOnly
		internal SnakeSegment[] Segments
		{
			get
			{
				SnakeSegment[] retarray = new SnakeSegment[this.m_segs.Count];
				m_segs.CopyTo(retarray,0);
				return retarray;
			}
		}

		//Move the Snake Use Add a head new and clear the tail Method
		public void Slither(Point newLocation)
		{
			SnakeSegment newhead = new SnakeSegment(newLocation, this.m_width);
			this.m_segs.Enqueue(newhead);
			this.m_segs.Dequeue();
		}

		public SnakeSegment Head
		{
			get
			{
				return ((SnakeSegment) this.m_segs.Peek()).Clone();
			}
		}
 
		//Returns if the Point is On the Snake
		public bool PointOnSnake(Point pt)
		{
			IEnumerator myenum = this.m_segs.GetEnumerator();
			while (myenum.MoveNext())
			{
				if (((SnakeSegment) myenum.Current).Rectangle.Contains(pt))
				{
					return true;
				}
			}
			return false;
		}

 



 

	}
}
