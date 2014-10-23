
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
		private static IServerMarshall m_marshallClient;
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
			var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
			var endpoint = new EndpointAddress("net.pipe://localhost/DESERVE/" + instanceName);
			var channelFactory = new ChannelFactory<IServerMarshall>(binding, endpoint);

			try
			{
				m_marshallClient = channelFactory.CreateChannel();
				return m_marshallClient;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				if (m_marshallClient != null)
				{
					((ICommunicationObject)m_marshallClient).Abort();
				}
				return null;
			}
		}
		#endregion
	}
}
