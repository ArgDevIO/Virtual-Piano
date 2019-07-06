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

        public bool checkForCollision(string keyPressed)
        {
            foreach (NoteObj n in notes)
            {
                if (n.position.Y >= 376 && n.position.Y <= 420)
                {
                    if (n.noteName.Equals(keyPressed))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

		public bool checkForLastAndStop()
		{
			if (notes[notes.Count - 1].position.Y >= 440)
				return true;
			else
				return false;
		}
    }
}
