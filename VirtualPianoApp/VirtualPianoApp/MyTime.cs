using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPianoApp
{
	class MyTime
	{
		public int _minutes { get; set; }
		public int _seconds { get; set; }
		public long _miliseconds { get; set; }

		public MyTime(int min, int sec, long milsec)
		{
			_minutes = min;
			_seconds = sec;
			_miliseconds = milsec;
		}
	}
}
