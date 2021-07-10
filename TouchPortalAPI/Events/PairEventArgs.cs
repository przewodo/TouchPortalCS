using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI.Events
{
	public class PairEventArgs : EventArgs
	{
		public PairResponse response { get; set; }
	}
}
