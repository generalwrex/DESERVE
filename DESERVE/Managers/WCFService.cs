using DESERVE.Common;
using System;
using System.ServiceModel;
using System.Threading;

namespace DESERVE.Managers
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	class WCFService : IWCFService
	{
		public String Uri { get { return "net.pipe://localhost/DESERVE/" + m_instanceName; } }
		private string m_instanceName;

		public WCFService(String instanceName)
		{
			m_instanceName = instanceName;
		}

		public void Stop()
		{
			ThreadPool.QueueUserWorkItem((object state) => ServerInstance.Instance.Stop());
		}

		public void Save()
		{
			ThreadPool.QueueUserWorkItem((object state) => ServerInstance.Instance.Save());
		}

		public void RequestUpdate()
		{
			IWCFClient callback = OperationContext.Current.GetCallbackChannel<IWCFClient>();
			ServerInfo info = new ServerInfo();

			if (ServerInstance.Instance.IsRunning)
			{
				info.CurrentPlayers = ServerInstance.Instance.CurrentPlayers;
				info.IsRunning = ServerInstance.Instance.IsRunning;
				info.LastSave = ServerInstance.Instance.LastSave;
				info.Name = ServerInstance.Instance.Name;
				info.Uptime = ServerInstance.Instance.Uptime;
				info.ChatMessages = ServerInstance.Instance.ChatMessages;
			}
			else
			{
				info.CurrentPlayers = new System.Collections.ObjectModel.ObservableCollection<Player>();
				info.IsRunning = false;
				info.LastSave = DateTime.MinValue;
				info.Name = ServerInstance.Instance.Name;
				info.Uptime = TimeSpan.Zero;
				info.ChatMessages = new System.Collections.ObjectModel.ObservableCollection<ChatMessage>();
			}
			ThreadPool.QueueUserWorkItem((object state) =>
			{
				if (callback != null)
				{
					callback.ServerUpdate(info);
				}
			});
		}

		public void SendChatMessage(ChatMessage message)
		{
			ServerInstance.Instance.SendChatMessage(message);
		}
	}
}
