using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI
{
	public class Connector
	{
		public string id { get; set; }
		public string name { get; set; }
		public string format { get; set; }
		public List<ConnectorData> data { get; set; }
	}
}
