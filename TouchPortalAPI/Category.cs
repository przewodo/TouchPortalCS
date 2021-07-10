using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchPortalAPI
{
	public class Category
	{
		public string id { get; set; }
		public string name { get; set; }
		public string imagepath { get; set; }
		public List<Action> actions { get; set; }
		public List<Event> events { get; set; }
		public List<Connector> connectors { get; set; }
		public List<State> states { get; set; }
	}
}
