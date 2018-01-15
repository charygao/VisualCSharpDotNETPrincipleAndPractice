using System;
using System.Drawing;

namespace RedSnake
{
	/// <summary>
	/// Snake的基础单元,Snake的画面组成基础
	/// </summary>
	public class SnakeSegment
	{
		private Rectangle m_rect;

        public SnakeSegment(Point location,int width)
		{
			m_rect = new Rectangle(location,new Size(width,width));
		}

		//ReadOnly
		public Rectangle Rectangle
		{
			get
			{
				return m_rect;
			}
		}

		public Point Location
		{
			get
			{
				return this.m_rect.Location;
			}
			set
			{
				this.m_rect.Location = value;
			}
		}

		//ReadOnly
		public Size Size
		{
			get
			{
				return this.m_rect.Size;
			}
		}

		public SnakeSegment Clone()
		{
			return new SnakeSegment(this.m_rect.Location, this.m_rect.Width);
		}

		public override string ToString()
		{
			return (this.GetType().ToString() + ": " + this.m_rect.Location.ToString());
		}

	}
}
