using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualPianoApp
{
	public partial class form_startMenu : Form
	{
		public string notesFolderLocation { get; set; }
		private string[] notesNames = new string[]
		{
			"C.wav", "CSharp.wav",
			"D.wav", "DSharp.wav",
			"E.wav",
			"F.wav", "FSharp.wav",
			"G.wav", "GSharp.wav",
			"A.wav", "ASharp.wav",
			"B.wav"
		};
		public form_startMenu()
		{
			InitializeComponent();
			if (checkIfNotesLocationIsSaved())
			{
				btn_startGame.Enabled = true;
				btn_freePlay.Enabled = true;
			}
		}

		private void btn_startGame_Click(object sender, EventArgs e)
		{
			this.Hide();
			var playGameForm = new form_PlayGame(notesFolderLocation);
			playGameForm.Closed += (s, args) => this.Close();
			playGameForm.Show();
		}

        private void btn_freePlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            var freePlayForm = new form_FreePlay(notesFolderLocation);
            freePlayForm.Closed += (s, args) => this.Close();
            freePlayForm.Show();
        }

		private void btn_locateNotes_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				notesFolderLocation = fbd.SelectedPath;
				if (checkIfAllNotesExists(fbd.SelectedPath)){
					DialogResult dresult = MessageBox.Show("Remember this notes folder for next time?", "Remember location path",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (dresult == DialogResult.Yes)
					{
						saveLocationToFile(fbd.SelectedPath);
					}

					MessageBox.Show("All notes loaded successfully!\nReady to play some music!");
					btn_freePlay.Enabled = true;
					btn_startGame.Enabled = true;
				}
				else
				{
					DialogResult dresult = MessageBox.Show("The selected directory doesn't contain all the needed notes!\n" +
						"Want to try a different folder location?", "Files not found!",
						MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
					if(dresult == DialogResult.Retry)
					{
						btn_locateNotes.PerformClick();
					}
				}
				
			}
		}

		private bool checkIfNotesLocationIsSaved()
		{
			StreamReader file = new StreamReader(@"Notes_Location.txt");
			string line = file.ReadLine();
			file.Close();

			if (line != null)
			{
				notesFolderLocation = line;
				return true;
			}
			return false;
		}

		private bool checkIfAllNotesExists(string path)
		{
			foreach(string noteName in notesNames)
			{
				if(!File.Exists(Path.Combine(path, noteName))){
					return false;
				}
			}
			return true;
		}

		private void saveLocationToFile(string path)
		{
			string[] lines = { path };
			File.WriteAllLines(@"Notes_Location.txt", lines);
		}
	}
}
