namespace VirtualPianoApp
{
	partial class form_startMenu
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btn_startGame = new System.Windows.Forms.Button();
			this.btn_freePlay = new System.Windows.Forms.Button();
			this.btn_locateNotes = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_startGame
			// 
			this.btn_startGame.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.btn_startGame.CausesValidation = false;
			this.btn_startGame.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btn_startGame.Enabled = false;
			this.btn_startGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_startGame.Location = new System.Drawing.Point(600, 62);
			this.btn_startGame.Name = "btn_startGame";
			this.btn_startGame.Size = new System.Drawing.Size(200, 120);
			this.btn_startGame.TabIndex = 0;
			this.btn_startGame.TabStop = false;
			this.btn_startGame.Text = "PLAY GAME";
			this.btn_startGame.UseVisualStyleBackColor = false;
			this.btn_startGame.Click += new System.EventHandler(this.btn_startGame_Click);
			// 
			// btn_freePlay
			// 
			this.btn_freePlay.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.btn_freePlay.CausesValidation = false;
			this.btn_freePlay.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btn_freePlay.Enabled = false;
			this.btn_freePlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_freePlay.Location = new System.Drawing.Point(600, 260);
			this.btn_freePlay.Name = "btn_freePlay";
			this.btn_freePlay.Size = new System.Drawing.Size(200, 120);
			this.btn_freePlay.TabIndex = 1;
			this.btn_freePlay.TabStop = false;
			this.btn_freePlay.Text = "FREE PLAY";
			this.btn_freePlay.UseVisualStyleBackColor = false;
			this.btn_freePlay.Click += new System.EventHandler(this.btn_freePlay_Click);
			// 
			// btn_locateNotes
			// 
			this.btn_locateNotes.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.btn_locateNotes.CausesValidation = false;
			this.btn_locateNotes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btn_locateNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_locateNotes.Location = new System.Drawing.Point(28, 260);
			this.btn_locateNotes.Name = "btn_locateNotes";
			this.btn_locateNotes.Size = new System.Drawing.Size(200, 120);
			this.btn_locateNotes.TabIndex = 2;
			this.btn_locateNotes.TabStop = false;
			this.btn_locateNotes.Text = "LOCATE NOTES FOLDER";
			this.btn_locateNotes.UseVisualStyleBackColor = false;
			this.btn_locateNotes.Click += new System.EventHandler(this.btn_locateNotes_Click);
			// 
			// form_startMenu
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackgroundImage = global::VirtualPianoApp.Properties.Resources.piano_background;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(836, 461);
			this.Controls.Add(this.btn_locateNotes);
			this.Controls.Add(this.btn_freePlay);
			this.Controls.Add(this.btn_startGame);
			this.MaximumSize = new System.Drawing.Size(864, 540);
			this.MinimumSize = new System.Drawing.Size(854, 507);
			this.Name = "form_startMenu";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "VIRTUAL PIANO";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn_startGame;
		private System.Windows.Forms.Button btn_freePlay;
		private System.Windows.Forms.Button btn_locateNotes;
	}
}

