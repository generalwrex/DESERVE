
using System;
using System.ServiceModel;
using System.Windows.Forms;
using System.Collections.Generic;

using DESERVE.Managers;

using DESERVE.Manager.Marshall;

namespace DESERVE.Manager
{
	#region Event Handler Class
	public class DESERVEEventHandler : IServerMarshallCallback	
	{
		public delegate void ServerEvent();
		public event ServerEvent ServerStarted;
		public event ServerEvent ServerStopped;

		public delegate void ChatEvent(ulong remoteUserId, string message);
		public event ChatEvent ReceivedChatMessage;

		public delegate void WorldEvent(bool isSaving);
		public event WorldEvent SavingChanged;


		public void OnServerStopped() { if (ServerStopped != null) { ServerStopped(); } }
		public void OnServerStarted() { if (ServerStarted != null) { ServerStarted(); } }

		public void OnChatMessage(ulong remoteUserId, string message) { if (ReceivedChatMessage != null) { ReceivedChatMessage(remoteUserId, message); } }

		public void IsSavingChanged(bool isSaving) { if (SavingChanged != null) { SavingChanged(isSaving); } }
	}
	#endregion

	#region ServerInstance Class
	public class ServerInstance
	{
		#region Properties
		public IServerMarshall ServerMarshall { get; set; }
		public DESERVEEventHandler ServerEvents { get; set; }
		#endregion

		#region Constructor
		public ServerInstance(IServerMarshall marshall, DESERVEEventHandler eventHandler)
		{
			ServerMarshall = marshall;
			ServerEvents = eventHandler;
		}
		#endregion
	}
	#endregion

	#region Services Class
	internal class Services
	{
		#region "Fields"
		private static Services m_instance;
		private static IServerMarshall m_marshallServer;
		#endregion

		#region Constructor
		public Services()
		{
			m_instance = this;
		}
		#endregion

		#region "Properties"
		public static Services Instance
		{
			get
			{
				if (m_instance == null)
					m_instance = new Services();

				return m_instance;
			}
		}
		#endregion

		#region "Methods"
		public ServerInstance ConnectToPipe(string instanceName)
		{
			var eventHandler = new DESERVEEventHandler();
			var serverInstanceContext = new InstanceContext(eventHandler);
			var serverBinding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
			var serverEndpoint = new EndpointAddress("net.pipe://localhost/DESERVE/" + instanceName);
			var serverChannel = new DuplexChannelFactory<IServerMarshall>(serverInstanceContext, serverBinding, serverEndpoint);

			
			try
			{   
				m_marshallServer = serverChannel.CreateChannel();
				m_marshallServer.SubscribeToCallbacks();
		
				if (m_marshallServer.get_Name() == "")
					return null;

				return new ServerInstance(m_marshallServer, eventHandler);
			}
			catch
			{
				if (m_marshallServer != null)
				{
					((ICommunicationObject)m_marshallServer).Abort();
				}
				return null;
			}
		}
		#endregion
	}
#endregion
}
