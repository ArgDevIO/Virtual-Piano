﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;

namespace VirtualPianoApp
{
	public partial class form_PlayGame : Form
	{
		#region External winmm player library
		[DllImport("winmm.dll")]
		static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);
		#endregion

		#region Variables & Lists initialization
		string noteName;
		string openNoteCommand;
		string playNoteCommand;

        int hits = 0;
        int misses = 0;

		public short _minutes, _seconds;
		public long _miliseconds;

		private NoteDoc noteDoc = new NoteDoc();
		private List<string> keyDowns = new List<string>();
		private List<NoteObj> listOfNotes = new List<NoteObj>();

		public bool buffer = false;

		bool playingNote = false;
		int noteCounter = 1;

		private MidiObj midiObj = null;
		#endregion

		public form_PlayGame()
		{
			InitializeComponent();
			timerPiano.Stop();

			typeof(Panel).InvokeMember("DoubleBuffered",
			BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
			null, notesWindow, new object[] { true });

			Console.WriteLine("open " + Application.StartupPath + "\\NOTES\\{0}.wav type waveaudio alias {0}");
		}

		#region Event handlers
		private void form_PlayGame_KeyUp(object sender, KeyEventArgs e)
		{
			string key = getNote((char)e.KeyValue);
			if (key != null)
			{
				keyDowns.Remove(key);
				resetButtonColor(key);
			}
		}

		private void form_PlayGame_KeyDown(object sender, KeyEventArgs e)
		{
			string key = getNote((char)e.KeyValue);
			if (key != null)
			{
				if (keyDowns.Contains(key))
					return;

				keyDowns.Add(key);

				checkForCollision(key);

				if (playingNote)
				{
					mciSendString(getOpenNoteCommand(key) + Convert.ToString(noteCounter), null, 0, IntPtr.Zero);
					mciSendString(getPlayNoteCommand(key) + Convert.ToString(noteCounter), null, 0, IntPtr.Zero);
					playingNote = false;
					noteCounter++;
				}
				else
				{
					mciSendString(getOpenNoteCommand(key) + Convert.ToString(noteCounter), null, 0, IntPtr.Zero);
					mciSendString(getPlayNoteCommand(key) + Convert.ToString(noteCounter), null, 0, IntPtr.Zero);
					playingNote = true;
					noteCounter++;
				}
				changeButtonPressedColor(key);
			}
		}

		private void btn_openMidi_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "MIDI|*.mid";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				midiObj = new MidiObj(ofd.FileName);
				btn_openMidi.Hide();
				btn_start.Show();

				IEnumerable<Note> notes = midiObj.notes;
				TempoMap tempoMap = midiObj.tempoMap;

