using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI
{
	public class UpdateTouchPortalList
	{
		public string type { get { return "choiceUpdate"; } }
		public string id { get; set; }
		public List<string> value { get; set; }
	}
}
