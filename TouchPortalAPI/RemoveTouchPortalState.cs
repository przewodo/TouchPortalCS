using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI
{
	public class RemoveTouchPortalState
	{
		public string type { get { return "removeState"; } }
		public string id { get; set; }
	}
}
