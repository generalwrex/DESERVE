using DESERVE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Timers;

namespace DESERVE.Manager
{
	class WCFClient : IWCFClient
	{
		private static int _MS_PER_UPDATE_ = 5000;
		private String m_uriString { get { return "net.pipe://localhost/DESERVE/" + m_serverInstance.Name; } }
		private ServerInstance m_serverInstance;
		private DuplexChannelFactory<IWCFService> m_pipeFactory;
		private IWCFService m_pipeProxy;
		private IClientChannel m_pipeChannel;
		private static readonly object _lockObj = new object();
		private Timer m_updateTimer;
		private DateTime m_lastUpdate;
		private Boolean m_connected;

		internal WCFClient(ServerInstance serverInstance)
		{
			m_lastUpdate = DateTime.MinValue;
			m_serverInstance = serverInstance;

			NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.Transport);
			m_pipeFactory = new DuplexChannelFactory<IWCFService>(this, binding, m_uriString);

			m_updateTimer = new Timer(_MS_PER_UPDATE_);
			m_updateTimer.Elapsed += OnUpdateTimer;
			m_updateTimer.AutoReset = false;
			m_updateTimer.Start();
		}

		private void OnUpdateTimer(object sender, ElapsedEventArgs e)
		{
			if (DateTime.Now - m_lastUpdate > TimeSpan.FromMilliseconds(_MS_PER_UPDATE_))
			{
				if (m_pipeChannel != null && m_pipeChannel.State == CommunicationState.Opened)
				{
					try
					{
						m_pipeChannel.Close();
					}
					catch {}
				}
				Connect();
			}
			m_updateTimer.Start();
		}

		private void Connect()
		{
			m_pipeProxy = m_pipeFactory.CreateChannel();

			m_pipeChannel = m_pipeProxy as IClientChannel;
			m_pipeChannel.Faulted += OnChannelFaulted;

			try
			{
				m_pipeChannel.Open();
				m_serverInstance.Update(m_pipeProxy.Connect());
				m_connected = true;
			}
			catch (EndpointNotFoundException)
			{
				m_serverInstance.Update(new ServerInfo(m_serverInstance.Name, false, new List<Player>(), TimeSpan.Zero, DateTime.MinValue, new List<ChatMessage>())); 
			}
			catch (CommunicationException ex)
			{
				Manager.ErrorLog.WriteLine(String.Format("Manager Communication Error: {0}", ex.ToString()));
			}
			catch (Exception ex)
			{
				Manager.ErrorLog.WriteLine(String.Format("Manager Unhandled Exception while connecting to instance {0}. Exception: {1}", m_serverInstance.Name, ex.ToString()));
			}
		}

		private void OnChannelFaulted(object sender, EventArgs e)
		{
			m_connected = false;
			m_pipeChannel.Faulted -= OnChannelFaulted;
		}

		public void UpdateServerInfo(ServerInfoPartial serverInfo)
		{
			m_lastUpdate = DateTime.Now;
			m_serverInstance.Update(serverInfo);
		}

		public void ChatMessageUpdate(ChatMessage message)
		{
			m_serverInstance.ChatUpdate(message);
		}

		public void PlayerUpdate(Player player, PlayerAction action)
		{
			m_serverInstance.PlayerUpdate(player, action);
		}

		internal void SendChatMessage(ChatMessage message)
		{
			if (!m_connected)
			{
				Manager.ErrorLog.WriteLineAndConsole(String.Format("Tried to send ChatMessage to disconnected server: {0}", m_serverInstance.Name));
				return;
			}
			m_pipeProxy.SendChatMessage(message);
		}

		internal void StopServer()
		{
			if (!m_connected)
			{
				Manager.ErrorLog.WriteLineAndConsole(String.Format("Tried to send Stop Command to disconnected server: {0}", m_serverInstance.Name));
				return;
			}
			m_pipeProxy.Stop();
		}

		internal void SaveServer()
		{
			if (!m_connected)
			{
				Manager.ErrorLog.WriteLineAndConsole(String.Format("Tried to send Save Command to disconnected server: {0}", m_serverInstance.Name));
				return;
			}
			m_pipeProxy.Save();
		}
	}
}
