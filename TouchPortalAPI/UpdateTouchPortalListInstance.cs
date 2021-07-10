using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI
{
	public class UpdateTouchPortalListInstance
	{
		public string type { get { return "choiceUpdate"; } }
		public string id { get; set; }
		public string instanceId { get; set; }		
		public List<string> value { get; set; }
	}
}
