using DESERVE.Common;
using DESERVE.ReflectionWrappers.DedicatedServerWrappers;
using DESERVE.ReflectionWrappers.SandboxGameWrappers;
using System;
using System.Reflection;
using System.Threading;


namespace DESERVE.Managers
{
	public class ServerInstance : IServerInstance
	{
		#region Fields
		private String m_saveFile;
		private Thread m_serverThread;
		private static ServerInstance m_serverInstance;

		private DedicatedServerWrapper m_dedicatedServerWrapper;
		private SandboxGameWrapper m_sandboxGameWrapper;

		private DateTime m_launchedTime;
		private DateTime m_lastSave;

		#endregion

		#region Events
		public event ServerStateEvent ServerStarted;
		public event ServerStateEvent ServerStopped;
		#endregion

		#region Properties
		public static ServerInstance Instance { get { return m_serverInstance; } }

		public String Name { get { return m_saveFile; } }
		public Boolean IsRunning { get; set; }
		public Int32 CurrentPlayers { get; set; }
		public TimeSpan Uptime { get { return DateTime.Now - m_launchedTime; } }
		public DateTime LastSave { get { return m_lastSave; } }
		#endregion

		#region Methods
		public ServerInstance(CommandLineArgs args)
		{
			m_launchedTime = DateTime.Now;
			m_saveFile = args.Instance;
			m_serverThread = null;
			m_serverInstance = this;
			m_dedicatedServerWrapper = new DedicatedServerWrapper(Assembly.UnsafeLoadFrom("SpaceEngineersDedicated.exe"));
			m_sandboxGameWrapper = new SandboxGameWrapper(Assembly.UnsafeLoadFrom("Sandbox.Game.dll"));
		}

		public void Start()
		{
			Object[] serverArgs = new Object[]
				{
					new String[] {
						"-path",
						DESERVE.InstanceDirectory,
						"-noconsole",
					}
				};

			m_serverThread = DedicatedServerWrapper.Program.StartServer(serverArgs);

			m_dedicatedServerWrapper.Init();
			m_sandboxGameWrapper.Init();
		}

		public void Stop()
		{
			SandboxGameWrapper.MainGame.SignalShutdown();
			m_serverThread.Join(60000);
			m_serverThread.Abort();
		}

		public void Save()
		{
			bool enhancedSave = true;
			m_lastSave = DateTime.Now;
			if (enhancedSave)
			{
				SandboxGameWrapper.WorldManager.EnhancedSave();
			}
			else
			{
				SandboxGameWrapper.WorldManager.Save();
			}
		}
		#endregion
	}
}
