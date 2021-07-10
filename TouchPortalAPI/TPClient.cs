using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TouchPortalAPI.Events;

namespace TouchPortalAPI
{
	public class TPClient
	{
		public event EventHandler OnConnected;
		public event EventHandler OnDisconnected;
		public event PairEventHandler OnPairResponse;
		public event DataReceivedEventHandler OnDataReceived;

		public string address { get; set; }
		public int port { get; set; }
		public bool RetryConnect { get; set; }

		private TcpClient tcpClient { get; set; }
		private Thread mainThd { get; set; }

		private bool IsPaired { get; set; }
		private Pair pairData { get; set; }

		public TPClient()
		{
			this.address = "127.0.0.1";
			this.port = 12136;
			this.tcpClient = null;
			this.mainThd = new Thread(new ThreadStart(this.mainThreadLoop));
			this.IsPaired = false;

			this.OnPairResponse += TPClient_OnPairResponse;
		}

		private void TPClient_OnPairResponse(object sender, PairEventArgs args)
		{
			if (args.response != null && args.response.type == "info" && args.response.status == "paired")
			{
				this.IsPaired = true;
			}
			else
			{
				this.IsPaired = false;
			}
		}

		public bool Connect()
		{
			try
			{
				this.tcpClient = new TcpClient();
				this.tcpClient.Connect(this.address, this.port);

				if (this.tcpClient.Connected) this.OnConnected?.Invoke(this, new EventArgs());
			}
			catch
			{
				this.tcpClient.Dispose();
				this.tcpClient = null;
			}

			if (!this.mainThd.IsAlive) this.mainThd.Start();

			return this.tcpClient == null ? false : this.tcpClient.Connected;
		}

		public bool Connect(string address, int port)
		{
			this.address = address;
			this.port = port;

			return this.Connect();
		}

		public void Disconnect()
		{
			bool oVal = this.RetryConnect;
			this.RetryConnect = false;

			this.mainThd.Abort();
			this.tcpClient.Close();

			this.IsPaired = false;

			this.tcpClient = null;

			Thread.Sleep(200);

			this.RetryConnect = oVal;
		}

		public void Pair(Pair p)
		{
			this.pairData = p;

			this.SendData(p);
		}

		public void CreateState(CreateTouchPortalState state)
		{
			this.SendData(state);
		}

		public void RemoveState(RemoveTouchPortalState state)
		{
			this.SendData(state);
		}

		public void UpdateState(UpdateTouchPortalState state)
		{
			this.SendData(state);
		}

		public void UpdateAction(UpdateTouchPortalActionData actionData)
		{
			this.SendData(actionData);
		}

		public void UpdateList(UpdateTouchPortalList list)
		{
			this.SendData(list);
		}

		public void UpdateListInstance(UpdateTouchPortalListInstance listInstance)
		{
			this.SendData(listInstance);
		}

		public void UpdateSetting(UpdateTouchPortalSetting setting)
		{
			this.SendData(setting);
		}

		private void SendData(object o)
		{
			if (!this.tcpClient.Connected || o == null) return;

			string dataToSend = Utils.ToJson(o);

			System.Diagnostics.Debug.WriteLine(dataToSend, "Outcoming Data");

			StreamWriter writer = new StreamWriter(this.tcpClient.GetStream());

			writer.WriteLine(dataToSend);
			writer.Flush();
		}

		private void mainThreadLoop()
		{
			while (this.RetryConnect || this.IsPaired == false)
			{
				try
				{
					while (this.tcpClient.Connected)
					{
						StreamReader reader = new StreamReader(this.tcpClient.GetStream());

						string sData = reader.ReadLine();

						System.Diagnostics.Debug.WriteLine(sData, "Incoming Data");

						this.OnDataReceived?.Invoke(this, new DataReceivedEventArgs() { data = Utils.FromJson<TouchPortalEvent>(sData) });

						if (!this.IsPaired)
						{
							PairResponse resp = Utils.FromJson<PairResponse>(sData);

							this.OnPairResponse?.Invoke(this, new PairEventArgs() { response = resp });
						}
					}
				}
				catch
				{
					if (this.tcpClient == null || this.tcpClient.Connected == false)
					{
						this.OnDisconnected?.Invoke(this, new EventArgs());
					}
				}

				if (this.RetryConnect)
				{
					if (this.Connect() == true)
					{
						this.Pair(this.pairData);
					}
					Thread.Sleep(1000);
				}
			}
		}
	}
}
