using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI
{
	public class State
	{
		public string id { get; set; }
		public string type { get; set; }
		public string desc { get; set; }
		[JsonProperty(PropertyName = "default")]
		public string defaultValue { get; set; }
		public List<string> valueChoices { get; set; }
	}
}
