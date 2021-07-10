using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI
{
	public class Action
	{
		public string id { get; set; }
		public string name { get; set; }
		public string prefix { get; set; }
		public string type { get; set; }
		public string executionType { get; set; }
		public string description { get; set; }
		public List<ActionData> data { get; set; }
		public bool tryInline { get; set; }
		public string format { get; set; }
		public bool hasHoldFunctionality { get; set; }
	}
}