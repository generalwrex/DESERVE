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

		#endregion

		#region Events
		public event ServerStateEvent ServerStarted;
		public event ServerStateEvent ServerStopped;
		#endregion

		#region Properties
		public static ServerInstance Instance { get { return m_serverInstance; } }

		public String Name { get { return m_saveFile; } }
		public Boolean IsRunning { get; set; }
		public Int32 CurrentPlayers { get { throw new NotImplementedException(); } }
		public TimeSpan Uptime { get { throw new NotImplementedException(); } }
		public TimeSpan LastSave { get { throw new NotImplementedException(); } }
		#endregion

		#region Methods
		public ServerInstance(CommandLineArgs args)
		{
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

		public void Save(Boolean enhancedSave = false)
		{
			SandboxGameWrapper.WorldManager.Save();
		}
		#endregion
	}
}
