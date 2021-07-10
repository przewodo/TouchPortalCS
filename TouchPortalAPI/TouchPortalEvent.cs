using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI
{
	public class TouchPortalEvent
	{
		public string type { get; set; }
		public string pluginId { get; set; }
		public string actionId { get; set; }
		[JsonProperty(PropertyName = "event")]
		public string eventName { get; set; }
		public string pageName { get; set; }		
		public string listId { get; set; }
		public string instanceId { get; set; }		
		public string value { get; set; }
		public List<TouchPortalEventData> data { get; set; }
	}
}
