using DESERVE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Timers;
using System.Collections.ObjectModel;

namespace DESERVE.Manager
{
	class ClientController : IWCFClient
	{
		#region Fields
		private static Int32 _MS_PER_UPDATE_ = 1000;

		private DuplexChannelFactory<IWCFService> m_pipeFactory;
		private IWCFService m_pipeProxy;
		private IClientChannel m_pipeChannel;
		private EndpointAddress m_endpoint;
		private Boolean m_connected;
		private ServerInstance m_serverInstance;
		private Timer m_updateTimer;
		private DateTime m_lastUpdate;
		private readonly object _lockObj = new object();
		#endregion

		#region Properties
		public Boolean Connected { get { return m_connected; } }
		#endregion

		#region Methods
		public ClientController(String instanceName, ServerInstance instance)
		{
			m_lastUpdate = DateTime.MinValue;
			m_endpoint = new EndpointAddress("net.pipe://localhost/DESERVE/" + instanceName);
			m_serverInstance = instance;
			m_updateTimer = new Timer(_MS_PER_UPDATE_);
			m_updateTimer.Elapsed += OnUpdateTimer;
			m_updateTimer.AutoReset = false;
			m_updateTimer.Start();
		}

		private void OnUpdateTimer(object sender, ElapsedEventArgs e)
		{
			if (DateTime.Now - m_lastUpdate >= TimeSpan.FromMilliseconds(_MS_PER_UPDATE_))
			{
				if (Connect())
				{
					m_pipeProxy.RegisterForUpdates();
				}
				else
				{
					ServerStateUpdate(new ServerInfo(m_serverInstance.Name, false, new List<Player>(), TimeSpan.Zero, DateTime.MinValue, new List<ChatMessage>()));
				}
			}

			m_updateTimer.Start();
		}

		private void OnChannelFaulted(object sender, EventArgs e)
		{
			m_pipeChannel.Faulted -= OnChannelFaulted;
			m_connected = false;
		}

		internal void StopServer()
		{
			if (!Connected)
			{
				if (!Connect())
				{
					return;
				}
			}
			m_pipeProxy.Stop();
		}

		internal void SaveServer()
		{
			if (!Connected)
			{
				if (!Connect())
				{
					return;
				}
			}
			m_pipeProxy.Save();
		}

		internal void SendChatMessage(ChatMessage chatMessage)
		{
			if (!Connected)
			{
				if (!Connect())
				{
					return;
				}
			}
			m_pipeProxy.SendChatMessage(chatMessage);
		}

		private Boolean Connect()
		{
			lock (_lockObj)
			{
				m_pipeFactory = new DuplexChannelFactory<IWCFService>(this, new NetNamedPipeBinding(), m_endpoint);

				m_pipeProxy = m_pipeFactory.CreateChannel();
				m_pipeChannel = m_pipeProxy as IClientChannel;
				m_pipeChannel.Faulted += OnChannelFaulted;

				m_connected = false;

				try
				{
					m_pipeChannel.Open();
					m_connected = true;
				}
				catch (EndpointNotFoundException)
				{
					// Do nothing. Server isn't running.
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
			return m_connected;
		}

		#region Remote Callbacks
		public void ChatMessageUpdate(ChatMessage message)
		{
			m_serverInstance.ChatMessages.Add(message);
		}

		public void PlayerUpdate(Player player, PlayerAction action)
		{
			if (action == PlayerAction.Joined)
			{
				m_serverInstance.CurrentPlayers.Add(player);
			}
			else
			{
				//TODO: Test to make sure this works.
				m_serverInstance.CurrentPlayers.Remove(player);
			}
		}

		public void ServerStateUpdate(ServerInfo serverInfo)
		{
			m_serverInstance.Update(serverInfo);
			m_lastUpdate = DateTime.Now;
		}

		public void ServerStateUpdatePartial(ServerInfoPartial serverInfo)
		{
			m_serverInstance.Update(serverInfo);
			m_lastUpdate = DateTime.Now;
		}
		#endregion
		#endregion
	}
}