				foreach (Note n in notes)
				{
					MetricTimeSpan metricTime = n.TimeAs<MetricTimeSpan>(tempoMap);

					NoteObj tmpNote =
						new NoteObj(
						new Point(
							getNotePosition(n).X, 0), new MyTime(
								metricTime.Minutes, metricTime.Seconds, metricTime.Milliseconds),
							n.NoteName.ToString(),
							getNoteWidth(n));
					listOfNotes.Add(tmpNote);
				}
			}

		}

		private void btn_start_Click(object sender, EventArgs e)
		{
			timerPiano.Start();
			btn_start.Hide();
		}
		#endregion

		private void checkForCollision(string key)
		{
            bool isCollision = noteDoc.checkForCollision(key);
            if (isCollision)
                hits++;
            else
                misses++;

		}

		#region Helper methods
		private string getOpenNoteCommand(string note)
		{
			return string.Format("open C:\\VIRTUAL-PIANO\\NOTES\\{0}.wav type waveaudio alias {0}", note);
		}

		private string getPlayNoteCommand(string note)
		{
			return string.Format("play {0}", note);
		}

		private string getNote(char keyPressed)
		{
			switch (keyPressed)
			{
				case 'Q': return "C";
				case '2': return "CSharp";
				case 'W': return "D";
				case '3': return "DSharp";
				case 'E': return "E";
				case 'R': return "F";
				case '5': return "FSharp";
				case 'T': return "G";
				case '6': return "GSharp";
				case 'Y': return "A";
				case '7': return "ASharp";
				case 'U': return "B";
				case 'I': return "C1";
				default: return null;
			}
		}

		private void resetButtonColor(string note)
		{
			if (!note.Contains("Sharp"))
			{
				switch (note)
				{
					case "C":
						btn_C.BackColor = Color.White;
						break;
					case "D":
						btn_D.BackColor = Color.White;
						break;
					case "E":
						btn_E.BackColor = Color.White;
						break;
					case "F":
						btn_F.BackColor = Color.White;
						break;
					case "G":
						btn_G.BackColor = Color.White;
						break;
					case "A":
						btn_A.BackColor = Color.White;
						break;
					case "B":
						btn_B.BackColor = Color.White;
						break;
					case "C1":
						btn_C1.BackColor = Color.White;
						break;
				}
			}
			else
			{
				switch (note)
				{
					case "CSharp":
						btn_CSharp.BackColor = Color.Black;
						break;
					case "DSharp":
						btn_DSharp.BackColor = Color.Black;
						break;
					case "FSharp":
						btn_FSharp.BackColor = Color.Black;
						break;
					case "GSharp":
						btn_GSharp.BackColor = Color.Black;
						break;
					case "ASharp":
						btn_ASharp.BackColor = Color.Black;
						break;
				}
			}
		}

		private void changeButtonPressedColor(string note)
		{
			switch (note)
			{
				case "C":
					btn_C.BackColor = Color.Gray;
					break;
				case "CSharp":
					btn_CSharp.BackColor = Color.Gray;
					break;
				case "D":
					btn_D.BackColor = Color.Gray;
					break;
				case "DSharp":
					btn_DSharp.BackColor = Color.Gray;
					break;
				case "E":
					btn_E.BackColor = Color.Gray;
					break;
				case "F":
					btn_F.BackColor = Color.Gray;
					break;
				case "FSharp":
					btn_FSharp.BackColor = Color.Gray;
					break;
				case "G":
					btn_G.BackColor = Color.Gray;
					break;
				case "GSharp":
					btn_GSharp.BackColor = Color.Gray;
					break;
				case "A":
					btn_A.BackColor = Color.Gray;
					break;
				case "ASharp":
					btn_ASharp.BackColor = Color.Gray;
					break;
				case "B":
					btn_B.BackColor = Color.Gray;
					break;
				case "C1":
					btn_C1.BackColor = Color.Gray;
					break;
			}
		}

		private int getNoteWidth(Note n)
		{
			string note = n.NoteName.ToString();

			if (!note.Contains("Sharp"))
			{
				return 77;
			}
			else
			{
				return 40;
			}
		}

		private Point getNotePosition(Note n)
		{
			switch (Convert.ToString(n.NoteName))
			{
				case "C":
					return btn_C.Location;
				case "CSharp":
					return btn_CSharp.Location;
				case "D":
					return btn_D.Location;
				case "DSharp":
					return btn_DSharp.Location;
				case "E":
					return btn_E.Location;
				case "F":
					return btn_F.Location;
				case "FSharp":
					return btn_FSharp.Location;
				case "G":
					return btn_G.Location;
				case "GSharp":
					return btn_GSharp.Location;
				case "A":
					return btn_A.Location;
				case "ASharp":
					return btn_ASharp.Location;
				case "B":
					return btn_B.Location;

				default: return new Point(0, 0);
			}
		}
		private void ShowTime()
		{
			lbl_time.Text = _minutes.ToString("00") + ":" + _seconds.ToString("00") + ":" + _miliseconds.ToString("0000");
		}

		private bool compareTime(NoteObj n)
		{
			if (n.time._minutes == _minutes)
			{
				if (n.time._seconds == _seconds)
				{
					if (Math.Abs(n.time._miliseconds - _miliseconds) <= 27)
					{
						return true;
					}
					else return false;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		private void IncreaseMiliseconds()
		{
			if (_miliseconds == 999)
			{
				_miliseconds = 0;
				IncreaseSeconds();
			}
			else
			{
				_miliseconds += 27;
			}
		}

		private void IncreaseSeconds()
		{
			if (_seconds == 59)
			{
				_seconds = 0;
				IncreaseMinutes();
			}
			else
			{
				_seconds++;
			}
		}

		private void IncreaseMinutes()
		{
			_minutes++;
		}
		#endregion
		private void timerPiano_Tick(object sender, EventArgs e)
		{
			noteDoc.Move();
			IncreaseMiliseconds();
			ShowTime();
			DrawNote();

			Invalidate(true);
		}

		private void DrawNote()
		{
			if (listOfNotes.Count != 0)
			{
				NoteObj n = listOfNotes.First();
				if (compareTime(n))
				{
					noteDoc.AddNote(n);
					listOfNotes.RemoveAt(0);
				}
			}
		}

		private void notesWindow_Paint(object sender, PaintEventArgs e)
		{
			noteDoc.Draw(e.Graphics);
		}
	}
}
