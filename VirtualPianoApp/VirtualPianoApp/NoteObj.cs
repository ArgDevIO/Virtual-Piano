using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPianoApp
{
	class NoteObj
	{
		public Point position { get; set; }
		public MyTime time;
		public string noteName;
		public int width;

		public NoteObj(Point xy, MyTime tt, string noteName, int width)
		{
			this.position = xy;
			this.time = tt;
			this.noteName = noteName;
			this.width = width;
		}

		public void Draw(Graphics g)
		{
			Brush b = new SolidBrush(Color.Green);
			Rectangle rect = new Rectangle(position.X, position.Y, width, 25);
			g.FillRectangle(b, rect);
			StringFormat format = new StringFormat();
			format.LineAlignment = StringAlignment.Center;
			format.Alignment = StringAlignment.Center;
			if (width > 40)
				g.DrawString(position.Y.ToString(), new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold), Brushes.White, rect, format);
			else
				g.DrawString(position.Y.ToString(), new Font(FontFamily.GenericSansSerif, 7.5F, FontStyle.Bold), Brushes.White, rect, format);
		}

		public void Move(Point newPosition)
		{
			position = newPosition;
		}
	}
}
