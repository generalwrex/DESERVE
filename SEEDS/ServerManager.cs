using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEEDS
{
	class ServerManager
	{
		#region Attributes
		private List<ServerInstance> m_serverInstances;
		#endregion

		#region Properties
		public List<ServerInstance> ServerInstances { get { return m_serverInstances; } }
		#endregion

		#region Methods
		public ServerManager()
		{
			m_serverInstances = new List<ServerInstance>();
		}

		public void StartServer(string saveFile)
		{
			ServerInstance server = new ServerInstance(saveFile);
			m_serverInstances.Add(server);
			server.Start();
		}

		public void StopServer(ServerInstance server)
		{
			server.Stop();
			m_serverInstances.Remove(server);
		}

		public void StopAllServers()
		{
			foreach (ServerInstance instance in ServerInstances)
			{
				instance.Stop();
			}
		}
		#endregion
	}
}
