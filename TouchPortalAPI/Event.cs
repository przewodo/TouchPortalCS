using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI
{
	public class Event
	{
		public string id { get; set; }
		public string name { get; set; }
		public string format { get; set; }
		public string type { get; set; }
		public List<string> valueChoices { get; set; }
		public string valueType { get; set; }
		public string valueStateId { get; set; }
	}
}
