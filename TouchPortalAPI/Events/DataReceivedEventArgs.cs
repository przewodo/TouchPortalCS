using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI.Events
{
	public class DataReceivedEventArgs : EventArgs
	{
		public TouchPortalEvent data { get; set; }
	}
}
