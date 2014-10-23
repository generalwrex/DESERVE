using DESERVE.Managers;

namespace DESERVE.Manager
{
	public class Server
	{
		private IServerMarshall m_clientMarshall;
		
		public string Name
		{
			get { return m_clientMarshall.Name; }
		}

		public bool IsRunning
		{
			get { return m_clientMarshall.IsRunning; }
		}

		public CommandLineArgs Arguments
		{
			get { return m_clientMarshall.Arguments; }
		}

		public void ConnectToServer(string instanceName)
		{
			m_clientMarshall = Services.Instance.ConnectToPipe(instanceName);		
		}

		public void StartServer()
		{
			ProcessManager.StartServer(this.Arguments);
		}

		public void StopServer()
		{
			m_clientMarshall.Stop();
		}

		public void Save()
		{
			m_clientMarshall.Save();
		}





	}
}

