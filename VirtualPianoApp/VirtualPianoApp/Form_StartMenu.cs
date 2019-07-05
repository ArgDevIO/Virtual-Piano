using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualPianoApp
{
	public partial class form_startMenu : Form
	{
		public form_startMenu()
		{
			InitializeComponent();
		}

		private void btn_startGame_Click(object sender, EventArgs e)
		{
			this.Hide();
			var playGameForm = new form_PlayGame();
			playGameForm.Closed += (s, args) => this.Close();
			playGameForm.Show();
		}

        private void btn_freePlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            var freePlayForm = new form_FreePlay();
            freePlayForm.Closed += (s, args) => this.Close();
            freePlayForm.Show();
        }
    }
}
