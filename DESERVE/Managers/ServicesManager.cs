using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel.Web;
using System.ServiceModel.Security;

using System.ServiceModel;
using System.ServiceModel.Description;

namespace DESERVE.Managers
{
	static class ServicesManager
	{
		#region "Fields"

		private static ServiceHost m_pipedServerService;
		private static bool m_isOpen;
		#endregion

		#region "Properties"
		public static bool IsOpened
		{
			get { return m_isOpen; }
		}
		#endregion

		#region "Methods"

		public static ServiceHost CreatePipedService(string instanceName, int maxConnections)
		{
			try
			{
				m_pipedServerService = new ServiceHost(typeof(ServerMarshall), new Uri("http://localhost:8000/DESERVE"));

				NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);

				binding.MaxConnections = maxConnections;

				m_pipedServerService.AddServiceEndpoint(typeof(IServerMarshall), binding, "net.pipe://localhost/DESERVE/" + instanceName);



				ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
				smb.HttpGetEnabled = true; // for updating service references
				m_pipedServerService.Description.Behaviors.Add(smb);

				LogManager.MainLog.WriteLineAndConsole("Piped Service Created Successfully!");

				return m_pipedServerService;
			}
			catch (Exception ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole("Service Creation Exception: " + ex.Message);
				m_pipedServerService.Abort();
				return null;
			}
		}

		public static void StartService(this ServiceHost service)
		{
			try
			{
				service.Open();
				LogManager.MainLog.WriteLineAndConsole("Piped Service Opened at '" + service.Description.Endpoints.FirstOrDefault().Address + "'");
				m_isOpen = true;
			}
			catch (Exception ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole("Service Communication exception occurred: " + ex.Message);
				service.Abort();
				m_isOpen = false;
			}
		}

		public static void StopService(this ServiceHost service)
		{
			service.Abort();
			LogManager.ErrorLog.WriteLineAndConsole("Service '"+ service.BaseAddresses.FirstOrDefault().ToString() + "' Stopped");	
		}

		#endregion

	}
}
