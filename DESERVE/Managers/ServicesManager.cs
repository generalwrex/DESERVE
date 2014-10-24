using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using System.ServiceModel.Web;
using System.ServiceModel.Security;

using System.ServiceModel;
using System.ServiceModel.Description;

namespace DESERVE.Managers
{
	static class ServicesManager
	{
		#region Fields

		private static ServiceHost m_pipedServerService;
		private static bool m_isOpen;
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

		public static void StartService(this ServiceHost service)
		{
			try
			{
				service.Open();
				LogManager.MainLog.WriteLineAndConsole("Piped Service Opened at '" + service.Description.Endpoints.FirstOrDefault().Address + "'");
				m_isOpen = true;
			}
			catch (CommunicationException ex)
			{
				Console.WriteLine("Service Communication exception occurred ( see ErrorLog for more details ): " + ex.Message);
				LogManager.ErrorLog.WriteLineAndConsole("Service Communication full exception: " + ex.ToString());
				service.Abort();
				m_isOpen = false;
			}
		}

		public static void StopService(this ServiceHost service)
		{
			service.Abort();
			LogManager.MainLog.WriteLineAndConsole("Piped Service '" + service.Description.Endpoints.FirstOrDefault().Address + "' Stopped");
		}

		#endregion
	}
}
