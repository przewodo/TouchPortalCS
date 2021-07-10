using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI
{
	public class ActionData
	{
		public string id { get; set; }
		public string type { get; set; }
		public string label { get; set; }
		[JsonProperty(PropertyName = "default")]
		public string defaultValue { get; set; }
		public List<string> valueChoices { get; set; }
		public List<string> extensions { get; set; }
		public bool allowDecimals { get; set; }
		public double? minValue { get; set; }
		public double? maxValue { get; set; }
	}
}
