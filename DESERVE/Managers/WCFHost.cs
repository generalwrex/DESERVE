using DESERVE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace DESERVE.Managers
{
	class WCFHost : IDisposable
	{
		#region Fields
		private static String DefaultPipeName = "Pipe";

		private ServiceHost m_serviceHost;
		private String m_pipeName;
		private Boolean m_operational;
		private WCFService m_service; 
		#endregion

		#region Properties
		public Boolean Operation { get { return m_operational; } }
		#endregion

		#region Methods
		#region Constructors
		public WCFHost(String instanceName)
		{
			m_serviceHost = null;
			m_pipeName = DefaultPipeName ;
			m_operational = false;
			m_service = new WCFService(instanceName);
		}
		#endregion

		/// <summary>
		/// Starts the WCF Hosting services.
		/// </summary>
		public void StartServer()
		{
			try
			{
				m_serviceHost = new ServiceHost(m_service, new Uri(m_service.Uri));

				// Usage BasicHttpBinding can be used if this is
				// not going to be on the local machine.
				m_serviceHost.AddServiceEndpoint(typeof(IWCFService),
					 new NetNamedPipeBinding(),
					 m_service.Uri);
				m_serviceHost.Open();

				m_operational = true;
			}
			catch (Exception ex)
			{
				m_operational = false;
			}
		}

		/// <summary>
		/// Stops the WCF Hosting service.
		/// </summary>
		public void StopServer()
		{
			if (m_serviceHost != null)
			{
				if (m_serviceHost.State != CommunicationState.Closed)
				{
					m_serviceHost.Close();
				}
			}

			m_operational = false;
		}

		public void Dispose()
		{
			StopServer();
			m_service = null;
		}
		#endregion

	}
}
