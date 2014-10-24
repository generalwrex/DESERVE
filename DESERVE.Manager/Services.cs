
using System;
using System.ServiceModel;
using System.Windows.Forms;

using DESERVE.Managers;

using DESERVE.Manager.Marshall;

namespace DESERVE.Manager
{
	internal class Services
	{
		#region "Fields"
		private static IServerMarshall m_marshallServer;
		private static Services m_instance;
		#endregion

		public Services()
		{
			m_instance = this;
		}

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
		public IServerMarshall ConnectToPipe(string instanceName)
		{
			var serverBinding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
			var serverEndpoint = new EndpointAddress("net.pipe://localhost/DESERVE/" + instanceName);
			var serverChannel = new ChannelFactory<IServerMarshall>(serverBinding, serverEndpoint);
			
			try
			{   
				m_marshallServer = serverChannel.CreateChannel();

				if (m_marshallServer.get_Name() == "")
					return null;

				return m_marshallServer;
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
}
