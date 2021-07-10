using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TouchPortalAPI;
using TouchPortalAPI.Events;

namespace TouchPortalAPI_Test
{
	class Program
	{
		static void Main(string[] args)
		{
			TPClient client = new TPClient();

			client.RetryConnect = true;
			client.OnPairResponse += Client_OnPairResponse;
			client.OnDataReceived += Client_OnDataReceived;

			if (client.Connect())
			{
				client.Pair(new Pair() {
					id = "dztp0001"
				});
			}

			client.UpdateList(new UpdateTouchPortalList() {
				id = "dztp_daz_actions",
				value = new List<string>(new string[] {
					"Value 1",
					"Value 2",
					"Value 4",
					"Value 5",
					"Value 6",
					"Value 1"
				})
			});
		}

		private static void Client_OnDataReceived(object sender, DataReceivedEventArgs args)
		{
		}

		private static void Client_OnPairResponse(object sender, PairEventArgs args)
		{
		}
	}
}
