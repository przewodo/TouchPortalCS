using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI
{
	public class UpdateTouchPortalActionData
	{
		public string type { get { return "updateActionData"; } }
		public string instanceId { get; set; }
		public ActionData data { get; set; }
	}
}
