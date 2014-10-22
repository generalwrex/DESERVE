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
		private const String MPSessionNamespace = "91D02AC963BE35D1F9C1B9FBCFE1722D";


		private static MainGame m_mainGame;
		private static WorldManager m_worldManager;
		private static MPSession m_mpSession;
		#endregion

		#region Properties
		public static MainGame MainGame { get { return m_mainGame; } }
		public static WorldManager WorldManager { get { return m_worldManager; } }
		public static MPSession MPSession { get { return m_mpSession; } }
		#endregion

		#region Methods
		public SandboxGameWrapper(Assembly Assembly)
			: base(Assembly)
		{
			m_mainGame = new MainGame(Assembly, MainGameNamespace);
			m_worldManager = new WorldManager(Assembly, WorldManagerNamespace);
			m_mpSession = new MPSession(Assembly, MPSessionNamespace);
		}
		#endregion
	}
}
