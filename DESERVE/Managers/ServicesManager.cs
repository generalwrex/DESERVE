using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using System.ServiceModel.Web;
using System.ServiceModel.Security;

using System.ServiceModel;
using System.ServiceModel.Description;

using DESERVE.Common.Marshall;

namespace DESERVE.Managers
{
	static class ServicesManager
	{
		#region Fields

		private static ServiceHost m_pipedServerService;
		private static bool m_isOpen;
		private static int m_maxReconnectAttempts = 5;
		private static int m_connectionAttempts;
		#endregion

		#region Properties
		public static bool IsOpened
		{
			get { return m_isOpen; }
		}

		#endregion

		#region Methods


		public static ServiceHost CreatePipedService(string instanceName, int maxConnections)
		{
			try
			{
				m_pipedServerService = new ServiceHost(typeof(ServerMarshall), new Uri("http://localhost:8000/DESERVE"));

				NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);

				binding.MaxConnections = maxConnections;

				m_pipedServerService.AddServiceEndpoint(typeof(IServerMarshall), binding, "net.pipe://localhost/DESERVE/" + instanceName);

				ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
				smb.HttpGetEnabled = true;

				m_pipedServerService.Description.Behaviors.Add(smb);

				LogManager.MainLog.WriteLineAndConsole("Piped Service Created Successfully!");

				m_pipedServerService.Closed += m_pipedServerService_Closed;
				m_pipedServerService.Closing += m_pipedServerService_Closing;
				m_pipedServerService.Faulted += m_pipedServerService_Faulted;
				m_pipedServerService.Opened += m_pipedServerService_Opened;

				return m_pipedServerService;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Service Creation Exception( see ErrorLog for more details ): " + ex.Message);
				LogManager.ErrorLog.WriteLine("Service Creation Full Exception: " + ex.ToString());

				m_pipedServerService.Abort();
				return null;
			}
		}

		static void m_pipedServerService_Opened(object sender, EventArgs e)
		{
			m_isOpen = true;
			LogManager.MainLog.WriteLineAndConsole("Piped Service Opened at '" + m_pipedServerService.Description.Endpoints.FirstOrDefault().Address + "'");
		}

		static void m_pipedServerService_Faulted(object sender, EventArgs e)
		{
			LogManager.ErrorLog.WriteLineAndConsole("Pipe Service Faulted: Reopening Pipe ");

			if (!m_isOpen)
			{
				StartService(m_pipedServerService);
			}
		}

		static void m_pipedServerService_Closing(object sender, EventArgs e)
		{		
		}

		static void m_pipedServerService_Closed(object sender, EventArgs e)
		{
			m_isOpen = false;
			LogManager.MainLog.WriteLineAndConsole("Piped Service '" + m_pipedServerService.Description.Endpoints.FirstOrDefault().Address + "' Closed");
		}


		public static void StartService(this ServiceHost service)
		{
			try
			{
				m_connectionAttempts++;

				if(m_connectionAttempts < m_maxReconnectAttempts)
					service.Open();	
			}
			catch (CommunicationException ex)
			{
				Console.WriteLine("Service Communication exception occurred ( see ErrorLog for more details ): " + ex.Message);
				LogManager.ErrorLog.WriteLineAndConsole("Service Communication full exception: " + ex.ToString());
				service.Abort();
				m_isOpen = false;
			}
		}

		#endregion
	}
}
