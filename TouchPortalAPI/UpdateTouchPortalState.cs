using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI
{
	public class UpdateTouchPortalState
	{
		public string type { get { return "stateUpdate"; } }
		public string id { get; set; }
		public string value { get; set; }
	}
}
