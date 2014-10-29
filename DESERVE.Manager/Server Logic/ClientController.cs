using DESERVE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

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
		#endregion

		#region Properties
		public Boolean Connected { get { return m_connected; } }
		#endregion

		#region Methods
		public ClientController(String instanceName, ServerInstance instance)
		{
			m_endpoint = new EndpointAddress("net.pipe://localhost/DESERVE/" + instanceName);
		}

		public Boolean Connect()
		{
			m_pipeFactory = new DuplexChannelFactory<IWCFService>(this, new NetNamedPipeBinding(), m_endpoint);

			m_pipeProxy = m_pipeFactory.CreateChannel();
			m_pipeChannel = m_pipeProxy as IClientChannel;

			m_pipeChannel.Faulted += PipeProxyFaulted;

			try
			{
				m_pipeChannel.Open();
				m_pipeProxy.RequestUpdate();
			}
			catch (EndpointNotFoundException ex)
			{
				//TODO: LogManager.Log("Server not running");
				return false;
			}
			catch (CommunicationException ex)
			{
				//TODO: LogManager.Log("Communication failed!");
				return false;
			}


			return true;
		}

		void PipeProxyFaulted(object sender, EventArgs e)
		{
			IClientChannel proxy = sender as IClientChannel;
			if (proxy != null)
			{
				proxy.Faulted -= PipeProxyFaulted;
				proxy = null;
			}

			m_pipeFactory = null;
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
	
		public void ServerUpdate(IServerInstance serverInfo)
		{
			if (!Connected)
			{
				m_connected = Connect();
				if (!Connected)
				{
					return;
				}
			}
			m_serverInstance.Update(serverInfo);
		}
		#endregion
	}
}
