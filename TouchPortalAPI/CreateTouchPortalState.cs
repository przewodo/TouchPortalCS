using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI
{
	public class CreateTouchPortalState
	{
		public string type { get { return "createState"; } }
		public string id { get; set; }
		public string desc { get; set; }
		public string defaultValue { get; set; }
	}
}
