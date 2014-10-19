using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel.Web;
using System.ServiceModel.Security;

using System.ServiceModel;
using System.ServiceModel.Description;

namespace SEEDS
{
	public class ServicesManager
	{
		#region "Fields"
		private static ServiceHost m_serverManagerHost;
		#endregion

		#region "Properties"
		#endregion

		#region "Methods"

		public static bool SetupServerManagerService()
		{
			try
			{
				m_serverManagerHost = CreateServiceEndpoint(typeof(ServerManager), typeof(IServerManager), "ServerManager/", "ServerManager");
				m_serverManagerHost.Open();
			}
			catch (CommunicationException ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole("An exception occurred: " + ex.Message);
				m_serverManagerHost.Abort();
				return false;
			}

			return true;
		}

		private static ServiceHost CreateServiceEndpoint(Type serviceType, Type contractType, string urlExtension, string name)
		{
			try
			{
				Uri baseAddress = new Uri("http://localhost:8005/SEEDS/" + urlExtension);
				ServiceHost selfHost = new ServiceHost(serviceType, baseAddress);

				WSHttpBinding binding = new WSHttpBinding();
				binding.Security.Mode = SecurityMode.Message;
				binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
				selfHost.AddServiceEndpoint(contractType, binding, name);

				ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
				smb.HttpGetEnabled = true;
				selfHost.Description.Behaviors.Add(smb);


				LogManager.MainLog.WriteLineAndConsole("Created WCF service at '" + baseAddress.ToString() + "'");
				

				return selfHost;
			}
			catch (CommunicationException ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole("An exception occurred: " + ex.Message);
				return null;
			}
		}

		#endregion
	}
}
