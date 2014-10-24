using DESERVE.Managers;

using DESERVE.Manager.Marshall;

namespace DESERVE.Manager
{
	public class Server
	{
		private IServerMarshall m_clientMarshall;


		public string Name { get; set; }
		public bool IsRunning { get; set; }
		public IServerMarshall Instance { get; set; }

		public CommandLineArgs Arguments { get; set; }

		public string ArgumentsString { get; set; }


		public bool ConnectToServer(string instanceName)
		{
			m_clientMarshall = Services.Instance.ConnectToPipe(instanceName);

			if (m_clientMarshall == null)
				return false;

			this.Instance = m_clientMarshall;
			this.Name = m_clientMarshall.get_Name();
			this.IsRunning = m_clientMarshall.get_IsRunning();
			this.Arguments = m_clientMarshall.get_Arguments();
			this.ArgumentsString = Arguments.FullString;

			return true;
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

