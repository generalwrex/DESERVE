using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DESERVE.ReflectionWrappers.SandboxGameWrappers
{
	class SandboxGameWrapper : ReflectionAssemblyWrapper
	{
		#region Fields
		private const String MainGameNamespace = "B337879D0C82A5F9C44D51D954769590";
		private const String ServerCoreNamespace = "168638249D29224100DB50BB468E7C07";
		private const String WorldManagerNamespace = "AAC05F537A6F0F6775339593FBDFC564";


		private static MainGame m_mainGame;
		private static ServerCore m_serverCore;
		private static WorldManager m_worldManager;
		#endregion

		#region Properties
		public static MainGame MainGame { get { return m_mainGame; } }
		public static ServerCore ServerCore { get { return m_serverCore; } }
		public static WorldManager WorldManager { get { return m_worldManager; } }
		#endregion

		#region Methods
		public SandboxGameWrapper(Assembly Assembly)
			: base(Assembly)
		{
			m_mainGame = new MainGame(Assembly, MainGameNamespace);
			m_serverCore = new ServerCore(Assembly, ServerCoreNamespace);
			m_worldManager = new WorldManager(Assembly, WorldManagerNamespace);
		}
		#endregion
	}
}
