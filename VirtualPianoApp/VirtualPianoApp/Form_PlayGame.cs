using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualPianoApp
{
	public partial class form_PlayGame : Form
	{
		[DllImport("winmm.dll")]
		static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

		bool playingNote = false;
		List<string> keyDowns = new List<string>();

		string noteName;
		string openNoteCommand;
		string playNoteCommand;
		int noteCounter = 1;

		public form_PlayGame()
		{
			InitializeComponent();
			Console.WriteLine("open " + Application.StartupPath + "\\NOTES\\{0}.wav type waveaudio alias {0}");
		}

		


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
				case 'I': return "CC";
				default: return null;
			}
		}

		private void form_PlayGame_KeyUp(object sender, KeyEventArgs e)
		{
			string key = getNote((char)e.KeyValue);
			if (key != null)
			{
				keyDowns.Remove(key);
				//resetButtonColor(key);
			}
		}

		private void form_PlayGame_KeyDown(object sender, KeyEventArgs e)
		{
			string key = getNote((char)e.KeyValue);
			Console.WriteLine(key + "key");
			if (key != null)
			{
				//if (keyDowns.Contains(key))
				//	return;

				//keyDowns.Add(key);

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
				//changeButtonPressedColor(key);
			}
		}
	}
}
