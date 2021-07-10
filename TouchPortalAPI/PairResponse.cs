using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI
{
	public class PairResponse
	{
		public string type { get; set; }
		public string sdkVersion { get; set; }
		public string tpVersionString { get; set; }
		public string tpVersionCode { get; set; }
		public string pluginVersion { get; set; }
		public string status { get; set; }
	}
}
