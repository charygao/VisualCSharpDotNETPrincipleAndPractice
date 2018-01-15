using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace RedSnake
{
	/// <summary>
	/// 控制移动。
	/// </summary>
	public class Control
	{
		private Point m_location;   //Snake Head Location
		private int m_increment;    //Snake Draw with to move
		private SnakeDirection m_direction;
		public Control()
		{
			m_increment = 8;
			m_location = new Point(0,0);
			Direction = SnakeDirection.Right;
		}

		//OverLoad the Constructer with paras
		internal Control(int newIncrement,Point startLocation,SnakeDirection newDirection)
		{
			if ((newDirection < SnakeDirection.Left) || (newDirection > SnakeDirection.Up))
			{
				throw new ArgumentOutOfRangeException("Direction", "Direction must be Left [0], Down [1], Right [2], or Up [3]");
			}
			this.m_direction = newDirection;
			this.m_increment = newIncrement;
			this.m_location = startLocation;
		}

		internal enum SnakeDirection
		{
			//Fields
			None = -1,
			Down = 1,
			Left = 0,
			Right = 2,
			Up = 3		    
		}



		//Find the Next Movement Loaction But Not Move It
		internal Point PeekNextLoaction([OptionalAttribute]SnakeDirection peekDir /* =SnakeDirection.None */)
		{
			Point retPt = new Point(this.m_location.X,this.m_location.Y);
			if(peekDir == SnakeDirection.None)
			{
				peekDir = m_direction;
			}
			switch(peekDir)
			{
				case SnakeDirection.Left:
					retPt.X -= this.m_increment;
					return retPt;

				case SnakeDirection.Right:
					retPt.X += this.m_increment;
					return retPt;

				case SnakeDirection.Up:
					retPt.Y -= this.m_increment;
					return retPt;

				case SnakeDirection.Down:
					retPt.Y += this.m_increment;
					return retPt;
			}
			return retPt;
		}

		//Move The snake based on the current direction
		internal void Move(SnakeDirection moveDir /* = SnakeDirection.None */)
		{
			if(moveDir == SnakeDirection.None)
			{
				moveDir = this.m_direction;
			}
			switch (moveDir)
			{
				case SnakeDirection.Left:
					this.m_location.X -= this.m_increment;
					return;

				case SnakeDirection.Right:
					this.m_location.X += this.m_increment;
					return;

				case SnakeDirection.Up:
					this.m_location.Y -= this.m_increment;
					return;

				case SnakeDirection.Down:
					this.m_location.Y += this.m_increment;
					return;
			}
		}

		internal void Move()
		{
			Move(SnakeDirection.None);
		}

		//ReadOnly
		public Point Location
		{
			get
			{
				return this.m_location;
			}
		}

		internal SnakeDirection Direction
		{
			get
			{
				return m_direction;
			}
			set
			{
				if(value < SnakeDirection.Left || value > SnakeDirection.Up)
					throw new ArgumentOutOfRangeException("Direction must be Left [0], Down [1], Right [2], or Up [3]");
				if(value != m_direction && Math.Abs(value - m_direction)%2 !=0)
				{
					this.m_direction = value;
				}
			}
		}

		//逆时针
		public void TurnLeft()
		{
			if (!((this.m_direction < SnakeDirection.Left) | (this.m_direction > SnakeDirection.Up)))
			{
				SnakeDirection newDir = (SnakeDirection)(m_direction+1);
				if (newDir > SnakeDirection.Up)
				{
					newDir = SnakeDirection.Left;
				}
				this.Direction = newDir;
			}

		}

		//顺时针
		public void TurnRight()
		{
			if (!((this.m_direction < SnakeDirection.Left) | (this.m_direction > SnakeDirection.Up)))
			{
				SnakeDirection newDir = (SnakeDirection)(m_direction-1);
				if ( newDir < SnakeDirection.Left)
				{
					newDir = SnakeDirection.Up;
				}
				this.Direction = newDir;
			}
		}

		public int Increment
		{
			get
			{
				return this.m_increment;
			}
		}
 
	}
}
