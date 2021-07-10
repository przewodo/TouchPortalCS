using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI
{
	public class Entry
	{
		public int sdk { get; set; }
		public int version { get; set; }
		public string name { get; set; }
		public string id { get; set; }
		public Configuration configuration { get; set; }
		public string plugin_start_cmd { get; set; }
		public List<Category> categories { get; set; }
		public List<Settings> settings { get; set; }
	}
}
