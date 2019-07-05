using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPianoApp
{
	class NoteDoc
	{
		private static int velocity = 4;
		public List<NoteObj> notes { get; set; }
		public NoteDoc()
		{
			notes = new List<NoteObj>();
		}

		public void AddNote(NoteObj n)
		{
			notes.Add(n);
		}

		public void Draw(Graphics g)
		{
			foreach (NoteObj n in notes)
				n.Draw(g);
		}

		public void Move()
		{
			foreach (NoteObj n in notes)
				n.Move(new Point(n.position.X, n.position.Y + velocity));
		}

		public NoteObj getNote()
		{
			return notes.First();
		}
	}
}
