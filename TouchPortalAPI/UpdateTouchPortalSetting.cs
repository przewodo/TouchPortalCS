using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI
{
	public class UpdateTouchPortalSetting
	{
		public string type { get { return "settingUpdate"; } }
		public string name { get; set; }
		public string value { get; set; }
	}
}
