using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualPianoApp
{
    public partial class form_FreePlay : Form
    {
        #region External winmm player library
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);
        #endregion

        #region Variables & List initializations
        string noteName;
        string openNoteCommand;
        string playNoteCommand;
   
        private List<string> keyDowns = new List<string>();
        private List<NoteObj> listOfNotes = new List<NoteObj>();

        bool playingNote = false;
        int noteCounter = 1;

		private string notesFolderLocation;
        #endregion

        public form_FreePlay(string notesFolder)
        {
            InitializeComponent();
			this.Icon = VirtualPianoApp.Properties.Resources.VirtualPianoIcon;
			this.notesFolderLocation = notesFolder;
        }

		#region Events/Actions
		private void Form_FreePlay_KeyDown(object sender, KeyEventArgs e)
        {
            string key = getNote((char)e.KeyValue);
            if (key != null)
            {
                if (keyDowns.Contains(key))
                    return;

                keyDowns.Add(key);

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

		private void form_FreePlay_KeyUp(object sender, KeyEventArgs e)
		{
			string key = getNote((char)e.KeyValue);
			if (key != null)
			{
				keyDowns.Remove(key);
				resetButtonColor(key);
			}
		}

		private void btn_backToStartMenu_Click(object sender, EventArgs e)
		{
			this.Hide();
			var startMenu = new form_startMenu();
			startMenu.Closed += (s, args) => this.Close();
			startMenu.Show();
		}
		#endregion

		#region Helper methods
		private string getOpenNoteCommand(string note)
        {
			Console.WriteLine(string.Format("open {0}\\{1}.wav type waveaudio alias {1}", notesFolderLocation, note));
            return string.Format("open {0}\\{1}.wav type waveaudio alias {1}", notesFolderLocation, note);
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
		#endregion
	}
}
