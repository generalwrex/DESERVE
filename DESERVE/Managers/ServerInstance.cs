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
using DESERVE.ReflectionWrappers.DedicatedServerWrappers;
using DESERVE.ReflectionWrappers.SandboxGameWrappers;
using System.ServiceModel;
using DESERVE.Managers;
using DESERVE.Common;


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
		public String Name { get { return m_saveFile; } }
		public Boolean IsRunning { get; set; }
		public static ServerInstance Instance { get { return m_serverInstance; } }
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
