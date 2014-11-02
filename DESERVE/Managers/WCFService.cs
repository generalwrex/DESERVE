using DESERVE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Timers;

namespace DESERVE.Managers
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	[CallbackBehavior(UseSynchronizationContext = false)]
	class WCFService : IWCFService
	{
		private static int _MS_PER_UPDATE_ = 500;
		private String m_uriString { get { return "net.pipe://localhost/DESERVE/" + ServerInstance.Instance.Name; } }
		private List<IWCFClient> m_callbacks;
		private static readonly object _lockObj = new object();
		private ServiceHost m_serviceHost;
		private Timer m_updateTimer;

		internal WCFService()
		{
			m_callbacks = new List<IWCFClient>();
			m_serviceHost = new ServiceHost(this, new Uri(m_uriString));
			NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.Transport);

			m_serviceHost.AddServiceEndpoint(typeof(IWCFService),
				 binding,
				 m_uriString);

			try
			{
				m_serviceHost.Open();
				LogManager.MainLog.WriteLineAndConsole(String.Format("DESERVE: Opened WCF Pipe at {0}", m_uriString));
			}
			catch (Exception ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(String.Format("DESERVE: Failed to open WCF Pipe. Exception: {0}", ex.ToString()));
				return;
			}

			ServerInstance.Instance.OnChatMessage += OnChatMessage;
			ServerInstance.Instance.PlayerUpdated += OnPlayerUpdate;

			m_updateTimer = new Timer(_MS_PER_UPDATE_);
			m_updateTimer.Elapsed += OnUpdateTimer;
			m_updateTimer.AutoReset = false;
			m_updateTimer.Start();
		}

		private void OnPlayerUpdate(Player player, PlayerAction action)
		{
			List<IWCFClient> callbacks;
			lock (_lockObj)
			{
				callbacks = new List<IWCFClient>(m_callbacks);
			}
			foreach (IWCFClient callback in callbacks)
			{
				callback.PlayerUpdate(player, action);
			}
		}

		private void OnChatMessage(ChatMessage message)
		{
			List<IWCFClient> callbacks;
			lock (_lockObj)
			{
				callbacks = new List<IWCFClient>(m_callbacks);
			}
			foreach (IWCFClient callback in callbacks)
			{
				callback.ChatMessageUpdate(message);
			}
		}

		private void OnUpdateTimer(object sender, ElapsedEventArgs e)
		{
			List<IWCFClient> callbacks;
			lock (_lockObj)
			{
				callbacks = new List<IWCFClient>(m_callbacks);
			}
			foreach (IWCFClient callback in callbacks)
			{
				try
				{
					callback.UpdateServerInfo(ServerInstance.Instance.GetInfoPartial());
				}
				catch (ObjectDisposedException)
				{
					lock (_lockObj)
					{
						m_callbacks.Remove(callback);
					}
				}
				catch (Exception ex)
				{
					LogManager.ErrorLog.WriteLineAndConsole(String.Format("DESERVE: Unhandled WCF Exception: {0}", ex.ToString()));
				}

			}
			m_updateTimer.Start();
		}

		private void OnClientFaulted(object sender, EventArgs e)
		{
			IClientChannel channel = sender as IClientChannel;

			channel.Faulted -= OnClientFaulted;
			lock (_lockObj)
			{
				m_callbacks.Remove((IWCFClient)sender);
			}
		}

		public ServerInfo Connect()
		{
			IWCFClient callback = OperationContext.Current.
			   GetCallbackChannel<IWCFClient>();

			((IClientChannel)callback).Faulted += OnClientFaulted;

			lock (_lockObj)
			{
				m_callbacks.Add(callback);
			}

			return ServerInstance.Instance.GetInfo();
		}

		public void Disconnect()
		{
			IWCFClient callback = OperationContext.Current.
			   GetCallbackChannel<IWCFClient>();

			lock (_lockObj)
			{
				m_callbacks.Remove(callback);
			}
			((IClientChannel)callback).Close();
		}

		public void Stop()
		{
			ServerInstance.Instance.Stop();
		}

		public void Save()
		{
			ServerInstance.Instance.Save();
		}

		public void SendChatMessage(ChatMessage message)
		{
			ServerInstance.Instance.SendChatMessage(message);
		}
	}
}
