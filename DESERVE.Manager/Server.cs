using DESERVE.Managers;

using DESERVE.Manager.Marshall;

namespace DESERVE.Manager
{
	public class Server
	{
		#region Fields
		private IServerMarshall m_clientMarshall;
		private DESERVEEventHandler m_eventHandler;
		private static ServerInstance m_serverInstance;
		#endregion

		#region Events
		public delegate void ServerChangedHandler(IServerMarshall marshall);
		public event ServerChangedHandler ServerChanged;
		#endregion

		#region Properties
		public string Name { get; set; }
		public bool IsRunning { get; set; }
		public IServerMarshall Instance { get; set; }
		public DESERVEEventHandler Events { get; set; }
		public CommandLineArgs Arguments { get; set; }
		public string ArgumentsString { get; set; }
		#endregion

		#region Methods
		public bool ConnectToServer(string instanceName)
		{
			m_serverInstance = Services.Instance.ConnectToPipe(instanceName);

			m_clientMarshall = m_serverInstance.ServerMarshall;
			m_eventHandler = m_serverInstance.ServerEvents;
			
			if (m_clientMarshall == null)
				return false;


			this.Instance = m_clientMarshall;
			this.Events = m_eventHandler;
			this.Name = m_clientMarshall.get_Name();
			this.IsRunning = m_clientMarshall.get_IsRunning();
			this.Arguments = m_clientMarshall.get_Arguments();
			this.ArgumentsString = Arguments.FullString;

			m_eventHandler.ServerStarted += m_eventHandler_ServerStarted;
			m_eventHandler.ServerStopped += m_eventHandler_ServerStopped;

			return true;
		}

		void m_eventHandler_ServerStopped()
		{
			if( ServerChanged != null)
				ServerChanged(m_clientMarshall);
		}

		void m_eventHandler_ServerStarted()
		{
			if (ServerChanged != null)
				ServerChanged(m_clientMarshall);
		}

		public void StopServer()
		{
			m_clientMarshall.Stop();
		}

		public void Save()
		{
			m_clientMarshall.Save();
		}
		#endregion
	}
}

