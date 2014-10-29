using DESERVE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Timers;

namespace DESERVE.Manager
{
	class ClientController : IWCFClient
	{
		#region Fields
		private DuplexChannelFactory<IWCFService> m_pipeFactory;
		private IWCFService m_pipeProxy;
		private IClientChannel m_pipeChannel;
		private EndpointAddress m_endpoint;
		private Boolean m_connected;
		private ServerInstance m_serverInstance;
		private Timer m_updateTimer;
		#endregion

		#region Properties
		public Boolean Connected { get { return m_connected; } }
		#endregion

		#region Methods
		public ClientController(String instanceName, ServerInstance instance)
		{
			m_endpoint = new EndpointAddress("net.pipe://localhost/DESERVE/" + instanceName);
			m_serverInstance = instance;
			m_updateTimer = new Timer(5000);
			m_updateTimer.Elapsed += Timer_Elapsed;
			m_updateTimer.Start();
		}

		void Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			if (Connect())
			{
				m_pipeProxy.RequestUpdate();
			}
			else
			{
				ServerUpdate(new ServerInfo(m_serverInstance.Name, false, 0, TimeSpan.Zero, DateTime.MinValue));
			}
		}

		public Boolean Connect()
		{
			m_pipeFactory = new DuplexChannelFactory<IWCFService>(this, new NetNamedPipeBinding(), m_endpoint);

			m_pipeProxy = m_pipeFactory.CreateChannel();
			m_pipeChannel = m_pipeProxy as IClientChannel;

			try
			{
				m_pipeChannel.Open();
				return true;
			}
			catch (EndpointNotFoundException ex)
			{
				//TODO: LogManager.Log("Server not running");
			}
			catch (CommunicationException ex)
			{
				//TODO: LogManager.Log("Communication failed!");
			}
			catch (Exception ex)
			{
				//TODO: LogManager.Log("Uncaught Exception!");
			}
			return false;
		}

		public void StopServer()
		{
			if (!Connected)
			{
				m_connected = Connect();
				if (!Connected)
				{
					return;
				}
			}
			m_pipeProxy.Stop();
		}

		public void SaveServer()
		{
			if (!Connected)
			{
				m_connected = Connect();
				if (!Connected)
				{
					return;
				}
			}
			m_pipeProxy.Save();
		}
	
		public void ServerUpdate(ServerInfo serverInfo)
		{
			m_serverInstance.Update(serverInfo);
		}
		#endregion


		public void ClosePipe()
		{
			m_pipeChannel.Close();
		}
	}
}
