using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI
{
	public class Settings
	{
		public string name { get; set; }
		[JsonProperty(PropertyName = "default")]
		public string defaultValue { get; set; }
		public string type { get; set; }
		public int? maxLenght { get; set; }
		public bool? isPassword { get; set; }
		public double? minValue { get; set; }
		public double? maxValue { get; set; }
		public bool? readOnly { get; set; }
	}
}
