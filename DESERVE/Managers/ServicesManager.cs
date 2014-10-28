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
	public class ServicesManager
	{
		#region Fields
		private static ServicesManager m_instance;
		private static ServiceHost m_service;
		private static IManagerMarshall m_managerMarshall;

		private System.Timers.Timer m_serviceCheckTimer;
		private static int m_maxReopenAttempts;
		private static int m_reopenAttempts;
		#endregion


		public ServicesManager()
		{
			m_instance = this;

			m_maxReopenAttempts = 5;

			m_serviceCheckTimer = new System.Timers.Timer();
			m_serviceCheckTimer.AutoReset = true;
			m_serviceCheckTimer.Interval = 60000;
			m_serviceCheckTimer.Elapsed += CheckService_Elapsed;
		}



		#region Properties

		public static ServicesManager Instance
		{
			get
			{
				if (m_instance == null)
					m_instance = new ServicesManager();

				return m_instance;
			}
		}
		#endregion

		#region Events
		

		private void CheckService_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			try
			{
				CheckService();
			}
			catch (Exception ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(ex.ToString());
			}
			
		}

		void Service_Faulted(object sender, EventArgs e)
		{
			try
			{
				CheckService();
			}
			catch (Exception ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(ex.ToString());
			}
			
		}

		void Service_Opened(object sender, EventArgs e)
		{
			try
			{
				LogManager.MainLog.WriteLineAndConsole("Piped Service Opened at '" + m_service.Description.Endpoints.FirstOrDefault().Address + "'");
				ConnectToManager(DESERVE.Arguments.Instance);
				m_serviceCheckTimer.Start();
				m_reopenAttempts = 0;
			}
			catch (Exception ex)
			{
				LogManager.ErrorLog.WriteLineAndConsole(ex.ToString());
			}
			
		}
		#endregion


		#region Methods
		public void CreatePipedService(string instanceName, int maxConnections )
		{
			try
			{
				m_service = new ServiceHost(typeof(ServerMarshall), new Uri("net.pipe://localhost/DESERVE/" + instanceName));

				NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
				binding.MaxConnections = maxConnections;
				binding.ReceiveTimeout = TimeSpan.MaxValue;

				m_service.AddServiceEndpoint(typeof(IServerMarshall), binding, "net.pipe://localhost/DESERVE/" + instanceName);
				m_service.Description.Behaviors.Add(new ServiceMetadataBehavior(){HttpGetEnabled = false});

				LogManager.MainLog.WriteLineAndConsole("Piped Service Created Successfully!");

				// connection events
				m_service.Faulted += Service_Faulted;
				m_service.Opened += Service_Opened;

				m_service.Open();
				
			}
			catch (CommunicationException ex)
			{
				LogManager.ErrorLog.WriteLine("Piped Service Creation Exception: " + ex.ToString());
			}
		}

		public void CheckService()
		{
			if (m_service.State == CommunicationState.Faulted || m_service.State == CommunicationState.Closed)
			{
				if (m_reopenAttempts < m_maxReopenAttempts)
				{
					m_service.Open();
					m_reopenAttempts++;
				}
				else
				{
					throw new Exception("Could not Reopen Pipe!");
				}
			}
		}

		public void ClosePipe()
		{

		}

		public void ConnectToManager(string instanceName)
		{
			var serverBinding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
			var serverEndpoint = new EndpointAddress("net.pipe://localhost/DESERVE/Manager");
			var serverChannel = new ChannelFactory<IManagerMarshall>(serverBinding, serverEndpoint);

			try
			{
				m_managerMarshall = serverChannel.CreateChannel();

				if (m_managerMarshall != null)
				{
					m_managerMarshall.ReportInstanceName(instanceName);
					m_managerMarshall = null;
					serverChannel.Close();
				}
			}
			catch
			{
				if (m_managerMarshall != null)
				{
					((ICommunicationObject)m_managerMarshall).Abort();
				}
			}
		}

		#endregion
	}
}
