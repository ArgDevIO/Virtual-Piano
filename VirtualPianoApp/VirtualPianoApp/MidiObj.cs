using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;

namespace VirtualPianoApp
{
	class MidiObj
	{
		public MidiFile file { get; set; }
		public IEnumerable<Note> notes { get; set; }
		public TempoMap tempoMap { get; set; }
		public ITimeSpan duration { get; set; }

		public MidiObj(String file)
		{
			this.file = MidiFile.Read(file);
			notes = this.file.GetNotes();
			tempoMap = this.file.GetTempoMap();
			duration = this.file.GetDuration(TimeSpanType.Metric);
		}

		public string getDurationAsString()
		{
			return duration.ToString().Substring(2);
		}
	}
}
