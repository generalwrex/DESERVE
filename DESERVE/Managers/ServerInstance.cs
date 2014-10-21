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


namespace DESERVE //DEdicated SERVer Enhanced
{
	[ServiceContract]
	public static class ServerInstance
	{
		#region Fields
		private static String m_saveFile;
		private static Thread m_serverThread;
		private static Boolean m_isRunning;

		private static DedicatedServerWrapper m_dedicatedServerWrapper;
		private static SandboxGameWrapper m_sandboxGameWrapper;

		private const String seInstancePath = "C:\\ProgramData\\SpaceEngineersDedicated\\";

		#endregion

		#region Properties
		public static String Name { get { return m_saveFile; } }
		public static Boolean IsRunning { get { return DedicatedServerWrapper.Program.IsRunning; } }
		#endregion

		#region Methods
		[OperationContract]
		public static void Start(CommandLineArgs args)
		{
			m_saveFile = args.Instance;
			m_dedicatedServerWrapper = new DedicatedServerWrapper(Assembly.UnsafeLoadFrom("SpaceEngineersDedicated.exe"));
			m_sandboxGameWrapper = new SandboxGameWrapper(Assembly.UnsafeLoadFrom("Sandbox.Game.dll"));

			Object[] serverArgs = new Object[]
				{
					new String[] {
						"-path",
						seInstancePath + args.Instance,
						"-console",
					}
				};

			SandboxGameWrapper.ServerCore.NullRender = true;
			m_serverThread = DedicatedServerWrapper.Program.StartServer(serverArgs);
		}

		[OperationContract]
		public static void Stop()
		{
			SandboxGameWrapper.MainGame.SignalShutdown();
			m_serverThread.Join(60000);
			m_serverThread.Abort();
			m_isRunning = false;
		}

		[OperationContract]
		public static void Save()
		{
			SandboxGameWrapper.WorldManager.Save();
		}
		#endregion
	}
}
