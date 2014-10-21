using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading;
using System.Reflection;
using System.Globalization;
using VRage.Common.Utils;
using SysUtils.Utils;
using SEEDS.ReflectionWrappers.DedicatedServerWrappers;
using SEEDS.ReflectionWrappers.SandboxGameWrappers;


namespace SEEDS
{
	[DataContract]
	public class ServerManager : IServerManager
	{
		#region Fields
		private List<ServerInstance> m_serverInstances;
		#endregion

		#region Properties
		[DataMember]
		public List<ServerInstance> ServerInstances { get { return m_serverInstances; } }
		#endregion

		#region Methods
		public ServerManager()
		{
			m_serverInstances = new List<ServerInstance>();
		}

		public List<ServerInstance> GetServerInstances()
		{
			return m_serverInstances;
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

	[DataContract]
	public class ServerInstance
	{
		#region Fields
		private String m_saveFile;
		private Thread m_serverThread;
		private DedicatedServerWrapper m_server;
		private Boolean m_isRunning;

		#endregion

		#region Properties
		public String Name { get { return m_saveFile; } }
		public Boolean IsRunning { get { return m_isRunning; } }
		#endregion

		#region Methods

		public ServerInstance(string saveFile)
		{
			this.m_saveFile = saveFile;
			m_server = new DedicatedServerWrapper();
		}

		public void Start()
		{

			object[] args = new object[]
				{
					"Project Vengeance",
					"",
					true,
					true
				};

			m_serverThread = DedicatedServerWrapper.Program.StartServer(args);

		}

		public void Stop()
		{
			SandboxGameWrapper.MainGame.SignalShutdown();
			m_serverThread.Join(60000);
			m_serverThread.Abort();
		}
		#endregion
	}
}
