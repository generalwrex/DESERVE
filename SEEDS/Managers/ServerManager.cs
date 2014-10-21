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

		public void StartServer(String saveFile)
		{
			ServerInstance server = new ServerInstance(saveFile);
			m_serverInstances.Add(server);
			server.Start(saveFile);
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
		private DedicatedServerWrapper m_dedicatedServerWrapper;
		private SandboxGameWrapper m_sandboxGameWrapper;
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
			m_dedicatedServerWrapper = new DedicatedServerWrapper(Assembly.UnsafeLoadFrom("SpaceEngineersDedicated.exe"));
			m_sandboxGameWrapper = new SandboxGameWrapper(Assembly.UnsafeLoadFrom("Sandbox.Game.dll"));
		}

		public void Start(String saveFile)
		{

			object[] args = new object[]
				{
					saveFile,
					"",
					true,
					true
				};

			SandboxGameWrapper.ServerCore.NullRender = true;
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
